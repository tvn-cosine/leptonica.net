using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class Dewarp3
    {
        // Apply disparity array to pix
        public static int dewarpaApplyDisparity(this L_Dewarpa dewa, int pageno, Pix pixs, int grayin, int x, int y, out Pix ppixd, string debugfile)
        {
            if (null == pixs
             || null == dewa)
            {
                throw new ArgumentNullException("pixs, dewa cannot be null.");
            }

            IntPtr ppixdPtr;
            var success = Native.DllImports.dewarpaApplyDisparity((HandleRef)dewa, pageno, (HandleRef)pixs, grayin, x, y, out ppixdPtr, debugfile);
            if (IntPtr.Zero == ppixdPtr)
            {
                ppixd = null;
            }
            else
            {
                ppixd = new Pix(ppixdPtr);
            }
            return success;
        }

        // Apply disparity array to boxa
        public static int dewarpaApplyDisparityBoxa(this L_Dewarpa dewa, int pageno, Pix pixs, Boxa boxas, int mapdir, int x, int y, out Boxa pboxad, string debugfile)
        {
            if (null == pixs
             || null == dewa
             || null == boxas)
            {
                throw new ArgumentNullException("pixs, dewa, boxas cannot be null.");
            }

            IntPtr pboxadPtr;
            var success = Native.DllImports.dewarpaApplyDisparityBoxa((HandleRef)dewa, pageno, (HandleRef)pixs, (HandleRef)boxas, mapdir, x, y, out pboxadPtr, debugfile);
            if (IntPtr.Zero == pboxadPtr)
            {
                pboxad = null;
            }
            else
            {
                pboxad = new Boxa(pboxadPtr);
            }
            return success;
        }

        // Stripping out data and populating full res disparity
        public static int dewarpMinimize(this L_Dewarp dew)
        {
            if (null == dew)
            {
                throw new ArgumentNullException("dew cannot be null.");
            }

            return Native.DllImports.dewarpMinimize((HandleRef)dew);
        }

        public static int dewarpPopulateFullRes(this L_Dewarp dew, Pix pix, int x, int y)
        {
            if (null == dew)
            {
                throw new ArgumentNullException("dew cannot be null.");
            }

            return Native.DllImports.dewarpPopulateFullRes((HandleRef)dew, (HandleRef)pix, x, y);
        }
    }
}
