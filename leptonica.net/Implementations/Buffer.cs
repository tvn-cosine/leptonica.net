using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Buffer
    {
        // Create/Destroy BBuffer
        public static L_ByteBuffer bbufferCreate(IntPtr indata, int nalloc)
        {
            if (IntPtr.Zero == indata)
            {
                throw new ArgumentNullException("indata cannot be null.");
            }

            var pointer = Native.DllImports.bbufferCreate(indata, nalloc);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ByteBuffer(pointer);
            }
        }

        public static void bbufferDestroy(this L_ByteBuffer pbb)
        {
            if (null == pbb)
            {
                throw new ArgumentNullException("pbb cannot be null.");
            }

            var pointer = (IntPtr)pbb;
            Native.DllImports.bbufferDestroy(ref pointer);
        }

        public static IntPtr bbufferDestroyAndSaveData(this L_ByteBuffer pbb, IntPtr pnbytes)
        {
            if (null == pbb
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("pbb, pnbytes cannot be null.");
            }

            var pointer = (IntPtr)pbb;
            return Native.DllImports.bbufferDestroyAndSaveData(ref pointer, pnbytes);
        }

        // Operations to read data TO a BBuffer
        public static int bbufferRead(this L_ByteBuffer bb, IntPtr src, int nbytes)
        {
            if (null == bb
             || IntPtr.Zero == src)
            {
                throw new ArgumentNullException("bb, src cannot be null.");
            }

            return Native.DllImports.bbufferRead((HandleRef)bb, src, nbytes);
        }

        public static int bbufferReadStream(this L_ByteBuffer bb, IntPtr fp, int nbytes)
        {
            if (null == bb
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("bb, fp cannot be null.");
            }

            return Native.DllImports.bbufferReadStream((HandleRef)bb, fp, nbytes);
        }

        public static int bbufferExtendArray(this L_ByteBuffer bb, int nbytes)
        {
            if (null == bb)
            {
                throw new ArgumentNullException("bb cannot be null.");
            }

            return Native.DllImports.bbufferExtendArray((HandleRef)bb, nbytes);
        }

        // Operations to write data FROM a BBuffer
        public static int bbufferWrite(this L_ByteBuffer bb, IntPtr dest, IntPtr nbytes, IntPtr pnout)
        {
            if (null == bb
             || IntPtr.Zero == dest
             || IntPtr.Zero == nbytes
             || IntPtr.Zero == pnout)
            {
                throw new ArgumentNullException("bb, dest, nbytes, pnout cannot be null.");
            }

            return Native.DllImports.bbufferWrite((HandleRef)bb, dest, nbytes, pnout);
        }

        public static int bbufferWriteStream(this L_ByteBuffer bb, IntPtr fp, IntPtr nbytes, IntPtr pnout)
        {
            if (null == bb
             || IntPtr.Zero == fp
             || IntPtr.Zero == nbytes
             || IntPtr.Zero == pnout)
            {
                throw new ArgumentNullException("bb, fp, nbytes, pnout cannot be null.");
            }

            return Native.DllImports.bbufferWriteStream((HandleRef)bb, fp, nbytes, pnout);
        }
    }
}
