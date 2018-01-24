using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Queue
    {
        // Create/Destroy L_Queue
        public static  L_Queue lqueueCreate(int nalloc)
        {
            throw new NotImplementedException();
        }

        public static  void lqueueDestroy(this L_Queue plq, int freeflag)
        {
            throw new NotImplementedException();
        }


        // Operations to add/remove to/from a L_Queue
        public static  int lqueueAdd(this L_Queue lq, IntPtr item)
        {
            throw new NotImplementedException();
        }

        public static  IntPtr lqueueRemove(this L_Queue lq)
        {
            throw new NotImplementedException();
        }


        // Accessors
        public static  int lqueueGetCount(this L_Queue lq)
        {
            throw new NotImplementedException();
        }


        // Debug output
        public static  int lqueuePrint(IntPtr fp, L_Queue lq)
        {
            throw new NotImplementedException();
        } 
    }
}
