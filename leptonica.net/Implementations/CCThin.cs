﻿using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class CCThin
    {
        public static Pixa pixaThinConnected(this Pixa pixas, ThinningFlags type, int connectivity, int maxiters)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null.");
            }

            var pointer = Native.DllImports.pixaThinConnected((HandleRef)pixas, (int)type, connectivity, maxiters);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pix pixThinConnected(this Pix pixs, ThinningFlags type, int connectivity, int maxiters)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixThinConnected((HandleRef)pixs, (int)type, connectivity, maxiters);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixThinConnectedBySet(this Pix pixs, ThinningFlags type, Sela sela, int maxiters)
        {
            if (null == pixs
             || null == sela)
            {
                throw new ArgumentNullException("pixs, sela cannot be null.");
            }

            var pointer = Native.DllImports.pixThinConnectedBySet((HandleRef)pixs, (int)type, (HandleRef)sela, maxiters);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Sela selaMakeThinSets(int index, int debug)
        {
            var pointer = Native.DllImports.selaMakeThinSets(index, debug);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Sela(pointer);
            }
        }
    }
}
