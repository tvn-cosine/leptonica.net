using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Projective
    {
        // Projective(4 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        public static Pix pixProjectiveSampledPta(this Pix pixs, Pta ptad, Pta ptas, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjectiveSampled(this Pix pixs, out IntPtr vc, int incolor)
        {
            throw new NotImplementedException();
        }


        // Projective(4 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        public static Pix pixProjectivePta(this Pix pixs, Pta ptad, Pta ptas, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjective(this Pix pixs, out IntPtr vc, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjectivePtaColor(this Pix pixs, Pta ptad, Pta ptas, uint colorval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjectiveColor(this Pix pixs, out IntPtr vc, uint colorval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjectivePtaGray(this Pix pixs, Pta ptad, Pta ptas, byte grayval)
        {
            throw new NotImplementedException();
        }

        public static Pix pixProjectiveGray(this Pix pixs, out IntPtr vc, byte grayval)
        {
            throw new NotImplementedException();
        }


        // Projective transform including alpha(blend) component
        public static Pix pixProjectivePtaWithAlpha(this Pix pixs, Pta ptad, Pta ptas, Pix pixg, float fract, int border)
        {
            throw new NotImplementedException();
        }


        // Projective coordinate transformation
        public static int getProjectiveXformCoeffs(Pta ptas, Pta ptad, out IntPtr pvc)
        {
            throw new NotImplementedException();
        }

        public static int projectiveXformSampledPt(out IntPtr vc, int x, int y, out int pxp, out int pyp)
        {
            throw new NotImplementedException();
        }

        public static int projectiveXformPt(out IntPtr vc, int x, int y, out float pxp, out float pyp)
        {
            throw new NotImplementedException();
        }
    }
}
