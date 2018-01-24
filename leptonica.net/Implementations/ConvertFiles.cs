using System; 

namespace Leptonica 
{
    public static class ConvertFiles
    {
        // Conversion to 1 bpp 
        public static int convertFilesTo1bpp(string dirin, string substr, int upscaling, int thresh, int firstpage, int npages, string dirout, int outformat)
        {
            if (string.IsNullOrWhiteSpace(dirin)
             || string.IsNullOrWhiteSpace(dirout))
            {
                throw new ArgumentNullException("dirin, dirout cannot be null.");
            }
            if (System.IO.Directory.Exists(dirin)
             || System.IO.Directory.Exists(dirout))
            {
                throw new System.IO.DirectoryNotFoundException("dirin, dirout does not exist.");
            }

            return Native.DllImports.convertFilesTo1bpp(dirin, substr, upscaling, thresh, firstpage, npages, dirout, outformat);
        }
    }
}
