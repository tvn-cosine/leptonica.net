using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pix4
    {
        // Pixel histogram, rank val, averaging and min/max
        public static Numa pixGetGrayHistogram(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetGrayHistogram((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixGetGrayHistogramMasked(this Pix pixs, Pix pixm, int x, int y, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetGrayHistogramMasked((HandleRef)pixs, (HandleRef)pixm, x, y, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixGetGrayHistogramInRect(this Pix pixs, Box box, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetGrayHistogramInRect((HandleRef)pixs, (HandleRef)box, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numaa pixGetGrayHistogramTiled(this Pix pixs, int factor, int nx, int ny)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetGrayHistogramTiled((HandleRef)pixs, factor, nx, ny);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static int pixGetColorHistogram(this Pix pixs, int factor, out Numa pnar, out Numa pnag, out Numa pnab)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pnarPtr, pnagPtr, pnabPtr;
            var result = Native.DllImports.pixGetColorHistogram((HandleRef)pixs, factor, out pnarPtr, out pnagPtr, out pnabPtr);
            pnar = new Numa(pnarPtr);
            pnag = new Numa(pnagPtr);
            pnab = new Numa(pnabPtr);

            return result;
        }

        public static int pixGetColorHistogramMasked(this Pix pixs, Pix pixm, int x, int y, int factor, out Numa pnar, out Numa pnag, out Numa pnab)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pnarPtr, pnagPtr, pnabPtr;
            var result = Native.DllImports.pixGetColorHistogramMasked((HandleRef)pixs, (HandleRef)pixm, x, y, factor, out pnarPtr, out pnagPtr, out pnabPtr);
            pnar = new Numa(pnarPtr);
            pnag = new Numa(pnagPtr);
            pnab = new Numa(pnabPtr);

            return result;
        }

        public static Numa pixGetCmapHistogram(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetCmapHistogram((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixGetCmapHistogramMasked(this Pix pixs, Pix pixm, int x, int y, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetCmapHistogramMasked((HandleRef)pixs, (HandleRef)pixm, x, y, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixGetCmapHistogramInRect(this Pix pixs, Box box, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetCmapHistogramInRect((HandleRef)pixs, (HandleRef)box, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixCountRGBColors(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixCountRGBColors((HandleRef)pixs);
        }

        public static L_AMap pixGetColorAmapHistogram(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetColorAmapHistogram((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap(pointer);
            }
        }

        public static int amapGetCountForColor(this L_AMap amap, uint val)
        {
            if (null == amap)
            {
                throw new ArgumentNullException("amap cannot be null");
            }

            return Native.DllImports.amapGetCountForColor((HandleRef)amap, val);
        }

        public static int pixGetRankValue(this Pix pixs, int factor, float rank, out uint pvalue)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetRankValue((HandleRef)pixs, factor, rank, out pvalue);
        }

        public static int pixGetRankValueMaskedRGB(this Pix pixs, Pix pixm, int x, int y, int factor, float rank, out float prval, out float pgval, out float pbval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetRankValueMaskedRGB((HandleRef)pixs, (HandleRef)pixm, x, y, factor, rank, out prval, out pgval, out pbval);
        }

        public static int pixGetRankValueMasked(this Pix pixs, Pix pixm, int x, int y, int factor, float rank, out float pval, out Numa pna)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pnaPtr;
            var result = Native.DllImports.pixGetRankValueMasked((HandleRef)pixs, (HandleRef)pixm, x, y, factor, rank, out pval, out pnaPtr);
            pna = new Numa(pnaPtr);

            return result;
        }

        public static int pixGetAverageValue(this Pix pixs, int factor, int type, out uint pvalue)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetAverageValue((HandleRef)pixs, factor, type, out pvalue);
        }

        public static int pixGetAverageMaskedRGB(this Pix pixs, Pix pixm, int x, int y, int factor, int type, out float prval, out float pgval, out float pbval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetAverageMaskedRGB((HandleRef)pixs, (HandleRef)pixm, x, y, factor, type, out prval, out pgval, out pbval);
        }

        public static int pixGetAverageMasked(this Pix pixs, Pix pixm, int x, int y, int factor, int type, out float pval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetAverageMasked((HandleRef)pixs, (HandleRef)pixm, x, y, factor, type, out pval);
        }

        public static int pixGetAverageTiledRGB(this Pix pixs, int sx, int sy, int type, out Pix ppixr, out Pix ppixg, out Pix ppixb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr ppixrPtr, ppixgPtr, ppixbPtr;
            var result = Native.DllImports.pixGetAverageTiledRGB((HandleRef)pixs, sx, sy, type, out ppixrPtr, out ppixgPtr, out ppixbPtr);
            ppixr = new Pix(ppixrPtr);
            ppixg = new Pix(ppixgPtr);
            ppixb = new Pix(ppixbPtr);

            return result;
        }

        public static Pix pixGetAverageTiled(this Pix pixs, int sx, int sy, int type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetAverageTiled((HandleRef)pixs, sx, sy, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixRowStats(this Pix pixs, Box box, out Numa pnamean, out Numa pnamedian, out Numa pnamode, out Numa pnamodecount, out Numa pnavar, out Numa pnarootvar)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pnameanPtr, pnamedianPtr, pnamodePtr, pnamodecountPtr, pnavarPtr, pnarootvarPtr;
            var result = Native.DllImports.pixRowStats((HandleRef)pixs, (HandleRef)box, out pnameanPtr, out pnamedianPtr, out pnamodePtr, out pnamodecountPtr, out pnavarPtr, out pnarootvarPtr);
            pnamean = new Numa(pnameanPtr);
            pnamedian = new Numa(pnamedianPtr);
            pnamode = new Numa(pnamodePtr);
            pnamodecount = new Numa(pnamodecountPtr);
            pnavar = new Numa(pnavarPtr);
            pnarootvar = new Numa(pnarootvarPtr);

            return result;
        }

        public static int pixColumnStats(this Pix pixs, Box box, out Numa pnamean, out Numa pnamedian, out Numa pnamode, out Numa pnamodecount, out Numa pnavar, out Numa pnarootvar)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pnameanPtr, pnamedianPtr, pnamodePtr, pnamodecountPtr, pnavarPtr, pnarootvarPtr;
            var result = Native.DllImports.pixColumnStats((HandleRef)pixs, (HandleRef)box, out pnameanPtr, out pnamedianPtr, out pnamodePtr, out pnamodecountPtr, out pnavarPtr, out pnarootvarPtr);
            pnamean = new Numa(pnameanPtr);
            pnamedian = new Numa(pnamedianPtr);
            pnamode = new Numa(pnamodePtr);
            pnamodecount = new Numa(pnamodecountPtr);
            pnavar = new Numa(pnavarPtr);
            pnarootvar = new Numa(pnarootvarPtr);

            return result;
        }

        public static int pixGetRangeValues(this Pix pixs, int factor, int color, out int pminval, out int pmaxval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var result = Native.DllImports.pixGetRangeValues((HandleRef)pixs, factor, color, out pminval, out pmaxval);

            return result;
        }

        public static int pixGetExtremeValue(this Pix pixs, int factor, int type, out int prval, out int pgval, out int pbval, out int pgrayval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var result = Native.DllImports.pixGetExtremeValue((HandleRef)pixs, factor, type, out prval, out pgval, out pbval, out pgrayval);

            return result;
        }

        public static int pixGetMaxValueInRect(this Pix pixs, Box box, out uint pmaxval, out int pxmax, out int pymax)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var result = Native.DllImports.pixGetMaxValueInRect((HandleRef)pixs, (HandleRef)box, out pmaxval, out pxmax, out pymax);

            return result;
        }

        public static int pixGetBinnedComponentRange(this Pix pixs, int nbins, int factor, int color, out int pminval, out int pmaxval, out IntPtr pcarray, int fontsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var result = Native.DllImports.pixGetBinnedComponentRange((HandleRef)pixs, nbins, factor, color, out pminval, out pmaxval, out pcarray, fontsize);

            return result;
        }

        public static int pixGetRankColorArray(this Pix pixs, int nbins, int type, int factor, out IntPtr pcarray, int debugflag, int fontsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var result = Native.DllImports.pixGetRankColorArray((HandleRef)pixs, nbins, type, factor, out pcarray, debugflag, fontsize);

            return result;
        }

        public static int pixGetBinnedColor(this Pix pixs, Pix pixg, int factor, int nbins, Numa nalut, out IntPtr pcarray, int debugflag)
        {
            if (null == pixs
             || null == pixg
             || null == nalut)
            {
                throw new ArgumentNullException("pixs, nalut, pixg cannot be null");
            }

            var result = Native.DllImports.pixGetBinnedColor((HandleRef)pixs, (HandleRef)pixg, factor, nbins, (HandleRef)nalut, out pcarray, debugflag);

            return result;
        }

        public static Pix pixDisplayColorArray(IntPtr carray, int ncolors, int side, int ncols, int fontsize)
        {
            if (IntPtr.Zero == carray)
            {
                throw new ArgumentNullException("carray cannot be null");
            }

            var pointer = Native.DllImports.pixDisplayColorArray(carray, ncolors, side, ncols, fontsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixRankBinByStrip(this Pix pixs, int direction, int size, int nbins, int type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixRankBinByStrip((HandleRef)pixs, direction, size, nbins, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Pixelwise aligned statistics
        public static Pix pixaGetAlignedStats(this Pixa pixa, int type, int nbins, int thresh)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaGetAlignedStats((HandleRef)pixa, type, nbins, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixaExtractColumnFromEachPix(this Pixa pixa, int col, Pix pixd)
        {
            if (null == pixa
             || null == pixd)
            {
                throw new ArgumentNullException("pixa, pixd cannot be null");
            }

            return Native.DllImports.pixaExtractColumnFromEachPix((HandleRef)pixa, col, (HandleRef)pixd);
        }

        public static int pixGetRowStats(this Pix pixs, int type, int nbins, int thresh, IntPtr colvect)
        {
            if (null == pixs
             || IntPtr.Zero == colvect)
            {
                throw new ArgumentNullException("pixs, colvect cannot be null");
            }

            return Native.DllImports.pixGetRowStats((HandleRef)pixs, type, nbins, thresh, colvect);
        }

        public static int pixGetColumnStats(this Pix pixs, int type, int nbins, int thresh, IntPtr rowvect)
        {
            if (null == pixs
             || IntPtr.Zero == rowvect)
            {
                throw new ArgumentNullException("pixs, rowvect cannot be null");
            }

            return Native.DllImports.pixGetColumnStats((HandleRef)pixs, type, nbins, thresh, rowvect);
        }

        public static int pixSetPixelColumn(this Pix pix, int col, IntPtr colvect)
        {
            if (null == pix
             || IntPtr.Zero == colvect)
            {
                throw new ArgumentNullException("pix, colvect cannot be null");
            }

            return Native.DllImports.pixSetPixelColumn((HandleRef)pix, col, colvect);
        }

        // Foreground/background estimation
        public static int pixThresholdForFgBg(this Pix pixs, int factor, int thresh, out int pfgval, out int pbgval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixThresholdForFgBg((HandleRef)pixs, factor, thresh, out pfgval, out pbgval);
        }

        public static int pixSplitDistributionFgBg(this Pix pixs, float scorefract, int factor, out int pthresh, out int pfgval, out int pbgval, out Pix ppixdb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr ppixdbPtr;
            var result = Native.DllImports.pixSplitDistributionFgBg((HandleRef)pixs, scorefract, factor, out pthresh, out pfgval, out pbgval, out ppixdbPtr);
            ppixdb = new Pix(ppixdbPtr);

            return result;
        }
    }
}
