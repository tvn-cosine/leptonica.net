using System;
using System.Runtime.InteropServices;

namespace Leptonica
{ 
    public static class ReadFile
    {
        // Top-level functions for reading images from file
        /// <summary>
        ///      (1) %dirname is the full path for the directory.
        ///      (2) %substr is the part of the file name(excluding
        /// the directory) that is to be matched.All matching
        ///          filenames are read into the Pixa.If substr is NULL,
        /// all filenames are read into the Pixa.
        /// </summary>
        /// <param name="dirname"></param>
        /// <param name="substr">[optional] substring filter on filenames; can be null</param>
        /// <returns>pixa, or NULL on error</returns>
        public static Pixa pixaReadFiles(string dirname, string substr)
        {
            if (string.IsNullOrEmpty(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null.");
            }
            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist");
            }

            var pointer = Native.DllImports.pixaReadFiles(dirname, substr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sa">string array of full pathnames for all files</param>
        /// <returns>pixa, or NULL on error</returns>
        public static Pixa pixaReadFilesSA(this Sarray sa)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            var pointer = Native.DllImports.pixaReadFilesSA((HandleRef)sa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        /// <summary>
        /// See at top of file for supported formats.
        /// </summary>
        /// <param name="filename">filename with full pathname or in local directory</param>
        /// <returns>pix if OK; NULL on error</returns>
        public static Pix pixRead(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        /// The hint is not binding, but may be used to optimize jpeg decoding. Use 0 for no hinting.
        /// </summary>
        /// <param name="filename">filename with full pathname or in local directory</param>
        /// <param name="hint">hint bitwise OR of L_HINT_* values for jpeg; use 0 for no hint</param>
        /// <returns>pix if OK; NULL on error</returns>
        public static Pix pixReadWithHint(string filename, int hint)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixReadWithHint(filename, hint);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) This function is useful for selecting image files from a
        /// directory, where the integer %index is embedded into
        ///          the file name.
        ///      (2) This is typically done by generating the sarray using
        /// getNumberedPathnamesInDirectory(), so that the %index
        /// pathname would have the number %index in it.The size
        /// of the sarray should be the largest number(plus 1) appearing
        ///          in the file names, respecting the constraints in the
        /// call to getNumberedPathnamesInDirectory().
        ///      (3) Consequently, for some indices into the sarray, there may
        /// be no pathnames in the directory containing that number. 
        /// By convention, we place empty C strings("") in those
        /// locations in the sarray, and it is not an error if such
        /// a string is encountered and no pix is returned. 
        /// Therefore, the caller must verify that a pix is returned.
        ///      (4) See convertSegmentedPagesToPS() in src/psio1.c for an
        /// example of usage.
        /// </summary>
        /// <param name="sa">string array of full pathnames</param>
        /// <param name="index">index into pathname array</param>
        /// <returns>pix if OK; null if not found</returns>
        public static Pix pixReadIndexed(this Sarray sa, int index)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            var pointer = Native.DllImports.pixReadIndexed((HandleRef)sa, index);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        /// The hint only applies to jpeg.
        /// </summary>
        /// <param name="fp">fp file stream</param>
        /// <param name="hint">hint bitwise OR of L_HINT_* values for jpeg; use 0 for no hint</param>
        /// <returns>pix if OK; NULL on error</returns>
        public static Pix pixReadStream(IntPtr fp, int hint)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.pixReadStream(fp, hint);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }


        // Read header information from file
        /// <summary>
        /// This reads the actual headers for jpeg, png, tiff and pnm.
        /// For bmp and gif, we cheat and read the entire file into a pix, from which we extract the "header" information.
        /// </summary>
        /// <param name="filename">filename with full pathname or in local directory</param>
        /// <param name="pformat">file format</param>
        /// <param name="pw"></param>
        /// <param name="ph"></param>
        /// <param name="pbps">bits/sample</param>
        /// <param name="pspp">samples/pixel 1, 3 or 4</param>
        /// <param name="piscmap">1 if cmap exists; 0 otherwise</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixReadHeader(string filename, out ImageFileFormatTypes pformat, out int pw, out int ph, out int pbps, out int pspp, out bool piscmap)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            return Native.DllImports.pixReadHeader(filename, out pformat, out pw, out ph, out pbps, out pspp, out piscmap);
        }


        // Format finders
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pformat">found format</param>
        /// <returns>false if OK, true on error or if format is not recognized</returns>
        public static bool findFileFormat(string filename, out ImageFileFormatTypes pformat)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            return Native.DllImports.findFileFormat(filename, out pformat);
        }

        /// <summary>
        /// Important: Side effect -- this resets fp to BOF.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="pformat"></param>
        /// <returns>false if OK, true on error or if format is not recognized</returns>
        public static bool findFileFormatStream(IntPtr fp, out ImageFileFormatTypes pformat)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            return Native.DllImports.findFileFormatStream(fp, out pformat);
        }

        /// <summary>
        /// (1) This determines the file format from the first 12 bytes in
        ///     the compressed data stream, which are stored in memory.
        /// (2) For tiff files, this returns IFF_TIFF.The specific tiff
        ///     compression is then determined using findTiffCompression().
        /// </summary>
        /// <param name="buf">byte buffer at least 12 bytes in size; we can't check</param>
        /// <param name="pformat">found format</param>
        /// <returns>false if OK, true on error or if format is not recognized</returns>
        public static bool findFileFormatBuffer(IntPtr buf, out ImageFileFormatTypes pformat)
        {
            if (IntPtr.Zero == buf)
            {
                throw new ArgumentNullException("buf cannot be null.");
            }

            return Native.DllImports.findFileFormatBuffer(buf, out pformat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fp">file stream</param>
        /// <returns>true if file is tiff; false otherwise or on error</returns>
        public static bool fileFormatIsTiff(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            return Native.DllImports.fileFormatIsTiff(fp);
        }


        // Read from memory
        /// <summary>
        ///      (1) This is a variation of pixReadStream(), where the data is read
        /// from a memory buffer rather than a file.
        ///      (2) On windows, this only reads tiff formatted files directly from
        /// memory.For other formats, it writes to a temp file and
        /// decompresses from file.
        ///      (3) findFileFormatBuffer() requires up to 12 bytes to decide on
        ///          the format.That determines the constraint here.  But in
        ///          fact the data must contain the entire compressed string for
        ///          the image.
        /// </summary>
        /// <param name="data">const; encoded</param>
        /// <param name="size">size of data</param>
        /// <returns>pix, or NULL on error</returns>
        public static Pix pixReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null.");
            }

            var pointer = Native.DllImports.pixReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        /// <summary>
        ///      (1) This reads the actual headers for jpeg, png, tiff, jp2k and pnm.
        /// For bmp and gif, we cheat and read all the data into a pix,
        ///          from which we extract the "header" information.
        ///      (2) The amount of data required depends on the format.For
        /// png, it requires less than 30 bytes, but for jpeg it can
        /// require most of the compressed file.In practice, the data
        ///          is typically the entire compressed file in memory.
        ///      (3) findFileFormatBuffer() requires up to 8 bytes to decide on
        ///          the format, which we require.
        /// </summary>
        /// <param name="data">const; encoded</param>
        /// <param name="size">size of data</param>
        /// <param name="pformat">image format</param>
        /// <param name="pw"></param>
        /// <param name="ph"></param>
        /// <param name="pbps"></param>
        /// <param name="pspp"></param>
        /// <param name="piscmap"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixReadHeaderMem(IntPtr data, IntPtr size, out ImageFileFormatTypes pformat, out int pw, out int ph, out int pbps, out int pspp, out bool piscmap)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null.");
            }

            return Native.DllImports.pixReadHeaderMem(data, size, out pformat, out pw, out ph, out pbps, out pspp, out piscmap);
        }


        // Output image file information
        /// <summary>
        /// (1) If headeronly == 0 and the image has spp == 4,this will
        /// also call pixDisplayLayersRGBA() to display the image
        /// in three views.
        /// </summary>
        /// <param name="filename">input file</param>
        /// <param name="fpout">output file stream</param>
        /// <param name="headeronly">1 to read only the header; 0 to read both the header and the input file</param>
        /// <returns>false if OK, true on error</returns>
        public static bool writeImageFileInfo(string filename, IntPtr fpout, bool headeronly)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            if (IntPtr.Zero == fpout)
            {
                throw new ArgumentNullException("fpout cannot be null.");
            }

            return Native.DllImports.writeImageFileInfo(filename, fpout, headeronly);
        }


        // Test function for I/O with different formats
        /// <summary>
        ///      (1) This writes and reads a set of output files losslessly
        ///          in different formats to /tmp/format/, and tests that the
        ///          result before and after is unchanged.
        ///      (2) This should work properly on input images of any depth,
        ///          with and without colormaps.
        ///      (3) All supported formats are tested for bmp, png, tiff and
        ///          non-ascii pnm.Ascii pnm also works (but who'd ever want
        ///          to use it?)   We allow 2 bpp bmp, although it's not
        ///          supported elsewhere.And we don't support reading
        ///          16 bpp png, although this can be turned on in pngio.c.
        ///      (4) This silently skips png or tiff testing if HAVE_LIBPNG
        /// or HAVE_LIBTIFF are 0, respectively.
        /// </summary>
        /// <param name="filename">input file</param>
        /// <returns>false if OK; true on error or if the test fails</returns>
        public static bool ioFormatTest(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            return Native.DllImports.ioFormatTest(filename);
        }
    }
}
