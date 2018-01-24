using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class FPix2
    {
        // Interconversions between Pix, FPix and DPix
        public static FPix pixConvertToFPix(this Pix pixs, int ncomps)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixConvertToFPix((HandleRef)pixs, ncomps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static DPix pixConvertToDPix(this Pix pixs, int ncomps)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixConvertToDPix((HandleRef)pixs, ncomps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static Pix fpixConvertToPix(this FPix fpixs, int outdepth, int negvals, int errorflag)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.fpixConvertToPix((HandleRef)fpixs, outdepth, negvals, errorflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix fpixDisplayMaxDynamicRange(this FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.fpixDisplayMaxDynamicRange((HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static DPix fpixConvertToDPix(this FPix fpix)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            var pointer = Native.DllImports.fpixConvertToDPix((HandleRef)fpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static Pix dpixConvertToPix(this DPix dpixs, int outdepth, int negvals, int errorflag)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null");
            }

            var pointer = Native.DllImports.dpixConvertToPix((HandleRef)dpixs, outdepth, negvals, errorflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static FPix dpixConvertToFPix(this DPix dpix)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            var pointer = Native.DllImports.dpixConvertToFPix((HandleRef)dpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        // Min/max value
        public static int fpixGetMin(this FPix fpix, out float pminval, out int pxminloc, out int pyminloc)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            return Native.DllImports.fpixGetMin((HandleRef)fpix, out pminval, out pxminloc, out pyminloc);
        }

        public static int fpixGetMax(this FPix fpix, out float pmaxval, out int pxmaxloc, out int pymaxloc)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            return Native.DllImports.fpixGetMax((HandleRef)fpix, out pmaxval, out pxmaxloc, out pymaxloc);
        }

        public static int dpixGetMin(this DPix dpix, out double pminval, out int pxminloc, out int pyminloc)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            return Native.DllImports.dpixGetMin((HandleRef)dpix, out pminval, out pxminloc, out pyminloc);
        }

        public static int dpixGetMax(this DPix dpix, out double pmaxval, out int pxmaxloc, out int pymaxloc)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            return Native.DllImports.dpixGetMax((HandleRef)dpix, out pmaxval, out pxmaxloc, out pymaxloc);
        }

        // Integer scaling
        public static FPix fpixScaleByInteger(this FPix fpixs, int factor)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixScaleByInteger((HandleRef)fpixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static DPix dpixScaleByInteger(this DPix dpixs, int factor)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null");
            }

            var pointer = Native.DllImports.dpixScaleByInteger((HandleRef)dpixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        // Arithmetic operations
        public static FPix fpixLinearCombination(this FPix fpixd, FPix fpixs1, FPix fpixs2, float a, float b)
        {
            if (null == fpixs1
             || null == fpixs2)
            {
                throw new ArgumentNullException("fpixs1, fpixs2 cannot be null");
            }

            var pointer = Native.DllImports.fpixLinearCombination((HandleRef)fpixd, (HandleRef)fpixs1, (HandleRef)fpixs2, a, b);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static int fpixAddMultConstant(this FPix fpix, float addc, float multc)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            return Native.DllImports.fpixAddMultConstant((HandleRef)fpix, addc, multc);
        }

        public static DPix dpixLinearCombination(this DPix dpixd, DPix dpixs1, DPix dpixs2, float a, float b)
        {
            if (null == dpixs1
             || null == dpixs2)
            {
                throw new ArgumentNullException("dpixs1, dpixs2 cannot be null");
            }

            var pointer = Native.DllImports.dpixLinearCombination((HandleRef)dpixd, (HandleRef)dpixs1, (HandleRef)dpixs2, a, b);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static int dpixAddMultConstant(this DPix dpix, double addc, double multc)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            return Native.DllImports.dpixAddMultConstant((HandleRef)dpix, addc, multc);
        }

        // Set all
        public static int fpixSetAllArbitrary(this FPix fpix, float inval)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            return Native.DllImports.fpixSetAllArbitrary((HandleRef)fpix, inval);
        }

        public static int dpixSetAllArbitrary(this DPix dpix, double inval)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            return Native.DllImports.dpixSetAllArbitrary((HandleRef)dpix, inval);
        }

        // FPix border functions
        public static FPix fpixAddBorder(this FPix fpixs, int left, int right, int top, int bot)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixAddBorder((HandleRef)fpixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixRemoveBorder(this FPix fpixs, int left, int right, int top, int bot)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixRemoveBorder((HandleRef)fpixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixAddMirroredBorder(this FPix fpixs, int left, int right, int top, int bot)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixAddMirroredBorder((HandleRef)fpixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixAddContinuedBorder(this FPix fpixs, int left, int right, int top, int bot)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixAddContinuedBorder((HandleRef)fpixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixAddSlopeBorder(this FPix fpixs, int left, int right, int top, int bot)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixAddSlopeBorder((HandleRef)fpixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }


        // FPix simple rasterop
        public static int fpixRasterop(this FPix fpixd, int dx, int dy, int dw, int dh, FPix fpixs, int sx, int sy)
        {
            if (null == fpixd
             || null == fpixs)
            {
                throw new ArgumentNullException("fpixd, fpixs cannot be null");
            }

            return Native.DllImports.fpixRasterop((HandleRef)fpixd, dx, dy, dw, dh, (HandleRef)fpixs, sx, sy);
        }

        // FPix rotation by multiples of 90 degrees
        public static FPix fpixRotateOrth(this FPix fpixs, int quads)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixRotateOrth((HandleRef)fpixs, quads);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixRotate180(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixRotate180((HandleRef)fpixd, (HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixRotate90(this FPix fpixs, int direction)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixRotate90((HandleRef)fpixs, direction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixFlipLR(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixFlipLR((HandleRef)fpixd, (HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixFlipTB(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixFlipTB((HandleRef)fpixd, (HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        // FPix affine and projective interpolated transforms
        public static FPix fpixAffinePta(this FPix fpixs, Pta ptad, Pta ptas, int border, float inval)
        {
            if (null == fpixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("fpixs, ptad, ptas cannot be null");
            }

            var pointer = Native.DllImports.fpixAffinePta((HandleRef)fpixs, (HandleRef)ptad, (HandleRef)ptas, border, inval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixAffine(this FPix fpixs, IntPtr vc, float inval)
        {
            if (null == fpixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("fpixs, vc cannot be null");
            }

            var pointer = Native.DllImports.fpixAffine((HandleRef)fpixs, vc, inval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixProjectivePta(this FPix fpixs, Pta ptad, Pta ptas, int border, float inval)
        {
            if (null == fpixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("fpixs, ptad, ptas cannot be null");
            }

            var pointer = Native.DllImports.fpixProjectivePta((HandleRef)fpixs, (HandleRef)ptad, (HandleRef)ptas, border, inval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixProjective(this FPix fpixs, IntPtr vc, float inval)
        {
            if (null == fpixs
             || IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("fpixs, vc cannot be null");
            }

            var pointer = Native.DllImports.fpixProjective((HandleRef)fpixs, vc, inval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static int linearInterpolatePixelFloat(IntPtr datas, int w, int h, float x, float y, float inval, out float pval)
        {
            if (IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("datas cannot be null");
            }

            return Native.DllImports.linearInterpolatePixelFloat(datas, w, h, x, y, inval, out pval);
        }

        // Thresholding to 1 bpp Pix
        public static Pix fpixThresholdToPix(this FPix fpix, float thresh)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            var pointer = Native.DllImports.fpixThresholdToPix((HandleRef)fpix, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generate function from components
        public static FPix pixComponentFunction(this Pix pix, float rnum, float gnum, float bnum, float rdenom, float gdenom, float bdenom)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix, cannot be null");
            }

            var pointer = Native.DllImports.pixComponentFunction((HandleRef)pix, rnum, gnum, bnum, rdenom, gdenom, bdenom);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

    }
}
