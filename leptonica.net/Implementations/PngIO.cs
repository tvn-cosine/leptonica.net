using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PngIO
    {
        // Reading png through stream
        public static Pix pixReadStreamPng(IntPtr fp)
        {
            throw new NotImplementedException();
        }


        // Reading png header
        public static int readHeaderPng(string filename, out int pw, out int ph, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }

        public static int freadHeaderPng(IntPtr fp, out int pw, out int ph, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderMemPng(IntPtr data, IntPtr size, out int pw, out int ph, out int pbps, out int pspp, out int piscmap)
        {
            throw new NotImplementedException();
        }


        // Reading png metadata
        public static int fgetPngResolution(IntPtr fp, out int pxres, out int pyres)
        {
            throw new NotImplementedException();
        }

        public static int isPngInterlaced(string filename, out int pinterlaced)
        {
            throw new NotImplementedException();
        }

        public static int fgetPngColormapInfo(IntPtr fp, out PixColormap pcmap, out int ptransparency)
        {
            throw new NotImplementedException();
        }


        // Writing png through stream
        public static int pixWritePng(string filename, Pix pix, float gamma)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamPng(IntPtr fp, Pix pix, float gamma)
        {
            throw new NotImplementedException();
        }

        public static int pixSetZlibCompression(this Pix pix, int compval)
        {
            throw new NotImplementedException();
        }


        // Set flag for special read mode
        public static void l_pngSetReadStrip16To8(int flag)
        {
            throw new NotImplementedException();
        }


        // Reading png from memory
        public static Pix pixReadMemPng(IntPtr filedata, IntPtr filesize)
        {
            throw new NotImplementedException();
        }


        // Writing png to memory
        public static int pixWriteMemPng(out IntPtr pfiledata, IntPtr pfilesize, Pix pix, float gamma)
        {
            throw new NotImplementedException();
        }

    }
}
