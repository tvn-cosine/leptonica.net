using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Basic Pix
    /// </summary>
    public class Pix : LeptonicaObjectBase, IDisposable, ICloneable
    {
        public Pix(IntPtr pointer) : base(pointer)
        {
            if (pointer != null && pointer != IntPtr.Zero)
            {
                Pointer = pointer;
                var bpp = Native.DllImports.pixGetDepth(new HandleRef(this, pointer));
                if (bpp == 1 || bpp > 3)
                    Bitmap = CreateBitmap();
            }
        }

        #region [ Properties ]
        public IntPtr Pointer { get; set; }

        public int Width
        {
            get
            {
                return this.pixGetWidth();
            }
            set
            {
                if (this.pixSetWidth(value))
                {
                    throw new Exception("An error occurred while trying to set the width.");
                }
            }
        }

        public int Height
        {
            get
            {
                return this.pixGetHeight();
            }
            set
            {
                if (this.pixSetHeight(value))
                {
                    throw new Exception("An error occurred while trying to set the height.");
                }
            }
        }

        public int Depth
        {
            get
            {
                return this.pixGetDepth();
            }
            set
            {
                if (this.pixSetDepth(value))
                {
                    throw new Exception("An error occurred while trying to set the depth.");
                }
            }
        }

        public int Spp
        {
            get
            {
                return this.pixGetSpp();
            }
            set
            {
                if (this.pixSetSpp(value))
                {
                    throw new Exception("An error occurred while trying to set the spp.");
                }
            }
        }

        public int Wpl
        {
            get
            {
                return this.pixGetWpl();
            }
            set
            {
                if (this.pixSetWpl(value))
                {
                    throw new Exception("An error occurred while trying to set the wpl.");
                }
            }
        }

        public int Stride { get { return Wpl * 4; } }

        public int RefCount
        {
            get
            {
                return this.pixGetRefcount();
            }
            set
            {
                if (this.pixChangeRefcount(value))
                {
                    throw new Exception("An error occurred while trying to change the refcount.");
                }
            }
        }

        public int XRes
        {
            get
            {
                return this.pixGetXRes();
            }
            set
            {
                if (this.pixSetXRes(value))
                {
                    throw new Exception("An error occurred while trying to set the x res.");
                }
            }
        }

        public int YRes
        {
            get
            {
                return this.pixGetYRes();
            }
            set
            {
                if (this.pixSetYRes(value))
                {
                    throw new Exception("An error occurred while trying to set the y res.");
                }
            }
        }

        public ImageFileFormatTypes InputFormat
        {
            get
            {
                return this.pixGetInputFormat();
            }
            set
            {
                if (this.pixSetInputFormat(value))
                {
                    throw new Exception("An error occurred while trying to set the input format.");
                }
            }
        }

        public PixColormap Colormap
        {
            get
            {
                return this.pixGetColormap();
            }
            set
            {
                if (this.pixSetColormap(value))
                {
                    throw new Exception("An error occurred while trying to set the colormap.");
                }
            }
        }

        public string Text
        {
            get
            {
                return this.pixGetText();
            }
        }

        public IntPtr Data
        {
            get
            {
                return this.pixGetData();
            }
        }

        public string DataHash { get; set; }

        public string ComputeDataHash(ref byte[] data)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                return BitConverter.ToString(md5.ComputeHash(data));
        }

        private Bitmap _bmp;

        public Bitmap Bitmap
        {
            get
            {
                var bmp = CreateBitmap();
                if (bmp != null)
                {
                    _bmp?.Dispose();
                    _bmp = bmp;
                }
                return _bmp;
            }
            set
            {
                if ((_bmp != null) && (!ReferenceEquals(_bmp, value)))
                    _bmp.Dispose();

                _bmp = value;
            }
        }

        private Bitmap CreateBitmap()
        {
            // Check the data to see if it has changed
            var dataSize = Stride * Height;
            byte[] _data = new byte[dataSize];
            Marshal.Copy(Data, _data, 0, _data.Length);
            var hash = ComputeDataHash(ref _data);
            //Array.Clear(_data, 0, _data.Length);
            _data = null;

            if (IsDirty(hash))
                return this.ToBitmap();
            else
                return null;
        }

        private bool IsDirty(string hash)
        {
            if (!hash.Equals(DataHash))
            {
                DataHash = hash;
                return true;
            }
            else
                return false;
        }
        #endregion

        public static Pix Read(string filename)
        {
            return ReadFile.pixRead(filename);
        }

        public bool Write(string filename, ImageFileFormatTypes format)
        {
            return WriteFile.pixWrite(filename, this, format);
        }

        public static Pix Create(int width, int height, int depth)
        {
            return Pix1.pixCreate(width, height, depth);
        }

        public static explicit operator Pix(IntPtr pointer)
        {
            return new Pix(pointer);
        }

        public object Clone()
        {
            return this.pixCopy(null);
        }

        public override string ToString()
        {
            return $"Width: {Width} Height: {Height} Depth: {Depth} Spp: {Spp} Res: {XRes}x{YRes}";
        }

        public static Bitmap Convert(Pix pix, bool includeAlpha = false)
        {
            var pixelFormat = GetPixelFormat(pix);
            var depth = pix.Depth;
            var img = new Bitmap(pix.Width, pix.Height, pixelFormat);

            BitmapData imgData = null;
            try
            {
                // transfer pixel data
                if ((pixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed)
                {
                    TransferPalette(pix, img);
                }

                // transfer data
                imgData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, pixelFormat);

                if (depth == 32)
                    TransferData32(pix, imgData, includeAlpha ? 0 : 255);
                else if (depth == 16)
                    TransferData16(pix, imgData);
                else if (depth == 8)
                    TransferData8(pix, imgData);
                else if (depth == 4)
                    TransferData4(pix, imgData);
                else if (depth == 1)
                    TransferData1(pix, imgData);

                if (pix.XRes > 0 && pix.YRes > 0)
                    img.SetResolution(pix.XRes, pix.YRes);

                return img;
            }
            catch (Exception)
            {
                img.Dispose();
                throw;
            }
            finally
            {
                if (imgData != null)
                {
                    img.UnlockBits(imgData);
                }
            }
        }

        #region [ TransferData ]
        private unsafe static void TransferData32(Pix pix, BitmapData imgData, int alphaMask = 0)
        {
            var imgFormat = imgData.PixelFormat;
            var height = imgData.Height;
            var width = imgData.Width;
            var pixData = pix.pixGetData();
            var wpl = pix.Wpl;

            for (int y = 0; y < height; y++)
            {
                byte* imgLine = (byte*)imgData.Scan0 + (y * imgData.Stride);
                uint* pixLine = (uint*)pixData + (y * wpl);

                for (int x = 0; x < width; x++)
                {
                    //var pixVal = PixColor.FromRgba(pixLine[x]);
                    var value = pixLine[x];
                    //byte* pixelPtr = imgLine + (x << 2);
                    //pixelPtr[0] = pixVal.Blue;
                    //pixelPtr[1] = pixVal.Green;
                    //pixelPtr[2] = pixVal.Red;
                    //pixelPtr[3] = (byte)(alphaMask | pixVal.Alpha); // Allow user to include alpha or not
                    byte* pixelPtr = imgLine + (x << 2);
                    // First Way
                    pixelPtr[0] = (byte)((value >> 8) & 0xFF); //B
                    pixelPtr[1] = (byte)((value >> 16) & 0xFF); //G
                    pixelPtr[2] = (byte)((value >> 24) & 0xFF); //R
                    pixelPtr[3] = (byte)((byte)(value & 0xFF) | alphaMask); //A

                    //// Second Way
                    //var col = ToArgb(value);
                    //pixelPtr[0] = col.B;
                    //pixelPtr[1] = col.G;
                    //pixelPtr[2] = col.R;
                    //pixelPtr[3] = (byte)(col.A | alphaMask);

                    //// Third Way
                    //var a = (value & 0xFF000000) >> 24;
                    //var r = (value & 0x00FF0000) >> 16;
                    //var g = (value & 0x0000FF00) >> 8;
                    //var b = (value & 0x000000FF);

                    //pixelPtr[0] = (byte)b;
                    //pixelPtr[1] = (byte)g;
                    //pixelPtr[2] = (byte)r;
                    //pixelPtr[3] = (byte)((byte)a | alphaMask);

                    //// First Way but clearer
                    //var a = (byte)((byte)(value & 0xFF) | alphaMask); //A
                    //var b = (byte)((value >> 8) & 0xFF); //B
                    //var g = (byte)((value >> 16) & 0xFF); //G
                    //var r = (byte)((value >> 24) & 0xFF); //R
                    //pixelPtr[0] = b;
                    //pixelPtr[1] = g;
                    //pixelPtr[2] = r;
                    //pixelPtr[3] = a;
                }
            }
        }

        private unsafe static void TransferData16(Pix pix, BitmapData imgData)
        {
            var imgFormat = imgData.PixelFormat;
            var height = imgData.Height;
            var width = imgData.Width;
            var pixData = pix.pixGetData();
            var wpl = pix.Wpl;

            for (int y = 0; y < height; y++)
            {
                uint* pixLine = (uint*)pixData + (y * wpl);
                ushort* imgLine = (ushort*)imgData.Scan0 + (y * imgData.Stride);

                for (int x = 0; x < width; x++)
                {
                    var pixVal = (ushort)GetDataTwoByte(pixLine, x);
                    imgLine[x] = pixVal;
                }
            }
        }

        private unsafe static void TransferData8(Pix pix, BitmapData imgData)
        {
            var imgFormat = imgData.PixelFormat;
            var height = imgData.Height;
            var width = imgData.Width;
            var pixData = pix.pixGetData();
            var wpl = pix.Wpl;

            for (int y = 0; y < height; y++)
            {
                uint* pixLine = (uint*)pixData + (y * wpl);
                byte* imgLine = (byte*)imgData.Scan0 + (y * imgData.Stride);

                for (int x = 0; x < width; x++)
                {
                    var pixVal = (byte)GetDataByte(pixLine, x);
                    imgLine[x] = pixVal;
                }
            }
        }

        private unsafe static void TransferData4(Pix pix, BitmapData imgData)
        {
            var imgFormat = imgData.PixelFormat;
            var height = imgData.Height;
            var width = imgData.Width;
            var pixData = pix.pixGetData();
            var wpl = pix.Wpl;

            for (int y = 0; y < height; y++)
            {
                uint* pixLine = (uint*)pixData + (y * wpl);
                byte* imgLine = (byte*)imgData.Scan0.ToPointer();

                for (int x = 0; x < width; x++)
                {
                    var pixVal = (byte)GetDataQBit(pixLine, x);

                    var index = (y * imgData.Stride) + (x >> 1);
                    var curBy = ((byte*)imgData.Scan0)[index];
                    if ((x&1) == 1)
                    {
                        curBy &= 0xf0;
                        curBy |= (byte)(pixVal & 0x0f);
                    }
                    else
                    {
                        curBy &= 0x0f;
                        curBy |= (byte)(pixVal << 4);
                    }

                    imgLine[index] = curBy;
                }
            }
        }

        private unsafe static void TransferData1(Pix pix, BitmapData imgData)
        {
            var imgFormat = imgData.PixelFormat;
            var height = imgData.Height;
            var width = imgData.Width;
            var pixData = pix.pixGetData();
            var wpl = pix.Wpl;

            for (int y = 0; y < height; y++)
            {
                uint* pixLine = (uint*)pixData + (y * wpl);
                byte* imgLine = (byte*)imgData.Scan0.ToPointer();

                for (int x = 0; x < width; x++)
                {
                    var pixVal = (byte)~GetDataBit(pixLine, x);
                    var index = y * imgData.Stride + (x >> 3);
                    var mask = (byte)(0x80 >> (x & 0x7));
                    if (pixVal != 255)
                        imgLine[index] &= (byte)(mask ^ 0xff);
                    else
                        imgLine[index] |= mask;
                }
            }
        }

        private static void TransferPalette(Pix pix, Bitmap img)
        {
            var palette = img.Palette;
            var maxColors = palette.Entries.Length;
            var lastColor = maxColors - 1;
            var colormap = pix.pixGetColormap();// pix.Colormap;
            if (colormap != null && colormap.pixcmapGetCount() <= maxColors)
            {
                var colormapCount = colormap.pixcmapGetCount();
                for (int i = 0; i < colormapCount; i++)
                    palette.Entries[i] = colormap[i];
            }
            else
            {
                for (int i = 0; i < maxColors ; i++)
                {
                    var value = (byte)(i * 255 / lastColor);
                    palette.Entries[i] = Color.FromArgb(value, value, value);
                }
            }

            // This is required to force the palette to update!
            img.Palette = palette;
        }
        #endregion

        private static PixelFormat GetPixelFormat(Pix pix)
        {
            switch (pix.Depth)
            {
                case 1: return PixelFormat.Format1bppIndexed;
                case 2: return PixelFormat.Format4bppIndexed;
                case 4: return PixelFormat.Format4bppIndexed;
                case 8: return PixelFormat.Format8bppIndexed;
                case 16: return PixelFormat.Format16bppGrayScale;
                case 32: return PixelFormat.Format32bppArgb;
                default: throw new InvalidOperationException(String.Format("Pix depth {0} is not supported.", pix.Depth));
            }
        }

        private static Color ToArgb(uint value)
        {
            //return new PixColor(
            //   (byte)((value >> 24) & 0xFF),
            //   (byte)((value >> 16) & 0xFF),
            //   (byte)((value >> 8) & 0xFF),
            //   (byte)(value & 0xFF));

            return Color.FromArgb(
               (byte)(value & 0xFF), //A
               (byte)((value >> 24) & 0xFF), //R
               (byte)((value >> 16) & 0xFF), //G
               (byte)((value >> 8) & 0xFF)); //B
        }

        // Can't get the Disposable pattern working right, so let's go back to the default.
        public void Dispose()
        {
            this.pixDestroy();
        }

        #region [ PixData ]
#if Net45
       	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint EncodeAsRGBA(byte red, byte green, byte blue, byte alpha)
        {
            return (uint)((red << 24) |
                (green << 16) |
                (blue << 8) |
                alpha);
        }

        /// <summary>
        /// Gets the pixel value for a 1bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataBit(uint* data, int index)
        {
            return (*(data + ((index) >> 5)) >> (31 - ((index) & 31))) & 1;
        }

        /// <summary>
        /// Sets the pixel value for a 1bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataBit(uint* data, int index, uint value)
        {
            uint* wordPtr = data + ((index) >> 5);
            *wordPtr &= ~(0x80000000 >> ((index) & 31));
            *wordPtr |= (value << (31 - ((index) & 31)));
        }

        /// <summary>
        /// Gets the pixel value for a 2bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataDIBit(uint* data, int index)
        {
            return (*(data + ((index) >> 4)) >> (2 * (15 - ((index) & 15)))) & 3;
        }

        /// <summary>
        /// Sets the pixel value for a 2bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataDIBit(uint* data, int index, uint value)
        {
            uint* wordPtr = data + ((index) >> 4);
            *wordPtr &= ~(0xc0000000 >> (2 * ((index) & 15)));
            *wordPtr |= (((value) & 3) << (30 - 2 * ((index) & 15)));
        }

        /// <summary>
        /// Gets the pixel value for a 4bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataQBit(uint* data, int index)
        {
            return (*(data + ((index) >> 3)) >> (4 * (7 - ((index) & 7)))) & 0xf;
        }

        /// <summary>
        /// Sets the pixel value for a 4bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataQBit(uint* data, int index, uint value)
        {
            uint* wordPtr = data + ((index) >> 3);
            *wordPtr &= ~(0xf0000000 >> (4 * ((index) & 7)));
            *wordPtr |= (((value) & 15) << (28 - 4 * ((index) & 7)));
        }

        /// <summary>
        /// Gets the pixel value for a 8bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataByte(uint* data, int index)
        {
            // Must do direct size comparison to detect x64 process, since in this will be jited out and results in a lot faster code (e.g. 6x faster for image conversion)
            if (IntPtr.Size == 8)
            {
                return *((byte*)((ulong)((byte*)data + index) ^ 3));
            }
            else
            {
                return *((byte*)((uint)((byte*)data + index)  ^ 3));
            }
            // Architecture types that are NOT little edian are not currently supported
            //return *((byte*)data + index);
        }

        /// <summary>
        /// Sets the pixel value for a 8bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataByte(uint* data, int index, uint value)
        {
            // Must do direct size comparison to detect x64 process, since in this will be jited out and results in a lot faster code (e.g. 6x faster for image conversion)
            if (IntPtr.Size == 8)
            {
                *(byte*)((ulong)((byte*)data + index) ^ 3) = (byte)value;
            }
            else
            {
                *(byte*)((uint)((byte*)data + index) ^ 3) = (byte)value;
            }

            // Architecture types that are NOT little edian are not currently supported
            // *((byte*)data + index) =  (byte)value;
        }

        /// <summary>
        /// Gets the pixel value for a 16bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataTwoByte(uint* data, int index)
        {
            // Must do direct size comparison to detect x64 process, since in this will be jited out and results in a lot faster code (e.g. 6x faster for image conversion)
            if (IntPtr.Size == 8)
            {
                return *(ushort*)((ulong)((ushort*)data + index) ^ 2);
            }
            else
            {
                return *(ushort*)((uint)((ushort*)data + index) ^ 2);
            }
            // Architecture types that are NOT little edian are not currently supported
            // return *((ushort*)data + index);
        }

        /// <summary>
        /// Sets the pixel value for a 16bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataTwoByte(uint* data, int index, uint value)
        {
            // Must do direct size comparison to detect x64 process, since in this will be jited out and results in a lot faster code (e.g. 6x faster for image conversion)
            if (IntPtr.Size == 8)
            {
                *(ushort*)((ulong)((ushort*)data + index) ^ 2) = (ushort)value;
            }
            else
            {
                *(ushort*)((uint)((ushort*)data + index) ^ 2) = (ushort)value;
            }
            // Architecture types that are NOT little edian are not currently supported
            //*((ushort*)data + index) = (ushort)value;
        }

        /// <summary>
        /// Gets the pixel value for a 32bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe uint GetDataFourByte(uint* data, int index)
        {
            return *(data + index);
        }

        /// <summary>
        /// Sets the pixel value for a 32bpp image.
        /// </summary>
#if Net45
      	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static unsafe void SetDataFourByte(uint* data, int index, uint value)
        {
            *(data + index) = value;
        }
        #endregion
    }

    public static class PixCustomExtensions
    {
        /// <summary>
        /// Convert Pix to Bitmap
        /// </summary>
        /// <param name="pixs">Pix Source</param>
        /// <param name="includeAlpha">Should Alpha Channel Be Included</param>
        /// <returns></returns>
        public static Bitmap ToBitmap(this Pix pixs, bool includeAlpha = false)
        {
            return Pix.Convert(pixs, includeAlpha);
        }

        /// <summary>
        /// Convert Pix to 3-dimensional byte array
        /// </summary>
        /// <param name="pixs">Pix Source</param>
        /// <param name="parallel">true to run in parallel, false to run sequentially single threaded</param>
        /// <returns>byte[height][width][3] (r,g,b) </returns>
        public static byte[][][] pixTo3dByteArrayByLine(this Pix pixs, bool parallel = true)
        {
            var h = pixs.Height;
            var w = pixs.Width;
            var nImage = new byte[h][][];

            if (!parallel)
            {
                var rLine = new byte[w];
                var gLine = new byte[w];
                var bLine = new byte[w];
                for (int y = 0; y < h; y++)
                {
                    nImage[y] = new byte[w][];

                    rLine = new byte[w];
                    gLine = new byte[w];
                    bLine = new byte[w];
                    pixs.pixGetRGBLine(y, rLine, gLine, bLine);

                    for (int x = 0; x < rLine.Length; x++)
                        nImage[y][x] = new byte[] { rLine[x], gLine[x], bLine[x] };
                }
                rLine = null;
                gLine = null;
                bLine = null;
            }
            else
            {
                var parallelOpts = new System.Threading.Tasks.ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
                System.Threading.Tasks.Parallel.For(0, h, parallelOpts, y =>
                {
                    nImage[y] = new byte[w][];

                    byte[] rLine = new byte[w];
                    byte[] gLine = new byte[w];
                    byte[] bLine = new byte[w];
                    pixs.pixGetRGBLine(y, rLine, gLine, bLine);

                    for (int x = 0; x < rLine.Length; x++)
                        nImage[y][x] = new byte[] { rLine[x], gLine[x], bLine[x] };
                });
            }
            return nImage;
        }

        /// <summary>
        /// Convert Pix to 3-dimensional byte array
        /// </summary>
        /// <param name="pixs">Source Pix</param>
        /// <param name="parallel">Run in parallel (defaults to true)</param>
        /// <param name="includeAlpha">Return the alpha channel too (defaults to true)</param>
        /// <returns>byte[height][width][3] (r,g,b) or byte[height][width][4] (a,r,g,b)</returns>
        public static byte[][][] pixTo3dByteArray(this Pix pixs, bool parallel = true, bool includeAlpha = false)
        {
            var stride = pixs.Stride;
            byte[] data = new byte[stride * pixs.Height];
            Marshal.Copy(pixs.Data, data, 0, data.Length);
            var byteImage = new byte[pixs.Height][][];
            var w = pixs.Width;
            var dataLen = data.Length / 4;

            if (!parallel)
            {
                for (int i = 0; i < dataLen; i++)
                {
                    var x = i % w;
                    var y = i / w;
                    if (x == 0)
                        byteImage[y] = new byte[w][];
                    var o = (y * stride + x * 4);
                    if (includeAlpha)
                        byteImage[y][x] = new byte[] { data[o], data[o + 3], data[o + 2], data[o + 1] };
                    else // FYI - Data is in BGR layout
                        byteImage[y][x] = new byte[] { data[o + 3], data[o + 2], data[o + 1] };
                }
            }
            else
            {
                var po = new System.Threading.Tasks.ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
                //Precreate array
                System.Threading.Tasks.Parallel.For(0, dataLen, po, i =>
                {
                    //var x = i % w;
                    //var y = i / w;
                    if ((i % w) == 0)
                        byteImage[i / w] = new byte[w][];
                });
                System.Threading.Tasks.Parallel.For(0, dataLen, po, i =>
                {
                    var x = i % w;
                    var y = i / w;
                    var o = (y * stride + x * 4);
                    if (includeAlpha)
                        byteImage[y][x] = new byte[] { data[o], data[o + 3], data[o + 2], data[o + 1] };
                    else // FYI - Data is in BGR layout
                        byteImage[y][x] = new byte[] { data[o + 3], data[o + 2], data[o + 1] };
                });
            }
            return byteImage;
        }
    }
}
