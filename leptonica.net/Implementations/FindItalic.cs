using System;
using System.Runtime.InteropServices;
 
namespace Leptonica
{
    public static class FindItalic
    {
        public static int pixItalicWords(this Pix pixs, Boxa boxaw, Pix pixw, out Boxa pboxa, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr;
            var result = Native.DllImports.pixItalicWords((HandleRef)pixs, (HandleRef)boxaw, (HandleRef)pixw, out pboxaPtr, debugflag);
            if (IntPtr.Zero == pboxaPtr)
            {
                pboxa = null;
            }
            else
            {
                pboxa = new Boxa(pboxaPtr);
            }

            return result;
        }
    }
}
