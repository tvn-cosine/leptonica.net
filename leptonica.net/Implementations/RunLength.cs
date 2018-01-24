using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static  class RunLength
    {
        // Label pixels by membership in runs 
        public static Pix pixStrokeWidthTransform(this Pix pixs, int color, int depth, int nangles)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRunlengthTransform(this Pix pixs, int color, int direction, int depth)
        {
            throw new NotImplementedException();
        }


        // Find runs along horizontal and vertical lines
        public static int pixFindHorizontalRuns(this Pix pix, int y, IntPtr xstart, IntPtr xend, out int pn)
        {
            throw new NotImplementedException();
        }

        public static int pixFindVerticalRuns(this Pix pix, int x, IntPtr ystart, IntPtr yend, out int pn)
        {
            throw new NotImplementedException();
        }


        // Find max runs along horizontal and vertical lines
        public static Numa pixFindMaxRuns(this Pix pix, int direction, out Numa pnastart)
        {
            throw new NotImplementedException();
        }

        public static int pixFindMaxHorizontalRunOnLine(this Pix pix, int y, IntPtr pxstart, out int psize)
        {
            throw new NotImplementedException();
        }

        public static int pixFindMaxVerticalRunOnLine(this Pix pix, int x, IntPtr pystart, out int psize)
        {
            throw new NotImplementedException();
        }


        // Compute runlength-to-membership transform on a line
        public static int runlengthMembershipOnLine(IntPtr buffer, int size, int depth, IntPtr start, IntPtr end, int n)
        {
            throw new NotImplementedException();
        }


        // Make byte position LUT
        public static IntPtr makeMSBitLocTab(int bitval)
        {
            throw new NotImplementedException();
        } 
    }
}
