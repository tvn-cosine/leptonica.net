using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class BoxFunc1
    {
        public static int boxContains(this Box box1, Box box2, out int presult)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxContains((HandleRef)box1, (HandleRef)box2, out presult);
        }

        public static int boxIntersects(this Box box1, Box box2, out int presult)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxIntersects((HandleRef)box1, (HandleRef)box2, out presult);
        }

        public static Boxa boxaContainedInBox(this Boxa boxas, Box box)
        {
            if (null == boxas
             || null == box)
            {
                throw new ArgumentNullException("boxas, box cannot be null");
            }

            var pointer = Native.DllImports.boxaContainedInBox((HandleRef)boxas, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaContainedInBoxCount(this Boxa boxa, Box box, out int pcount)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaContainedInBoxCount((HandleRef)boxa, (HandleRef)box, out pcount);
        }

        public static int boxaContainedInBoxa(this Boxa boxa1, Boxa boxa2, out int pcontained)
        {
            if (null == boxa1
             || null == boxa2)
            {
                throw new ArgumentNullException("boxa1, boxa2 cannot be null");
            }

            return Native.DllImports.boxaContainedInBoxa((HandleRef)boxa1, (HandleRef)boxa2, out pcontained);
        }

        public static Boxa boxaIntersectsBox(this Boxa boxas, Box box)
        {
            if (null == boxas
             || null == box)
            {
                throw new ArgumentNullException("boxas, box cannot be null");
            }

            var pointer = Native.DllImports.boxaIntersectsBox((HandleRef)boxas, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaIntersectsBoxCount(this Boxa boxa, Box box, out int pcount)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaIntersectsBoxCount((HandleRef)boxa, (HandleRef)box, out pcount);
        }

        public static Boxa boxaClipToBox(this Boxa boxas, Box box)
        {
            if (null == boxas
             || null == box)
            {
                throw new ArgumentNullException("boxas, box cannot be null");
            }

            var pointer = Native.DllImports.boxaClipToBox((HandleRef)boxas, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaCombineOverlaps(this Boxa boxas, Pixa pixadb)
        {
            if (null == boxas
             || null == pixadb)
            {
                throw new ArgumentNullException("boxas, pixadb cannot be null");
            }

            var pointer = Native.DllImports.boxaCombineOverlaps((HandleRef)boxas, (HandleRef)pixadb);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaCombineOverlapsInPair(this Boxa boxas1, Boxa boxas2, out Boxa pboxad1, out Boxa pboxad2, Pixa pixadb)
        {
            if (null == boxas1
             || null == boxas2
             || null == pixadb)
            {
                throw new ArgumentNullException("boxas1, boxas2, pixadb cannot be null");
            }

            IntPtr pboxad1Ptr, pboxad2Ptr;
            var result = Native.DllImports.boxaCombineOverlapsInPair((HandleRef)boxas1, (HandleRef)boxas2, out pboxad1Ptr, out pboxad2Ptr, (HandleRef)pixadb);

            if (IntPtr.Zero == pboxad1Ptr)
            {
                pboxad1 = null;
            }
            else
            {
                pboxad1 = new Boxa(pboxad1Ptr);
            }
            if (IntPtr.Zero == pboxad2Ptr)
            {
                pboxad2 = null;
            }
            else
            {
                pboxad2 = new Boxa(pboxad2Ptr);
            }

            return result;
        }

        public static Box boxOverlapRegion(this Box box1, Box box2)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            var pointer = Native.DllImports.boxOverlapRegion((HandleRef)box1, (HandleRef)box2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxBoundingRegion(this Box box1, Box box2)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            var pointer = Native.DllImports.boxBoundingRegion((HandleRef)box1, (HandleRef)box2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static int boxOverlapFraction(this Box box1, Box box2, out float pfract)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxOverlapFraction((HandleRef)box1, (HandleRef)box2, out pfract);
        }

        public static int boxOverlapArea(this Box box1, Box box2, out int parea)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxOverlapArea((HandleRef)box1, (HandleRef)box2, out parea);
        }

        public static Boxa boxaHandleOverlaps(this Boxa boxas, int op, int range, float min_overlap, float max_ratio, out Numa pnamap)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            IntPtr pnamapPtr;
            var pointer = Native.DllImports.boxaHandleOverlaps((HandleRef)boxas, op, range, min_overlap, max_ratio, out pnamapPtr);
            if (IntPtr.Zero == pointer)
            {
                pnamap = null;
                return null;
            }
            else
            {
                pnamap = new Numa(pnamapPtr);
                return new Boxa(pointer);
            }
        }

        public static int boxSeparationDistance(this Box box1, Box box2, out int ph_sep, out int pv_sep)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxSeparationDistance((HandleRef)box1, (HandleRef)box2, out ph_sep, out pv_sep);
        }

        public static int boxCompareSize(this Box box1, Box box2, int type, out int prel)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxCompareSize((HandleRef)box1, (HandleRef)box2, type, out prel);
        }

        public static int boxContainsPt(this Box box, float x, float y, out int pcontains)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxContainsPt((HandleRef)box, x, y, out pcontains);
        }

        public static Box boxaGetNearestToPt(this Boxa boxa, int x, int y)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaGetNearestToPt((HandleRef)boxa, x, y);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxaGetNearestToLine(this Boxa boxa, int x, int y)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaGetNearestToLine((HandleRef)boxa, x, y);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static int boxGetCenter(this Box box, out float pcx, out float pcy)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxGetCenter((HandleRef)box, out pcx, out pcy);
        }

        public static int boxIntersectByLine(this Box box, int x, int y, float slope, out int px1, out int py1, out int px2, out int py2, out int pn)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxIntersectByLine((HandleRef)box, x, y, slope, out px1, out py1, out px2, out py2, out pn);
        }

        public static Box boxClipToRectangle(this Box box, int wi, int hi)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            var pointer = Native.DllImports.boxClipToRectangle((HandleRef)box, wi, hi);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static int boxClipToRectangleParams(this Box box, int w, int h, out int pxstart, out int pystart, out int pxend, out int pyend, out int pbw, out int pbh)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxClipToRectangleParams((HandleRef)box, w, h, out pxstart, out pystart, out pxend, out pyend, out pbw, out pbh);
        }

        public static Box boxRelocateOneSide(this Box boxd, Box boxs, int loc, int sideflag)
        {
            if (null == boxs)
            {
                throw new ArgumentNullException("boxs cannot be null");
            }

            var pointer = Native.DllImports.boxRelocateOneSide((HandleRef)boxd, (HandleRef)boxs, loc, sideflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Boxa boxaAdjustSides(this Boxa boxas, int delleft, int delright, int deltop, int delbot)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            var pointer = Native.DllImports.boxaAdjustSides((HandleRef)boxas, delleft, delright, deltop, delbot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Box boxAdjustSides(this Box boxd, Box boxs, int delleft, int delright, int deltop, int delbot)
        {
            if (null == boxs)
            {
                throw new ArgumentNullException("boxs cannot be null");
            }

            var pointer = Native.DllImports.boxAdjustSides((HandleRef)boxd, (HandleRef)boxs, delleft, delright, deltop, delbot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Boxa boxaSetSide(this Boxa boxad, Boxa boxas, int side, int val, int thresh)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            var pointer = Native.DllImports.boxaSetSide((HandleRef)boxad, (HandleRef)boxas, side, val, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaAdjustWidthToTarget(this Boxa boxad, Boxa boxas, int sides, int target, int thresh)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            var pointer = Native.DllImports.boxaAdjustWidthToTarget((HandleRef)boxad, (HandleRef)boxas, sides, target, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaAdjustHeightToTarget(this Boxa boxad, Boxa boxas, int sides, int target, int thresh)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            var pointer = Native.DllImports.boxaAdjustHeightToTarget((HandleRef)boxad, (HandleRef)boxas, sides, target, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxEqual(this Box box1, Box box2, out int psame)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxEqual((HandleRef)box1, (HandleRef)box2, out psame);
        }

        public static int boxaEqual(this Boxa boxa1, Boxa boxa2, int maxdist, out Numa pnaindex, out int psame)
        {
            if (null == boxa1
             || null == boxa2)
            {
                throw new ArgumentNullException("boxa1, boxa2 cannot be null");
            }

            IntPtr pnaindexPtr;
            var result = Native.DllImports.boxaEqual((HandleRef)boxa1, (HandleRef)boxa2, maxdist, out pnaindexPtr, out psame);
            if (IntPtr.Zero == pnaindexPtr)
            {
                pnaindex = null;
            }
            else
            {
                pnaindex = new Numa(pnaindexPtr);
            }
            return result;
        }

        public static int boxSimilar(this Box box1, Box box2, int leftdiff, int rightdiff, int topdiff, int botdiff, out int psimilar)
        {
            if (null == box1
             || null == box2)
            {
                throw new ArgumentNullException("box1, box2 cannot be null");
            }

            return Native.DllImports.boxSimilar((HandleRef)box1, (HandleRef)box2, leftdiff, rightdiff, topdiff, botdiff, out psimilar);
        }

        public static int boxaSimilar(this Boxa boxa1, Boxa boxa2, int leftdiff, int rightdiff, int topdiff, int botdiff, int debug, out int psimilar, out Numa pnasim)
        {
            if (null == boxa1
             || null == boxa2)
            {
                throw new ArgumentNullException("boxa1, boxa2 cannot be null");
            }

            IntPtr pnasimPtr;
            var result = Native.DllImports.boxaSimilar((HandleRef)boxa1, (HandleRef)boxa2, leftdiff, rightdiff, topdiff, botdiff, debug, out psimilar, out pnasimPtr);
            if (IntPtr.Zero == pnasimPtr)
            {
                pnasim = null;
            }
            else
            {
                pnasim = new Numa(pnasimPtr);
            }
            return result;
        }


        // Boxa combine and split
        public static int boxaJoin(this Boxa boxad, Boxa boxas, int istart, int iend)
        {
            if (null == boxas
             || null == boxad)
            {
                throw new ArgumentNullException("boxas, boxad cannot be null");
            }

            return Native.DllImports.boxaJoin((HandleRef)boxad, (HandleRef)boxas, istart, iend);
        }

        public static int boxaaJoin(this Boxaa baad, Boxaa baas, int istart, int iend)
        {
            if (null == baad
             || null == baas)
            {
                throw new ArgumentNullException("baad, baas cannot be null");
            }

            return Native.DllImports.boxaJoin((HandleRef)baad, (HandleRef)baas, istart, iend);
        }

        public static int boxaSplitEvenOdd(this Boxa boxa, int fillflag, out Boxa pboxae, out Boxa pboxao)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            IntPtr pboxaePtr, pboxaoPtr;
            var result = Native.DllImports.boxaSplitEvenOdd((HandleRef)boxa, fillflag, out pboxaePtr, out pboxaoPtr);
            if (null == pboxaePtr)
            {
                pboxae = null;
            }
            else
            {
                pboxae = new Boxa(pboxaePtr);
            }
            if (null == pboxaoPtr)
            {
                pboxao = null;
            }
            else
            {
                pboxao = new Boxa(pboxaoPtr);
            }

            return result;
        }

        public static Boxa boxaMergeEvenOdd(this Boxa boxae, Boxa boxao, int fillflag)
        {
            if (null == boxae
             || null == boxao)
            {
                throw new ArgumentNullException("boxae, boxao cannot be null");
            }

            var pointer = Native.DllImports.boxaMergeEvenOdd((HandleRef)boxae, (HandleRef)boxao, fillflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }
    }
}
