using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Bilateral
    {
        // Top level approximate separable grayscale or color bilateral filtering
        public static Pix pixBilateral(this Pix pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBilateral((HandleRef)pixs, spatial_stdev, range_stdev, ncomps, reduction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilateralGray(this Pix pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBilateralGray((HandleRef)pixs, spatial_stdev, range_stdev, ncomps, reduction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Slow, exact implementation of grayscale or color bilateral filtering
        public static Pix pixBilateralExact(this Pix pixs, L_Kernel spatial_kel, L_Kernel range_kel)
        {
            if (null == pixs
             || null == spatial_kel
             || null == range_kel)
            {
                throw new ArgumentNullException("pixs, spatial_kel, range_kel cannot be null.");
            }

            var pointer = Native.DllImports.pixBilateralExact((HandleRef)pixs, (HandleRef)spatial_kel, (HandleRef)range_kel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBilateralGrayExact(this Pix pixs, L_Kernel spatial_kel, L_Kernel range_kel)
        {
            if (null == pixs
             || null == spatial_kel
             || null == range_kel)
            {
                throw new ArgumentNullException("pixs, spatial_kel, range_kel cannot be null.");
            }

            var pointer = Native.DllImports.pixBilateralGrayExact((HandleRef)pixs, (HandleRef)spatial_kel, (HandleRef)range_kel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlockBilateralExact(this Pix pixs, float spatial_stdev, float range_stdev)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixBlockBilateralExact((HandleRef)pixs, spatial_stdev, range_stdev);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Kernel helper function
        public static L_Kernel makeRangeKernel(float range_stdev)
        { 
            var pointer = Native.DllImports.makeRangeKernel(range_stdev);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }
    }
}
