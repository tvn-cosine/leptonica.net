using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PsIO1
    {
        // Convert specified files to PS
        public static int convertFilesToPS(string dirin, string substr, int res, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int sarrayConvertFilesToPS(this Sarray sa, int res, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int convertFilesFittedToPS(string dirin, string substr, float xpts, float ypts, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int sarrayConvertFilesFittedToPS(this Sarray sa, float xpts, float ypts, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int writeImageCompressedToPSFile(string filein, string fileout, int res, out int pfirstfile, out int pindex)
        {
            throw new NotImplementedException();
        }


        // Convert mixed text/image files to PS
        public static int convertSegmentedPagesToPS(string pagedir, string pagestr, int page_numpre, string maskdir, string maskstr, int mask_numpre, int numpost, int maxnum, float textscale, float imagescale, int threshold, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteMixedToPS(this Pix pixb, Pix pixc, float scale, int pageno, string fileout)
        {
            throw new NotImplementedException();
        }


        // Convert any image file to PS for embedding
        public static int convertToPSEmbed(string filein, string fileout, int level)
        {
            throw new NotImplementedException();
        }


        // Write all images in a pixa out to PS
        public static int pixaWriteCompressedToPS(this Pixa pixa, string fileout, int res, int level)
        {
            throw new NotImplementedException();
        } 
    }
}
