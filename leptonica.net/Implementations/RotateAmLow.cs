using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RotateAmLow
    {
        // 32 bpp grayscale rotation about image center
        public static void rotateAMColorLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval)
        {
            throw new NotImplementedException();
        }

        // 8 bpp grayscale rotation about image center
        public static void rotateAMGrayLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval)
        {
            throw new NotImplementedException();
        }

        // 32 bpp grayscale rotation about UL corner of image
        public static void rotateAMColorCornerLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval)
        {
            throw new NotImplementedException();
        }

        // 8 bpp grayscale rotation about UL corner of image
        public static void rotateAMGrayCornerLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval)
        {
            throw new NotImplementedException();
        }

        // Fast RGB color rotation about center:
        public static void rotateAMColorFastLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval)
        {
            throw new NotImplementedException();
        }
    }
}
