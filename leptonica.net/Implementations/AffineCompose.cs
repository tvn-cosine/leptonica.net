using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class AffineCompose
    {
        // Composable coordinate transforms 
        /// <summary>
        /// (1) The translation is equivalent to:
        ///        v' = Av
        ///     where v and v' are 1x3 column vectors in the form
        ///        v = [x, y, 1]^    ^ denotes transpose
        ///     and the affine tranlation matrix is
        ///        A = [ 1   0   tx
        ///              0   1   ty
        ///              0   0    1  ]
        ///
        /// (2) We consider translation as with respect to a fixed origin.
        ///     In a clipping operation, the origin moves and the points
        ///     are fixed, and you use (-tx, -ty) where (tx, ty) is the
        ///     translation vector of the origin.
        /// </summary>
        /// <param name="transx">x component of translation wrt. the origin</param>
        /// <param name="transy">y component of translation wrt. the origin</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static IntPtr createMatrix2dTranslate(float transx, float transy)
        {
            return Native.DllImports.createMatrix2dTranslate(transx, transy);
        }

        /// <summary>
        /// (1) The scaling is equivalent to:
        ///        v' = Av
        ///    where v and v' are 1x3 column vectors in the form
        ///         v = [x, y, 1]^    ^ denotes transpose
        ///    and the affine scaling matrix is
        ///        A = [ sx  0    0
        ///              0   sy   0
        ///              0   0    1  ]
        ///
        /// (2) We consider scaling as with respect to a fixed origin.
        ///     In other words, the origin is the only point that doesn't
        ///     move in the scaling transform.
        /// </summary>
        /// <param name="scalex">horizontal scale factor</param>
        /// <param name="scaley">vertical scale factor</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static IntPtr createMatrix2dScale(float scalex, float scaley)
        {
            return Native.DllImports.createMatrix2dScale(scalex, scaley);
        }

        /// <summary>
        /// (1) The rotation is equivalent to:
        ///        v' = Av
        ///     where v and v' are 1x3 column vectors in the form
        ///        v = [x, y, 1]^    ^ denotes transpose
        ///     and the affine rotation matrix is
        ///        A = [ cosa   -sina    xc*1-cosa + yc*sina
        ///              sina    cosa    yc*1-cosa - xc*sina
        ///                0       0                 1         ]
        ///
        ///     If the rotation is about the origin, xc, yc) = (0, 0 and
        ///     this simplifies to
        ///        A = [ cosa   -sina    0
        ///              sina    cosa    0
        ///                0       0     1 ]
        ///
        ///     These relations follow from the following equations, which
        ///     you can convince yourself are correct as follows.  Draw a
        ///     circle centered on xc,yc) and passing through (x,y), with
        ///     (x',y') on the arc at an angle 'a' clockwise from (x,y).
        ///      [ Hint: cosa + b = cosa * cosb - sina * sinb
        ///              sina + b = sina * cosb + cosa * sinb ]
        ///
        ///       x' - xc =  x - xc) * cosa - (y - yc * sina
        ///       y' - yc =  x - xc) * sina + (y - yc * cosa
        /// </summary>
        /// <param name="xc">location of center of rotation</param>
        /// <param name="yc">location of center of rotation</param>
        /// <param name="angle">rotation in radians; clockwise is positive</param>
        /// <returns>3x3 transform matrix, or NULL on error</returns>
        public static IntPtr createMatrix2dRotate(float xc, float yc, float angle)
        {
            return Native.DllImports.createMatrix2dRotate(xc, yc, angle);
        }

        // Special coordinate transforms on pta 
        /// <summary>
        /// See createMatrix2dTranslate() for details of transform.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="transx">x component of translation wrt. the origin</param>
        /// <param name="transy">y component of translation wrt. the origin</param>
        /// <returns>ptad  translated points, or NULL on error</returns>
        public static Pta ptaTranslate(this Pta ptas, float transx, float transy)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("ptas cannot be null.");
            }

            var pointer = Native.DllImports.ptaTranslate((HandleRef)ptas, transx, transy);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        /// <summary>
        /// See createMatrix2dScale() for details of transform.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="scalex">horizontal scale factor</param>
        /// <param name="scaley">vertical scale factor</param>
        /// <returns></returns>
        public static Pta ptaScale(this Pta ptas, float scalex, float scaley)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("ptas cannot be null.");
            }

            var pointer = Native.DllImports.ptaScale((HandleRef)ptas, scalex, scaley);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        /// <summary>
        /// (1) See createMatrix2dScale() for details of transform.
        /// (2) This transform can be thought of as composed of the
        ///     sum of two parts:
        ///      a) an (x,y)-dependent rotation about the origin:
        ///         xr = x * cosa - y * sina
        ///         yr = x * sina + y * cosa
        ///      b) an (x,y)-independent translation that depends on the
        ///         rotation center and the angle:
        ///         xt = xc - xc * cosa + yc * sina
        ///         yt = yc - xc * sina - yc * cosa
        ///     The translation part (xt,yt) is equal to the difference
        ///     between the center (xc,yc) and the location of the
        ///     center after it is rotated about the origin.
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="xc">location of center of rotation</param>
        /// <param name="yc">location of center of rotation</param>
        /// <param name="angle">rotation in radians; clockwise is positive</param>
        /// <returns></returns>
        public static Pta ptaRotate(this Pta ptas, float xc, float yc, float angle)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("ptas cannot be null.");
            }

            var pointer = Native.DllImports.ptaRotate((HandleRef)ptas, xc, yc, angle);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        // Special coordinate transforms on boxa 
        /// <summary>
        /// See createMatrix2dTranslate() for details of transform.
        /// </summary>
        /// <param name="boxas"></param>
        /// <param name="transx">x component of translation wrt. the origin</param>
        /// <param name="transy">y component of translation wrt. the origin</param>
        /// <returns>boxad  translated boxas, or NULL on error</returns>
        public static Boxa boxaTranslate(this Boxa boxas, float transx, float transy)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaTranslate((HandleRef)boxas, transx, transy);
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
        /// See createMatrix2dScale() for details of transform.
        /// </summary>
        /// <param name="boxas"></param>
        /// <param name="scalex">horizontal scale factor</param>
        /// <param name="scaley">vertical scale factor</param>
        /// <returns>scaled boxas, or NULL on error</returns>
        public static Boxa boxaScale(this Boxa boxas, float scalex, float scaley)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaScale((HandleRef)boxas, scalex, scaley);
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
        /// See createMatrix2dRotate() for details of transform.
        /// </summary>
        /// <param name="boxas"></param>
        /// <param name="xc">location of center of rotation</param>
        /// <param name="yc">location of center of rotation</param>
        /// <param name="angle">rotation in radians; clockwise is positive</param>
        /// <returns>scaled boxas, or NULL on error</returns>
        public static Boxa boxaRotate(this Boxa boxas, float xc, float yc, float angle)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaRotate((HandleRef)boxas, xc, yc, angle);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // General coordinate transform on pta and boxa 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptas">ptas for initial points</param>
        /// <param name="mat">3x3 transform matrix; canonical form</param>
        /// <returns>transformed points, or NULL on error</returns>
        public static Pta ptaAffineTransform(this Pta ptas, IntPtr mat)
        {
            if (null == ptas
             || IntPtr.Zero == mat)
            {
                throw new ArgumentNullException("ptas, mat cannot be null.");
            }

            var pointer = Native.DllImports.ptaAffineTransform((HandleRef)ptas, mat);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxas"></param>
        /// <param name="mat">3x3 transform matrix; canonical form</param>
        /// <returns>transformed boxas, or NULL on error</returns>
        public static Boxa boxaAffineTransform(this Boxa boxas, IntPtr mat)
        {
            if (null == boxas
             || IntPtr.Zero == mat)
            {
                throw new ArgumentNullException("boxas, mat cannot be null.");
            }

            var pointer = Native.DllImports.ptaAffineTransform((HandleRef)boxas, mat);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // Matrix operations 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat">square matrix, as a 1-dimensional %size^2 array</param>
        /// <param name="vecs">input column vector of length %size</param>
        /// <param name="vecd">result column vector</param>
        /// <param name="size">matrix is %size x %size; vectors are length %size</param>
        /// <returns>false if OK, true on error</returns>
        public static bool l_productMatVec(IntPtr mat, IntPtr vecs, IntPtr vecd, int size)
        {
            if (IntPtr.Zero == mat
             || IntPtr.Zero == vecs
             || IntPtr.Zero == vecd)
            {
                throw new ArgumentNullException("mat, vecs, vecd cannot be null.");
            }

            return Native.DllImports.l_productMatVec(mat, vecs, vecd, size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">square matrix; product stored here</param>
        /// <param name="size">size of matrices</param>
        /// <returns>false if OK, true on error</returns>
        public static bool l_productMat2(IntPtr mat1, IntPtr mat2, IntPtr matd, int size)
        {
            if (IntPtr.Zero == mat1
             || IntPtr.Zero == mat2
             || IntPtr.Zero == matd)
            {
                throw new ArgumentNullException("mat1, mat2, matd cannot be null.");
            }

            return Native.DllImports.l_productMat2(mat1, mat2, matd, size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat3">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">square matrix; product stored here</param>
        /// <param name="size">of matrices</param>
        /// <returns>false if OK, true on error</returns>
        public static bool l_productMat3(IntPtr mat1, IntPtr mat2, IntPtr mat3, IntPtr matd, int size)
        {
            if (IntPtr.Zero == mat1
             || IntPtr.Zero == mat2
             || IntPtr.Zero == mat3
             || IntPtr.Zero == matd)
            {
                throw new ArgumentNullException("mat1, mat2, mat3, matd cannot be null.");
            }

            return Native.DllImports.l_productMat3(mat1, mat2, mat3, matd, size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat2">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat3">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="mat4">square matrix, as a 1-dimensional size^2 array</param>
        /// <param name="matd">square matrix; product stored here</param>
        /// <param name="size">of matrices</param>
        /// <returns>false if OK, true on error</returns>
        public static bool l_productMat4(IntPtr mat1, IntPtr mat2, IntPtr mat3, IntPtr mat4, IntPtr matd, int size)
        {
            if (IntPtr.Zero == mat1
             || IntPtr.Zero == mat2
             || IntPtr.Zero == mat3
             || IntPtr.Zero == mat4
             || IntPtr.Zero == matd)
            {
                throw new ArgumentNullException("mat1, mat2, mat3, mat4, matd cannot be null.");
            }

            return Native.DllImports.l_productMat4(mat1, mat2, mat3, mat4, matd, size);
        }
    }
}
