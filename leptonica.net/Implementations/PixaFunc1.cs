using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixaFunc1
    {
        // Filters
        public static Pix pixSelectBySize(this Pix pixs, int width, int height, int connectivity, int type, int relation, out int pchanged)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSelectBySize((HandleRef)pixs, width, height, connectivity, type, relation, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaSelectBySize(this Pixa pixas, int width, int height, int type, int relation, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectBySize((HandleRef)pixas, width, height, type, relation, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Numa pixaMakeSizeIndicator(this Pixa pixa, int width, int height, int type, int relation)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaMakeSizeIndicator((HandleRef)pixa, width, height, type, relation);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Pix pixSelectByPerimToAreaRatio(this Pix pixs, float thresh, int connectivity, int type, out int pchanged)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSelectByPerimToAreaRatio((HandleRef)pixs, thresh, connectivity, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaSelectByPerimToAreaRatio(this Pixa pixas, float thresh, int type, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectByPerimToAreaRatio((HandleRef)pixas, thresh, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pix pixSelectByPerimSizeRatio(this Pix pixs, float thresh, int connectivity, int type, out int pchanged)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSelectByPerimSizeRatio((HandleRef)pixs, thresh, connectivity, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaSelectByPerimSizeRatio(this Pixa pixas, float thresh, int type, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectByPerimSizeRatio((HandleRef)pixas, thresh, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pix pixSelectByAreaFraction(this Pix pixs, float thresh, int connectivity, int type, out int pchanged)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSelectByAreaFraction((HandleRef)pixs, thresh, connectivity, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaSelectByAreaFraction(this Pixa pixas, float thresh, int type, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectByAreaFraction((HandleRef)pixas, thresh, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pix pixSelectByWidthHeightRatio(this Pix pixs, float thresh, int connectivity, int type, out int pchanged)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixSelectByWidthHeightRatio((HandleRef)pixs, thresh, connectivity, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaSelectByWidthHeightRatio(this Pixa pixas, float thresh, int type, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectByWidthHeightRatio((HandleRef)pixas, thresh, type, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaSelectByNumConnComp(this Pixa pixas, int nmin, int nmax, int connectivity, out int pchanged)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectByNumConnComp((HandleRef)pixas, nmin, nmax, connectivity, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaSelectWithIndicator(this Pixa pixas, Numa na, out int pchanged)
        {
            if (null == pixas
             || null == na)
            {
                throw new ArgumentNullException("pixas, na cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectWithIndicator((HandleRef)pixas, (HandleRef)na, out pchanged);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixRemoveWithIndicator(this Pix pixs, Pixa pixa, Numa na)
        {
            if (null == pixs
             || null == pixa
             || null == na)
            {
                throw new ArgumentNullException("pixs, pixa, na cannot be null");
            }

            return Native.DllImports.pixRemoveWithIndicator((HandleRef)pixs, (HandleRef)pixa, (HandleRef)na);
        }

        public static int pixAddWithIndicator(this Pix pixs, Pixa pixa, Numa na)
        {
            if (null == pixs
             || null == pixa
             || null == na)
            {
                throw new ArgumentNullException("pixs, pixa, na cannot be null");
            }

            return Native.DllImports.pixAddWithIndicator((HandleRef)pixs, (HandleRef)pixa, (HandleRef)na);
        }

        public static Pixa pixaSelectWithString(this Pixa pixas, string str, IntPtr perror)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectWithString((HandleRef)pixas, str, perror);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pix pixaRenderComponent(this Pix pixs, Pixa pixa, int index)
        {
            if (null == pixs
             || null == pixa)
            {
                throw new ArgumentNullException("pixs, pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaRenderComponent((HandleRef)pixs, (HandleRef)pixa, index);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Sort functions
        public static Pixa pixaSort(this Pixa pixas, int sorttype, int sortorder, out Numa pnaindex, int copyflag)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.pixaSort((HandleRef)pixas, sorttype, sortorder, out pnaindexPtr, copyflag);
            pnaindex = new Numa(pnaindexPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaBinSort(this Pixa pixas, int sorttype, int sortorder, out Numa pnaindex, int copyflag)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.pixaBinSort((HandleRef)pixas, sorttype, sortorder, out pnaindexPtr, copyflag);
            pnaindex = new Numa(pnaindexPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaSortByIndex(this Pixa pixas, Numa naindex, int copyflag)
        {
            if (null == pixas
             || null == naindex)
            {
                throw new ArgumentNullException("pixas, na cannot be null");
            }

            var pointer = Native.DllImports.pixaSortByIndex((HandleRef)pixas, (HandleRef)naindex, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixaa pixaSort2dByIndex(this Pixa pixas, Numaa naa, int copyflag)
        {
            if (null == pixas
             || null == naa)
            {
                throw new ArgumentNullException("pixas, na cannot be null");
            }

            var pointer = Native.DllImports.pixaSort2dByIndex((HandleRef)pixas, (HandleRef)naa, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        // Pixa and Pixaa range selection
        public static Pixa pixaSelectRange(this Pixa pixas, int first, int last, int copyflag)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaSelectRange((HandleRef)pixas, first, last, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixaa pixaaSelectRange(this Pixaa paas, int first, int last, int copyflag)
        {
            if (null == paas)
            {
                throw new ArgumentNullException("paas cannot be null");
            }

            var pointer = Native.DllImports.pixaaSelectRange((HandleRef)paas, first, last, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        // Pixa and Pixaa scaling
        public static Pixaa pixaaScaleToSize(this Pixaa paas, int wd, int hd)
        {
            if (null == paas)
            {
                throw new ArgumentNullException("paas cannot be null");
            }

            var pointer = Native.DllImports.pixaaScaleToSize((HandleRef)paas, wd, hd);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static Pixaa pixaaScaleToSizeVar(this Pixaa paas, Numa nawd, Numa nahd)
        {
            if (null == paas)
            {
                throw new ArgumentNullException("paas cannot be null");
            }

            var pointer = Native.DllImports.pixaaScaleToSizeVar((HandleRef)paas, (HandleRef)nawd, (HandleRef)nahd);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static Pixa pixaScaleToSize(this Pixa pixas, int wd, int hd)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaScaleToSize((HandleRef)pixas, wd, hd);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaScaleToSizeRel(this Pixa pixas, int delw, int delh)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaScaleToSizeRel((HandleRef)pixas, delw, delh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaScale(this Pixa pixas, float scalex, float scaley)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaScale((HandleRef)pixas, scalex, scaley);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Miscellaneous
        public static Pixa pixaAddBorderGeneral(this Pixa pixad, Pixa pixas, int left, int right, int top, int bot, uint val)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaAddBorderGeneral((HandleRef)pixad, (HandleRef)pixas, left, right, top, bot, val);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaaFlattenToPixa(this Pixaa paa, out Numa pnaindex, int copyflag)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            IntPtr pnaindexPtr;
            var pointer = Native.DllImports.pixaaFlattenToPixa((HandleRef)paa, out pnaindexPtr, copyflag);
            pnaindex = new Numa(pnaindexPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaaSizeRange(this Pixaa paa, out int pminw, out int pminh, out int pmaxw, out int pmaxh)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaSizeRange((HandleRef)paa, out pminw, out pminh, out pmaxw, out pmaxh);
        }

        public static int pixaSizeRange(this Pixa pixa, out int pminw, out int pminh, out int pmaxw, out int pmaxh)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaSizeRange((HandleRef)pixa, out pminw, out pminh, out pmaxw, out pmaxh);
        }

        public static Pixa pixaClipToPix(this Pixa pixas, Pix pixs)
        {
            if (null == pixas
             || null == pixs)
            {
                throw new ArgumentNullException("pixas, pixs cannot be null");
            }

            var pointer = Native.DllImports.pixaClipToPix((HandleRef)pixas, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaClipToForeground(this Pixa pixas, out Numa ppixad, out Numa pboxa)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            IntPtr ppixadPtr, pboxaPtr;
            var result = Native.DllImports.pixaClipToForeground((HandleRef)pixas, out ppixadPtr, out pboxaPtr);
            ppixad = new Numa(pboxaPtr);
            pboxa = new Numa(pboxaPtr);

            return result;
        }

        public static int pixaGetRenderingDepth(this Pixa pixa, out int pdepth)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetRenderingDepth((HandleRef)pixa, out pdepth);
        }

        public static int pixaHasColor(this Pixa pixa, out int phascolor)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaHasColor((HandleRef)pixa, out phascolor);
        }

        public static int pixaAnyColormaps(this Pixa pixa, out int phascmap)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaAnyColormaps((HandleRef)pixa, out phascmap);
        }

        public static int pixaGetDepthInfo(this Pixa pixa, out int pmaxdepth, out int psame)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetDepthInfo((HandleRef)pixa, out pmaxdepth, out psame);
        }

        public static Pixa pixaConvertToSameDepth(this Pixa pixas)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertToSameDepth((HandleRef)pixas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaEqual(this Pixa pixa1, Pixa pixa2, int maxdist, out Numa pnaindex, out int psame)
        {
            if (null == pixa1
             || null == pixa2)
            {
                throw new ArgumentNullException("pixa1, pixa2 cannot be null");
            }

            IntPtr pnaindexPtr;
            var result = Native.DllImports.pixaEqual((HandleRef)pixa1, (HandleRef)pixa2, maxdist, out pnaindexPtr, out psame);
            pnaindex = new Numa(pnaindexPtr);

            return result;
        }

        public static Pixa pixaRotateOrth(this Pixa pixas, int rotation)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaRotateOrth((HandleRef)pixas, rotation);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaSetFullSizeBoxa(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaSetFullSizeBoxa((HandleRef)pixa);
        }
    }
}
