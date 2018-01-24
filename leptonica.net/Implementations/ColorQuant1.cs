using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ColorQuant1
    {
        // (1) Two-pass adaptive octree color quantization
        public static Pix pixOctreeColorQuant(this Pix pixs, int colors, int ditherflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctreeColorQuant((HandleRef)pixs, colors, ditherflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOctreeColorQuantGeneral(this Pix pixs, int colors, int ditherflag, float validthresh, float colorthresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctreeColorQuantGeneral((HandleRef)pixs, colors, ditherflag, validthresh, colorthresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Helper index functions
        public static int makeRGBToIndexTables(out IntPtr prtab, out IntPtr pgtab, out IntPtr pbtab, int cqlevels)
        {
            return Native.DllImports.makeRGBToIndexTables(out prtab, out pgtab, out pbtab, cqlevels);
        }

        public static void getOctcubeIndexFromRGB(int rval, int gval, int bval, IntPtr rtab, IntPtr gtab, IntPtr btab, out uint pindex)
        {
            if (IntPtr.Zero == rtab
             || IntPtr.Zero == gtab
             || IntPtr.Zero == btab)
            {
                throw new ArgumentNullException("rtab, gtab, btab cannot be null.");
            }

            Native.DllImports.getOctcubeIndexFromRGB(rval, gval, bval, rtab, gtab, btab, out pindex);
        }


        // (2) Adaptive octree quantization based on population at a fixed level
        public static Pix pixOctreeQuantByPopulation(this Pix pixs, int level, int ditherflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctreeQuantByPopulation((HandleRef)pixs, level, ditherflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (3) Adaptive octree quantization to 4 and 8 bpp with specified number of output colors in colormap
        public static Pix pixOctreeQuantNumColors(this Pix pixs, int maxcolors, int subsample)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctreeQuantNumColors((HandleRef)pixs, maxcolors, subsample);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (4) Mixed color/gray quantization with specified number of colors
        public static Pix pixOctcubeQuantMixedWithGray(this Pix pixs, int depth, int graylevels, int delta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctcubeQuantMixedWithGray((HandleRef)pixs, depth, graylevels, delta);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (5) Fixed partition octcube quantization with 256 cells
        public static Pix pixFixedOctcubeQuant256(this Pix pixs, int ditherflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFixedOctcubeQuant256((HandleRef)pixs, ditherflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (6) Fixed partition quantization for images with few colors
        public static Pix pixFewColorsOctcubeQuant1(this Pix pixs, int level)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFewColorsOctcubeQuant1((HandleRef)pixs, level);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFewColorsOctcubeQuant2(this Pix pixs, int level, Numa na, int ncolors, out int pnerrors)
        {
            if (null == pixs
             || null == na)
            {
                throw new ArgumentNullException("pixs, na cannot be null.");
            }

            var pointer = Native.DllImports.pixFewColorsOctcubeQuant2((HandleRef)pixs, level, (HandleRef)na, ncolors, out pnerrors);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFewColorsOctcubeQuantMixed(this Pix pixs, int level, int darkthresh, int lightthresh, int diffthresh, float minfract, int maxspan)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFewColorsOctcubeQuantMixed((HandleRef)pixs, level, darkthresh, lightthresh, diffthresh, minfract, maxspan);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (7) Fixed partition octcube quantization at specified level with quantized output to RGB
        public static Pix pixFixedOctcubeQuantGenRGB(this Pix pixs, int level)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFixedOctcubeQuantGenRGB((HandleRef)pixs, level);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // (8) Color quantize RGB image using existing colormap
        public static Pix pixQuantFromCmap(this Pix pixs, PixColormap cmap, int mindepth, int level, int metric)
        {
            if (null == pixs
             || null == cmap)
            {
                throw new ArgumentNullException("pixs, cmap cannot be null.");
            }

            var pointer = Native.DllImports.pixQuantFromCmap((HandleRef)pixs, (HandleRef)cmap, mindepth, level, metric);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOctcubeQuantFromCmap(this Pix pixs, PixColormap cmap, int mindepth, int level, int metric)
        {
            if (null == pixs
             || null == cmap)
            {
                throw new ArgumentNullException("pixs, cmap cannot be null.");
            }

            var pointer = Native.DllImports.pixOctcubeQuantFromCmap((HandleRef)pixs, (HandleRef)cmap, mindepth, level, metric);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generation of octcube histogram
        public static Numa pixOctcubeHistogram(this Pix pixs, int level, out int pncolors)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOctcubeHistogram((HandleRef)pixs, level, out pncolors);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Get filled octcube table from colormap
        public static IntPtr pixcmapToOctcubeLUT(PixColormap cmap, int level, int metric)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null.");
            }

            return Native.DllImports.pixcmapToOctcubeLUT((HandleRef)cmap, level, metric);
        }

        // Strip out unused elements in colormap
        public static int pixRemoveUnusedColors(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixRemoveUnusedColors((HandleRef)pixs);
        }

        // Find number of occupied octcubes at the specified level
        public static int pixNumberOccupiedOctcubes(this Pix pix, int level, int mincount, float minfract, out int pncolors)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixNumberOccupiedOctcubes((HandleRef)pix, level, mincount, minfract, out pncolors);
        }
    }
}
