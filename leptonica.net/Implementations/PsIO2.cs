using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PsIO2
    {
        // For uncompressed images
        public static int pixWritePSEmbed(string filein, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int pixWriteStreamPS(IntPtr fp, Pix pix, Box box, int res, float scale)
        {
            throw new NotImplementedException();
        }

        public static IntPtr pixWriteStringPS(this Pix pixs, Box box, int res, float scale)
        {
            throw new NotImplementedException();
        }

        public static IntPtr generateUncompressedPS(string hexdata, int w, int h, int d, int psbpl, int bps, float xpt, float ypt, float wpt, float hpt, int boxflag)
        {
            throw new NotImplementedException();
        }

        public static void getScaledParametersPS(HandleRef box, int wpix, int hpix, int res, float scale, out float pxpt, out float pypt, out float pwpt, out float phpt)
        {
            throw new NotImplementedException();
        }

        public static void convertByteToHexAscii(byte byteval, string pnib1, string pnib2)
        {
            throw new NotImplementedException();
        }


        // For jpeg compressed images(use dct compression)
        public static int convertJpegToPSEmbed(string filein, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int convertJpegToPS(string filein, string fileout, string operation, int x, int y, int res, float scale, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }

        public static int convertJpegToPSString(string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }

        public static IntPtr generateJpegPS(string filein, L_Compressed_Data cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }


        // For g4 fax compressed images(use ccitt g4 compression)
        public static int convertG4ToPSEmbed(string filein, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int convertG4ToPS(string filein, string fileout, string operation, int x, int y, int res, float scale, int pageno, int maskflag, int endpage)
        {
            throw new NotImplementedException();
        }

        public static int convertG4ToPSString(string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int maskflag, int endpage)
        {
            throw new NotImplementedException();
        }

        public static IntPtr generateG4PS(string filein, L_Compressed_Data cid, float xpt, float ypt, float wpt, float hpt, int maskflag, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }


        // For multipage tiff images
        public static int convertTiffMultipageToPS(string filein, string fileout, float fillfract)
        {
            throw new NotImplementedException();
        }


        // For flate(gzip) compressed images(e.g., png)
        public static int convertFlateToPSEmbed(string filein, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int convertFlateToPS(string filein, string fileout, string operation, int x, int y, int res, float scale, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }

        public static int convertFlateToPSString(string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }

        public static IntPtr generateFlatePS(string filein, L_Compressed_Data cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage)
        {
            throw new NotImplementedException();
        }


        // Write to memory
        public static int pixWriteMemPS(out IntPtr pdata, IntPtr psize, Pix pix, Box box, int res, float scale)
        {
            throw new NotImplementedException();
        }


        // Converting resolution
        public static int getResLetterPage(int w, int h, float fillfract)
        {
            throw new NotImplementedException();
        }

        public static int getResA4Page(int w, int h, float fillfract)
        {
            throw new NotImplementedException();
        }


        // Setting flag for writing bounding box hint
        public static void l_psWriteBoundingBox(int flag)
        {
            throw new NotImplementedException();
        } 
    }
}
