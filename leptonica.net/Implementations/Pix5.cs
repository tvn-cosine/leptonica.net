using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pix5
    {
        // Measurement of properties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixa"></param>
        /// <param name="pnaw">numa of pix widths</param>
        /// <param name="pnah">numa of pix heights</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixaFindDimensions(this Pixa pixa, ref Numa pnaw, ref Numa pnah)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            IntPtr pnawPtr = (IntPtr)pnaw;
            IntPtr pnahPtr = (IntPtr)pnah;
            return Native.DllImports.pixaFindDimensions((HandleRef)pixa, ref pnawPtr, ref pnahPtr);
        }

        /// <summary>
        /// (1) The area is the number of fg pixels that are not on the
        ///     boundary(i.e., are not 8-connected to a bg pixel), and the
        ///     perimeter is the number of fg boundary pixels.Returns
        ///     0.0 if there are no fg pixels.
        /// (2) This function is retained because clients are using it.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="tab">pixel sum table, can be NULL</param>
        /// <param name="pfract">area/perimeter ratio</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindAreaPerimRatio(this Pix pixs, IntPtr tab, out float pfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixFindAreaPerimRatio((HandleRef)pixs, tab, out pfract);
        }

        /// <summary>
        /// This is typically used for a pixa consisting of 1 bpp connected components.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <returns>na of perimeter/arear ratio for each pix, or NULL on error</returns>
        public static Numa pixaFindPerimToAreaRatio(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaFindPerimToAreaRatio((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) The perimeter is the number of fg boundary pixels, and the
        ///     area is the number of fg pixels.  This returns 0.0 if
        ///     there are no fg pixels.
        /// (2) Unlike pixFindAreaPerimRatio(), this uses the full set of
        ///     fg pixels for the area, and the ratio is taken in the opposite
        ///     order.
        /// (3) This is typically used for a single connected component.
        ///     This always has a value <= 1.0, and if the average distance
        ///     of a fg pixel from the nearest bg pixel is d, this has
        ///     a value ~1/d.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="tab">[optional] pixel sum table, can be NULL</param>
        /// <param name="pfract">pfract perimeter/area ratio</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindPerimToAreaRatio(this Pix pixs, IntPtr tab, out float pfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixFindPerimToAreaRatio((HandleRef)pixs, tab, out pfract);
        }

        /// <summary>
        /// (1) This is typically used for a pixa consisting of
        ///     1 bpp connected components.
        /// (2) This has a minimum value for a circle of pi/4; a value for
        ///     a rectangle component of approx. 1.0; and a value much larger
        ///     than 1.0 for a component with a highly irregular boundary.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <returns>na of fg perimeter/(2*(w+h)) ratio for each pix, or NULL on error</returns>
        public static Numa pixaFindPerimSizeRatio(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaFindPerimSizeRatio((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary> 
        /// (1) We take the 'size' as twice the sum of the width and
        ///     height of pixs, and the perimeter is the number of fg
        ///     boundary pixels.  We use the fg pixels of the boundary
        ///     because the pix may be clipped to the boundary, so an
        ///     erosion is required to count all boundary pixels.
        /// (2) This has a large value for dendritic, fractal-like components
        ///     with highly irregular boundaries.
        /// (3) This is typically used for a single connected component.
        ///     It has a value of about 1.0 for rectangular components with
        ///     relatively smooth boundaries.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="tab">[optional] pixel sum table, can be NULL</param>
        /// <param name="pratio">pratio perimeter/size ratio</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindPerimSizeRatio(this Pix pixs, IntPtr tab, out float pratio)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixFindPerimSizeRatio((HandleRef)pixs, tab, out pratio);
        }

        /// <summary>
        /// This is typically used for a pixa consisting of 1 bpp connected components.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <returns>na of area fractions for each pix, or NULL on error</returns>
        public static Numa pixaFindAreaFraction(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaFindAreaFraction((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) This finds the ratio of the number of fg pixels to the
        ///     size of the pix (w * h).  It is typically used for a
        ///     single connected component.
        /// </summary>
        /// <param name="pixs">pixs 1 bpp</param>
        /// <param name="tab">[optional] pixel sum table, can be NULL</param>
        /// <param name="pfract">pfract fg area/size ratio</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindAreaFraction(this Pix pixs, IntPtr tab, out float pfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixFindAreaFraction((HandleRef)pixs, tab, out pfract);
        }

        /// <summary>
        /// (1) This is typically used for a pixa consisting of
        ///     1 bpp connected components, which has an associated
        ///     boxa giving the location of the components relative
        ///     to the mask origin.
        /// (2) The debug flag displays in green and red the masked and
        ///     unmasked parts of the image from which pixa was derived.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <param name="pixm">pixm mask image</param>
        /// <param name="debug">true for output, false to suppress</param>
        /// <returns>na of ratio masked/total fractions for each pix, or NULL on error</returns>
        public static Numa pixaFindAreaFractionMasked(this Pixa pixa, Pix pixm, bool debug)
        {
            if (null == pixa
             || null == pixm)
            {
                throw new ArgumentNullException("pixa, pixm cannot be null");
            }

            var pointer = Native.DllImports.pixaFindAreaFractionMasked((HandleRef)pixa, (HandleRef)pixm, debug);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) This finds the ratio of the number of masked fg pixels
        ///     in pixs to the total number of fg pixels in pixs.
        ///     It is typically used for a single connected component.
        ///     If there are no fg pixels, this returns a ratio of 0.0.
        /// (2) The box gives the location of the pix relative to that
        ///     of the UL corner of the mask.  Therefore, the rasterop
        ///     is performed with the pix translated to its location
        ///     (x, y) in the mask before ANDing.
        ///     If box == NULL, the UL corners of pixs and pixm are aligned.
        /// </summary>
        /// <param name="pixs">1 bpp, typically a single component</param>
        /// <param name="box">[optional] for pixs relative to pixm</param>
        /// <param name="pixm">1 bpp mask, typically over the entire image from which the component pixs was extracted</param>
        /// <param name="tab">[optional] pixel sum table, can be NULL</param>
        /// <param name="pfract">fg area/size ratio</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindAreaFractionMasked(this Pix pixs, Box box, Pix pixm, IntPtr tab, out float pfract)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null");
            }
            if (1 != pixm.Depth)
            {
                throw new ArgumentException("pixm must be 1 bpp.");
            }

            return Native.DllImports.pixFindAreaFractionMasked((HandleRef)pixs, (HandleRef)box, (HandleRef)pixm, tab, out pfract);
        }

        /// <summary>
        /// This is typically used for a pixa consisting of 1 bpp connected components.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <returns>na of width/height ratios for each pix, or NULL on error</returns>
        public static Numa pixaFindWidthHeightRatio(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaFindWidthHeightRatio((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// This is typically used for a pixa consisting of 1 bpp connected components.
        /// </summary>
        /// <param name="pixa">pixa of 1 bpp pix</param>
        /// <returns>na of width*height products for each pix, or NULL on error</returns>
        public static Numa pixaFindWidthHeightProduct(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaFindWidthHeightProduct((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) The UL corner of pixs2 is placed at (x2, y2) in pixs1.
        /// (2) This measure is similar to the correlation.
        /// </summary>
        /// <param name="pixs1">1 bpp</param>
        /// <param name="pixs2">1 bpp</param>
        /// <param name="x2">location in pixs1 of UL corner of pixs2</param>
        /// <param name="y2">location in pixs1 of UL corner of pixs2</param>
        /// <param name="tab">[optional] pixel sum table, can be null</param>
        /// <param name="pratio">ratio fg intersection to fg union</param>
        /// <param name="pnoverlap">number of overlapping pixels</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindOverlapFraction(this Pix pixs1, Pix pixs2, int x2, int y2, IntPtr tab, out float pratio, out int pnoverlap)
        {
            if (null == pixs1
             || null == pixs2)
            {
                throw new ArgumentNullException("pixs1, pixs2 cannot be null");
            }
            if (1 != pixs1.Depth
             || 1 != pixs2.Depth)
            {
                throw new ArgumentException("pixs1, pixs2 must have 1 bpp");
            }

            return Native.DllImports.pixFindOverlapFraction((HandleRef)pixs1, (HandleRef)pixs2, x2, y2, tab, out pratio, out pnoverlap);
        }

        /// <summary>
        /// (1) This applies the function pixConformsToRectangle() to
        ///     each 8-c.c. in pixs, and returns a boxa containing the
        ///     regions of all components that are conforming.
        /// (2) Conforming components must satisfy both the size constraint
        ///     given by %minsize and the slop in conforming to a rectangle
        ///     determined by %dist.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="dist">max distance allowed between bounding box and nearest foreground pixel within it</param>
        /// <param name="minw">minimum size in each direction as a requirement for a conforming rectangle</param>
        /// <param name="minh">minimum size in each direction as a requirement for a conforming rectangle</param>
        /// <returns>boxa of components that conform, or NULL on error</returns>
        public static Boxa pixFindRectangleComps(this Pix pixs, int dist, int minw, int minh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixFindRectangleComps((HandleRef)pixs, dist, minw, minh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        /// <summary>
        /// (1) There are several ways to test if a connected component has
        ///     an essentially rectangular boundary, such as:
        ///      a. Fraction of fill into the bounding box
        ///      b. Max-min distance of fg pixel from periphery of bounding box
        ///      c. Max depth of bg intrusions into component within bounding box
        ///     The weakness of (a) is that it is highly sensitive to holes
        ///     within the c.c.  The weakness of (b) is that it can have
        ///     arbitrarily large intrusions into the c.c.  Method (c) tests
        ///     the integrity of the outer boundary of the c.c., with respect
        ///     to the enclosing bounding box, so we use it.
        /// (2) This tests if the connected component within the box conforms
        ///     to the box at all points on the periphery within %dist.
        ///     Inside, at a distance from the box boundary that is greater
        ///     than %dist, we don't care about the pixels in the c.c.
        /// (3) We can think of the conforming condition as follows:
        ///     No pixel inside a distance %dist from the boundary
        ///     can connect to the boundary through a path through the bg.
        ///     To implement this, we need to do a flood fill.  We can go
        ///     either from inside toward the boundary, or the other direction.
        ///     It's easiest to fill from the boundary, and then verify that
        ///     there are no filled pixels farther than %dist from the boundary.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="box">[optional] if null, use the entire pixs</param>
        /// <param name="dist">max distance allowed between bounding box and nearest foreground pixel within it</param>
        /// <param name="pconforms">(false) if not conforming; (true) if conforming</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixConformsToRectangle(this Pix pixs, Box box, int dist, out bool pconforms)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixConformsToRectangle((HandleRef)pixs, (HandleRef)box, dist, out pconforms);
        }

        // Extract rectangular region
        /// <summary>
        /// The returned pixa includes the actual regions clipped out from the input pixs.
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="boxa">requested clipping regions</param>
        /// <returns>pixa consisting of requested regions, or NULL on error</returns>
        public static Pixa pixClipRectangles(this Pix pixs, Boxa boxa)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null");
            }

            var pointer = Native.DllImports.pixClipRectangles((HandleRef)pixs, (HandleRef)boxa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        /// <summary>
        ///  This should be simple, but there are choices to be made.
        ///  The box is defined relative to the pix coordinates.  However,
        ///  if the box is not contained within the pix, we have two choices:
        ///
        ///      (1) clip the box to the pix
        ///      (2) make a new pix equal to the full box dimensions,
        ///          but let rasterop do the clipping and positioning
        ///          of the src with respect to the dest
        ///
        ///  Choice (2) immediately brings up the problem of what pixel values
        ///  to use that were not taken from the src.  For example, on a grayscale
        ///  image, do you want the pixels not taken from the src to be black
        ///  or white or something else?  To implement choice 2, one needs to
        ///  specify the color of these extra pixels.
        ///
        ///  So we adopt (1), and clip the box first, if necessary,
        ///  before making the dest pix and doing the rasterop.  But there
        ///  is another issue to consider.  If you want to paste the
        ///  clipped pix back into pixs, it must be properly aligned, and
        ///  it is necessary to use the clipped box for alignment.
        ///  Accordingly, this function has a third (optional) argument, which is
        ///  the input box clipped to the src pix.
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="box">requested clipping region; const</param>
        /// <param name="pboxc">[optional] actual box of clipped region</param>
        /// <returns>clipped pix, or NULL on error or if rectangle  doesn't intersect pixs</returns>
        public static Pix pixClipRectangle(this Pix pixs, Box box, ref Box pboxc)
        {
            if (null == pixs
             || null == box)
            {
                throw new ArgumentNullException("pixs, box cannot be null");
            }

            IntPtr pboxcPtr = (IntPtr)pboxc;
            var pointer = Native.DllImports.pixClipRectangle((HandleRef)pixs, (HandleRef)box, ref pboxcPtr);
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
        /// (1) If pixs has a colormap, it is preserved in pixd.
        /// (2) The depth of pixd is the same as that of pixs.
        /// (3) If the depth of pixs is 1, use %outval = 0 for white background
        ///     and 1 for black; otherwise, use the max value for white
        ///     and 0 for black.  If pixs has a colormap, the max value for
        ///     %outval is 0xffffffff; otherwise, it is 2^d - 1.
        /// (4) When using 1 bpp pixs, this is a simple clip and
        ///     blend operation.  For example, if both pix1 and pix2 are
        ///     black text on white background, and you want to OR the
        ///     fg on the two images, let pixm be the inverse of pix2.
        ///     Then the operation takes all of pix1 that's in the bg of
        ///     pix2, and for the remainder (which are the pixels
        ///     corresponding to the fg of the pix2), paint them black
        ///     (1) in pix1.  The function call looks like
        ///        pixClipMasked(pix2, pixInvert(pix1, pix1), x, y, 1);
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp; colormap ok</param>
        /// <param name="pixm">clipping mask, 1 bpp</param>
        /// <param name="x">origin of clipping mask relative to pixs</param>
        /// <param name="y">origin of clipping mask relative to pixs</param>
        /// <param name="outval">val to use for pixels that are outside the mask</param>
        /// <returns>pixd, clipped pix or NULL on error or if pixm doesn't intersect pixs</returns>
        public static Pix pixClipMasked(this Pix pixs, Pix pixm, int x, int y, uint outval)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null");
            }
            if (1 != pixm.Depth)
            {
                throw new ArgumentException("pixm must have 1 bpp");
            }

            var pointer = Native.DllImports.pixClipMasked((HandleRef)pixs, (HandleRef)pixm, x, y, outval);
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
        /// (1) This resizes pixs1 and/or pixs2 by cropping at the right
        ///     and bottom, so that they're the same size.
        /// (2) If a pix doesn't need to be cropped, a clone is returned.
        /// (3) Note: the images are implicitly aligned to the UL corner.
        /// </summary>
        /// <param name="pixs1">any depth, colormap OK</param>
        /// <param name="pixs2">any depth, colormap OK</param>
        /// <param name="ppixd1">may be a clone</param>
        /// <param name="ppixd2">may be a clone</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixCropToMatch(this Pix pixs1, Pix pixs2, ref Pix ppixd1, ref Pix ppixd2)
        {
            if (null == pixs1
             || null == pixs2
             || null == ppixd1
             || null == ppixd2)
            {
                throw new ArgumentNullException("pixs1, pixs2, ppixd1, ppixd2 cannot be null");
            }

            IntPtr ppixd1Ptr = (IntPtr)ppixd1;
            IntPtr ppixd2Ptr = (IntPtr)ppixd2;
            return Native.DllImports.pixCropToMatch((HandleRef)pixs1, (HandleRef)pixs2, ref ppixd1Ptr, ref ppixd2Ptr);
        }

        /// <summary>
        /// (1) If either w or h is smaller than the corresponding dimension
        ///     of pixs, this returns a cropped image; otherwise it returns
        ///     a clone of pixs.
        /// </summary>
        /// <param name="pixs">any depth, colormap OK</param>
        /// <param name="w">max dimensions of cropped image</param>
        /// <param name="h">max dimensions of cropped image</param>
        /// <returns>pixd cropped if necessary or NULL on error.</returns>
        public static Pix pixCropToSize(this Pix pixs, int w, int h)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixCropToSize((HandleRef)pixs, w, h);
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
        /// (1) This resizes pixs to make pixd, without scaling, by either
        ///     cropping or extending separately in both width and height.
        ///     Extension is done by replicating the last row or column.
        ///     This is useful in a situation where, due to scaling
        ///     operations, two images that are expected to be the
        ///     same size can differ slightly in each dimension.
        /// (2) You can use either an existing pixt or specify
        ///     both %w and %h.  If pixt is defined, the values
        ///     in %w and %h are ignored.
        /// (3) If pixt is larger than pixs (or if w and/or d is larger
        ///     than the dimension of pixs, replicate the outer row and
        ///     column of pixels in pixs into pixd.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp; colormap ok</param>
        /// <param name="pixt">can be null; we use only the size</param>
        /// <param name="w">ignored if pixt is defined</param>
        /// <param name="h">ignored if pixt is defined</param>
        /// <returns>pixd resized to match or NULL on error</returns>
        public static Pix pixResizeToMatch(this Pix pixs, Pix pixt, int w, int h)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixResizeToMatch((HandleRef)pixs, (HandleRef)pixt, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Make a frame mask
        /// <summary>
        /// (1) This makes an arbitrary 1-component mask with a centered fg
        ///     frame, which can have both an inner and an outer boundary.
        ///     All input fractional distances are measured from the image
        ///     border to the frame boundary, in units of the image half-width
        ///     for hf1 and hf2 and the image half-height for vf1 and vf2.
        ///     The distances to the outer frame boundary are given by hf1
        ///     and vf1; to the inner frame boundary, by hf2 and vf2.
        ///     Input fractions are thus in [0.0 ... 1.0], with hf1 &lt;= hf2
        ///     and vf1 &lt;= vf2.  Horizontal and vertical frame widths are
        ///     thus independently specified.
        /// (2) Special cases:
        ///      * full fg mask: hf1 = vf1 = 0.0, hf2 = vf2 = 1.0.
        ///      * empty fg (zero width) mask: set  hf1 = hf2  and vf1 = vf2.
        ///      * fg rectangle with no hole: set hf2 = vf2 = 1.0.
        ///      * frame touching outer boundary: set hf1 = vf1 = 0.0.
        /// (3) The vertical thickness of the horizontal mask parts
        ///     is 0.5 * (vf2 - vf1) * h.  The horizontal thickness of the
        ///     vertical mask parts is 0.5 * (hf2 - hf1) * w.
        /// </summary>
        /// <param name="w">dimensions of output 1 bpp pix</param>
        /// <param name="h">dimensions of output 1 bpp pix</param>
        /// <param name="hf1">horizontal fraction of half-width at outer frame bdry</param>
        /// <param name="hf2">horizontal fraction of half-width at inner frame bdry</param>
        /// <param name="vf1">vertical fraction of half-width at outer frame bdry</param>
        /// <param name="vf2">vertical fraction of half-width at inner frame bdry</param>
        /// <returns>pixd 1 bpp, or NULL on error.</returns>
        public static Pix pixMakeFrameMask(int w, int h, float hf1, float hf2, float vf1, float vf2)
        {
            var pointer = Native.DllImports.pixMakeFrameMask(w, h, hf1, hf2, vf1, vf2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Fraction of Fg pixels under a mask
        /// <summary>
        /// (1) This gives the fraction of fg pixels in pix1 that are in
        ///     the intersection (i.e., under the fg) of pix2:
        ///     |1 & 2|/|1|, where |...| means the number of fg pixels.
        ///     Note that this is different from the situation where
        ///     pix1 and pix2 are reversed.
        /// (2) Both pix1 and pix2 are registered to the UL corners.  A warning
        ///     is issued if pix1 and pix2 have different sizes.
        /// (3) This can also be used to find the fraction of fg pixels in pix1
        ///     that are NOT under the fg of pix2: 1.0 - |1 & 2|/|1|
        /// (4) If pix1 or pix2 are empty, this returns %fract = 0.0.
        /// (5) For example, pix2 could be a frame around the outside of the
        ///     image, made from pixMakeFrameMask().
        /// </summary>
        /// <param name="pix1">1 bpp</param>
        /// <param name="pix2">1 bpp</param>
        /// <param name="pfract">fraction of fg pixels in 1 that are aligned with the fg of 2</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFractionFgInMask(this Pix pix1, Pix pix2, out float pfract)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null");
            }
            if (1 != pix1.Depth
             || 1 == pix2.Depth)
            {
                throw new ArgumentException("pix1, pix2 must have 1 bpp");
            }

            return Native.DllImports.pixFractionFgInMask((HandleRef)pix1, (HandleRef)pix2, out pfract);
        }

        // Clip to foreground
        /// <summary>
        /// (1) At least one of {&pixd, &box} must be specified.
        /// (2) If there are no fg pixels, the returned ptrs are null.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="ppixd">[optional] clipped pix returned</param>
        /// <param name="pbox">[optional] bounding box</param>
        /// <returns>false if OK; true on error or if there are no fg pixels</returns>
        public static bool pixClipToForeground(this Pix pixs, ref Pix ppixd, ref Box pbox)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            IntPtr ppixdPtr = (IntPtr)ppixd;
            IntPtr pboxPtr = (IntPtr)pbox;
            return Native.DllImports.pixClipToForeground((HandleRef)pixs, ref ppixdPtr, ref pboxPtr);
        }

        /// <summary>
        /// (1) This is a lightweight test to determine if a 1 bpp image
        ///     can be further cropped without loss of fg pixels.
        ///     If it cannot, canclip is set to 0.
        /// (2) It does not test for the existence of any fg pixels.
        ///     If there are no fg pixels, it will return %canclip = 1.
        ///     Check the output of the subsequent call to pixClipToForeground().
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pcanclip">true if fg does not extend to all four edges</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixTestClipToForeground(this Pix pixs, out bool pcanclip)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixTestClipToForeground((HandleRef)pixs, out pcanclip);
        }

        /// <summary>
        /// (1) At least one of {&pixd, &boxd} must be specified.
        /// (2) If there are no fg pixels, the returned ptrs are null.
        /// (3) Do not use &pixs for the 3rd arg or &boxs for the 4th arg;
        ///     this will leak memory.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="boxs">[optional] ; use full image if null</param>
        /// <param name="ppixd">[optional] clipped pix returned</param>
        /// <param name="pboxd">[optional] bounding box</param>
        /// <returns>false if OK; true on error or if there are no fg pixels</returns>
        public static bool pixClipBoxToForeground(this Pix pixs, Box boxs, ref Pix ppixd, ref Box pboxd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            IntPtr ppixdPtr = (IntPtr)ppixd;
            IntPtr pboxdPtr = (IntPtr)pboxd;
            return Native.DllImports.pixClipBoxToForeground((HandleRef)pixs, (HandleRef)boxs, ref ppixdPtr, ref pboxdPtr);
        }

        /// <summary>
        /// (1) If there are no fg pixels, the position is set to 0.
        ///     Caller must check the return value!
        /// (2) Use %box == NULL to scan from edge of pixs
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="box">[optional] within which the search is conducted</param>
        /// <param name="scanflag">direction of scan; e.g., L_FROM_LEFT</param>
        /// <param name="ploc">location in scan direction of first black pixel</param>
        /// <returns>false if OK; true on error or if there are no fg pixels found</returns>
        public static bool pixScanForForeground(this Pix pixs, Box box, ScanDirectionFlags scanflag, out int ploc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixScanForForeground((HandleRef)pixs, (HandleRef)box, scanflag, out ploc);
        }

        /// <summary>
        /// (1) At least one of {&pixd, &boxd} must be specified.
        /// (2) If there are no fg pixels, the returned ptrs are null.
        /// (3) This function attempts to locate rectangular "image" regions
        ///     of high-density fg pixels, that have well-defined edges
        ///     on the four sides.
        /// (4) Edges are searched for on each side, iterating in order
        ///     from left, right, top and bottom.  As each new edge is
        ///     found, the search box is resized to use that location.
        ///     Once an edge is found, it is held.  If no more edges
        ///     are found in one iteration, the search fails.
        /// (5) See pixScanForEdge() for usage of the thresholds and %maxwidth.
        /// (6) The thresholds must be at least 1, and the low threshold
        ///     cannot be larger than the high threshold.
        /// (7) If the low and high thresholds are both 1, this is equivalent
        ///     to pixClipBoxToForeground().
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="boxs">[optional] ; use full image if null</param>
        /// <param name="lowthresh">threshold to choose clipping location</param>
        /// <param name="highthresh">threshold required to find an edge</param>
        /// <param name="maxwidth">max allowed width between low and high thresh locs</param>
        /// <param name="factor">sampling factor along pixel counting direction</param>
        /// <param name="ppixd">[optional] clipped pix returned</param>
        /// <param name="pboxd">[optional] bounding box</param>
        /// <returns>false if OK; true on error or if there are no fg pixels found all four sides.</returns>
        public static bool pixClipBoxToEdges(this Pix pixs, Box boxs, int lowthresh, int highthresh, int maxwidth, int factor, ref Pix ppixd, ref Box pboxd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            IntPtr ppixdPtr = (IntPtr)ppixd;
            IntPtr pboxdPtr = (IntPtr)pboxd;

            return Native.DllImports.pixClipBoxToEdges((HandleRef)pixs, (HandleRef)boxs, lowthresh, highthresh, maxwidth, factor, ref ppixdPtr, ref pboxdPtr);
        }

        /// <summary>
        /// (1) If there are no fg pixels, the position is set to 0.
        ///     Caller must check the return value!
        /// (2) Use %box == NULL to scan from edge of pixs
        /// (3) As the scan progresses, the location where the sum of
        ///     pixels equals or excees %lowthresh is noted (loc).  The
        ///     scan is stopped when the sum of pixels equals or exceeds
        ///     %highthresh.  If the scan distance between loc and that
        ///     point does not exceed %maxwidth, an edge is found and
        ///     its position is taken to be loc.  %maxwidth implicitly
        ///     sets a minimum on the required gradient of the edge.
        /// (4) The thresholds must be at least 1, and the low threshold
        ///     cannot be larger than the high threshold.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="box">[optional] within which the search is conducted</param>
        /// <param name="lowthresh">threshold to choose clipping location</param>
        /// <param name="highthresh">threshold required to find an edge</param>
        /// <param name="maxwidth">max allowed width between low and high thresh locs</param>
        /// <param name="factor">sampling factor along pixel counting direction</param>
        /// <param name="scanflag">direction of scan; e.g., L_FROM_LEFT</param>
        /// <param name="ploc">location in scan direction of first black pixel</param>
        /// <returns>false if OK; true on error or if the edge is not found</returns>
        public static bool pixScanForEdge(this Pix pixs, Box box, int lowthresh, int highthresh, int maxwidth, int factor, ScanDirectionFlags scanflag, out int ploc)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must have 1 bpp");
            }

            return Native.DllImports.pixScanForEdge((HandleRef)pixs, (HandleRef)box, lowthresh, highthresh, maxwidth, factor, scanflag, out ploc);
        }

        // Extract pixel averages and reversals along lines
        /// <summary>
        /// (1) Input end points are clipped to the pix.
        /// (2) If the line is either horizontal, or closer to horizontal
        ///     than to vertical, the points will be extracted from left
        ///     to right in the pix.  Likewise, if the line is vertical,
        ///     or closer to vertical than to horizontal, the points will
        ///     be extracted from top to bottom.
        /// (3) Can be used with numaCountReverals(), for example, to
        ///     characterize the intensity smoothness along a line.
        /// </summary>
        /// <param name="pixs">1 bpp or 8 bpp; no colormap</param>
        /// <param name="x1">one end point for line</param>
        /// <param name="y1">one end point for line</param>
        /// <param name="x2">another end pt for line</param>
        /// <param name="y2">another end pt for line</param>
        /// <param name="factor">sampling; >= 1</param>
        /// <returns>na of pixel values along line, or NULL on error.</returns>
        public static Numa pixExtractOnLine(this Pix pixs, int x1, int y1, int x2, int y2, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (!(1 == pixs.Depth
               || 8 == pixs.Depth))
            {
                throw new ArgumentException("pixs must have 1 or 8 bpp");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }
            if (1 > factor)
            {
                throw new ArgumentException("factor must be >= 1.");
            }

            var pointer = Native.DllImports.pixExtractOnLine((HandleRef)pixs, x1, y1, x2, y2, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) The line must be either horizontal or vertical, so either
        ///     y1 == y2 (horizontal) or x1 == x2 (vertical).
        /// (2) If horizontal, x1 must be &lt;= x2.
        ///     If vertical, y1 must be &lt;= y2.
        ///     characterize the intensity smoothness along a line.
        /// (3) Input end points are clipped to the pix.
        /// </summary>
        /// <param name="pixs">1 bpp or 8 bpp; no colormap</param>
        /// <param name="x1">starting pt for line</param>
        /// <param name="y1">starting pt for line</param>
        /// <param name="x2">end pt for line</param>
        /// <param name="y2">end pt for line</param>
        /// <param name="factor">sampling; >= 1</param>
        /// <returns>average of pixel values along line, or NULL on error.</returns>
        public static float pixAverageOnLine(this Pix pixs, int x1, int y1, int x2, int y2, int factor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (!(1 == pixs.Depth
               || 8 == pixs.Depth))
            {
                throw new ArgumentException("pixs must have 1 or 8 bpp");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }
            if (1 > factor)
            {
                throw new ArgumentException("factor must be >= 1.");
            }

            return Native.DllImports.pixAverageOnLine((HandleRef)pixs, x1, y1, x2, y2, factor);
        }

        /// <summary>
        /// (1) If d != 1 bpp, colormaps are removed and the result
        ///     is converted to 8 bpp.
        /// (2) If %dir == L_HORIZONTAL_LINE, the intensity is averaged
        ///     along each horizontal raster line (sampled by %factor1),
        ///     and the profile is the array of these averages in the
        ///     vertical direction between %first and %last raster lines,
        ///     and sampled by %factor2.
        /// (3) If %dir == L_VERTICAL_LINE, the intensity is averaged
        ///     along each vertical line (sampled by %factor1),
        ///     and the profile is the array of these averages in the
        ///     horizontal direction between %first and %last columns,
        ///     and sampled by %factor2.
        /// (4) The averages are measured over the central %fract of the image.
        ///     Use %fract == 1.0 to average across the entire width or height.
        /// </summary>
        /// <param name="pixs">pixs any depth; colormap OK</param>
        /// <param name="fract">fraction of image width or height to be used</param>
        /// <param name="dir">averaging direction: L_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
        /// <param name="first">span of rows or columns to measure</param>
        /// <param name="last">span of rows or columns to measure</param>
        /// <param name="factor1">sampling along fast scan direction; >= 1</param>
        /// <param name="factor2">sampling along slow scan direction; >= 1</param>
        /// <returns>na of reversal profile, or NULL on error.</returns>
        public static Numa pixAverageIntensityProfile(this Pix pixs, float fract, LineOrientationFlags dir, int first, int last, int factor1, int factor2)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 > factor1
             || 1 > factor2)
            {
                throw new ArgumentException("factor1, factor2 must be >= 1.");
            }

            var pointer = Native.DllImports.pixAverageIntensityProfile((HandleRef)pixs, fract, dir, first, last, factor1, factor2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        /// <summary>
        /// (1) If d != 1 bpp, colormaps are removed and the result
        ///     is converted to 8 bpp.
        /// (2) If %dir == L_HORIZONTAL_LINE, the the reversals are counted
        ///     along each horizontal raster line (sampled by %factor1),
        ///     and the profile is the array of these sums in the
        ///     vertical direction between %first and %last raster lines,
        ///     and sampled by %factor2.
        /// (3) If %dir == L_VERTICAL_LINE, the the reversals are counted
        ///     along each vertical column (sampled by %factor1),
        ///     and the profile is the array of these sums in the
        ///     horizontal direction between %first and %last columns,
        ///     and sampled by %factor2.
        /// (4) For each row or column, the reversals are summed over the
        ///     central %fract of the image.  Use %fract == 1.0 to sum
        ///     across the entire width (of row) or height (of column).
        /// (5) %minreversal is the relative change in intensity that is
        ///     required to resolve peaks and valleys.  A typical number for
        ///     locating text in 8 bpp might be 50.  For 1 bpp, minreversal
        ///     must be 1.
        /// (6) The reversal profile is simply the number of reversals
        ///     in a row or column, vs the row or column index
        /// </summary>
        /// <param name="pixs">any depth; colormap OK</param>
        /// <param name="fract">fraction of image width or height to be used</param>
        /// <param name="dir">profile direction: L_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
        /// <param name="first">span of rows or columns to measure</param>
        /// <param name="last">span of rows or columns to measure</param>
        /// <param name="minreversal">minimum change in intensity to trigger a reversal</param>
        /// <param name="factor1">sampling along raster line (fast scan); >= 1</param>
        /// <param name="factor2">sampling of raster lines (slow scan); >= 1</param>
        /// <returns>na of reversal profile, or NULL on error.</returns>
        public static Numa pixReversalProfile(this Pix pixs, float fract, LineOrientationFlags dir, int first, int last, int minreversal, int factor1, int factor2)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 > factor1
             || 1 > factor2)
            {
                throw new ArgumentException("factor1, factor2 must be >= 1.");
            }

            var pointer = Native.DllImports.pixReversalProfile((HandleRef)pixs, fract, dir, first, last, minreversal, factor1, factor2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Extract windowed variance along a line
        /// <summary>
        /// (1) The returned variance array traverses the line starting
        ///     from the smallest coordinate, min(c1,c2).
        /// (2) Line end points are clipped to pixs.
        /// (3) The reference point for the variance calculation is the center of
        ///     the window.  Therefore, the numa start parameter from
        ///     pixExtractOnLine() is incremented by %size/2,
        ///     to align the variance values with the pixel coordinate.
        /// (4) The square root of the variance is the RMS deviation from the mean.
        /// </summary>
        /// <param name="pixs">8 bpp; no colormap</param>
        /// <param name="dir">_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
        /// <param name="loc">location of the constant coordinate for the line</param>
        /// <param name="c1">end point coordinates for the line</param>
        /// <param name="c2">end point coordinates for the line</param>
        /// <param name="size">window size; must be > 1</param>
        /// <param name="pnad">windowed square root of variance</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixWindowedVarianceOnLine(this Pix pixs, LineOrientationFlags dir, int loc, int c1, int c2, int size, ref Numa pnad)
        {
            if (null == pixs
             || null == pnad)
            {
                throw new ArgumentNullException("pixs, pnad cannot be null");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }
            if (1 > size)
            {
                throw new ArgumentException("size must be > 1.");
            }

            IntPtr pnadPtr = (IntPtr)pnad;
            return Native.DllImports.pixWindowedVarianceOnLine((HandleRef)pixs, dir, loc, c1, c2, size, ref pnadPtr);
        }

        // Extract min/max of pixel values near lines
        /// <summary>
        /// (1) If the line is more horizontal than vertical, the values
        ///     are computed for [x1, x2], and the pixels are taken
        ///     below and/or above the local y-value.  Otherwise, the
        ///     values are computed for [y1, y2] and the pixels are taken
        ///     to the left and/or right of the local x value.
        /// (2) %direction specifies which side (or both sides) of the
        ///     line are scanned for min and max values.
        /// (3) There are two ways to tell if the returned values of min
        ///     and max averages are valid: the returned values cannot be
        ///     negative and the function must return 0.
        /// (4) All accessed pixels are clipped to the pix.
        /// </summary>
        /// <param name="pixs">8 bpp; no colormap</param>
        /// <param name="x1">starting pt for line</param>
        /// <param name="y1">starting pt for line</param>
        /// <param name="x2">end pt for line</param>
        /// <param name="y2">end pt for line</param>
        /// <param name="dist">distance to search from line in each direction</param>
        /// <param name="direction">L_SCAN_NEGATIVE, L_SCAN_POSITIVE, L_SCAN_BOTH</param>
        /// <param name="pnamin">[optional] minimum values</param>
        /// <param name="pnamax">[optional] maximum values</param>
        /// <param name="pminave">average of minimum values</param>
        /// <param name="pmaxave">average of maximum values</param>
        /// <returns>false if OK; true on error or if there are no sampled points within the image.</returns>
        public static bool pixMinMaxNearLine(this Pix pixs, int x1, int y1, int x2, int y2, int dist, ScanDirectionFlags direction, ref Numa pnamin, ref Numa pnamax, out float pminave, out float pmaxave)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }

            IntPtr pnaminPtr = (IntPtr)pnamin;
            IntPtr pnamaxPtr = (IntPtr)pnamax;
            return Native.DllImports.pixMinMaxNearLine((HandleRef)pixs, x1, y1, x2, y2, dist, direction, ref pnaminPtr, ref pnamaxPtr, out pminave, out pmaxave); 
           
        }

        // Rank row and column transforms
        /// <summary>
        /// The time is O(n) in the number of pixels and runs about 100 Mpixels/sec on a 3 GHz machine.
        /// </summary>
        /// <param name="pixs">8 bpp; no colormap</param>
        /// <returns>pixd with pixels sorted in each row, from min to max value</returns>
        public static Pix pixRankRowTransform(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }

            var pointer = Native.DllImports.pixRankRowTransform((HandleRef)pixs);
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
        /// The time is O(n) in the number of pixels and runs about 50 Mpixels/sec on a 3 GHz machine.
        /// </summary>
        /// <param name="pixs">8 bpp; no colormap</param>
        /// <returns>pixd with pixels sorted in each column, from min to max value</returns>
        public static Pix pixRankColumnTransform(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (8 != pixs.Depth)
            {
                throw new ArgumentException("pixs not 8 bpp.");
            }
            if (null != pixs.Colormap)
            {
                throw new ArgumentException("pixs cannot be color mapped.");
            }

            var pointer = Native.DllImports.pixRankColumnTransform((HandleRef)pixs);
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
