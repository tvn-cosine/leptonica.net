using System;

namespace Leptonica 
{
    public static class FhmtGenLow1
    {
        public static int fhmtgen_low_1(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index)
        {
            if (IntPtr.Zero == datad
             || IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("datad, datas cannot be null.");
            }

            return Native.DllImports.fhmtgen_low_1(datad, w, h, wpld, datas, wpls, index);
        }
    }
}
