using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class AdaptMap
    {
        // Clean background to white using background normalization  
        /// <summary>
        ///    (1) This is a simplified interface for cleaning an image.
        /// For comparison, see pixAdaptThresholdToBinaryGen().
        ///    (2) The suggested default values for the input parameters are:
        ///          gamma:    1.0  (reduce this to increase the contrast; e.g.,
        ///                          for light text)
        ///          blackval   70  (a bit more than 60)
        ///          whiteval  190  (a bit less than 200)
        /// </summary>
        /// <param name="pixs">8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="pixg">8 bpp grayscale version; can be null</param>
        /// <param name="gamma">gamma correction; must be > 0.0; typically ~1.0</param>
        /// <param name="blackval">dark value to set to black (0)</param>
        /// <param name="whiteval">light value to set to white (255)</param>
        /// <returns>pixd 8 bpp or 32 bpp rgb, or NULL on error</returns>
        public static Pix pixCleanBackgroundToWhite(this Pix pixs, Pix pixim, Pix pixg, float gamma = 1F, int blackval = 70, int whiteval = 190)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(8 == pixs.Depth
              || 32 == pixs.Depth))
            {
                throw new ArgumentNullException("pixs is not 8 bpp grayscale or 32 bpp rgb.");
            }

            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }

            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentNullException("pixg is not 8 bpp.");
            }

            if (0 > gamma)
            {
                throw new ArgumentNullException("gamma is not > 0.");
            }

            var pointer = Native.DllImports.pixCleanBackgroundToWhite((HandleRef)pixs, (HandleRef)pixim, (HandleRef)pixg, gamma, blackval, whiteval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Adaptive background normalization (top-level functions) 
        /// <summary>
        /// (1) This is a simplified interface to pixBackgroundNorm(),
        ///     where seven parameters are defaulted.
        /// (2) The input image is either grayscale or rgb.
        /// (3) See pixBackgroundNorm() for usage and function.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="pixg">8 bpp grayscale version; can be null</param>
        /// <returns>pixd 8 bpp or 32 bpp rgb, or NULL on error</returns>
        public static Pix pixBackgroundNormSimple(this Pix pixs, Pix pixim, Pix pixg)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(8 == pixs.Depth
              || 32 == pixs.Depth))
            {
                throw new ArgumentNullException("pixs is not 8 bpp grayscale or 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentNullException("pixg is not 8 bpp.");
            }

            var pointer = Native.DllImports.pixBackgroundNormSimple((HandleRef)pixs, (HandleRef)pixim, (HandleRef)pixg);
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
        ///    (1) This is a top-level interface for normalizing the image intensity
        ///        by mapping the image so that the background is near the input
        ///         value 'bgval'.
        ///    (2) The input image is either grayscale or rgb.
        ///    (3) For each component in the input image, the background value
        ///        in each tile is estimated using the values in the tile that
        ///         are not part of the foreground, where the foreground is
        ///         determined by the input 'thresh' argument.
        ///    (4) An optional binary mask can be specified, with the foreground
        ///         pixels typically over image regions.The resulting background
        ///        map values will be determined by surrounding pixels that are
        ///        not under the mask foreground.The origin (0,0) of this mask
        ///        is assumed to be aligned with the origin of the input image.
        ///         This binary mask must not fully cover pixs, because then there
        ///         will be no pixels in the input image available to compute
        ///        the background.
        ///    (5) An optional grayscale version of the input pixs can be supplied.
        ///        The only reason to do this is if the input is RGB and this
        ///        grayscale version can be used elsewhere.  If the input is RGB
        ///        and this is not supplied, it is made internally using only
        ///         the green component, and destroyed after use.
        ///    (6) The dimensions of the pixel tile(sx, sy) give the amount by
        ///         by which the map is reduced in size from the input image.
        ///    (7) The threshold is used to binarize the input image, in order to
        ///         locate the foreground components.If this is set too low,
        ///         some actual foreground may be used to determine the maps;
        ///        if set too high, there may not be enough background
        ///        to determine the map values accurately.  Typically, it's
        ///        better to err by setting the threshold too high.
        ///    (8) A 'mincount' threshold is a minimum count of pixels in a
        ///        tile for which a background reading is made, in order for that
        ///        pixel in the map to be valid.  This number should perhaps be
        ///        at least 1/3 the size of the tile.
        ///    (9) A 'bgval' target background value for the normalized image.  This
        ///        should be at least 128.  If set too close to 255, some
        ///         clipping will occur in the result.
        ///         (10) Two factors, 'smoothx' and 'smoothy', are input for smoothing
        ///         the map.Each low - pass filter kernel dimension is
        ///         is 2 * (smoothing factor) +1, so a
        ///         value of 0 means no smoothing.A value of 1 or 2 is recommended.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="pixg">8 bpp grayscale version; can be null</param>
        /// <param name="sx">tile size in pixels</param>
        /// <param name="sy">tile size in pixels</param>
        /// <param name="thresh">threshold for determining foreground</param>
        /// <param name="mincount">min threshold on counts in a tile</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="smoothx">half-width of block convolution kernel width</param>
        /// <param name="smoothy">half-width of block convolution kernel height</param>
        /// <returns>8 bpp or 32 bpp rgb, or NULL on error</returns>
        public static Pix pixBackgroundNorm(this Pix pixs, Pix pixim, Pix pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(8 == pixs.Depth
              || 32 == pixs.Depth))
            {
                throw new ArgumentNullException("pixs is not 8 bpp grayscale or 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentNullException("pixg is not 8 bpp.");
            }

            var pointer = Native.DllImports.pixBackgroundNorm((HandleRef)pixs, (HandleRef)pixim, (HandleRef)pixg, sx, sy, thresh, mincount, bgval, smoothx, smoothy);
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
        ///    (1) This is a top-level interface for normalizing the image intensity
        ///        by mapping the image so that the background is near the input
        ///         value 'bgval'.
        ///    (2) The input image is either grayscale or rgb.
        ///    (3) For each component in the input image, the background value
        ///        is estimated using a grayscale closing; hence the 'Morph'
        ///        in the function name.
        ///    (4) An optional binary mask can be specified, with the foreground
        ///         pixels typically over image regions.The resulting background
        ///        map values will be determined by surrounding pixels that are
        ///        not under the mask foreground.The origin (0,0) of this mask
        ///        is assumed to be aligned with the origin of the input image.
        ///         This binary mask must not fully cover pixs, because then there
        ///         will be no pixels in the input image available to compute
        ///        the background.
        ///    (5) The map is computed at reduced size (given by 'reduction')
        ///        from the input pixs and optional pixim.  At this scale,
        ///        pixs is closed to remove the background, using a square Sel
        ///         of odd dimension.The product of reduction* size should be
        ///        large enough to remove most of the text foreground.
        ///    (6) No convolutional smoothing needs to be done on the map before
        ///         inverting it.
        ///    (7) A 'bgval' target background value for the normalized image.This
        ///         should be at least 128.  If set too close to 255, some
        ///         clipping will occur in the result.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale or 32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">bgval target bg val; typ. > 128</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixBackgroundNormMorph(this Pix pixs, Pix pixim, int reduction, int size, int bgval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(8 == pixs.Depth
              || 32 == pixs.Depth))
            {
                throw new ArgumentException("pixs is not 8 bpp grayscale or 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }
            if (2 < reduction
            || 16 > reduction)
            {
                throw new ArgumentException("reduction must be between 2 and 16.");
            }

            var pointer = Native.DllImports.pixBackgroundNormMorph((HandleRef)pixs, (HandleRef)pixim, reduction, size, bgval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Arrays of inverted background values for normalization (16 bpp)
        /// <summary>
        ///    (1) See notes in pixBackgroundNorm().
        ///    (2) This returns a 16 bpp pix that can be used by
        ///         pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///         of the input pixs.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="sx">tile size in pixels</param>
        /// <param name="sy">tile size in pixels</param>
        /// <param name="thresh">threshold for determining foreground</param>
        /// <param name="mincount">min threshold on counts in a tile</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="smoothx">half-width of block convolution kernel width</param>
        /// <param name="smoothy">half-width of block convolution kernel height</param>
        /// <param name="ppixd">16 bpp array of inverted background value</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixBackgroundNormGrayArray(this Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, ref Pix ppixd)
        {
            if (null == pixs
             || null == ppixd)
            {
                throw new ArgumentNullException("pixs, ppixd cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }

            IntPtr pointer = (IntPtr)ppixd;
            return Native.DllImports.pixBackgroundNormGrayArray((HandleRef)pixs, (HandleRef)pixim, sx, sy, thresh, mincount, bgval, smoothx, smoothy, ref pointer);
        }

        /// <summary>
        ///    (1) See notes in pixBackgroundNorm().
        ///    (2) This returns a set of three 16 bpp pix that can be used by
        ///         pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///         of each component of the input pixs.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="pixg">8 bpp grayscale version; can be null</param>
        /// <param name="sx">tile size in pixels</param>
        /// <param name="sy">tile size in pixels</param>
        /// <param name="thresh">threshold for determining foreground</param>
        /// <param name="mincount">min threshold on counts in a tile</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="smoothx">half-width of block convolution kernel width</param>
        /// <param name="smoothy">half-width of block convolution kernel height</param>
        /// <param name="ppixr">16 bpp array of inverted R background value</param>
        /// <param name="ppixg">16 bpp array of inverted G background value</param>
        /// <param name="ppixb">16 bpp array of inverted B background value</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixBackgroundNormRGBArrays(this Pix pixs, Pix pixim, Pix pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, ref Pix ppixr, ref Pix ppixg, ref Pix ppixb)
        {
            if (null == pixs
             || null == ppixr
             || null == ppixg
             || null == ppixb)
            {
                throw new ArgumentNullException("pixs, ppixr, ppixg, ppixb cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentNullException("pixg is not 8 bpp.");
            }

            IntPtr ppixrPtr = (IntPtr)ppixr;
            IntPtr ppixgPtr = (IntPtr)ppixg;
            IntPtr ppixbPtr = (IntPtr)ppixb;
            return Native.DllImports.pixBackgroundNormRGBArrays((HandleRef)pixs, (HandleRef)pixim, (HandleRef)pixg, sx, sy, thresh, mincount, bgval, smoothx, smoothy, ref ppixrPtr, ref ppixgPtr, ref ppixbPtr);
        }

        /// <summary>
        ///    (1) See notes in pixBackgroundNormMorph().
        ///    (2) This returns a 16 bpp pix that can be used by
        ///         pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///         of the input pixs.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="ppixd">16 bpp array of inverted background value</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixBackgroundNormGrayArrayMorph(this Pix pixs, Pix pixim, int reduction, int size, int bgval, ref Pix ppixd)
        {
            if (null == pixs
             || null == ppixd)
            {
                throw new ArgumentNullException("pixs, ppixd cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (2 < reduction
            || 16 > reduction)
            {
                throw new ArgumentException("reduction must be between 2 and 16.");
            }

            IntPtr pointer = (IntPtr)ppixd;
            return Native.DllImports.pixBackgroundNormGrayArrayMorph((HandleRef)pixs, (HandleRef)pixim, reduction, size, bgval, ref pointer);
        }

        /// <summary>
        ///    (1) See notes in pixBackgroundNormMorph().
        ///    (2) This returns a set of three 16 bpp pix that can be used by
        ///         pixApplyInvBackgroundGrayMap() to generate a normalized version
        ///         of each component of the input pixs.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null</param>
        /// <param name="reduction">reduction at which morph closings are done; between 2 and 16</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="ppixr">16 bpp array of inverted R background value</param>
        /// <param name="ppixg">16 bpp array of inverted G background value</param>
        /// <param name="ppixb">16 bpp array of inverted B background value</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixBackgroundNormRGBArraysMorph(this Pix pixs, Pix pixim, int reduction, int size, int bgval, ref Pix ppixr, ref Pix ppixg, ref Pix ppixb)
        {
            if (null == pixs
             || null == ppixr
             || null == ppixg
             || null == ppixb)
            {
                throw new ArgumentNullException("pixs, ppixr, ppixg, ppixb cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (2 < reduction
            || 16 > reduction)
            {
                throw new ArgumentException("reduction must be between 2 and 16.");
            }

            IntPtr ppixrPtr = (IntPtr)ppixr;
            IntPtr ppixgPtr = (IntPtr)ppixg;
            IntPtr ppixbPtr = (IntPtr)ppixb;
            return Native.DllImports.pixBackgroundNormRGBArraysMorph((HandleRef)pixs, (HandleRef)pixim, reduction, size, bgval, ref ppixrPtr, ref ppixgPtr, ref ppixbPtr);
        }

        // Measurement of local background
        /// <summary>
        /// (1) The background is measured in regions that don't have
        ///     images.It is then propagated into the image regions,
        ///     and finally smoothed in each image region.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; not cmapped</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="sx">tile size in pixels</param>
        /// <param name="sy">tile size in pixels</param>
        /// <param name="thresh">threshold for determining foreground</param>
        /// <param name="mincount">min threshold on counts in a tile</param>
        /// <param name="ppixd">8 bpp grayscale map</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetBackgroundGrayMap(this Pix pixs, Pix pixim, int sx, int sy, int thresh, int mincount, ref Pix ppixd)
        {
            if (null == pixs
             || null == ppixd)
            {
                throw new ArgumentNullException("pixs, ppixd cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }

            IntPtr pointer = (IntPtr)ppixd;
            return Native.DllImports.pixGetBackgroundGrayMap((HandleRef)pixs, (HandleRef)pixim, sx, sy, thresh, mincount, ref pointer);
        }

        /// <summary>
        /// (1) If pixg, which is a grayscale version of pixs, is provided,
        ///     use this internally to generate the foreground mask.
        ///     Otherwise, a grayscale version of pixs will be generated
        ///     from the green component only, used, and destroyed.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="pixg">8 bpp grayscale version; can be null</param>
        /// <param name="sx">tile size in pixels</param>
        /// <param name="sy">tile size in pixels</param>
        /// <param name="thresh">threshold for determining foreground</param>
        /// <param name="mincount">min threshold on counts in a tile</param>
        /// <param name="ppixmr">rgb maps</param>
        /// <param name="ppixmg">rgb maps</param>
        /// <param name="ppixmb">rgb maps</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetBackgroundRGBMap(this Pix pixs, Pix pixim, Pix pixg, int sx, int sy, int thresh, int mincount, ref Pix ppixmr, ref Pix ppixmg, ref Pix ppixmb)
        {
            if (null == pixs
             || null == ppixmr
             || null == ppixmg
             || null == ppixmb)
            {
                throw new ArgumentNullException("pixs, ppixmr, ppixmg, ppixmb cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }
            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentException("pixg is not 8 bpp.");
            }

            IntPtr ppixmrPtr = (IntPtr)ppixmr;
            IntPtr ppixmgPtr = (IntPtr)ppixmg;
            IntPtr ppixmbPtr = (IntPtr)ppixmb;
            return Native.DllImports.pixGetBackgroundRGBMap((HandleRef)pixs, (HandleRef)pixim, (HandleRef)pixg, sx, sy, thresh, mincount, ref ppixmrPtr, ref ppixmgPtr, ref ppixmbPtr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; not cmapped</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null; it should not have all foreground pixels</param>
        /// <param name="reduction">reduction factor at which closing is performed</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="ppixm">grayscale map</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetBackgroundGrayMapMorph(this Pix pixs, Pix pixim, int reduction, int size, ref Pix ppixm)
        {
            if (null == pixs
             || null == ppixm)
            {
                throw new ArgumentNullException("pixs, ppixm cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }

            IntPtr pointer = (IntPtr)ppixm;
            return Native.DllImports.pixGetBackgroundGrayMapMorph((HandleRef)pixs, (HandleRef)pixim, reduction, size, ref pointer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="pixim">1 bpp 'image' mask; can be null; it should not have all foreground pixels.</param>
        /// <param name="reduction">factor at which closing is performed</param>
        /// <param name="size">size of square Sel for the closing; use an odd number</param>
        /// <param name="ppixmr">red component map</param>
        /// <param name="ppixmg">green component map</param>
        /// <param name="ppixmb">blue component map</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetBackgroundRGBMapMorph(this Pix pixs, Pix pixim, int reduction, int size, ref Pix ppixmr, ref Pix ppixmg, ref Pix ppixmb)
        {
            if (null == pixs
             || null == ppixmr
             || null == ppixmg
             || null == ppixmb)
            {
                throw new ArgumentNullException("pixs, ppixmr, ppixmg, ppixmb cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 32 bpp rgb.");
            }
            if (null != pixim
                && 1 != pixim.Depth)
            {
                throw new ArgumentException("pixim is not 1 bpp.");
            }

            IntPtr ppixmrPtr = (IntPtr)ppixmr;
            IntPtr ppixmgPtr = (IntPtr)ppixmg;
            IntPtr ppixmbPtr = (IntPtr)ppixmb;
            return Native.DllImports.pixGetBackgroundRGBMapMorph((HandleRef)pixs, (HandleRef)pixim, reduction, size, ref ppixmrPtr, ref ppixmgPtr, ref ppixmbPtr);
        }

        /// <summary>
        ///      (1) This is an in-place operation on pix(the map).  pix is
        ///          typically a low-resolution version of some other image
        ///          from which it was derived, where each pixel in pix
        /// corresponds to a rectangular tile(say, m x n) of pixels
        ///          in the larger image.All we need to know about the larger
        ///          image is whether or not the rightmost column and bottommost
        ///          row of pixels in pix correspond to tiles that are
        ///          only partially covered by pixels in the larger image.
        ///      (2) Typically, some number of pixels in the input map are
        ///          not known, and their values must be determined by near
        /// pixels that are known.These unknown pixels are the 'holes'.
        ///          They can take on only two values, 0 and 255, and the
        ///          instruction about which to fill is given by the filltype flag.
        ///      (3) The "holes" can come from two sources.The first is when there
        ///          are not enough foreground or background pixels in a tile;
        ///          the second is when a tile is at least partially covered
        ///          by an image mask.If we're filling holes in a fg mask,
        ///          the holes are initialized to black (0) and use L_FILL_BLACK.
        /// For filling holes in a bg mask, initialize the holes to
        ///          white(255) and use L_FILL_WHITE.
        ///      (4) If w is the map width, nx = w or nx = w - 1; ditto for h and ny.
        /// </summary>
        /// <param name="pixs">pix 8 bpp; a map, with one pixel for each tile in a larger image</param>
        /// <param name="nx">number of horizontal pixel tiles that are entirely covered with pixels in the original source image</param>
        /// <param name="ny">number of vertical pixel tiles that are entirely covered with pixels in the original source image</param>
        /// <param name="filltype">L_FILL_WHITE or L_FILL_BLACK</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFillMapHoles(this Pix pixs, int nx, int ny, GrayscaleFillingFlags filltype)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }

            return Native.DllImports.pixFillMapHoles((HandleRef)pixs, nx, ny, filltype);
        }

        /// <summary>
        /// The pixel values are extended to the left and down, as required.
        /// </summary>
        /// <param name="pixs">8 bpp</param>
        /// <param name="addw">number of extra pixels horizontally to add</param>
        /// <param name="addh">number of extra pixels vertically to add</param>
        /// <returns>pixd extended with replicated pixel values, or NULL on error</returns>
        public static Pix pixExtendByReplication(this Pix pixs, int addw, int addh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }

            var pointer = Native.DllImports.pixExtendByReplication((HandleRef)pixs, addw, addh);
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
        ///      (1) The pixels in pixs corresponding to those in each
        ///          8-connected region in the mask are set to the average value.
        ///      (2) This is required for adaptive mapping to avoid the
        /// generation of stripes in the background map, due to
        ///          variations in the pixel values near the edges of mask regions.
        ///      (3) This function is optimized for background smoothing, where
        ///          there are a relatively small number of components.It will
        /// be inefficient if used where there are many small components.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; no colormap</param>
        /// <param name="pixm">1 bpp; if null, this is a no-op</param>
        /// <param name="factor">subsampling factor for getting average; >= 1</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSmoothConnectedRegions(this Pix pixs, Pix pixm, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }
            if (null != pixm
                && 1 != pixm.Depth)
            {
                throw new ArgumentNullException("pixim is not 1 bpp.");
            }
            if (1 < factor)
            {
                throw new ArgumentException("factor must be >= 1.");
            }

            return Native.DllImports.pixSmoothConnectedRegions((HandleRef)pixs, (HandleRef)pixm, factor);
        }

        // Generate inverted background map for each component 
        /// <summary>
        /// (1) bgval should typically be > 120 and< 240
        /// (2) pixd is a normalization image; the original image is
        ///   multiplied by pixd and the result is divided by 256.
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; no colormap</param>
        /// <param name="bgval">target bg val; typ. > 128</param>
        /// <param name="smoothx">smoothx half-width of block convolution kernel width</param>
        /// <param name="smoothy">smoothy half-width of block convolution kernel height</param>
        /// <returns>pixd 16 bpp, or NULL on error</returns>
        public static Pix pixGetInvBackgroundMap(this Pix pixs, int bgval, int smoothx, int smoothy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }

            var pointer = Native.DllImports.pixGetInvBackgroundMap((HandleRef)pixs, bgval, smoothx, smoothy);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Apply inverse background map to image
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">pixs 8 bpp grayscale; no colormap</param>
        /// <param name="pixm">pixm 16 bpp, inverse background map</param>
        /// <param name="sx">tile width in pixels</param>
        /// <param name="sy">tile height in pixels</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixApplyInvBackgroundGrayMap(this Pix pixs, Pix pixm, int sx, int sy)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }
            if (16 != pixm.Depth)
            {
                throw new ArgumentNullException("pixm is not 16 bpp.");
            }

            var pointer = Native.DllImports.pixApplyInvBackgroundGrayMap((HandleRef)pixs, (HandleRef)pixm, sx, sy);
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
        /// <param name="pixs">32 bpp rbg</param>
        /// <param name="pixmr">16 bpp, red inverse background map</param>
        /// <param name="pixmg">16 bpp, green inverse background map</param>
        /// <param name="pixmb">16 bpp, blue inverse background map</param>
        /// <param name="sx">tile width in pixels</param>
        /// <param name="sy">tile height in pixels</param>
        /// <returns>pixd 32 bpp rbg, or NULL on error</returns>
        public static Pix pixApplyInvBackgroundRGBMap(this Pix pixs, Pix pixmr, Pix pixmg, Pix pixmb, int sx, int sy)
        {
            if (null == pixs
             || null == pixmr
             || null == pixmg
             || null == pixmb)
            {
                throw new ArgumentNullException("pixs, pixmr, pixmg, pixmb cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 32 bpp.");
            }
            if (16 != pixmr.Depth
             || 16 != pixmg.Depth
             || 16 != pixmb.Depth)
            {
                throw new ArgumentNullException("pixmr, pixmg, pixmb is not 16 bpp.");
            }

            var pointer = Native.DllImports.pixApplyInvBackgroundRGBMap((HandleRef)pixs, (HandleRef)pixmr, (HandleRef)pixmg, (HandleRef)pixmb, sx, sy);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Apply variable map
        /// <summary>
        ///      (1) Suppose you have an image that you want to transform based
        /// on some photometric measurement at each point, such as the
        /// threshold value for binarization.Representing the photometric
        /// measurement as an image pixg, you can threshold in input image
        ///          using pixVarThresholdToBinary().  Alternatively, you can map
        /// the input image pointwise so that the threshold over the
        /// entire image becomes a constant, such as 128.  For example,
        ///          if a pixel in pixg is 150 and the target is 128, the
        /// corresponding pixel in pixs is mapped linearly to a value
        ///          (128/150) of the input value.If the resulting mapped image
        ///          pixd were then thresholded at 128, you would obtain the
        ///          same result as a direct binarization using pixg with
        /// pixVarThresholdToBinary().
        ///      (2) The sizes of pixs and pixg must be equal.
        /// </summary>
        /// <param name="pixs">8 bpp</param>
        /// <param name="pixg">8 bpp, variable map</param>
        /// <param name="target">typ. 128 for threshold</param>
        /// <returns>pixd 8 bpp, or NULL on error</returns>
        public static Pix pixApplyVariableGrayMap(this Pix pixs, Pix pixg, int target)
        {
            if (null == pixs
             || null == pixg)
            {
                throw new ArgumentNullException("pixs, pixg cannot be null.");
            }
            if (16 != pixs.Depth
             || 16 != pixg.Depth)
            {
                throw new ArgumentNullException("pixs, pixg is not 16 bpp.");
            }

            var pointer = Native.DllImports.pixApplyVariableGrayMap((HandleRef)pixs, (HandleRef)pixg, target);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Non-adaptive (global) mapping
        /// <summary>
        ///    (1) The value of pixd determines if the results are written to a
        ///        new pix(use NULL), in-place to pixs(use pixs), or to some
        /// other existing pix.
        ///    (2) This does a global normalization of an image where the
        ///        r,g,b color components are not balanced.Thus, white in pixs is
        ///        represented by a set of r, g, b values that are not all 255.
        ///    (3) The input values(rval, gval, bval) should be chosen to
        ///        represent the gray color(mapval, mapval, mapval) in src.
        /// Thus, this function will map(rval, gval, bval) to that gray color.
        ///    (4) Typically, mapval = 255, so that(rval, gval, bval)
        ///        corresponds to the white point of src.In that case, these
        ///        parameters should be chosen so that few pixels have higher values.
        ///    (5) In all cases, we do a linear TRC separately on each of the
        ///        components, saturating at 255.
        ///    (6) If the input pix is 8 bpp without a colormap, you can get
        ///        this functionality with mapval = 255 by calling:
        ///            pixGammaTRC(pixd, pixs, 1.0, 0, bgval);
        ///        where bgval is the value you want to be mapped to 255.
        ///        Or more generally, if you want bgval to be mapped to mapval:
        ///            pixGammaTRC(pixd, pixs, 1.0, 0, 255 * bgval / mapval);
        /// </summary>
        /// <param name="pixd">null, existing or equal to pixs</param>
        /// <param name="pixs">pixs 32 bpp rgb, or colormapped</param>
        /// <param name="rval">rval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="gval">gval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="bval">bval pixel values in pixs that are linearly mapped to mapval</param>
        /// <param name="mapval">use 255 for mapping to white</param>
        /// <returns>pixd 32 bpp rgb or colormapped, or NULL on error</returns>
        public static Pix pixGlobalNormRGB(this Pix pixs, Pix pixd, int rval, int gval, int bval, int mapval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 32 bpp.");
            }

            var pointer = Native.DllImports.pixGlobalNormRGB((HandleRef)pixd, (HandleRef)pixs, rval, gval, bval, mapval);
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
        ///    (1) This is a version of pixGlobalNormRGB(), where the output
        /// intensity is scaled back so that a controlled fraction of
        ///        pixel components is allowed to saturate.See comments in
        ///        pixGlobalNormRGB().
        ///    (2) The value of pixd determines if the results are written to a
        ///        new pix(use NULL), in-place to pixs(use pixs), or to some
        /// other existing pix.
        ///    (3) This does a global normalization of an image where the
        ///        r,g,b color components are not balanced.Thus, white in pixs is
        ///        represented by a set of r, g, b values that are not all 255.
        ///    (4) The input values(rval, gval, bval) can be chosen to be the
        ///        color that, after normalization, becomes white background.
        /// For images that are mostly background, the closer these values
        ///        are to the median component values, the closer the resulting
        /// background will be to gray, becoming white at the brightest places.
        ///    (5) The mapval used in pixGlobalNormRGB() is computed here to
        /// avoid saturation of any component in the image(save for a
        /// fraction of the pixels given by the input rank value).
        /// </summary>
        /// <param name="pixd">null, existing or equal to pixs</param>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="rval">rval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="gval">gval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="bval">bval pixel values in pixs that are linearly mapped to mapval; but see below</param>
        /// <param name="factor">subsampling factor; integer >= 1</param>
        /// <param name="rank">between 0.0 and 1.0; typ. use a value near 1.0</param>
        /// <returns>pixd 32 bpp rgb, or NULL on error</returns>
        public static Pix pixGlobalNormNoSatRGB(this Pix pixs, Pix pixd, int rval, int gval, int bval, int factor, float rank)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 32 bpp.");
            }
            if (1 < factor)
            {
                throw new ArgumentException("factor must be >= 1");
            }
            if (1 < rank
             || 0 > rank)
            {
                throw new ArgumentException("rank must be between 0.0 and 1.0.");
            }

            var pointer = Native.DllImports.pixGlobalNormNoSatRGB((HandleRef)pixd, (HandleRef)pixs, rval, gval, bval, factor, rank);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Adaptive threshold spread normalization
        /// <summary>
        ///      (1) The basis of this approach is the use of seed spreading
        /// on a (possibly) sparse set of estimates for the local threshold.
        ///          The resulting dense estimates are smoothed by convolution
        ///          and used to either threshold the input image or normalize it
        ///          with a local transformation that linearly maps the pixels so
        ///          that the local threshold estimate becomes constant over the
        ///          resulting image.  This approach is one of several that
        ///          have been suggested (and implemented) by Ray Smith.
        ///      (2) You can use either the Sobel or TwoSided edge filters.
        ///          The results appear to be similar, using typical values
        /// of edgethresh in the rang 10-20.
        ///      (3) To skip the trc enhancement, use gamma = 1.0, minval = 0
        /// and maxval = 255.
        ///      (4) For the normalized image pixd, each pixel is linearly mapped
        ///          in such a way that the local threshold is equal to targetthresh.
        ///      (5) The full width and height of the convolution kernel
        /// are(2 * smoothx + 1) and(2 * smoothy + 1).
        ///      (6) This function can be used with the pixtiling utility if the
        /// images are too large.See pixOtsuAdaptiveThreshold() for
        /// an example of this.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; not colormapped</param>
        /// <param name="filtertype">L_SOBEL_EDGE or L_TWO_SIDED_EDGE</param>
        /// <param name="edgethresh">threshold on magnitude of edge filter; typ 10-20</param>
        /// <param name="smoothx">half-width of convolution kernel applied to spread threshold: use 0 for no smoothing</param>
        /// <param name="smoothy">half-width of convolution kernel applied to spread threshold: use 0 for no smoothing</param>
        /// <param name="gamma">gamma correction; typ. about 0.7</param>
        /// <param name="minval">input value that gives 0 for output; typ. -25</param>
        /// <param name="maxval">input value that gives 255 for output; typ. 255</param>
        /// <param name="targetthresh">target threshold for normalization</param>
        /// <param name="ppixth">[optional] computed local threshold value</param>
        /// <param name="ppixb">[optional] thresholded normalized image</param>
        /// <param name="ppixd">[optional] normalized image</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixThresholdSpreadNorm(this Pix pixs, EdgeFilterFlags filtertype, int edgethresh, int smoothx, int smoothy, float gamma, int minval, int maxval, int targetthresh, ref Pix ppixth, ref Pix ppixb, ref Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }

            IntPtr ppixthPtr = (IntPtr)ppixth;
            IntPtr ppixbPtr = (IntPtr)ppixb;
            IntPtr ppixdPtr = (IntPtr)ppixd;

            return Native.DllImports.pixThresholdSpreadNorm((HandleRef)pixs, filtertype, edgethresh, smoothx, smoothy, gamma, minval, maxval, targetthresh, ref ppixthPtr, ref ppixbPtr, ref ppixdPtr);
        }

        // Adaptive background normalization (flexible adaptaption)
        /// <summary>
        ///      (1) This does adaptation flexibly to a quickly varying background.
        /// For that reason, all input parameters should be small.
        ///      (2) sx and sy give the tile size; they should be in [5 - 7].
        ///      (3) The full width and height of the convolution kernel
        /// are(2 * smoothx + 1) and(2 * smoothy + 1).  They
        /// should be in [1 - 2].
        ///      (4) Basin filling is used to fill the large fg regions.The
        /// parameter %delta measures the height that the black
        /// background is raised from the local minima.By raising
        ///          the background, it is possible to threshold the large
        /// fg regions to foreground.If %delta is too large,
        ///          bg regions will be lifted, causing thickening of
        /// the fg regions.Use 0 to skip.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; not colormapped</param>
        /// <param name="sx">desired tile dimensions; actual size may vary; use values between 3 and 10</param>
        /// <param name="sy">desired tile dimensions; actual size may vary; use values between 3 and 10</param>
        /// <param name="smoothx">half-width of convolution kernel applied to threshold array: use values between 1 and 3</param>
        /// <param name="smoothy">half-width of convolution kernel applied to threshold array: use values between 1 and 3</param>
        /// <param name="delta">difference parameter in basin filling; use 0 to skip</param>
        /// <returns>pixd 8 bpp, background-normalized), or NULL on error</returns>
        public static Pix pixBackgroundNormFlex(this Pix pixs, int sx, int sy, int smoothx, int smoothy, int delta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentNullException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }

            var pointer = Native.DllImports.pixBackgroundNormFlex((HandleRef)pixs, sx, sy, smoothx, smoothy, delta);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Adaptive contrast normalization
        /// <summary>
        ///      (1) This function adaptively attempts to expand the contrast
        ///          to the full dynamic range in each tile.If the contrast in
        ///          a tile is smaller than %mindiff, it uses the min and max
        ///          pixel values from neighboring tiles.It also can use
        ///          convolution to smooth the min and max values from
        ///            neighboring tiles.After all that processing, it is
        ///          possible that the actual pixel values in the tile are outside
        ///          the computed [min...max] range for local contrast
        ///          normalization.Such pixels are taken to be at either 0
        ///          (if below the min) or 255 (if above the max).
        ///      (2) pixd can be equal to pixs(in-place operation) or
        ///          null (makes a new pixd).
        ///      (3) sx and sy give the tile size; they are typically at least 20.
        ///      (4) mindiff is used to eliminate results for tiles where it is
        ///          likely that either fg or bg is missing.A value around 50
        ///          or more is reasonable.
        ///      (5) The full width and height of the convolution kernel
        ///            are(2 * smoothx + 1) and(2 * smoothy + 1).  Some smoothing
        ///          is typically useful, and we limit the smoothing half-widths
        ///            to the range from 0 to 8.
        ///      (6) A linear TRC(gamma = 1.0) is applied to increase the contrast
        ///          in each tile.The result can subsequently be globally corrected,
        ///            by applying pixGammaTRC() with arbitrary values of gamma
        ///            and the 0 and 255 points of the mapping.
        /// </summary>
        /// <param name="pixd">[optional] 8 bpp; null or equal to pixs</param>
        /// <param name="pixs">8 bpp grayscale; not colormapped</param>
        /// <param name="sx">tile dimensions</param>
        /// <param name="sy">tile dimensions</param>
        /// <param name="mindiff">minimum difference to accept as valid</param>
        /// <param name="smoothx">half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <param name="smoothy">half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <returns>pixd always</returns>
        public static Pix pixContrastNorm(this Pix pixs, Pix pixd, int sx, int sy, int mindiff, int smoothx, int smoothy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }
            if (null != pixd
                && 8 != pixd.Depth)
            {
                throw new ArgumentException("pixd is not 8 bpp.");
            }

            var pointer = Native.DllImports.pixContrastNorm((HandleRef)pixd, (HandleRef)pixs, sx, sy, mindiff, smoothx, smoothy);
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
        ///      (1) This computes filtered and smoothed values for the min and
        ///            max pixel values in each tile of the image.
        ///      (2) See pixContrastNorm() for usage.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale; not colormapped</param>
        /// <param name="sx">tile dimensions</param>
        /// <param name="sy">tile dimensions</param>
        /// <param name="mindiff">minimum difference to accept as valid</param>
        /// <param name="smoothx">half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <param name="smoothy">half-width of convolution kernel applied to min and max arrays: use 0 for no smoothing</param>
        /// <param name="ppixmin">tiled minima</param>
        /// <param name="ppixmax">tiled maxima</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixMinMaxTiles(this Pix pixs, int sx, int sy, int mindiff, int smoothx, int smoothy, ref Pix ppixmin, ref Pix ppixmax)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs is colormapped.");
            }

            IntPtr ppixminPtr = (IntPtr)ppixmin;
            IntPtr ppixmaxPtr = (IntPtr)ppixmax;

            return Native.DllImports.pixMinMaxTiles((HandleRef)pixs, sx, sy, mindiff, smoothx, smoothy, ref ppixminPtr, ref ppixmaxPtr);
        }

        /// <summary>
        /// (1) This compares corresponding pixels in pixs1 and pixs2.
        ///     When they differ by less than %mindiff, set the pixel
        ///     values to 0 in each.  Each pixel typically represents a tile
        ///     in a larger image, and a very small difference between
        ///     the min and max in the tile indicates that the min and max
        ///     values are not to be trusted.
        /// (2) If contrast (pixel difference) detection is expected to fail,
        ///     caller should check return value.
        /// </summary>
        /// <param name="pixs1">pixs1 8 bpp</param>
        /// <param name="pixs2">pixs2 8 bpp</param>
        /// <param name="mindiff">minimum difference to accept as valid</param>
        /// <returns>false if OK; true if no pixel diffs are large enough, or on error</returns>
        public static int pixSetLowContrast(this Pix pixs1, Pix pixs2, int mindiff)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs1.Depth
             || 8 != pixs2.Depth)
            {
                throw new ArgumentException("pixs1, pixs2 is not 8 bpp.");
            }

            return Native.DllImports.pixSetLowContrast((HandleRef)pixs1, (HandleRef)pixs2, mindiff);
        }

        /// <summary>
        ///      (1) pixd can be equal to pixs(in-place operation) or
        ///          null (makes a new pixd).
        ///      (2) sx and sy give the tile size; they are typically at least 20.
        ///      (3) pixmin and pixmax are generated by pixMinMaxTiles()
        ///      (4) For each tile, this does a linear expansion of the dynamic
        /// range so that the min value in the tile becomes 0 and the
        ///          max value in the tile becomes 255.
        ///      (5) The LUTs that do the mapping are generated as needed
        /// and stored for reuse in an integer array within the ptr array iaa[].
        /// </summary>
        /// <param name="pixd">[optional] 8 bpp</param>
        /// <param name="pixs">8 bpp, not colormapped</param>
        /// <param name="sx">tile dimensions</param>
        /// <param name="sy">tile dimensions</param>
        /// <param name="pixmin">pix of min values in tiles</param>
        /// <param name="pixmax">pix of max values in tiles</param>
        /// <returns>pixd always</returns>
        public static Pix pixLinearTRCTiled(this Pix pixs, Pix pixd, int sx, int sy, Pix pixmin, Pix pixmax)
        {
            if (null == pixs
             || null == pixmin
             || null == pixmax)
            {
                throw new ArgumentNullException("pixs, pixmin, pixmax cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 8 bpp.");
            }
            if (null != pixd
                && 8 != pixd.Depth)
            {
                throw new ArgumentException("pixd cannot be null.");
            }

            var pointer = Native.DllImports.pixLinearTRCTiled((HandleRef)pixd, (HandleRef)pixs, sx, sy, (HandleRef)pixmin, (HandleRef)pixmax);
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
