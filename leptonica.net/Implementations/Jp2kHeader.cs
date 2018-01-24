using System;

namespace Leptonica
{
    public static class Jp2kHeader
    {
        // Read header
        public static int readHeaderJp2k(string filename, out int pw, out int ph, out int pbps, out int pspp)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            return Native.DllImports.readHeaderJp2k(filename, out pw, out ph, out pbps, out pspp);
        }

        public static int freadHeaderJp2k(IntPtr fp, out int pw, out int ph, out int pbps, out int pspp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            return Native.DllImports.freadHeaderJp2k(fp, out pw, out ph, out pbps, out pspp);
        }

        public static int readHeaderMemJp2k(IntPtr data, IntPtr size, out int pw, out int ph, out int pbps, out int pspp)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            return Native.DllImports.readHeaderMemJp2k(data, size, out pw, out ph, out pbps, out pspp);
        }

        public static int fgetJp2kResolution(IntPtr fp, out int pxres, out int pyres)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            return Native.DllImports.fgetJp2kResolution(fp, out pxres, out pyres);
        }
    }
}
