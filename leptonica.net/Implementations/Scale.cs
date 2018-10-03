using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Scale
    {
        // Top-level scaling
        /// <summary>
        /// This function scales 32 bpp RGB; 2, 4 or 8 bpp palette color;
        /// 2, 4, 8 or 16 bpp gray; and binary images.
        ///
        /// When the input has palette color, the colormap is removed and
        /// the result is either 8 bpp gray or 32 bpp RGB, depending on whether
        /// the colormap has color entries.Images with 2, 4 or 16 bpp are
        /// converted to 8 bpp.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="scalex"></param>
        /// <param name="scaley"></param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScale(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScale((HandleRef)pixs, scalex, scaley);
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
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="delw">change in width, in pixels; 0 means no change</param>
        /// <param name="delh">change in height, in pixels; 0 means no change</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleToSizeRel(this Pix pixs, int delw, int delh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleToSizeRel((HandleRef)pixs, delw, delh);
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
        /// (1) This guarantees that the output scaled image has the
        ///     dimension(s) you specify.
        ///      ~ To specify the width with isotropic scaling, set %hd = 0.
        ///      ~ To specify the height with isotropic scaling, set %wd = 0.
        ///      ~ If both %wd and %hd are specified, the image is scaled
        ///        (in general, anisotropically) to that size.
        ///      ~ It is an error to set both %wd and %hd to 0.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="wd">target width; use 0 if using height as target</param>
        /// <param name="hd">target height; use 0 if using width as target</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleToSize(this Pix pixs, int wd, int hd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleToSize((HandleRef)pixs, wd, hd);
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
        /// pixScaleToResolution()
        /// <param name="pixs"></param>
        /// <param name="target">desired resolution</param>
        /// <param name="assumed">assumed resolution if not defined; typ. 300.</param>
        /// <param name="pscalefact">[optional] actual scaling factor used</param>
        /// <returns>pixd, or NULL on error</returns>
        /// </summary>
        /// <returns></returns>
        public static Pix pixScaleToResolution(this Pix pixs, float target, float assumed, float pscalefact)
        {
            //internal static extern IntPtr pixScaleToResolution(HandleRef pixs, float target, float assumed, float pscalefact);
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleToResolution((HandleRef)pixs, target, assumed, pscalefact);
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
        /// (1) See pixScale() for usage.
        /// (2) This interface may change in the future, as other special
        ///     cases are added.
        /// (3) The actual sharpening factors used depend on the maximum
        ///     of the two scale factors (maxscale):
        ///       maxscale &lt;= 0.2:        no sharpening
        ///       0.2 &lt; maxscale &lt; 1.4:   uses the input parameters
        ///       maxscale >= 1.4:        no sharpening
        /// (4) To avoid sharpening for grayscale and color images with
        ///     scaling factors between 0.2 and 1.4, call this function
        ///     with %sharpfract == 0.0.
        /// (5) To use arbitrary sharpening in conjunction with scaling,
        ///     call this function with %sharpfract = 0.0, and follow this
        ///     with a call to pixUnsharpMasking() with your chosen parameters.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16 and 32 bpp</param>
        /// <param name="scalex">&lt; 0.0</param>
        /// <param name="scaley">&lt; 0.0</param>
        /// <param name="sharpfract">use 0.0 to skip sharpening</param>
        /// <param name="sharpwidth">halfwidth of low-pass filter; typ. 1 or 2</param>
        /// <returns></returns>
        public static Pix pixScaleGeneral(this Pix pixs, float scalex, float scaley, float sharpfract, int sharpwidth)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (0 > scalex
             || 0 > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.");
            }

            var pointer = Native.DllImports.pixScaleGeneral((HandleRef)pixs, scalex, scaley, sharpfract, sharpwidth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Linearly interpreted(usually up-) scaling
        /// <summary>
        /// (1) This function should only be used when the scale factors are
        ///     greater than or equal to 0.7, and typically greater than 1.
        ///     If either scale factor is smaller than 0.7, we issue a warning
        ///     and invoke pixScale().
        /// (2) This works on 2, 4, 8, 16 and 32 bpp images, as well as on
        ///     2, 4 and 8 bpp images that have a colormap.  If there is a
        ///     colormap, it is removed to either gray or RGB, depending
        ///     on the colormap.
        /// (3) This does a linear interpolation on the src image.
        /// (4) It dispatches to much faster implementations for
        ///     the special cases of 2x and 4x expansion.
        /// </summary>
        /// <param name="pixs">2, 4, 8 or 32 bpp; with or without colormap</param>
        /// <param name="scalex">must both be >= 0.7</param>
        /// <param name="scaley">must both be >= 0.7</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleLI(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (0.7F > scalex
             || 0.7F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.7F");
            }

            var pointer = Native.DllImports.pixScaleLI((HandleRef)pixs, scalex, scaley);
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
        /// (1) If this is used for scale factors less than 0.7,
        ///     it will suffer from antialiasing.  A warning is issued.
        ///     Particularly for document images with sharp edges,
        ///     use pixScaleSmooth() or pixScaleAreaMap() instead.
        /// (2) For the general case, it's about 4x faster to manipulate
        ///     the color pixels directly, rather than to make images
        ///     out of each of the 3 components, scale each component
        ///     using the pixScaleGrayLI(), and combine the results back
        ///     into an rgb image.
        /// (3) The speed on intel hardware for the general case (not 2x)
        ///     is about 10 * 10^6 dest-pixels/sec/GHz.  (The special 2x
        ///     case runs at about 80 * 10^6 dest-pixels/sec/GHz.)
        /// </summary>
        /// <param name="pixs">32 bpp, representing rgb</param>
        /// <param name="scalex">must both be >= 0.7</param>
        /// <param name="scaley">must both be >= 0.7</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleColorLI(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be > 32 bpp");
            }
            if (0.7F > scalex
             || 0.7F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.7F");
            }

            var pointer = Native.DllImports.pixScaleColorLI((HandleRef)pixs, scalex, scaley);
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
        /// (1) This is a special case of linear interpolated scaling,
        ///     for 2x upscaling.  It is about 8x faster than using
        ///     the generic pixScaleColorLI(), and about 4x faster than
        ///     using the special 2x scale function pixScaleGray2xLI()
        ///     on each of the three components separately.
        /// (2) The speed on intel hardware is about
        ///     80 * 10^6 dest-pixels/sec/GHz.
        /// </summary>
        /// <param name="pixs">32 bpp, representing rgb</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleColor2xLI(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be > 32 bpp");
            }

            var pointer = Native.DllImports.pixScaleColor2xLI((HandleRef)pixs);
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
        /// (1) This is a special case of color linear interpolated scaling,
        ///     for 4x upscaling.  It is about 3x faster than using
        ///     the generic pixScaleColorLI().
        /// (2) The speed on intel hardware is about
        ///     30 * 10^6 dest-pixels/sec/GHz
        /// (3) This scales each component separately, using pixScaleGray4xLI().
        ///     It would be about 4x faster to inline the color code properly,
        ///     in analogy to scaleColor4xLILow(), and I leave this as
        ///     an exercise for someone who really needs it.
        /// </summary>
        /// <param name="pixs">32 bpp, representing rgb</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleColor4xLI(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be > 32 bpp");
            }

            var pointer = Native.DllImports.pixScaleColor4xLI((HandleRef)pixs);
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
        ///  This function is appropriate for upscaling
        ///  magnification: scale factors > 1, and for a
        ///  small amount of downscaling reduction: scale
        ///  factors > 0.5.   For scale factors less than 0.5,
        ///  the best result is obtained by area mapping,
        ///  but this is very expensive.  So for such large
        ///  reductions, it is more appropriate to do low pass
        ///  filtering followed by subsampling, a combination
        ///  which is effectively a cheap form of area mapping.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale, no cmap</param>
        /// <param name="scalex">must both be >= 0.7</param>
        /// <param name="scaley">must both be >= 0.7</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleGrayLI(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be colormapped.");
            }
            if (0.7F > scalex
             || 0.7F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.7F");
            }

            var pointer = Native.DllImports.pixScaleGrayLI((HandleRef)pixs, scalex, scaley);
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
        /// (1) This is a special case of gray linear interpolated scaling,
        ///     for 2x upscaling.  It is about 6x faster than using
        ///     the generic pixScaleGrayLI().
        /// (2) The speed on intel hardware is about
        ///     100 * 10^6 dest-pixels/sec/GHz
        /// </summary>
        /// <param name="pixs">8 bpp grayscale, not cmapped</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleGray2xLI(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be > 8 bpp");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be colormapped.");
            }

            var pointer = Native.DllImports.pixScaleGray2xLI((HandleRef)pixs);
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
        /// (1) This is a special case of gray linear interpolated scaling,
        ///     for 4x upscaling.  It is about 12x faster than using
        ///     the generic pixScaleGrayLI().
        /// (2) The speed on intel hardware is about
        ///     160 * 10^6 dest-pixels/sec/GHz.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale, not cmapped</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleGray4xLI(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be > 8 bpp");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be colormapped.");
            }

            var pointer = Native.DllImports.pixScaleGray4xLI((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Scaling by closest pixel sampling
        /// <summary>
        /// (1) This function samples from the source without
        ///     filtering.  As a result, aliasing will occur for
        ///     subsampling (%scalex and/or %scaley &lt; 1.0).
        /// (2) If %scalex == 1.0 and %scaley == 1.0, returns a copy.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="scalex">both > 0.0</param>
        /// <param name="scaley">both > 0.0</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleBySampling(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (0F > scalex
             || 0F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0F");
            }

            var pointer = Native.DllImports.pixScaleBySampling((HandleRef)pixs, scalex, scaley);
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
        /// (1) This guarantees that the output scaled image has the
        ///     dimension(s) you specify.
        ///      ~ To specify the width with isotropic scaling, set %hd = 0.
        ///      ~ To specify the height with isotropic scaling, set %wd = 0.
        ///      ~ If both %wd and %hd are specified, the image is scaled
        ///        (in general, anisotropically) to that size.
        ///      ~ It is an error to set both %wd and %hd to 0.
        /// </summary>
        /// <param name="pixs"1, 2, 4, 8, 16 and 32 bpp></param>
        /// <param name="wd">target width; use 0 if using height as target</param>
        /// <param name="hd">target height; use 0 if using width as target</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleBySamplingToSize(this Pix pixs, int wd, int hd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleBySamplingToSize((HandleRef)pixs, wd, hd);
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
        /// (1) Simple interface to pixScaleBySampling(), for
        ///     isotropic integer reduction.
        /// (2) If %factor == 1, returns a copy.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="factor">integer subsampling</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleByIntSampling(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleByIntSampling((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Fast integer factor subsampling RGB to gray and to binary
        /// <summary>
        /// (1) This does simultaneous subsampling by an integer factor and
        ///     extraction of the color from the RGB pix.
        /// (2) It is designed for maximum speed, and is used for quickly
        ///     generating a downsized grayscale image from a higher resolution
        ///     RGB image.  This would typically be used for image analysis.
        /// (3) The standard color byte order (RGBA) is assumed.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="factor">integer reduction factor >= 1</param>
        /// <param name="color">one of COLOR_RED, COLOR_GREEN, COLOR_BLUE</param>
        /// <returns>8 bpp, or NULL on error</returns>
        public static Pix pixScaleRGBToGrayFast(this Pix pixs, int factor, ColorsFor32Bpp color)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp");
            }
            if (1 > factor)
            {
                throw new ArgumentException("factor must be > 1");
            }

            var pointer = Native.DllImports.pixScaleRGBToGrayFast((HandleRef)pixs, factor, color);
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
        /// (1) This does simultaneous subsampling by an integer factor and
        ///     conversion from RGB to gray to binary.
        /// (2) It is designed for maximum speed, and is used for quickly
        ///     generating a downsized binary image from a higher resolution
        ///     RGB image.  This would typically be used for image analysis.
        /// (3) It uses the green channel to represent the RGB pixel intensity.
        /// </summary>
        /// <param name="pixs">32 bpp RGB</param>
        /// <param name="factor">integer reduction factor >= 1</param>
        /// <param name="thresh">binarization threshold</param>
        /// <returns>pixd 1 bpp, or NULL on error</returns>
        public static Pix pixScaleRGBToBinaryFast(this Pix pixs, int factor, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp");
            }
            if (1 > factor)
            {
                throw new ArgumentException("factor must be > 1");
            }

            var pointer = Native.DllImports.pixScaleRGBToBinaryFast((HandleRef)pixs, factor, thresh);
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
        /// (1) This does simultaneous subsampling by an integer factor and
        ///     thresholding from gray to binary.
        /// (2) It is designed for maximum speed, and is used for quickly
        ///     generating a downsized binary image from a higher resolution
        ///     gray image.  This would typically be used for image analysis.
        /// </summary>
        /// <param name="pixs">8 bpp grayscale</param>
        /// <param name="factor">integer reduction factor >= 1</param>
        /// <param name="thresh">binarization threshold</param>
        /// <returns>pixd 1 bpp, or NULL on error</returns>
        public static Pix pixScaleGrayToBinaryFast(this Pix pixs, int factor, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp");
            }
            if (1 > factor)
            {
                throw new ArgumentException("factor must be > 1");
            }

            var pointer = Native.DllImports.pixScaleGrayToBinaryFast((HandleRef)pixs, factor, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Downscaling with(antialias) smoothing
        /// <summary>
        /// (1) This function should only be used when the scale factors are less
        ///     than or equal to 0.7 (i.e., more than about 1.42x reduction).
        ///     If either scale factor is larger than 0.7, we issue a warning
        ///     and invoke pixScale().
        /// (2) This works only on 2, 4, 8 and 32 bpp images, and if there is
        ///     a colormap, it is removed by converting to RGB.  In other
        ///     cases, we issue a warning and invoke pixScale().
        /// (3) It does simple (flat filter) convolution, with a filter size
        ///     commensurate with the amount of reduction, to avoid antialiasing.
        /// (4) It does simple subsampling after smoothing, which is appropriate
        ///     for this range of scaling.  Linear interpolation gives essentially
        ///     the same result with more computation for these scale factors,
        ///     so we don't use it.
        /// (5) The result is the same as doing a full block convolution followed by
        ///     subsampling, but this is faster because the results of the block
        ///     convolution are only computed at the subsampling locations.
        ///     In fact, the computation time is approximately independent of
        ///     the scale factor, because the convolution kernel is adjusted
        ///     so that each source pixel is summed approximately once.
        /// </summary>
        /// <param name="pix">2, 4, 8 or 32 bpp; and 2, 4, 8 bpp with colormap</param>
        /// <param name="scalex">must both be &lt; 0.7</param>
        /// <param name="scaley">must both be &lt; 0.7</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleSmooth(this Pix pix, float scalex, float scaley)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (0.7F > scalex
             || 0.7F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.7");
            }

            var pointer = Native.DllImports.pixScaleSmooth((HandleRef)pix, scalex, scaley);
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
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="rwt">must sum to 1.0</param>
        /// <param name="gwt">must sum to 1.0</param>
        /// <param name="bwt">must sum to 1.0</param>
        /// <returns>pixd, 8 bpp, 2x reduced, or NULL on error</returns>
        public static Pix pixScaleRGBToGray2(this Pix pixs, float rwt, float gwt, float bwt)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp");
            }
            if (1F != rwt + gwt + bwt)
            {
                throw new ArgumentException("rwt + gwt + bwt must sum to 1.0");
            }

            var pointer = Native.DllImports.pixScaleRGBToGray2((HandleRef)pixs, rwt, gwt, bwt);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Downscaling with(antialias) area mapping
        /// <summary>
        /// (1) This function should only be used when the scale factors are less
        ///     than or equal to 0.7 (i.e., more than about 1.42x reduction).
        ///     If either scale factor is larger than 0.7, we issue a warning
        ///     and invoke pixScale().
        /// (2) This works only on 2, 4, 8 and 32 bpp images.  If there is
        ///     a colormap, it is removed by converting to RGB.  In other
        ///     cases, we issue a warning and invoke pixScale().
        /// (3) It does a relatively expensive area mapping computation, to
        ///     avoid antialiasing.  It is about 2x slower than pixScaleSmooth(),
        ///     but the results are much better on fine text.
        /// (4) This is typically about 20% faster for the special cases of
        ///     2x, 4x, 8x and 16x reduction.
        /// (5) Surprisingly, there is no speedup (and a slight quality
        ///     impairment) if you do as many successive 2x reductions as
        ///     possible, ending with a reduction with a scale factor larger
        ///     than 0.5.
        /// </summary>
        /// <param name="pix">2, 4, 8 or 32 bpp; and 2, 4, 8 bpp with colormap</param>
        /// <param name="scalex">must both be <= 0.7</param>
        /// <param name="scaley">must both be <= 0.7</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleAreaMap(this Pix pix, float scalex, float scaley)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (0.7F > scalex
             || 0.7F > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0.7");
            }

            var pointer = Native.DllImports.pixScaleAreaMap((HandleRef)pix, scalex, scaley);
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
        /// (1) This function does an area mapping (average) for 2x
        ///     reduction.
        /// (2) This works only on 2, 4, 8 and 32 bpp images.  If there is
        ///     a colormap, it is removed by converting to RGB.
        /// (3) Speed on 3 GHz processor:
        ///        Color: 160 Mpix/sec
        ///        Gray: 700 Mpix/sec
        ///     This contrasts with the speed of the general pixScaleAreaMap():
        ///        Color: 35 Mpix/sec
        ///        Gray: 50 Mpix/sec
        /// (4) From (3), we see that this special function is about 4.5x
        ///     faster for color and 14x faster for grayscale
        /// (5) Consequently, pixScaleAreaMap2() is incorporated into the
        ///     general area map scaling function, for the special cases
        ///     of 2x, 4x, 8x and 16x reduction.
        /// </summary>
        /// <param name="pix">2, 4, 8 or 32 bpp; and 2, 4, 8 bpp with colormap</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleAreaMap2(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixScaleAreaMap2((HandleRef)pix);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Binary scaling by closest pixel sampling
        /// <summary>
        /// (1) This function samples from the source without
        ///     filtering.  As a result, aliasing will occur for
        ///     subsampling (scalex and scaley < 1.0).
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="scalex">both > 0.0</param>
        /// <param name="scaley">both > 0.0</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixScaleBinary(this Pix pixs, float scalex, float scaley)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }
            if (0 > scalex
             || 0 > scaley)
            {
                throw new ArgumentException("scalex, scaley must be > 0");
            }

            var pointer = Native.DllImports.pixScaleBinary((HandleRef)pixs, scalex, scaley);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Scale-to-gray(1 bpp --> 8 bpp; arbitrary downscaling)
        /// <summary>
        ///  For faster scaling in the range of scalefactors from 0.0625 to 0.5,
        ///  with very little difference in quality, use pixScaleToGrayFast().
        ///
        ///  Binary images have sharp edges, so they intrinsically have very
        ///  high frequency content.  To avoid aliasing, they must be low-pass
        ///  filtered, which tends to blur the edges.  How can we keep relatively
        ///  crisp edges without aliasing?  The trick is to do binary upscaling
        ///  followed by a power-of-2 scaleToGray.  For large reductions, where
        ///  you don't end up with much detail, some corners can be cut.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="scalefactor">reduction: must be > 0.0 and &lt; 1.0</param>
        /// <returns>pixd 8 bpp, scaled down by scalefactor in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray(this Pix pixs, float scalefactor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }
            if (0F > scalefactor
             || 1F < scalefactor)
            {
                throw new ArgumentException("must be > 0.0 and < 1.0");
            }

            var pointer = Native.DllImports.pixScaleToGray((HandleRef)pixs, scalefactor);
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
        /// (1) See notes in pixScaleToGray() for the basic approach.
        /// (2) This function is considerably less expensive than pixScaleToGray()
        ///     for scalefactor in the range (0.0625 ... 0.5), and the
        ///     quality is nearly as good.
        /// (3) Unlike pixScaleToGray(), which does binary upscaling before
        ///     downscaling for scale factors >= 0.0625, pixScaleToGrayFast()
        ///     first downscales in binary for all scale factors &lt; 0.5, and
        ///     then does a 2x scale-to-gray as the final step.  For
        ///     scale factors &lt; 0.0625, both do a 16x scale-to-gray, followed
        ///     by further grayscale reduction.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="scalefactor">reduction: must be > 0.0 and < 1.0</param>
        /// <returns>pixd 8 bpp, scaled down by scalefactor in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGrayFast(this Pix pixs, float scalefactor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }
            if (0F > scalefactor
             || 1F < scalefactor)
            {
                throw new ArgumentException("must be > 0.0 and < 1.0");
            }

            var pointer = Native.DllImports.pixScaleToGrayFast((HandleRef)pixs, scalefactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Scale-to-gray(1 bpp --> 8 bpp; integer downscaling)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 2x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray2(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray2((HandleRef)pixs);
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
        /// (1) Speed is about 100 x 10^6 src-pixels/sec/GHz.
        ///     Another way to express this is it processes 1 src pixel
        ///     in about 10 cycles.
        /// (2) The width of pixd is truncated is truncated to a factor of 8.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 3x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray3(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray3((HandleRef)pixs);
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
        /// The width of pixd is truncated is truncated to a factor of 2.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 4x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray4(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray4((HandleRef)pixs);
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
        /// The width of pixd is truncated is truncated to a factor of 8.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 6x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray6(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray6((HandleRef)pixs);
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
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 8x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray8(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray8((HandleRef)pixs);
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
        /// <param name="pixs">1 bpp</param>
        /// <returns>pixd 8 bpp, scaled down by 16x in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGray16(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixScaleToGray16((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Scale-to-gray by mipmap(1 bpp --> 8 bpp, arbitrary reduction)
        /// <summary>
        ///  This function is here mainly for pedagogical reasons.
        ///  Mip-mapping is widely used in graphics for texture mapping, because
        ///  the texture changes smoothly with scale.  This is accomplished by
        ///  constructing a multiresolution pyramid and, for each pixel,
        ///  doing a linear interpolation between corresponding pixels in
        ///  the two planes of the pyramid that bracket the desired resolution.
        ///  The computation is very efficient, and is implemented in hardware
        ///  in high-end graphics cards.
        ///
        ///  We can use mip-mapping for scale-to-gray by using two scale-to-gray
        ///  reduced images (we don't need the entire pyramid) selected from
        ///  the set {2x, 4x, ... 16x}, and interpolating.  However, we get
        ///  severe aliasing, probably because we are subsampling from the
        ///  higher resolution image.  The method is very fast, but the result
        ///  is very poor.  In fact, the results don't look any better than
        ///  either subsampling off the higher-res grayscale image or oversampling
        ///  on the lower-res image.  Consequently, this method should NOT be used
        ///  for generating reduced images, scale-to-gray or otherwise.

        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="scalefactor">reduction: must be > 0.0 and < 1.0</param>
        /// <returns>pixd 8 bpp, scaled down by scalefactor in each direction, or NULL on error.</returns>
        public static Pix pixScaleToGrayMipmap(this Pix pixs, float scalefactor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }
            if (0F > scalefactor
             || 1F < scalefactor)
            {
                throw new ArgumentException("must be > 0.0 and < 1.0");
            }

            var pointer = Native.DllImports.pixScaleToGrayMipmap((HandleRef)pixs, scalefactor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Grayscale scaling using mipmap
        /// <summary>
        /// (1) See notes in pixScaleToGrayMipmap().
        /// (2) This function suffers from aliasing effects that are
        ///     easily seen in document images.
        /// </summary>
        /// <param name="pixs1">high res 8 bpp, no cmap</param>
        /// <param name="pixs2">low res -- 2x reduced -- 8 bpp, no cmap</param>
        /// <param name="scale">reduction with respect to high res image, > 0.5</param>
        /// <returns>8 bpp pix, scaled down by reduction in each direction, or NULL on error.</returns>
        public static Pix pixScaleMipmap(this Pix pixs1, Pix pixs2, float scale)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null.");
            }
            if (8 != pixs1.Depth
             || 8 != pixs2.Depth)
            {
                throw new ArgumentException("pixs1, pixs2 must be 8 bpp.");
            }
            if (null != pixs1.Colormap
             || null != pixs2.Colormap)
            {
                throw new ArgumentException("pixs1, pixs2 must not be color mapped.");
            }
            if (0.5F < scale)
            {
                throw new ArgumentException("must be > 0.5");
            }

            var pointer = Native.DllImports.pixScaleMipmap((HandleRef)pixs1, (HandleRef)pixs2, scale);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Replicated(integer) expansion(all depths)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="factor">factor integer scale factor for replicative expansion</param>
        /// <returns>pixd scaled up, or NULL on error.</returns>
        public static Pix pixExpandReplicate(this Pix pixs, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExpandReplicate((HandleRef)pixs, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Upscale 2x followed by binarization
        /// <summary>
        /// (1) This does 2x upscale on pixs, using linear interpolation,
        ///     followed by thresholding to binary.
        /// (2) Buffers are used to avoid making a large grayscale image.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <param name="thresh">between 0 and 256</param>
        /// <returns>pixd 1 bpp, or NULL on error</returns>
        public static Pix pixScaleGray2xLIThresh(this Pix pixs, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }
            if (0 > thresh
           || 256 < thresh)
            {
                throw new ArgumentException("thres must be between 0 and 256");
            }

            var pointer = Native.DllImports.pixScaleGray2xLIThresh((HandleRef)pixs, thresh);
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
        /// (1) This does 2x upscale on pixs, using linear interpolation,
        ///     followed by Floyd-Steinberg dithering to binary.
        /// (2) Buffers are used to avoid making a large grayscale image.
        ///     ~ Two line buffers are used for the src, required for the 2x
        ///       LI upscale.
        ///     ~ Three line buffers are used for the intermediate image.
        ///       Two are filled with each 2xLI row operation; the third is
        ///       needed because the upscale and dithering ops are out of sync.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <returns>1 bpp, or NULL on error</returns>
        public static Pix pixScaleGray2xLIDither(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGray2xLIDither((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Upscale 4x followed by binarization
        /// <summary>
        /// (1) This does 4x upscale on pixs, using linear interpolation,
        ///     followed by thresholding to binary.
        /// (2) Buffers are used to avoid making a large grayscale image.
        /// (3) If a full 4x expanded grayscale image can be kept in memory,
        ///     this function is only about 10% faster than separately doing
        ///     a linear interpolation to a large grayscale image, followed
        ///     by thresholding to binary.
        /// </summary>
        /// <param name="pixs">8 bpp</param>
        /// <param name="thresh">between 0 and 256</param>
        /// <returns>pixd 1 bpp, or NULL on error</returns>
        public static Pix pixScaleGray4xLIThresh(this Pix pixs, int thresh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (0 > thresh
           || 256 < thresh)
            {
                throw new ArgumentException("thres must be between 0 and 256");
            }

            var pointer = Native.DllImports.pixScaleGray4xLIThresh((HandleRef)pixs, thresh);
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
        ///  (1) This does 4x upscale on pixs, using linear interpolation,
        ///      followed by Floyd-Steinberg dithering to binary.
        ///  (2) Buffers are used to avoid making a large grayscale image.
        ///      ~ Two line buffers are used for the src, required for the
        ///        4xLI upscale.
        ///      ~ Five line buffers are used for the intermediate image.
        ///        Four are filled with each 4xLI row operation; the fifth
        ///        is needed because the upscale and dithering ops are
        ///        out of sync.
        ///  (3) If a full 4x expanded grayscale image can be kept in memory,
        ///      this function is only about 5% faster than separately doing
        ///      a linear interpolation to a large grayscale image, followed
        ///      by error-diffusion dithering to binary.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <returns>pixd 1 bpp, or NULL on error</returns>
        public static Pix pixScaleGray4xLIDither(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGray4xLIDither((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Grayscale downscaling using min and max
        /// <summary>
        /// (1) The downscaled pixels in pixd are the min, max or (max - min)
        ///     of the corresponding set of xfact * yfact pixels in pixs.
        /// (2) Using L_CHOOSE_MIN is equivalent to a grayscale erosion,
        ///     using a brick Sel of size (xfact * yfact), followed by
        ///     subsampling within each (xfact * yfact) cell.  Using
        ///     L_CHOOSE_MAX is equivalent to the corresponding dilation.
        /// (3) Using L_CHOOSE_MAXDIFF finds the difference between max
        ///     and min values in each cell.
        /// (4) For the special case of downscaling by 2x in both directions,
        ///     pixScaleGrayMinMax2() is about 2x more efficient.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <param name="xfact">x downscaling factor; integer</param>
        /// <param name="yfact">y downscaling factor; integer</param>
        /// <param name="type">L_CHOOSE_MIN, L_CHOOSE_MAX, L_CHOOSE_MAXDIFF</param>
        /// <returns>pixd 8 bpp</returns>
        public static Pix pixScaleGrayMinMax(this Pix pixs, int xfact, int yfact, MinMaxSelectionFlags type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGrayMinMax((HandleRef)pixs, xfact, yfact, type);
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
        /// (1) Special version for 2x reduction.  The downscaled pixels
        ///     in pixd are the min, max or (max - min) of the corresponding
        ///     set of 4 pixels in pixs.
        /// (2) The max and min operations are a special case (for levels 1
        ///     and 4) of grayscale analog to the binary rank scaling operation
        ///     pixReduceRankBinary2().  Note, however, that because of
        ///     the photometric definition that higher gray values are
        ///     lighter, the erosion-like L_CHOOSE_MIN will darken
        ///     the resulting image, corresponding to a threshold level 1
        ///     in the binary case.  Likewise, L_CHOOSE_MAX will lighten
        ///     the pixd, corresponding to a threshold level of 4.
        /// (3) To choose any of the four rank levels in a 2x grayscale
        ///     reduction, use pixScaleGrayRank2().
        /// (4) This runs at about 70 MPix/sec/GHz of source data for
        ///     erosion and dilation.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <param name="type">L_CHOOSE_MIN, L_CHOOSE_MAX, L_CHOOSE_MAXDIFF</param>
        /// <returns>pixd 8 bpp downscaled by 2x</returns>
        public static Pix pixScaleGrayMinMax2(this Pix pixs, MinMaxSelectionFlags type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGrayMinMax2((HandleRef)pixs, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Grayscale downscaling using rank value
        /// <summary>
        /// (1) This performs up to four cascaded 2x rank reductions.
        /// (2) Use level = 0 to truncate the cascade.
        /// </summary>
        /// <param name="pixs">8 bpp, not cmapped</param>
        /// <param name="level1">rank thresholds, in set {0, 1, 2, 3, 4}</param>
        /// <param name="level2">rank thresholds, in set {0, 1, 2, 3, 4}</param>
        /// <param name="level3">rank thresholds, in set {0, 1, 2, 3, 4}</param>
        /// <param name="level4">rank thresholds, in set {0, 1, 2, 3, 4}</param>
        /// <returns>pixd 8 bpp, downscaled by up to 16x</returns>
        public static Pix pixScaleGrayRankCascade(this Pix pixs, int level1, int level2, int level3, int level4)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGrayRankCascade((HandleRef)pixs, level1, level2, level3, level4);
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
        /// (1) Rank 2x reduction.  If rank == 1(4), the downscaled pixels
        ///     in pixd are the min(max) of the corresponding set of
        ///     4 pixels in pixs.  Values 2 and 3 are intermediate.
        /// (2) This is the grayscale analog to the binary rank scaling operation
        ///     pixReduceRankBinary2().  Here, because of the photometric
        ///     definition that higher gray values are lighter, rank 1 gives
        ///     the darkest pixel, whereas rank 4 gives the lightest pixel.
        ///     This is opposite to the binary rank operation.
        /// (3) For rank = 1 and 4, this calls pixScaleGrayMinMax2(),
        ///     which runs at about 70 MPix/sec/GHz of source data.
        ///     For rank 2 and 3, this runs 3x slower, at about 25 MPix/sec/GHz.
        /// </summary>
        /// <param name="pixs">8 bpp, no cmap</param>
        /// <param name="rank">1 (darkest), 2, 3, 4 (lightest)</param>
        /// <returns>pixd 8 bpp, downscaled by 2x</returns>
        public static Pix pixScaleGrayRank2(this Pix pixs, int rank)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs must not be color mapped.");
            }

            var pointer = Native.DllImports.pixScaleGrayRank2((HandleRef)pixs, rank);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Helper function for transferring alpha with scaling
        /// <summary>
        /// This scales the alpha component of pixs and inserts into pixd.
        /// </summary>
        /// <param name="pixs">32 bpp, original unscaled image</param>
        /// <param name="pixd">32 bpp, scaled image</param>
        /// <param name="scalex">both > 0.0</param>
        /// <param name="scaley">both > 0.0</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixScaleAndTransferAlpha(this Pix pixs, Pix pixd, float scalex, float scaley)
        {
            if (null == pixs
             || null == pixd)
            {
                throw new ArgumentNullException("pixs, pixd cannot be null.");
            }
            if (32 != pixs.Depth
             || 32 != pixd.Depth)
            {
                throw new ArgumentException("pixs, pixd must be 32 bpp.");
            }
            if (0 > scalex
             || 0 > scaley)
            {
                throw new ArgumentException("scalex, scaley must > 0.");
            }

            return Native.DllImports.pixScaleAndTransferAlpha((HandleRef)pixd, (HandleRef)pixs, scalex, scaley);
        }


        // RGB scaling including alpha(blend) component
        /// <summary>
        /// (1) The alpha channel is transformed separately from pixs,
        ///     and aligns with it, being fully transparent outside the
        ///     boundary of the transformed pixs.  For pixels that are fully
        ///     transparent, a blending function like pixBlendWithGrayMask()
        ///     will give zero weight to corresponding pixels in pixs.
        /// (2) Scaling is done with area mapping or linear interpolation,
        ///     depending on the scale factors.  Default sharpening is done.
        /// (3) If pixg is NULL, it is generated as an alpha layer that is
        ///     partially opaque, using %fract.  Otherwise, it is cropped
        ///     to pixs if required, and %fract is ignored.  The alpha
        ///     channel in pixs is never used.
        /// (4) Colormaps are removed to 32 bpp.
        /// (5) The default setting for the border values in the alpha channel
        ///     is 0 (transparent) for the outermost ring of pixels and
        ///     (0.5 * fract * 255) for the second ring.  When blended over
        ///     a second image, this
        ///     (a) shrinks the visible image to make a clean overlap edge
        ///         with an image below, and
        ///     (b) softens the edges by weakening the aliasing there.
        ///     Use l_setAlphaMaskBorder() to change these values.
        /// (6) A subtle use of gamma correction is to remove gamma correction
        ///     before scaling and restore it afterwards.  This is done
        ///     by sandwiching this function between a gamma/inverse-gamma
        ///     photometric transform:
        ///         pixt = pixGammaTRCWithAlpha(NULL, pixs, 1.0 / gamma, 0, 255);
        ///         pixd = pixScaleWithAlpha(pixt, scalex, scaley, NULL, fract);
        ///         pixGammaTRCWithAlpha(pixd, pixd, gamma, 0, 255);
        ///         pixDestroy(&pixt);
        ///     This has the side-effect of producing artifacts in the very
        ///     dark regions.
        /// </summary>
        /// <param name="pixs">32 bpp rgb or cmapped</param>
        /// <param name="scalex">must be > 0.0</param>
        /// <param name="scaley">must be > 0.0</param>
        /// <param name="pixg">8 bpp, can be null</param>
        /// <param name="fract">between 0.0 and 1.0, with 0.0 fully transparent and 1.0 fully opaque</param>
        /// <returns>pixd 32 bpp rgba, or NULL on error</returns>
        public static Pix pixScaleWithAlpha(this Pix pixs, float scalex, float scaley, Pix pixg, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp.");
            }
            if (0 > scalex
             || 0 > scaley)
            {
                throw new ArgumentException("scalex, scaley must > 0.");
            }
            if (1 < fract
             || 0 < fract)
            {
                throw new ArgumentException("fract > between 0.0 and 1.0");
            }
            if (null != pixg
                && 8 != pixg.Depth)
            {
                throw new ArgumentException("pixg must be 8 bpp.");
            }

            var pointer = Native.DllImports.pixScaleWithAlpha((HandleRef)pixs, scalex, scaley, (HandleRef)pixg, fract);
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
