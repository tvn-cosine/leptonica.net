using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class FMorphAuto
    {
        // Main function calls:
        public static int fmorphautogen(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fmorphautogen((HandleRef)sela, fileindex, filename);
        }

        public static int fmorphautogen1(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fmorphautogen1((HandleRef)sela, fileindex, filename);
        }

        public static int fmorphautogen2(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fmorphautogen2((HandleRef)sela, fileindex, filename);
        }
    }
}
