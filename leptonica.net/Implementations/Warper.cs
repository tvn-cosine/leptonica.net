using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Warper
    {
        // High-level captcha interface
        public static Pix pixSimpleCaptcha(this Pix pixs, int border, int nterms, uint seed, uint color, int cmapflag)
        {
            throw new NotImplementedException();
        }
         
        // Random sinusoidal warping
        public static Pix pixRandomHarmonicWarp(this Pix pixs, float xmag, float ymag, float xfreq, float yfreq, int nx, int ny, uint seed, int grayval)
        {
            throw new NotImplementedException();
        }
         
        // Stereoscopic warping
        public static Pix pixWarpStereoscopic(this Pix pixs, int zbend, int zshiftt, int zshiftb, int ybendt, int ybendb, int redleft)
        {
            throw new NotImplementedException();
        }


        // Linear and quadratic horizontal stretching
        public static Pix pixStretchHorizontal(this Pix pixs, int dir, int type, int hmax, int operation, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixStretchHorizontalSampled(this Pix pixs, int dir, int type, int hmax, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixStretchHorizontalLI(this Pix pixs, int dir, int type, int hmax, int incolor)
        {
            throw new NotImplementedException();
        }


        // Quadratic vertical shear
        public static Pix pixQuadraticVShear(this Pix pixs, int dir, int vmaxt, int vmaxb, int operation, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixQuadraticVShearSampled(this Pix pixs, int dir, int vmaxt, int vmaxb, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixQuadraticVShearLI(this Pix pixs, int dir, int vmaxt, int vmaxb, int incolor)
        {
            throw new NotImplementedException();
        }


        // Stereo from a pair of images
        public static Pix pixStereoFromPair(this Pix pix1, Pix pix2, float rwt, float gwt, float bwt)
        {
            throw new NotImplementedException();
        }
    }
}
