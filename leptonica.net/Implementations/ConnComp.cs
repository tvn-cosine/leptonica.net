using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ConnComp
    {
        // Top-level calls: 
        public static Boxa pixConnComp(this Pix pixs, out Pixa ppixa, int connectivity)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixaPtr;
            var pointer = Native.DllImports.pixConnComp((HandleRef)pixs, out ppixaPtr, connectivity);
            ppixa = new Pixa(ppixaPtr);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa pixConnCompPixa(this Pix pixs, out Pixa ppixa, int connectivity)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixaPtr;
            var pointer = Native.DllImports.pixConnCompPixa((HandleRef)pixs, out ppixaPtr, connectivity);
            ppixa = new Pixa(ppixaPtr);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa pixConnCompBB(this Pix pixs, int connectivity)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConnCompBB((HandleRef)pixs, connectivity);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int pixCountConnComp(this Pix pixs, int connectivity, out int pcount)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixCountConnComp((HandleRef)pixs, connectivity, out pcount);
        }

        // Identify the next c.c.to be erased: 
        public static int nextOnPixelInRaster(this Pix pixs, int xstart, int ystart, out int px, out int py)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.nextOnPixelInRaster((HandleRef)pixs, xstart, ystart, out px, out py);
        }

        public static int nextOnPixelInRasterLow(IntPtr data, int w, int h, int wpl, int xstart, int ystart, out int px, out int py)
        {
            if (IntPtr.Zero == data)
            {
                throw new ArgumentNullException("data cannot be null.");
            }

            return Native.DllImports.nextOnPixelInRasterLow(data, w, h, wpl, xstart, ystart, out px, out py);
        }

        // Erase the c.c., saving the b.b.: 
        public static Box pixSeedfillBB(this Pix pixs, L_Stack stack, int x, int y, int connectivity)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            var pointer = Native.DllImports.pixSeedfillBB((HandleRef)pixs, (HandleRef)stack, x, y, connectivity);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box pixSeedfill4BB(this Pix pixs, L_Stack stack, int x, int y)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            var pointer = Native.DllImports.pixSeedfill4BB((HandleRef)pixs, (HandleRef)stack, x, y);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box pixSeedfill8BB(this Pix pixs, L_Stack stack, int x, int y)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            var pointer = Native.DllImports.pixSeedfill8BB((HandleRef)pixs, (HandleRef)stack, x, y);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        // Just erase the c.c.: 
        public static int pixSeedfill(this Pix pixs, L_Stack stack, int x, int y, int connectivity)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            return Native.DllImports.pixSeedfill((HandleRef)pixs, (HandleRef)stack, x, y, connectivity); 
        }

        public static int pixSeedfill4(this Pix pixs, L_Stack stack, int x, int y)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            return Native.DllImports.pixSeedfill4((HandleRef)pixs, (HandleRef)stack, x, y);
        }

        public static int pixSeedfill8(this Pix pixs, L_Stack stack, int x, int y)
        {
            if (null == pixs
             || null == stack)
            {
                throw new ArgumentNullException("pixs, stack cannot be null.");
            }

            return Native.DllImports.pixSeedfill8((HandleRef)pixs, (HandleRef)stack, x, y);
        }
    }
}
