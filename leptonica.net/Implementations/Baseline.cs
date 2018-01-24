using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Baseline
    {
        // Locate text baselines in an image
        public static Numa pixFindBaselines(this Pix pixs, out Pta ppta, Pixa pixadb)
        {
            if (null == pixs
             || null == pixadb)
            {
                throw new ArgumentNullException("pixs, pixadb cannot be null.");
            }

            IntPtr pptaPtr;
            var pointer = Native.DllImports.pixFindBaselines((HandleRef)pixs, out pptaPtr, (HandleRef)pixadb);
            if (IntPtr.Zero == pointer)
            {
                ppta = null;
                return null;
            }
            else
            {
                ppta = new Pta(pptaPtr);
                return new Numa(pointer);
            }
        }

        // Projective transform to remove local skew
        public static Pix pixDeskewLocal(this Pix pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixDeskewLocal((HandleRef)pixs, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Determine local skew
        public static int pixGetLocalSkewTransform(this Pix pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, out Pta pptas, out Pta pptad)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pptasPtr, pptadPtr;
            var result = Native.DllImports.pixGetLocalSkewTransform((HandleRef)pixs, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta, out pptasPtr, out pptadPtr);
            if (IntPtr.Zero == pptasPtr
             || IntPtr.Zero == pptadPtr)
            {
                pptas = null;
                pptad = null;
            }
            else
            {
                pptas = new Pta(pptasPtr);
                pptad = new Pta(pptadPtr);
            }

            return result;
        }

        public static Numa pixGetLocalSkewAngles(this Pix pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, out float pa, out float pb, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
             
            var pointer = Native.DllImports.pixGetLocalSkewAngles((HandleRef)pixs, nslices, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta, out pa, out pb, debug);
            if (IntPtr.Zero == pointer)
            { 
                return null;
            }
            else
            { 
                return new Numa(pointer);
            }
        }
    }
}
