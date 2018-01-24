using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class NumaFunc1
    {
        // Arithmetic and logic 
        public static Numa numaArithOp(this Numa nad, Numa na1, Numa na2, int op)
        {
            if (null == na1
             || null == na2)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaArithOp((HandleRef)nad, (HandleRef)na1, (HandleRef)na2, op);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaLogicalOp(this Numa nad, Numa na1, Numa na2, int op)
        {
            if (null == na1
             || null == na2)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaLogicalOp((HandleRef)nad, (HandleRef)na1, (HandleRef)na2, op);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaInvert(this Numa nad, Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            var pointer = Native.DllImports.numaInvert((HandleRef)nad, (HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaSimilar(this Numa na1, Numa na2, float maxdiff, out int psimilar)
        {
            if (null == na1
             || null == na2)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaSimilar((HandleRef)na1, (HandleRef)na2, maxdiff, out psimilar);
        }

        public static int numaAddToNumber(this Numa na, int index, float val)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaAddToNumber((HandleRef)na, index, val);
        }


        // Simple extractions
        public static int numaGetMin(this Numa na, out float pminval, out int piminloc)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetMin((HandleRef)na, out pminval, out piminloc);
        }

        public static int numaGetMax(this Numa na, out float pmaxval, out int pimaxloc)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetMax((HandleRef)na, out pmaxval, out pimaxloc);
        }

        public static int numaGetSum(this Numa na, out float psum)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetSum((HandleRef)na, out psum);
        }

        public static Numa numaGetPartialSums(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }
            var pointer = Native.DllImports.numaGetPartialSums((HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaGetSumOnInterval(this Numa na, int first, int last, out float psum)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetSumOnInterval((HandleRef)na, first, last, out psum);
        }

        public static int numaHasOnlyIntegers(this Numa na, int maxsamples, out int pallints)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaHasOnlyIntegers((HandleRef)na, maxsamples, out pallints);
        }

        public static Numa numaSubsample(this Numa nas, int subfactor)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaSubsample((HandleRef)nas, subfactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeDelta(this Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaMakeDelta((HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeSequence(float startval, float increment, int size)
        {
            var pointer = Native.DllImports.numaMakeSequence(startval, increment, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeConstant(float val, int size)
        {
            var pointer = Native.DllImports.numaMakeConstant(val, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeAbsValue(this Numa nad, Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaMakeAbsValue((HandleRef)nad, (HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaAddBorder(this Numa nas, int left, int right, float val)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaAddBorder((HandleRef)nas, left, right, val);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaAddSpecifiedBorder(this Numa nas, int left, int right, int type)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaAddSpecifiedBorder((HandleRef)nas, left, right, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaRemoveBorder(this Numa nas, int left, int right)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaRemoveBorder((HandleRef)nas, left, right);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }
         
        public static int numaCountNonzeroRuns(this Numa na, out int pcount)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaCountNonzeroRuns((HandleRef)na, out pcount);
        }

        public static int numaGetNonzeroRange(this Numa na, float eps, out int pfirst, out int plast)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetNonzeroRange((HandleRef)na, eps, out pfirst, out plast);
        }

        public static int numaGetCountRelativeToZero(this Numa na, int type, out int pcount)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetCountRelativeToZero((HandleRef)na, type, out pcount);
        }

        public static Numa numaClipToInterval(this Numa nas, int first, int last)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaClipToInterval((HandleRef)nas, first, last);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaMakeThresholdIndicator(this Numa nas, float thresh, int type)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaMakeThresholdIndicator((HandleRef)nas, thresh, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaUniformSampling(this Numa nas, int nsamp)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaUniformSampling((HandleRef)nas, nsamp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaReverse(this Numa nad, Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaReverse((HandleRef)nad, (HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }


        // Signal feature extraction
        public static Numa numaLowPassIntervals(this Numa nas, float thresh, float maxn)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaLowPassIntervals((HandleRef)nas, thresh, maxn);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaThresholdEdges(this Numa nas, float thresh1, float thresh2, float maxn)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaThresholdEdges((HandleRef)nas, thresh1, thresh2, maxn);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaGetSpanValues(this Numa na, int span, out int pstart, out int pend)
        {
            if (null == na)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            return Native.DllImports.numaGetSpanValues((HandleRef)na, span, out pstart, out pend);
        }

        public static int numaGetEdgeValues(this Numa na, int edge, out int pstart, out int pend, out int psign)
        {
            if (null == na)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            return Native.DllImports.numaGetEdgeValues((HandleRef)na, edge, out pstart, out pend, out psign);
        }


        // Interpolation
        public static int numaInterpolateEqxVal(float startx, float deltax, Numa nay, int type, float xval, out float pyval)
        {
            if (null == nay)
            {
                throw new ArgumentNullException("nay cannot be null.");
            }
            return Native.DllImports.numaInterpolateEqxVal(startx, deltax, (HandleRef)nay, type, xval, out pyval);
        }

        public static int numaInterpolateArbxVal(this Numa nax, Numa nay, int type, float xval, out float pyval)
        {
            if (null == nax
             || null == nay)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }
            return Native.DllImports.numaInterpolateArbxVal((HandleRef)nax, (HandleRef)nay, type, xval, out pyval);
        }

        public static int numaInterpolateEqxInterval(float startx, float deltax, Numa nasy, int type, float x0, float x1, int npts, out Numa pnax, out Numa pnay)
        {
            if (null == nasy)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }

            IntPtr pnaxPtr, pnayPtr;
            var result = Native.DllImports.numaInterpolateEqxInterval(startx, deltax, (HandleRef)nasy, type, x0, x1, npts, out pnaxPtr, out pnayPtr);
            pnax = new Numa(pnaxPtr);
            pnay = new Numa(pnayPtr);

            return result;
        }
         
        public static int numaInterpolateArbxInterval(this Numa nax, Numa nay, int type, float x0, float x1, int npts, out Numa pnadx, out Numa pnady)
        {
            if (null == nax
             || null == nay)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }

            IntPtr pnadxPtr, pnadyPtr;
            var result = Native.DllImports.numaInterpolateArbxInterval((HandleRef)nax, (HandleRef)nay, type, x0, x1, npts, out pnadxPtr, out pnadyPtr);
            pnadx = new Numa(pnadxPtr);
            pnady = new Numa(pnadyPtr);

            return result;
        }


        // Functions requiring interpolation
        public static int numaFitMax(this Numa na, out float pmaxval, Numa naloc, out float pmaxloc)
        {
            if (null == na
             || null == naloc)
            {
                throw new ArgumentNullException("nax, naloc cannot be null.");
            }
            return Native.DllImports.numaFitMax((HandleRef)na, out pmaxval, (HandleRef)naloc, out pmaxloc);
        }

        public static int numaDifferentiateInterval(this Numa nax, Numa nay, float x0, float x1, int npts, out Numa pnadx, out Numa pnady)
        {
            if (null == nax
             || null == nay)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }

            IntPtr pnadxPtr, pnadyPtr;
            var result = Native.DllImports.numaDifferentiateInterval((HandleRef)nax, (HandleRef)nay, x0, x1, npts, out pnadxPtr, out pnadyPtr);
            pnadx = new Numa(pnadxPtr);
            pnady = new Numa(pnadyPtr);

            return result;
        }

        public static int numaIntegrateInterval(this Numa nax, Numa nay, float x0, float x1, int npts, out float psum)
        {
            if (null == nax
             || null == nay)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }

            var result = Native.DllImports.numaIntegrateInterval((HandleRef)nax, (HandleRef)nay, x0, x1, npts, out psum);

            return result;
        }


        // Sorting
        public static int numaSortGeneral(this Numa na, out Numa pnasort, out Numa pnaindex, out Numa pnainvert, int sortorder, int sorttype)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            IntPtr pnasortPtr, pnaindexPtr, pnainvertPtr;
            var result = Native.DllImports.numaSortGeneral((HandleRef)na, out pnasortPtr, out pnaindexPtr, out pnainvertPtr, sortorder, sorttype);
            pnasort = new Numa(pnasortPtr);
            pnaindex = new Numa(pnaindexPtr);
            pnainvert = new Numa(pnainvertPtr);

            return result;
        }

        public static Numa numaSortAutoSelect(this Numa nas, int sortorder)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaSortAutoSelect((HandleRef)nas, sortorder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaSortIndexAutoSelect(this Numa nas, int sortorder)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaSortIndexAutoSelect((HandleRef)nas, sortorder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaChooseSortType(this Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaChooseSortType((HandleRef)nas);
        }

        public static Numa numaSort(this Numa naout, Numa nain, int sortorder)
        {
            if (null == nain)
            {
                throw new ArgumentNullException("nain cannot be null.");
            }
            var pointer = Native.DllImports.numaSort((HandleRef)naout, (HandleRef)nain, sortorder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaGetSortIndex(this Numa na, int sortorder)
        {
            if (null == na)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaGetSortIndex((HandleRef)na, sortorder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaGetBinSortIndex(this Numa nas, int sortorder)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }
            var pointer = Native.DllImports.numaGetBinSortIndex((HandleRef)nas, sortorder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaSortByIndex(this Numa nas, Numa naindex)
        {
            if (null == nas
             || null == naindex)
            {
                throw new ArgumentNullException("nas, naindex cannot be null.");
            }

            var pointer = Native.DllImports.numaSortByIndex((HandleRef)nas, (HandleRef)naindex);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaIsSorted(this Numa nas, int sortorder, out int psorted)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas cannot be null.");
            }

            return Native.DllImports.numaIsSorted((HandleRef)nas, sortorder, out psorted);
        }

        public static int numaSortPair(this Numa nax, Numa nay, int sortorder, out Numa pnasx, out Numa pnasy)
        {
            if (null == nax
             || null == nay)
            {
                throw new ArgumentNullException("nax, nay cannot be null.");
            }

            IntPtr pnasxPtr, pnasyPtr;
            var result = Native.DllImports.numaSortPair((HandleRef)nax, (HandleRef)nay, sortorder, out pnasxPtr, out pnasyPtr);
            pnasx = new Numa(pnasxPtr);
            pnasy = new Numa(pnasyPtr);

            return result;
        }

        public static Numa numaInvertMap(this Numa nas)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas, naindex cannot be null.");
            }

            var pointer = Native.DllImports.numaInvertMap((HandleRef)nas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }


        // Random permutation
        public static Numa numaPseudorandomSequence(int size, int seed)
        {
            var pointer = Native.DllImports.numaPseudorandomSequence(size, seed);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaRandomPermutation(this Numa nas, int seed)
        {
            if (null == nas)
            {
                throw new ArgumentNullException("nas, naindex cannot be null.");
            }

            var pointer = Native.DllImports.numaRandomPermutation((HandleRef)nas, seed);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }


        // Functions requiring sorting
        public static int numaGetRankValue(this Numa na, float fract, Numa nasort, int usebins, out float pval)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetRankValue((HandleRef)na, fract, (HandleRef)nasort, usebins, out pval);
        }

        public static int numaGetMedian(this Numa na, out float pval)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetMedian((HandleRef)na, out pval);
        }

        public static int numaGetBinnedMedian(this Numa na, out int pval)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetBinnedMedian((HandleRef)na, out pval);
        }

        public static int numaGetMode(this Numa na, out float pval, out int pcount)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetMode((HandleRef)na, out pval, out pcount);
        }

        public static int numaGetMedianVariation(this Numa na, out float pmedval, out float pmedvar)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetMedianVariation((HandleRef)na, out pmedval, out pmedvar);
        }


        // Rearrangements
        public static int numaJoin(this Numa nad, Numa nas, int istart, int iend)
        {
            if (null == nad)
            {
                throw new ArgumentNullException("nad cannot be null.");
            }

            return Native.DllImports.numaJoin((HandleRef)nad, (HandleRef)nas, istart, iend);
        }

        public static int numaaJoin(this Numaa naad, Numaa naas, int istart, int iend)
        {
            if (null == naad)
            {
                throw new ArgumentNullException("naad cannot be null.");
            }

            return Native.DllImports.numaaJoin((HandleRef)naad, (HandleRef)naas, istart, iend);
        }

        public static Numa numaaFlattenToNuma(this Numaa naa)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null.");
            }

            var pointer = Native.DllImports.numaaFlattenToNuma((HandleRef)naa);
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
