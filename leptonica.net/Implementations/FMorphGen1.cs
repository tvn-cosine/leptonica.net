using System;
using System.Runtime.InteropServices;
namespace Leptonica
{
    public static class FMorphGen1
    {
        // Top-level fast binary morphology with auto-generated sels
        public static Pix pixMorphDwa_1(this Pix pixd, Pix pixs, int operation, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphDwa_1((HandleRef)pixd, (HandleRef)pixs, operation, selname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFMorphopGen_1(this Pix pixd, Pix pixs, int operation, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFMorphopGen_1((HandleRef)pixd, (HandleRef)pixs, operation, selname);
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
