using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Binarize
    {
        // Adaptive Otsu-based thresholding
        public static int pixOtsuAdaptiveThreshold(this Pix pixs, int sx, int sy, int smoothx, int smoothy, float scorefract, out Pix ppixth, out Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixminPtr, ppixmaxPtr;
            var success = Native.DllImports.pixOtsuAdaptiveThreshold((HandleRef)pixs, sx, sy, smoothx, smoothy, scorefract, out ppixminPtr, out ppixmaxPtr);
            if (IntPtr.Zero == ppixminPtr
             || IntPtr.Zero == ppixmaxPtr)
            {
                ppixth = null;
                ppixd = null;
            }
            else
            {
                ppixth = new Pix(ppixminPtr);
                ppixd = new Pix(ppixmaxPtr);
            }
            return success;
        }

        // Otsu thresholding on adaptive background normalization
        public static Pix pixOtsuThreshOnBackgroundNorm(this Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, float scorefract, out int pthresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixOtsuThreshOnBackgroundNorm((HandleRef)pixs, (HandleRef)pixim, sx, sy, thresh, mincount, bgval, smoothx, smoothy, scorefract, out pthresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Masking and Otsu estimate on adaptive background normalization
        public static Pix pixMaskedThreshOnBackgroundNorm(this Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, int smoothx, int smoothy, float scorefract, out int pthresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMaskedThreshOnBackgroundNorm((HandleRef)pixs, (HandleRef)pixim, sx, sy, thresh, mincount, smoothx, smoothy, scorefract, out pthresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Sauvola local thresholding
        public static int pixSauvolaBinarizeTiled(this Pix pixs, int whsize, float factor, int nx, int ny, out Pix ppixth, out Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixminPtr, ppixmaxPtr;
            var success = Native.DllImports.pixSauvolaBinarizeTiled((HandleRef)pixs, whsize, factor, nx, ny, out ppixminPtr, out ppixmaxPtr);
            if (IntPtr.Zero == ppixminPtr
             || IntPtr.Zero == ppixmaxPtr)
            {
                ppixth = null;
                ppixd = null;
            }
            else
            {
                ppixth = new Pix(ppixminPtr);
                ppixd = new Pix(ppixmaxPtr);
            }
            return success;
        }

        public static int pixSauvolaBinarize(this Pix pixs, int whsize, float factor, int addborder, out Pix ppixm, out Pix ppixsd, out Pix ppixth, out Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixmPtr, ppixsdPtr, ppixthPtr, ppixdPtr;
            var success = Native.DllImports.pixSauvolaBinarize((HandleRef)pixs, whsize, factor, addborder, out ppixmPtr, out ppixsdPtr, out ppixthPtr, out ppixdPtr);
            if (IntPtr.Zero == ppixmPtr
             || IntPtr.Zero == ppixsdPtr
             || IntPtr.Zero == ppixthPtr
             || IntPtr.Zero == ppixdPtr)
            {
                ppixm = null;
                ppixsd = null;
                ppixth = null;
                ppixd = null;
            }
            else
            {
                ppixm = new Pix(ppixmPtr);
                ppixsd = new Pix(ppixsdPtr);
                ppixth = new Pix(ppixthPtr);
                ppixd = new Pix(ppixdPtr);
            }
            return success;
        }

        public static Pix pixSauvolaGetThreshold(this Pix pixm, Pix pixms, float factor, out Pix ppixsd)
        {
            if (null == pixm
             || null == pixms)
            {
                throw new ArgumentNullException("pixs, pixms cannot be null.");
            }

            IntPtr ppixsdPtr;
            var pointer = Native.DllImports.pixSauvolaGetThreshold((HandleRef)pixm, (HandleRef)pixms, factor, out ppixsdPtr);
            if (IntPtr.Zero == ppixsdPtr)
            {
                ppixsd = null;
            }
            else
            {
                ppixsd = new Pix(ppixsdPtr);
            }
            return new Pix(pointer);
        }

        public static Pix pixApplyLocalThreshold(this Pix pixs, Pix pixth, int redfactor)
        {
            if (null == pixs
             || null == pixth)
            {
                throw new ArgumentNullException("pixs, pixth cannot be null.");
            }

            var pointer = Native.DllImports.pixApplyLocalThreshold((HandleRef)pixs, (HandleRef)pixth, redfactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Thresholding using connected components
        public static int pixThresholdByConnComp(this Pix pixs, Pix pixm, int start, int end, int incr, float thresh48, float threshdiff, out int pglobthresh, out Pix ppixd, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixdPtr;
            var result = Native.DllImports.pixThresholdByConnComp((HandleRef)pixs, (HandleRef)pixm, start, end, incr, thresh48, threshdiff, out pglobthresh, out ppixdPtr, debugflag);
            if (IntPtr.Zero == ppixdPtr)
            {
                ppixd = null;
            }
            else
            {
                ppixd = new Pix(ppixdPtr);
            }

            return result;
        }
    }
}
