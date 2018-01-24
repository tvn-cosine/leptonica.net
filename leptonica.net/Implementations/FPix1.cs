using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class FPix1
    {
        // FPix Create/copy/destroy
        public static FPix fpixCreate(int width, int height)
        {
            var pointer = Native.DllImports.fpixCreate(width, height);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixCreateTemplate(this FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null.");
            }

            var pointer = Native.DllImports.fpixCreateTemplate((HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixClone(this FPix fpix)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            var pointer = Native.DllImports.fpixClone((HandleRef)fpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixCopy(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null.");
            }

            var pointer = Native.DllImports.fpixCopy((HandleRef)fpixd, (HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static int fpixResizeImageData(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null.");
            }

            return Native.DllImports.fpixResizeImageData((HandleRef)fpixd, (HandleRef)fpixs);
        }

        public static void fpixDestroy(this FPix pfpix)
        {
            if (null == pfpix)
            {
                throw new ArgumentNullException("pfpix cannot be null");
            }

            var pointer = (IntPtr)pfpix;

            Native.DllImports.fpixDestroy(ref pointer);
        }

        // FPix accessors
        public static int fpixGetDimensions(this FPix fpix, out int pw, out int ph)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetDimensions((HandleRef)fpix, out pw, out ph);
        }

        public static int fpixSetDimensions(this FPix fpix, int w, int h)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixSetDimensions((HandleRef)fpix, w, h);
        }

        public static int fpixGetWpl(this FPix fpix)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetWpl((HandleRef)fpix);
        }

        public static int fpixSetWpl(this FPix fpix, int wpl)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixSetWpl((HandleRef)fpix, wpl);
        }

        public static int fpixGetRefcount(this FPix fpix)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetRefcount((HandleRef)fpix);
        }

        public static int fpixChangeRefcount(this FPix fpix, int delta)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixChangeRefcount((HandleRef)fpix, delta);
        }

        public static int fpixGetResolution(this FPix fpix, out int pxres, out int pyres)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetResolution((HandleRef)fpix, out pxres, out pyres);
        }

        public static int fpixSetResolution(this FPix fpix, int xres, int yres)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixSetResolution((HandleRef)fpix, xres, yres);
        }

        public static int fpixCopyResolution(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs
             || null == fpixd)
            {
                throw new ArgumentNullException("fpixs, fpixd cannot be null.");
            }

            return Native.DllImports.fpixCopyResolution((HandleRef)fpixd, (HandleRef)fpixs);
        }

        public static IntPtr fpixGetData(this FPix fpix)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetData((HandleRef)fpix);
        }

        public static int fpixSetData(this FPix fpix, IntPtr data)
        {
            if (null == fpix
             || IntPtr.Zero == data)
            {
                throw new ArgumentNullException("fpix, data cannot be null.");
            }

            return Native.DllImports.fpixSetData((HandleRef)fpix, data);
        }

        public static int fpixGetPixel(this FPix fpix, int x, int y, out float pval)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixGetPixel((HandleRef)fpix, x, y, out pval);
        }

        public static int fpixSetPixel(this FPix fpix, int x, int y, float val)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.fpixSetPixel((HandleRef)fpix, x, y, val);
        }
         
        // FPixa Create/copy/destroy
        public static FPixa fpixaCreate(int n)
        {
            var pointer = Native.DllImports.fpixaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static FPixa fpixaCopy(this FPixa fpixa, int copyflag)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa cannot be null.");
            }

            var pointer = Native.DllImports.fpixaCopy((HandleRef)fpixa, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static void fpixaDestroy(this FPixa pfpixa)
        {
            if (null == pfpixa)
            {
                throw new ArgumentNullException("pfpixa cannot be null");
            }

            var pointer = (IntPtr)pfpixa;

            Native.DllImports.fpixaDestroy(ref pointer);
        }

        // FPixa addition
        public static int fpixaAddFPix(this FPixa fpixa, FPix fpix, int copyflag)
        {
            if (null == fpixa
             || null == fpix)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaAddFPix((HandleRef)fpixa, (HandleRef)fpix, copyflag);
        }

        // FPixa accessors
        public static int fpixaGetCount(this FPixa fpixa)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaGetCount((HandleRef)fpixa);
        }

        public static int fpixaChangeRefcount(this FPixa fpixa, int delta)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaChangeRefcount((HandleRef)fpixa, delta);
        }

        public static FPix fpixaGetFPix(this FPixa fpixa, int index, int accesstype)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa cannot be null.");
            }

            var pointer = Native.DllImports.fpixaGetFPix((HandleRef)fpixa, index, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static int fpixaGetFPixDimensions(this FPixa fpixa, int index, out int pw, out int ph)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaGetFPixDimensions((HandleRef)fpixa, index, out pw, out ph);
        }

        public static IntPtr fpixaGetData(this FPixa fpixa, int index)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaGetData((HandleRef)fpixa, index);
        }

        public static int fpixaGetPixel(this FPixa fpixa, int index, int x, int y, out float pval)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaGetPixel((HandleRef)fpixa, index, x, y, out pval);
        }

        public static int fpixaSetPixel(this FPixa fpixa, int index, int x, int y, float val)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa, fpix cannot be null.");
            }

            return Native.DllImports.fpixaSetPixel((HandleRef)fpixa, index, x, y, val);
        }

        // DPix Create/copy/destroy
        public static DPix dpixCreate(int width, int height)
        {
            var pointer = Native.DllImports.dpixCreate(width, height);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static DPix dpixCreateTemplate(this DPix dpixs)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null.");
            }

            var pointer = Native.DllImports.dpixCreateTemplate((HandleRef)dpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static DPix dpixClone(this DPix dpix)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            var pointer = Native.DllImports.dpixClone((HandleRef)dpix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static DPix dpixCopy(this DPix dpixd, DPix dpixs)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null.");
            }

            var pointer = Native.DllImports.dpixCopy((HandleRef)dpixd, (HandleRef)dpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static int dpixResizeImageData(this DPix dpixd, DPix dpixs)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null.");
            }

            return Native.DllImports.dpixResizeImageData((HandleRef)dpixd, (HandleRef)dpixs);
        }

        public static void dpixDestroy(this DPix pdpix)
        {
            if (null == pdpix)
            {
                throw new ArgumentNullException("pdpix cannot be null");
            }

            var pointer = (IntPtr)pdpix;

            Native.DllImports.dpixDestroy(ref pointer);
        }

        // DPix accessors
        public static int dpixGetDimensions(this DPix dpix, out int pw, out int ph)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("fpix cannot be null.");
            }

            return Native.DllImports.dpixGetDimensions((HandleRef)dpix, out pw, out ph);
        }

        public static int dpixSetDimensions(this DPix dpix, int w, int h)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixSetDimensions((HandleRef)dpix, w, h);
        }

        public static int dpixGetWpl(this DPix dpix)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixGetWpl((HandleRef)dpix);
        }

        public static int dpixSetWpl(this DPix dpix, int wpl)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixSetWpl((HandleRef)dpix, wpl);
        }

        public static int dpixGetRefcount(this DPix dpix)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixGetRefcount((HandleRef)dpix);
        }

        public static int dpixChangeRefcount(this DPix dpix, int delta)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixChangeRefcount((HandleRef)dpix, delta);
        }

        public static int dpixGetResolution(this DPix dpix, out int pxres, out int pyres)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixGetResolution((HandleRef)dpix, out pxres, out pyres);
        }

        public static int dpixSetResolution(this DPix dpix, int xres, int yres)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixSetResolution((HandleRef)dpix, xres, yres);
        }

        public static int dpixCopyResolution(this DPix dpixd, DPix dpixs)
        {
            if (null == dpixd
             || null == dpixs)
            {
                throw new ArgumentNullException("dpixs, dpixd cannot be null.");
            }

            return Native.DllImports.fpixCopyResolution((HandleRef)dpixd, (HandleRef)dpixs);
        }

        public static IntPtr dpixGetData(this DPix dpix)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixGetData((HandleRef)dpix);
        }

        public static int dpixSetData(this DPix dpix, IntPtr data)
        {
            if (null == dpix
             || IntPtr.Zero == data)
            {
                throw new ArgumentNullException("dpix, data cannot be null.");
            }

            return Native.DllImports.fpixSetData((HandleRef)dpix, data);
        }

        public static int dpixGetPixel(this DPix dpix, int x, int y, out double pval)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixGetPixel((HandleRef)dpix, x, y, out pval);
        }

        public static int dpixSetPixel(this DPix dpix, int x, int y, double val)
        {
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null.");
            }

            return Native.DllImports.dpixSetPixel((HandleRef)dpix, x, y, val);
        }

        // FPix serialized I/O
        public static FPix fpixRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.fpixRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.fpixReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static FPix fpixReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.fpixReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        public static int fpixWrite(string filename, FPix fpix)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            return Native.DllImports.fpixWrite(filename, (HandleRef)fpix);
        }

        public static int fpixWriteStream(IntPtr fp, FPix fpix)
        {
            if (IntPtr.Zero == fp
             || null == fpix)
            {
                throw new ArgumentNullException("fp, fpix cannot be null");
            }

            return Native.DllImports.fpixWriteStream(fp, (HandleRef)fpix);
        }
         
        public static int fpixWriteMem(out IntPtr pdata, IntPtr psize, FPix fpix)
        {
            if (IntPtr.Zero == psize
             || null == fpix)
            {
                throw new ArgumentNullException("psize, fpix cannot be null");
            }

            return Native.DllImports.fpixWriteMem(out pdata, psize, (HandleRef)fpix);
        }

        public static FPix fpixEndianByteSwap(this FPix fpixd, FPix fpixs)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixEndianByteSwap((HandleRef)fpixd, (HandleRef)fpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPix(pointer);
            }
        }

        // DPix serialized I/O
        public static DPix dpixRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.dpixRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static DPix dpixReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.dpixReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static DPix dpixReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.dpixReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        public static int dpixWrite(string filename, DPix dpix)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == dpix)
            {
                throw new ArgumentNullException("dpix cannot be null");
            }

            return Native.DllImports.dpixWrite(filename, (HandleRef)dpix);
        }

        public static int dpixWriteStream(IntPtr fp, DPix dpix)
        {
            if (IntPtr.Zero == fp
             || null == dpix)
            {
                throw new ArgumentNullException("fp, boxa cannot be null");
            }

            return Native.DllImports.dpixWriteStream(fp, (HandleRef)dpix);
        }

        public static int dpixWriteMem(out IntPtr pdata, IntPtr psize, DPix dpix) 
        {
            if (IntPtr.Zero == psize
             || null == dpix)
            {
                throw new ArgumentNullException("psize, dpix cannot be null");
            }

            return Native.DllImports.dpixWriteMem(out pdata, psize, (HandleRef)dpix);
        }

        public static DPix dpixEndianByteSwap(this DPix dpixd, DPix dpixs)
        {
            if (null == dpixs)
            {
                throw new ArgumentNullException("dpixs cannot be null");
            }

            var pointer = Native.DllImports.dpixEndianByteSwap((HandleRef) dpixd, (HandleRef)dpixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DPix(pointer);
            }
        }

        // Print FPix(subsampled, for debugging)
        public static int fpixPrintStream(IntPtr fp, FPix fpix, int factor)
        {
            if (IntPtr.Zero == fp
             || null == fpix)
            {
                throw new ArgumentNullException("fp, fpix cannot be null");
            }

            return Native.DllImports.fpixPrintStream(fp, (HandleRef)fpix, factor);
        }
    }
}
