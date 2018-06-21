using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pix1
    {
        // Pix memory management(allows custom allocator and deallocator) 
        /// <summary>
        ///      (1) Use this to change the alloc and/or dealloc functions;
        ///          e.g., setPixMemoryManager(my_malloc, my_free).
        ///      (2) The C99 standard (section 6.7.5.3, par. 8) says:
        ///            A declaration of a parameter as "function returning type"
        ///            shall be adjusted to "pointer to function returning type"
        ///          so that it can be in either of these two forms:
        ///            (a) type (function-ptr(type, ...))
        ///            (b) type ((*function-ptr)(type, ...))
        ///          because form (a) is implictly converted to form (b), as in the
        ///          definition of struct PixMemoryManager above.So, for example,
        ///          we should be able to declare either of these:
        ///            (a) void*(allocator(size_t))
        ///            (b) void*((*allocator)(size_t))
        ///          However, MSVC++ only accepts the second version.
        /// </summary>
        /// <param name="allocator">[optional]; use NULL to skip</param>
        /// <param name="deallocator">[optional]; use NULL to skip</param>
        public static void setPixMemoryManager(IntPtr allocator, IntPtr deallocator)
        {
            if (null == allocator
             || null == deallocator)
            {
                throw new ArgumentNullException("allocator, deallocator cannot be null");
            }

            Native.DllImports.setPixMemoryManager(allocator, deallocator);
        }

        public unsafe static Pix pixReadFromMemoryStream(System.IO.Stream stream)
        {
            Pix pix;

            using (var image = System.Drawing.Image.FromStream(stream))
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    var bytes = ms.ToArray();
                    fixed (byte* ptr = bytes)
                    {
                        pix = BmpIO.pixReadMemBmp((IntPtr)ptr, (IntPtr)bytes.Length);
                    }
                }
            }

            return pix;
        }

        // Pix creation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns>pixd with data allocated and initialized to 0, or NULL on error</returns>
        public static Pix pixCreate(int width, int height, int depth)
        {
            var pointer = Native.DllImports.pixCreate(width, height, depth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        /// (1) Must set pad bits to avoid reading unitialized data, because some optimized routines (e.g., pixConnComp()) read from pad bits.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns>pixd with data allocated but not initialized, or NULL on error</returns>
        public static Pix pixCreateNoInit(int width, int height, int depth)
        {
            var pointer = Native.DllImports.pixCreateNoInit(width, height, depth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) Makes a Pix of the same size as the input Pix, with the
        ///          data array allocated and initialized to 0.
        ///      (2) Copies the other fields, including colormap if it exists.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixCreateTemplate(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCreateTemplate((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) Makes a Pix of the same size as the input Pix, with
        /// the data array allocated but not initialized to 0.
        ///      (2) Copies the other fields, including colormap if it exists.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns></returns>
        public static Pix pixCreateTemplateNoInit(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCreateTemplateNoInit((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) It is assumed that all 32 bit pix have 3 spp.If there is
        ///          a valid alpha channel, this will be set to 4 spp later.
        ///      (2) If the number of bytes to be allocated is larger than the
        /// maximum value in an int32, we can get overflow, resulting
        ///          in a smaller amount of memory actually being allocated.
        ///          Later, an attempt to access memory that wasn't allocated will
        ///          cause a crash.So to avoid crashing a program (or worse)
        ///          with bad(or malicious) input, this is where we limit the
        ///          requested allocation of image data in a typesafe way.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns>pixd with no data allocated, or NULL on error</returns>
        public static Pix pixCreateHeader(int width, int height, int depth)
        {
            var pointer = Native.DllImports.pixCreateHeader(width, height, depth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) A "clone" is simply a handle(ptr) to an existing pix.
        ///          It is implemented because (a) images can be large and
        /// hence expensive to copy, and(b) extra handles to a data
        /// structure need to be made with a simple policy to avoid
        ///          both double frees and memory leaks.Pix are reference
        /// counted.The side effect of pixClone() is an increase
        ///          by 1 in the ref count.
        ///      (2) The protocol to be used is:
        ///          (a) Whenever you want a new handle to an existing image,
        ///              call pixClone(), which just bumps a ref count.
        ///          (b) Always call pixDestroy() on all handles.This
        /// decrements the ref count, nulls the handle, and
        /// only destroys the pix when pixDestroy() has been
        ///              called on all handles.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns>same pix ptr, or NULL on error</returns>
        public static Pix pixClone(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixClone((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Pix destruction
        /// <summary>
        ///      (1) Decrements the ref count and, if 0, destroys the pix.
        ///      (2) Always nulls the input ptr.
        /// </summary>
        /// <param name="ppix"></param>
        public static void pixDestroy(this Pix ppix)
        {
            if (null == ppix)
            {
                throw new ArgumentNullException("ppix cannot be null");
            }

            var pointer = (IntPtr)ppix;
            Native.DllImports.pixDestroy(ref pointer);
            ppix = null;
        }

        // Pix copy
        /// <summary>
        ///      (1) There are three cases:
        ///            (a) pixd == null  (makes a new pix; refcount = 1)
        ///            (b) pixd == pixs(no-op)
        ///            (c) pixd != pixs(data copy; no change in refcount)
        ///          If the refcount of pixd > 1, case (c) will side-effect
        /// these handles. 
        ///      (2) The general pattern of use is:
        ///             pixd = pixCopy(pixd, pixs);
        ///          This will work for all three cases.
        /// For clarity when the case is known, you can use:
        ///            (a) pixd = pixCopy(NULL, pixs);
        ///            (c) pixCopy(pixd, pixs);
        ///      (3) For case (c), we check if pixs and pixd are the same
        ///          size(w, h, d).  If so, the data is copied directly.
        ///          Otherwise, the data is reallocated to the correct size
        /// and the copy proceeds.The refcount of pixd is unchanged. 
        ///      (4) This operation, like all others that may involve a pre-existing
        /// pixd, will side-effect any existing clones of pixd.
        /// </summary>
        /// <param name="pixd">[optional]; can be null, or equal to pixs, or different from pixs</param>
        /// <param name="pixs"></param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixCopy(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCopy((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) This removes any existing image data from pixd and
        /// allocates an uninitialized buffer that will hold the
        /// amount of image data that is in pixs.
        /// </summary>
        /// <param name="pixd">gets new uninitialized buffer for image data</param>
        /// <param name="pixs">determines the size of the buffer; not changed</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixResizeImageData(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixResizeImageData((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        ///      (1) This always destroys any colormap in pixd(except if
        ///          the operation is a no-op.
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopyColormap(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopyColormap((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix1"></param>
        /// <param name="pix2"></param>
        /// <returns>true if the two pix have same {h, w, d}; false otherwise.</returns>
        public static bool pixSizesEqual(this Pix pix1, Pix pix2)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null");
            }

            return Native.DllImports.pixSizesEqual((HandleRef)pix1, (HandleRef)pix2);
        }

        /// <summary>
        ///      (1) This does a complete data transfer from pixs to pixd,
        ///          followed by the destruction of pixs(refcount permitting).
        ///      (2) If the refcount of pixs is 1, pixs is destroyed.Otherwise,
        ///          the data in pixs is copied(rather than transferred) to pixd.
        ///      (3) This operation, like all others with a pre-existing pixd,
        ///          will side-effect any existing clones of pixd.The pixd refcount does not change.
        ///      (4) When might you use this?  Suppose you have an in-place Pix
        ///          function(returning void) with the typical signature:
        ///              void function-inplace(PIX* pix, ...)
        ///          where "..." are non-pointer input parameters, and suppose
        ///          further that you sometimes want to return an arbitrary Pix
        ///          in place of the input Pix. 
        /// </summary>
        /// <param name="pixd">must be different from pixs</param>
        /// <param name="ppixs">ppixs will be nulled if refcount goes to 0</param>
        /// <param name="copytext">true to copy the text field; false to skip</param>
        /// <param name="copyformat">true to copy the informat field; false to skip</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixTransferAllData(this Pix pixd, ref Pix ppixs, bool copytext, bool copyformat)
        {
            if (null == pixd
             || null == ppixs)
            {
                throw new ArgumentNullException("pixd, ppixs cannot be null");
            }
            if (pixd == ppixs)
            {
                throw new ArgumentException("pixd cannot equals ppixs.");
            }

            IntPtr ppixsPtr = (IntPtr)ppixs;
            var result = Native.DllImports.pixTransferAllData((HandleRef)pixd, ref ppixsPtr, copytext, copyformat);
            ppixs = new Pix(ppixsPtr);

            return result;
        }

        /// <summary>
        ///      (1) Simple operation to change the handle name safely.
        ///          After this operation, the original image in pixd has
        ///          been destroyed, pixd points to what was pixs, and
        /// the input pixs ptr has been nulled.
        ///      (2) This works safely whether or not pixs and pixd are cloned.
        /// If pixs is cloned, the other handles still point to
        ///          the original image, with the ref count reduced by 1.
        /// </summary>
        /// <param name="ppixd">[optional] input pixd can be null and it must be different from pixs</param>
        /// <param name="ppixs">ppixs will be nulled after the swap</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSwapAndDestroy(ref Pix ppixd, ref Pix ppixs)
        {
            if (null == ppixs)
            {
                throw new ArgumentNullException("ppixs cannot be null");
            }
            if (null != ppixd
             && ppixd == ppixs)
            {
                throw new ArgumentException("ppixd cannot equals ppixs.");
            }

            IntPtr ppixsPtr = (IntPtr)ppixs;
            IntPtr ppixdPtr = (IntPtr)ppixd;
            var result = Native.DllImports.pixSwapAndDestroy(ref ppixdPtr, ref ppixsPtr);
            ppixs = new Pix(ppixsPtr);
            ppixd = new Pix(ppixdPtr);

            return result;
        }

        // Pix accessors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetWidth(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetWidth((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="width"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetWidth(this Pix pix, int width)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetWidth((HandleRef)pix, width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetHeight(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetHeight((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="height"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetHeight(this Pix pix, int height)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetHeight((HandleRef)pix, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetDepth(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetDepth((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="depth"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetDepth(this Pix pix, int depth)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetDepth((HandleRef)pix, depth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="pw"></param>
        /// <param name="ph"></param>
        /// <param name="pd"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetDimensions(this Pix pix, out int pw, out int ph, out int pd)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetDimensions((HandleRef)pix, out pw, out ph, out pd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="w">use 0 to skip the setting</param>
        /// <param name="h">use 0 to skip the setting</param>
        /// <param name="d">use 0 to skip the setting</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetDimensions(this Pix pix, int w, int h, int d)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetDimensions((HandleRef)pix, w, h, d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopyDimensions(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopyDimensions((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetSpp(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetSpp((HandleRef)pix);
        }

        /// <summary>
        ///      (1) For a 32 bpp pix, this can be used to ignore the
        ///          alpha sample(spp == 3) or to use it(spp == 4).
        ///          For example, to write a spp == 4 image without the alpha
        ///          sample(as an rgb pix), call pixSetSpp(pix, 3) and
        /// then write it out as a png.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="spp">(1, 3 or 4)</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetSpp(this Pix pix, int spp)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (spp != 1
             || spp != 3
             || spp != 4)
            {
                throw new ArgumentNullException("spp must be (1, 3 or 4)");
            }

            return Native.DllImports.pixSetSpp((HandleRef)pix, spp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopySpp(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopySpp((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetWpl(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetWpl((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="wpl"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetWpl(this Pix pix, int wpl)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetWpl((HandleRef)pix, wpl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetRefcount(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetRefcount((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="delta"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixChangeRefcount(this Pix pix, int delta)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixChangeRefcount((HandleRef)pix, delta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetXRes(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetXRes((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="res"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetXRes(this Pix pix, int res)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetXRes((HandleRef)pix, res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static int pixGetYRes(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetYRes((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="res"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetYRes(this Pix pix, int res)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetYRes((HandleRef)pix, res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="pxres"></param>
        /// <param name="pyres"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetResolution(this Pix pix, out int pxres, out int pyres)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetResolution((HandleRef)pix, out pxres, out pyres);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="xres">use 0 to skip the setting</param>
        /// <param name="yres">use 0 to skip the setting</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetResolution(this Pix pix, int xres, int yres)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetResolution((HandleRef)pix, xres, yres);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopyResolution(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopyResolution((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="xscale"></param>
        /// <param name="yscale"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixScaleResolution(this Pix pix, float xscale, float yscale)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixScaleResolution((HandleRef)pix, xscale, yscale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static ImageFileFormatTypes pixGetInputFormat(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetInputFormat((HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="informat"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetInputFormat(this Pix pix, ImageFileFormatTypes informat)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetInputFormat((HandleRef)pix, informat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopyInputFormat(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopyInputFormat((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="special"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetSpecial(this Pix pix, int special)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetSpecial((HandleRef)pix, special);
        }

        /// <summary>
        /// The text string belongs to the pix.  The caller must NOT free it!
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static string pixGetText(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            var pointer = Native.DllImports.pixGetText((HandleRef)pix);

            return Marshal.PtrToStringAnsi(pointer);
        }

        /// <summary>
        /// This removes any existing textstring and puts a copy of the input textstring there.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="textstring">textstring can be null</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetText(this Pix pix, string textstring)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetText((HandleRef)pix, textstring);
        }

        /// <summary>
        ///      (1) This adds the new textstring to any existing text.
        ///      (2) Either or both the existing text and the new text
        /// string can be null.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="textstring"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixAddText(this Pix pix, string textstring)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixAddText((HandleRef)pix, textstring);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd"></param>
        /// <param name="pixs"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCopyText(this Pix pixd, Pix pixs)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixCopyText((HandleRef)pixd, (HandleRef)pixs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static PixColormap pixGetColormap(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException(") cannot be null");
            }

            var pointer = Native.DllImports.pixGetColormap((HandleRef)pix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new PixColormap(pointer);
            }
        }

        /// <summary>
        ///      (1) Unlike with the pix data field, pixSetColormap() destroys
        /// any existing colormap before assigning the new one.
        ///          Because colormaps are not ref counted, it is important that
        /// the new colormap does not belong to any other pix.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="colormap">to be assigned</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetColormap(this Pix pix, PixColormap colormap)
        {
            if (null == pix
             || null == colormap)
            {
                throw new ArgumentNullException("pix, colormap cannot be null");
            }

            return Native.DllImports.pixSetColormap((HandleRef)pix, (HandleRef)colormap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixDestroyColormap(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pbox cannot be null");
            }

            return Native.DllImports.pixDestroyColormap((HandleRef)pix);
        }

        /// <summary>
        /// This gives a new handle for the data.The data is still owned by the pix, so do not call LEPT_FREE() on it.
        /// </summary>
        /// <param name="pix"></param>
        /// <returns></returns>
        public static IntPtr pixGetData(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pbox cannot be null");
            }

            return Native.DllImports.pixGetData((HandleRef)pix);
        }

        /// <summary>
        /// This does not free any existing data.  To free existing data, use pixFreeData() before pixSetData().
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="data"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSetData(this Pix pix, IntPtr data)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pbox cannot be null");
            }

            return Native.DllImports.pixSetData((HandleRef)pix, data);
        }

        /// <summary>
        ///      (1) This extracts the pix image data for use in another context.
        ///          The caller still needs to use pixDestroy() on the input pix.
        ///      (2) If refcount == 1, the data is extracted and the
        /// pix->data ptr is set to NULL. 
        ///      (3) If refcount > 1, this simply returns a copy of the data,
        ///          using the pix allocator, and leaving the input pix unchanged.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns></returns>
        public static IntPtr pixExtractData(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixExtractData((HandleRef)pixs);
        }

        /// <summary>
        ///      (1) This frees the data and sets the pix data ptr to null.
        ///          It should be used before pixSetData() in the situation where
        /// you want to free any existing data before doing
        ///          a subsequent assignment with pixSetData().
        /// </summary>
        /// <param name="pix"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFreeData(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixFreeData((HandleRef)pix);
        }

        // Pix line ptrs
        /// <summary>
        ///      (1) This is intended to be used for fast random pixel access.
        ///          For example, for an 8 bpp image, 
        ///          is equivalent to, but much faster than, 
        ///      (2) How much faster? For 1 bpp, it's from 6 to 10x faster.
        ///          For 8 bpp, it's an amazing 30x faster.  So if you are
        ///          doing random access over a substantial part of the image,
        ///          use this line ptr array.
        ///      (3) When random access is used in conjunction with a stack,
        ///          queue or heap, the overall computation time depends on
        ///          the operations performed on each struct that is popped
        /// or pushed, and whether we are using a priority queue(O(logn))
        /// or a queue or stack(O(1)).  For example, for maze search,
        /// the overall ratio of time for line ptrs vs.pixGet/Set* is
        /// Maze type Type                   Time ratio
        /// binary      queue                     0.4
        /// gray        heap(priority queue)     0.6
        ///      (4) Because this returns a void and the accessors take void,
        /// the compiler cannot check the pointer types.  It is
        ///          strongly recommended that you adopt a naming scheme for
        ///          the returned ptr arrays that indicates the pixel depth.
        ///          (This follows the original intent of Simonyi's "Hungarian"
        ///          application notation, where naming is used proactively
        ///          to make errors visibly obvious.)  By doing this, you can
        ///          tell by inspection if the correct accessor is used. 
        ///      (5) These are convenient for accessing bytes sequentially in an
        ///          8 bpp grayscale image.  People who write image processing code
        ///          on 8 bpp images are accustomed to grabbing pixels directly out
        ///          of the raster array.  Note that for little endians, you first
        ///          need to reverse the byte order in each 32-bit word.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="psize">array size, which is the pix height</param>
        /// <returns>array of line ptrs, or NULL on error</returns>
        public static IntPtr pixGetLinePtrs(this Pix pix, out int psize)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetLinePtrs((HandleRef)pix, out psize);
        }

        // Pix debug
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fp">fp file stream</param>
        /// <param name="pix"></param>
        /// <param name="text">identifying string;</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixPrintStreamInfo(IntPtr fp, Pix pix, string text)
        {
            if (null == pix
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("pix, fp cannot be null");
            }

            return Native.DllImports.pixPrintStreamInfo(fp, (HandleRef)pix, text);
        }
    }
}
