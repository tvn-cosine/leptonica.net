using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Rank
    {
        public static Pix pixRankFilter(this Pix pixs, int wf, int hf, float rank)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRankFilterRGB(this Pix pixs, int wf, int hf, float rank)
        {
            throw new NotImplementedException();
        }

        public static Pix pixRankFilterGray(this Pix pixs, int wf, int hf, float rank)
        {
            throw new NotImplementedException();
        }


        // Median filter 
        public static Pix pixMedianFilter(this Pix pixs, int wf, int hf)
        {
            throw new NotImplementedException();
        }


        // Rank filter(accelerated with downscaling) 
        public static Pix pixRankFilterWithScaling(this Pix pixs, int wf, int hf, float rank, float scalefactor)
        {
            throw new NotImplementedException();
        } 
    }
}
