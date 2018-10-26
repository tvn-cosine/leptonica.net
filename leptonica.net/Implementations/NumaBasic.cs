using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class NumaBasic
    {
        // Numa creation, destruction, copy, clone, etc.
        public static Numa numaCreate(int n)
        {
            var pointer = Native.DllImports.numaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaCreateFromIArray(IntPtr iarray, int size)
        {
            if (null == iarray)
            {
                throw new ArgumentNullException("iarray cannot be null.");
            }

            var pointer = Native.DllImports.numaCreateFromIArray(iarray, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaCreateFromFArray(IntPtr farray, int size, int copyflag)
        {
            if (null == farray)
            {
                throw new ArgumentNullException("iarray cannot be null.");
            }

            var pointer = Native.DllImports.numaCreateFromFArray(farray, size, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaCreateFromString(string str)
        {
            var pointer = Native.DllImports.numaCreateFromString(str);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static void numaDestroy(this Numa pna)
        {
            if (null == pna)
            {
                throw new ArgumentNullException("pna cannot be null");
            }

            var pointer = (IntPtr)pna;

            Native.DllImports.boxDestroy(ref pointer);
        }

        public static Numa numaCopy(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaCopy((HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaClone(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaClone((HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaEmpty(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaEmpty((HandleRef)na);
        }

        // Add/remove number(float or integer)
        public static int numaAddNumber(this Numa na, float val)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaAddNumber((HandleRef)na, val);
        }

        public static int numaInsertNumber(this Numa na, int index, float val)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaInsertNumber((HandleRef)na, index, val);
        }

        public static int numaRemoveNumber(this Numa na, int index)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaRemoveNumber((HandleRef)na, index);
        }

        public static int numaReplaceNumber(this Numa na, int index, float val)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaReplaceNumber((HandleRef)na, index, val);
        }

        // Numa accessors
        public static int numaGetCount(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetCount((HandleRef)na);
        }

        public static int numaSetCount(this Numa na, int newcount)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaSetCount((HandleRef)na, newcount);
        }

        public static int numaGetFValue(this Numa na, int index, out float pval)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetFValue((HandleRef)na, index, out pval);
        }

        public static int numaGetIValue(this Numa na, int index, out int pival)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetIValue((HandleRef)na, index, out pival);
        }

        public static int numaSetValue(this Numa na, int index, float val)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaSetValue((HandleRef)na, index, val);
        }

        public static int numaShiftValue(this Numa na, int index, float diff)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaShiftValue((HandleRef)na, index, diff);
        }

        public static IntPtr numaGetIArray(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetIArray((HandleRef)na);
        }

        public static IntPtr numaGetFArray(this Numa na, int copyflag)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetFArray((HandleRef)na, copyflag);
        }

        public static int numaGetRefcount(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetRefcount((HandleRef)na);
        }

        public static int numaChangeRefcount(this Numa na, int delta)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaChangeRefcount((HandleRef)na, delta);
        }

        public static int numaGetParameters(this Numa na, out float pstartx, out float pdelx)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaGetParameters((HandleRef)na, out pstartx, out pdelx);
        }

        public static int numaSetParameters(this Numa na, float startx, float delx)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            return Native.DllImports.numaSetParameters((HandleRef)na, startx, delx);
        }

        public static int numaCopyParameters(this Numa nad, Numa nas)
        {
            if (null == nad
             || null == nas)
            {
                throw new ArgumentNullException("nad, nas cannot be null.");
            }

            return Native.DllImports.numaCopyParameters((HandleRef)nad, (HandleRef)nas);
        }

        // Convert to string array
        public static Sarray numaConvertToSarray(this Numa na, int size1, int size2, int addzeros, int type)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null.");
            }

            var pointer = Native.DllImports.numaConvertToSarray((HandleRef)na, size1, size2, addzeros, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Sarray(pointer);
            }
        }

        // Serialize numa for I/O
        public static Numa numaRead(string filename)

        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.numaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.numaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static Numa numaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.numaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaWrite(string filename, Numa na)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            return Native.DllImports.numaWrite(filename, (HandleRef)na);
        }

        public static int numaWriteStream(IntPtr fp, Numa na)
        {
            if (IntPtr.Zero == fp
             || null == na)
            {
                throw new ArgumentNullException("fp, na cannot be null");
            }

            return Native.DllImports.numaWriteStream(fp, (HandleRef)na);
        }

        public static int numaWriteMem(out IntPtr pdata, IntPtr psize, Numa na)
        {
            if (IntPtr.Zero == psize
             || null == na)
            {
                throw new ArgumentNullException("pdata, psize, na cannot be null");
            }

            return Native.DllImports.numaWriteMem(out pdata, psize, (HandleRef)na);
        }

        // Numaa creation, destruction, truncation
        public static Numaa numaaCreate(int n)
        {
            var pointer = Native.DllImports.numaaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static Numaa numaaCreateFull(int nptr, int n)
        {
            var pointer = Native.DllImports.numaaCreateFull(nptr, n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static int numaaTruncate(this Numaa naa)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null.");
            }

            return Native.DllImports.numaaTruncate((HandleRef)naa);
        }

        public static void numaaDestroy(this Numaa pnaa)
        {
            if (null == pnaa)
            {
                throw new ArgumentNullException("pnaa cannot be null");
            }

            var pointer = (IntPtr)pnaa;

            Native.DllImports.boxDestroy(ref pointer);
        }

        // Add Numa to Numaa
        public static int numaaAddNuma(this Numaa naa, Numa na, AccessAndStorageFlags copyflag)
        {
            if (null == naa
             || null == na)
            {
                throw new ArgumentNullException("naa, na cannot be null");
            }

            return Native.DllImports.numaaAddNuma((HandleRef)naa, (HandleRef)na, (int)copyflag);
        }

        // Numaa accessors
        public static int numaaGetCount(this Numaa naa)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaGetCount((HandleRef)naa);
        }

        public static int numaaGetNumaCount(this Numaa naa, int index)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaGetNumaCount((HandleRef)naa, index);
        }

        public static int numaaGetNumberCount(this Numaa naa)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaGetNumberCount((HandleRef)naa);
        }

        public static IntPtr numaaGetPtrArray(this Numaa naa)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaGetPtrArray((HandleRef)naa);
        }

        public static Numa numaaGetNuma(this Numaa naa, int index, int accessflag)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            var pointer = Native.DllImports.numaaGetNuma((HandleRef)naa, index, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int numaaReplaceNuma(this Numaa naa, int index, Numa na)
        {
            if (null == naa
             || null == na)
            {
                throw new ArgumentNullException("naa, na cannot be null");
            }

            return Native.DllImports.numaaReplaceNuma((HandleRef)naa, index, (HandleRef)na);
        }

        public static int numaaGetValue(this Numaa naa, int i, int j, out float pfval, out int pival)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaGetValue((HandleRef)naa, i, j, out pfval, out pival);
        }

        public static int numaaAddNumber(this Numaa naa, int index, float val)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaAddNumber((HandleRef)naa, index, val);
        }

        // Serialize numaa for I/O
        public static Numaa numaaRead(string filename)

        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.numaaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static Numaa numaaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.numaaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static Numaa numaaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.numaaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numaa(pointer);
            }
        }

        public static int numaaWrite(string filename, Numaa naa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.numaaWrite(filename, (HandleRef)naa);
        }

        public static int numaaWriteStream(IntPtr fp, Numaa naa)
        {
            if (IntPtr.Zero == fp
             || null == naa)
            {
                throw new ArgumentNullException("fp, naa cannot be null");
            }

            return Native.DllImports.numaaWriteStream(fp, (HandleRef)naa);
        }

        public static int numaaWriteMem(out IntPtr pdata, IntPtr psize, Numaa naa)
        {
            if (IntPtr.Zero == psize
             || null == naa)
            {
                throw new ArgumentNullException("pdata, psize, naa cannot be null");
            }

            return Native.DllImports.numaaWriteMem(out pdata, psize, (HandleRef)naa);
        }
    }
}
