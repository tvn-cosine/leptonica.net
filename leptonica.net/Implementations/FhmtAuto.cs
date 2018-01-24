using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class FhmtAuto
    {
        // Main function calls:
        public static int fhmtautogen(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fhmtautogen((HandleRef)sela, fileindex, filename);
        }

        public static int fhmtautogen1(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fhmtautogen1((HandleRef)sela, fileindex, filename);
        }

        public static int fhmtautogen2(this Sela sela, int fileindex, string filename)
        {
            if (null == sela)
            {
                throw new ArgumentNullException("sela cannot be null.");
            }

            return Native.DllImports.fhmtautogen2((HandleRef)sela, fileindex, filename);
        } 
    }
}
