using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class WaterShed
    {
        // Top-level
        /// <summary>
        /// (1) It is not necessary for the fg pixels in the seed image
        ///     be at minima, or that they be isolated.  We extract a
        ///     single pixel from each connected component, and a seed
        ///     anywhere in a watershed will eventually label the watershed
        ///     when the filling level reaches it.
        /// (2) Set mindepth to some value to ignore noise in pixs that
        ///     can create small local minima.  Any watershed shallower
        ///     than mindepth, even if it has a seed, will not be saved;
        ///     It will either be incorporated in another watershed or
        ///     eliminated.
        /// </summary>
        /// <param name="pixs">8 bpp source</param>
        /// <param name="pixm">1 bpp 'marker' seed</param>
        /// <param name="mindepth">minimum depth; anything less is not saved</param>
        /// <param name="debugflag">true for debug output</param>
        /// <returns></returns>
        public static L_WShed wshedCreate(this Pix pixs, Pix pixm, int mindepth, bool debugflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }

            if (null != pixm
                && 1 != pixm.Depth)
            {
                throw new ArgumentNullException("pixm is not 1 bpp.");
            }
            var pointer = Native.DllImports.wshedCreate((HandleRef)pixs, (HandleRef)pixm, mindepth, debugflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_WShed(pointer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pwshed">will be set to null before returning</param>
        public static void wshedDestroy(this L_WShed pwshed)
        {
            if (null == pwshed)
            {
                throw new ArgumentNullException("pwshed cannot be null");
            }

            var pointer = (IntPtr)pwshed;
            Native.DllImports.wshedDestroy(ref pointer);
            pwshed = null;
        }

        /// <summary>
        /// 1 This is buggy.  It seems to locate watersheds that are
        ///     duplicates.  The watershed extraction after complete fill
        ///     grabs some regions belonging to existing watersheds.
        ///     See prog/watershedtest.c for testing.
        /// </summary>
        /// <param name="wshed">generated from wshedCreate()</param>
        /// <returns>false if OK, true on error</returns>
        public static bool wshedApply(this L_WShed wshed)
        {
            if (null == wshed)
            {
                throw new ArgumentNullException("wshed cannot be null.");
            }
            return Native.DllImports.wshedApply((HandleRef)wshed);
        }


        // Output
        /// <summary>
        ///  
        /// </summary>
        /// <param name="wshed"></param>
        /// <param name="ppixa">[optional] mask of watershed basins</param>
        /// <param name="pnalevels">[optional] watershed levels</param>
        /// <returns>false if OK, true on error</returns>
        public static bool wshedBasins(this L_WShed wshed, ref Pixa ppixa, ref Numa pnalevels)
        {
            if (null == wshed)
            {
                throw new ArgumentNullException("wshed cannot be null.");
            }

            IntPtr ppixaPtr = (IntPtr)ppixa;
            IntPtr pnalevelsPtr = (IntPtr)pnalevels;
            return Native.DllImports.wshedBasins((HandleRef)wshed, ref ppixaPtr, ref pnalevelsPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wshed"></param>
        /// <returns>pixd initial image with all basins filled, or NULL on error</returns>
        public static Pix wshedRenderFill(this L_WShed wshed)
        {
            if (null == wshed)
            {
                throw new ArgumentNullException("wshed cannot be null.");
            }

            var pointer = Native.DllImports.wshedRenderFill((HandleRef)wshed);
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
        /// 
        /// </summary>
        /// <param name="wshed"></param>
        /// <returns>pixd initial image with all basins filled, or NULL on error</returns>
        public static Pix wshedRenderColors(this L_WShed wshed)
        {
            if (null == wshed)
            {
                throw new ArgumentNullException("wshed cannot be null.");
            }

            var pointer = Native.DllImports.wshedRenderColors((HandleRef)wshed);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
    }
}
