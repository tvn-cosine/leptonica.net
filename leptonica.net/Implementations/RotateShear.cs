using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RotateShear
    {
        // Shear rotation about arbitrary point using 2 and 3 shears 
        public static  Pix  pixRotateShear(this Pix pixs, int xcen, int ycen, float angle, int incolor)
        {
            throw new NotImplementedException();
        }

        public static  Pix  pixRotate2Shear(this Pix pixs, int xcen, int ycen, float angle, int incolor)
        {
            throw new NotImplementedException();
        }

        public static  Pix  pixRotate3Shear(this Pix pixs, int xcen, int ycen, float angle, int incolor)
        {
            throw new NotImplementedException();
        }


        // Shear rotation in-place about arbitrary point using 3 shears
        public static int pixRotateShearIP(this Pix pixs, int xcen, int ycen, float angle, int incolor)
        {
            throw new NotImplementedException();
        }


        // Shear rotation around the image center
        public static  Pix  pixRotateShearCenter(this Pix pixs, float angle, int incolor)
        {
            throw new NotImplementedException();
        }

        public static int pixRotateShearCenterIP(this Pix pixs, float angle, int incolor)
        {
            throw new NotImplementedException();
        } 
    }
}
