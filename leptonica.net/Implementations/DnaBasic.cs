using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class DnaBasic
    {
        // Dna creation, destruction, copy, clone, etc.
        public static L_Dna l_dnaCreate(int n)
        {
            var pointer = Native.DllImports.l_dnaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaCreateFromIArray(IntPtr iarray, int size)
        {
            if (IntPtr.Zero == iarray)
            {
                throw new ArgumentNullException("iarray cannot be null");
            }

            var pointer = Native.DllImports.l_dnaCreateFromIArray(iarray, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaCreateFromDArray(IntPtr darray, int size, int copyflag)
        {
            if (IntPtr.Zero == darray)
            {
                throw new ArgumentNullException("darray cannot be null");
            }

            var pointer = Native.DllImports.l_dnaCreateFromDArray(darray, size, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaMakeSequence(double startval, double increment, int size)
        {
            var pointer = Native.DllImports.l_dnaMakeSequence(startval, increment, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static void l_dnaDestroy(this L_Dna pda)
        {
            if (null == pda)
            {
                throw new ArgumentNullException("pda cannot be null");
            }

            var pointer = (IntPtr)pda;

            Native.DllImports.l_dnaDestroy(ref pointer);
        }

        public static L_Dna l_dnaCopy(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_dnaCopy((HandleRef)da);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaClone(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_dnaClone((HandleRef)da);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static int l_dnaEmpty(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaEmpty((HandleRef)da);
        }

        // Dna: add/remove number and extend array
        public static int l_dnaAddNumber(this L_Dna da, double val)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaAddNumber((HandleRef)da, val);
        }

        public static int l_dnaInsertNumber(this L_Dna da, int index, double val)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaInsertNumber((HandleRef)da, index, val);
        }

        public static int l_dnaRemoveNumber(this L_Dna da, int index)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaRemoveNumber((HandleRef)da, index);
        }

        public static int l_dnaReplaceNumber(this L_Dna da, int index, double val)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaReplaceNumber((HandleRef)da, index, val);
        }

        // Dna accessors 
        public static int l_dnaGetCount(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetCount((HandleRef)da);
        }

        public static int l_dnaSetCount(this L_Dna da, int newcount)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaSetCount((HandleRef)da, newcount);
        }

        public static int l_dnaGetDValue(this L_Dna da, int index, out double pval)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetDValue((HandleRef)da, index, out pval);
        }

        public static int l_dnaGetIValue(this L_Dna da, int index, out int pival)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetIValue((HandleRef)da, index, out pival);
        }

        public static int l_dnaSetValue(this L_Dna da, int index, double val)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaSetValue((HandleRef)da, index, val);
        }

        public static int l_dnaShiftValue(this L_Dna da, int index, double diff)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaShiftValue((HandleRef)da, index, diff);
        }

        public static IntPtr l_dnaGetIArray(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetIArray((HandleRef)da);
        }

        public static IntPtr l_dnaGetDArray(this L_Dna da, int copyflag)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetDArray((HandleRef)da, copyflag);
        }

        public static int l_dnaGetRefcount(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetRefcount((HandleRef)da);
        }

        public static int l_dnaChangeRefcount(this L_Dna da, int delta)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaChangeRefcount((HandleRef)da, delta);
        }

        public static int l_dnaGetParameters(this L_Dna da, out double pstartx, out double pdelx)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaGetParameters((HandleRef)da, out pstartx, out pdelx);
        }

        public static int l_dnaSetParameters(this L_Dna da, double startx, double delx)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaSetParameters((HandleRef)da, startx, delx);
        }

        public static int l_dnaCopyParameters(this L_Dna dad, L_Dna das)
        {
            if (null == dad
             || null == das)
            {
                throw new ArgumentNullException("dad, das cannot be null");
            }

            return Native.DllImports.l_dnaCopyParameters((HandleRef)dad, (HandleRef)das);
        }

        // Serialize Dna for I/O
        public static L_Dna l_dnaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.l_dnaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.l_dnaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static int l_dnaWrite(string filename, L_Dna da)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaWrite(filename, (HandleRef)da);
        }

        public static int l_dnaWriteStream(IntPtr fp, L_Dna da)
        {
            if (IntPtr.Zero == fp
             || null == da)
            {
                throw new ArgumentNullException("fp, da cannot be null");
            }

            return Native.DllImports.l_dnaWriteStream(fp, (HandleRef)da);
        }

        // Dnaa creation, destruction
        public static L_Dnaa l_dnaaCreate(int n)
        {
            var pointer = Native.DllImports.l_dnaaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dnaa(pointer);
            }
        }

        public static L_Dnaa l_dnaaCreateFull(int nptr, int n)
        {
            var pointer = Native.DllImports.l_dnaaCreateFull(nptr, n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dnaa(pointer);
            }
        }

        public static int l_dnaaTruncate(this L_Dnaa daa)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            return Native.DllImports.l_dnaaTruncate((HandleRef)daa);
        }

        public static void l_dnaaDestroy(this L_Dnaa pdaa)
        {
            if (null == pdaa)
            {
                throw new ArgumentNullException("pdaa cannot be null");
            }

            var pointer = (IntPtr)pdaa;

            Native.DllImports.l_dnaaDestroy(ref pointer);
        }

        // Add Dna to Dnaa
        public static int l_dnaaAddDna(this L_Dnaa daa, L_Dna da, int copyflag)
        {
            if (null == daa
             || null == da)
            {
                throw new ArgumentNullException("daa, da cannot be null");
            }

            return Native.DllImports.l_dnaaAddDna((HandleRef)daa, (HandleRef)da, copyflag);
        }

        // Dnaa accessors
        public static int l_dnaaGetCount(this L_Dnaa daa)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaGetCount((HandleRef)daa);
        }

        public static int l_dnaaGetDnaCount(this L_Dnaa daa, int index)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaGetDnaCount((HandleRef)daa, index);
        }

        public static int l_dnaaGetNumberCount(this L_Dnaa daa)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaGetNumberCount((HandleRef)daa);
        }

        public static L_Dna l_dnaaGetDna(this L_Dnaa daa, int index, int accessflag)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            var pointer = Native.DllImports.l_dnaaGetDna((HandleRef)daa, index, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static int l_dnaaReplaceDna(this L_Dnaa daa, int index, L_Dna da)
        {
            if (null == daa
             || null == da)
            {
                throw new ArgumentNullException("daa, da cannot be null");
            }

            return Native.DllImports.l_dnaaReplaceDna((HandleRef)daa, index, (HandleRef)da);
        }

        public static int l_dnaaGetValue(this L_Dnaa daa, int i, int j, out double pval)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaGetValue((HandleRef)daa, i, j, out pval);
        }

        public static int l_dnaaAddNumber(this L_Dnaa daa, int index, double val)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaAddNumber((HandleRef)daa, index, val);
        }

        // Serialize Dnaa for I/O
        public static L_Dnaa l_dnaaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.l_dnaaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dnaa(pointer);
            }
        }

        public static L_Dnaa l_dnaaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.l_dnaaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dnaa(pointer);
            }
        }

        public static int l_dnaaWrite(string filename, L_Dnaa daa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == daa)
            {
                throw new ArgumentNullException("daa cannot be null");
            }

            return Native.DllImports.l_dnaaWrite(filename, (HandleRef)daa);
        }

        public static int l_dnaaWriteStream(IntPtr fp, L_Dnaa daa)
        {
            if (IntPtr.Zero == fp
             || null == daa)
            {
                throw new ArgumentNullException("fp, daa cannot be null");
            }

            return Native.DllImports.l_dnaaWriteStream(fp, (HandleRef)daa);
        }
    }
}
