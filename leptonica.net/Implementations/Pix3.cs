using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pix3
    {
        // Masked operations
        public static int pixSetMasked(this Pix pixd, Pix pixm, uint val)
        {
            if (null == pixd)
            {
                throw new ArgumentNullException("pixd cannot be null");
            }

            return Native.DllImports.pixSetMasked((HandleRef)pixd, (HandleRef)pixm, val);
        }

        public static int pixSetMaskedGeneral(this Pix pixd, Pix pixm, uint val, int x, int y)
        {
            if (null == pixd)
            {
                throw new ArgumentNullException("pixd cannot be null");
            }

            return Native.DllImports.pixSetMaskedGeneral((HandleRef)pixd, (HandleRef)pixm, val, x, y);
        }

        public static int pixCombineMasked(this Pix pixd, Pix pixs, Pix pixm)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCombineMasked((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm);
        }

        public static int pixCombineMaskedGeneral(this Pix pixd, Pix pixs, Pix pixm, int x, int y)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCombineMaskedGeneral((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, x, y);
        }

        public static int pixPaintThroughMask(this Pix pixd, Pix pixm, int x, int y, uint val)
        {
            if (null == pixd)
            {
                throw new ArgumentNullException("pixd cannot be null");
            }

            return Native.DllImports.pixPaintThroughMask((HandleRef)pixd, (HandleRef)pixm, x, y, val);
        }

        public static int pixPaintSelfThroughMask(this Pix pixd, Pix pixm, int x, int y, int searchdir, int mindist, int tilesize, int ntiles, int distblend)
        {
            if (null == pixd)
            {
                throw new ArgumentNullException("pixd cannot be null");
            }

            return Native.DllImports.pixPaintSelfThroughMask((HandleRef)pixd, (HandleRef)pixm, x, y, searchdir, mindist, tilesize, ntiles, distblend);
        }

        public static Pix pixMakeMaskFromVal(this Pix pixs, int val)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixMakeMaskFromVal((HandleRef)pixs, val);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeMaskFromLUT(this Pix pixs, IntPtr tab)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixMakeMaskFromLUT((HandleRef)pixs, tab);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeArbMaskFromRGB(this Pix pixs, float rc, float gc, float bc, float thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixMakeArbMaskFromRGB((HandleRef)pixs, rc, gc, bc, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixSetUnderTransparency(this Pix pixs, uint val, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSetUnderTransparency((HandleRef)pixs, val, debug);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeAlphaFromMask(this Pix pixs, int dist, out Box pbox)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr pboxPtr;
            var pointer = Native.DllImports.pixMakeAlphaFromMask((HandleRef)pixs, dist, out pboxPtr);
            pbox = new Box(pboxPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixGetColorNearMaskBoundary(this Pix pixs, Pix pixm, Box box, int dist, out uint pval, int debug)
        {
            if (null == pixs
             || null == pixm
             || null == box)
            {
                throw new ArgumentNullException("pixs, pixm, box cannot be null");
            }

            return Native.DllImports.pixGetColorNearMaskBoundary((HandleRef)pixs, (HandleRef)pixm, (HandleRef)box, dist, out pval, debug);
        }

        // One and two-image boolean operations on arbitrary depth images
        public static Pix pixInvert(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixInvert((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOr(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null");
            }

            var pointer = Native.DllImports.pixOr((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixAnd(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null");
            }

            var pointer = Native.DllImports.pixAnd((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixXor(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null");
            }

            var pointer = Native.DllImports.pixXor((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixSubtract(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null");
            }

            var pointer = Native.DllImports.pixSubtract((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Foreground pixel counting in 1 bpp images
        public static int pixZero(this Pix pix, out int pempty)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixZero((HandleRef)pix, out pempty);
        }

        public static int pixForegroundFraction(this Pix pix, out float pfract)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixForegroundFraction((HandleRef)pix, out pfract);
        }

        public static Numa pixaCountPixels(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaCountPixels((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixCountPixels(this Pix pix, out int pcount, IntPtr tab8)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixCountPixels((HandleRef)pix, out pcount, tab8);
        }

        public static Numa pixCountByRow(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixCountByRow((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixCountByColumn(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixCountByColumn((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixCountPixelsByRow(this Pix pix, IntPtr tab8)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixCountPixelsByRow((HandleRef)pix, tab8);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixCountPixelsByColumn(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixCountPixelsByColumn((HandleRef)pix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixCountPixelsInRow(this Pix pix, int row, out int pcount, IntPtr tab8)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixCountPixelsInRow((HandleRef)pix, row, out pcount, tab8);
        }

        public static Numa pixGetMomentByColumn(this Pix pix, int order)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixGetMomentByColumn((HandleRef)pix, order);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixThresholdPixelSum(this Pix pix, int thresh, out int pabove, IntPtr tab8)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixThresholdPixelSum((HandleRef)pix, thresh, out pabove, tab8);
        }

        public static IntPtr makePixelSumTab8(IntPtr v)
        {
            return Native.DllImports.makePixelSumTab8(v);
        }

        public static IntPtr makePixelCentroidTab8(IntPtr v)
        {
            return Native.DllImports.makePixelCentroidTab8(v);
        }

        // Average of pixel values in gray images
        public static Numa pixAverageByRow(this Pix pix, Box box, FlagsFor8BitAnd16BitSums type)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixAverageByRow((HandleRef)pix, (HandleRef)box, (int)type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixAverageByColumn(this Pix pix, Box box, FlagsFor8BitAnd16BitSums type)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixAverageByColumn((HandleRef)pix, (HandleRef)box, (int)type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixAverageInRect(this Pix pix, Box box, out float pave)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixAverageInRect((HandleRef)pix, (HandleRef)box, out pave);
        }

        // Variance of pixel values in gray images
        public static Numa pixVarianceByRow(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixVarianceByRow((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixVarianceByColumn(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixVarianceByColumn((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixVarianceInRect(this Pix pix, Box box, out float prootvar)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixVarianceInRect((HandleRef)pix, (HandleRef)box, out prootvar);
        }

        // Average of absolute value of pixel differences in gray images
        public static Numa pixAbsDiffByRow(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixAbsDiffByRow((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa pixAbsDiffByColumn(this Pix pix, Box box)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixAbsDiffByColumn((HandleRef)pix, (HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixAbsDiffInRect(this Pix pix, Box box, int dir, out float pabsdiff)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixAbsDiffInRect((HandleRef)pix, (HandleRef)box, dir, out pabsdiff);
        }

        public static int pixAbsDiffOnLine(this Pix pix, int x1, int y1, int x2, int y2, out float pabsdiff)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixAbsDiffOnLine((HandleRef)pix, x1, y1, x2, y2, out pabsdiff);
        }

        // Count of pixels with specific value
        public static int pixCountArbInRect(this Pix pixs, Box box, int val, int factor, out int pcount)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixCountArbInRect((HandleRef)pixs, (HandleRef)box, val, factor, out pcount);
        }

        // Mirrored tiling
        public static Pix pixMirroredTiling(this Pix pixs, int w, int h)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixMirroredTiling((HandleRef)pixs, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Representative tile near but outside region
        public static int pixFindRepCloseTile(this Pix pixs, Box box, int searchdir, int mindist, int tsize, int ntiles, out Box pboxtile, int debug)
        {
            if (null == pixs
             || null == box)
            {
                throw new ArgumentNullException("pixs, box cannot be null");
            }

            IntPtr pboxtilePtr;
            var result = Native.DllImports.pixFindRepCloseTile((HandleRef)pixs, (HandleRef)box, searchdir, mindist, tsize, ntiles, out pboxtilePtr, debug);
            pboxtile = new Box(pboxtilePtr);

            return result;
        }
    }
}
