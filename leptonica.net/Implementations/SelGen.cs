using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class SelGen
    {
        // Generate a subsampled structuring element
        public static Sel pixGenerateSelWithRuns(this Pix pixs, int nhlines, int nvlines, int distance, int minlength, int toppix, int botpix, int leftpix, int rightpix, out Pix ppixe)
        {
            throw new NotImplementedException();
        }

        public static Sel pixGenerateSelRandom(this Pix pixs, float hitfract, float missfract, int distance, int toppix, int botpix, int leftpix, int rightpix, out Pix ppixe)
        {
            throw new NotImplementedException();
        }

        public static Sel pixGenerateSelBoundary(this Pix pixs, int hitdist, int missdist, int hitskip, int missskip, int topflag, int botflag, int leftflag, int rightflag, out Pix ppixe)
        {
            throw new NotImplementedException();
        }


        // Accumulate data on runs along lines
        public static Numa pixGetRunCentersOnLine(this Pix pixs, int x, int y, int minlength)
        {
            throw new NotImplementedException();
        }

        public static Numa pixGetRunsOnLine(this Pix pixs, int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }


        // Subsample boundary pixels in relatively ordered way
        public static Pta pixSubsampleBoundaryPixels(this Pix pixs, int skip)
        {
            throw new NotImplementedException();
        }

        public static int adjacentOnPixelInRaster(this Pix pixs, int x, int y, out int pxa, out int pya)
        {
            throw new NotImplementedException();
        }


        // Display generated sel with originating image
        public static Pix pixDisplayHitMissSel(this Pix pixs, Sel sel, int scalefactor, uint hitcolor, uint misscolor)
        {
            throw new NotImplementedException();
        }
    }
}
