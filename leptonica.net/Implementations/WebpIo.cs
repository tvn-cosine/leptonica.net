using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class WebpIo
    {
        // Reading WebP
        public static Pix pixReadStreamWebP(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static Pix pixReadMemWebP(IntPtr filedata, IntPtr filesize)
        {
            throw new NotImplementedException();
        }


        // Reading WebP header
        public static int readHeaderWebP(string filename, out int pw, out int ph, out int pspp)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderMemWebP(IntPtr data, IntPtr size, out int pw, out int ph, out int pspp)
        {
            throw new NotImplementedException();
        }


        // Writing WebP
        public static int pixWriteWebP(string filename, Pix pixs, int quality, int lossless)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamWebP(IntPtr fp, Pix pixs, int quality, int lossless)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemWebP(out IntPtr pencdata, IntPtr pencsize, Pix pixs, int quality, int lossless)
        {
            throw new NotImplementedException();
        }
    }
}
