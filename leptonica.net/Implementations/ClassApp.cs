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

        /// <summary>
        /// pixGetWordsInTextlines()
        /// </summary>
        /// <param name="pixs">pixs 1 bpp, typ. 75 - 150 ppi</param>
        /// <param name="minwidth">minwidth, minheight of saved components; smaller are discarded</param>
        /// <param name="minheight">minwidth, minheight of saved components; smaller are discarded</param>
        /// <param name="maxwidth">maxwidth, maxheight of saved components; larger are discarded</param>
        /// <param name="maxheight">maxwidth, maxheight of saved components; larger are discarded</param>
        /// <param name="pboxad">pboxad word boxes sorted in textline line order</param>
        /// <param name="ppixad">ppixad word images sorted in textline line order</param>
        /// <param name="pnai">pnai index of textline for each word</param>
        /// <returns>0 if OK, 1 on error</returns>
        /// <![CDATA[
        /// Notes:
        ///(1) The input should be at a resolution of between 75 and 150 ppi.
        ///(2) The four size constraints on saved components are all
        ///    scaled by %reduction.
        ///(3) The result are word images (and their b.b.), extracted in
        ///    textline order, at either full res or 2x reduction,
        ///    and with a numa giving the textline index for each word.
        ///(4) The pixa and boxa interfaces should make this type of
        ///    application simple to put together.  The steps are:
        ///     ~ generate first estimate of word masks
        ///     ~ get b.b. of these, and remove the small and big ones
        ///     ~ extract pixa of the word images, using the b.b.
        ///     ~ sort actual word images in textline order (2d)
        ///     ~ flatten them to a pixa (1d), saving the textline index
        ///       for each pix
        ///(5) In an actual application, it may be desirable to pre-filter
        ///    the input image to remove large components, to extract
        ///    single columns of text, and to deskew them.  For example,
        ///    to remove both large components and small noisy components
        ///    that can interfere with the statistics used to estimate
        ///    parameters for segmenting by words, but still retain text lines,
        ///    the following image preprocessing can be done:
        ///          Pix *pixt = pixMorphSequence(pixs, "c40.1", 0);
        ///          Pix *pixf = pixSelectBySize(pixt, 0, 60, 8,
        ///                               L_SELECT_HEIGHT, L_SELECT_IF_LT, NULL);
        ///          pixAnd(pixf, pixf, pixs);  // the filtered image
        ///    The closing turns text lines into long blobs, but does not
        ///    significantly increase their height.  But if there are many
        ///    small connected components in a dense texture, this is likely
        ///    to generate tall components that will be eliminated in pixf.
        /// ]]>

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

        /// <summary>
        /// pixGetWordBoxesInTextlines()
        /// </summary>
        /// <param name="pixs">pixs 1 bpp, typ. 75 - 150 ppi</param>
        /// <param name="minwidth">minwidth, minheight of saved components; smaller are discarded</param>
        /// <param name="minheight">minwidth, minheight of saved components; smaller are discarded</param>
        /// <param name="maxwidth">maxwidth, maxheight of saved components; larger are discarded</param>
        /// <param name="maxheight">maxwidth, maxheight of saved components; larger are discarded</param>
        /// <param name="pboxad">pboxad word boxes sorted in textline line order</param>
        /// <param name="pnai">pnai [optional] index of textline for each word</param>
        /// <returns>0 if OK, 1 on error</returns>
        /// <![CDATA[
        /// Notes:
        ///(1) The input should be at a resolution of between 75 and 150 ppi.
        ///(2) This is a special version of pixGetWordsInTextlines(), that
        ///    just finds the word boxes in line order, with a numa
        ///    giving the textline index for each word.
        ///    See pixGetWordsInTextlines() for more details.
        /// ]]>
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

        /// <summary>
        /// pixFindWordAndCharacterBoxes()
        /// </summary>
        /// <param name="pixs">2, 4, 8 or 32 bpp; colormap OK; typ. 300 ppi</param>
        /// <param name="boxs">[optional] region to select in pixs</param>
        /// <param name="thresh">binarization threshold (typ. 100 - 150)</param>
        /// <param name="pboxaw">return the word boxes</param>
        /// <param name="pboxaac">return the character boxes</param>
        /// <param name="debugdir">[optional] for debug images; use NULL to skip</param>
        /// <returns>0 if OK, 1 on error</returns>
        /// <![CDATA[
        /// * Notes:
        ///(1) If %boxs == NULL, the entire input image is used.
        ///(2) Having an input pix that is not 1bpp is necessary to reduce
        ///    touching characters by using a low binarization threshold.
        ///    Suggested thresholds are between 100 and 150.
        ///(3) The coordinates in the output boxes are global, with respect
        ///    to the input image.
        /// ]]>
        public static int pixFindWordAndCharacterBoxes(this Pix pixs, Box boxs, int thresh, out Boxa pboxaw, out Boxaa pboxaac, string debugdir)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxawPtr, pboxaacPtr;
            var result = Native.DllImports.pixFindWordAndCharacterBoxes((HandleRef)pixs, (HandleRef)boxs, thresh, out pboxawPtr, out pboxaacPtr, debugdir);
            pboxaw = new Boxa(pboxawPtr);
            pboxaac = new Boxaa(pboxaacPtr);

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
