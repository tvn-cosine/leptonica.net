using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Stack
    {
        // Create/Destroy
        public static L_Stack lstackCreate(int nalloc)
        {
            throw new NotImplementedException();
        }

        public static void lstackDestroy(this L_Stack plstack, int freeflag)
        {
            throw new NotImplementedException();
        }


        // Accessors
        public static int lstackAdd(this L_Stack lstack, IntPtr item)
        {
            throw new NotImplementedException();
        }

        public static IntPtr lstackRemove(this L_Stack lstack)
        {
            throw new NotImplementedException();
        }

        public static int lstackGetCount(this L_Stack lstack)
        {
            throw new NotImplementedException();
        }


        // Text description
        public static int lstackPrint(IntPtr fp, L_Stack lstack)
        {
            throw new NotImplementedException();
        }
    }
}
