using System;

namespace Leptonica 
{
    public static class Encoding
    {
        // Base64
        public static IntPtr encodeBase64(IntPtr inarray, int insize, out int poutsize)
        {
            if (IntPtr.Zero == inarray)
            {
                throw new ArgumentNullException("inarray cannot be null");
            }

            return Native.DllImports.encodeBase64(inarray, insize, out poutsize);
        }

        public static IntPtr decodeBase64(string inarray, int insize, out int poutsize)
        {
            if (string.IsNullOrEmpty(inarray))
            {
                throw new ArgumentNullException("inarray cannot be null");
            }

            return Native.DllImports.decodeBase64(inarray, insize, out poutsize);
        }

        // Ascii85
        public static IntPtr encodeAscii85(IntPtr inarray, int insize, out int poutsize)
        {
            if (IntPtr.Zero == inarray)
            {
                throw new ArgumentNullException("inarray cannot be null");
            }

            return Native.DllImports.encodeAscii85(inarray, insize, out poutsize);
        }

        public static IntPtr decodeAscii85(string inarray, int insize, out int poutsize)
        {
            if (string.IsNullOrEmpty(inarray))
            {
                throw new ArgumentNullException("inarray cannot be null");
            }

            return Native.DllImports.decodeAscii85(inarray, insize, out poutsize);
        }

        // String reformatting for base 64 encoded data
        public static IntPtr reformatPacked64(string inarray, int insize, int leadspace, int linechars, int addquotes, out int poutsize)
        {
            if (string.IsNullOrEmpty(inarray))
            {
                throw new ArgumentNullException("inarray cannot be null");
            }

            return Native.DllImports.reformatPacked64(inarray, insize, leadspace, linechars, addquotes, out poutsize);
        }
    }
}
