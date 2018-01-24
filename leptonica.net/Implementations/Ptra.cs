using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Ptra
    {
        // Ptra creation and destruction
        public static L_Ptra ptraCreate(int n)
        {
            throw new NotImplementedException();
        }

        public static void ptraDestroy(this L_Ptra ppa, int freeflag, int warnflag)
        {
            throw new NotImplementedException();
        }


        // Add/insert/remove/replace generic ptr object
        public static int ptraAdd(this L_Ptra pa, IntPtr item)
        {
            throw new NotImplementedException();
        }

        public static int ptraInsert(this L_Ptra pa, int index, IntPtr item, int shiftflag)
        {
            throw new NotImplementedException();
        }

        public static IntPtr ptraRemove(this L_Ptra pa, int index, int flag)
        {
            throw new NotImplementedException();
        }

        public static IntPtr ptraRemoveLast(this L_Ptra pa)
        {
            throw new NotImplementedException();
        }

        public static IntPtr ptraReplace(this L_Ptra pa, int index, IntPtr item, int freeflag)
        {
            throw new NotImplementedException();
        }

        public static int ptraSwap(this L_Ptra pa, int index1, int index2)
        {
            throw new NotImplementedException();
        }

        public static int ptraCompactArray(this L_Ptra pa)
        {
            throw new NotImplementedException();
        }


        // Other array operations
        public static int ptraReverse(this L_Ptra pa)
        {
            throw new NotImplementedException();
        }

        public static int ptraJoin(this L_Ptra pa1, L_Ptra pa2)
        {
            throw new NotImplementedException();
        }


        // Simple Ptra accessors
        public static int ptraGetMaxIndex(this L_Ptra pa, out int pmaxindex)
        {
            throw new NotImplementedException();
        }

        public static int ptraGetActualCount(this L_Ptra pa, out int pcount)
        {
            throw new NotImplementedException();
        }

        public static IntPtr ptraGetPtrToItem(this L_Ptra pa, int index)
        {
            throw new NotImplementedException();
        }


        // Ptraa creation and destruction
        public static L_Ptraa ptraaCreate(int n)
        {
            throw new NotImplementedException();
        }

        public static void ptraaDestroy(this L_Ptraa ppaa, int freeflag, int warnflag)
        {
            throw new NotImplementedException();
        }


        // Ptraa accessors
        public static int ptraaGetSize(this L_Ptraa paa, out int psize)
        {
            throw new NotImplementedException();
        }

        public static int ptraaInsertPtra(this L_Ptraa paa, int index, L_Ptra pa)
        {
            throw new NotImplementedException();
        }

        public static L_Ptra ptraaGetPtra(this L_Ptraa paa, int index, int accessflag)
        {
            throw new NotImplementedException();
        }


        // Ptraa conversion
        public static L_Ptra ptraaFlattenToPtra(this L_Ptraa paa)
        {
            throw new NotImplementedException();
        }
    }
}
