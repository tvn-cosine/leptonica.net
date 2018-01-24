using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class JpegIO
    {
        // Read jpeg from file
        public static Pix pixReadJpeg(string filename, int cmapflag, int reduction, out int pnwarn, int hint)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixReadJpeg(filename, cmapflag, reduction, out pnwarn, hint);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixReadStreamJpeg(IntPtr fp, int cmapflag, int reduction, out int pnwarn, int hint)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixReadStreamJpeg(fp, cmapflag, reduction, out pnwarn, hint);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Read jpeg metadata from file
        public static int readHeaderJpeg(string filename, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            return Native.DllImports.readHeaderJpeg(filename, out pw, out ph, out pspp, out pycck, out pcmyk);
        }

        public static int freadHeaderJpeg(IntPtr fp, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            return Native.DllImports.freadHeaderJpeg(fp, out pw, out ph, out pspp, out pycck, out pcmyk);
        }

        public static int fgetJpegResolution(IntPtr fp, out int pxres, out int pyres)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            return Native.DllImports.fgetJpegResolution(fp, out pxres, out pyres);
        }

        public static int fgetJpegComment(IntPtr fp, out IntPtr pcomment)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            return Native.DllImports.fgetJpegComment(fp, out pcomment);
        }

        // Write jpeg to file
        public static int pixWriteJpeg(string filename, Pix pix, int quality, int progressive)
        {
            if (string.IsNullOrWhiteSpace(filename)
             || null == pix)
            {
                throw new ArgumentNullException("filename, pix cannot be null");
            }

            return Native.DllImports.pixWriteJpeg(filename, (HandleRef)pix, quality, progressive);
        }

        public static int pixWriteStreamJpeg(IntPtr fp, Pix pixs, int quality, int progressive)
        {
            if (IntPtr.Zero == fp
             || null == pixs)
            {
                throw new ArgumentNullException("fp, pixs cannot be null");
            }

            return Native.DllImports.pixWriteStreamJpeg(fp, (HandleRef)pixs, quality, progressive);
        }

        // Read/write to memory
        public static Pix pixReadMemJpeg(IntPtr data, IntPtr size, int cmflag, int reduction, out int pnwarn, int hint)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.pixReadMemJpeg(data, size, cmflag, reduction, out pnwarn, hint);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int readHeaderMemJpeg(IntPtr data, IntPtr size, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            return Native.DllImports.readHeaderMemJpeg(data, size, out pw, out ph, out pspp, out pycck, out pcmyk);
        }

        public static int pixWriteMemJpeg(out IntPtr pdata, IntPtr psize, Pix pix, int quality, int progressive)
        {
            if (IntPtr.Zero == psize
             || null == pix)
            {
                throw new ArgumentNullException("psize, pix cannot be null");
            }

            return Native.DllImports.pixWriteMemJpeg(out pdata, psize, (HandleRef)pix, quality, progressive);
        }

        // Setting special flag for chroma sampling on write
        public static int pixSetChromaSampling(this Pix pix, int sampling)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixSetChromaSampling((HandleRef)pix, sampling);
        }
    }
}
