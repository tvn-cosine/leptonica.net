using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class Coloring
    {
        // Coloring "gray" pixels
        public static Pix pixColorGrayRegions(this Pix pixs, Boxa boxa, int type, int thresh, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixColorGrayRegions((HandleRef)pixs, (HandleRef)boxa, type, thresh, rval, gval, bval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixColorGray(this Pix pixs, Box box, int type, int thresh, int rval, int gval, int bval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixColorGray((HandleRef)pixs, (HandleRef)box, type, thresh, rval, gval, bval);
        }

        public static Pix pixColorGrayMasked(this Pix pixs, Pix pixm, int type, int thresh, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }

            var pointer = Native.DllImports.pixColorGrayRegions((HandleRef)pixs, (HandleRef)pixm, type, thresh, rval, gval, bval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Adjusting one or more colors to a target color
        public static Pix pixSnapColor(this Pix pixd, Pix pixs, uint srcval, uint dstval, int diff)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSnapColor((HandleRef)pixd, (HandleRef)pixs, srcval, dstval, diff);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixSnapColorCmap(this Pix pixd, Pix pixs, uint srcval, uint dstval, int diff)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSnapColorCmap((HandleRef)pixd, (HandleRef)pixs, srcval, dstval, diff);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Piecewise linear color mapping based on a source/target pair
        public static Pix pixLinearMapToTargetColor(this Pix pixd, Pix pixs, uint srcval, uint dstval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixLinearMapToTargetColor((HandleRef)pixd, (HandleRef)pixs, srcval, dstval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixelLinearMapToTargetColor(uint scolor, uint srcmap, uint dstmap, out uint pdcolor)
        {
            return Native.DllImports.pixelLinearMapToTargetColor(scolor, srcmap, dstmap, out pdcolor);
        }

        // Fractional shift of RGB towards black or white
        public static Pix pixShiftByComponent(this Pix pixd, Pix pixs, uint srcval, uint dstval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixShiftByComponent((HandleRef)pixd, (HandleRef)pixs, srcval, dstval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixelShiftByComponent(int rval, int gval, int bval, uint srcval, uint dstval, out uint ppixel)
        {
            return Native.DllImports.pixelShiftByComponent(rval, gval, bval, srcval, dstval, out ppixel);
        }

        public static int pixelFractionalShift(int rval, int gval, int bval, float fraction, out uint ppixel)
        {
            return Native.DllImports.pixelFractionalShift(rval, gval, bval, fraction, out ppixel);
        }
    }
}
