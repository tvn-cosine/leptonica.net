using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Convolve
    {
        // Top level grayscale or color block convolution
        public static Pix pixBlockconv(this Pix pix, int wc, int hc)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconv((HandleRef)pix, wc, hc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Grayscale block convolution
        public static Pix pixBlockconvGray(this Pix pixs, Pix pixacc, int wc, int hc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconvGray((HandleRef)pixs, (HandleRef)pixacc, wc, hc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Accumulator for 1, 8 and 32 bpp convolution
        public static Pix pixBlockconvAccum(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconvAccum((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Un-normalized grayscale block convolution
        public static Pix pixBlockconvGrayUnnormalized(this Pix pixs, int wc, int hc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconvGrayUnnormalized((HandleRef)pixs, wc, hc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Tiled grayscale or color block convolution
        public static Pix pixBlockconvTiled(this Pix pix, int wc, int hc, int nx, int ny)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconvTiled((HandleRef)pix, wc, hc, nx, ny);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlockconvGrayTile(this Pix pixs, Pix pixacc, int wc, int hc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockconvGrayTile((HandleRef)pixs, (HandleRef)pixacc, wc, hc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Convolution for mean, mean square, variance and rms deviation in specified window
        public static int pixWindowedStats(this Pix pixs, int wc, int hc, int hasborder, out Pix ppixm, out Pix ppixms, out FPix pfpixv, out FPix pfpixrv)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixmPtr, ppixmsPtr, pfpixvPtr, pfpixrvPtr;
            var result = Native.DllImports.pixWindowedStats((HandleRef)pixs, wc, hc, hasborder, out ppixmPtr, out ppixmsPtr, out pfpixvPtr, out pfpixrvPtr);
            ppixm = new Pix(ppixmPtr);
            ppixms = new Pix(ppixmsPtr);
            pfpixv = new FPix(pfpixvPtr);
            pfpixrv = new FPix(pfpixrvPtr);

            return result;
        }

        public static Pix pixWindowedMean(this Pix pixs, int wc, int hc, int hasborder, int normflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixWindowedMean((HandleRef)pixs, wc, hc, hasborder, normflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixWindowedMeanSquare(this Pix pixs, int wc, int hc, int hasborder)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixWindowedMeanSquare((HandleRef)pixs, wc, hc, hasborder);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixWindowedVariance(this Pix pixm, Pix pixms, out FPix pfpixv, out FPix pfpixrv)
        {
            if (null == pixms
             || null == pixm)
            {
                throw new ArgumentNullException("pixms cannot be null.");
            }

            IntPtr pfpixvPtr, pfpixrvPtr;
            var result = Native.DllImports.pixWindowedVariance((HandleRef)pixm, (HandleRef)pixms, out pfpixvPtr, out pfpixrvPtr);
            pfpixv = new FPix(pfpixvPtr);
            pfpixrv = new FPix(pfpixrvPtr);

            return result;
        }

        public static DPix pixMeanSquareAccum(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMeanSquareAccum((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        // Binary block sum and rank filter
        public static Pix pixBlockrank(this Pix pixs, Pix pixacc, int wc, int hc, float rank)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockrank((HandleRef)pixs, (HandleRef)pixacc, wc, hc, rank);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlocksum(this Pix pixs, Pix pixacc, int wc, int hc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlocksum((HandleRef)pixs, (HandleRef)pixacc, wc, hc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Census transform
        public static Pix pixCensusTransform(this Pix pixs, int halfsize, Pix pixacc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixCensusTransform((HandleRef)pixs, halfsize, (HandleRef)pixacc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generic convolution(with Pix)
        public static Pix pixConvolve(this Pix pixs, L_Kernel kel, int outdepth, int normflag)
        {
            if (null == pixs
             || null == kel)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixConvolve((HandleRef)pixs, (HandleRef)kel, outdepth, normflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvolveSep(this Pix pixs, L_Kernel kelx, L_Kernel kely, int outdepth, int normflag)
        {
            if (null == pixs
             || null == kelx
             || null == kely)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixConvolveSep((HandleRef)pixs, (HandleRef)kelx, (HandleRef)kely, outdepth, normflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvolveRGB(this Pix pixs, L_Kernel kel)
        {
            if (null == pixs
             || null == kel)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixConvolveRGB((HandleRef)pixs, (HandleRef)kel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvolveRGBSep(this Pix pixs, L_Kernel kelx, L_Kernel kely)
        {
            if (null == pixs
             || null == kelx
             || null == kely)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixConvolveRGBSep((HandleRef)pixs, (HandleRef)kelx, (HandleRef)kely);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Generic convolution(with float arrays)
        public static FPix fpixConvolve(this FPix fpixs, L_Kernel kel, int normflag)
        {
            if (null == fpixs
             || null == kel)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.fpixConvolve((HandleRef)fpixs, (HandleRef)kel, normflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixConvolveSep(this FPix fpixs, L_Kernel kelx, L_Kernel kely, int normflag)
        {
            if (null == fpixs
             || null == kelx
             || null == kely)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.fpixConvolveSep((HandleRef)fpixs, (HandleRef)kelx, (HandleRef)kely, normflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        // Convolution with bias(for non-negative output)
        public static Pix pixConvolveWithBias(this Pix pixs, L_Kernel kel1, L_Kernel kel2, int force8, out int pbias)
        {
            if (null == pixs
             || null == kel1
             || null == kel2)
            {
                throw new ArgumentNullException("pixs, kel cannot be null.");
            }

            var pointer = Native.DllImports.pixConvolveWithBias((HandleRef)pixs, (HandleRef)kel1, (HandleRef)kel2, force8, out pbias);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Set parameter for convolution subsampling
        public static void l_setConvolveSampling(int xfact, int yfact)
        {
            Native.DllImports.l_setConvolveSampling(xfact, yfact);
        }

        //  Additive gaussian noise
        public static Pix pixAddGaussianNoise(this Pix pixs, float stdev)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixAddGaussianNoise((HandleRef)pixs, stdev);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static float gaussDistribSampling()
        {
            return Native.DllImports.gaussDistribSampling();
        }
    }
}
