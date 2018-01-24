using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PdfIO1
    {
        // 1. Convert specified image files to pdf(one image file per page)
        public static int convertFilesToPdf(string dirname, string substr, int res, float scalefactor, int type, int quality, string title, string fileout)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            return Native.DllImports.convertFilesToPdf(dirname, substr, res, scalefactor, type, quality, title, fileout);
        }

        public static int saConvertFilesToPdf(this Sarray sa, int res, float scalefactor, int type, int quality, string title, string fileout)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.saConvertFilesToPdf((HandleRef)sa, res, scalefactor, type, quality, title, fileout);
        }

        public static int saConvertFilesToPdfData(this Sarray sa, int res, float scalefactor, int type, int quality, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == sa
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("sa, pnbytes cannot be null.");
            }

            return Native.DllImports.saConvertFilesToPdfData((HandleRef)sa, res, scalefactor, type, quality, title, out pdata, pnbytes);
        }

        public static int selectDefaultPdfEncoding(this Pix pix, out int ptype)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.selectDefaultPdfEncoding((HandleRef)pix, out ptype);
        }

        // 2. Convert specified image files to pdf without scaling
        public static int convertUnscaledFilesToPdf(string dirname, string substr, string title, string fileout)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            return Native.DllImports.convertUnscaledFilesToPdf(dirname, substr, title, fileout);
        }

        public static int saConvertUnscaledFilesToPdf(this Sarray sa, string title, string fileout)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.saConvertUnscaledFilesToPdf((HandleRef)sa, title, fileout);
        }

        public static int saConvertUnscaledFilesToPdfData(this Sarray sa, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == sa
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.saConvertUnscaledFilesToPdfData((HandleRef)sa, title, out pdata, pnbytes);
        }

        public static int convertUnscaledToPdfData(string fname, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.convertUnscaledToPdfData(fname, title, out pdata, pnbytes);
        }

        // 3. Convert multiple images to pdf(one image per page)
        public static int pixaConvertToPdf(this Pixa pixa, int res, float scalefactor, int type, int quality, string title, string fileout)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null.");
            }

            return Native.DllImports.pixaConvertToPdf((HandleRef)pixa, res, scalefactor, type, quality, title, fileout);
        }

        public static int pixaConvertToPdfData(this Pixa pixa, int res, float scalefactor, int type, int quality, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == pixa
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("pixa, pnbytes cannot be null.");
            }

            return Native.DllImports.pixaConvertToPdfData((HandleRef)pixa, res, scalefactor, type, quality, title, out pdata, pnbytes);
        }

        // 4. Single page, multi-image converters
        public static int convertToPdf(string filein, int type, int quality, string fileout, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (string.IsNullOrWhiteSpace(filein))
            {
                throw new ArgumentNullException("filein cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new System.IO.FileNotFoundException("filein does not exist.");
            }

            return Native.DllImports.convertToPdf(filein, type, quality, fileout, x, y, res, title, out plpd, position);
        }

        public static int convertImageDataToPdf(IntPtr imdata, IntPtr size, int type, int quality, string fileout, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (IntPtr.Zero == imdata
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("imdata, size cannot be null.");
            }

            return Native.DllImports.convertImageDataToPdf(imdata, size, type, quality, fileout, x, y, res, title, out plpd, position);
        }

        public static int convertToPdfData(string filein, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (string.IsNullOrWhiteSpace(filein)
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("filein, pnbytes cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new System.IO.FileNotFoundException("filein does not exist.");
            }

            return Native.DllImports.convertToPdfData(filein, type, quality, out pdata, pnbytes, x, y, res, title, out plpd, position);
        }

        public static int convertImageDataToPdfData(IntPtr imdata, IntPtr size, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (IntPtr.Zero == imdata
             || IntPtr.Zero == size
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("imdata, size, pnbytes cannot be null.");
            }

            return Native.DllImports.convertImageDataToPdfData(imdata, size, type, quality, out pdata, pnbytes, x, y, res, title, out plpd, position);
        }

        public static int pixConvertToPdf(this Pix pix, int type, int quality, string fileout, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixConvertToPdf((HandleRef)pix, type, quality, fileout, x, y, res, title, out plpd, position);
        }

        public static int pixWriteStreamPdf(IntPtr fp, Pix pix, int res, string title)
        {
            if (null == pix
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("pix, fp cannot be null.");
            }

            return Native.DllImports.pixWriteStreamPdf(fp, (HandleRef)pix, res, title);
        }

        public static int pixWriteMemPdf(out IntPtr pdata, IntPtr pnbytes, Pix pix, int res, string title)
        {
            if (null == pix
             || IntPtr.Zero == pnbytes)
            {
                throw new ArgumentNullException("pix, pnbytes cannot be null.");
            }

            return Native.DllImports.pixWriteMemPdf(out pdata, pnbytes, (HandleRef)pix, res, title);
        }


        // 5. Segmented multi-page, multi-image converter
        public static int convertSegmentedFilesToPdf(string dirname, string substr, int res, int type, int thresh, Boxaa baa, int quality, float scalefactor, string title, string fileout)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            return Native.DllImports.convertSegmentedFilesToPdf(dirname, substr, res, type, thresh, (HandleRef)baa, quality, scalefactor, title, fileout);
        }

        public static Boxaa convertNumberedMasksToBoxaa(string dirname, string substr, int numpre, int numpost)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            var pointer = Native.DllImports.convertNumberedMasksToBoxaa(dirname, substr, numpre, numpost);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        // 6. Segmented single page, multi-image converters
        public static int convertToPdfSegmented(string filein, int res, int type, int thresh, Boxaa boxa, int quality, float scalefactor, string title, string fileout)
        {
            if (string.IsNullOrWhiteSpace(filein))
            {
                throw new ArgumentNullException("filein cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new System.IO.FileNotFoundException("filein does not exist.");
            }

            return Native.DllImports.convertToPdfSegmented(filein, res, type, thresh, (HandleRef)boxa, quality, scalefactor, title, fileout);
        }

        public static int pixConvertToPdfSegmented(this Pix pixs, int res, int type, int thresh, Boxaa boxa, int quality, float scalefactor, string title, string fileout)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixConvertToPdfSegmented((HandleRef)pixs, res, type, thresh, (HandleRef)boxa, quality, scalefactor, title, fileout);
        }

        public static int convertToPdfDataSegmented(string filein, int res, int type, int thresh, Boxaa boxa, int quality, float scalefactor, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (string.IsNullOrWhiteSpace(filein))
            {
                throw new ArgumentNullException("filein cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new System.IO.FileNotFoundException("filein does not exist.");
            }

            return Native.DllImports.convertToPdfDataSegmented(filein, res, type, thresh, (HandleRef)boxa, quality, scalefactor, title, out pdata, pnbytes);
        }

        public static int pixConvertToPdfDataSegmented(this Pix pixs, int res, int type, int thresh, Boxaa boxa, int quality, float scalefactor, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixConvertToPdfDataSegmented((HandleRef)pixs, res, type, thresh, (HandleRef)boxa, quality, scalefactor, title, out pdata, pnbytes);
        }

        // 7. Multipage concatenation
        public static int concatenatePdf(string dirname, string substr, string fileout)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            return Native.DllImports.concatenatePdf(dirname, substr, fileout);
        }

        public static int saConcatenatePdf(this Sarray sa, string fileout)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.saConcatenatePdf((HandleRef)sa, fileout);
        }

        public static int ptraConcatenatePdf(this L_Ptra pa, string fileout)
        {
            if (null == pa)
            {
                throw new ArgumentNullException("pa cannot be null.");
            }

            return Native.DllImports.ptraConcatenatePdf((HandleRef)pa, fileout);
        }

        public static int concatenatePdfToData(string dirname, string substr, out IntPtr pdata, IntPtr pnbytes)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist.");
            }

            return Native.DllImports.concatenatePdfToData(dirname, substr, out pdata, pnbytes);
        }

        public static int saConcatenatePdfToData(this Sarray sa, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.saConcatenatePdfToData((HandleRef)sa, out pdata, pnbytes);
        }
    }
}
