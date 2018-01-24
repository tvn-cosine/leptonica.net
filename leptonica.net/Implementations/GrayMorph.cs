using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class GrayMorph
    {
        // Top-level grayscale morphological operations(van Herk / Gil-Werman)
        public static Pix pixErodeGray(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixErodeGray((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDilateGray(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDilateGray((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenGray(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixOpenGray((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        } 

        public static Pix pixCloseGray(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCloseGray((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Special operations for 1x3, 3x1 and 3x3 Sels(direct)
        public static Pix pixErodeGray3(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixErodeGray3((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDilateGray3(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDilateGray3((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixOpenGray3(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixOpenGray3((HandleRef)pixs, hsize, vsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixCloseGray3(this Pix pixs, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCloseGray3((HandleRef)pixs, hsize, vsize);
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
