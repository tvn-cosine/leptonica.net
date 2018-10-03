using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class JbClass
    {
        // Initialization
        public static JbClasser jbRankHausInit(int components, int maxwidth, int maxheight, int size, float rank)
        {
            var pointer = Native.DllImports.jbRankHausInit(components, maxwidth, maxheight, size, rank);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbClasser(pointer);
            }
        }

        public static JbClasser jbCorrelationInit(int components, int maxwidth, int maxheight, float thresh, float weightfactor)
        {
            var pointer = Native.DllImports.jbCorrelationInit(components, maxwidth, maxheight, thresh, weightfactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbClasser(pointer);
            }
        }

        public static JbClasser jbCorrelationInitWithoutComponents(int components, int maxwidth, int maxheight, float thresh, float weightfactor)
        {
            var pointer = Native.DllImports.jbCorrelationInitWithoutComponents(components, maxwidth, maxheight, thresh, weightfactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbClasser(pointer);
            }
        }

        // Classify the pages
        public static int jbAddPages(this JbClasser classer, Sarray safiles)
        {
            if (null == classer
             || null == safiles)
            {
                throw new ArgumentNullException("classer, safiles cannot be null.");
            }

            return Native.DllImports.jbAddPages((HandleRef)classer, (HandleRef)safiles);
        }

        public static int jbAddPage(this JbClasser classer, Pix pixs)
        {
            if (null == classer
             || null == pixs)
            {
                throw new ArgumentNullException("classer, pixs cannot be null.");
            }

            return Native.DllImports.jbAddPage((HandleRef)classer, (HandleRef)pixs);
        }

        public static int jbAddPageComponents(this JbClasser classer, Pix pixs, Boxa boxas, Pixa pixas)
        {
            if (null == classer
             || null == pixs
             || null == boxas
             || null == pixas)
            {
                throw new ArgumentNullException("classer, pixs, boxas, pixas cannot be null.");
            }

            return Native.DllImports.jbAddPageComponents((HandleRef)classer, (HandleRef)pixs, (HandleRef)boxas, (HandleRef)pixas);
        }

        // Rank hausdorff classifier
        public static int jbClassifyRankHaus(this JbClasser classer, Boxa boxa, Pixa pixas)
        {
            if (null == classer
             || null == boxa
             || null == pixas)
            {
                throw new ArgumentNullException("classer, boxa, pixas cannot be null.");
            }

            return Native.DllImports.jbClassifyRankHaus((HandleRef)classer, (HandleRef)boxa, (HandleRef)pixas);
        }

        public static int pixHaustest(this Pix pix1, Pix pix2, Pix pix3, Pix pix4, float delx, float dely, int maxdiffw, int maxdiffh)
        {
            if (null == pix1
             || null == pix2
             || null == pix3
             || null == pix4)
            {
                throw new ArgumentNullException("pix1, pix2, pix3, pix4 cannot be null.");
            }

            return Native.DllImports.pixHaustest((HandleRef)pix1, (HandleRef)pix2, (HandleRef)pix3, (HandleRef)pix4, delx, dely, maxdiffw, maxdiffh);
        }

        public static int pixRankHaustest(this Pix pix1, Pix pix2, Pix pix3, Pix pix4, float delx, float dely, int maxdiffw, int maxdiffh, int area1, int area3, float rank, IntPtr tab8)
        {
            if (null == pix1
             || null == pix2
             || null == pix3
             || null == pix4
             || IntPtr.Zero == tab8)
            {
                throw new ArgumentNullException("pix1, pix2, pix3, pix4, tab8 cannot be null.");
            }

            return Native.DllImports.pixRankHaustest((HandleRef)pix1, (HandleRef)pix2, (HandleRef)pix3, (HandleRef)pix4, delx, dely, maxdiffw, maxdiffh, area1, area3, rank, tab8);
        }

        // Binary correlation classifier
        public static int jbClassifyCorrelation(this JbClasser classer, Boxa boxa, Pixa pixas)
        {
            if (null == classer
             || null == boxa
             || null == pixas)
            {
                throw new ArgumentNullException("classer, boxa, pixas cannot be null.");
            }

            return Native.DllImports.jbClassifyCorrelation((HandleRef)classer, (HandleRef)boxa, (HandleRef)pixas);
        }

        // Determine the image components we start with
        public static int jbGetComponents(this Pix pixs, int components, int maxwidth, int maxheight, out Boxa pboxad, out Pixa ppixad)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxadPtr, ppixadPtr;
            var result = Native.DllImports.jbGetComponents((HandleRef)pixs, components, maxwidth, maxheight, out pboxadPtr, out ppixadPtr);

            pboxad = new Boxa(pboxadPtr);
            ppixad = new Pixa(ppixadPtr);

            return result;
        }

        //public static int pixWordMaskByDilation(this Pix pixs, int maxdil, out Pix ppixm, out int psize)
        //{
        //    if (null == pixs)
        //    {
        //        throw new ArgumentNullException("pixs cannot be null.");
        //    }

        //    IntPtr ppixmPtr;
        //    var result = Native.DllImports.pixWordMaskByDilation((HandleRef)pixs, maxdil, out ppixmPtr, out psize);

        //    ppixm = new Pix(ppixmPtr);

        //    return result;
        //}

        public static int pixWordMaskByDilation(this Pix pixs, out Pix ppixm, out int psize, out Pixa pixadb)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var result = Native.DllImports.pixWordMaskByDilation((HandleRef)pixs, out IntPtr ppixmPtr, out psize, out IntPtr pixadbPtr);

            ppixm = new Pix(ppixmPtr);
            // TODO: pixadbPtr is always messed up - not sure why
            //pixadb = new Pixa(pixadbPtr);
            pixadb = null;

            return result;
        }

        public static int pixWordBoxesByDilation(this Pix pixs, int maxdil, int minwidth, int minheight, int maxwidth, int maxheight, out Boxa pboxa, out int psize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr;
            var result = Native.DllImports.pixWordBoxesByDilation((HandleRef)pixs, maxdil, minwidth, minheight, maxwidth, maxheight, out pboxaPtr, out psize);

            pboxa = new Boxa(pboxaPtr);

            return result;
        }

        // Build grayscale composites(templates)
        public static Pixa jbAccumulateComposites(this Pixaa pixaa, out Numa pna, out Pta pptat)
        {
            if (null == pixaa)
            {
                throw new ArgumentNullException("pixaa cannot be null.");
            }

            IntPtr pptatPtr, pnaPtr;
            var pointer = Native.DllImports.jbAccumulateComposites((HandleRef)pixaa, out pnaPtr, out pptatPtr);
            pna = new Numa(pnaPtr);
            pptat = new Pta(pptatPtr);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa jbTemplatesFromComposites(this Pixa pixac, Numa na)
        {
            if (null == pixac
             || null == na)
            {
                throw new ArgumentNullException("pixac, na cannot be null.");
            }

            var pointer = Native.DllImports.jbTemplatesFromComposites((HandleRef)pixac, (HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Utility functions for Classer
        public static JbClasser jbClasserCreate(int method, int components)
        {
            var pointer = Native.DllImports.jbClasserCreate(method, components);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbClasser(pointer);
            }
        }

        public static void jbClasserDestroy(this JbClasser pclasser)
        {
            if (null == pclasser)
            {
                throw new ArgumentNullException("pclasser cannot be null");
            }

            var pointer = (IntPtr)pclasser;

            Native.DllImports.jbClasserDestroy(ref pointer);
        }

        // Utility functions for Data
        public static JbData jbDataSave(this JbClasser classer)
        {
            if (null == classer)
            {
                throw new ArgumentNullException("classer cannot be null.");
            }

            var pointer = Native.DllImports.jbDataSave((HandleRef)classer);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbData(pointer);
            }
        }

        public static void jbDataDestroy(this JbData pdata)
        {
            if (null == pdata)
            {
                throw new ArgumentNullException("pdata cannot be null");
            }

            var pointer = (IntPtr)pdata;

            Native.DllImports.jbDataDestroy(ref pointer);
        }

        public static int jbDataWrite(string rootout, JbData jbdata)
        {
            if (string.IsNullOrWhiteSpace(rootout))
            {
                throw new ArgumentNullException("rootout cannot be null");
            }
            if (null == jbdata)
            {
                throw new ArgumentNullException("jbdata cannot be null");
            }

            return Native.DllImports.jbDataWrite(rootout, (HandleRef)jbdata);
        }

        public static JbData jbDataRead(string rootname)
        {
            if (string.IsNullOrWhiteSpace(rootname))
            {
                throw new ArgumentNullException("rootname cannot be null");
            }

            var pointer = Native.DllImports.jbDataRead(rootname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new JbData(pointer);
            }
        }

        public static Pixa jbDataRender(this JbData data, int debugflag)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data cannot be null.");
            }

            var pointer = Native.DllImports.jbDataRender((HandleRef)data, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int jbGetULCorners(this JbClasser classer, Pix pixs, Boxa boxa)
        {
            if (null == classer
             || null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("classer, pixs, boxa cannot be null.");
            }

            return Native.DllImports.jbGetULCorners((HandleRef)classer, (HandleRef)pixs, (HandleRef)boxa);
        }

        public static int jbGetLLCorners(this JbClasser classer)
        {
            if (null == classer)
            {
                throw new ArgumentNullException("classer cannot be null.");
            }

            return Native.DllImports.jbGetLLCorners((HandleRef)classer);
        }
    }
}
