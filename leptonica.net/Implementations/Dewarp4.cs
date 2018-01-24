using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class Dewarp4
    {
        // Top-level single page dewarper
        public static int dewarpSinglePage(this Pix pixs, int thresh, int adaptive, int useboth, int check_columns, out Pix ppixd, out L_Dewarpa pdewa, int debug)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixdPtr, pdewaPtr;
            var success = Native.DllImports.dewarpSinglePage((HandleRef)pixs, thresh, adaptive, useboth, check_columns, out ppixdPtr, out pdewaPtr, debug);
            ppixd = new Pix(ppixdPtr);
            pdewa = new L_Dewarpa(pdewaPtr);

            return success;
        }

        public static int dewarpSinglePageInit(this Pix pixs, int thresh, int adaptive, int useboth, int check_columns, out Pix ppixb, out L_Dewarpa pdewa)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr ppixbPtr, pdewaPtr;
            var success = Native.DllImports.dewarpSinglePageInit((HandleRef)pixs, thresh, adaptive, useboth, check_columns, out ppixbPtr, out pdewaPtr);
            ppixb = new Pix(ppixbPtr);
            pdewa = new L_Dewarpa(pdewaPtr);

            return success;
        }

        public static int dewarpSinglePageRun(this Pix pixs, Pix pixb, L_Dewarpa dewa, out Pix ppixd, int debug)
        {
            if (null == pixs
             || null == pixb
             || null == dewa)
            {
                throw new ArgumentNullException("pixs, pixb,  cannot be null.");
            }

            IntPtr ppixdPtr;
            var success = Native.DllImports.dewarpSinglePageRun((HandleRef)pixs, (HandleRef)pixb, (HandleRef)dewa, out ppixdPtr, debug);
            ppixd = new Pix(ppixdPtr);

            return success;
        }

        // Operations on dewarpa
        public static int dewarpaListPages(this L_Dewarpa dewa)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaListPages((HandleRef)dewa);
        }

        public static int dewarpaSetValidModels(this L_Dewarpa dewa, int notests, int debug)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaSetValidModels((HandleRef)dewa, notests, debug);
        }

        public static int dewarpaInsertRefModels(this L_Dewarpa dewa, int notests, int debug)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaInsertRefModels((HandleRef)dewa, notests, debug);
        }

        public static int dewarpaStripRefModels(this L_Dewarpa dewa)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaStripRefModels((HandleRef)dewa);
        }

        public static int dewarpaRestoreModels(this L_Dewarpa dewa)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaRestoreModels((HandleRef)dewa);
        }

        // Dewarp debugging output
        public static int dewarpaInfo(IntPtr fp, L_Dewarpa dewa)
        {
            if (null == dewa
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp, dewa cannot be null.");
            }

            return Native.DllImports.dewarpaInfo(fp, (HandleRef)dewa);
        }

        public static int dewarpaModelStats(this L_Dewarpa dewa, out int pnnone, out int pnvsuccess, out int pnvvalid, out int pnhsuccess, out int pnhvalid, out int pnref)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("fp, dewa cannot be null.");
            }

            return Native.DllImports.dewarpaModelStats((HandleRef)dewa, out pnnone, out pnvsuccess, out pnvvalid, out pnhsuccess, out pnhvalid, out pnref);
        }

        public static int dewarpaShowArrays(this L_Dewarpa dewa, float scalefact, int first, int last)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaShowArrays((HandleRef)dewa, scalefact, first, last);
        }

        public static int dewarpDebug(this L_Dewarp dew, string subdirs, int index)
        {
            if (null == dew
             || string.IsNullOrWhiteSpace(subdirs))
            {
                throw new ArgumentNullException("dewa, subdirs cannot be null.");
            }

            return Native.DllImports.dewarpDebug((HandleRef)dew, subdirs, index);
        }

        public static int dewarpShowResults(this L_Dewarpa dewa, Sarray sa, Boxa boxa, int firstpage, int lastpage, string pdfout)
        {
            if (null == dewa
             || null == sa)
            {
                throw new ArgumentNullException("dewa, sa cannot be null.");
            }

            return Native.DllImports.dewarpShowResults((HandleRef)dewa, (HandleRef)sa, (HandleRef)boxa, firstpage, lastpage, pdfout);
        }
    }
}
