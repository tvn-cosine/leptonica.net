using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class GrayQuantLow
    {
        // Floyd-Steinberg dithering to binary
        public static void ditherToBinaryLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip)
        {
            Native.DllImports.ditherToBinaryLow(datad, w, h, wpld, datas, wpls, bufs1, bufs2, lowerclip, upperclip);
        }

        public static void ditherToBinaryLineLow(IntPtr lined, int w, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip, int lastlineflag)
        {
            Native.DllImports.ditherToBinaryLineLow(lined, w, bufs1, bufs2, lowerclip, upperclip, lastlineflag);
        }

        // Simple(pixelwise) binarization
        public static void thresholdToBinaryLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int d, int wpls, int thresh)
        {
            Native.DllImports.thresholdToBinaryLow(datad, w, h, wpld, datas, d, wpls, thresh);
        }

        public static void thresholdToBinaryLineLow(IntPtr lined, int w, IntPtr lines, int d, int thresh)
        {
            Native.DllImports.thresholdToBinaryLineLow(lined, w, lines, d, thresh);
        }


        // Thresholding from 8 bpp to 2 bpp 
        // Floyd-Steinberg-like dithering to 2 bpp
        public static void ditherTo2bppLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14)
        {
            Native.DllImports.ditherTo2bppLow(datad, w, h, wpld, datas, wpls, bufs1, bufs2, tabval, tab38, tab14);
        }

        public static void ditherTo2bppLineLow(IntPtr lined, int w, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14, int lastlineflag)
        {
            Native.DllImports.ditherTo2bppLineLow(lined, w, bufs1, bufs2, tabval, tab38, tab14, lastlineflag);
        }

        public static int make8To2DitherTables(out IntPtr ptabval, out IntPtr ptab38, out IntPtr ptab14, int cliptoblack, int cliptowhite)
        {
            return Native.DllImports.make8To2DitherTables(out ptabval, out ptab38, out ptab14, cliptoblack, cliptowhite);
        }

        // Simple thresholding to 2 bpp
        public static void thresholdTo2bppLow(IntPtr datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab)
        {
            Native.DllImports.thresholdTo2bppLow(datad, h, wpld, datas, wpls, tab);
        }

        // Thresholding from 8 bpp to 4 bpp

        // Simple thresholding to 4 bpp
        public static void thresholdTo4bppLow(IntPtr datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab)
        {
            Native.DllImports.thresholdTo4bppLow(datad, h, wpld, datas, wpls, tab);
        }
    }
}
