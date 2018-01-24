using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PageSeg
    {
        // Top level page segmentation
        public static int pixGetRegionsBinary(this Pix pixs, out Pix ppixhm, out Pix ppixtm, out Pix ppixtb, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixhmPtr, ppixtmPtr, ppixtbPtr;
            var result = Native.DllImports.pixGetRegionsBinary((HandleRef)pixs, out ppixhmPtr, out ppixtmPtr, out ppixtbPtr, (HandleRef)pixadb);
            ppixhm = new Pix(ppixhmPtr);
            ppixtm = new Pix(ppixtmPtr);
            ppixtb = new Pix(ppixtbPtr);

            return result;
        }


        // Halftone region extraction
        [Obsolete("pixGenHalftoneMask depricated")]
        public static Pix pixGenHalftoneMask(this Pix pixs, out Pix ppixtext, out int phtfound, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixtextPtr;
            var pointer = Native.DllImports.pixGenHalftoneMask((HandleRef)pixs, out ppixtextPtr, out phtfound, debug);
            ppixtext = new Pix(ppixtextPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixGenerateHalftoneMask(this Pix pixs, out Pix ppixtext, out int phtfound, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixtextPtr;
            var pointer = Native.DllImports.pixGenerateHalftoneMask((HandleRef)pixs, out ppixtextPtr, out phtfound, (HandleRef)pixadb);
            ppixtext = new Pix(ppixtextPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Textline extraction
        public static Pix pixGenTextlineMask(this Pix pixs, out Pix ppixvws, out int ptlfound, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixvwsPtr;
            var pointer = Native.DllImports.pixGenTextlineMask((HandleRef)pixs, out ppixvwsPtr, out ptlfound, (HandleRef)pixadb);
            ppixvws = new Pix(ppixvwsPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Textblock extraction
        public static Pix pixGenTextblockMask(this Pix pixs, Pix pixvws, Pixa pixadb)
        {
            if (null == pixs
             || null == pixvws
             || null == pixadb)
            {
                throw new ArgumentNullException("pixs, pixadb, pixvws cannot be null.");
            }

            var pointer = Native.DllImports.pixGenTextblockMask((HandleRef)pixs, (HandleRef)pixvws, (HandleRef)pixadb);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Location of page foreground
        public static Pix pixFindPageForeground(this Pix pixs, int threshold, int mindist, int erasedist, int pagenum, int showmorph, int display, string pdfdir)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFindPageForeground((HandleRef)pixs, threshold, mindist, erasedist, pagenum, showmorph, display, pdfdir);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Extraction of characters from image with only text
        public static int pixSplitIntoCharacters(this Pix pixs, int minw, int minh, out Boxa pboxa, out Pixa ppixa, out Pix ppixdebug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr, ppixaPtr, ppixdebugPtr;
            var result = Native.DllImports.pixSplitIntoCharacters((HandleRef)pixs, minw, minh, out pboxaPtr, out ppixaPtr, out ppixdebugPtr);
            pboxa = new Boxa(pboxaPtr);
            ppixa = new Pixa(ppixaPtr);
            ppixdebug = new Pix(ppixdebugPtr);

            return result;
        }

        public static Boxa pixSplitComponentWithProfile(this Pix pixs, int delta, int mindel, out Pix ppixdebug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixdebugPtr;
            var pointer = Native.DllImports.pixSplitComponentWithProfile((HandleRef)pixs, delta, mindel, out ppixdebugPtr);
            ppixdebug = new Pix(ppixdebugPtr);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }


        // Extraction of lines of text
        public static Pixa pixExtractTextlines(this Pix pixs, int maxw, int maxh, int minw, int minh, int adjw, int adjh, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExtractTextlines((HandleRef)pixs, maxw, maxh, minw, minh, adjw, adjh, (HandleRef)pixadb);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixExtractRawTextlines(this Pix pixs, int maxw, int maxh, int adjw, int adjh, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExtractRawTextlines((HandleRef)pixs, maxw, maxh, adjw, adjh, (HandleRef)pixadb);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }


        // How many text columns
        public static int pixCountTextColumns(this Pix pixs, float deltafract, float peakfract, float clipfract, out int pncols, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixCountTextColumns((HandleRef)pixs, deltafract, peakfract, clipfract, out pncols, (HandleRef)pixadb);
        }


        // Decision: text vs photo
        public static int pixDecideIfText(this Pix pixs, Box box, out int pistext, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixDecideIfText((HandleRef)pixs, (HandleRef)box, out pistext, (HandleRef)pixadb);
        }

        public static int pixFindThreshFgExtent(this Pix pixs, int thresh, out int ptop, out int pbot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixFindThreshFgExtent((HandleRef)pixs, thresh, out ptop, out pbot);
        }


        // Decision: table vs text
        public static int pixDecideIfTable(this Pix pixs, Box box, out int pistable, Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixDecideIfTable((HandleRef)pixs, (HandleRef)box, out pistable, (HandleRef)pixadb);
        }

        public static Pix pixPrepare1bpp(this Pix pixs, Box box, float cropfract, int outres)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixPrepare1bpp((HandleRef)pixs, (HandleRef)box, cropfract, outres);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Estimate the grayscale background value
        public static int pixEstimateBackground(this Pix pixs, int darkthresh, float edgecrop, out int pbg)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixEstimateBackground((HandleRef)pixs, darkthresh, edgecrop, out pbg);
        }


        // Largest white or black rectangles in an image
        public static int pixFindLargeRectangles(this Pix pixs, int polarity, int nrect, out Boxa pboxa, out Pix ppixdb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr, ppixdbPtr;
            var result = Native.DllImports.pixFindLargeRectangles((HandleRef)pixs, polarity, nrect, out pboxaPtr, out ppixdbPtr);
            pboxa = new Boxa(pboxaPtr);
            ppixdb = new Pix(ppixdbPtr);

            return result;
        }

        public static int pixFindLargestRectangle(this Pix pixs, int polarity, out Box pbox, out Pix ppixdb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxPtr, ppixdbPtr;
            var result = Native.DllImports.pixFindLargestRectangle((HandleRef)pixs, polarity, out pboxPtr, out ppixdbPtr);
            pbox = new Box(pboxPtr);
            ppixdb = new Pix(ppixdbPtr);

            return result;
        }
    }
}
