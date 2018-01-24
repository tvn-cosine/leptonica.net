using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Enhance
    {
        // Gamma TRC(tone reproduction curve) mapping
        public static Pix pixGammaTRC(this Pix pixd, Pix pixs, float gamma, int minval, int maxval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGammaTRC((HandleRef)pixd, (HandleRef)pixs, gamma, minval, maxval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixGammaTRCMasked(this Pix pixd, Pix pixs, Pix pixm, float gamma, int minval, int maxval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGammaTRCMasked((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, gamma, minval, maxval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixGammaTRCWithAlpha(this Pix pixd, Pix pixs, float gamma, int minval, int maxval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGammaTRCWithAlpha((HandleRef)pixd, (HandleRef)pixs, gamma, minval, maxval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Numa numaGammaTRC(float gamma, int minval, int maxval)
        {
            var pointer = Native.DllImports.numaGammaTRC(gamma, minval, maxval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Contrast enhancement
        public static Pix pixContrastTRC(this Pix pixd, Pix pixs, float factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixContrastTRC((HandleRef)pixd, (HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixContrastTRCMasked(this Pix pixd, Pix pixs, Pix pixm, float factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixContrastTRCMasked((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Numa numaContrastTRC(float factor)
        {
            var pointer = Native.DllImports.numaContrastTRC(factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Histogram equalization
        public static Pix pixEqualizeTRC(this Pix pixd, Pix pixs, float fract, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixEqualizeTRC((HandleRef)pixd, (HandleRef)pixs, fract, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Numa numaEqualizeTRC(this Pix pix, float fract, int factor)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.numaEqualizeTRC((HandleRef)pix, fract, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Generic TRC mapper
        public static int pixTRCMap(this Pix pixs, Pix pixm, Numa na)
        {
            if (null == pixs
             || null == na)
            {
                throw new ArgumentNullException("pixs, na cannot be null.");
            }

            return Native.DllImports.pixTRCMap((HandleRef)pixs, (HandleRef)pixm, (HandleRef)na);
        }

        // Unsharp-masking
        public static Pix pixUnsharpMasking(this Pix pixs, int halfwidth, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMasking((HandleRef)pixs, halfwidth, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixUnsharpMaskingGray(this Pix pixs, int halfwidth, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMaskingGray((HandleRef)pixs, halfwidth, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixUnsharpMaskingFast(this Pix pixs, int halfwidth, float fract, int direction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMaskingFast((HandleRef)pixs, halfwidth, fract, direction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixUnsharpMaskingGrayFast(this Pix pixs, int halfwidth, float fract, int direction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMaskingGrayFast((HandleRef)pixs, halfwidth, fract, direction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixUnsharpMaskingGray1D(this Pix pixs, int halfwidth, float fract, int direction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMaskingGray1D((HandleRef)pixs, halfwidth, fract, direction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixUnsharpMaskingGray2D(this Pix pixs, int halfwidth, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixUnsharpMaskingGray2D((HandleRef)pixs, halfwidth, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Hue and saturation modification
        public static Pix pixModifyHue(this Pix pixd, Pix pixs, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixModifyHue((HandleRef)pixd, (HandleRef)pixs, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixModifySaturation(this Pix pixd, Pix pixs, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixModifySaturation((HandleRef)pixd, (HandleRef)pixs, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixMeasureSaturation(this Pix pixs, int factor, out float psat)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixMeasureSaturation((HandleRef)pixs, factor, out psat);
        }

        public static Pix pixModifyBrightness(this Pix pixd, Pix pixs, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixModifyBrightness((HandleRef)pixd, (HandleRef)pixs, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Color shifting
        public static Pix pixColorShiftRGB(this Pix pixs, float rfract, float gfract, float bfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorShiftRGB((HandleRef)pixs, rfract, gfract, bfract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // General multiplicative constant color transform
        public static Pix pixMultConstantColor(this Pix pixs, float rfact, float gfact, float bfact)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMultConstantColor((HandleRef)pixs, rfact, gfact, bfact);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMultMatrixColor(this Pix pixs, L_Kernel kel)
        {
            if (null == pixs
             || null == kel)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixMultMatrixColor((HandleRef)pixs, (HandleRef)kel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Edge by bandpass
        public static Pix pixHalfEdgeByBandpass(this Pix pixs, int sm1h, int sm1v, int sm2h, int sm2v)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixHalfEdgeByBandpass((HandleRef)pixs, sm1h, sm1v, sm2h, sm2v);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
    }
}
