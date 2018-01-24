using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PdfIO2
    {
        // Intermediate function for single page, multi-image conversion
        public static int pixConvertToPdfData(this Pix pix, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, string title, out IntPtr plpd, int position)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixConvertToPdfData((HandleRef)pix, type, quality, out pdata, pnbytes, x, y, res, title, out plpd, position);
        }


        // Intermediate function for generating multipage pdf output
        public static int ptraConcatenatePdfToData(this L_Ptra pa_data, Sarray sa, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == pa_data)
            {
                throw new ArgumentNullException("pa_data cannot be null.");
            }

            return Native.DllImports.ptraConcatenatePdfToData((HandleRef)pa_data, (HandleRef)sa, out pdata, pnbytes);
        }


        // Convert tiff multipage to pdf file
        public static int convertTiffMultipageToPdf(string filein, string fileout)
        {
            if (string.IsNullOrWhiteSpace(filein))
            {
                throw new ArgumentNullException("filein cannot be null.");
            }

            if (!System.IO.File.Exists(filein))
            {
                throw new System.IO.FileNotFoundException("filein does not exist.");
            }

            return Native.DllImports.convertTiffMultipageToPdf(filein, fileout);
        }


        // Low-level CID-based operations Without transcoding
        public static int l_generateCIDataForPdf(string fname, Pix pix, int quality, out IntPtr pcid)
        {

            return Native.DllImports.l_generateCIDataForPdf(fname, (HandleRef)pix, quality, out pcid);
        }

        public static L_Compressed_Data l_generateFlateDataPdf(string fname, Pix pixs)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist.");
            }

            var pointer = Native.DllImports.l_generateFlateDataPdf(fname, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Compressed_Data(pointer);
            }
        }

        public static L_Compressed_Data l_generateJpegData(string fname, int ascii85flag)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist.");
            }

            var pointer = Native.DllImports.l_generateJpegData(fname, ascii85flag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Compressed_Data(pointer);
            }
        }


        // With transcoding
        public static int l_generateCIData(string fname, int type, int quality, int ascii85, out IntPtr pcid)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist.");
            }

            return Native.DllImports.l_generateCIData(fname, type, quality, ascii85, out pcid);
        }

        public static int pixGenerateCIData(this Pix pixs, int type, int quality, int ascii85, out IntPtr pcid)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixGenerateCIData((HandleRef)pixs, type, quality, ascii85, out pcid);
        }

        public static L_Compressed_Data l_generateFlateData(string fname, int ascii85flag)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist.");
            }

            var pointer = Native.DllImports.l_generateJpegData(fname, ascii85flag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Compressed_Data(pointer);
            }
        }

        public static L_Compressed_Data l_generateG4Data(string fname, int ascii85flag)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            if (!System.IO.File.Exists(fname))
            {
                throw new System.IO.FileNotFoundException("fname does not exist.");
            }

            var pointer = Native.DllImports.l_generateG4Data(fname, ascii85flag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Compressed_Data(pointer);
            }
        }


        // Other
        public static int cidConvertToPdfData(this L_Compressed_Data cid, string title, out IntPtr pdata, IntPtr pnbytes)
        {
            if (null == cid)
            {
                throw new ArgumentNullException("cid cannot be null.");
            }

            return Native.DllImports.cidConvertToPdfData((HandleRef)cid, title, out pdata, pnbytes);
        }

        public static void l_CIDataDestroy(this L_Compressed_Data pcid)
        {
            if (null == pcid)
            {
                throw new ArgumentNullException("pcid cannot be null");
            }

            var pointer = (IntPtr)pcid;

            Native.DllImports.l_CIDataDestroy(ref pointer);
        }


        // Set flags for special modes
        public static void l_pdfSetG4ImageMask(int flag)
        {
            Native.DllImports.l_pdfSetG4ImageMask(flag);
        }

        public static void l_pdfSetDateAndVersion(int flag)
        {
            Native.DllImports.l_pdfSetDateAndVersion(flag);
        } 
    }
}
