using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Pix2
    {
        // Pixel poking
        /// <summary>
        /// (1) This returns the value in the data array.  If the pix is
        ///     colormapped, it returns the colormap index, not the rgb value.
        /// (2) Because of the function overhead and the parameter checking,
        ///     this is much slower than using the GET_DATA_*() macros directly.
        ///     Speed on a 1 Mpixel RGB image, using a 3 GHz machine:
        ///       * pixGet/pixSet: ~25 Mpix/sec
        ///       * GET_DATA/SET_DATA: ~350 MPix/sec
        ///     If speed is important and you're doing random access into
        ///     the pix, use pixGetLinePtrs() and the array access macros.
        /// (3) If the point is outside the image, this returns an error (1),
        ///     with 0 in %pval.  To avoid spamming output, it fails silently.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <param name="pval">pixel value</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetPixel(this Pix pix, int x, int y, out uint pval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetPixel((HandleRef)pix, x, y, out pval);
        }

        /// <summary>
        /// (1) Warning: the input value is not checked for overflow with respect
        ///     the the depth of %pix, and the sign bit (if any) is ignored.
        ///     * For d == 1, %val > 0 sets the bit on.
        ///     * For d == 2, 4, 8 and 16, %val is masked to the maximum allowable
        ///       pixel value, and any (invalid) higher order bits are discarded.
        /// (2) See pixGetPixel() for information on performance.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <param name="val">value to be inserted</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetPixel(this Pix pix, int x, int y, uint val)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetPixel((HandleRef)pix, x, y, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix">32 bpp rgb, not colormapped</param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <param name="prval">red component</param>
        /// <param name="pgval">green component</param>
        /// <param name="pbval">blue component</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetRGBPixel(this Pix pix, int x, int y, out int prval, out int pgval, out int pbval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (32 == pix.Depth)
            {
                throw new ArgumentNullException("pix must be 32 bpp");
            }
            if (null != pix.Colormap)
            {
                throw new ArgumentNullException("pix cannot be color mapped");
            }

            return Native.DllImports.pixGetRGBPixel((HandleRef)pix, x, y, out prval, out pgval, out pbval);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix">32 bpp rgb</param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <param name="rval">red component</param>
        /// <param name="gval">green component</param>
        /// <param name="bval">blue component</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetRGBPixel(this Pix pix, int x, int y, int rval, int gval, int bval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (32 == pix.Depth)
            {
                throw new ArgumentNullException("pix must be 32 bpp");
            }

            return Native.DllImports.pixSetRGBPixel((HandleRef)pix, x, y, rval, gval, bval);
        }

        /// <summary>
        /// If the pix is colormapped, it returns the rgb value.
        /// </summary>
        /// <param name="pix">any depth; can be colormapped</param>
        /// <param name="pval"pixel value></param>
        /// <param name="px">x coordinate chosen;</param>
        /// <param name="py">y coordinate chosen</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetRandomPixel(this Pix pix, out uint pval, out int px, out int py)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetRandomPixel((HandleRef)pix, out pval, out px, out py);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixClearPixel(this Pix pix, int x, int y)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixClearPixel((HandleRef)pix, x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="x">pixel coords</param>
        /// <param name="y">pixel coords</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixFlipPixel(this Pix pix, int x, int y)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixFlipPixel((HandleRef)pix, x, y);
        }

        /// <summary>
        /// Caution: input variables are not checked!
        /// </summary>
        /// <param name="line">ptr to beginning of line,</param>
        /// <param name="x">pixel location in line</param>
        /// <param name="depth">bpp</param>
        /// <param name="val"> to be inserted</param>
        public static void setPixelLow(IntPtr line, int x, int depth, uint val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null");
            }

            Native.DllImports.setPixelLow(line, x, depth, val);
        }

        // Find black or white value
        /// <summary>
        /// (1) Side effect.  For a colormapped image, if the requested
        ///     color is not present and there is room to add it in the cmap,
        ///     it is added and the new index is returned.  If there is no room,
        ///     the index of the closest color in intensity is returned.
        /// </summary>
        /// <param name="pixs">all depths; cmap ok</param>
        /// <param name="op">L_GET_BLACK_VAL, L_GET_WHITE_VAL</param>
        /// <param name="pval">pixel value</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetBlackOrWhiteVal(this Pix pixs, FlagsForGettingWhiteOrBlackValue op, out uint pval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixGetBlackOrWhiteVal((HandleRef)pixs, op, out pval);
        }

        // Full image clear/set/set-to-arbitrary-value
        /// <summary>
        /// (1) Clears all data to 0.  For 1 bpp, this is white; for grayscale
        ///     or color, this is black.
        /// (2) Caution: for colormapped pix, this sets the color to the first
        ///     one in the colormap.  Be sure that this is the intended color!
        /// </summary>
        /// <param name="pix">all depths; use cmapped with caution</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixClearAll(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixClearAll((HandleRef)pix);
        }

        /// <summary>
        /// (1) Sets all data to 1.  For 1 bpp, this is black; for grayscale
        ///     or color, this is white.
        /// (2) Caution: for colormapped pix, this sets the pixel value to the
        ///     maximum value supported by the colormap: 2^d - 1.  However, this
        ///     color may not be defined, because the colormap may not be full. 
        /// </summary>
        /// <param name="pix">all depths; use cmapped with caution</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetAll(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetAll((HandleRef)pix);
        }

        /// <summary>
        /// (1) N.B.  For all images, %grayval == 0 represents black and
        ///     %grayval == 255 represents white.
        /// (2) For depth &lt; 8, we do our best to approximate the gray level.
        ///     For 1 bpp images, any %grayval &lt; 128 is black; >= 128 is white.
        ///     For 32 bpp images, each r,g,b component is set to %grayval,
        ///     and the alpha component is preserved.
        /// (3) If pix is colormapped, it adds the gray value, replicated in
        ///     all components, to the colormap if it's not there and there
        ///     is room.  If the colormap is full, it finds the closest color in
        ///     L2 distance of components.  This index is written to all pixels.
        /// </summary>
        /// <param name="pix">all depths, cmap ok</param>
        /// <param name="grayval">in range 0 ... 255</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetAllGray(this Pix pix, int grayval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (0 > grayval
             || 255 < grayval)
            {
                throw new ArgumentException("grayval must be in range 0... 255");
            }

            return Native.DllImports.pixSetAllGray((HandleRef)pix, grayval);
        }

        /// <summary>
        /// (1) Caution 1!  For colormapped pix, %val is used as an index
        ///     into a colormap.  Be sure that index refers to the intended color.
        ///     If the color is not in the colormap, you should first add it
        ///     and then call this function.
        /// (2) Caution 2!  For 32 bpp pix, the interpretation of the LSB
        ///     of %val depends on whether spp == 3 (RGB) or spp == 4 (RGBA).
        ///     For RGB, the LSB is ignored in image transformations.
        ///     For RGBA, the LSB is interpreted as the alpha (transparency)
        ///     component; full transparency has alpha == 0x0, whereas
        ///     full opacity has alpha = 0xff.  An RGBA image with full
        ///     opacity behaves like an RGB image. 
        /// (3) As an example of (2), suppose you want to initialize a 32 bpp
        ///     pix with partial opacity, say 0xee337788.  If the pix is 3 spp,
        ///     the 0x88 alpha component will be ignored and may be changed
        ///     in subsequent processing.  However, if the pix is 4 spp, the
        ///     alpha component will be retained and used. The function
        ///     pixCreate(w, h, 32) makes an RGB image by default, and
        ///     pixSetSpp(pix, 4) can be used to promote an RGB image to RGBA.
        /// </summary>
        /// <param name="pix">all depths; use cmapped with caution</param>
        /// <param name="val">value to set all pixels</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetAllArbitrary(this Pix pix, uint val)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetAllArbitrary((HandleRef)pix, val);
        }

        /// <summary>
        /// (1) Function for setting all pixels in an image to either black
        ///     or white.
        /// (2) If pixs is colormapped, it adds black or white to the
        ///     colormap if it's not there and there is room.  If the colormap
        ///     is full, it finds the closest color in intensity.
        ///     This index is written to all pixels.
        /// </summary>
        /// <param name="pixs">all depths; cmap ok</param>
        /// <param name="op"> L_SET_BLACK, L_SET_WHITE</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetBlackOrWhite(this Pix pixs, FlagsForSettingToBlackOrWhite op)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixSetBlackOrWhite((HandleRef)pixs, op);
        }

        /// <summary>
        /// For example, this can be used to set the alpha component to opaque: pixSetComponentArbitrary(pix, L_ALPHA_CHANNEL, 255)
        /// </summary>
        /// <param name="pix">32 bpp</param>
        /// <param name="comp">COLOR_RED, COLOR_GREEN, COLOR_BLUE, L_ALPHA_CHANNEL</param>
        /// <param name="val">value to set this component</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetComponentArbitrary(this Pix pix, ColorsFor32Bpp comp, int val)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetComponentArbitrary((HandleRef)pix, comp, val);
        }

        // Rectangular region clear/set/set-to-arbitrary-value/blend
        /// <summary>
        /// (1) Clears all data in rect to 0.  For 1 bpp, this is white;
        ///     for grayscale or color, this is black.
        /// (2) Caution: for colormapped pix, this sets the color to the first
        ///     one in the colormap.Be sure that this is the intended color!
        /// </summary>
        /// <param name="pix">all depths; can be cmapped</param>
        /// <param name="box">in which all pixels will be cleared</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixClearInRect(this Pix pix, Box box)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixClearInRect((HandleRef)pix, (HandleRef)box);
        }

        /// <summary>
        /// (1) Sets all data in rect to 1.  For 1 bpp, this is black;
        ///     for grayscale or color, this is white.
        /// (2) Caution: for colormapped pix, this sets the pixel value to the
        ///     maximum value supported by the colormap: 2^d - 1.  However, this
        ///     color may not be defined, because the colormap may not be full.
        /// </summary>
        /// <param name="pix">all depths, can be cmapped</param>
        /// <param name="box">in which all pixels will be set</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetInRect(this Pix pix, Box box)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixSetInRect((HandleRef)pix, (HandleRef)box);
        }

        /// <summary>
        /// (1) For colormapped pix, be sure the value is the intended
        ///     one in the colormap.
        /// (2) Caution: for colormapped pix, this sets each pixel in the
        ///     rect to the color at the index equal to val.  Be sure that
        ///     this index exists in the colormap and that it is the intended one!
        /// </summary>
        /// <param name="pix">all depths; can be cmapped</param>
        /// <param name="box">in which all pixels will be set to val</param>
        /// <param name="val">value to set all pixels</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetInRectArbitrary(this Pix pix, Box box, uint val)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixSetInRectArbitrary((HandleRef)pix, (HandleRef)box, val);
        }

        /// <summary>
        /// (1) This is an in-place function.  It blends the input color %val
        ///     with the pixels in pixs in the specified rectangle.
        ///     If no rectangle is specified, it blends over the entire image.
        /// </summary>
        /// <param name="pixs">32 bpp rgb</param>
        /// <param name="box">[optional] in which all pixels will be blended</param>
        /// <param name="val">blend value; 0xrrggbb00</param>
        /// <param name="fract">fraction of color to be blended with each pixel in pixs</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixBlendInRect(this Pix pixs, Box box, uint val, float fract)
        {
            if (null == pixs
             || null == box)
            {
                throw new ArgumentNullException("pixs, box cannot be null");
            }
            if (32 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 32 bpp");
            }

            return Native.DllImports.pixBlendInRect((HandleRef)pixs, (HandleRef)box, val, fract);
        }

        // Set pad bits
        /// <summary>
        /// (1) The pad bits are the bits that expand each scanline to a
        ///     multiple of 32 bits.  They are usually not used in
        ///     image processing operations.  When boundary conditions
        ///     are important, as in seedfill, they must be set properly.
        /// (2) This sets the value of the pad bits (if any) in the last
        ///     32-bit word in each scanline.
        /// (3) For 32 bpp pix, there are no pad bits, so this is a no-op.
        /// (4) When writing formatted output, such as tiff, png or jpeg,
        ///     the pad bits have no effect on the raster image that is
        ///     generated by reading back from the file.  However, in some
        ///     cases, the compressed file itself will depend on the pad
        ///     bits.  This is seen, for example, in Windows with 2 and 4 bpp
        ///     tiff-compressed images that have pad bits on each scanline.
        ///     It is sometimes convenient to use a golden file with a
        ///     byte-by-byte check to verify invariance.  Consequently,
        ///     and because setting the pad bits is cheap, the pad bits are
        ///     set to 0 before writing these compressed files.
        /// </summary>
        /// <param name="pix">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="val">0 or 1</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetPadBits(this Pix pix, int val)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetPadBits((HandleRef)pix, val);
        }

        /// <summary>
        /// (1) The pad bits are the bits that expand each scanline to a
        ///     multiple of 32 bits.  They are usually not used in
        ///     image processing operations.  When boundary conditions
        ///     are important, as in seedfill, they must be set properly.
        /// (2) This sets the value of the pad bits (if any) in the last
        ///     32-bit word in each scanline, within the specified
        ///     band of raster lines.
        /// (3) For 32 bpp pix, there are no pad bits, so this is a no-op.
        /// </summary>
        /// <param name="pix">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="by">starting y value of band</param>
        /// <param name="bh">height of band</param>
        /// <param name="val">0 or 1</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetPadBitsBand(this Pix pix, int by, int bh, int val)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixSetPadBitsBand((HandleRef)pix, by, bh, val);
        }

        // Assign border pixels
        /// <summary>
        /// (1) The border region is defined to be the region in the
        ///     image within a specific distance of each edge.  Here, we
        ///     allow the pixels within a specified distance of each
        ///     edge to be set independently.  This either sets or
        ///     clears all pixels in the border region.
        /// (2) For binary images, use PIX_SET for black and PIX_CLR for white.
        /// (3) For grayscale or color images, use PIX_SET for white
        ///     and PIX_CLR for black.
        /// </summary>
        /// <param name="pixs">all depths</param>
        /// <param name="left">amount to set or clear</param>
        /// <param name="right">amount to set or clear</param>
        /// <param name="top">amount to set or clear</param>
        /// <param name="bot">amount to set or clear</param>
        /// <param name="op">PIX_SET or PIX_CLR</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetOrClearBorder(this Pix pixs, int left, int right, int top, int bot, ClearOrSetPixels op)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixSetOrClearBorder((HandleRef)pixs, left, right, top, bot, op);
        }

        /// <summary>
        /// (1) The border region is defined to be the region in the
        ///     image within a specific distance of each edge.  Here, we
        ///     allow the pixels within a specified distance of each
        ///     edge to be set independently.  This sets the pixels
        ///     in the border region to the given input value.
        /// (2) For efficiency, use pixSetOrClearBorder() if
        ///     you're setting the border to either black or white.
        /// (3) If d != 32, the input value should be masked off
        ///     to the appropriate number of least significant bits.
        /// (4) The code is easily generalized for 2 or 4 bpp.
        /// </summary>
        /// <param name="pixs">8, 16 or 32 bpp</param>
        /// <param name="left">amount to set</param>
        /// <param name="right">amount to set</param>
        /// <param name="top">amount to set</param>
        /// <param name="bot">amount to set</param>
        /// <param name="val">value to set at each border pixel</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetBorderVal(this Pix pixs, int left, int right, int top, int bot, uint val)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixSetBorderVal((HandleRef)pixs, left, right, top, bot, val);
        }

        /// <summary>
        /// (1) The rings are single-pixel-wide rectangular sets of
        ///     pixels at a given distance from the edge of the pix.
        ///     This sets all pixels in a given ring to a value.
        /// </summary>
        /// <param name="pixs">any depth; cmap OK</param>
        /// <param name="dist">distance from outside; must be > 0; first ring is 1</param>
        /// <param name="val">value to set at each border pixel</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetBorderRingVal(this Pix pixs, int dist, uint val)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (1 > dist)
            {
                throw new ArgumentException("dist must be > 1");
            }

            return Native.DllImports.pixSetBorderRingVal((HandleRef)pixs, dist, val);
        }

        /// <summary>
        /// (1) This applies what is effectively mirror boundary conditions
        ///     to a border region in the image.  It is in-place.
        /// (2) This is useful for setting pixels near the border to a
        ///     value representative of the near pixels to the interior.
        /// (3) The general pixRasterop() is used for an in-place operation here
        ///     because there is no overlap between the src and dest rectangles.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels to set</param>
        /// <param name="right">number of pixels to set</param>
        /// <param name="top">number of pixels to set</param>
        /// <param name="bot">number of pixels to set</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetMirroredBorder(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixSetMirroredBorder((HandleRef)pixs, left, right, top, bot);
        }

        /// <summary>
        /// (1) pixd can be null, but otherwise it must be the same size
        ///     and depth as pixs.  Always returns pixd.
        /// (2) This is useful in situations where by setting a few border
        ///     pixels we can avoid having to copy all pixels in pixs into
        ///     pixd as an initialization step for some operation.
        ///     Nevertheless, for safety, if making a new pixd, all the
        ///     non-border pixels are initialized to 0.
        /// </summary>
        /// <param name="pixs">same depth and size as pixd</param>
        /// <param name="pixd">all depths; colormap ok; can be NULL</param>
        /// <param name="left">number of pixels to copy</param>
        /// <param name="right">number of pixels to copy</param>
        /// <param name="top">number of pixels to copy</param>
        /// <param name="bot">number of pixels to copy</param>
        /// <returns>pixd, or NULL on error if pixd is not defined</returns>
        public static Pix pixCopyBorder(this Pix pixs, Pix pixd, int left, int right, int top, int bot)
        {
            if (null == pixs
             || null == pixd)
            {
                throw new ArgumentNullException("pixs, pixd cannot be null");
            }
            if (pixd.Depth != pixs.Depth
             || pixd.Width != pixs.Width
             || pixd.Height != pixs.Height)
            {
                throw new ArgumentException("pixs must be same depth and size as pixd");
            }

            var pointer = Native.DllImports.pixCopyBorder((HandleRef)pixd, (HandleRef)pixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Add and remove border
        /// <summary>
        /// See pixGetBlackOrWhiteVal() for values of black and white pixels.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="npix">number of pixels to be added to each side</param>
        /// <param name="val">value of added border pixels</param>
        /// <returns>pixd with the added exterior pixels, or NULL on error</returns>
        public static Pix pixAddBorder(this Pix pixs, int npix, uint val)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddBorder((HandleRef)pixs, npix, val);
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
        /// (1) See pixGetBlackOrWhiteVal() for possible side effect (adding
        ///     a color to a colormap).
        /// (2) The only complication is that pixs may have a colormap.
        ///     There are two ways to add the black or white border:
        ///     (a) As done here (simplest, most efficient)
        ///     (b) l_int32 ws, hs, d;
        ///         pixGetDimensions(pixs, &ws, &hs, &d);
        ///         Pix *pixd = pixCreate(ws + left + right, hs + top + bot, d);
        ///         PixColormap *cmap = pixGetColormap(pixs);
        ///         if (cmap != NULL)
        ///             pixSetColormap(pixd, pixcmapCopy(cmap));
        ///         pixSetBlackOrWhite(pixd, L_SET_WHITE);  // uses cmap
        ///         pixRasterop(pixd, left, top, ws, hs, PIX_SET, pixs, 0, 0);
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels added</param>
        /// <param name="right">number of pixels added</param>
        /// <param name="top">number of pixels added</param>
        /// <param name="bot">number of pixels added</param>
        /// <param name="op">L_GET_BLACK_VAL, L_GET_WHITE_VAL</param>
        /// <returns>pixd with the added exterior pixels, or NULL on error</returns>
        public static Pix pixAddBlackOrWhiteBorder(this Pix pixs, int left, int right, int top, int bot, FlagsForGettingWhiteOrBlackValue op)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddBlackOrWhiteBorder((HandleRef)pixs, left, right, top, bot, op);
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
        /// (1) For binary images:
        ///        white:  val = 0
        ///        black:  val = 1
        ///     For grayscale images:
        ///        white:  val = 2 ** d - 1
        ///        black:  val = 0
        ///     For rgb color images:
        ///        white:  val = 0xffffff00
        ///        black:  val = 0
        ///     For colormapped images, set val to the appropriate colormap index.
        /// (2) If the added border is either black or white, you can use
        ///        pixAddBlackOrWhiteBorder()
        ///     The black and white values for all images can be found with
        ///        pixGetBlackOrWhiteVal()
        ///     which, if pixs is cmapped, may add an entry to the colormap.
        ///     Alternatively, if pixs has a colormap, you can find the index
        ///     of the pixel whose intensity is closest to white or black:
        ///        white: pixcmapGetRankIntensity(cmap, 1.0, &index);
        ///        black: pixcmapGetRankIntensity(cmap, 0.0, &index);
        ///     and use that for val. 
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels added</param>
        /// <param name="right">number of pixels added</param>
        /// <param name="top">number of pixels added</param>
        /// <param name="bot">number of pixels added</param>
        /// <param name="val">value of added border pixels</param>
        /// <returns>pixd with the added exterior pixels, or NULL on error</returns>
        public static Pix pixAddBorderGeneral(this Pix pixs, int left, int right, int top, int bot, uint val)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddBorderGeneral((HandleRef)pixs, left, right, top, bot, val);
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
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="npix">number to be removed from each of the 4 sides</param>
        /// <returns>pixd with pixels removed around border, or NULL on error</returns>
        public static Pix pixRemoveBorder(this Pix pixs, int npix)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixRemoveBorder((HandleRef)pixs, npix);
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
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels removed</param>
        /// <param name="right">number of pixels removed</param>
        /// <param name="top">number of pixels removed</param>
        /// <param name="bot">number of pixels removed</param>
        /// <returns>pixd with pixels removed around border, or NULL on error</returns>
        public static Pix pixRemoveBorderGeneral(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixRemoveBorderGeneral((HandleRef)pixs, left, right, top, bot);
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
        /// (1) Removes pixels as evenly as possible from the sides of the
        ///     image, leaving the central part.
        /// (2) Returns clone if no pixels requested removed, or the target
        ///     sizes are larger than the image.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="wd">target width; use 0 if only removing from height</param>
        /// <param name="hd">target height; use 0 if only removing from width</param>
        /// <returns>pixd with pixels removed around border, or NULL on error</returns>
        public static Pix pixRemoveBorderToSize(this Pix pixs, int wd, int hd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixRemoveBorderToSize((HandleRef)pixs, wd, hd);
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
        /// (1) This applies what is effectively mirror boundary conditions.
        ///     For the added border pixels in pixd, the pixels in pixs
        ///     near the border are mirror-copied into the border region.
        /// (2) This is useful for avoiding special operations near
        ///     boundaries when doing image processing operations
        ///     such as rank filters and convolution.  In use, one first
        ///     adds mirrored pixels to each side of the image.  The number
        ///     of pixels added on each side is half the filter dimension.
        ///     Then the image processing operations proceed over a
        ///     region equal to the size of the original image, and
        ///     write directly into a dest pix of the same size as pixs.
        /// (3) The general pixRasterop() is used for an in-place operation here
        ///     because there is no overlap between the src and dest rectangles.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels added</param>
        /// <param name="right">number of pixels added</param>
        /// <param name="top">number of pixels added</param>
        /// <param name="bot">number of pixels added</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAddMirroredBorder(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddMirroredBorder((HandleRef)pixs, left, right, top, bot);
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
        /// (1) This applies a repeated border, as if the central part of
        ///     the image is tiled over the plane.  So, for example, the
        ///     pixels in the left border come from the right side of the image.
        /// (2) The general pixRasterop() is used for an in-place operation here
        ///     because there is no overlap between the src and dest rectangles.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels added</param>
        /// <param name="right">number of pixels added</param>
        /// <param name="top">number of pixels added</param>
        /// <param name="bot">number of pixels added</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAddRepeatedBorder(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddRepeatedBorder((HandleRef)pixs, left, right, top, bot);
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
        /// (1) This applies mirrored boundary conditions horizontally
        ///     and repeated b.c. vertically.
        /// (2) It is specifically used for avoiding special operations
        ///     near boundaries when convolving a hue-saturation histogram
        ///     with a given window size.  The repeated b.c. are used
        ///     vertically for hue, and the mirrored b.c. are used
        ///     horizontally for saturation.  The number of pixels added
        ///     on each side is approximately (but not quite) half the
        ///     filter dimension.  The image processing operations can
        ///     then proceed over a region equal to the size of the original
        ///     image, and write directly into a dest pix of the same
        ///     size as pixs.
        /// (3) The general pixRasterop() can be used for an in-place
        ///     operation here because there is no overlap between the
        ///     src and dest rectangles.
        /// </summary>
        /// <param name="pixs">all depths; colormap ok</param>
        /// <param name="left">number of pixels added</param>
        /// <param name="right">number of pixels added</param>
        /// <param name="top">number of pixels added</param>
        /// <param name="bot">number of pixels added</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAddMixedBorder(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddMixedBorder((HandleRef)pixs, left, right, top, bot);
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
        /// (1) This adds pixels on each side whose values are equal to
        ///     the value on the closest boundary pixel.
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="left">pixels on each side to be added</param>
        /// <param name="right">pixels on each side to be added</param>
        /// <param name="top">pixels on each side to be added</param>
        /// <param name="bot">pixels on each side to be added</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixAddContinuedBorder(this Pix pixs, int left, int right, int top, int bot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixAddContinuedBorder((HandleRef)pixs, left, right, top, bot);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Helper functions using alpha
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixd">32 bpp</param>
        /// <param name="pixs">32 bpp</param>
        /// <param name="shiftx"></param>
        /// <param name="shifty"></param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixShiftAndTransferAlpha(this Pix pixs, Pix pixd, float shiftx, float shifty)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }
            if (32 != pixs.Depth
             || 32 != pixd.Depth)
            {
                throw new ArgumentException("pixd, pixs must be 32 bpp.");
            }

            return Native.DllImports.pixShiftAndTransferAlpha((HandleRef)pixd, (HandleRef)pixs, shiftx, shifty);
        }

        /// <summary>
        /// (1) Use %val == 0xffffff00 for white background.
        /// (2) Three views are given:
        ///      ~the image with a fully opaque alpha
        ///      ~the alpha layer
        ///      ~the image as it would appear with a white background.
        /// </summary>
        /// <param name="pixs">pixs cmap or 32 bpp rgba</param>
        /// <param name="val">32 bit unsigned color to use as background</param>
        /// <param name="maxw">max output image width; 0 for no scaling</param>
        /// <returns>pixd showing various image views, or NULL on error</returns>
        public static Pix pixDisplayLayersRGBA(this Pix pixs, uint val, int maxw)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixDisplayLayersRGBA((HandleRef)pixs, val, maxw);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Color sample setting and extraction
        /// <summary>
        /// (1) the 4th byte, sometimes called the "alpha channel",
        ///     and which is often used for blending between different
        ///     images, is left with 0 value.
        /// (2) see Note (4) in pix.h for details on storage of
        ///     8-bit samples within each 32-bit word.
        /// (3) This implementation, setting the r, g and b components
        ///     sequentially, is much faster than setting them in parallel
        ///     by constructing an RGB dest pixel and writing it to dest.
        ///     The reason is there are many more cache misses when reading
        ///     from 3 input images simultaneously.
        /// </summary>
        /// <param name="pixr">8 bpp red pix</param>
        /// <param name="pixg">8 bpp green pix</param>
        /// <param name="pixb">8 bpp blue pix</param>
        /// <returns>32 bpp pix, interleaved with 4 samples/pixel, or NULL on error</returns>
        public static Pix pixCreateRGBImage(this Pix pixr, Pix pixg, Pix pixb)
        {
            if (null == pixr
             || null == pixg
             || null == pixb)
            {
                throw new ArgumentNullException("pixr, pixg, pixb cannot be null");
            }
            if (8 == pixr.Depth
             || 8 == pixg.Depth
             || 8 == pixb.Depth)
            {
                throw new ArgumentException("pixr, pixg, pixb must be 8 bpp.");
            }

            var pointer = Native.DllImports.pixCreateRGBImage((HandleRef)pixr, (HandleRef)pixg, (HandleRef)pixb);
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
        /// (1) Three calls to this function generate the r, g and b 8 bpp
        ///     component images.  This is much faster than generating the
        ///     three images in parallel, by extracting a src pixel and setting
        ///     the pixels of each component image from it.  The reason is
        ///     there are many more cache misses when writing to three
        ///     output images simultaneously.
        /// </summary>
        /// <param name="pixs">32 bpp, or colormapped</param>
        /// <param name="comp">one of {COLOR_RED, COLOR_GREEN, COLOR_BLUE, L_ALPHA_CHANNEL}</param>
        /// <returns>pixd the selected 8 bpp component image of the input 32 bpp image or NULL on error</returns>
        public static Pix pixGetRGBComponent(this Pix pixs, ColorsFor32Bpp comp)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGetRGBComponent((HandleRef)pixs, comp);
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
        /// (1) This places the 8 bpp pixel in pixs into the
        ///     specified component (properly interleaved) in pixd,
        /// (2) The two images are registered to the UL corner; the sizes
        ///     need not be the same, but a warning is issued if they differ.
        /// </summary>
        /// <param name="pixs">8 bpp</param>
        /// <param name="pixd">32 bpp</param>
        /// <param name="comp">one of {COLOR_RED, COLOR_GREEN, COLOR_BLUE, L_ALPHA_CHANNEL}</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixSetRGBComponent(this Pix pixs, Pix pixd, ColorsFor32Bpp comp)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }

            return Native.DllImports.pixSetRGBComponent((HandleRef)pixd, (HandleRef)pixs, comp);
        }

        /// <summary>
        /// In leptonica, we do not support alpha in colormaps.
        /// </summary>
        /// <param name="pixs">colormapped</param>
        /// <param name="comp">one of the set: {COLOR_RED, COLOR_GREEN, COLOR_BLUE}</param>
        /// <returns>the selected 8 bpp component image of the input cmapped image, or NULL on error</returns>
        public static Pix pixGetRGBComponentCmap(this Pix pixs, ColorsFor32Bpp comp)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }
            if (null == pixs.Colormap)
            {
                throw new ArgumentNullException("pixs must be color mapped");
            }

            var pointer = Native.DllImports.pixGetRGBComponentCmap((HandleRef)pixs, comp);
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
        /// (1) The two images are registered to the UL corner.The sizes
        ///     are usually the same, and a warning is issued if they differ.
        /// </summary>
        /// <param name="pixd">32 bpp</param>
        /// <param name="pixs">32 bpp</param>
        /// <param name="comp">one of the set: {COLOR_RED, COLOR_GREEN, COLOR_BLUE}</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixCopyRGBComponent(this Pix pixs, Pix pixd, ColorsFor32Bpp comp)
        {
            if (null == pixd
             || null == pixs)
            {
                throw new ArgumentNullException("pixd, pixs cannot be null");
            }
            if (32 != pixs.Depth
             || 32 != pixd.Depth)
            {
                throw new ArgumentException("pixd, pixs must be 32 bpp.");
            }

            return Native.DllImports.pixCopyRGBComponent((HandleRef)pixd, (HandleRef)pixs, comp);
        }

        /// <summary>
        /// (1) All channels are 8 bits: the input values must be between
        ///     0 and 255.  For speed, this is not enforced by masking
        ///     with 0xff before shifting.
        /// (2) A slower implementation uses macros:
        ///       SET_DATA_BYTE(ppixel, COLOR_RED, rval);
        ///       SET_DATA_BYTE(ppixel, COLOR_GREEN, gval);
        ///       SET_DATA_BYTE(ppixel, COLOR_BLUE, bval);
        /// </summary>
        /// <param name="rval"></param>
        /// <param name="gval"></param>
        /// <param name="bval"></param>
        /// <param name="ppixel">32-bit pixel</param>
        /// <returns>false if OK; true on error</returns>
        public static bool composeRGBPixel(int rval, int gval, int bval, out uint ppixel)
        {
            return Native.DllImports.composeRGBPixel(rval, gval, bval, out ppixel);
        }

        /// <summary>
        /// (1) All channels are 8 bits: the input values must be between
        ///     0 and 255.  For speed, this is not enforced by masking
        ///     with 0xff before shifting.
        /// </summary>
        /// <param name="rval"></param>
        /// <param name="gval"></param>
        /// <param name="bval"></param>
        /// <param name="aval"></param>
        /// <param name="ppixel">32-bit pixel</param>
        /// <returns>false if OK; true on error</returns>
        public static int composeRGBAPixel(int rval, int gval, int bval, int aval, out uint ppixel)
        {
            return Native.DllImports.composeRGBAPixel(rval, gval, bval, aval, out ppixel);
        }

        /// <summary>
        /// (1) A slower implementation uses macros:
        ///        *prval = GET_DATA_BYTE(&pixel, COLOR_RED);
        ///        *pgval = GET_DATA_BYTE(&pixel, COLOR_GREEN);
        ///        *pbval = GET_DATA_BYTE(&pixel, COLOR_BLUE);
        /// </summary>
        /// <param name="pixel">32 bit</param>
        /// <param name="prval">red component</param>
        /// <param name="pgval">green component</param>
        /// <param name="pbval">blue component</param>
        public static void extractRGBValues(uint pixel, out int prval, out int pgval, out int pbval)
        {
            Native.DllImports.extractRGBValues(pixel, out prval, out pgval, out pbval);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixel">32 bit</param>
        /// <param name="prval">red component</param>
        /// <param name="pgval">green component</param>
        /// <param name="pbval">blue component</param>
        /// <param name="paval">alpha component</param>
        public static void extractRGBAValues(uint pixel, out int prval, out int pgval, out int pbval, out int paval)
        {
            Native.DllImports.extractRGBAValues(pixel, out prval, out pgval, out pbval, out paval);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixel">32 bpp RGB</param>
        /// <param name="type">L_CHOOSE_MIN or L_CHOOSE_MAX</param>
        /// <returns>component in range [0 ... 255], or NULL on error</returns>
        public static int extractMinMaxComponent(uint pixel, MinMaxSelectionFlags type)
        {
            return Native.DllImports.extractMinMaxComponent(pixel, type);
        }

        /// <summary>
        /// This puts rgb components from the input line in pixs into the given buffers.
        /// </summary>
        /// <param name="pixs">32 bpp</param>
        /// <param name="row"></param>
        /// <param name="bufr">array of red samples; size w bytes</param>
        /// <param name="bufg">array of green samples; size w bytes</param>
        /// <param name="bufb">array of blue samples; size w bytes</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetRGBLine(this Pix pixs, int row, IntPtr bufr, IntPtr bufg, IntPtr bufb)
        {
            if (null == pixs
             || IntPtr.Zero == bufr
             || IntPtr.Zero == bufg
             || IntPtr.Zero == bufb)
            {
                throw new ArgumentNullException("pixs, bufr, bufg, bufb cannot be null");
            }

            return Native.DllImports.pixGetRGBLine((HandleRef)pixs, row, bufr, bufg, bufb);
        }

        // Conversion between big and little endians
        /// <summary>
        /// (1) This is used to convert the data in a pix to a
        ///     serialized byte buffer in raster order, and, for RGB,
        ///     in order RGBA.  This requires flipping bytes within
        ///     each 32-bit word for little-endian platforms, because the
        ///     words have a MSB-to-the-left rule, whereas byte raster-order
        ///     requires the left-most byte in each word to be byte 0.
        ///     For big-endians, no swap is necessary, so this returns a clone.
        /// (2) Unlike pixEndianByteSwap(), which swaps the bytes in-place,
        ///     this returns a new pix (or a clone).  We provide this
        ///     because often when serialization is done, the source
        ///     pix needs to be restored to canonical little-endian order,
        ///     and this requires a second byte swap.  In such a situation,
        ///     it is twice as fast to make a new pix in big-endian order,
        ///     use it, and destroy it.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixEndianByteSwapNew(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixEndianByteSwapNew((HandleRef)pixs);
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
        /// (1) This is used on little-endian platforms to swap
        ///     the bytes within a word; bytes 0 and 3 are swapped,
        ///     and bytes 1 and 2 are swapped.
        /// (2) This is required for little-endians in situations
        ///     where we convert from a serialized byte order that is
        ///     in raster order, as one typically has in file formats,
        ///     to one with MSB-to-the-left in each 32-bit word, or v.v.
        ///     See pix.h for a description of the canonical format
        ///     (MSB-to-the left) that is used for both little-endian
        ///     and big-endian platforms.   For big-endians, the
        ///     MSB-to-the-left word order has the bytes in raster
        ///     order when serialized, so no byte flipping is required.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixEndianByteSwap(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixEndianByteSwap((HandleRef)pixs);
        }

        /// <summary>
        /// (1) This is used on little-endian platforms to swap
        ///     the bytes within each word in the line of image data.
        ///     Bytes 0 <==> 3 and 1 <==> 2 are swapped in the dest
        ///     byte array data8d, relative to the pix data in datas.
        /// (2) The bytes represent 8 bit pixel values.  They are swapped
        ///     for little endians so that when the dest array (char *)datad
        ///     is addressed by bytes, the pixels are chosen sequentially
        ///     from left to right in the image.
        /// </summary>
        /// <param name="datad">dest byte array data, reordered on little-endians</param>
        /// <param name="datas">a src line of pix data</param>
        /// <param name="wpl">number of 32 bit words in the line</param>
        /// <returns>false if OK; true on error</returns>
        public static bool lineEndianByteSwap(IntPtr datad, IntPtr datas, int wpl)
        {
            if (IntPtr.Zero == datad
             || IntPtr.Zero == datas)
            {
                throw new ArgumentNullException("datad, datas cannot be null");
            }

            return Native.DllImports.lineEndianByteSwap(datad, datas, wpl);
        }

        /// <summary>
        /// (1) This is used on little-endian platforms to swap the
        ///     2-byte entities within a 32-bit word.
        /// (2) This is equivalent to a full byte swap, as performed
        ///     by pixEndianByteSwap(), followed by byte swaps in
        ///     each of the 16-bit entities separately.
        /// (3) Unlike pixEndianTwoByteSwap(), which swaps the shorts in-place,
        ///     this returns a new pix (or a clone).  We provide this
        ///     to avoid having to swap twice in situations where the input
        ///     pix must be restored to canonical little-endian order.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns></returns>
        public static Pix pixEndianTwoByteSwapNew(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixEndianTwoByteSwapNew((HandleRef)pixs);
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
        /// (1) This is used on little-endian platforms to swap the
        ///     2-byte entities within a 32-bit word.
        /// (2) This is equivalent to a full byte swap, as performed
        ///     by pixEndianByteSwap(), followed by byte swaps in
        ///     each of the 16-bit entities separately.
        /// </summary>
        /// <param name="pixs"></param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixEndianTwoByteSwap(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixEndianTwoByteSwap((HandleRef)pixs);
        }


        // Extract raster data as binary string
        /// <summary>
        /// (1) This returns the raster data as a byte string, padded to the
        ///     byte.  For 1 bpp, the first pixel is the MSbit in the first byte.
        ///     For rgb, the bytes are in (rgb) order.  This is the format
        ///     required for flate encoding of pixels in a PostScript file.
        /// </summary>
        /// <param name="pixs">1, 8, 32 bpp</param>
        /// <param name="pdata">raster data in memory</param>
        /// <param name="pnbytes">number of bytes in data string</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixGetRasterData(this Pix pixs, out IntPtr pdata, out IntPtr pnbytes)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            return Native.DllImports.pixGetRasterData((HandleRef)pixs, out pdata, out pnbytes);
        }

        // Test alpha component opaqueness
        /// <summary>
        /// On error, opaque is returned as 0 (FALSE).
        /// </summary>
        /// <param name="pix">32 bpp, spp == 4</param>
        /// <param name="popaque">true if spp == 4 and all alpha component values are 255 (opaque); 0 otherwise</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixAlphaIsOpaque(this Pix pix, out bool popaque)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (32 != pix.Depth
             || 4 != pix.Spp)
            {
                throw new ArgumentException("pix must be 32 bpp, spp == 4");
            }

            return Native.DllImports.pixAlphaIsOpaque((HandleRef)pix, out popaque);
        }

        // Setup helpers for 8 bpp byte processing
        /// <summary>
        /// (1) This is a simple helper for processing 8 bpp images with
        ///     direct byte access.  It can swap byte order within each word.
        /// (2) After processing, you must call pixCleanupByteProcessing(),
        ///     which frees the lineptr array and restores byte order.
        /// </summary>
        /// <param name="pix">8 bpp, no colormap</param>
        /// <param name="pw">width</param>
        /// <param name="ph">height</param>
        /// <returns>line ptr array, or NULL on error</returns>
        public static IntPtr pixSetupByteProcessing(this Pix pix, out int pw, out int ph)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (8 != pix.Depth
             || null != pix.Colormap)
            {
                throw new ArgumentException("pix must be 8 bpp, no colormap");
            }

            return Native.DllImports.pixSetupByteProcessing((HandleRef)pix, out pw, out ph);
        }

        /// <summary>
        /// (1) This must be called after processing that was initiated
        ///     by pixSetupByteProcessing() has finished.
        /// </summary>
        /// <param name="pix">8 bpp, no colormap</param>
        /// <param name="lineptrs">ptrs to the beginning of each raster line of data</param>
        /// <returns></returns>
        public static int pixCleanupByteProcessing(this Pix pix, out IntPtr lineptrs)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }
            if (8 != pix.Depth
             || null != pix.Colormap)
            {
                throw new ArgumentException("pix must be 8 bpp, no colormap");
            }

            return Native.DllImports.pixCleanupByteProcessing((HandleRef)pix, out lineptrs);
        }

        // Setting parameters for antialias masking with alpha transforms
        /// <summary>
        /// (1) This sets the opacity values used to generate the two outer
        ///     boundary rings in the alpha mask associated with geometric
        ///     transforms such as pixRotateWithAlpha().
        /// (2) The default values are val1 = 0.0 (completely transparent
        ///     in the outermost ring) and val2 = 0.5 (half transparent
        ///     in the second ring).  When the image is blended, this
        ///     completely removes the outer ring (shrinking the image by
        ///     2 in each direction), and alpha-blends with 0.5 the second ring.
        ///     Using val1 = 0.25 and val2 = 0.75 gives a slightly more
        ///     blurred border, with no perceptual difference at screen resolution.
        /// (3) The actual mask values are found by multiplying these
        ///     normalized opacity values by 255.
        /// </summary>
        /// <param name="val1">[0.0 ... 1.0]</param>
        /// <param name="val2">[0.0 ... 1.0]</param>
        public static void l_setAlphaMaskBorder(float val1, float val2)
        {
            Native.DllImports.l_setAlphaMaskBorder(val1, val2);
        }
    }
}
