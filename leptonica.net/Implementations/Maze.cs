using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Maze
    {
        // This is a game with a pedagogical slant.
        public static Pix generateBinaryMaze(int w, int h, int xi, int yi, float wallps, float ranis)
        {
            var pointer = Native.DllImports.generateBinaryMaze(w, h, xi, yi, wallps, ranis);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pta pixSearchBinaryMaze(this Pix pixs, int xi, int yi, int xf, int yf, out Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            IntPtr ppixdPtr;
            var pointer = Native.DllImports.pixSearchBinaryMaze((HandleRef)pixs, xi, yi, xf, yf, out ppixdPtr);
            ppixd = new Pix(ppixdPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        // Generalizing a maze to a grayscale image, the search is now for the  shortest  or least cost path, for some given cost function. 
        public static Pta pixSearchGrayMaze(this Pix pixs, int xi, int yi, int xf, int yf, out Pix ppixd)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs, ptad, ptas cannot be null.");
            }

            IntPtr ppixdPtr;
            var pointer = Native.DllImports.pixSearchGrayMaze((HandleRef)pixs, xi, yi, xf, yf, out ppixdPtr);
            ppixd = new Pix(ppixdPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }
    }
}
