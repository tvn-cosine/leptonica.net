using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class ColorQuant2
    {
        // Modified median cut color quantization 
        // High level
        public static Pix pixMedianCutQuant(this Pix pixs, int ditherflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMedianCutQuant((HandleRef)pixs, ditherflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMedianCutQuantGeneral(this Pix pixs, int ditherflag, int outdepth, int maxcolors, int sigbits, int maxsub, int checkbw)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMedianCutQuantGeneral((HandleRef)pixs, ditherflag, outdepth, maxcolors, sigbits, maxsub, checkbw);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMedianCutQuantMixed(this Pix pixs, int ncolor, int ngray, int darkthresh, int lightthresh, int diffthresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMedianCutQuantMixed((HandleRef)pixs, ncolor, ngray, darkthresh, lightthresh, diffthresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFewColorsMedianCutQuantMixed(this Pix pixs, int ncolor, int ngray, int maxncolors, int darkthresh, int lightthresh, int diffthresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFewColorsMedianCutQuantMixed((HandleRef)pixs, ncolor, ngray, maxncolors, darkthresh, lightthresh, diffthresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Median cut indexed histogram
        public static IntPtr pixMedianCutHisto(this Pix pixs, int sigbits, int subsample)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixMedianCutHisto((HandleRef)pixs, sigbits, subsample); 
        }
    }
}
