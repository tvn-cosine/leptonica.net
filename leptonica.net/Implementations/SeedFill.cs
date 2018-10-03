using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class SeedFill
    { 
        // Binary seedfill(source: Luc Vincent)
        public static Pix pixSeedfillBinary(this Pix pixd, Pix pixs, Pix pixm, int connectivity)
        {
            var pointer = Native.DllImports.pixSeedfillBinary((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, connectivity);
            return new Pix(pointer);
        }

        public static Pix pixSeedfillBinaryRestricted(this Pix pixd, Pix pixs, Pix pixm, int connectivity, int xmax, int ymax)
        {
            throw new NotImplementedException();
        }


        // Applications of binary seedfill to find and fill holes, remove c.c.touching the border and fill bg from border:
        public static Pix pixHolesByFilling(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static Pix pixFillClosedBorders(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static Pix pixExtractBorderConnComps(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRemoveBorderConnComps(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static Pix pixFillBgFromBorder(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }


        // Hole-filling of components to bounding rectangle
        public static Pix pixFillHolesToBoundingRect(this Pix pixs, int minsize, float maxhfract, float minfgfract)
        {
            throw new NotImplementedException();
        }


        // Gray seedfill(source: Luc Vincent:fast-hybrid-grayscale-reconstruction)
        public static int pixSeedfillGray(this Pix pixs, Pix pixm, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static int pixSeedfillGrayInv(this Pix pixs, Pix pixm, int connectivity)
        {
            throw new NotImplementedException();
        }


        // Gray seedfill(source: Luc Vincent: sequential-reconstruction algorithm)
        public static int pixSeedfillGraySimple(this Pix pixs, Pix pixm, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static int pixSeedfillGrayInvSimple(this Pix pixs, Pix pixm, int connectivity)
        {
            throw new NotImplementedException();
        }


        // Gray seedfill variations
        public static Pix pixSeedfillGrayBasin(this Pix pixb, Pix pixm, int delta, int connectivity)
        {
            throw new NotImplementedException();
        }


        // Distance function(source: Luc Vincent)
        public static Pix pixDistanceFunction(this Pix pixs, int connectivity, int outdepth, int boundcond)
        {
            throw new NotImplementedException();
        }


        // Seed spread(based on distance function)
        public static Pix pixSeedspread(this Pix pixs, int connectivity)
        {
            throw new NotImplementedException();
        }


        // Local extrema:
        public static int pixLocalExtrema(this Pix pixs, int maxmin, int minmax, out Pix ppixmin, out Pix ppixmax)
        {
            throw new NotImplementedException();
        }

        public static int pixSelectedLocalExtrema(this Pix pixs, int mindist, out Pix ppixmin, out Pix ppixmax)
        {
            throw new NotImplementedException();
        }

        public static Pix pixFindEqualValues(this Pix pixs1, Pix pixs2)
        {
            throw new NotImplementedException();
        }


        // Selection of minima in mask of connected components
        public static int pixSelectMinInConnComp(this Pix pixs, Pix pixm, out Pta ppta, out Numa pnav)
        {
            throw new NotImplementedException();
        }


        // Removal of seeded connected components from a mask
        public static Pix pixRemoveSeededComponents(this Pix pixd, Pix pixs, Pix pixm, int connectivity, int bordersize)
        {
            throw new NotImplementedException();
        }
    }
}
