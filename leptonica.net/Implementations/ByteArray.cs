using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leptonica
{
    public static class ByteArray
    {
        // Creation, copy, clone, destruction
        public static L_Bytea l_byteaCreate(int nbytes)
        {
            //if (IntPtr.Zero == nbytes)
            //{
            //    throw new ArgumentNullException("nbytes cannot be null.");
            //}

            var pointer = Native.DllImports.l_byteaCreate(nbytes);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bytea(pointer);
            }
        }

        public static L_Bytea l_byteaInitFromMem(byte[] data, int size)
        {
            //if (IntPtr.Zero == data)//|| IntPtr.Zero == size)
            //{
            //    throw new ArgumentNullException("data, size cannot be null.");
            //}

            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data cannot be null.");

            var pointer = Native.DllImports.l_byteaInitFromMem(data, size);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bytea(pointer);
            }
        }

        public static L_Bytea l_byteaInitFromFile(string fname)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist");
            }

            var pointer = Native.DllImports.l_byteaInitFromFile(fname);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bytea(pointer);
            }
        }

        public static L_Bytea l_byteaInitFromStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.l_byteaInitFromStream(fp);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bytea(pointer);
            }
        }

        public static L_Bytea l_byteaCopy(this L_Bytea bas, int copyflag)
        {
            if (null == bas)
            {
                throw new ArgumentNullException("bas cannot be null.");
            }

            var pointer = Native.DllImports.l_byteaCopy((HandleRef)bas, copyflag);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bytea(pointer);
            }
        }

        public static void l_byteaDestroy(this L_Bytea pba)
        {
            if (null == pba)
            {
                throw new ArgumentNullException("pba cannot be null");
            }

            var pointer = (IntPtr)pba;

            Native.DllImports.l_byteaDestroy(ref pointer);
        }

        // Accessors
        public static int l_byteaGetSize(this L_Bytea ba)
        {
            if (null == ba)
            {
                throw new ArgumentNullException("ba cannot be null");
            }

            return Native.DllImports.l_byteaGetSize((HandleRef)ba);
        }

        public static IntPtr l_byteaGetData(this L_Bytea ba, ref int psize)
        {
            if (null == ba)// || IntPtr.Zero == psize)
            {
                throw new ArgumentNullException("ba, psize cannot be null");
            }

            return Native.DllImports.l_byteaGetData((HandleRef)ba, ref psize);
        }

        public static IntPtr l_byteaCopyData(this L_Bytea ba, IntPtr psize)
        {
            if (null == ba
             || IntPtr.Zero == psize)
            {
                throw new ArgumentNullException("ba, psize cannot be null");
            }

            return Native.DllImports.l_byteaCopyData((HandleRef)ba, psize);
        }

        // Appending
        public static int l_byteaAppendData(this L_Bytea ba, IntPtr newdata, IntPtr newbytes)
        {
            if (null == ba
             || IntPtr.Zero == newdata
             || IntPtr.Zero == newbytes)
            {
                throw new ArgumentNullException("ba, newbytes, newdata cannot be null");
            }

            return Native.DllImports.l_byteaAppendData((HandleRef)ba, newdata, newbytes);
        }

        public static int l_byteaAppendString(this L_Bytea ba, string str)
        {
            if (null == ba)
            {
                throw new ArgumentNullException("ba cannot be null");
            }

            var ret = Native.DllImports.l_byteaAppendString((HandleRef)ba, str);
            return ret;
        }

        // Join/Split
        public static int l_byteaJoin(L_Bytea ba1, ref L_Bytea pba2)
        {
            if (null == ba1)
                throw new ArgumentNullException("ba1 cannot be null");

            IntPtr pba2Ptr = pba2.Pointer;
            IntPtr ba1Ptr = ba1.Pointer;
            var ret = Native.DllImports.l_byteaJoin(ba1Ptr, ref pba2Ptr);
            return ret;
        }

        public static int l_byteaSplit(this L_Bytea ba1, int splitloc, out L_Bytea pba2)
        {
            if (null == ba1
             || 0 == splitloc)
            {
                throw new ArgumentNullException("ba1, splitloc cannot be null");
            }

            IntPtr pba2Ptr;
            var result = Native.DllImports.l_byteaSplit((HandleRef)ba1, splitloc, out pba2Ptr);
            pba2 = new L_Bytea(pba2Ptr);
            return result;
        }

        // Search
        public static int l_byteaFindEachSequence(this L_Bytea ba, IntPtr sequence, int seqlen, out L_Dna pda)
        {
            if (null == ba
             || IntPtr.Zero == sequence)
            {
                throw new ArgumentNullException("ba1, sequence cannot be null");
            }

            IntPtr pdaPtr;
            var result = Native.DllImports.l_byteaFindEachSequence((HandleRef)ba, sequence, seqlen, out pdaPtr);
            pda = new L_Dna(pdaPtr);
            return result;
        }

        // Output to file
        public static int l_byteaWrite(string fname, L_Bytea ba, IntPtr startloc, IntPtr endloc)
        {
            if (null == ba
             || IntPtr.Zero == startloc
             || IntPtr.Zero == endloc
             || string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("ba, startloc, endloc, fname cannot be null");
            }

            return Native.DllImports.l_byteaWrite(fname, (HandleRef)ba, startloc, endloc);
        }

        public static int l_byteaWriteStream(IntPtr fp, L_Bytea ba, IntPtr startloc, IntPtr endloc)
        {
            if (IntPtr.Zero == fp
             || null == ba
             || IntPtr.Zero == startloc
             || IntPtr.Zero == endloc)
            {
                throw new ArgumentNullException("fp, ba, startloc, endloc cannot be null");
            }

            return Native.DllImports.l_byteaWriteStream(fp, (HandleRef)ba, startloc, endloc);
        }
    }
}
