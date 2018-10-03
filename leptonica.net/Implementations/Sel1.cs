using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Sel1
    {
        // Create/destroy/copy:
        public static Sela selaCreate(int n)
        {
            var pointer = Native.DllImports.selaCreate(n);
            return new Sela(pointer);
        }

        public static void selaDestroy(this Sela psela)
        {
            var pointer = (IntPtr)psela;
            Native.DllImports.selaDestroy(ref pointer);
        }

        public static Sel selCreate(int height, int width, string name)
        {
            throw new NotImplementedException();
        }

        public static void selDestroy(this Sel psel)
        {
            var pointer = (IntPtr)psel;
            Native.DllImports.selDestroy(ref pointer);
        }

        public static Sel selCopy(this Sel sel)
        {
            throw new NotImplementedException();
        }

        public static Sel selCreateBrick(int h, int w, int cy, int cx, int type)
        {
            var sel = Native.DllImports.selCreateBrick(h, w, cy, cx, (int)type);
            return new Sel(sel);
        }

        public static Sel selCreateComb(int factor1, int factor2, int direction)
        {
            throw new NotImplementedException();
        }


        // Helper proc:
        public static IntPtr create2dIntArray(int sy, int sx)
        {
            throw new NotImplementedException();
        }


        // Extension of sela:
        public static int selaAddSel(this Sela sela, Sel sel, string selname, int copyflag)
        {
            return Native.DllImports.selaAddSel((HandleRef)sela, (HandleRef)sel, selname, copyflag);
        }


        // Accessors:
        public static int selaGetCount(this Sela sela)
        {
            throw new NotImplementedException();
        }

        public static Sel selaGetSel(this Sela sela, int i)
        {
            throw new NotImplementedException();
        }

        public static IntPtr selGetName(this Sel sel)
        {
            throw new NotImplementedException();
        }

        public static int selSetName(this Sel sel, string name)
        {
            throw new NotImplementedException();
        }

        public static int selaFindSelByName(this Sela sela, string name, out int pindex, out Sel psel)
        {
            throw new NotImplementedException();
        }

        public static int selGetElement(this Sel sel, int row, int col, out int ptype)
        {
            throw new NotImplementedException();
        }

        public static int selSetElement(this Sel sel, int row, int col, int type)
        {
            throw new NotImplementedException();
        }

        public static int selGetParameters(this Sel sel, out int psy, out int psx, out int pcy, out int pcx)
        {
            throw new NotImplementedException();
        }

        public static int selSetOrigin(this Sel sel, int cy, int cx)
        {
            throw new NotImplementedException();
        }

        public static int selGetTypeAtOrigin(this Sel sel, out int ptype)
        {
            throw new NotImplementedException();
        }

        public static IntPtr selaGetBrickName(this Sela sela, int hsize, int vsize)
        {
            throw new NotImplementedException();
        }

        public static IntPtr selaGetCombName(this Sela sela, int size, int direction)
        {
            throw new NotImplementedException();
        }

        public static int getCompositeParameters(int size, out int psize1, out int psize2, out IntPtr pnameh1, out IntPtr pnameh2, out IntPtr pnamev1, out IntPtr pnamev2)
        {
            throw new NotImplementedException();
        }

        public static Sarray selaGetSelnames(this Sela sela)
        {
            throw new NotImplementedException();
        }


        // Max translations for erosion and hmt
        public static int selFindMaxTranslations(this Sel sel, out int pxp, out int pyp, out int pxn, out int pyn)
        {
            throw new NotImplementedException();
        }


        // Rotation by multiples of 90 degrees
        public static Sel selRotateOrth(this Sel sel, int quads)
        {
            var pointer = Native.DllImports.selRotateOrth((HandleRef)sel, quads);
            return new Sel(pointer);
        }


        // Sela and Sel serialized I/O
        public static Sela selaRead(string fname)
        {
            throw new NotImplementedException();
        }

        public static Sela selaReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static Sel selRead(string fname)
        {
            throw new NotImplementedException();
        }

        public static Sel selReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static int selaWrite(string fname, Sela sela)
        {
            return Native.DllImports.selaWrite(fname, (HandleRef)sela);
        }

        public static int selaWriteStream(IntPtr fp, Sela sela)
        {
            throw new NotImplementedException();
        }

        public static int selWrite(string fname, Sel sel)
        {
            return Native.DllImports.selWrite(fname, (HandleRef)sel);
        }

        public static int selWriteStream(IntPtr fp, Sel sel)
        {
            throw new NotImplementedException();
        }


        // Building custom hit-miss sels from compiled strings
        public static Sel selCreateFromString(string text, int h, int w, string name)
        {
            var pointer = Native.DllImports.selCreateFromString(text, h, w, name);
            return new Sel(pointer);
        }

        public static string selPrintToString(this Sel sel)
        {
            var pointer = Native.DllImports.selPrintToString((HandleRef)sel);
            return Marshal.PtrToStringAnsi(pointer);
        }

        // Building custom hit-miss sels from a simple file format
        public static Sela selaCreateFromFile(string filename)
        {
            throw new NotImplementedException();
        }

        // Making hit-only sels from Pta and Pix
        public static Sel selCreateFromPta(HandleRef pta, int cy, int cx, string name)
        {
            throw new NotImplementedException();
        }

        public static Sel selCreateFromPix(this Pix pix, int cy, int cx, string name)
        {
            throw new NotImplementedException();
        }


        // Making hit-miss sels from Pix and image files
        public static Sel selReadFromColorImage(string pathname)
        {
            throw new NotImplementedException();
        }

        public static Sel selCreateFromColorPix(this Pix pixs, string selname)
        {
            throw new NotImplementedException();
        }


        // Printable display of sel
        public static Pix selDisplayInPix(this Sel sel, int size, int gthick)
        {
            throw new NotImplementedException();
        }

        public static Pix selaDisplayInPix(this Sela sela, int size, int gthick, int spacing, int ncols)
        {
            var pointer = Native.DllImports.selaDisplayInPix((HandleRef)sela, size, gthick, spacing, ncols);
            return new Pix(pointer);
        }
    }
}
