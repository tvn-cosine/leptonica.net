using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Heap
    {
        // Create/Destroy L_Heap
        public static L_Heap lheapCreate(int nalloc, int direction)
        {
            var pointer = Native.DllImports.lheapCreate(nalloc, direction);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Heap(pointer);
            }
        }

        public static void lheapDestroy(this L_Heap plh, int freeflag)
        {
            if (null == plh)
            {
                throw new ArgumentNullException("plh cannot be null");
            }

            var pointer = (IntPtr)plh;

            Native.DllImports.lheapDestroy(ref pointer, freeflag);
        }

        // Operations to add/remove to/from the heap
        public static int lheapAdd(this L_Heap lh, IntPtr item)
        {
            if (null == lh
             || IntPtr.Zero == item)
            {
                throw new ArgumentNullException("lh, item cannot be null");
            }

            return Native.DllImports.lheapAdd((HandleRef)lh, item); 
        }

        public static IntPtr lheapRemove(this L_Heap lh)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }

            return Native.DllImports.lheapRemove((HandleRef)lh);
        }
         
        // Heap operations
        public static int lheapSwapUp(this L_Heap lh, int index)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }
             
           return Native.DllImports.lheapSwapUp((HandleRef)lh, index);
        }

        public static int lheapSwapDown(this L_Heap lh)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }

            return Native.DllImports.lheapSwapDown((HandleRef)lh);
        }

        public static int lheapSort(this L_Heap lh)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }

            return Native.DllImports.lheapSort((HandleRef)lh);
        }

        public static int lheapSortStrictOrder(this L_Heap lh)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }

            return Native.DllImports.lheapSortStrictOrder((HandleRef)lh);
        }
         
        // Accessors
        public static int lheapGetCount(this L_Heap lh)
        {
            if (null == lh)
            {
                throw new ArgumentNullException("lh cannot be null");
            }

            return Native.DllImports.lheapGetCount((HandleRef)lh);
        }
         
        // Debug output
        public static int lheapPrint(IntPtr fp, L_Heap lh)
        {
            if (null == lh
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("lh, fp cannot be null");
            }

            return Native.DllImports.lheapPrint(fp, (HandleRef)lh);
        }
    }
}
