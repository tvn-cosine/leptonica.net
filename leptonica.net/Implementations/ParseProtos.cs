using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ParseProtos
    {
        public static string parseForProtos(string filein, string prestring)
        {
            if (string.IsNullOrEmpty(filein))
            {
                throw new ArgumentNullException("filein cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new ArgumentNullException("filein does not exist.");
            }

            var pointer = Native.DllImports.parseForProtos(filein, prestring);
            return Marshal.PtrToStringAnsi(pointer);
        }
    }
}
