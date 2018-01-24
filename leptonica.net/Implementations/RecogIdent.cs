using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RecogIdent
    {
        // Top-level identification
        public static int recogIdentifyMultiple(this L_Recog recog, Pix pixs, int minh, int skipsplit, out Boxa pboxa, out Pixa ppixa, out Pix ppixdb, int debugsplit)
        {
            throw new NotImplementedException();
        }


        // Segmentation and noise removal
        public static int recogSplitIntoCharacters(this L_Recog recog, Pix pixs, int minh, int skipsplit, out Boxa pboxa, out Pixa ppixa, int debug)
        {
            throw new NotImplementedException();
        }


        // Greedy character splitting
        public static int recogCorrelationBestRow(this L_Recog recog, Pix pixs, out Boxa pboxa, out Numa pnascore, out Numa pnaindex, out Sarray psachar, int debug)
        {
            throw new NotImplementedException();
        }

        public static int recogCorrelationBestChar(this L_Recog recog, Pix pixs, out Box pbox, out float pscore, out int index, out IntPtr pcharstr, out Pix ppixdb)
        {
            throw new NotImplementedException();
        }


        // Low-level identification of single characters
        public static int recogIdentifyPixa(this L_Recog recog, HandleRef pixa, out Pix ppixdb)
        {
            throw new NotImplementedException();
        }

        public static int recogIdentifyPix(this L_Recog recog, Pix pixs, out Pix ppixdb)
        {
            throw new NotImplementedException();
        }

        public static int recogSkipIdentify(this L_Recog recog)
        {
            throw new NotImplementedException();
        }


        // Operations for handling identification results
        public static void rchaDestroy(this L_Rcha prcha)
        {
            throw new NotImplementedException();
        }

        public static void rchDestroy(this L_Rch prch)
        {
            throw new NotImplementedException();
        }

        public static int rchaExtract(this L_Rcha rcha, out Numa pnaindex, out Numa pnascore, out Sarray psatext, out Numa pnasample, out Numa pnaxloc, out Numa pnayloc, out Numa pnawidth)
        {
            throw new NotImplementedException();
        }

        public static int rchExtract(this L_Rch rch, out int index, out float pscore, out IntPtr ptext, out int sample, out int xloc, out int yloc, out int width)
        {
            throw new NotImplementedException();
        }


        // Preprocessing and filtering
        public static Pix recogProcessToIdentify(this L_Recog recog, Pix pixs, int pad)
        {
            throw new NotImplementedException();
        }


        // Postprocessing
        public static Sarray recogExtractNumbers(this L_Recog recog, HandleRef boxas, float scorethresh, int spacethresh, out Boxaa pbaa, out Numaa pnaa)
        {
            throw new NotImplementedException();
        }

        public static Pixa showExtractNumbers(this Pix pixs, Sarray sa, Boxaa baa, Numaa naa, out Pix ppixdb)
        {
            throw new NotImplementedException();
        } 
    }
}
