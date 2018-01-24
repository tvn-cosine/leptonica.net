using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ColorContent
    {
        // Builds an image of the color content, on a per-pixel basis, as a measure of the amount of divergence of each color component(R, G, B) from gray.
        public static int pixColorContent(this Pix pixs, int rwhite, int gwhite, int bwhite, int mingray, out Pix ppixr, out Pix ppixg, out Pix ppixb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixrPtr, ppixgPtr, ppixbPtr;
            var result = Native.DllImports.pixColorContent((HandleRef)pixs, rwhite, gwhite, bwhite, mingray, out ppixrPtr, out ppixgPtr, out ppixbPtr);
            ppixr = new Pix(ppixrPtr);
            ppixg = new Pix(ppixgPtr);
            ppixb = new Pix(ppixbPtr);

            return result;
        }

        // Finds the 'amount' of color in an image, on a per-pixel basis, as a measure of the difference of the pixel color from gray.
        public static Pix pixColorMagnitude(this Pix pixs, int rwhite, int gwhite, int bwhite, int type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorMagnitude((HandleRef)pixs, rwhite, gwhite, bwhite, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generates a mask over pixels that have sufficient color and are not too close to gray pixels.
        public static Pix pixMaskOverColorPixels(this Pix pixs, int threshdiff, int mindist)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMaskOverColorPixels((HandleRef)pixs, threshdiff, mindist);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generates mask over pixels within a prescribed cube in RGB space
        public static Pix pixMaskOverColorRange(this Pix pixs, int rmin, int rmax, int gmin, int gmax, int bmin, int bmax)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMaskOverColorRange((HandleRef)pixs, rmin, rmax, gmin, gmax, bmin, bmax);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Finds the fraction of pixels with "color" that are not close to black
        public static int pixColorFraction(this Pix pixs, int darkthresh, int lightthresh, int diffthresh, int factor, out float ppixfract, out float pcolorfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixColorFraction((HandleRef)pixs, darkthresh, lightthresh, diffthresh, factor, out ppixfract, out pcolorfract);
        }

        // Determine if there are significant color regions that are not background in a page image
        public static int pixFindColorRegions(this Pix pixs, Pix pixm, int factor, int lightthresh, int darkthresh, int mindiff, int colordiff, float edgefract, out float pcolorfract, out Pix pcolormask1, out Pix pcolormask2, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pcolormask1Ptr, pcolormask2Ptr;
            var result = Native.DllImports.pixFindColorRegions((HandleRef)pixs, (HandleRef)pixm, factor, lightthresh, darkthresh, mindiff, colordiff, edgefract, out pcolorfract, out pcolormask1Ptr, out pcolormask2Ptr, (HandleRef)pixadb);

            pcolormask1 = new Pix(pcolormask1Ptr);
            pcolormask2 = new Pix(pcolormask2Ptr);

            return result;
        }

        // Finds the number of perceptually significant gray intensities in a grayscale image.
        public static int pixNumSignificantGrayColors(this Pix pixs, int darkthresh, int lightthresh, float minfract, int factor, out int pncolors)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixNumSignificantGrayColors((HandleRef)pixs, darkthresh, lightthresh, minfract, factor, out pncolors);
        }

        // Identifies images where color quantization will cause posterization  due to the existence of many colors in low-gradient regions.
        public static int pixColorsForQuantization(this Pix pixs, int thresh, out int pncolors, out int piscolor, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixColorsForQuantization((HandleRef)pixs, thresh, out pncolors, out piscolor, debug);
        }

        // Finds the number of unique colors in an image
        public static int pixNumColors(this Pix pixs, int factor, out int pncolors)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixNumColors((HandleRef)pixs, factor, out pncolors);
        }

        // Find the most "populated" colors in the image(and quantize)
        public static int pixGetMostPopulatedColors(this Pix pixs, int sigbits, int factor, int ncolors, out IntPtr parray, out PixColormap pcmap)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pcmapPtr;
            var result = Native.DllImports.pixGetMostPopulatedColors((HandleRef)pixs, sigbits, factor, ncolors, out parray, out pcmapPtr);

            pcmap = new PixColormap(pcmapPtr);

            return result;
        }

        public static Pix pixSimpleColorQuantize(this Pix pixs, int sigbits, int factor, int ncolors)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSimpleColorQuantize((HandleRef)pixs, sigbits, factor, ncolors);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Constructs a color histogram based on rgb indices
        public static Numa pixGetRGBHistogram(this Pix pixs, int sigbits, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGetRGBHistogram((HandleRef)pixs, sigbits, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int makeRGBIndexTables(out IntPtr prtab, out IntPtr pgtab, out IntPtr pbtab, int sigbits)
        {
            return Native.DllImports.makeRGBIndexTables(out prtab, out pgtab, out pbtab, sigbits);
        }

        public static int getRGBFromIndex(uint index, int sigbits, out int prval, out int pgval, out int pbval)
        {
            return Native.DllImports.getRGBFromIndex(index, sigbits, out prval, out pgval, out pbval);
        }

        // Identify images that have highlight(red) color
        public static int pixHasHighlightRed(this Pix pixs, int factor, float fract, float fthresh, out int phasred, out float pratio, out Pix ppixdb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixdbPtr;
            var result = Native.DllImports.pixHasHighlightRed((HandleRef)pixs, factor, fract, fthresh, out phasred, out pratio, out ppixdbPtr);
            ppixdb = new Pix(ppixdbPtr);

            return result;
        }
    }
}
