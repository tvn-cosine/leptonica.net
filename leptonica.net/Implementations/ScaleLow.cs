using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ScaleLow
    {
        // Color(interpolated) scaling: general case
         public static  void scaleColorLILow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }


        // Grayscale(interpolated) scaling: general case
        public static  void scaleGrayLILow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }


        // Color(interpolated) scaling: 2x upscaling
        public static  void scaleColor2xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }

        public static  void scaleColor2xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag)
        {
            throw new NotImplementedException();
        }


        // Grayscale(interpolated) scaling: 2x upscaling
        public static  void scaleGray2xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }

        public static  void scaleGray2xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag)
        {
            throw new NotImplementedException();
        }


        // Grayscale(interpolated) scaling: 4x upscaling
        public static  void scaleGray4xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }

        public static  void scaleGray4xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag)
        {
            throw new NotImplementedException();
        }


        // Grayscale and color scaling by closest pixel sampling
        public static  int scaleBySamplingLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls)
        {
            throw new NotImplementedException();
        }


        // Color and grayscale downsampling with(antialias) lowpass filter
        public static  int scaleSmoothLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls, int size)
        {
            throw new NotImplementedException();
        }

        public static  void scaleRGBToGray2Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, float rwt, float gwt, float bwt)
        {
            throw new NotImplementedException();
        }


        // Color and grayscale downsampling with(antialias) area mapping
        public static  void scaleColorAreaMapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }

        public static  void scaleGrayAreaMapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }

        public static  void scaleAreaMapLow2(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int d, int wpls)
        {
            throw new NotImplementedException();
        }


        // Binary scaling by closest pixel sampling
        public static  int scaleBinaryLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 2x
        public static  void scaleToGray2Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeSumTabSG2(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeValTabSG2(IntPtr v)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 3x
        public static  void scaleToGray3Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeSumTabSG3(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeValTabSG3(IntPtr v)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 4x
        public static  void scaleToGray4Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeSumTabSG4(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeValTabSG4(IntPtr v)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 6x
        public static  void scaleToGray6Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeValTabSG6(IntPtr v)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 8x
        public static  void scaleToGray8Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr makeValTabSG8(IntPtr v)
        {
            throw new NotImplementedException();
        }


        // Scale-to-gray 16x
        public static  void scaleToGray16Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8)
        {
            throw new NotImplementedException();
        }


        // Grayscale mipmap
        public static  int scaleMipmapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas1, int wpls1, IntPtr datas2, int wpls2, float red)
        {
            throw new NotImplementedException();
        } 
    }
}
