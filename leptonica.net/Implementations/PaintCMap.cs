using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PaintCMap
    {      // Repaint selected pixels in region
        public static int pixSetSelectCmap(this Pix pixs, Box box, int sindex, int rval, int gval, int bval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixSetSelectCmap((HandleRef)pixs, (HandleRef)box, sindex, rval, gval, bval);
        }

        // Repaint non-white pixels in region
        public static int pixColorGrayRegionsCmap(this Pix pixs, Boxa boxa, int type, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            return Native.DllImports.pixColorGrayRegionsCmap((HandleRef)pixs, (HandleRef)boxa, type, rval, gval, bval);
        }

        public static int pixColorGrayCmap(this Pix pixs, Box box, int type, int rval, int gval, int bval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixColorGrayCmap((HandleRef)pixs, (HandleRef)box, type, rval, gval, bval);
        }

        public static int pixColorGrayMaskedCmap(this Pix pixs, Pix pixm, int type, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }

            return Native.DllImports.pixColorGrayMaskedCmap((HandleRef)pixs, (HandleRef)pixm, type, rval, gval, bval);
        }

        public static int addColorizedGrayToCmap(this PixColormap cmap, int type, int rval, int gval, int bval, out Numa pna)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pnaPtr;
            var result = Native.DllImports.addColorizedGrayToCmap((HandleRef)cmap, type, rval, gval, bval, out pnaPtr);
            pna = new Numa(pnaPtr);

            return result;
        }

        // Repaint selected pixels through mask
        public static int pixSetSelectMaskedCmap(this Pix pixs, Pix pixm, int x, int y, int sindex, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }

            return Native.DllImports.pixSetSelectMaskedCmap((HandleRef)pixs, (HandleRef)pixm, x, y, sindex, rval, gval, bval);
        }

        // Repaint all pixels through mask
        public static int pixSetMaskedCmap(this Pix pixs, Pix pixm, int x, int y, int rval, int gval, int bval)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }

            return Native.DllImports.pixSetMaskedCmap((HandleRef)pixs, (HandleRef)pixm, x, y, rval, gval, bval);
        }
    }
}
