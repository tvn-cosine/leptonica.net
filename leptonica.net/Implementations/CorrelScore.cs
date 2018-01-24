using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class CorrelScore
    {
        // Optimized 2 pix correlators(for jbig2 clustering)
        public static int pixCorrelationScore(this Pix pix1, Pix pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out float pscore)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCorrelationScore((HandleRef)pix1, (HandleRef)pix2, area1, area2, delx, dely, maxdiffw, maxdiffh, out tab, out pscore);
        }

        public static int pixCorrelationScoreThresholded(this Pix pix1, Pix pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out int downcount, float score_threshold)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCorrelationScoreThresholded((HandleRef)pix1, (HandleRef)pix2, area1, area2, delx, dely, maxdiffw, maxdiffh, out tab, out downcount, score_threshold);
        }

        // Simple 2 pix correlators
        public static int pixCorrelationScoreSimple(this Pix pix1, Pix pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out float pscore)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCorrelationScoreSimple((HandleRef)pix1, (HandleRef)pix2, area1, area2, delx, dely, maxdiffw, maxdiffh, out tab, out pscore);
        }

        public static int pixCorrelationScoreShifted(this Pix pix1, Pix pix2, int area1, int area2, int delx, int dely, out int tab, out float pscore)
        {
            if (null == pix1
             || null == pix2)
            {
                throw new ArgumentNullException("pix1, pix2 cannot be null.");
            }

            return Native.DllImports.pixCorrelationScoreShifted((HandleRef)pix1, (HandleRef)pix2, area1, area2, delx, dely, out tab, out pscore);
        } 
    }
}
