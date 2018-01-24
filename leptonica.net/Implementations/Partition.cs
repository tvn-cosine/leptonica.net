using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Partition
    {
        // Whitespace block extraction
        public static Boxa boxaGetWhiteblocks(Boxa boxas, Box box, int sortflag, int maxboxes, float maxoverlap, int maxperim, float fract, int maxpops)
        {
            if (null == boxas
             || null == box)
            {
                throw new ArgumentNullException("boxas, box cannot be null.");
            }

            var pointer = Native.DllImports.boxaGetWhiteblocks((HandleRef)boxas, (HandleRef)box, sortflag, maxboxes, maxoverlap, maxperim, fract, maxpops);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // Helpers  
        public static Boxa boxaPruneSortedOnOverlap(Boxa boxas, float maxoverlap)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaPruneSortedOnOverlap((HandleRef)boxas, maxoverlap);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }
    }
}
