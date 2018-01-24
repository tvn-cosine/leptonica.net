using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class DnaHash
    {
        // DnaHash creation, destruction
        public static L_DnaHash l_dnaHashCreate(int nbuckets, int initsize)
        {
            var pointer = Native.DllImports.l_dnaHashCreate(nbuckets, initsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_DnaHash(pointer);
            }
        }

        public static void l_dnaHashDestroy(this L_DnaHash pdahash)
        {
            if (null == pdahash)
            {
                throw new ArgumentNullException("pdahash cannot be null");
            }

            var pointer = (IntPtr)pdahash;

            Native.DllImports.l_dnaHashDestroy(ref pointer);
        }

        // DnaHash: Accessors and modifiers*
        public static int l_dnaHashGetCount(this L_DnaHash dahash)
        {
            if (null == dahash)
            {
                throw new ArgumentNullException("dahash cannot be null");
            }

            return Native.DllImports.l_dnaHashGetCount((HandleRef)dahash);
        }

        public static int l_dnaHashGetTotalCount(this L_DnaHash dahash)
        {
            if (null == dahash)
            {
                throw new ArgumentNullException("dahash cannot be null");
            }

            return Native.DllImports.l_dnaHashGetTotalCount((HandleRef)dahash);
        }

        public static L_Dna l_dnaHashGetDna(this L_DnaHash dahash, long key, int copyflag)
        {
            if (null == dahash)
            {
                throw new ArgumentNullException("dahash cannot be null");
            }

            var pointer = Native.DllImports.l_dnaHashGetDna((HandleRef)dahash, key, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static int l_dnaHashAdd(this L_DnaHash dahash, long key, double value)
        {
            if (null == dahash)
            {
                throw new ArgumentNullException("dahash cannot be null");
            }

            return Native.DllImports.l_dnaHashAdd((HandleRef)dahash, key, value);
        }

        // DnaHash: Operations on Dna
        public static L_DnaHash l_dnaHashCreateFromDna(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_dnaHashCreateFromDna((HandleRef)da);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_DnaHash(pointer);
            }
        }

        public static int l_dnaRemoveDupsByHash(this L_Dna das, out L_Dna pdad, out L_DnaHash pdahash)
        {
            if (null == das)
            {
                throw new ArgumentNullException("das cannot be null");
            }

            IntPtr pdadPtr, pdahashPtr;
            var result = Native.DllImports.l_dnaRemoveDupsByHash((HandleRef)das, out pdadPtr, out pdahashPtr);
            pdad = new L_Dna(pdadPtr);
            pdahash = new L_DnaHash(pdahashPtr);

            return result;
        }

        public static int l_dnaMakeHistoByHash(this L_Dna das, out L_DnaHash pdahash, out L_Dna pdav, out L_Dna pdac)
        {
            if (null == das)
            {
                throw new ArgumentNullException("das cannot be null");
            }

            IntPtr pdahashPtr, pdavPtr, pdacPtr;
            var result = Native.DllImports.l_dnaMakeHistoByHash((HandleRef)das, out pdahashPtr, out pdavPtr, out pdacPtr);
            pdahash = new L_DnaHash(pdahashPtr);
            pdav = new L_Dna(pdavPtr);
            pdac = new L_Dna(pdacPtr);

            return result;
        }
        public static L_Dna l_dnaIntersectionByHash(this L_Dna da1, L_Dna da2)
        {
            if (null == da1
             || null == da2)
            {
                throw new ArgumentNullException("da1, da2 cannot be null");
            }

            var pointer = Native.DllImports.l_dnaIntersectionByHash((HandleRef)da1, (HandleRef)da2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static int l_dnaFindValByHash(this L_Dna da, L_DnaHash dahash, double val, out int pindex)
        {
            if (null == da
             || null == dahash)
            {
                throw new ArgumentNullException("da, dahash cannot be null");
            }

            return Native.DllImports.l_dnaFindValByHash((HandleRef)da, (HandleRef)dahash, val, out pindex);
        }
    }
}
