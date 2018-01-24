using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixAlloc
    {
        public static int pmsCreate(IntPtr minsize, IntPtr smallest, Numa numalloc, string logfile)
        {
            throw new NotImplementedException();
        }

        public static void pmsDestroy()
        {
            throw new NotImplementedException();
        }

        public static IntPtr pmsCustomAlloc(IntPtr nbytes)
        {
            throw new NotImplementedException();
        }

        public static void pmsCustomDealloc(IntPtr data)
        {
            throw new NotImplementedException();
        }

        public static IntPtr pmsGetAlloc(IntPtr nbytes)
        {
            throw new NotImplementedException();
        }

        public static int pmsGetLevelForAlloc(IntPtr nbytes, IntPtr plevel)
        {
            throw new NotImplementedException();
        }

        public static int pmsGetLevelForDealloc(IntPtr data, IntPtr plevel)
        {
            throw new NotImplementedException();
        }

        public static void pmsLogInfo()
        {
            throw new NotImplementedException();
        } 
    }
}
