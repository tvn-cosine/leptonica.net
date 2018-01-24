using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class MorphDwa
    {
        // Binary morphological(dwa) ops with brick Sels 
        public static Pix pixDilateBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDilateBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErodeBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixErodeBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Binary composite morphological(dwa) ops with brick Sels 
        public static Pix pixDilateCompBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDilateCompBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErodeCompBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixErodeCompBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenCompBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenCompBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseCompBrickDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseCompBrickDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Binary extended composite morphological(dwa) ops with brick Sels 
        public static Pix pixDilateCompBrickExtendDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDilateCompBrickExtendDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixErodeCompBrickExtendDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixErodeCompBrickExtendDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenCompBrickExtendDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOpenCompBrickExtendDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseCompBrickExtendDwa(this Pix pixd, Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCloseCompBrickExtendDwa((HandleRef)pixd, (HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int getExtendedCompositeParameters(int size, out int pn, out int pextra, out int pactualsize)
        {
            return Native.DllImports.getExtendedCompositeParameters(size, out pn, out pextra, out pactualsize);
        }
    }
}
