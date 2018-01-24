using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RecogBasic
    {

        // Recog creation, destruction and access
        public static L_Recog recogCreateFromRecog(this L_Recog recs, int scalew, int scaleh, int linew, int threshold, int maxyshift)
        {
            throw new NotImplementedException();
        }

        public static L_Recog recogCreateFromPixa(this Pixa pixa, int scalew, int scaleh, int linew, int threshold, int maxyshift)
        {
            throw new NotImplementedException();
        }

        public static L_Recog recogCreateFromPixaNoFinish(this Pixa pixa, int scalew, int scaleh, int linew, int threshold, int maxyshift)
        {
            throw new NotImplementedException();
        }

        public static L_Recog recogCreate(int scalew, int scaleh, int linew, int threshold, int maxyshift)
        {
            throw new NotImplementedException();
        }

        public static void recogDestroy(this L_Recog precog)
        {
            throw new NotImplementedException();
        }

        public static int recogGetCount(this L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static int recogSetParams(this L_Recog recog, int type, int min_nopad, float max_wh_ratio, float max_ht_ratio)
        {
            throw new NotImplementedException();
        }


        // Character/index lookup
        public static int recogGetClassIndex(this L_Recog recog, int val, string text, out int pindex)
        {
            throw new NotImplementedException();
        }

        public static int recogStringToIndex(this L_Recog recog, string text, out int pindex)
        {
            throw new NotImplementedException();
        }

        public static int recogGetClassString(this L_Recog recog, int index, out IntPtr pcharstr)
        {
            throw new NotImplementedException();
        }

        public static int l_convertCharstrToInt(string str, out int pval)
        {
            throw new NotImplementedException();
        }


        // Serialization
        public static L_Recog recogRead(string filename)
        {
            throw new NotImplementedException();
        }

        public static L_Recog recogReadStream(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static L_Recog recogReadMem(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static int recogWrite(string filename, L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static int recogWriteStream(IntPtr fp, L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static int recogWriteMem(out IntPtr pdata, IntPtr psize, L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static Pixa recogExtractPixa(this L_Recog recog)
        {
            throw new NotImplementedException();
        }
    }
}
