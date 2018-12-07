using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class TextOps
    {
        // Font layout
        public static Pix pixAddSingleTextblock(this Pix pixs, L_Bmf bmf, string textstr, uint val, FlagsForAddingTextToAPix location, out int poverflow)
        {
            var pointer = Native.DllImports.pixAddSingleTextblock((HandleRef)pixs, (HandleRef)bmf, textstr, val, (int)location, out poverflow);
            return new Pix(pointer);
        }

        public static Pix pixAddTextlines(this Pix pixs, L_Bmf bmf, string textstr, uint val, int location)
        {
            throw new NotImplementedException();
        }

        public static int pixSetTextblock(this Pix pixs, L_Bmf bmf, string textstr, uint val, int x0, int y0, int wtext, int firstindent, out int poverflow)
        {
            throw new NotImplementedException();
        }

        public static int pixSetTextline(this Pix pixs, L_Bmf bmf, string textstr, uint val, int x0, int y0, out int pwidth, out int poverflow)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaAddTextNumber(this Pixa pixas, L_Bmf bmf, Numa na, uint val, int location)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaAddTextlines(this Pixa pixas, L_Bmf bmf, Sarray sa, uint val, int location)
        {
            throw new NotImplementedException();
        }

        public static int pixaAddPixWithText(this Pixa pixa, Pix pixs, int reduction, L_Bmf bmf, string textstr, uint val, int location)
        {
            throw new NotImplementedException();
        }


        // Text size estimation and partitioning
        public static Sarray bmfGetLineStrings(L_Bmf bmf, string textstr, int maxw, int firstindent, out int ph)
        {
            throw new NotImplementedException();
        }

        public static Numa bmfGetWordWidths(this L_Bmf bmf, string textstr, Sarray sa)
        {
            throw new NotImplementedException();
        }

        public static int bmfGetStringWidth(this L_Bmf bmf, string textstr, out int pw)
        {
            throw new NotImplementedException();
        }


        // Text splitting
        public static Sarray splitStringToParagraphs(string textstr, int splitflag)
        {
            throw new NotImplementedException();
        }
    }
}
