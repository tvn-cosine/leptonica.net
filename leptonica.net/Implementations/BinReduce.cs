using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class BinReduce
    {
        // Subsampled 2x reduction
        public static Pix pixReduceBinary2(this Pix pixs, IntPtr intab)
        {
            if (null == pixs
             || IntPtr.Zero == intab)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixReduceBinary2((HandleRef)pixs, intab);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Rank filtered 2x reductions
        public static Pix pixReduceRankBinaryCascade(this Pix pixs, int level1, int level2, int level3, int level4)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixReduceRankBinaryCascade((HandleRef)pixs, level1, level2, level3, level4);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixReduceRankBinary2(this Pix pixs, int level, IntPtr intab)
        {
            if (null == pixs)
             //|| IntPtr.Zero == intab)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixReduceRankBinary2((HandleRef)pixs, level, intab);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Permutation table for 2x rank binary reduction
        public static IntPtr makeSubsampleTab2x(IntPtr v)
        {
            if (IntPtr.Zero == v)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.makeSubsampleTab2x(v); 
        }
    }
}
