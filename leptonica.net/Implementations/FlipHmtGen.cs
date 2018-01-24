using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class FlipHmtGen
    {
        public static Pix pixFlipFHMTGen(this Pix pixd, Pix pixs, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFlipFHMTGen((HandleRef)pixd, (HandleRef)pixs, selname);
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
