using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RecogTrain
    {
        // Training on labeled data
        public static int recogTrainLabeled(this L_Recog recog, Pix pixs, HandleRef box,   string text, int debug)
        {
            throw new NotImplementedException();
        }

        public static int recogProcessLabeled(this L_Recog recog, Pix pixs, HandleRef box,   string text, out Pix ppix)
        {
            throw new NotImplementedException();
        }

        public static int recogAddSample(this L_Recog recog, Pix pix, int debug)
        {
            throw new NotImplementedException();
        }

        public static Pix recogModifyTemplate(this L_Recog recog, Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static int recogAverageSamples(IntPtr precog, int debug)
        {
            throw new NotImplementedException();
        }

        public static int pixaAccumulateSamples(this Pixa pixa, Pta pta, out Pix ppixd, out float px, out float py)
        {
            throw new NotImplementedException();
        }

        public static int recogTrainingFinished(IntPtr precog, int modifyflag, int minsize, float minfract)
        {
            throw new NotImplementedException();
        }

        public static Pixa recogFilterPixaBySize(this Pixa pixas, int setsize, int maxkeep, float max_ht_ratio, out Numa pna)
        {
            throw new NotImplementedException();
        }

        public static Pixaa recogSortPixaByClass(this Pixa pixa, int setsize)
        {
            throw new NotImplementedException();
        }

        public static int recogRemoveOutliers1(IntPtr precog, float minscore, int mintarget, int minsize, out Pix ppixsave, out Pix ppixrem)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaRemoveOutliers1(this Pixa pixas, float minscore, int mintarget, int minsize, out Pix ppixsave, out Pix ppixrem)
        {
            throw new NotImplementedException();
        }

        public static int recogRemoveOutliers2(IntPtr precog, float minscore, int minsize, out Pix ppixsave, out Pix ppixrem)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaRemoveOutliers2(this Pixa pixas, float minscore, int minsize, out Pix ppixsave, out Pix ppixrem)
        {
            throw new NotImplementedException();
        }


        // Training on unlabeled data
        public static L_Recog recogTrainFromBoot(this L_Recog recogboot, HandleRef pixas, float minscore, int threshold, int debug)
        {
            throw new NotImplementedException();
        }


        // Padding the digit training set
        public static int recogPadDigitTrainingSet(IntPtr precog, int scaleh, int linew)
        {
            throw new NotImplementedException();
        }

        public static int recogIsPaddingNeeded(this L_Recog recog, out Sarray psa)
        {
            throw new NotImplementedException();
        }

        public static Pixa recogAddDigitPadTemplates(this L_Recog recog, Sarray sa)
        {
            throw new NotImplementedException();
        }


        // Making a boot digit recognizer
        public static L_Recog recogMakeBootDigitRecog(int scaleh, int linew, int maxyshift, int debug)
        {
            throw new NotImplementedException();
        }

        public static Pixa recogMakeBootDigitTemplates(int debug)
        {
            throw new NotImplementedException();
        }


        // Debugging
        public static int recogShowContent(IntPtr fp, L_Recog recog, int index, int display)
        {
            throw new NotImplementedException();
        }

        public static int recogDebugAverages(IntPtr precog, int debug)
        {
            throw new NotImplementedException();
        }

        public static int recogShowAverageTemplates(this L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static int recogShowMatchesInRange(this L_Recog recog, HandleRef pixa, float minscore, float maxscore, int display)
        {
            throw new NotImplementedException();
        }

        public static Pix recogShowMatch(this L_Recog recog, Pix pix1, Pix pix2, HandleRef box, int index, float score)
        {
            throw new NotImplementedException();
        } 
    }
}
