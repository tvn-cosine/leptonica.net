using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixArith
    {
        // One-image grayscale arithmetic operations(8, 16, 32 bpp)
         public static  int pixAddConstantGray(this Pix pixs, int val)
        {
            throw new NotImplementedException();
        }

        public static  int pixMultConstantGray(this Pix pixs, float val)
        {
            throw new NotImplementedException();
        }


        // Two-image grayscale arithmetic operations(8, 16, 32 bpp)
        public static  Pix pixAddGray(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            var pointer = Native.DllImports.pixAddGray((HandleRef)pixd, (HandleRef)pixs1, (HandleRef)pixs2);
            return new Pix(pointer);
        }

        public static  Pix pixSubtractGray(this Pix pixd, Pix pixs1, Pix pixs2)
        {
            throw new NotImplementedException();
        }


        // Grayscale threshold operation(8, 16, 32 bpp)
        public static  Pix pixThresholdToValue(this Pix pixd, Pix pixs, int threshval, int setval)
        {
            var pointer = Native.DllImports.pixThresholdToValue((HandleRef)pixd, (HandleRef)pixs, threshval, setval);
            return new Pix(pointer);
        }


        // Image accumulator arithmetic operations
        public static  Pix pixInitAccumulate(int w, int h, uint offset)
        {
            throw new NotImplementedException();
        }

        public static  Pix pixFinalAccumulate(this Pix pixs, uint offset, int depth)
        {
            throw new NotImplementedException();
        }

        public static  Pix pixFinalAccumulateThreshold(this Pix pixs, uint offset, uint threshold)
        {
            throw new NotImplementedException();
        }

        public static  int pixAccumulate(this Pix pixd, Pix pixs, int op)
        {
            throw new NotImplementedException();
        }

        public static  int pixMultConstAccumulate(this Pix pixs, float factor, uint offset)
        {
            throw new NotImplementedException();
        }


        // Absolute value of difference
        public static  Pix pixAbsDifference(this Pix pixs1, Pix pixs2)
        {
            throw new NotImplementedException();
        }


        // Sum of color images
        public static  Pix pixAddRGB(this Pix pixs1, Pix pixs2)
        {
            throw new NotImplementedException();
        }


        // Two-image min and max operations(8 and 16 bpp)
        public static  Pix pixMinOrMax(this Pix pixd, Pix pixs1, Pix pixs2, int type)
        {
            throw new NotImplementedException();
        }


        // Scale pix for maximum dynamic range
        public static  Pix pixMaxDynamicRange(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }

        public static  Pix pixMaxDynamicRangeRGB(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }


        // RGB pixel value scaling
        public static  uint linearScaleRGBVal(uint sval, float factor)
        {
            throw new NotImplementedException();
        }

        public static  uint logScaleRGBVal(uint sval, IntPtr tab, float factor)
        {
            throw new NotImplementedException();
        }


        // Log base2 lookup
        public static  IntPtr makeLogBase2Tab(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static  float getLogBase2(int val, IntPtr logtab)
        {
            throw new NotImplementedException();
        }

    }
}
