using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Shear
    {
        // About arbitrary lines
        public static Pix pixHShear(this Pix pixd, Pix pixs, int yloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixVShear(this Pix pixd, Pix pixs, int xloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }


        // About special 'points': UL corner and center
        public static Pix pixHShearCorner(this Pix pixd, Pix pixs, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixVShearCorner(this Pix pixd, Pix pixs, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixHShearCenter(this Pix pixd, Pix pixs, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixVShearCenter(this Pix pixd, Pix pixs, float radang, int incolor)
        {
            throw new NotImplementedException();
        }


        // In place about arbitrary lines
        public static int pixHShearIP(this Pix pixs, int yloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static int pixVShearIP(this Pix pixs, int xloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }


        // Linear interpolated shear about arbitrary lines
        public static Pix pixHShearLI(this Pix pixs, int yloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }

        public static Pix pixVShearLI(this Pix pixs, int xloc, float radang, int incolor)
        {
            throw new NotImplementedException();
        }
    }
}
