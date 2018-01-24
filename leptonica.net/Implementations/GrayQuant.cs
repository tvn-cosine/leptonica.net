using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class GrayQuant
    {
        // Floyd-Steinberg dithering to binary
        public static Pix pixDitherToBinary(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDitherToBinary((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDitherToBinarySpec(this Pix pixs, int lowerclip, int upperclip)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDitherToBinarySpec((HandleRef)pixs, lowerclip, upperclip);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Simple(pixelwise) binarization with fixed threshold
        public static Pix pixThresholdToBinary(this Pix pixs, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixThresholdToBinary((HandleRef)pixs, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Binarization with variable threshold
        public static Pix pixVarThresholdToBinary(this Pix pixs, Pix pixg)
        {
            if (null == pixs
             || null == pixg)
            {
                throw new ArgumentNullException("pixs, pixg cannot be null");
            }

            var pointer = Native.DllImports.pixVarThresholdToBinary((HandleRef)pixs, (HandleRef)pixg);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Binarization by adaptive mapping
        public static Pix pixAdaptThresholdToBinary(this Pix pixs, Pix pixm, float gamma)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAdaptThresholdToBinary((HandleRef)pixs, (HandleRef)pixm, gamma);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixAdaptThresholdToBinaryGen(this Pix pixs, Pix pixm, float gamma, int blackval, int whiteval, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAdaptThresholdToBinaryGen((HandleRef)pixs, (HandleRef)pixm, gamma, blackval, whiteval, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generate a binary mask from pixels of particular values
        public static Pix pixGenerateMaskByValue(this Pix pixs, int val, int usecmap)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGenerateMaskByValue((HandleRef)pixs, val, usecmap);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixGenerateMaskByBand(this Pix pixs, int lower, int upper, int inband, int usecmap)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGenerateMaskByBand((HandleRef)pixs, lower, upper, inband, usecmap);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Dithering to 2 bpp
        public static Pix pixDitherTo2bpp(this Pix pixs, int cmapflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDitherTo2bpp((HandleRef)pixs, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDitherTo2bppSpec(this Pix pixs, int lowerclip, int upperclip, int cmapflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDitherTo2bppSpec((HandleRef)pixs, lowerclip, upperclip, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Simple(pixelwise) thresholding to 2 bpp with optional cmap
        public static Pix pixThresholdTo2bpp(this Pix pixs, int nlevels, int cmapflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixThresholdTo2bpp((HandleRef)pixs, nlevels, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Simple(pixelwise) thresholding from 8 bpp to 4 bpp
        public static Pix pixThresholdTo4bpp(this Pix pixs, int nlevels, int cmapflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixThresholdTo4bpp((HandleRef)pixs, nlevels, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Simple(pixelwise) quantization on 8 bpp grayscale
        public static Pix pixThresholdOn8bpp(this Pix pixs, int nlevels, int cmapflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixThresholdOn8bpp((HandleRef)pixs, nlevels, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Arbitrary(pixelwise) thresholding from 8 bpp to 2, 4 or 8 bpp
        public static Pix pixThresholdGrayArb(this Pix pixs, string edgevals, int outdepth, int use_average, int setblack, int setwhite)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixThresholdGrayArb((HandleRef)pixs, edgevals, outdepth, use_average, setblack, setwhite);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Quantization tables for linear thresholds of grayscale images
        public static IntPtr makeGrayQuantIndexTable(int nlevels)
        {
            return Native.DllImports.makeGrayQuantIndexTable(nlevels);
        }

        public static IntPtr makeGrayQuantTargetTable(int nlevels, int depth)
        {
            return Native.DllImports.makeGrayQuantTargetTable(nlevels, depth);
        }

        // Quantization table for arbitrary thresholding of grayscale images
        public static int makeGrayQuantTableArb(this Numa na, int outdepth, out IntPtr ptab, out PixColormap pcmap)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            IntPtr pcmapPtr;
            var result = Native.DllImports.makeGrayQuantTableArb((HandleRef)na, outdepth, out ptab, out pcmapPtr);
            pcmap = new PixColormap(pcmapPtr);

            return result;
        }

        public static int makeGrayQuantColormapArb(this Pix pixs, IntPtr tab, int outdepth, out PixColormap pcmap)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pcmapPtr;
            var result = Native.DllImports.makeGrayQuantColormapArb((HandleRef)pixs, tab, outdepth, out pcmapPtr);
            pcmap = new PixColormap(pcmapPtr);

            return result;
        }

        // Thresholding from 32 bpp rgb to 1 bpp (really color quantization, but it's better placed in this file)
        public static Pix pixGenerateMaskByBand32(this Pix pixs, uint refval, int delm, int delp, float fractm, float fractp)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGenerateMaskByBand32((HandleRef)pixs, refval, delm, delp, fractm, fractp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixGenerateMaskByDiscr32(this Pix pixs, uint refval1, uint refval2, int distflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGenerateMaskByDiscr32((HandleRef)pixs, refval1, refval2, distflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Histogram - based grayscale quantization
        public static Pix pixGrayQuantFromHisto(this Pix pixd, Pix pixs, Pix pixm, float minfract, int maxsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGrayQuantFromHisto((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, minfract, maxsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Color quantize grayscale image using existing colormap
        public static Pix pixGrayQuantFromCmap(this Pix pixs, PixColormap cmap, int mindepth)
        {
            if (null == pixs
             || null == cmap)
            {
                throw new ArgumentNullException("pixs, cmap cannot be null");
            }

            var pointer = Native.DllImports.pixGrayQuantFromCmap((HandleRef)pixs, (HandleRef)cmap, mindepth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
    }
}
