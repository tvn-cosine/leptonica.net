using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Blend
    {
        // Blending two images that are not colormapped 
        public static Pix pixBlend(this Pix pixs1, Pix pixs2, int x, int y, float fract)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlend((HandleRef)pixs1, (HandleRef)pixs2, x, y, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendMask(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract, int type)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendMask((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendGray(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract, int type, int transparent, uint transpix)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendGray((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract, type, transparent, transpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendGrayInverse(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendGrayInverse((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendColor(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract, int transparent, uint transpix)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendColor((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract, transparent, transpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendColorByChannel(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float rfract, float gfract, float bfract, int transparent, uint transpix)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendColorByChannel((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, rfract, gfract, bfract, transparent, transpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendGrayAdapt(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract, int shift)
        {
            if (null == pixs1
             || null == pixs1)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendGrayAdapt((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract, shift);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFadeWithGray(this Pix pixs, Pix pixb, float factor, int type)
        {
            if (null == pixs
             || null == pixb)
            {
                throw new ArgumentNullException("pixs, pixb cannot be null.");
            }

            var pointer = Native.DllImports.pixFadeWithGray((HandleRef)pixs, (HandleRef)pixb, factor, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendHardLight(this Pix pixd, Pix pixs1, Pix pixs2, int x, int y, float fract)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixb cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendHardLight((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2, x, y, fract);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Blending two colormapped images
        public static int pixBlendCmap(this Pix pixs, Pix pixb, int x, int y, int sindex)
        {
            if (null == pixs
             || null == pixb)
            {
                throw new ArgumentNullException("pixs, pixb cannot be null.");
            }

            return Native.DllImports.pixBlendCmap((HandleRef)pixs, (HandleRef)pixb, x, y, sindex);
        }

        // Blending two images using a third (alpha mask)
        public static Pix pixBlendWithGrayMask(this Pix pixs1, Pix pixs2, Pix pixg, int x, int y)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendWithGrayMask((HandleRef)pixs1, (HandleRef)pixs2, (HandleRef)pixg, x, y);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Blending background to a specific color
        public static Pix pixBlendBackgroundToColor(this Pix pixd, Pix pixs, Box box, uint color, float gamma, int minval, int maxval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendBackgroundToColor((HandleRef)pixd, (HandleRef)pixs, (HandleRef)box, color, gamma, minval, maxval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Multiplying by a specific color
        public static Pix pixMultiplyByColor(this Pix pixd, Pix pixs, Box box, uint color)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMultiplyByColor((HandleRef)pixd, (HandleRef)pixs, (HandleRef)box, color);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Rendering with alpha blending over a uniform background
        public static Pix pixAlphaBlendUniform(this Pix pixs, uint color)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixAlphaBlendUniform((HandleRef)pixs, color);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Adding an alpha layer for blending
        public static Pix pixAddAlphaToBlend(this Pix pixs, float fract, int invert)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixAddAlphaToBlend((HandleRef)pixs, fract, invert);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Setting a transparent alpha component over a white background
        public static Pix pixSetAlphaOverWhite(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSetAlphaOverWhite((HandleRef)pixs);
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
