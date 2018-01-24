using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class QuadTree
    {
        // Top level quadtree linear statistics
        public static int pixQuadtreeMean(this Pix pixs, int nlevels, Pix pix_ma, out FPixa pfpixa)
        {
            throw new NotImplementedException();
        }

        public static int pixQuadtreeVariance(this Pix pixs, int nlevels, Pix pix_ma, DPix dpix_msa, out FPixa pfpixa_v, out FPixa pfpixa_rv)
        {
            throw new NotImplementedException();
        }


        // Statistics in an arbitrary rectangle
        public static int pixMeanInRectangle(this Pix pixs, HandleRef box, Pix pixma, out float pval)
        {
            throw new NotImplementedException();
        }

        public static int pixVarianceInRectangle(this Pix pixs, HandleRef box, Pix pix_ma, DPix dpix_msa, out float pvar, out float prvar)
        {
            throw new NotImplementedException();
        }


        // Quadtree regions
        public static Boxaa boxaaQuadtreeRegions(int w, int h, int nlevels)
        {
            throw new NotImplementedException();
        }


        // Quadtree access
        public static int quadtreeGetParent(this FPixa fpixa, int level, int x, int y, out float pval)
        {
            throw new NotImplementedException();
        }

        public static int quadtreeGetChildren(this FPixa fpixa, int level, int x, int y, out float pval00, out float pval10, out float pval01, out float pval11)
        {
            throw new NotImplementedException();
        }

        public static int quadtreeMaxLevels(int w, int h)
        {
            throw new NotImplementedException();
        }


        // Display quadtree
        public static Pix fpixaDisplayQuadtree(this FPixa fpixa, int factor, int fontsize)
        {
            throw new NotImplementedException();
        } 
    }
}
