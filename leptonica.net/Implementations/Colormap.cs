using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class Colormap
    {
        // Colormap creation, copy, destruction, addition
        public static PixColormap pixcmapCreate(int depth)
        {
            var pointer = Native.DllImports.pixcmapCreate(depth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapCreateRandom(int depth, int hasblack, int haswhite)
        {
            var pointer = Native.DllImports.pixcmapCreateRandom(depth, hasblack, haswhite);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapCreateLinear(int d, int nlevels)
        {
            var pointer = Native.DllImports.pixcmapCreateLinear(d, nlevels);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapCopy(this PixColormap cmaps)
        {
            if (null == cmaps)
            {
                throw new ArgumentNullException("cmaps cannot be null");
            }

            var pointer = Native.DllImports.pixcmapCopy((HandleRef)cmaps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static void pixcmapDestroy(this PixColormap pcmap)
        {
            if (null == pcmap)
            {
                throw new ArgumentNullException("pcmap cannot be null");
            }

            var pointer = (IntPtr)pcmap;

            Native.DllImports.pixcmapDestroy(ref pointer);
        }

        public static int pixcmapAddColor(this PixColormap cmap, int rval, int gval, int bval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapAddColor((HandleRef)cmap, rval, gval, bval);
        }

        public static int pixcmapAddRGBA(this PixColormap cmap, int rval, int gval, int bval, int aval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapAddRGBA((HandleRef)cmap, rval, gval, bval, aval);
        }

        public static int pixcmapAddNewColor(this PixColormap cmap, int rval, int gval, int bval, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapAddNewColor((HandleRef)cmap, rval, gval, bval, out pindex);
        }

        public static int pixcmapAddNearestColor(this PixColormap cmap, int rval, int gval, int bval, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapAddNearestColor((HandleRef)cmap, rval, gval, bval, out pindex);
        }

        public static int pixcmapUsableColor(this PixColormap cmap, int rval, int gval, int bval, out int pusable)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapUsableColor((HandleRef)cmap, rval, gval, bval, out pusable);
        }

        public static int pixcmapAddBlackOrWhite(this PixColormap cmap, int color, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapAddBlackOrWhite((HandleRef)cmap, color, out pindex);
        }

        public static int pixcmapSetBlackAndWhite(this PixColormap cmap, int setblack, int setwhite)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapSetBlackAndWhite((HandleRef)cmap, setblack, setwhite);
        }

        public static int pixcmapGetCount(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetCount((HandleRef)cmap);
        }

        public static int pixcmapGetDepth(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetDepth((HandleRef)cmap);
        }

        public static int pixcmapGetMinDepth(this PixColormap cmap, out int pmindepth)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetMinDepth((HandleRef)cmap, out pmindepth);
        }

        public static int pixcmapGetFreeCount(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetFreeCount((HandleRef)cmap);
        }

        public static int pixcmapClear(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapClear((HandleRef)cmap);
        }

        // Colormap random access and test 
        public static int pixcmapGetColor(this PixColormap cmap, int index, out int prval, out int pgval, out int pbval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetColor((HandleRef)cmap, index, out prval, out pgval, out pbval);
        }

        public static int pixcmapGetColor32(this PixColormap cmap, int index, out int pval32)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetColor32((HandleRef)cmap, index, out pval32);
        }

        public static int pixcmapGetRGBA(this PixColormap cmap, int index, out int prval, out int pgval, out int pbval, out int paval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetRGBA((HandleRef)cmap, index, out prval, out pgval, out pbval, out paval);
        }

        public static int pixcmapGetRGBA32(this PixColormap cmap, int index, out int pval32)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetRGBA32((HandleRef)cmap, index, out pval32);
        }

        public static int pixcmapResetColor(this PixColormap cmap, int index, int rval, int gval, int bval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapResetColor((HandleRef)cmap, index, rval, gval, bval);
        }

        public static int pixcmapSetAlpha(this PixColormap cmap, int index, int aval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapSetAlpha((HandleRef)cmap, index, aval);
        }

        public static int pixcmapGetIndex(this PixColormap cmap, int rval, int gval, int bval, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetIndex((HandleRef)cmap, rval, gval, bval, out pindex);
        }

        public static int pixcmapHasColor(this PixColormap cmap, out int pcolor)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapHasColor((HandleRef)cmap, out pcolor);
        }

        public static int pixcmapIsOpaque(this PixColormap cmap, out int popaque)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapIsOpaque((HandleRef)cmap, out popaque);
        }

        public static int pixcmapIsBlackAndWhite(this PixColormap cmap, out int pblackwhite)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapIsBlackAndWhite((HandleRef)cmap, out pblackwhite);
        }

        public static int pixcmapCountGrayColors(this PixColormap cmap, out int pngray)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapCountGrayColors((HandleRef)cmap, out pngray);
        }

        public static int pixcmapGetRankIntensity(this PixColormap cmap, float rankval, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetRankIntensity((HandleRef)cmap, rankval, out pindex);
        }

        public static int pixcmapGetNearestIndex(this PixColormap cmap, int rval, int gval, int bval, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetNearestIndex((HandleRef)cmap, rval, gval, bval, out pindex);
        }

        public static int pixcmapGetNearestGrayIndex(this PixColormap cmap, int val, out int pindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetNearestGrayIndex((HandleRef)cmap, val, out pindex);
        }

        public static int pixcmapGetDistanceToColor(this PixColormap cmap, int index, int rval, int gval, int bval, out int pdist)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetDistanceToColor((HandleRef)cmap, index, rval, gval, bval, out pdist);
        }

        public static int pixcmapGetRangeValues(this PixColormap cmap, int select, out int pminval, out int pmaxval, out int pminindex, out int pmaxindex)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGetRangeValues((HandleRef)cmap, select, out pminval, out pmaxval, out pminindex, out pmaxindex);
        }

        // Colormap conversion
        public static PixColormap pixcmapGrayToColor(uint color)
        {
            var pointer = Native.DllImports.pixcmapGrayToColor(color);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapColorToGray(this PixColormap cmaps, float rwt, float gwt, float bwt)
        {
            if (null == cmaps)
            {
                throw new ArgumentNullException("cmaps cannot be null");
            }

            var pointer = Native.DllImports.pixcmapColorToGray((HandleRef)cmaps, rwt, gwt, bwt);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapConvertTo4(this PixColormap cmaps)
        {
            if (null == cmaps)
            {
                throw new ArgumentNullException("cmaps cannot be null");
            }

            var pointer = Native.DllImports.pixcmapConvertTo4((HandleRef)cmaps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapConvertTo8(this PixColormap cmaps)
        {
            if (null == cmaps)
            {
                throw new ArgumentNullException("cmaps cannot be null");
            }

            var pointer = Native.DllImports.pixcmapConvertTo8((HandleRef)cmaps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        // Colormap I/O
        public static PixColormap pixcmapRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist.");
            }

            var pointer = Native.DllImports.pixcmapRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixcmapReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static PixColormap pixcmapReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.pixcmapReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static int pixcmapWrite(string filename, PixColormap cmap)
        {
            if (string.IsNullOrWhiteSpace(filename)
             || null == cmap)
            {
                throw new ArgumentNullException("filename, cmap cannot be null");
            }

            return Native.DllImports.pixcmapWrite(filename, (HandleRef)cmap);
        }

        public static int pixcmapWriteStream(IntPtr fp, PixColormap cmap)
        {
            if (IntPtr.Zero == fp
             || null == cmap)
            {
                throw new ArgumentNullException("fp, cmap cannot be null");
            }

            return Native.DllImports.pixcmapWriteStream(fp, (HandleRef)cmap);
        }

        public static int pixcmapWriteMem(out IntPtr pdata, out IntPtr psize, PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapWriteMem(out pdata, out psize, (HandleRef)cmap);
        }

        // Extract colormap arrays and serialization
        public static int pixcmapToArrays(this PixColormap cmap, out IntPtr prmap, out IntPtr pgmap, out IntPtr pbmap, out IntPtr pamap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapToArrays((HandleRef)cmap, out prmap, out pgmap, out pbmap, out pamap);
        }

        public static int pixcmapToRGBTable(this PixColormap cmap, out IntPtr ptab, out int pncolors)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapToRGBTable((HandleRef)cmap, out ptab, out pncolors);
        }

        public static int pixcmapSerializeToMemory(this PixColormap cmap, int cpc, out int pncolors, out IntPtr pdata)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapSerializeToMemory((HandleRef)cmap, cpc, out pncolors, out pdata);
        }

        public static PixColormap pixcmapDeserializeFromMemory(IntPtr data, int cpc, int ncolors)
        {
            if (IntPtr.Zero == data)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            var pointer = Native.DllImports.pixcmapDeserializeFromMemory(data, cpc, ncolors);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        public static string pixcmapConvertToHex(IntPtr data, int ncolors)
        {
            if (IntPtr.Zero == data)
            {
                throw new ArgumentNullException("data cannot be null");
            }

            var pointer = Native.DllImports.pixcmapConvertToHex(data, ncolors);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return Marshal.PtrToStringAnsi(pointer);
            }
        }

        // Colormap transforms
        public static int pixcmapGammaTRC(this PixColormap cmap, float gamma, int minval, int maxval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapGammaTRC((HandleRef)cmap, gamma, minval, maxval);
        }

        public static int pixcmapContrastTRC(this PixColormap cmap, float factor)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapContrastTRC((HandleRef)cmap, factor);
        }

        public static int pixcmapShiftIntensity(this PixColormap cmap, float fraction)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapShiftIntensity((HandleRef)cmap, fraction);
        }

        public static int pixcmapShiftByComponent(this PixColormap cmap, uint srcval, uint dstval)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null");
            }

            return Native.DllImports.pixcmapShiftByComponent((HandleRef)cmap, srcval, dstval);
        }
    }
}
