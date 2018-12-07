using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixConv
    {
        // Conversion from 8 bpp grayscale to 1, 2, 4 and 8 bpp
        public static Pix pixThreshold8(this Pix pixs, int d, int nlevels, int cmapflag)
        {
            throw new NotImplementedException();
        }


        // Conversion from colormap to full color or grayscale
        public static Pix pixRemoveColormapGeneral(this Pix pixs, int type, int ifnocmap)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRemoveColormap(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }


        // Add colormap losslessly(8 to 8)
        public static int pixAddGrayColormap8(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixAddMinimalGrayColormap8(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Conversion from RGB color to grayscale
        public static Pix pixConvertRGBToLuminance(this Pix pixs)
        {
            var pointer = Native.DllImports.pixConvertRGBToLuminance((HandleRef)pixs);
            return new Pix(pointer);
        }

        public static Pix pixConvertRGBToGray(this Pix pixs, float rwt, float gwt, float bwt)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertRGBToGrayFast(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertRGBToGrayMinMax(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertRGBToGraySatBoost(this Pix pixs, int refval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertRGBToGrayArb(this Pix pixs, float rc, float gc, float bc)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertRGBToBinaryArb(this Pix pixs, float rc, float gc, float bc, int thresh, int relation)
        {
            throw new NotImplementedException();
        }


        // Conversion from grayscale to colormap
        public static Pix pixConvertGrayToColormap(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertGrayToColormap8(this Pix pixs, int mindepth)
        {
            throw new NotImplementedException();
        }


        // Colorizing conversion from grayscale to color
        public static Pix pixColorizeGray(this Pix pixs, uint color, int cmapflag)
        {
            throw new NotImplementedException();
        }


        // Conversion from RGB color to colormap
        public static Pix pixConvertRGBToColormap(this Pix pixs, int ditherflag)
        {
            throw new NotImplementedException();
        }


        // Conversion from colormap to 1 bpp
        public static Pix pixConvertCmapTo1(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Quantization for relatively small number of colors in source
        public static int pixQuantizeIfFewColors(this Pix pixs, int maxcolors, int mingraycolors, int octlevel, out Pix ppixd)
        {
            throw new NotImplementedException();
        }


        // Conversion from 16 bpp to 8 bpp
        public static Pix pixConvert16To8(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }


        // Conversion from grayscale to false color
        public static Pix pixConvertGrayToFalseColor(this Pix pixs, float gamma)
        {
            var pointer = Native.DllImports.pixConvertGrayToFalseColor((HandleRef)pixs, gamma);
            return new Pix(pointer);
        }


        // Unpacking conversion from 1 bpp to 2, 4, 8, 16 and 32 bpp
        public static Pix pixUnpackBinary(this Pix pixs, int depth, int invert)
        {
            if (null == pixs)
                throw new ArgumentNullException("pixs cannot be null.");

            if (pixs.Depth != 1)
                throw new ArgumentException("pixs not 1 bpp.");

            if (depth != 2 && depth != 4 && depth != 8 && depth != 16 && depth != 32)
                throw new ArgumentException("depth not 2, 4, 8, 16, or 32 bpp.");

            Pix pixd = Pix.Create(pixs.Width, pixs.Height, depth);

            if (pixs.Depth == 2)
            {
                if (invert == 0)
                    pixConvert1To2(pixd, pixs, 0, 3);
                else
                    pixConvert1To2(pixd, pixs, 3, 0);
            }
            else if (depth == 4)
            {
                if (invert == 0)
                    pixConvert1To4(pixd, pixs, 0, 15);
                else  /* invert bits */
                    pixConvert1To4(pixd, pixs, 15, 0);
            }
            else if (depth == 8)
            {
                if (invert == 0)
                    pixConvert1To8(pixd, pixs, 0, 255);
                else  /* invert bits */
                    pixConvert1To8(pixd, pixs, 255, 0);
            }
            else if (depth == 16)
            {
                if (invert == 0)
                    pixConvert1To16(pixd, pixs, 0, 0xffff);
                else  /* invert bits */
                    pixConvert1To16(pixd, pixs, 0xffff, 0);
            }
            else
            {
                if (invert == 0)
                    pixConvert1To32(pixd, pixs, 0, 0xffffffff);
                else
                    pixConvert1To32(pixd, pixs, 0xffffffff, 0);
            }

            return pixd;
        }

        public static Pix pixConvert1To16(this Pix pixd, Pix pixs, ushort val0, ushort val1)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert1To32(this Pix pixd, Pix pixs, uint val0, uint val1)
        {
            if (null == pixs)
                throw new ArgumentNullException("pixs cannot be null.");

            if (pixs.Depth != 1)
                throw new ArgumentException("pixs not 1 bpp.");

            if (null != pixd)
            {
                if (pixs.Width != pixd.Width || pixs.Height != pixd.Height)
                    throw new ArgumentException("pix sizes unequal.");
                if (pixd.Depth != 32)
                    throw new ArgumentException("pixd not 32 bpp.");
            }
            else
            {
                pixd = Pix.Create(pixs.Width, pixs.Height, 32);
            }
            Native.DllImports.pixCopyResolution((HandleRef)pixd, (HandleRef)pixs);

            var pointer = Native.DllImports.pixConvert1To32((HandleRef)pixd, (HandleRef)pixs, val0, val1);
            return new Pix(pointer);
        }


        // Unpacking conversion from 1 bpp to 2 bpp
        public static Pix pixConvert1To2Cmap(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert1To2(this Pix pixd, Pix pixs, int val0, int val1)
        {
            if (null == pixs)
                throw new ArgumentNullException("pixs cannot be null.");

            if (pixs.Depth != 1)
                throw new ArgumentException("pixs not 1 bpp.");

            if (null != pixd)
            {
                if (pixs.Width != pixd.Width || pixs.Height != pixd.Height)
                    throw new ArgumentException("pix sizes unequal.");
                if (pixd.Depth != 2)
                    throw new ArgumentException("pixd not 2 bpp.");
            }
            else
            {
                pixd = Pix.Create(pixs.Width, pixs.Height, 2);
            }
            Native.DllImports.pixCopyResolution((HandleRef)pixd, (HandleRef)pixs);
            var pointer = Native.DllImports.pixConvert1To2((HandleRef)pixd, (HandleRef)pixs, val0, val1);
            return new Pix(pointer);
        }

        // Unpacking conversion from 1 bpp to 4 bpp
        public static Pix pixConvert1To4Cmap(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert1To4(this Pix pixd, Pix pixs, int val0, int val1)
        {
            throw new NotImplementedException();
        }


        // Unpacking conversion from 1, 2 and 4 bpp to 8 bpp
        public static Pix pixConvert1To8Cmap(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert1To8(this Pix pixd, Pix pixs, byte val0, byte val1)
        {
            if (null == pixs)
                throw new ArgumentNullException("pixs cannot be null.");

            if (pixs.Depth != 1)
                throw new ArgumentException("pixs not 1 bpp.");

            if (null != pixd)
            {
                if (pixs.Width != pixd.Width || pixs.Height != pixd.Height)
                    throw new ArgumentException("pix sizes unequal.");
                if (pixd.Depth != 8)
                    throw new ArgumentException("pixd not 8 bpp.");
            }
            else
            {
                pixd = Pix.Create(pixs.Width, pixs.Height, 8);
            }
            Native.DllImports.pixCopyResolution((HandleRef)pixd, (HandleRef)pixs);
            var pointer = Native.DllImports.pixConvert1To8((HandleRef)pixd, (HandleRef)pixs, val0, val1);
            return new Pix(pointer);
        }

        public static Pix pixConvert2To8(this Pix pixs, byte val0, byte val1, byte val2, byte val3, int cmapflag)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert4To8(this Pix pixs, int cmapflag)
        {
            throw new NotImplementedException();
        }

        // Unpacking conversion from 8 bpp to 16 bpp
        public static Pix pixConvert8To16(this Pix pixs, int leftshift)
        {
            throw new NotImplementedException();
        }

        // Top-level conversion to 1 bpp
        public static Pix pixConvertTo1(this Pix pixs, int threshold)
        {
            var pointer = Native.DllImports.pixConvertTo1((HandleRef)pixs, threshold);
            return new Pix(pointer);
        }

        public static Pix pixConvertTo1BySampling(this Pix pixs, int factor, int threshold)
        {
            throw new NotImplementedException();
        }

        // Top-level conversion to 8 bpp
        public static Pix pixConvertTo8(this Pix pixs, int cmapflag)
        {
            var pointer = Native.DllImports.pixConvertTo8((HandleRef)pixs, cmapflag);
            return new Pix(pointer);
        }

        public static Pix pixConvertTo8BySampling(this Pix pixs, int factor, int cmapflag)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertTo8Color(this Pix pixs, int dither)
        {
            throw new NotImplementedException();
        }


        // Top-level conversion to 16 bpp
        public static Pix pixConvertTo16(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Top-level conversion to 32 bpp(RGB)
        public static Pix pixConvertTo32(this Pix pixs)
        {
            var pointer = Native.DllImports.pixConvertTo32((HandleRef)pixs);
            return new Pix(pointer);
        }

        public static Pix pixConvertTo32BySampling(this Pix pixs, int factor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert8To32(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Top-level conversion to 8 or 32 bpp, without colormap
        public static Pix pixConvertTo8Or32(this Pix pixs, int copyflag, int warnflag)
        {
            throw new NotImplementedException();
        }


        // Conversion between 24 bpp and 32 bpp rgb
        public static Pix pixConvert24To32(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert32To24(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Conversion between 32 bpp(1 spp) and 16 or 8 bpp
        public static Pix pixConvert32To16(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvert32To8(this Pix pixs, int type16, int type8)
        {
            throw new NotImplementedException();
        }


        // Removal of alpha component by blending with white background
        public static Pix pixRemoveAlpha(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Addition of alpha component to 1 bpp
        public static Pix pixAddAlphaTo1bpp(this Pix pixd, Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Lossless depth conversion(unpacking)
        public static Pix pixConvertLossless(this Pix pixs, int d)
        {
            throw new NotImplementedException();
        }


        // Conversion for printing in PostScript
        public static Pix pixConvertForPSWrap(this Pix pixs)
        {
            throw new NotImplementedException();
        }


        // Scaling conversion to subpixel RGB
        public static Pix pixConvertToSubpixelRGB(this Pix pixs, float scalex, float scaley, int order)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertGrayToSubpixelRGB(this Pix pixs, float scalex, float scaley, int order)
        {
            throw new NotImplementedException();
        }

        public static Pix pixConvertColorToSubpixelRGB(this Pix pixs, float scalex, float scaley, int order)
        {
            throw new NotImplementedException();
        }


        // Setting neutral point for min/max boost conversion to gray
        public static void l_setNeutralBoostVal(int val)
        {
            throw new NotImplementedException();
        }
    }
}
