using System;
using System.Runtime.InteropServices;

namespace Leptonica.Implementations
{
    public static class FlipDetect
    {
        // Page orientation detection(pure rotation by 90 degree increments):
        public static int pixOrientDetect(this Pix pixs, out float pupconf, out float pleftconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixOrientDetect((HandleRef)pixs, out pupconf, out pleftconf, mincount, debug);
        }

        public static int makeOrientDecision(float upconf, float leftconf, float minupconf, float minratio, out int porient, int debug)
        {
            return Native.DllImports.makeOrientDecision(upconf, leftconf, minupconf, minratio, out porient, debug);
        }

        public static int pixUpDownDetect(this Pix pixs, out float pconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixUpDownDetect((HandleRef)pixs, out pconf, mincount, debug);
        }

        public static int pixUpDownDetectGeneral(this Pix pixs, out float pconf, int mincount, int npixels, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixUpDownDetectGeneral((HandleRef)pixs, out pconf, mincount, npixels, debug);
        }

        public static int pixOrientDetectDwa(this Pix pixs, out float pupconf, out float pleftconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixOrientDetectDwa((HandleRef)pixs, out pupconf, out pleftconf, mincount, debug);
        }

        public static int pixUpDownDetectDwa(this Pix pixs, out float pconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixUpDownDetectDwa((HandleRef)pixs, out pconf, mincount, debug);
        }

        public static int pixUpDownDetectGeneralDwa(this Pix pixs, out float pconf, int mincount, int npixels, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixUpDownDetectGeneralDwa((HandleRef)pixs, out pconf, mincount, npixels, debug);
        }

        // Page mirror detection(flip 180 degrees about line in plane of image):
        public static int pixMirrorDetect(this Pix pixs, out float pconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixMirrorDetect((HandleRef)pixs, out pconf, mincount, debug);
        }

        public static int pixMirrorDetectDwa(this Pix pixs, out float pconf, int mincount, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixMirrorDetectDwa((HandleRef)pixs, out pconf, mincount, debug);
        }
    }
}
