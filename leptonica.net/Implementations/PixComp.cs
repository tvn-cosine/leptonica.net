using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pixcomp
    {
        // Pixcomp creation and destruction
        public static PixComp pixcompCreateFromPix(this Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static PixComp pixcompCreateFromString(IntPtr data, IntPtr size, int copyflag)
        {
            throw new NotImplementedException();
        }

        public static PixComp pixcompCreateFromFile(string filename, int comptype)
        {
            throw new NotImplementedException();
        }

        public static void pixcompDestroy(this PixComp ppixc)
        {
            throw new NotImplementedException();
        }

        public static PixComp pixcompCopy(this PixComp pixcs)
        {
            throw new NotImplementedException();
        }


        // Pixcomp accessors
        public static int pixcompGetDimensions(this PixComp pixc, out int pw, out int ph, out int pd)
        {
            throw new NotImplementedException();
        }

        public static int pixcompDetermineFormat(int comptype, int d, int cmapflag, out int pformat)
        {
            throw new NotImplementedException();
        }


        // Pixcomp conversion to Pix
        public static Pix pixCreateFromPixcomp(this PixComp pixc)
        {
            throw new NotImplementedException();
        }


        // Pixacomp creation and destruction
        public static PixaComp pixacompCreate(int n)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompCreateWithInit(int n, int offset, Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompCreateFromPixa(this Pixa pixa, int comptype, int accesstype)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompCreateFromFiles(string dirname, string substr, int comptype)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompCreateFromSA(this Sarray sa, int comptype)
        {
            throw new NotImplementedException();
        }

        public static void pixacompDestroy(this Pixacc ppixac)
        {
            throw new NotImplementedException();
        }


        // Pixacomp addition/replacement
        public static int pixacompAddPix(this PixaComp pixac, Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static int pixacompAddPixcomp(this PixaComp pixac, PixComp pixc, int copyflag)
        {
            throw new NotImplementedException();
        }

        public static int pixacompReplacePix(this PixaComp pixac, int index, Pix pix, int comptype)
        {
            throw new NotImplementedException();
        }

        public static int pixacompReplacePixcomp(this PixaComp pixac, int index, PixComp pixc)
        {
            throw new NotImplementedException();
        }

        public static int pixacompAddBox(this PixaComp pixac, HandleRef box, int copyflag)
        {
            throw new NotImplementedException();
        }


        // Pixacomp accessors
        public static int pixacompGetCount(this PixaComp pixac)
        {
            throw new NotImplementedException();
        }

        public static PixComp pixacompGetPixcomp(this PixaComp pixac, int index, int copyflag)
        {
            throw new NotImplementedException();
        }

        public static Pix pixacompGetPix(this PixaComp pixac, int index)
        {
            throw new NotImplementedException();
        }

        public static int pixacompGetPixDimensions(this PixaComp pixac, int index, out int pw, out int ph, out int pd)
        {
            throw new NotImplementedException();
        }

        public static Boxa pixacompGetBoxa(this PixaComp pixac, int accesstype)
        {
            throw new NotImplementedException();
        }

        public static int pixacompGetBoxaCount(this PixaComp pixac)
        {
            throw new NotImplementedException();
        }

        public static Box pixacompGetBox(this PixaComp pixac, int index, int accesstype)
        {
            throw new NotImplementedException();
        }

        public static int pixacompGetBoxGeometry(this PixaComp pixac, int index, out int px, out int py, out int pw, out int ph)
        {
            throw new NotImplementedException();
        }

        public static int pixacompGetOffset(this PixaComp pixac)
        {
            throw new NotImplementedException();
        }

        public static int pixacompSetOffset(this PixaComp pixac, int offset)
        {
            throw new NotImplementedException();
        }


        // Pixacomp conversion to Pixa
        public static Pixa pixaCreateFromPixacomp(this PixaComp pixac, int accesstype)
        {
            throw new NotImplementedException();
        }


        // Combining pixacomp
        public static int pixacompJoin(this PixaComp pixacd, PixaComp pixacs, int istart, int iend)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompInterleave(this PixaComp pixac1, PixaComp pixac2)
        {
            throw new NotImplementedException();
        }


        // Pixacomp serialized I/O
        public static PixaComp pixacompRead(string filename)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static PixaComp pixacompReadMem(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int pixacompWrite(string filename, PixaComp pixac)
        {
            throw new NotImplementedException();
        }

        public static int pixacompWriteStream(IntPtr fp, PixaComp pixac)
        {
            throw new NotImplementedException();
        }

        public static int pixacompWriteMem(out IntPtr pdata, IntPtr psize, PixaComp pixac)
        {
            throw new NotImplementedException();
        }


        // Conversion to pdf
        public static int pixacompConvertToPdf(this PixaComp pixac, int res, float scalefactor, int type, int quality, string title, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int pixacompConvertToPdfData(this PixaComp pixac, int res, float scalefactor, int type, int quality, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            throw new NotImplementedException();
        }


        // Output for debugging
        public static int pixacompWriteStreamInfo(IntPtr fp, PixaComp pixac, string text)
        {
            throw new NotImplementedException();
        }

        public static int pixcompWriteStreamInfo(IntPtr fp, PixComp pixc, string text)
        {
            throw new NotImplementedException();
        }

        public static Pix pixacompDisplayTiledAndScaled(this PixaComp pixac, int outdepth, int tilewidth, int ncols, int background, int spacing, int border)
        {
            throw new NotImplementedException();
        } 
    }
}
