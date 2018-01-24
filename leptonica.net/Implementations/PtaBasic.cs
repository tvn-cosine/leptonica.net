using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PtaBasic
    {
        // Pta creation, destruction, copy, clone, empty
        public static Pta ptaCreate(int n)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaCreateFromNuma(this Numa nax, Numa nay)
        {
            throw new NotImplementedException();
        }

        public static void ptaDestroy(this Pta ppta)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaCopy(this Pta pta)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaCopyRange(this Pta ptas, int istart, int iend)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaClone(this Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaEmpty(this Pta pta)
        {
            throw new NotImplementedException();
        }


        // Pta array extension
        public static int ptaAddPt(this Pta pta, float x, float y)
        {
            throw new NotImplementedException();
        }


        // Pta insertion and removal
        public static int ptaInsertPt(this Pta pta, int index, int x, int y)
        {
            throw new NotImplementedException();
        }

        public static int ptaRemovePt(this Pta pta, int index)
        {
            throw new NotImplementedException();
        }


        // Pta accessors
        public static int ptaGetRefcount(this Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaChangeRefcount(this Pta pta, int delta)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetCount(this Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetPt(this Pta pta, int index, out float px, out float py)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetIPt(this Pta pta, int index, out int px, out int py)
        {
            throw new NotImplementedException();
        }

        public static int ptaSetPt(this Pta pta, int index, float x, float y)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetArrays(this Pta pta, out Numa pnax, out Numa pnay)
        {
            throw new NotImplementedException();
        }


        // Pta serialized for I/O
        public static Pta ptaRead(string filename)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaReadMem(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int ptaWrite(string filename, Pta pta, int type)
        {
            throw new NotImplementedException();
        }

        public static int ptaWriteStream(IntPtr fp, Pta pta, int type)
        {
            throw new NotImplementedException();
        }

        public static int ptaWriteMem(out IntPtr pdata, IntPtr psize, Pta pta, int type)
        {
            throw new NotImplementedException();
        }


        // Ptaa creation, destruction
        public static Ptaa ptaaCreate(int n)
        {
            throw new NotImplementedException();
        }

        public static void ptaaDestroy(this Ptaa pptaa)
        {
            throw new NotImplementedException();
        }


        // Ptaa array extension
        public static int ptaaAddPta(this Ptaa ptaa, Pta pta, int copyflag)
        {
            throw new NotImplementedException();
        }


        // Ptaa accessors
        public static int ptaaGetCount(this Ptaa ptaa)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaaGetPta(this Ptaa ptaa, int index, int accessflag)
        {
            throw new NotImplementedException();
        }

        public static int ptaaGetPt(this Ptaa ptaa, int ipta, int jpt, out float px, out float py)
        {
            throw new NotImplementedException();
        }


        // Ptaa array modifiers
        public static int ptaaInitFull(this Ptaa ptaa, Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaaReplacePta(this Ptaa ptaa, int index, Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaaAddPt(this Ptaa ptaa, int ipta, float x, float y)
        {
            throw new NotImplementedException();
        }

        public static int ptaaTruncate(this Ptaa ptaa)
        {
            throw new NotImplementedException();
        }


        // Ptaa serialized for I/O
        public static Ptaa ptaaRead(string filename)
        {
            throw new NotImplementedException();
        }

        public static Ptaa ptaaReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static Ptaa ptaaReadMem(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int ptaaWrite(string filename, Ptaa ptaa, int type)
        {
            throw new NotImplementedException();
        }

        public static int ptaaWriteStream(IntPtr fp, Ptaa ptaa, int type)
        {
            throw new NotImplementedException();
        }

        public static int ptaaWriteMem(out IntPtr pdata, IntPtr psize, Ptaa ptaa, int type)
        {
            throw new NotImplementedException();
        }
    }
}
