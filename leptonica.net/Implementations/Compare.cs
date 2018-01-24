using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Compare
    {
        // Test for pix equality
        public static int pixEqual(this Pix pix1, Pix pix2, out int psame)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixEqual((HandleRef)pix1, (HandleRef)pix2, out psame);
        }

        public static int pixEqualWithAlpha(this Pix pix1, Pix pix2, int use_alpha, out int psame)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixEqualWithAlpha((HandleRef)pix1, (HandleRef)pix2, use_alpha, out psame);
        }

        public static int pixEqualWithCmap(this Pix pix1, Pix pix2, out int psame)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixEqualWithCmap((HandleRef)pix1, (HandleRef)pix2, out psame);
        }

        public static int cmapEqual(this PixColormap cmap1, PixColormap cmap2, int ncomps, out int psame)
        {
            if (null == cmap1
             || null == cmap2)
            {
                throw new ArgumentNullException("cmap1, pix2 cannot be null.");
            }

            return Native.DllImports.cmapEqual((HandleRef)cmap1, (HandleRef)cmap2, ncomps, out psame);
        }

        public static int pixUsesCmapColor(this Pix pixs, out int pcolor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixUsesCmapColor((HandleRef)pixs, out pcolor);
        }


        // Binary correlation
        public static int pixCorrelationBinary(this Pix pix1, Pix pix2, out float pval)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCorrelationBinary((HandleRef)pix1, (HandleRef)pix2, out pval);
        }

        // Difference of two images of same size
        public static Pix pixDisplayDiffBinary(this Pix pix1, Pix pix2)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            var pointer = Native.DllImports.pixDisplayDiffBinary((HandleRef)pix1, (HandleRef)pix2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixCompareBinary(this Pix pix1, Pix pix2, int comptype, out float pfract, out Pix ppixdiff)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr ppixdiffPtr;
            var result = Native.DllImports.pixCompareBinary((HandleRef)pix1, (HandleRef)pix2, comptype, out pfract, out ppixdiffPtr);
            ppixdiff = new Pix(ppixdiffPtr);

            return result;
        }

        public static int pixCompareGrayOrRGB(this Pix pix1, Pix pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out Pix ppixdiff)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr ppixdiffPtr;
            var result = Native.DllImports.pixCompareGrayOrRGB((HandleRef)pix1, (HandleRef)pix2, comptype, plottype, out psame, out pdiff, out prmsdiff, out ppixdiffPtr);
            ppixdiff = new Pix(ppixdiffPtr);

            return result;
        }

        public static int pixCompareGray(this Pix pix1, Pix pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out Pix ppixdiff)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr ppixdiffPtr;
            var result = Native.DllImports.pixCompareGray((HandleRef)pix1, (HandleRef)pix2, comptype, plottype, out psame, out pdiff, out prmsdiff, out ppixdiffPtr);
            ppixdiff = new Pix(ppixdiffPtr);

            return result;
        }

        public static int pixCompareRGB(this Pix pix1, Pix pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out Pix ppixdiff)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr ppixdiffPtr;
            var result = Native.DllImports.pixCompareRGB((HandleRef)pix1, (HandleRef)pix2, comptype, plottype, out psame, out pdiff, out prmsdiff, out ppixdiffPtr);
            ppixdiff = new Pix(ppixdiffPtr);

            return result;
        }

        public static int pixCompareTiled(this Pix pix1, Pix pix2, int sx, int sy, int type, out Pix ppixdiff)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr ppixdiffPtr;
            var result = Native.DllImports.pixCompareTiled((HandleRef)pix1, (HandleRef)pix2, sx, sy, type, out ppixdiffPtr);
            ppixdiff = new Pix(ppixdiffPtr);

            return result;
        }

        // Other measures of the difference of two images of the same size
        public static Numa pixCompareRankDifference(this Pix pix1, Pix pix2, int factor)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            var pointer = Native.DllImports.pixCompareRankDifference((HandleRef)pix1, (HandleRef)pix2, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixTestForSimilarity(this Pix pix1, Pix pix2, int factor, int mindiff, float maxfract, float maxave, out int psimilar, int printstats)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixTestForSimilarity((HandleRef)pix1, (HandleRef)pix2, factor, mindiff, maxfract, maxave, out psimilar, printstats);
        }

        public static int pixGetDifferenceStats(this Pix pix1, Pix pix2, int factor, int mindiff, out float pfractdiff, out float pavediff, int printstats)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixGetDifferenceStats((HandleRef)pix1, (HandleRef)pix2, factor, mindiff, out pfractdiff, out pavediff, printstats);
        }

        public static Numa pixGetDifferenceHistogram(this Pix pix1, Pix pix2, int factor)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            var pointer = Native.DllImports.pixGetDifferenceHistogram((HandleRef)pix1, (HandleRef)pix2, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixGetPerceptualDiff(this Pix pixs1, Pix pixs2, int sampling, int dilation, int mindiff, out float pfract, out Pix ppixdiff1, out Pix ppixdiff2)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            IntPtr ppixdiff1Ptr, ppixdiff2Ptr;
            var result = Native.DllImports.pixGetPerceptualDiff((HandleRef)pixs1, (HandleRef)pixs2, sampling, dilation, mindiff, out pfract, out ppixdiff1Ptr, out ppixdiff2Ptr);
            ppixdiff1 = new Pix(ppixdiff1Ptr);
            ppixdiff2 = new Pix(ppixdiff2Ptr);

            return result;
        }

        public static int pixGetPSNR(this Pix pix1, Pix pix2, int factor, out float ppsnr)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixGetPSNR((HandleRef)pix1, (HandleRef)pix2, factor, out ppsnr);
        }

        // Comparison of photo regions by histogram
        public static int pixaComparePhotoRegionsByHisto(this Pixa pixa, float minratio, float textthresh, int factor, int nx, int ny, float simthresh, out Numa pnai, out IntPtr pscores, out Pix ppixd)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null.");
            }

            IntPtr pnaiPtr, ppixdPtr;
            var result = Native.DllImports.pixaComparePhotoRegionsByHisto((HandleRef)pixa, minratio, textthresh, factor, nx, ny, simthresh, out pnaiPtr, out pscores, out ppixdPtr);
            pnai = new Numa(pnaiPtr);
            ppixd = new Pix(ppixdPtr);

            return result;
        }

        public static int pixComparePhotoRegionsByHisto(this Pix pix1, Pix pix2, Box box1, Box box2, float minratio, int factor, int nx, int ny, out float pscore, int debugflag)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixComparePhotoRegionsByHisto((HandleRef)pix1, (HandleRef)pix2, (HandleRef)box1, (HandleRef)box2, minratio, factor, nx, ny, out pscore, debugflag);
        }

        public static int pixGenPhotoHistos(this Pix pixs, Box box, int factor, float thresh, int nx, int ny, out Numaa pnaa, out int pw, out int ph, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pnaaPtr;
            var result = Native.DllImports.pixGenPhotoHistos((HandleRef)pixs, (HandleRef)box, factor, thresh, nx, ny, out pnaaPtr, out pw, out ph, debugflag);
            pnaa = new Numaa(pnaaPtr);

            return result;
        }

        public static Pix pixPadToCenterCentroid(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixPadToCenterCentroid((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixCentroid8(this Pix pixs, int factor, out float pcx, out float pcy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixCentroid8((HandleRef)pixs, factor, out pcx, out pcy);
        }

        public static int pixDecideIfPhotoImage(this Pix pix, int factor, int nx, int ny, float thresh, out Numaa pnaa, Pixa pixadebug)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            IntPtr pnaaPtr;
            var result = Native.DllImports.pixDecideIfPhotoImage((HandleRef)pix, factor, nx, ny, thresh, out pnaaPtr, (HandleRef)pixadebug);
            pnaa = new Numaa(pnaaPtr);

            return result;
        }

        public static int compareTilesByHisto(this Numa naa1, Numa naa2, float minratio, int w1, int h1, int w2, int h2, out float pscore, Pixa pixadebug)
        {
            if (null == naa1
             || null == naa2)
            {
                throw new ArgumentNullException("naa1, naa2 cannot be null.");
            }

            return Native.DllImports.compareTilesByHisto((HandleRef)naa1, (HandleRef)naa2, minratio, w1, h1, w2, h2, out pscore, (HandleRef)pixadebug);
        }

        public static int pixCompareGrayByHisto(this Pix pix1, Pix pix2, Box box1, Box box2, float minratio, int maxgray, int factor, int nx, int ny, out float pscore, int debugflag)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCompareGrayByHisto((HandleRef)pix1, (HandleRef)pix2, (HandleRef)box1, (HandleRef)box2, minratio, maxgray, factor, nx, ny, out pscore, debugflag);
        }

        public static int pixCropAlignedToCentroid(this Pix pix1, Pix pix2, int factor, out Box pbox1, out Box pbox2)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            IntPtr pbox1Ptr, pbox2Ptr;
            var result = Native.DllImports.pixCropAlignedToCentroid((HandleRef)pix1, (HandleRef)pix2, factor, out pbox1Ptr, out pbox2Ptr);
            pbox1 = new Box(pbox1Ptr);
            pbox2 = new Box(pbox2Ptr);

            return result;
        }

        public static IntPtr l_compressGrayHistograms(this Numa naa, int w, int h, IntPtr psize)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null.");
            }

            return Native.DllImports.l_compressGrayHistograms((HandleRef)naa, w, h, psize);
        }

        public static Numaa l_uncompressGrayHistograms(IntPtr bytea, IntPtr size, out int pw, out int ph)
        {
            if (IntPtr.Zero == bytea
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("bytea, size cannot be null.");
            }

            var pointer = Native.DllImports.l_uncompressGrayHistograms(bytea, size, out pw, out ph);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        // Translated images at the same resolution
        public static int pixCompareWithTranslation(this Pix pix1, Pix pix2, int thresh, out int pdelx, out int pdely, out float pscore, int debugflag)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCompareWithTranslation((HandleRef)pix1, (HandleRef)pix2, thresh, out pdelx, out pdely, out pscore, debugflag);
        }

        public static int pixBestCorrelation(this Pix pix1, Pix pix2, int area1, int area2, int etransx, int etransy, int maxshift, out int tab8, out int pdelx, out int pdely, out float pscore, int debugflag)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixBestCorrelation((HandleRef)pix1, (HandleRef)pix2, area1, area2, etransx, etransy, maxshift, out tab8, out pdelx, out pdely, out pscore, debugflag);
        }
    }
}
