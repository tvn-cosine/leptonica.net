using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class BoxFunc2
    {
        // Boxa/Box transform(shift, scale) and orthogonal rotation
        public static Boxa boxaTransform(this Boxa boxas, int shiftx, int shifty, float scalex, float scaley)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaTransform((HandleRef)boxas, shiftx, shifty, scalex, scaley);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Box boxTransform(this Box box, int shiftx, int shifty, float scalex, float scaley)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null.");
            }

            var pointer = Native.DllImports.boxTransform((HandleRef)box, shiftx, shifty, scalex, scaley);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Boxa boxaTransformOrdered(this Boxa boxas, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaTransformOrdered((HandleRef)boxas, shiftx, shifty, scalex, scaley, xcen, ycen, angle, order);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Box boxTransformOrdered(this Box boxs, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order)
        {
            if (null == boxs)
            {
                throw new ArgumentNullException("boxs cannot be null.");
            }

            var pointer = Native.DllImports.boxTransformOrdered((HandleRef)boxs, shiftx, shifty, scalex, scaley, xcen, ycen, angle, order);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Boxa boxaRotateOrth(this Boxa boxas, int w, int h, int rotation)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaRotateOrth((HandleRef)boxas, w, h, rotation);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Box boxRotateOrth(this Box box, int w, int h, int rotation)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null.");
            }

            var pointer = Native.DllImports.boxRotateOrth((HandleRef)box, w, h, rotation);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        // Boxa sort
        public static Boxa boxaSort(this Boxa boxas, int sorttype, int sortorder, out Numa pnaindex)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.boxaSort((HandleRef)boxas, sorttype, sortorder, out pnaindexPtr);

            if (IntPtr.Zero == pnaindexPtr)
            {
                pnaindex = null;
            }
            else
            {
                pnaindex = new Numa(pnaindexPtr);
            }

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaBinSort(this Boxa boxas, int sorttype, int sortorder, out Numa pnaindex)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.boxaBinSort((HandleRef)boxas, sorttype, sortorder, out pnaindexPtr);

            if (IntPtr.Zero == pnaindexPtr)
            {
                pnaindex = null;
            }
            else
            {
                pnaindex = new Numa(pnaindexPtr);
            }

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaSortByIndex(this Boxa boxas, Numa naindex)
        {
            if (null == boxas
             || null == naindex)
            {
                throw new ArgumentNullException("boxas, naindex cannot be null.");
            }

            var pointer = Native.DllImports.boxaSortByIndex((HandleRef)boxas, (HandleRef)naindex);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxaa boxaSort2d(this Boxa boxas, out Numaa pnaad, int delta1, int delta2, int minh1)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            IntPtr pnaadPtr;
            var pointer = Native.DllImports.boxaSort2d((HandleRef)boxas, out pnaadPtr, delta1, delta2, minh1);

            if (IntPtr.Zero == pnaadPtr)
            {
                pnaad = null;
            }
            else
            {
                pnaad = new Numaa(pnaadPtr);
            }

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static Boxaa boxaSort2dByIndex(this Boxa boxas, Numa naa)
        {
            if (null == boxas
             || null == naa)
            {
                throw new ArgumentNullException("boxas, naa cannot be null.");
            }

            var pointer = Native.DllImports.boxaSort2dByIndex((HandleRef)boxas, (HandleRef)naa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        // Boxa statistics
        public static int boxaGetRankVals(this Boxa boxa, float fract, out int px, out int py, out int pw, out int ph)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var result = Native.DllImports.boxaGetRankVals((HandleRef)boxa, fract, out px, out py, out pw, out ph);


            return result;
        }

        public static int boxaGetMedianVals(this Boxa boxa, out int px, out int py, out int pw, out int ph)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var result = Native.DllImports.boxaGetMedianVals((HandleRef)boxa, out px, out py, out pw, out ph);


            return result;
        }

        public static int boxaGetAverageSize(this Boxa boxa, out float pw, out float ph)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var result = Native.DllImports.boxaGetAverageSize((HandleRef)boxa, out pw, out ph);


            return result;
        }

        // Boxa array extraction
        public static int boxaExtractAsNuma(this Boxa boxa, out Numa pnal, out Numa pnat, out Numa pnar, out Numa pnab, out Numa pnaw, out Numa pnah, int keepinvalid)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            IntPtr pnalPtr, pnatPtr, pnarPtr, pnabPtr, pnawPtr, pnahPtr;
            var result = Native.DllImports.boxaExtractAsNuma((HandleRef)boxa, out pnalPtr, out pnatPtr, out pnarPtr, out pnabPtr, out pnawPtr, out pnahPtr, keepinvalid);

            pnal = new Numa(pnalPtr);
            pnat = new Numa(pnatPtr);
            pnar = new Numa(pnarPtr);
            pnab = new Numa(pnabPtr);
            pnaw = new Numa(pnawPtr);
            pnah = new Numa(pnahPtr);

            return result;
        }

        public static int boxaExtractAsPta(this Boxa boxa, out Pta pptal, out Pta pptat, out Pta pptar, out Pta pptab, out Pta pptaw, out Pta pptah, int keepinvalid)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            IntPtr pptalPtr, pptatPtr, pptarPtr, pptabPtr, pptawPtr, pptahPtr;
            var result = Native.DllImports.boxaExtractAsPta((HandleRef)boxa, out pptalPtr, out pptatPtr, out pptarPtr, out pptabPtr, out pptawPtr, out pptahPtr, keepinvalid);

            pptal = new Pta(pptalPtr);
            pptat = new Pta(pptatPtr);
            pptar = new Pta(pptarPtr);
            pptab = new Pta(pptabPtr);
            pptaw = new Pta(pptawPtr);
            pptah = new Pta(pptahPtr);

            return result;
        }

        //Other Boxaa functions
        public static int boxaaGetExtent(this Boxaa baa, out int pw, out int ph, out Box pbox, out Boxa pboxa)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null.");
            }

            IntPtr pboxPtr, pboxaPtr;
            var result = Native.DllImports.boxaaGetExtent((HandleRef)baa, out pw, out ph, out pboxPtr, out pboxaPtr);

            pbox = new Box(pboxPtr);
            pboxa = new Boxa(pboxaPtr);

            return result;
        }

        public static Boxa boxaaFlattenToBoxa(this Boxaa baa, out Numa pnaindex, int copyflag)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null.");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.boxaaFlattenToBoxa((HandleRef)baa, out pnaindexPtr, copyflag);

            pnaindex = new Numa(pnaindexPtr);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaaFlattenAligned(this Boxaa baa, int num, Box fillerbox, int copyflag)
        {
            if (null == baa
             || null == fillerbox)
            {
                throw new ArgumentNullException("baa, fillerbox cannot be null.");
            }

            var pointer = Native.DllImports.boxaaFlattenAligned((HandleRef)baa, num, (HandleRef)fillerbox, copyflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxaa boxaEncapsulateAligned(this Boxa boxa, int num, int copyflag)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null.");
            }

            var pointer = Native.DllImports.boxaEncapsulateAligned((HandleRef)boxa, num, copyflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static Boxaa boxaaTranspose(this Boxaa baas)
        {
            if (null == baas)
            {
                throw new ArgumentNullException("baas cannot be null.");
            }

            var pointer = Native.DllImports.boxaaTranspose((HandleRef)baas);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static int boxaaAlignBox(this Boxaa baa, Box box, int delta, out int pindex)
        {
            if (null == baa
             || null == box)
            {
                throw new ArgumentNullException("baa, box cannot be null.");
            }

            return Native.DllImports.boxaaAlignBox((HandleRef)baa, (HandleRef)box, delta, out pindex);
        }
    }
}
