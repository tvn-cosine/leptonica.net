using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pixtiling
    {
         public static  PixTiling pixTilingCreate(this Pix pixs, int nx, int ny, int w, int h, int xoverlap, int yoverlap)
        {
            throw new NotImplementedException();
        }

         public static  void pixTilingDestroy(this PixTiling ppt)
        {
            throw new NotImplementedException();
        }

         public static  int pixTilingGetCount(this PixTiling pt, out int pnx, out int pny)
        {
            throw new NotImplementedException();
        }

         public static  int pixTilingGetSize(this PixTiling pt, out int pw, out int ph)
        {
            throw new NotImplementedException();
        }

         public static  Pix pixTilingGetTile(this PixTiling pt, int i, int j)
        {
            throw new NotImplementedException();
        }

         public static  int pixTilingNoStripOnPaint(this PixTiling pt)
        {
            throw new NotImplementedException();
        }

         public static  int pixTilingPaintTile(this Pix pixd, int i, int j, Pix pixs, PixTiling pt)
        {
            throw new NotImplementedException();
        }

    }
}
