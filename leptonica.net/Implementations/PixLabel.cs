using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixLabel
    {
        // Label pixels by an index for connected component membership
        public static Pix pixConnCompTransform(this Pix pixs, int connect, int depth)
        {
            throw new NotImplementedException();
        }

        // Label pixels by the area of their connected component
        public static Pix pixConnCompAreaTransform(this Pix pixs, int connect)
        {
            throw new NotImplementedException();
        }

        // Label pixels to allow incremental computation of connected components
        public static int pixConnCompIncrInit(this Pix pixs, int conn, out Pix ppixd, out Ptaa pptaa, out int pncc)
        {
            throw new NotImplementedException();
        }

        public static int pixConnCompIncrAdd(this Pix pixs, out Ptaa ptaa, out int pncc, float x, float y, int debug)
        {
            throw new NotImplementedException();
        }

        public static int pixGetSortedNeighborValues(this Pix pixs, int x, int y, int conn, out IntPtr pneigh, out int pnvals)
        {
            throw new NotImplementedException();
        }

        // Label pixels with spatially-dependent color coding
        public static Pix pixLocToColorTransform(this Pix pixs)
        {
            throw new NotImplementedException();
        }
    }
}
