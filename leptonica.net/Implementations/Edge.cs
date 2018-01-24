using System;
using System.Runtime.InteropServices;

namespace Leptonica.Implementations
{
    public static class Edge
    {
        // Sobel edge detecting filter
        public static Pix pixSobelEdgeFilter(this Pix pixs, int orientflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSobelEdgeFilter((HandleRef)pixs, orientflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Two-sided edge gradient filter
        public static Pix pixTwoSidedEdgeFilter(this Pix pixs, int orientflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixTwoSidedEdgeFilter((HandleRef)pixs, orientflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Measurement of edge smoothness
        public static int pixMeasureEdgeSmoothness(this Pix pixs, int side, int minjump, int minreversal, out float pjpl, out float pjspl, out float prpl, string debugfile)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixMeasureEdgeSmoothness((HandleRef)pixs, side, minjump, minreversal, out pjpl, out pjspl, out prpl, debugfile);
        }

        public static Numa pixGetEdgeProfile(this Pix pixs, int side, string debugfile)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetEdgeProfile((HandleRef)pixs, side, debugfile);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int pixGetLastOffPixelInRun(this Pix pixs, int x, int y, int direction, out int ploc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetLastOffPixelInRun((HandleRef)pixs, x, y, direction, out ploc);
        }

        public static int pixGetLastOnPixelInRun(this Pix pixs, int x, int y, int direction, out int ploc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetLastOnPixelInRun((HandleRef)pixs, x, y, direction, out ploc);
        }
    }
}
