using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Skew
    {
        // Top-level deskew interfaces
        /// <summary>
        /// (1) This binarizes if necessary and does both horizontal
        ///     and vertical deskewing, using the default parameters in
        ///     the underlying pixDeskew().  See usage there.
        /// (2) This may return a clone.
        /// </summary>
        /// <param name="pixs">any depth</param>
        /// <param name="redsearch">redsearch for binary search: reduction factor = 1, 2 or 4; use 0 for default</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixDeskewBoth(this Pix pixs, int redsearch)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0");
            }

            var pointer = Native.DllImports.pixDeskewBoth((HandleRef)pixs, redsearch);
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
        /// (1) This binarizes if necessary and finds the skew angle.  If the
        ///     angle is large enough and there is sufficient confidence,
        ///     it returns a deskewed image; otherwise, it returns a clone.
        /// (2) Typical values at 300 ppi for %redsearch are 2 and 4.
        ///     At 75 ppi, one should use %redsearch = 1.
        /// </summary>
        /// <param name="pixs">any depth</param>
        /// <param name="redsearch">redsearch for binary search: reduction factor = 1, 2 or 4; use 0 for default</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixDeskew(this Pix pixs, int redsearch)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0");
            }

            var pointer = Native.DllImports.pixDeskew((HandleRef)pixs, redsearch);
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
        /// (1) This binarizes if necessary and finds the skew angle.  If the
        ///     angle is large enough and there is sufficient confidence,
        ///     it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pixs">any depth</param>
        /// <param name="redsearch">for binary search: reduction factor = 1, 2 or 4; use 0 for default</param>
        /// <param name="pangle">angle required to deskew, in degrees</param>
        /// <param name="pconf">conf value is ratio of max/min scores</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixFindSkewAndDeskew(this Pix pixs, int redsearch, out float pangle, out float pconf)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0");
            }

            var pointer = Native.DllImports.pixFindSkewAndDeskew((HandleRef)pixs, redsearch, out pangle, out pconf);
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
        ///      (1) This binarizes if necessary and finds the skew angle.If the
        /// angle is large enough and there is sufficient confidence,
        /// it returns a deskewed image; otherwise, it returns a clone.
        /// </summary>
        /// <param name="pixs">any depth</param>
        /// <param name="redsweep">for linear search: reduction factor = 1, 2 or 4;  use 0 for default</param>
        /// <param name="sweeprange">in degrees in each direction from 0; use 0.0 for default</param>
        /// <param name="sweepdelta">in degrees; use 0.0 for default</param>
        /// <param name="redsearch">for binary search: reduction factor = 1, 2 or 4;use 0 for default;</param>
        /// <param name="thresh">for binarizing the image; use 0 for default</param>
        /// <param name="pangle">angle required to deskew, in degrees</param>
        /// <param name="pconf">conf value is ratio of max/min scores</param>
        /// <returns>pixd deskewed pix, or NULL on error</returns>
        public static Pix pixDeskewGeneral(this Pix pixs, int redsweep, float sweeprange, float sweepdelta, int redsearch, int thresh, out float pangle, out float pconf)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (!(0 == redsweep
               || 1 == redsweep
               || 2 == redsweep
               || 4 == redsweep))
            {
                throw new ArgumentException("redsweep must be 1, 2, 4 or 0");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0");
            }

            var pointer = Native.DllImports.pixDeskewGeneral((HandleRef)pixs, redsweep, sweeprange, sweepdelta, redsearch, thresh, out pangle, out pconf);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Top-level angle-finding interface
        /// <summary>
        /// (1) This is a simple high-level interface, that uses default
        ///     values of the parameters for reasonable speed and accuracy.
        /// (2) The angle returned is the negative of the skew angle of
        ///     the image.  It is the angle required for deskew.
        ///     Clockwise rotations are positive angles.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew, in degrees</param>
        /// <param name="pconf">confidence value is ratio max/min scores</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkew(this Pix pixs, out float pangle, out float pconf)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }

            return Native.DllImports.pixFindSkew((HandleRef)pixs, out pangle, out pconf);
        }


        // Basic angle-finding functions
        /// <summary>
        /// (1) This examines the 'score' for skew angles with equal intervals.
        /// (2) Caller must check the return value for validity of the result.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew, in degrees</param>
        /// <param name="reduction">factor = 1, 2, 4 or 8</param>
        /// <param name="sweeprange">half the full range; assumed about 0; in degrees</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkewSweep(this Pix pixs, out float pangle, int reduction, float sweeprange, float sweepdelta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }

            return Native.DllImports.pixFindSkewSweep((HandleRef)pixs, out pangle, reduction, sweeprange, sweepdelta);
        }

        /// <summary>
        /// (1) This finds the skew angle, doing first a sweep through a set
        ///     of equal angles, and then doing a binary search until
        ///     convergence.
        /// (2) Caller must check the return value for validity of the result.
        /// (3) In computing the differential line sum variance score, we sum
        ///     the result over scanlines, but we always skip:
        ///      ~ at least one scanline
        ///      ~ not more than 10% of the image height
        ///      ~ not more than 5% of the image width
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew; in degrees</param>
        /// <param name="pconf">confidence given by ratio of max/min score</param>
        /// <param name="redsweep">sweep reduction factor = 1, 2, 4 or 8</param>
        /// <param name="redsearch">binary search reduction factor = 1, 2, 4 or 8; and must not exceed redsweep</param>
        /// <param name="sweeprange">half the full range, assumed about 0; in degrees</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees</param>
        /// <param name="minbsdelta">min binary search increment angle; in degrees</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkewSweepAndSearch(this Pix pixs, out float pangle, out float pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }
            if (!(0 == redsweep
               || 1 == redsweep
               || 2 == redsweep
               || 4 == redsweep))
            {
                throw new ArgumentException("redsweep must be 1, 2, 4 or 0");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch
               || redsearch > redsweep))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0 and must not exceed redsweep");
            }

            return Native.DllImports.pixFindSkewSweepAndSearch((HandleRef)pixs, out pangle, out pconf, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta);
        }

        /// <summary>
        /// (1) This finds the skew angle, doing first a sweep through a set
        ///     of equal angles, and then doing a binary search until convergence.
        /// (2) There are two built-in constants that determine if the
        ///     returned confidence is nonzero:
        ///       ~ MIN_VALID_MAXSCORE (minimum allowed maxscore)
        ///       ~ MINSCORE_THRESHOLD_CONSTANT (determines minimum allowed
        ///            minscore, by multiplying by (height * width^2)
        ///     If either of these conditions is not satisfied, the returned
        ///     confidence value will be zero.  The maxscore is optionally
        ///     returned in this function to allow evaluation of the
        ///     resulting angle by a method that is independent of the
        ///     returned confidence value.
        /// (3) The larger the confidence value, the greater the probability
        ///     that the proper alignment is given by the angle that maximizes
        ///     variance.  It should be compared to a threshold, which depends
        ///     on the application.  Values between 3.0 and 6.0 are common.
        /// (4) By default, the shear is about the UL corner.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew; in degrees</param>
        /// <param name="pconf">confidence given by ratio of max/min score</param>
        /// <param name="pendscore">max score;</param>
        /// <param name="redsweep">sweep reduction factor = 1, 2, 4 or 8</param>
        /// <param name="redsearch">binary search reduction factor = 1, 2, 4 or 8; and must not exceed redsweep</param>
        /// <param name="sweepcenter">angle about which sweep is performed; in degrees</param>
        /// <param name="sweeprange">half the full range, taken about sweepcenter;in degrees</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees</param>
        /// <param name="minbsdelta">min binary search increment angle; in degrees</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkewSweepAndSearchScore(this Pix pixs, out float pangle, out float pconf, out float pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }
            if (!(0 == redsweep
               || 1 == redsweep
               || 2 == redsweep
               || 4 == redsweep))
            {
                throw new ArgumentException("redsweep must be 1, 2, 4 or 0");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch
               || redsearch > redsweep))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0 and must not exceed redsweep");
            }

            return Native.DllImports.pixFindSkewSweepAndSearchScore((HandleRef)pixs, out pangle, out pconf, out pendscore, redsweep, redsearch, sweepcenter, sweeprange, sweepdelta, minbsdelta);
        }

        /// <summary>
        /// (1) See notes in pixFindSkewSweepAndSearchScore().
        /// (2) This allows choice of shear pivoting from either the UL corner
        ///     or the center.  For small angles, the ability to discriminate
        ///     angles is better with shearing from the UL corner.  However,
        ///     for large angles (say, greater than 20 degrees), it is better
        ///     to shear about the center because a shear from the UL corner
        ///     loses too much of the image.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew; in degrees</param>
        /// <param name="pconf">confidence given by ratio of max/min score</param>
        /// <param name="pendscore">max score</param>
        /// <param name="redsweep">weep reduction factor = 1, 2, 4 or 8</param>
        /// <param name="redsearch">binary search reduction factor = 1, 2, 4 or 8; and must not exceed redsweep</param>
        /// <param name="sweepcenter">angle about which sweep is performed; in degrees</param>
        /// <param name="sweeprange">half the full range, taken about sweepcenter; in degrees</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees</param>
        /// <param name="minbsdelta">min binary search increment angle; in degrees</param>
        /// <param name="pivot">L_SHEAR_ABOUT_CORNER, L_SHEAR_ABOUT_CENTER</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkewSweepAndSearchScorePivot(this Pix pixs, out float pangle, out float pconf, out float pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta, ShearFlags pivot)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }
            if (!(0 == redsweep
               || 1 == redsweep
               || 2 == redsweep
               || 4 == redsweep))
            {
                throw new ArgumentException("redsweep must be 1, 2, 4 or 0");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch
               || redsearch > redsweep))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0 and must not exceed redsweep");
            }

            return Native.DllImports.pixFindSkewSweepAndSearchScorePivot((HandleRef)pixs, out pangle, out pconf, out pendscore, redsweep, redsearch, sweepcenter, sweeprange, sweepdelta, minbsdelta, pivot);
        }


        // Search over arbitrary range of angles in orthogonal directions
        /// <summary>
        ///  (1) This searches for the skew angle, first in the range
        ///      [-sweeprange, sweeprange], and then in
        ///      [90 - sweeprange, 90 + sweeprange], with angles measured
        ///      clockwise.  For exploring the full range of possibilities,
        ///      suggest using sweeprange = 47.0 degrees, giving some overlap
        ///      at 45 and 135 degrees.  From these results, and discounting
        ///      the the second confidence by %confprior, it selects the
        ///      angle for maximal differential variance.  If the angle
        ///      is larger than pi/4, the angle found after 90 degree rotation
        ///      is selected.
        ///  (2) The larger the confidence value, the greater the probability
        ///      that the proper alignment is given by the angle that maximizes
        ///      variance.  It should be compared to a threshold, which depends
        ///      on the application.  Values between 3.0 and 6.0 are common.
        ///  (3) Allowing for both portrait and landscape searches is more
        ///      difficult, because if the signal from the text lines is weak,
        ///      a signal from vertical rules can be larger!
        ///      The most difficult documents to deskew have some or all of:
        ///        (a) Multiple columns, not aligned
        ///        (b) Black lines along the vertical edges
        ///        (c) Text from two pages, and at different angles
        ///      Rule of thumb for resolution:
        ///        (a) If the margins are clean, you can work at 75 ppi,
        ///            although 100 ppi is safer.
        ///        (b) If there are vertical lines in the margins, do not
        ///            work below 150 ppi.  The signal from the text lines must
        ///            exceed that from the margin lines.
        ///  (4) Choosing the %confprior parameter depends on knowing something
        ///      about the source of image.  However, we're not using
        ///      real probabilities here, so its use is qualitative.
        ///      If landscape and portrait are equally likely, use
        ///      %confprior = 0.0.  If the likelihood of portrait (non-rotated)
        ///      is 100 times higher than that of landscape, we want to reduce
        ///      the chance that we rotate to landscape in a situation where
        ///      the landscape signal is accidentally larger than the
        ///      portrait signal.  To do this use a positive value of
        ///      %confprior; say 1.5.
        /// </summary>
        /// <param name="pixs">1 bpp</param>
        /// <param name="pangle">angle required to deskew; in degrees</param>
        /// <param name="pconf">confidence given by ratio of max/min score</param>
        /// <param name="redsweep">weep reduction factor = 1, 2, 4 or 8</param>
        /// <param name="redsearch">binary search reduction factor = 1, 2, 4 or 8; and must not exceed redsweep</param>
        /// <param name="sweeprange">half the full range, taken about sweepcenter; in degrees</param>
        /// <param name="sweepdelta">angle increment of sweep; in degrees</param>
        /// <param name="minbsdelta">binary search increment angle; in degrees</param>
        /// <param name="confprior">amount by which confidence of 90 degree rotated result is reduced when comparing with unrotated confidence value</param>
        /// <returns>false if OK, true on error or if angle measurment not valid</returns>
        public static bool pixFindSkewOrthogonalRange(this Pix pixs, out float pangle, out float pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, float confprior)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            if (1 != pixs.Depth)
            {
                throw new ArgumentException("pixs is not 1 bpp");
            }
            if (!(0 == redsweep
               || 1 == redsweep
               || 2 == redsweep
               || 4 == redsweep))
            {
                throw new ArgumentException("redsweep must be 1, 2, 4 or 0");
            }
            if (!(0 == redsearch
               || 1 == redsearch
               || 2 == redsearch
               || 4 == redsearch
               || redsearch > redsweep))
            {
                throw new ArgumentException("redsearch must be 1, 2, 4 or 0 and must not exceed redsweep");
            }

            return Native.DllImports.pixFindSkewOrthogonalRange((HandleRef)pixs, out pangle, out pconf, redsweep, redsearch, sweeprange, sweepdelta, minbsdelta, confprior);
        }


        // Differential square sum function for scoring
        /// <summary>
        /// (1) At the top and bottom, we skip:
        ///      ~ at least one scanline
        ///      ~ not more than 10% of the image height
        ///      ~ not more than 5% of the image width
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="psum"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixFindDifferentialSquareSum(this Pix pixs, out float psum)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            return Native.DllImports.pixFindDifferentialSquareSum((HandleRef)pixs, out psum);
        }


        // Measures of variance of row sums
        /// <summary>
        /// (1) Let the image have h scanlines and N fg pixels.
        ///     If the pixels were uniformly distributed on scanlines,
        ///     the sum of squares of fg pixels on each scanline would be
        ///     h * (N / h)^2.  However, if the pixels are not uniformly
        ///     distributed (e.g., for text), the sum of squares of fg
        ///     pixels will be larger.  We return in hratio and vratio the
        ///     ratio of these two values.
        /// (2) If there are no fg pixels, hratio and vratio are returned as 0.0.
        /// </summary>
        /// <param name="pixs"></param>
        /// <param name="phratio">ratio of normalized horiz square sum to result if the pixel distribution were uniform</param>
        /// <param name="pvratio">ratio of normalized vert square sum to result if the pixel distribution were uniform</param>
        /// <param name="pfract">ratio of fg pixels to total pixels</param>
        /// <returns>false if OK, true on error or if there are no fg pixels</returns>
        public static bool pixFindNormalizedSquareSum(this Pix pixs, out float phratio, out float pvratio, out float pfract)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }
            return Native.DllImports.pixFindNormalizedSquareSum((HandleRef)pixs, out phratio, out pvratio, out pfract);
        }
    }
}
