using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Sarray2
    {
        // Sort
        public static Sarray sarraySort(this Sarray saout, Sarray sain, int sortorder)
        {
            throw new NotImplementedException();
        }

        public static Sarray sarraySortByIndex(this Sarray sain, Numa naindex)
        {
            throw new NotImplementedException();
        }

        public static int stringCompareLexical(string str1, string str2)
        {
            throw new NotImplementedException();
        }


        // Set operations using aset (rbtree)
        public static Sarray sarrayUnionByAset(this Sarray sa1, Sarray sa2)
        {
            throw new NotImplementedException();
        }

        public static Sarray sarrayRemoveDupsByAset(this Sarray sas)
        {
            throw new NotImplementedException();
        }

        public static Sarray sarrayIntersectionByAset(this Sarray sa1, Sarray sa2)
        {
            throw new NotImplementedException();
        }

        public static L_ASet l_asetCreateFromSarray(this Sarray sa)
        {
            throw new NotImplementedException();
        }


        // Set operations using hashing (dnahash)
        public static int sarrayRemoveDupsByHash(this Sarray sas, out Sarray psad, out L_DnaHash pdahash)
        {
            throw new NotImplementedException();
        }

        public static Sarray sarrayIntersectionByHash(this Sarray sa1, Sarray sa2)
        {
            throw new NotImplementedException();
        }

        public static int sarrayFindStringByHash(this Sarray sa, L_DnaHash dahash, string str, out int pindex)
        {
            throw new NotImplementedException();
        }

        public static L_DnaHash l_dnaHashCreateFromSarray(this Sarray sa)
        {
            throw new NotImplementedException();
        }


        // Miscellaneous operations
        public static Sarray sarrayGenerateIntegers(int n)
        {
            throw new NotImplementedException();
        } 
    }
}
