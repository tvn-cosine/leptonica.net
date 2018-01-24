using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixAcc
    {
        // Pixacc creation, destruction
        public static Pixacc pixaccCreate(int w, int h, int negflag)
        {
            var pointer = Native.DllImports.pixaccCreate(w, h, negflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixacc(pointer);

            }
        }

        public static Pixacc pixaccCreateFromPix(this Pix pix, int negflag)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixaccCreateFromPix((HandleRef)pix, negflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixacc(pointer);

            }
        }

        public static void pixaccDestroy(this Pixacc ppixacc)
        {
            if (null == ppixacc)
            {
                throw new ArgumentNullException("ppixacc cannot be null");
            }

            var pointer = (IntPtr)ppixacc;

            Native.DllImports.pixaccDestroy(ref pointer);
        }

        // Pixacc finalization
        public static Pix pixaccFinal(this Pixacc pixacc, int outdepth)
        {
            if (null == pixacc)
            {
                throw new ArgumentNullException("pixacc cannot be null");
            }

            var pointer = Native.DllImports.pixaccFinal((HandleRef)pixacc, outdepth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);

            }
        }

        // Pixacc accessors
        public static Pix pixaccGetPix(this Pixacc pixacc)
        {
            if (null == pixacc)
            {
                throw new ArgumentNullException("pixacc cannot be null");
            }

            var pointer = Native.DllImports.pixaccGetPix((HandleRef)pixacc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);

            }
        }

        public static int pixaccGetOffset(this Pixacc pixacc)
        {
            if (null == pixacc)
            {
                throw new ArgumentNullException("pixacc cannot be null");
            }

            return Native.DllImports.pixaccGetOffset((HandleRef)pixacc);
        }

        // Pixacc accumulators
        public static int pixaccAdd(this Pixacc pixacc, Pix pix)
        {
            if (null == pixacc
             || null == pix)
            {
                throw new ArgumentNullException("pixacc, pix cannot be null");
            }

            return Native.DllImports.pixaccAdd((HandleRef)pixacc, (HandleRef)pix);
        }

        public static int pixaccSubtract(this Pixacc pixacc, Pix pix)
        {
            if (null == pixacc
             || null == pix)
            {
                throw new ArgumentNullException("pixacc, pix cannot be null");
            }

            return Native.DllImports.pixaccSubtract((HandleRef)pixacc, (HandleRef)pix);
        }

        public static int pixaccMultConst(this Pixacc pixacc, float factor)
        {
            if (null == pixacc)
            {
                throw new ArgumentNullException("pixacc, pix cannot be null");
            }

            return Native.DllImports.pixaccMultConst((HandleRef)pixacc, factor);
        }

        public static int pixaccMultConstAccumulate(this Pixacc pixacc, Pix pix, float factor)
        {
            if (null == pixacc
             || null == pix)
            {
                throw new ArgumentNullException("pixacc, pix cannot be null");
            }

            return Native.DllImports.pixaccMultConstAccumulate((HandleRef)pixacc, (HandleRef)pix, factor);
        }
    }
}
