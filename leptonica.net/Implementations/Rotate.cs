using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Rotate
    {
        // General rotation about image center
        /// <summary>
        ///      (1) This is a high-level, simple interface for rotating images
        ///          about their center.
        ///      (2) For very small rotations, just return a clone.
        ///      (3) Rotation brings either white or black pixels in
        ///          from outside the image.
        ///      (4) The rotation type is adjusted if necessary for the image
        ///          depth and size of rotation angle.For 1 bpp images, we
        /// rotate either by shear or sampling.
        ///      (5) Colormaps are removed for rotation by area mapping.
        ///      (6) The dest can be expanded so that no image pixels
        ///          are lost.To invoke expansion, input the original
        /// width and height.  For repeated rotation, use of the
        /// original width and height allows the expansion to
        /// stop at the maximum required size, which is a square
        ///          with side = sqrt(w * w + h * h).
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 32 bpp rgb</param>
        /// <param name="angle">radians; clockwise is positive</param>
        /// <param name="type">L_ROTATE_AREA_MAP, L_ROTATE_SHEAR, L_ROTATE_SAMPLING</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <param name="width">original width; use 0 to avoid embedding</param>
        /// <param name="height">original height; use 0 to avoid embedding</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixRotate(this Pix pixs, float angle, RotateFlags type, BackgroundFlags incolor, int width, int height)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            var pointer = Native.DllImports.pixRotate((HandleRef)pixs, angle, type, incolor, width, height);
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
        /// (1) For very small rotations, just return a clone.
        /// (2) Generate larger image to embed pixs if necessary, and
        ///     place the center of the input image in the center.
        /// (3) Rotation brings either white or black pixels in
        ///     from outside the image.  For colormapped images where
        ///     there is no white or black, a new color is added if
        ///     possible for these pixels; otherwise, either the
        ///     lightest or darkest color is used.  In most cases,
        ///     the colormap will be removed prior to rotation.
        /// (4) The dest is to be expanded so that no image pixels
        ///     are lost after rotation.  Input of the original width
        ///     and height allows the expansion to stop at the maximum
        ///     required size, which is a square with side equal to
        ///     sqrt(w*w + h*h).
        /// (5) For an arbitrary angle, the expansion can be found by
        ///     considering the UL and UR corners.  As the image is
        ///     rotated, these move in an arc centered at the center of
        ///     the image.  Normalize to a unit circle by dividing by half
        ///     the image diagonal.  After a rotation of T radians, the UL
        ///     and UR corners are at points T radians along the unit
        ///     circle.  Compute the x and y coordinates of both these
        ///     points and take the max of absolute values; these represent
        ///     the half width and half height of the containing rectangle.
        ///     The arithmetic is done using formulas for sin(a+b) and cos(a+b),
        ///     where b = T.  For the UR corner, sin(a) = h/d and cos(a) = w/d.
        ///     For the UL corner, replace a by (pi - a), and you have
        ///     sin(pi - a) = h/d, cos(pi - a) = -w/d.  The equations
        ///     given below follow directly.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 32 bpp rgb</param>
        /// <param name="angle">radians; clockwise is positive</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <param name="width">original width; use 0 to avoid embedding</param>
        /// <param name="height">original height; use 0 to avoid embedding</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixEmbedForRotation(this Pix pixs, float angle, BackgroundFlags incolor, int width, int height)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            var pointer = Native.DllImports.pixEmbedForRotation((HandleRef)pixs, angle, incolor, width, height);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // General rotation by sampling
        /// <summary>
        /// (1) For very small rotations, just return a clone.
        /// (2) Rotation brings either white or black pixels in
        ///     from outside the image.
        /// (3) Colormaps are retained.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp rgb; can be cmapped</param>
        /// <param name="xcen">x value of center of rotation</param>
        /// <param name="ycen">y value of center of rotation</param>
        /// <param name="angle">radians; clockwise is positive</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixRotateBySampling(this Pix pixs, int xcen, int ycen, float angle, BackgroundFlags incolor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            var pointer = Native.DllImports.pixRotateBySampling((HandleRef)pixs, xcen, ycen, angle, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Nice(slow) rotation of 1 bpp image
        /// <summary>
        /// (1) For very small rotations, just return a clone.
        /// (2) This does a computationally expensive rotation of 1 bpp images.
        ///     The fastest rotators (using shears or subsampling) leave
        ///     visible horizontal and vertical shear lines across which
        ///     the image shear changes by one pixel.  To ameliorate the
        ///     visual effect one can introduce random dithering.  One
        ///     way to do this in a not-too-random fashion is given here.
        ///     We convert to 8 bpp, do a very small blur, rotate using
        ///     linear interpolation (same as area mapping), do a
        ///     small amount of sharpening to compensate for the initial
        ///     blur, and threshold back to binary.  The shear lines
        ///     are magically removed.
        /// (3) This operation is about 5x slower than rotation by sampling.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="angle">radians; clockwise is positive; about the center</param>
        /// <param name="incolor">L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
        /// <returns>pixd, or NULL on error</returns>
        public static Pix pixRotateBinaryNice(this Pix pixs, float angle, BackgroundFlags incolor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs must be 1 bpp.");
            }

            var pointer = Native.DllImports.pixRotateBinaryNice((HandleRef)pixs, angle, incolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Rotation including alpha(blend) component
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">32 bpp rgb or cmapped</param>
        /// <param name="angle">radians; clockwise is positive</param>
        /// <param name="pixg">[optional] 8 bpp, can be null</param>
        /// <param name="fract">between 0.0 and 1.0, with 0.0 fully transparent and 1.0 fully opaque</param>
        /// <returns></returns>
        public static Pix pixRotateWithAlpha(this Pix pixs, float angle, Pix pixg, float fract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
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
                throw new ArgumentException("fract only between 0.0 and 1.0.");
            }

            var pointer = Native.DllImports.pixRotateWithAlpha((HandleRef)pixs, angle, (HandleRef)pixg, fract);
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
