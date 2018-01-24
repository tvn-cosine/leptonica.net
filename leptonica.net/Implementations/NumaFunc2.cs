using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class NumaFunc2
    {
        // Morphological(min/max) operations 
        public static Numa numaErode(this Numa nas, int size)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaErode((HandleRef)nas, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaDilate(this Numa nas, int size)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaDilate((HandleRef)nas, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaOpen(this Numa nas, int size)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaOpen((HandleRef)nas, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaClose(this Numa nas, int size)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaClose((HandleRef)nas, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Other transforms

        public static Numa numaTransform(this Numa nas, float shift, float scale)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaTransform((HandleRef)nas, shift, scale);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaSimpleStats(this Numa na, int first, int last, out float pmean, out float pvar, out float prvar)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaSimpleStats((HandleRef)na, first, last, out pmean, out pvar, out prvar);
        }

        public static int numaWindowedStats(this Numa nas, int wc, out Numa pnam, out Numa pnams, out Numa pnav, out Numa pnarv)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            IntPtr pnamPtr, pnamsPtr, pnavPtr, pnarvPtr;
            var result = Native.DllImports.numaWindowedStats((HandleRef)nas, wc, out pnamPtr, out pnamsPtr, out pnavPtr, out pnarvPtr);
            pnam = new Numa(pnamPtr);
            pnams = new Numa(pnamsPtr);
            pnav = new Numa(pnavPtr);
            pnarv = new Numa(pnarvPtr);

            return result;
        }

        public static Numa numaWindowedMean(this Numa nas, int wc)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaWindowedMean((HandleRef)nas, wc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaWindowedMeanSquare(this Numa nas, int wc)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaWindowedMeanSquare((HandleRef)nas, wc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaWindowedVariance(this Numa nam, Numa nams, out Numa pnav, out Numa pnarv)
        {
            if (null == nam
             || null == nams)
            {
                throw new ArgumentNullException("nam, nams cannot be null.");
            }

            IntPtr pnavPtr, pnarvPtr;
            var result = Native.DllImports.numaWindowedVariance((HandleRef)nam, (HandleRef)nams, out pnavPtr, out pnarvPtr);
            pnav = new Numa(pnavPtr);
            pnarv = new Numa(pnarvPtr);

            return result;
        }

        public static Numa numaWindowedMedian(this Numa nas, int halfwin)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaWindowedMedian((HandleRef)nas, halfwin);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaConvertToInt(this Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaConvertToInt((HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }


        // Histogram generation and statistics

        public static Numa numaMakeHistogram(this Numa na, int maxbins, out int pbinsize, out int pbinstart)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaMakeHistogram((HandleRef)na, maxbins, out pbinsize, out pbinstart);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeHistogramAuto(this Numa na, int maxbins)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaMakeHistogramAuto((HandleRef)na, maxbins);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeHistogramClipped(this Numa na, float binsize, float maxsize)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaMakeHistogramClipped((HandleRef)na, binsize, maxsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaRebinHistogram(this Numa nas, int newsize)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaRebinHistogram((HandleRef)nas, newsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaNormalizeHistogram(this Numa nas, float tsum)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaNormalizeHistogram((HandleRef)nas, tsum);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaGetStatsUsingHistogram(this Numa na, int maxbins, out float pmin, out float pmax, out float pmean, out float pvariance, out float pmedian, float rank, out float prval, out Numa phisto)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            IntPtr phistoPtr;
            var result = Native.DllImports.numaGetStatsUsingHistogram((HandleRef)na, maxbins, out pmin, out pmax, out pmean, out pvariance, out pmedian, rank, out prval, out phistoPtr);
            phisto = new Numa(phistoPtr);

            return result;
        }

        public static int numaGetHistogramStats(this Numa nahisto, float startx, float deltax, out float pxmean, out float pxmedian, out float pxmode, out float pxvariance)
        {
            if (null == nahisto)
            {
                throw new ArgumentNullException("nahisto cannot be null.");
            }

            return Native.DllImports.numaGetHistogramStats((HandleRef)nahisto, startx, deltax, out pxmean, out pxmedian, out pxmode, out pxvariance);
        }

        public static int numaGetHistogramStatsOnInterval(this Numa nahisto, float startx, float deltax, int ifirst, int ilast, out float pxmean, out float pxmedian, out float pxmode, out float pxvariance)
        {
            if (null == nahisto)
            {
                throw new ArgumentNullException("nahisto cannot be null.");
            }

            return Native.DllImports.numaGetHistogramStatsOnInterval((HandleRef)nahisto, startx, deltax, ifirst, ilast, out pxmean, out pxmedian, out pxmode, out pxvariance);
        }

        public static int numaMakeRankFromHistogram(float startx, float deltax, Numa nasy, int npts, out Numa pnax, out Numa pnay)
        {
            if (null == nasy)
            {
                throw new ArgumentNullException("nasy cannot be null.");
            }

            IntPtr pnaxPtr, pnayPtr;
            var result = Native.DllImports.numaMakeRankFromHistogram(startx, deltax, (HandleRef)nasy, npts, out pnaxPtr, out pnayPtr);
            pnax = new Numa(pnaxPtr);
            pnay = new Numa(pnayPtr);

            return result;
        }

        public static int numaHistogramGetRankFromVal(this Numa na, float rval, out float prank)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaHistogramGetRankFromVal((HandleRef)na, rval, out prank);
        }

        public static int numaHistogramGetValFromRank(this Numa na, float rank, out float prval)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaHistogramGetValFromRank((HandleRef)na, rank, out prval);
        }

        public static int numaDiscretizeRankAndIntensity(this Numa na, int nbins, out Numa pnarbin, out Numa pnam, out Numa pnar, out Numa pnabb)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            IntPtr pnarbinPtr, pnamPtr, pnarPtr, pnabbPtr;
            var result = Native.DllImports.numaDiscretizeRankAndIntensity((HandleRef)na, nbins, out pnarbinPtr, out pnamPtr, out pnarPtr, out pnabbPtr);
            pnarbin = new Numa(pnarbinPtr);
            pnam = new Numa(pnamPtr);
            pnar = new Numa(pnarPtr);
            pnabb = new Numa(pnabbPtr);

            return result;
        }

        public static int numaGetRankBinValues(this Numa na, int nbins, out Numa pnarbin, out Numa pnam)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            IntPtr pnarbinPtr, pnamPtr;
            var result = Native.DllImports.numaGetRankBinValues((HandleRef)na, nbins, out pnarbinPtr, out pnamPtr);
            pnarbin = new Numa(pnarbinPtr);
            pnam = new Numa(pnamPtr);

            return result;
        }

        // Splitting a distribution 
        public static int numaSplitDistribution(this Numa na, float scorefract, out int psplitindex, out float pave1, out float pave2, out float pnum1, out float pnum2, out Numa pnascore)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            IntPtr pnascorePtr;
            var result = Native.DllImports.numaSplitDistribution((HandleRef)na, scorefract, out psplitindex, out pave1, out pave2, out pnum1, out pnum2, out pnascorePtr);
            pnascore = new Numa(pnascorePtr);

            return result;
        }

        // Comparing histograms

        public static int grayHistogramsToEMD(this Numaa naa1, Numaa naa2, out Numa pnad)
        {
            if (null == naa1
             || null == naa2)
            {
                throw new ArgumentNullException("naa1, naa2 cannot be null.");
            }

            IntPtr pnadPtr;
            var result = Native.DllImports.grayHistogramsToEMD((HandleRef)naa1, (HandleRef)naa2, out pnadPtr);
            pnad = new Numa(pnadPtr);

            return result;
        }

        public static int numaEarthMoverDistance(this Numa na1, Numa na2, out float pdist)
        {
            if (null == na1
             || null == na2)
            {
                throw new ArgumentNullException("naa1, naa2 cannot be null.");
            }

            return Native.DllImports.numaEarthMoverDistance((HandleRef)na1, (HandleRef)na2, out pdist);
        }

        public static int grayInterHistogramStats(this Numaa naa, int wc, out Numa pnam, out Numa pnams, out Numa pnav, out Numa pnarv)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null.");
            }

            IntPtr pnamPtr, pnamsPtr, pnavPtr, pnarvPtr;
            var result = Native.DllImports.grayInterHistogramStats((HandleRef)naa, wc, out pnamPtr, out pnamsPtr, out pnavPtr, out pnarvPtr);
            pnam = new Numa(pnamPtr);
            pnams = new Numa(pnamsPtr);
            pnav = new Numa(pnavPtr);
            pnarv = new Numa(pnarvPtr);

            return result;
        }

        // Extrema finding

        public static Numa numaFindPeaks(this Numa nas, int nmax, float fract1, float fract2)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaFindPeaks((HandleRef)nas, nmax, fract1, fract2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaFindExtrema(this Numa nas, float delta, out Numa pnav)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            IntPtr pnavPtr;
            var pointer = Native.DllImports.numaFindExtrema((HandleRef)nas, delta, out pnavPtr);
            pnav = new Numa(pnavPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaCountReversals(this Numa nas, float minreversal, out int pnr, out float pnrpl)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaCountReversals((HandleRef)nas, minreversal, out pnr, out pnrpl);
        }

        // Threshold crossings and frequency analysis

        public static int numaSelectCrossingThreshold(this Numa nax, Numa nay, float estthresh, out float pbestthresh)
        {
            if (null == nay)
            {
                throw new ArgumentNullException("nay cannot be null.");
            }

            return Native.DllImports.numaSelectCrossingThreshold((HandleRef)nax, (HandleRef)nay, estthresh, out pbestthresh);
        }

        public static Numa numaCrossingsByThreshold(this Numa nax, Numa nay, float thresh)
        {
            if (null == nay)
            {
                throw new ArgumentNullException("nay cannot be null.");
            }

            var pointer = Native.DllImports.numaCrossingsByThreshold((HandleRef)nax, (HandleRef)nay, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaCrossingsByPeaks(this Numa nax, Numa nay, float delta)
        {
            if (null == nay)
            {
                throw new ArgumentNullException("nay cannot be null.");
            }

            var pointer = Native.DllImports.numaCrossingsByPeaks((HandleRef)nax, (HandleRef)nay, delta);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaEvalBestHaarParameters(this Numa nas, float relweight, int nwidth, int nshift, float minwidth, float maxwidth, out float pbestwidth, out float pbestshift, out float pbestscore)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaEvalBestHaarParameters((HandleRef)nas, relweight, nwidth, nshift, minwidth, maxwidth, out pbestwidth, out pbestshift, out pbestscore);
        }

        public static int numaEvalHaarSum(this Numa nas, float width, float shift, float relweight, out float pscore)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaEvalHaarSum((HandleRef)nas, width, shift, relweight, out pscore);
        }

        // Generating numbers in a range under constraints 
        public static Numa genConstrainedNumaInRange(int first, int last, int nmax, int use_pairs)
        {
            var pointer = Native.DllImports.genConstrainedNumaInRange(first, last, nmax, use_pairs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }
    }
}
