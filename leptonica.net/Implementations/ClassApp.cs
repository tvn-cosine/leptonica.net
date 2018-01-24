using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class ClassApp
    {
        // Top-level jb2 correlation and rank-hausdorff 
        public static int jbCorrelation(string dirin, float thresh, float weight, int components, string rootname, int firstpage, int npages, int renderflag)
        {
            if (string.IsNullOrWhiteSpace(dirin))
            {
                throw new ArgumentNullException("dirin cannot be null.");
            }
            if (!System.IO.Directory.Exists(dirin))
            {
                throw new System.IO.DirectoryNotFoundException("dirin does not exist");
            }

            return Native.DllImports.jbCorrelation(dirin, thresh, weight, components, rootname, firstpage, npages, renderflag);
        }

        public static int jbRankHaus(string dirin, int size, float rank, int components, string rootname, int firstpage, int npages, int renderflag)
        {
            if (string.IsNullOrWhiteSpace(dirin)
             || string.IsNullOrWhiteSpace(rootname))
            {
                throw new ArgumentNullException("dirin, rootname cannot be null.");
            }
            if (!System.IO.Directory.Exists(dirin))
            {
                throw new System.IO.DirectoryNotFoundException("dirin does not exist");
            }

            return Native.DllImports.jbRankHaus(dirin, size, rank, components, rootname, firstpage, npages, renderflag);
        }

        // Extract and classify words in textline order 
        public static JbClasser jbWordsInTextlines(string dirin, int reduction, int maxwidth, int maxheight, float thresh, float weight, out Numa pnatl, int firstpage, int npages)
        {
            if (string.IsNullOrWhiteSpace(dirin))
            {
                throw new ArgumentNullException("dirin cannot be null.");
            }
            if (!System.IO.Directory.Exists(dirin))
            {
                throw new System.IO.DirectoryNotFoundException("dirin does not exist");
            }

            IntPtr pnatlPtr;
            var pointer = Native.DllImports.jbWordsInTextlines(dirin, reduction, maxwidth, maxheight, thresh, weight, out pnatlPtr, firstpage, npages);
            pnatl = new Numa(pnatlPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbClasser(pointer);
            }
        }

        public static int pixGetWordsInTextlines(this Pix pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, out Boxa pboxad, out Pixa ppixad, out Numa pnai)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxadPtr, ppixadPtr, pnaiPtr;
            var result = Native.DllImports.pixGetWordsInTextlines((HandleRef)pixs, reduction, minwidth, minheight, maxwidth, maxheight, out pboxadPtr, out ppixadPtr, out pnaiPtr);
            pboxad = new Boxa(pboxadPtr);
            ppixad = new Pixa(ppixadPtr);
            pnai = new Numa(pnaiPtr);

            return result;
        }

        public static int pixGetWordBoxesInTextlines(this Pix pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, out Boxa pboxad, out Numa pnai)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxadPtr, pnaiPtr;
            var result = Native.DllImports.pixGetWordBoxesInTextlines((HandleRef)pixs, reduction, minwidth, minheight, maxwidth, maxheight, out pboxadPtr, out pnaiPtr);
            pboxad = new Boxa(pboxadPtr);
            pnai = new Numa(pnaiPtr);

            return result;
        }

        // Use word bounding boxes to compare page images 
        public static Numaa boxaExtractSortedPattern(this Boxa boxa, Numa na)
        {
            if (null == boxa
             || null == na)
            {
                throw new ArgumentNullException("boxa, na cannot be null.");
            }

            var pointer = Native.DllImports.boxaExtractSortedPattern((HandleRef)boxa, (HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static int numaaCompareImagesByBoxes(this Numaa naa1, Numaa naa2, int nperline, int nreq, int maxshiftx, int maxshifty, int delx, int dely, out int psame, int debugflag)
        {
            if (null == naa1
             || null == naa2)
            {
                throw new ArgumentNullException("naa1, naa2 cannot be null.");
            }

            return Native.DllImports.numaaCompareImagesByBoxes((HandleRef)naa1, (HandleRef)naa2, nperline, nreq, maxshiftx, maxshifty, delx, dely, out psame, debugflag);
        }
    }
}
