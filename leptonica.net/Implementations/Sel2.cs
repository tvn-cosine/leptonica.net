using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Sel2
    {
        // Basic brick structuring elements 
        public static Sela selaAddBasic(this Sela sela)
        {
            var pointer = Native.DllImports.selaAddBasic((HandleRef)sela);
            return new Sela(pointer);
        }


        // Simple hit-miss structuring elements 
        public static Sela selaAddHitMiss(this Sela sela)
        {
            var pointer = Native.DllImports.selaAddHitMiss((HandleRef)sela);
            return new Sela(pointer);
        }


        // Structuring elements for comparing with DWA operations 
        public static Sela selaAddDwaLinear(this Sela sela)
        {
            var pointer = Native.DllImports.selaAddDwaLinear((HandleRef)sela);
            return new Sela(pointer);
        }

        public static Sela selaAddDwaCombs(this Sela sela)
        {
            var pointer = Native.DllImports.selaAddDwaCombs((HandleRef)sela);
            return new Sela(pointer);
        }


        // Structuring elements for the intersection of lines 
        public static Sela selaAddCrossJunctions(this Sela sela, float hlsize, float mdist, int norient, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Sela selaAddTJunctions(this Sela sela, float hlsize, float mdist, int norient, int debugflag)
        {
            throw new NotImplementedException();
        }


        // Structuring elements for connectivity-preserving thinning operations 
        public static Sela sela4ccThin(this Sela sela)
        {
            var pointer = Native.DllImports.sela4ccThin((HandleRef)sela);
            return new Sela(pointer);
        }

        public static Sela sela8ccThin(this Sela sela)
        {
            var pointer = Native.DllImports.sela8ccThin((HandleRef)sela);
            return new Sela(pointer);
        }

        public static Sela sela4and8ccThin(this Sela sela)
        {
            var pointer = Native.DllImports.sela4and8ccThin((HandleRef)sela);
            return new Sela(pointer);
        }
    }
}
