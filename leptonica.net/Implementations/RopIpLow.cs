using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RopIpLow
    {
        // Low level in-place full height vertical block transfer  
        public static void rasteropVipLow(IntPtr data, int pixw, int pixh, int depth, int wpl, int x, int w, int shift)
        {
            throw new NotImplementedException();
        }


        // Low level in-place full width horizontal block transfer  
        public static void rasteropHipLow(IntPtr data, int pixh, int depth, int wpl, int y, int h, int shift)
        {
            throw new NotImplementedException();
        }

        public static void shiftDataHorizontalLow(IntPtr datad, int wpld, IntPtr datas, int wpls, int shift)
        {
            throw new NotImplementedException();
        } 
    }
}
