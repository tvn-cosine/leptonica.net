using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class ColorMorph
    {
        public static Pix pixColorMorph(this Pix pixs, int type, int hsize, int vsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorMorph((HandleRef)pixs, type, hsize, vsize);
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
