using System; 

namespace Leptonica.Implementations
{
    public static class DwaCombLow
    {
        //  Dispatcher: 
        public static int fmorphopgen_low_2(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index)
        {
            return Native.DllImports.fmorphopgen_low_2(datad, w, h, wpld, datas, wpls, index);
        }
    }
}
