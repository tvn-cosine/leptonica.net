using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PnmIO
    {
        // Stream interface 
        public static Pix pixReadStreamPnm(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderPnm(string filename, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp)
        {
            throw new NotImplementedException();
        }

        public static int freadHeaderPnm(IntPtr fp, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamPnm(IntPtr fp, Pix pix)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamAsciiPnm(IntPtr fp, Pix pix)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamPam(IntPtr fp, Pix pix)
        {
            throw new NotImplementedException();
        }


        // Read/write to memory 
        public static Pix pixReadMemPnm(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderMemPnm(IntPtr data, IntPtr size, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemPnm(out IntPtr pdata, IntPtr psize, Pix pix)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemPam(out IntPtr pdata, IntPtr psize, Pix pix)
        {
            throw new NotImplementedException();
        }

    }
}
