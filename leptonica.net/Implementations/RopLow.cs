using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RopLow
    {  
        // Low level dest-only
        public static  void rasteropUniLow(IntPtr datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op)
        {
            throw new NotImplementedException();
        }


        // Low level src and dest 
        public static  void rasteropLow(IntPtr datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op, IntPtr datas, int spixw, int spixh, int swpl, int sx, int sy)
        {
            throw new NotImplementedException();
        } 
    }
}
