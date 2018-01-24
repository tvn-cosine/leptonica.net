using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Affine
    {
        // Affine (3 pt) image transformation using a sampled (to nearest integer) transform on each dest point 
        /// <summary>
        /// (1) Brings in either black or white pixels from the boundary.
        /// (2) Retains colormap, which you can do for a sampled transform..
        /// (3) The 3 points must not be collinear.
        /// (4) The order of the 3 points is arbitrary; however, to compare
        ///     with the sequential transform they must be in these locations
        ///     and in this order: origin, x-axis, y-axis.
        /// (5) For 1 bpp images, this has much better quality results
        ///     than pixAffineSequential(), particularly for text.
        ///     It is about 3x slower, but does not require additional
        ///     border pixels.  The poor quality of pixAffineSequential()
        ///     is due to repeated quantized transforms.  It is strongly
        ///     recommended that pixAffineSampled() be used for 1 bpp images.
        /// (6) For 8 or 32 bpp, much better quality is obtained by the
        ///     somewhat slower pixAffinePta().  See that function
        ///     for relative timings between sampled and interpolated.
        /// (7) To repeat, use of the sequential transform,
        ///     pixAffineSequential(), for any images, is discouraged.
        /// </summary>
        /// <param name="pixs">all depths</param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineSampledPta(this Pix pixs, Pta ptad, Pta ptas, BackgroundFlags incolor)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixAffineSampledPta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);
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
        /// (1) Brings in either black or white pixels from the boundary.
        /// (2) Retains colormap, which you can do for a sampled transform..
        /// (3) For 8 or 32 bpp, much better quality is obtained by the
        ///     somewhat slower pixAffine().  See that function
        ///     for relative timings between sampled and interpolated.
        /// </summary>
        /// <param name="pixs">all depths</param>
        /// <param name="vc">vector of 6 coefficients for affine transformation</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineSampled(this Pix pixs, IntPtr vc, BackgroundFlags incolor)
        {
            if (null == pixs
             || null == vc)
            {
                throw new ArgumentNullException("pixs, vc cannot be null.");
            }

            var pointer = Native.DllImports.pixAffineSampled((HandleRef)pixs, vc, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Affine (3 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        /// <summary>
        ///  (1) Brings in either black or white pixels from the boundary
        ///  (2) Removes any existing colormap, if necessary, before transforming
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffinePta(this Pix pixs, Pta ptad, Pta ptas, BackgroundFlags incolor)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixAffinePta((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, incolor);
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
        /// (1) Brings in either black or white pixels from the boundary
        /// (2) Removes any existing colormap, if necessary, before transforming
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="vc">vector of 6 coefficients for affine transformation</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffine(this Pix pixs, IntPtr vc, BackgroundFlags incolor)
        {
            if (null == pixs
             || null == vc)
            {
                throw new ArgumentNullException("pixs, vc cannot be null.");
            }

            var pointer = Native.DllImports.pixAffine((HandleRef)pixs, vc, incolor);
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
        /// <param name="pixs">32 bpp</param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="colorval">e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffinePtaColor(this Pix pixs, Pta ptad, Pta ptas, uint colorval)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp.");
            }

            var pointer = Native.DllImports.pixAffinePtaColor((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, colorval);
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
        /// <param name="pixs">32 bpp</param>
        /// <param name="vc">vector of 6 coefficients for affine transformation</param>
        /// <param name="colorval">e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineColor(this Pix pixs, IntPtr vc, uint colorval)
        {
            if (null == pixs
             || null == vc)
            {
                throw new ArgumentNullException("pixs, vc cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp.");
            }

            var pointer = Native.DllImports.pixAffineColor((HandleRef)pixs, vc, colorval);
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
        /// <param name="pixs">8 bpp</param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="grayval">0 to bring in BLACK, 255 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffinePtaGray(this Pix pixs, Pta ptad, Pta ptas, byte grayval)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }

            var pointer = Native.DllImports.pixAffinePtaGray((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, grayval);
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
        /// <param name="pixs">8 bpp</param>
        /// <param name="vc">vector of 6 coefficients for affine transformation</param>
        /// <param name="grayval">0 to bring in BLACK, 255 for WHITE</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineGray(this Pix pixs, IntPtr vc, byte grayval)
        {
            if (null == pixs
             || null == vc)
            {
                throw new ArgumentNullException("pixs, vc cannot be null.");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 8 bpp.");
            }

            var pointer = Native.DllImports.pixAffineGray((HandleRef)pixs, vc, grayval);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Affine transform including alpha (blend) component 
        /// <summary>
        /// (1) The alpha channel is transformed separately from pixs,
        ///     and aligns with it, being fully transparent outside the
        ///     boundary of the transformed pixs.  For pixels that are fully
        ///     transparent, a blending function like pixBlendWithGrayMask()
        ///     will give zero weight to corresponding pixels in pixs.
        /// (2) If pixg is NULL, it is generated as an alpha layer that is
        ///     partially opaque, using %fract.  Otherwise, it is cropped
        ///     to pixs if required and %fract is ignored.  The alpha channel
        ///     in pixs is never used.
        /// (3) Colormaps are removed.
        /// (4) When pixs is transformed, it doesn't matter what color is brought
        ///     in because the alpha channel will be transparent (0) there.
        /// (5) To avoid losing source pixels in the destination, it may be
        ///     necessary to add a border to the source pix before doing
        ///     the affine transformation.  This can be any non-negative number.
        /// (6) The input %ptad and %ptas are in a coordinate space before
        ///     the border is added.  Internally, we compensate for this
        ///     before doing the affine transform on the image after the border
        ///     is added.
        /// (7) The default setting for the border values in the alpha channel
        ///     is 0 (transparent) for the outermost ring of pixels and
        ///     (0.5 * fract * 255) for the second ring.  When blended over
        ///     a second image, this
        ///     (a) shrinks the visible image to make a clean overlap edge
        ///         with an image below, and
        ///     (b) softens the edges by weakening the aliasing there.
        ///     Use l_setAlphaMaskBorder() to change these values.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="pixg">[optional] 8 bpp, can be null</param>
        /// <param name="fract">between 0.0 and 1.0, with 0.0 fully transparent and 1.0 fully opaque</param>
        /// <param name="border">border of pixels added to capture transformed source pixels</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffinePtaWithAlpha(this Pix pixs, Pta ptad, Pta ptas, Pix pixg, float fract, int border)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp.");
            }
            if (null != pixg
             && 8 != pixg.Depth)
            {
                throw new ArgumentException("pixg must be 8 bpp.");
            }
            if (0 > fract
             || 1 < fract)
            {
                throw new ArgumentException("fract must be between 0.0 and 1.0.");
            }

            var pointer = Native.DllImports.pixAffinePtaWithAlpha((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, (HandleRef)pixg, fract, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Affine coordinate transformation 
        /// <summary>
        ///  We have a set of six equations, describing the affine
        ///  transformation that takes 3 points ptas into 3 other
        ///  points ptad.  These equations are:
        ///
        ///          x1' = c[0]*x1 + c[1]*y1 + c[2]
        ///          y1' = c[3]*x1 + c[4]*y1 + c[5]
        ///          x2' = c[0]*x2 + c[1]*y2 + c[2]
        ///          y2' = c[3]*x2 + c[4]*y2 + c[5]
        ///          x3' = c[0]*x3 + c[1]*y3 + c[2]
        ///          y3' = c[3]*x3 + c[4]*y3 + c[5]
        ///
        ///  This can be represented as
        ///
        ///          AC = B
        ///
        ///  where B and C are column vectors
        ///
        ///          B = [ x1' y1' x2' y2' x3' y3' ]
        ///          C = [ c[0] c[1] c[2] c[3] c[4] c[5] c[6] ]
        ///
        ///  and A is the 6x6 matrix
        ///
        ///          x1   y1   1   0    0    0
        ///           0    0   0   x1   y1   1
        ///          x2   y2   1   0    0    0
        ///           0    0   0   x2   y2   1
        ///          x3   y3   1   0    0    0
        ///           0    0   0   x3   y3   1
        ///
        ///  These six equations are solved here for the coefficients C.
        ///
        ///  These six coefficients can then be used to find the dest
        ///  point x',y') corresponding to any src point (x,y, according
        ///  to the equations
        ///
        ///           x' = c[0]x + c[1]y + c[2]
        ///           y' = c[3]x + c[4]y + c[5]
        ///
        ///  that are implemented in affineXformPt.
        /// </summary>
        /// <param name="ptas">source 3 points; unprimed</param>
        /// <param name="ptad">transformed 3 points; primed</param>
        /// <param name="pvc">vector of coefficients of transform</param>
        /// <returns>false if OK; true on error</returns>
        public static bool getAffineXformCoeffs(this Pta ptas, Pta ptad, out IntPtr pvc)
        {
            if (null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("ptad, ptas cannot be null.");
            }

            return Native.DllImports.getAffineXformCoeffs((HandleRef)ptad, (HandleRef)ptas, out pvc);
        }

        /// <summary>
        /// (1) The 6 affine transform coefficients are the first
        ///     two rows of a 3x3 matrix where the last row has
        ///     only a 1 in the third column.  We invert this
        ///     using gaussjordan(), and select the first 2 rows
        ///     as the coefficients of the inverse affine transform.
        /// (2) Alternatively, we can find the inverse transform
        ///     coefficients by inverting the 2x2 submatrix,
        ///     and treating the top 2 coefficients in the 3rd column as
        ///     a RHS vector for that 2x2 submatrix.  Then the
        ///     6 inverted transform coefficients are composed of
        ///     the inverted 2x2 submatrix and the negative of the
        ///     transformed RHS vector.  Why is this so?  We have
        ///        Y = AX + R  (2 equations in 6 unknowns)
        ///     Then
        ///        X = A'Y - A'R
        ///     Gauss-jordan solves
        ///        AF = R
        ///     and puts the solution for F, which is A'R,
        ///     into the input R vector.
        /// </summary>
        /// <param name="vc">vector of 6 coefficients</param>
        /// <param name="pvci">inverted transform</param>
        /// <returns>false if OK; true on error</returns>
        public static bool affineInvertXform(IntPtr vc, out IntPtr pvci)
        {
            if (IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.affineInvertXform(vc, out pvci);
        }

        /// <summary>
        /// (1) This finds the nearest pixel coordinates of the transformed point.
        /// (2) It does not check ptrs for returned data!
        /// </summary>
        /// <param name="vc">vector of 6 coefficients</param>
        /// <param name="x">initial point</param>
        /// <param name="y">initial point</param>
        /// <param name="pxp">transformed point</param>
        /// <param name="pyp">transformed point</param>
        /// <returns>false if OK; true on error</returns>
        public static bool affineXformSampledPt(IntPtr vc, int x, int y, out int pxp, out int pyp)
        {
            if (IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.affineXformSampledPt(vc, x, y, out pxp, out pyp);
        }

        /// <summary>
        /// (1) This computes the floating point location of the transformed point.
        /// (2) It does not check ptrs for returned data!
        /// </summary>
        /// <param name="vc">vector of 6 coefficients</param>
        /// <param name="x">initial point</param>
        /// <param name="y">initial point</param>
        /// <param name="pxp">transformed point</param>
        /// <param name="pyp">transformed point</param>
        /// <returns>false if OK; true on error</returns>
        public static bool affineXformPt(IntPtr vc, int x, int y, out float pxp, out float pyp)
        {
            if (IntPtr.Zero == vc)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.affineXformPt(vc, x, y, out pxp, out pyp);
        }

        // Interpolation helper functions  
        /// <summary>
        /// (1) This is a standard linear interpolation function.  It is
        ///     equivalent to area weighting on each component, and
        ///     avoids "jaggies" when rendering sharp edges.
        /// </summary>
        /// <param name="datas">ptr to beginning of image data</param>
        /// <param name="wpls">32-bit word/line for this data array</param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="x">floating pt location for evaluation</param>
        /// <param name="y">floating pt location for evaluation</param>
        /// <param name="colorval">colorval color brought in from the outside when the input x,y location is outside the image; in 0xrrggbb00 format)</param>
        /// <param name="pval">interpolated color value</param>
        /// <returns>false if OK; true on error</returns>
        public static bool linearInterpolatePixelColor(IntPtr datas, int wpls, int w, int h, float x, float y, uint colorval, out uint pval)
        {
            if (IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.linearInterpolatePixelColor(datas, wpls, w, h, x, y, colorval, out pval);
        }

        /// <summary>
        /// (1) This is a standard linear interpolation function.  It is
        ///     equivalent to area weighting on each component, and
        ///     avoids "jaggies" when rendering sharp edges.
        /// </summary>
        /// <param name="datas">ptr to beginning of image data</param>
        /// <param name="wpls">32-bit word/line for this data array</param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="x">floating pt location for evaluation</param>
        /// <param name="y">floating pt location for evaluation</param>
        /// <param name="grayval">grayval color brought in from the outside when the input x,y location is outside the image</param>
        /// <param name="pval">interpolated gray value</param>
        /// <returns>false if OK; true on error</returns>
        public static bool linearInterpolatePixelGray(IntPtr datas, int wpls, int w, int h, float x, float y, int grayval, out int pval)
        {
            if (IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("vc cannot be null.");
            }

            return Native.DllImports.linearInterpolatePixelGray(datas, wpls, w, h, x, y, grayval, out pval);
        }

        // Gauss-jordan linear equation solver
        /// <summary>
        /// (1) There are two side-effects:
        ///     * The matrix a is transformed to its inverse A
        ///     * The rhs vector b is transformed to the solution x
        ///       of the linear equation ax = b
        /// (2) The inverse A can then be used to solve the same equation with
        ///     different rhs vectors c by multiplication: x = Ac
        /// (3) Adapted from "Numerical Recipes in C, Second Edition", 1992,
        ///     pp. 36-41 (gauss-jordan elimination)
        /// </summary>
        /// <param name="a">n x n matrix</param>
        /// <param name="b">n x 1 right-hand side column vector</param>
        /// <param name="n">dimension</param>
        /// <returns>false if OK; true on error</returns>
        public static bool gaussjordan(IntPtr a, IntPtr b, int n)
        {
            if (IntPtr.Zero == a
             || IntPtr.Zero == b)
            {
                throw new ArgumentNullException("a, b cannot be null.");
            }

            return Native.DllImports.gaussjordan(a, b, n);
        }

        // Affine image transformation using a sequence of  shear/scale/translation operations  
        /// <summary>
        /// (1) The 3 pts must not be collinear.
        /// (2) The 3 pts must be given in this order:
        ///      ~ origin
        ///      ~ a location along the x-axis
        ///      ~ a location along the y-axis.
        /// (3) You must guess how much border must be added so that no
        ///     pixels are lost in the transformations from src to
        ///     dest coordinate space.  (This can be calculated but it
        ///     is a lot of work!)  For coordinate spaces that are nearly
        ///     at right angles, on a 300 ppi scanned page, the addition
        ///     of 1000 pixels on each side is usually sufficient.
        /// (4) This is here for pedagogical reasons.  It is about 3x faster
        ///     on 1 bpp images than pixAffineSampled(), but the results
        ///     on text are much inferior.
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="ptad">3 pts of final coordinate space</param>
        /// <param name="ptas">3 pts of initial coordinate space</param>
        /// <param name="bw">pixels of additional border width during computation</param>
        /// <param name="bh">pixels of additional border height during computation</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAffineSequential(this Pix pixs, Pta ptad, Pta ptas, int bw, int bh)
        {
            if (null == pixs
             || null == ptad
             || null == ptas)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            var pointer = Native.DllImports.pixAffineSequential((HandleRef)pixs, (HandleRef)ptad, (HandleRef)ptas, bw, bh);
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
