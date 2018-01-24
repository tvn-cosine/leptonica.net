using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Dewarp2
    {
        // Build basic page disparity model
        public static int dewarpBuildPageModel(this L_Dewarp dew, string debugfile)
        {
            if (null == dew)
            {
                throw new System.IO.FileNotFoundException("dew cannot be null.");
            }

            return Native.DllImports.dewarpBuildPageModel((HandleRef)dew, debugfile);
        }

        public static int dewarpFindVertDisparity(this L_Dewarp dew, Ptaa ptaa, int rotflag)
        {
            if (null == dew
             || null == ptaa)
            {
                throw new System.IO.FileNotFoundException("dew, ptaa cannot be null.");
            }

            return Native.DllImports.dewarpFindVertDisparity((HandleRef)dew, (HandleRef)ptaa, rotflag);
        }

        public static int dewarpFindHorizDisparity(this L_Dewarp dew, Ptaa ptaa)
        {
            if (null == dew
             || null == ptaa)
            {
                throw new System.IO.FileNotFoundException("dew, ptaa cannot be null.");
            }

            return Native.DllImports.dewarpFindHorizDisparity((HandleRef)dew, (HandleRef)ptaa);
        }

        public static Ptaa dewarpGetTextlineCenters(this Pix pixs, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.dewarpGetTextlineCenters((HandleRef)pixs, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Ptaa(pointer);
            }
        }

        public static Ptaa dewarpRemoveShortLines(this Pix pixs, Ptaa ptaas, float fract, int debugflag)
        {
            if (null == pixs
             || null == ptaas)
            {
                throw new ArgumentNullException("pixs, ptaas cannot be null.");
            }

            var pointer = Native.DllImports.dewarpRemoveShortLines((HandleRef)pixs, (HandleRef)ptaas, fract, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Ptaa(pointer);
            }
        }

        // Build disparity model for slope near binding
        public static int dewarpFindHorizSlopeDisparity(this L_Dewarp dew, Pix pixb, float fractthresh, int parity)
        {
            if (null == dew
             || null == pixb)
            {
                throw new System.IO.FileNotFoundException("dew, pixb cannot be null.");
            }

            return Native.DllImports.dewarpFindHorizSlopeDisparity((HandleRef)dew, (HandleRef)pixb, fractthresh, parity);
        }

        // Build the line disparity model
        public static int dewarpBuildLineModel(this L_Dewarp dew, int opensize, string debugfile)
        {
            if (null == dew)
            {
                throw new System.IO.FileNotFoundException("dew cannot be null.");
            }

            return Native.DllImports.dewarpBuildLineModel((HandleRef)dew, opensize, debugfile);
        }

        // Query model status
        public static int dewarpaModelStatus(this L_Dewarpa dewa, int pageno, out int pvsuccess, out int phsuccess)
        {
            if (null == dewa)
            {
                throw new System.IO.FileNotFoundException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaModelStatus((HandleRef)dewa, pageno, out pvsuccess, out phsuccess);
        }
    }
}
