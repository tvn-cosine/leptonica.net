using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Jpk2IO
    {
        // Read jp2k from file
        public static Pix pixReadJp2k(string filename, uint reduction, Box box, int hint, int debug)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixReadJp2k(filename, reduction, (HandleRef)box, hint, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixReadStreamJp2k(IntPtr fp, uint reduction, Box box, int hint, int debug)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixReadStreamJp2k(fp, reduction, (HandleRef)box, hint, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Write jp2k to file
        public static int pixWriteJp2k(string filename, Pix pix, int quality, int nlevels, int hint, int debug)
        {
            if (string.IsNullOrWhiteSpace(filename)
             || null == pix)
            {
                throw new ArgumentNullException("filename, pix cannot be null");
            }

            return Native.DllImports.pixWriteJp2k(filename, (HandleRef)pix, quality, nlevels, hint, debug);
        }

        public static int pixWriteStreamJp2k(IntPtr fp, Pix pix, int quality, int nlevels, int hint, int debug)
        {
            if (IntPtr.Zero == fp
             || null == pix)
            {
                throw new ArgumentNullException("fp, pix cannot be null");
            }

            return Native.DllImports.pixWriteStreamJp2k(fp, (HandleRef)pix, quality, nlevels, hint, debug);
        }

        // Read/write to memory
        public static Pix pixReadMemJp2k(IntPtr data, IntPtr size, uint reduction, Box box, int hint, int debug)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.pixReadMemJp2k(data, size, reduction, (HandleRef)box, hint, debug);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixWriteMemJp2k(out IntPtr pdata, IntPtr psize, Pix pix, int quality, int nlevels, int hint, int debug)
        {
            if (IntPtr.Zero == psize
             || null == pix)
            {
                throw new ArgumentNullException("psize, pix cannot be null");
            }

            return Native.DllImports.pixWriteMemJp2k(out pdata, psize, (HandleRef)pix, quality, nlevels, hint, debug);
        }
    }
}
