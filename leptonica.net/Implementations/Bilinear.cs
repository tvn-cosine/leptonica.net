using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Bilinear
    {
        // Bilinear (4 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        public static Pix pixBilinearSampledPta(this Pix pixs, Pta ptad, Pta ptas, int incolor)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearSampledPta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinearSampled(this Pix pixs, IntPtr vc, int incolor)
        {
            if (null == pixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("pixs,vc cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearSampled((HandleRef)pixs, vc, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Bilinear (4 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        public static Pix pixBilinearPta(this Pix pixs, Pta ptad, Pta ptas, int incolor)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearPta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinear(this Pix pixs, IntPtr vc, int incolor)
        {
            if (null == pixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("pixs,vc cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinear((HandleRef)pixs, vc, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinearPtaColor(this Pix pixs, Pta ptad, Pta ptas, uint colorval)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearPtaColor((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, colorval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinearColor(this Pix pixs, IntPtr vc, uint colorval)
        {
            if (null == pixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("pixs,vc cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearColor((HandleRef)pixs, vc, colorval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinearPtaGray(this Pix pixs, Pta ptad, Pta ptas, byte grayval)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearPtaGray((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, grayval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilinearGray(this Pix pixs, IntPtr vc, byte grayval)
        {
            if (null == pixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("pixs,vc cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearGray((HandleRef)pixs, vc, grayval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Bilinear transform including alpha (blend) component
        public static Pix pixBilinearPtaWithAlpha(this Pix pixs, Pta ptad, Pta ptas, Pix pixg, float fract, int border)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixBilinearPtaWithAlpha((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, (HandleRef)pixg, fract, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Bilinear coordinate transformation
        public static int getBilinearXformCoeffs(this Pta ptas, Pta ptad, out IntPtr pvc)
        {
            if (null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("ptad, ptas cannot be null.");
            }

            return Native.DllImports.getBilinearXformCoeffs((HandleRef)ptas, (HandleRef)ptad, out pvc);
        }

        public static int bilinearXformSampledPt(IntPtr vc, int x, int y, out int pxp, out int pyp)
        {
            if (IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.bilinearXformSampledPt(vc, x, y, out pxp, out pyp);
        }

        public static int bilinearXformPt(IntPtr vc, int x, int y, out float pxp, out float pyp)
        {
            if (IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.bilinearXformPt(vc, x, y, out pxp, out pyp);
        }
    }
}
