using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Rop
    {
        // General rasterop 
        public static int pixRasterop(this Pix pixd, int dx, int dy, int dw, int dh, int op, Pix pixs, int sx, int sy)
        {
            throw new NotImplementedException();
        }

        // In-place full band translation 
        public static int pixRasteropVip(this Pix pixd, int bx, int bw, int vshift, int incolor)
        {
            throw new NotImplementedException();
        }
        public static int pixRasteropHip(this Pix pixd, int by, int bh, int hshift, int incolor)
        {
            throw new NotImplementedException();
        }

        // Full image translation(general and in-place) 
        public static Pix pixTranslate(this Pix pixd, Pix pixs, int hshift, int vshift, int incolor)
        {
            throw new NotImplementedException();
        }

        public static int pixRasteropIP(this Pix pixd, int hshift, int vshift, int incolor)
        {
            throw new NotImplementedException();
        }

        // Full image rasterop with no translation 
        public static int pixRasteropFullImage(this Pix pixd, Pix pixs, int op)
        {
            throw new NotImplementedException();
        }
    }
}
