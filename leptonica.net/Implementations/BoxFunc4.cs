using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class BoxFunc4
    {
        // Boxa and Boxaa range selection
        public static Boxa boxaSelectRange(this Boxa boxas, int first, int last, int copyflag)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectRange((HandleRef)boxas, first, last, copyflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxaa boxaaSelectRange(this Boxaa baas, int first, int last, int copyflag)
        {
            if (null == baas)
            {
                throw new ArgumentNullException("baas cannot be null.");
            }

            var pointer = Native.DllImports.boxaaSelectRange((HandleRef)baas, first, last, copyflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        // Boxa size selection
        public static Boxa boxaSelectBySize(this Boxa boxas, int width, int height, int type, int relation, out int pchanged)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectBySize((HandleRef)boxas, width, height, type, relation, out pchanged);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Numa boxaMakeSizeIndicator(this Boxa boxa, int width, int height, int type, int relation)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var pointer = Native.DllImports.boxaMakeSizeIndicator((HandleRef)boxa, width, height, type, relation);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Boxa boxaSelectByArea(this Boxa boxas, int area, int relation, out int pchanged)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectByArea((HandleRef)boxas, area, relation, out pchanged);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Numa boxaMakeAreaIndicator(this Boxa boxa, int area, int relation)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var pointer = Native.DllImports.boxaMakeAreaIndicator((HandleRef)boxa, area, relation);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Boxa boxaSelectByWHRatio(this Boxa boxas, float ratio, int relation, out int pchanged)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectByWHRatio((HandleRef)boxas, ratio, relation, out pchanged);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Numa boxaMakeWHRatioIndicator(this Boxa boxa, float ratio, int relation)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var pointer = Native.DllImports.boxaMakeWHRatioIndicator((HandleRef)boxa, ratio, relation);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Boxa boxaSelectWithIndicator(this Boxa boxas, Numa na, out int pchanged)
        {
            if (null == boxas
             || null == na)
            {
                throw new ArgumentNullException("boxas, na cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectWithIndicator((HandleRef)boxas, (HandleRef)na, out pchanged);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // Boxa permutation
        public static Boxa boxaPermutePseudorandom(this Boxa boxas)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaPermutePseudorandom((HandleRef)boxas);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaPermuteRandom(this Boxa boxad, Boxa boxas)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaPermuteRandom((HandleRef)boxad, (HandleRef)boxas);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaSwapBoxes(this Boxa boxa, int i, int j)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            return Native.DllImports.boxaSwapBoxes((HandleRef)boxa, i, j);
        }

        // Boxa and box conversions
        public static Pta boxaConvertToPta(this Boxa boxa, int ncorners)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var pointer = Native.DllImports.boxaConvertToPta((HandleRef)boxa, ncorners);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Boxa ptaConvertToBoxa(this Pta pta, int ncorners)
        {
            if (null == pta)
            {
                throw new ArgumentNullException("pta cannot be null.");
            }

            var pointer = Native.DllImports.ptaConvertToBoxa((HandleRef)pta, ncorners);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Pta boxConvertToPta(this Box box, int ncorners)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null.");
            }

            var pointer = Native.DllImports.boxConvertToPta((HandleRef)box, ncorners);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Box ptaConvertToBox(this Pta pta)
        {
            if (null == pta)
            {
                throw new ArgumentNullException("pta cannot be null.");
            }

            var pointer = Native.DllImports.ptaConvertToBox((HandleRef)pta);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        // Boxa sequence fitting
        public static Boxa boxaSmoothSequenceLS(this Boxa boxas, float factor, int subflag, int maxdiff, int debug)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSmoothSequenceLS((HandleRef)boxas, factor, subflag, maxdiff, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaSmoothSequenceMedian(this Boxa boxas, int halfwin, int subflag, int maxdiff, int debug)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSmoothSequenceMedian((HandleRef)boxas, halfwin, subflag, maxdiff, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaLinearFit(this Boxa boxas, float factor, int debug)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaLinearFit((HandleRef)boxas, factor, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaWindowedMedian(this Boxa boxas, int halfwin, int debug)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaWindowedMedian((HandleRef)boxas, halfwin, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaModifyWithBoxa(this Boxa boxas, Boxa boxam, int subflag, int maxdiff)
        {
            if (null == boxas
             || null == boxam)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaModifyWithBoxa((HandleRef)boxas, (HandleRef)boxam, subflag, maxdiff);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaConstrainSize(this Boxa boxas, int width, int widthflag, int height, int heightflag)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaConstrainSize((HandleRef)boxas, width, widthflag, height, heightflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaReconcileEvenOddHeight(this Boxa boxas, int sides, int delh, int op, float factor, int start)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaReconcileEvenOddHeight((HandleRef)boxas, sides, delh, op, factor, start);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaReconcilePairWidth(this Boxa boxas, int delw, int op, float factor, Numa na)
        {
            if (null == boxas
             || null == na)
            {
                throw new ArgumentNullException("boxas, na cannot be null.");
            }

            var pointer = Native.DllImports.boxaReconcilePairWidth((HandleRef)boxas, delw, op, factor, (HandleRef)na);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaPlotSides(this Boxa boxa, string plotname, out Numa pnal, out Numa pnat, out Numa pnar, out Numa pnab, out Pix ppixd)
        {
            if (null == boxa
             || string.IsNullOrWhiteSpace(plotname))
            {
                throw new ArgumentNullException("boxas, plotname cannot be null.");
            }

            IntPtr pnalPtr, pnatPtr, pnarPtr, pnabPtr, ppixdPtr;
            var result = Native.DllImports.boxaPlotSides((HandleRef)boxa, plotname, out pnalPtr, out pnatPtr, out pnarPtr, out pnabPtr, out ppixdPtr);
            pnal = new Numa(pnalPtr);
            pnat = new Numa(pnatPtr);
            pnar = new Numa(pnarPtr);
            pnab = new Numa(pnabPtr);
            ppixd = new Pix(ppixdPtr);

            return result;
        }

        public static int boxaPlotSizes(this Boxa boxa, string plotname, out Numa pnaw, out Numa pnah, out Pix ppixd)
        {
            if (null == boxa
             || string.IsNullOrWhiteSpace(plotname))
            {
                throw new ArgumentNullException("boxas, plotname cannot be null.");
            }

            IntPtr pnawPtr, pnahPtr, ppixdPtr;
            var result = Native.DllImports.boxaPlotSizes((HandleRef)boxa, plotname, out pnawPtr, out pnahPtr, out ppixdPtr);
            pnaw = new Numa(pnawPtr);
            pnah = new Numa(pnahPtr);
            ppixd = new Pix(ppixdPtr);

            return result;
        }

        public static Boxa boxaFillSequence(this Boxa boxas, int useflag, int debug)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaFillSequence((HandleRef)boxas, useflag, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        //  Miscellaneous boxa functions
        public static int boxaGetExtent(this Boxa boxa, out int pw, out int ph, out Box pbox)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            IntPtr pboxPtr;
            var result = Native.DllImports.boxaGetExtent((HandleRef)boxa, out pw, out ph, out pboxPtr);
            pbox = new Box(pboxPtr);

            return result;
        }

        public static int boxaGetCoverage(this Boxa boxa, int wc, int hc, int exactflag, out float pfract)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            return Native.DllImports.boxaGetCoverage((HandleRef)boxa, wc, hc, exactflag, out pfract);
        }

        public static int boxaaSizeRange(this Boxaa baa, out int pminw, out int pminh, out int pmaxw, out int pmaxh)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null.");
            }

            return Native.DllImports.boxaaSizeRange((HandleRef)baa, out pminw, out pminh, out pmaxw, out pmaxh);
        }

        public static int boxaSizeRange(this Boxa boxa, out int pminw, out int pminh, out int pmaxw, out int pmaxh)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            return Native.DllImports.boxaSizeRange((HandleRef)boxa, out pminw, out pminh, out pmaxw, out pmaxh);
        }

        public static int boxaLocationRange(this Boxa boxa, out int pminx, out int pminy, out int pmaxx, out int pmaxy)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            return Native.DllImports.boxaLocationRange((HandleRef)boxa, out pminx, out pminy, out pmaxx, out pmaxy);
        }

        public static int boxaGetSizes(this Boxa boxa, out Numa pnaw, out Numa pnah)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            IntPtr pnawPtr, pnahPtr;
            var result = Native.DllImports.boxaGetSizes((HandleRef)boxa, out pnawPtr, out pnahPtr);
            pnaw = new Numa(pnawPtr);
            pnah = new Numa(pnahPtr);

            return result;
        }

        public static int boxaGetArea(this Boxa boxa, out int parea)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            return Native.DllImports.boxaGetArea((HandleRef)boxa, out parea);
        }

        public static Pix boxaDisplayTiled(this Boxa boxas, Pixa pixa, int maxwidth, int linewidth, float scalefactor, int background, int spacing, int border)
        {
            if (null == boxas
             || null == pixa)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaDisplayTiled((HandleRef)boxas, (HandleRef)pixa, maxwidth, linewidth, scalefactor, background, spacing, border);

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
