using System;
using System.Runtime.InteropServices;

namespace Leptonica.Implementations
{
    public static class DnaFunc1
    {
        // Rearrangements
        public static int l_dnaJoin(this L_Dna dad, L_Dna das, int istart, int iend)
        {
            if (null == dad
             || null == das)
            {
                throw new ArgumentNullException("dad, das cannot be null");
            }

            return Native.DllImports.l_dnaJoin((HandleRef)dad, (HandleRef)das, istart, iend);
        }

        public static L_Dna l_dnaaFlattenToDna(L_Dnaa daa)
        {
            if (null == daa)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_dnaaFlattenToDna((HandleRef)daa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        // Conversion between numa and dna
        public static Numa l_dnaConvertToNuma(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_dnaConvertToNuma((HandleRef)da);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static L_Dna numaConvertToDna(this Numa na)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            var pointer = Native.DllImports.numaConvertToDna((HandleRef)na);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        // Set operations using aset (rbtree)
        public static L_Dna l_dnaUnionByAset(this L_Dna da1, L_Dna da2)
        {
            if (null == da1
             || null == da2)
            {
                throw new ArgumentNullException("da1, da2 cannot be null");
            }

            var pointer = Native.DllImports.l_dnaUnionByAset((HandleRef)da1, (HandleRef)da2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaRemoveDupsByAset(this L_Dna das)
        {
            if (null == das)
            {
                throw new ArgumentNullException("das cannot be null");
            }

            var pointer = Native.DllImports.l_dnaRemoveDupsByAset((HandleRef)das);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_Dna l_dnaIntersectionByAset(this L_Dna da1, L_Dna da2)
        {
            if (null == da1
             || null == da2)
            {
                throw new ArgumentNullException("da1, da2 cannot be null");
            }

            var pointer = Native.DllImports.l_dnaIntersectionByAset((HandleRef)da1, (HandleRef)da2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }

        public static L_ASet l_asetCreateFromDna(this L_Dna da)
        {
            if (null == da)
            {
                throw new ArgumentNullException("da cannot be null");
            }

            var pointer = Native.DllImports.l_asetCreateFromDna((HandleRef)da);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet(pointer);
            }
        }
         
        // Miscellaneous operations
        public static L_Dna l_dnaDiffAdjValues(this L_Dna das)
        {
            if (null == das)
            {
                throw new ArgumentNullException("das cannot be null");
            }

            var pointer = Native.DllImports.l_dnaDiffAdjValues((HandleRef)das);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dna(pointer);
            }
        }
    }
}
