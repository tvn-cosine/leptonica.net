using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class FhmtGen1
    {
        // Top-level fast hit-miss transform with auto-generated sels
        public static Pix pixHMTDwa_1(this Pix pixd, Pix pixs, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixHMTDwa_1((HandleRef)pixd, (HandleRef)pixs, selname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFHMTGen_1(this Pix pixd, Pix pixs, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFHMTGen_1((HandleRef)pixd, (HandleRef)pixs, selname);
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
