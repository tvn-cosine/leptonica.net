using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Morph
    {
        // Generic binary morphological ops implemented with rasterop
        public static Pix pixDilate(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixDilate((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErode(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixErode((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixHMT(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixHMT((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpen(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixOpen((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixClose(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixClose((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseSafe(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseSafe((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenGeneralized(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenGeneralized((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseGeneralized(this Pix pixd, Pix pixs, Sel sel)
        {
            if (null == pixs
             || null == sel)
            {
                throw new ArgumentNullException("pixs, sel cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseGeneralized((HandleRef)pixd, (HandleRef)pixs, (HandleRef)sel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Binary morphological(raster) ops with brick Sels
        public static Pix pixDilateBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDilateBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErodeBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixErodeBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseSafeBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseSafeBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Binary composed morphological(raster) ops with brick Sels
        public static int selectComposableSels(int size, int direction, out Sel psel1, out Sel psel2)
        {
            IntPtr psel1Ptr, psel2Ptr;
            var result = Native.DllImports.selectComposableSels(size, direction, out psel1Ptr, out psel2Ptr);
            psel1 = new Sel(psel1Ptr);
            psel2 = new Sel(psel2Ptr);
            return result;
        }

        public static int selectComposableSizes(int size, out int pfactor1, out int pfactor2)
        {
            return Native.DllImports.selectComposableSizes(size, out pfactor1, out pfactor2);
        }

        public static Pix pixDilateCompBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDilateCompBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErodeCompBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixErodeCompBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenCompBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenCompBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseCompBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseCompBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseSafeCompBrick(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseSafeCompBrick((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Functions associated with boundary conditions
        public static void resetMorphBoundaryCondition(int bc)
        {
            Native.DllImports.resetMorphBoundaryCondition(bc);
        }

        public static uint getMorphBorderPixelColor(int type, int depth)
        {
            return Native.DllImports.getMorphBorderPixelColor(type, depth);
        }
    }
}
