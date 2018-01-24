using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class GifIO
    {
        // Read gif file
        public static Pix pixReadStreamGif(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixReadStreamGif(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Write gif file
        public static int pixWriteStreamGif(IntPtr fp, Pix pix)
        {
            if (IntPtr.Zero == fp
             || null == pix)
            {
                throw new ArgumentNullException("fp, pix cannot be null");
            }

            return Native.DllImports.pixWriteStreamGif(fp, (HandleRef)pix);
        }

        // Read/write gif from/to memory
        public static Pix pixReadMemGif(IntPtr cdata, IntPtr size)
        {
            if (IntPtr.Zero == cdata
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("cdata, size cannot be null");
            }

            var pointer = Native.DllImports.pixReadMemGif(cdata, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixWriteMemGif(out IntPtr pdata, IntPtr psize, Pix pix)
        {
            if (IntPtr.Zero == psize
             || null == pix)
            {
                throw new ArgumentNullException("psize, pix cannot be null");
            }

            return Native.DllImports.pixWriteMemGif(out pdata, psize, (HandleRef)pix);
        }
    }
}
