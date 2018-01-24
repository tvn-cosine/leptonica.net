using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RotateAm
    {
        // Rotation about the image center 
        public static Pix pixRotateAM(this Pix pixs, float angle, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRotateAMColor(this Pix pixs, float angle, uint colorval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRotateAMGray(this Pix pixs, float angle, byte grayval)
        {
            throw new NotImplementedException();
        }


        // Rotation about the UL corner of the image 
        public static Pix pixRotateAMCorner(this Pix pixs, float angle, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRotateAMColorCorner(this Pix pixs, float angle, uint fillval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRotateAMGrayCorner(this Pix pixs, float angle, byte grayval)
        {
            throw new NotImplementedException();
        }


        // Faster color rotation about the image center 
        public static Pix pixRotateAMColorFast(this Pix pixs, float angle, uint colorval)
        {
            throw new NotImplementedException();
        }

    }
}
