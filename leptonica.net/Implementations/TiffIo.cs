using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class TiffIo
    {
        // Reading tiff:
        public static Pix pixReadTiff(string filename, int n)
        {
            throw new NotImplementedException();
        }

        public static Pix pixReadStreamTiff(IntPtr fp, int n)
        {
            throw new NotImplementedException();
        }


        // Writing tiff:
        public static int pixWriteTiff(string filename, Pix pix, int comptype, string modestr)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteTiffCustom(string filename, Pix pix, int comptype, string modestr, Numa natags, Sarray savals, Sarray satypes, Numa nasizes)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamTiff(IntPtr fp, Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamTiffWA(IntPtr fp, Pix pix, int comptype, string modestr)
        {
            throw new NotImplementedException();
        }


        // Reading and writing multipage tiff
        public static Pix pixReadFromMultipageTiff(string fname, out IntPtr poffset)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaReadMultipageTiff(string filename)
        {
            throw new NotImplementedException();
        }

        public static int pixaWriteMultipageTiff(string fname, Pixa pixa)
        {
            throw new NotImplementedException();
        }

        public static int writeMultipageTiff(string dirin, string substr, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int writeMultipageTiffSA(this Sarray sa, string fileout)
        {
            throw new NotImplementedException();
        }


        // Information about tiff file
        public static int fprintTiffInfo(IntPtr fpout, string tiffile)
        {
            throw new NotImplementedException();
        }

        public static int tiffGetCount(IntPtr fp, out int pn)
        {
            throw new NotImplementedException();
        }

        public static int getTiffResolution(IntPtr fp, out int pxres, out int pyres)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderTiff(string filename, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat)
        {
            throw new NotImplementedException();
        }

        public static int freadHeaderTiff(IntPtr fp, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat)
        {
            throw new NotImplementedException();
        }

        public static int readHeaderMemTiff(IntPtr cdata, IntPtr size, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat)
        {
            throw new NotImplementedException();
        }

        public static int findTiffCompression(IntPtr fp, out int pcomptype)
        {
            throw new NotImplementedException();
        }


        // Extraction of tiff g4 data:
        public static int extractG4DataFromFile(string filein, out IntPtr pdata, IntPtr pnbytes, out int pw, out int ph, out int pminisblack)
        {
            throw new NotImplementedException();
        }


        // Memory I/O: reading memory --> pix and writing pix --> memory [10 static helper functions]
        public static Pix pixReadMemTiff(IntPtr cdata, IntPtr size, int n)
        {
            throw new NotImplementedException();
        }

        public static Pix pixReadMemFromMultipageTiff(IntPtr cdata, IntPtr size, IntPtr poffset)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaReadMemMultipageTiff(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int pixaWriteMemMultipageTiff(out IntPtr pdata, IntPtr psize, HandleRef pixa)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemTiff(out IntPtr pdata, IntPtr psize, Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMemTiffCustom(out IntPtr pdata, IntPtr psize, Pix pix, int comptype, Numa natags, Sarray savals, Sarray satypes, Numa nasizes)
        {
            throw new NotImplementedException();
        } 
    }
}
