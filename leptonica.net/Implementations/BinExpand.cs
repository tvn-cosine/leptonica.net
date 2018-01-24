using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class BinExpand
    {
        // Replicated expansion (integer scaling)
        public static Pix pixExpandBinaryReplicate(this Pix pixs, int xfact, int yfact)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExpandBinaryReplicate((HandleRef)pixs, xfact, yfact);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Special case: power of 2 replicated expansion
        public static Pix pixExpandBinaryPower2(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExpandBinaryPower2((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
    }
}
