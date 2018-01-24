using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PtaFunc2
    {
        // Sorting
        public static Pta ptaSort(this Pta ptas, int sorttype, int sortorder, out Numa pnaindex)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetSortIndex(this Pta ptas, int sorttype, int sortorder, out Numa pnaindex)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaSortByIndex(this Pta ptas, Numa naindex)
        {
            throw new NotImplementedException();
        }

        public static Ptaa ptaaSortByIndex(this Ptaa ptaas, Numa naindex)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetRankValue(this Pta pta, float fract, Pta ptasort, int sorttype, out float pval)
        {
            throw new NotImplementedException();
        }


        // Set operations using aset (rbtree)
        public static Pta ptaUnionByAset(this Pta pta1, Pta pta2)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaRemoveDupsByAset(this Pta ptas)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaIntersectionByAset(this Pta pta1, Pta pta2)
        {
            throw new NotImplementedException();
        }

        public static L_ASet l_asetCreateFromPta(this Pta pta)
        {
            throw new NotImplementedException();
        }


        // Set operations using hashing (dnahash)
        public static Pta ptaUnionByHash(this Pta pta1, Pta pta2)
        {
            throw new NotImplementedException();
        }

        public static int ptaRemoveDupsByHash(this Pta ptas, out Pta pptad, out L_DnaHash pdahash)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaIntersectionByHash(this Pta pta1, Pta pta2)
        {
            throw new NotImplementedException();
        }

        public static int ptaFindPtByHash(this Pta pta, L_DnaHash dahash, int x, int y, out int pindex)
        {
            throw new NotImplementedException();
        }

        public static L_DnaHash l_dnaHashCreateFromPta(this Pta pta)
        {
            throw new NotImplementedException();
        } 
    }
}
