using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ColorSeg
    {
        // Unsupervised color segmentation 
        public static Pix pixColorSegment(this Pix pixs, int maxdist, int maxcolors, int selsize, int finalcolors, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorSegment((HandleRef)pixs, maxdist, maxcolors, selsize, finalcolors, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixColorSegmentCluster(this Pix pixs, int maxdist, int maxcolors, int debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorSegmentCluster((HandleRef)pixs, maxdist, maxcolors, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixAssignToNearestColor(this Pix pixd, Pix pixs, Pix pixm, int level, IntPtr countarray)
        {
            if (null == pixs
             || null == pixd)
            {
                throw new ArgumentNullException("pixs, pixd cannot be null.");
            }

            return Native.DllImports.pixAssignToNearestColor((HandleRef)pixd, (HandleRef)pixs, (HandleRef)pixm, level, countarray);
        }

        public static int pixColorSegmentClean(this Pix pixs, int selsize, IntPtr countarray)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixColorSegmentClean((HandleRef)pixs, selsize, countarray);
        }

        public static int pixColorSegmentRemoveColors(this Pix pixd, Pix pixs, int finalcolors)
        {
            if (null == pixs
             || null == pixd)
            {
                throw new ArgumentNullException("pixs, pixd cannot be null.");
            }

            return Native.DllImports.pixColorSegmentRemoveColors((HandleRef)pixd, (HandleRef)pixs, finalcolors);
        }
    }
}
