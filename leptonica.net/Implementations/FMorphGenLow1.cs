using System; 

namespace Leptonica.Implementations
{
    public static class FMorphGenLow1
    {
        public static int fmorphopgen_low_1(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index)
        {
            if (IntPtr.Zero == datad
             || IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("datas, datad cannot be null.");
            }

            return Native.DllImports.fmorphopgen_low_1(datad, w, h, wpld, datas, wpls, index);
        }
    }
}
