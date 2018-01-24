using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class SpixIo
    {
        // Reading spix from file
        public static Pix pixReadStreamSpix(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderSpix(string filename, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }

        public static int freadHeaderSpix(IntPtr fp, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }

        public static int sreadHeaderSpix(IntPtr data, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }


        // Writing spix to file
        public static int pixWriteStreamSpix(IntPtr fp, Pix pix)
        {
            throw new NotImplementedException();
        }


        // Low-level serialization of pix to/from memory(uncompressed)
        public static Pix pixReadMemSpix(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemSpix(out IntPtr pdata, IntPtr psize, Pix pix)
        {
            throw new NotImplementedException();
        }

        public static int pixSerializeToMemory(this Pix pixs, out IntPtr pdata, IntPtr pnbytes)
        {
            throw new NotImplementedException();
        }

        public static Pix pixDeserializeFromMemory(IntPtr data, IntPtr nbytes)
        {
            throw new NotImplementedException();
        } 
    }
}
