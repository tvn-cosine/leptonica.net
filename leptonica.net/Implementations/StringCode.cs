using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class StringCode
    {
        public static L_StrCode  strcodeCreate(int fileno)
        {
            throw new NotImplementedException();
        }

        public static int strcodeCreateFromFile(string filein, int fileno, string outdir)
        {
            throw new NotImplementedException();
        }

        public static int strcodeGenerate(this L_StrCode strcode, string filein, string type)
        {
            throw new NotImplementedException();
        }

        public static int strcodeFinalize(this L_StrCode pstrcode, string outdir)
        {
            throw new NotImplementedException();
        }

        public static int l_getStructStrFromFile(string filename, int field, out IntPtr pstr)
        {
            throw new NotImplementedException();
        } 
    }
}
