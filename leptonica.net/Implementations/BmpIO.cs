using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class BmpIO
    {
        // Read bmp
        public static Pix pixReadStreamBmp(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.pixReadStreamBmp(fp);
            if (null == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixReadMemBmp(IntPtr cdata, IntPtr size)
        {
            if (IntPtr.Zero == cdata
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("cdata, size cannot be null.");
            }

            var pointer = Native.DllImports.pixReadMemBmp(cdata, size);
            if (null == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Write bmp
        public static int pixWriteStreamBmp(IntPtr fp, Pix pix)
        {
            if (IntPtr.Zero == fp
             || null == pix)
            {
                throw new ArgumentNullException("fp, pix cannot be null.");
            }

            return Native.DllImports.pixWriteStreamBmp(fp, (HandleRef)pix);
        }

        public static int pixWriteMemBmp(out IntPtr pfdata, out IntPtr pfsize, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixWriteMemBmp(out pfdata, out pfsize, (HandleRef)pixs);
        }
    }
}
