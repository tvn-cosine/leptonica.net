using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class WriteFile
    {
        // High-level procedures for writing images to file:
        /// <summary>
        /// Use %format = IFF_DEFAULT to decide the output format individually for each pix.
        /// </summary>
        /// <param name="rootname"></param>
        /// <param name="pixa"></param>
        /// <param name="format">defined in imageio.h; see notes for default</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixaWriteFiles(string rootname, Pixa pixa, ImageFileFormatTypes format)
        {
            if (null == pixa
             || string.IsNullOrWhiteSpace(rootname))
            {
                throw new ArgumentNullException("pixa, rootname cannot be null.");
            }
            if (!System.IO.Directory.Exists(rootname))
            {
                throw new System.IO.DirectoryNotFoundException("rootname does not exist");
            }

            return Native.DllImports.pixaWriteFiles(rootname, (HandleRef)pixa, format);
        }

        /// <summary>
        /// (1) Open for write using binary mode (with the "b" flag)
        ///     to avoid having Windows automatically translate the NL
        ///     into CRLF, which corrupts image files.  On non-windows
        ///     systems this flag should be ignored, per ISO C90.
        ///     Thanks to Dave Bryan for pointing this out.
        /// (2) If the default image format IFF_DEFAULT is requested:
        ///     use the input format if known; otherwise, use a lossless format.
        /// (3) There are two modes with respect to file naming.
        ///     (a) The default code writes to %fname.
        ///     (b) If WRITE_AS_NAMED is defined to 0, it's a bit fancier.
        ///         Then, if %fname does not have a file extension, one is
        ///         automatically appended, depending on the requested format.
        ///     The original intent for providing option (b) was to insure
        ///     that filenames on Windows have an extension that matches
        ///     the image compression.  However, this is not the default.
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="pix"></param>
        /// <param name="format">defined in imageio.h</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixWrite(string fname, Pix pix, ImageFileFormatTypes format)
        {
            if (null == pix
             || string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("pix, fname cannot be null.");
            }

            return Native.DllImports.pixWrite(fname, (HandleRef)pix, format);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pix"></param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixWriteAutoFormat(string filename, Pix pix)
        {
            if (null == pix
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("pix, filename cannot be null.");
            }

            return Native.DllImports.pixWriteAutoFormat(filename, (HandleRef)pix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="pix"></param>
        /// <param name="format"></param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixWriteStream(IntPtr fp, Pix pix, ImageFileFormatTypes format)
        {
            if (null == pix
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("pix, fp cannot be null.");
            }

            return Native.DllImports.pixWriteStream(fp, (HandleRef)pix, format);
        }

        /// <summary>
        /// (1) This determines the output format from the filename extension.
        /// (2) The last two args are ignored except for requests for jpeg files.
        /// (3) The jpeg default quality is 75.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pix"></param>
        /// <param name="quality">iff JPEG; 1 - 100, 0 for default</param>
        /// <param name="progressive">iff JPEG; 0 for baseline seq., 1 for progressive</param>
        /// <returns>false if OK; true on error</returns>
        public static bool pixWriteImpliedFormat(string filename, Pix pix, int quality, int progressive)
        {
            if (null == pix
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("pix, filename cannot be null.");
            }

            return Native.DllImports.pixWriteImpliedFormat(filename, (HandleRef)pix, quality, progressive);
        }


        // Selection of output format if default is requested
        /// <summary>
        /// (1) This should only be called if the requested format is IFF_DEFAULT.
        /// (2) If the pix wasn't read from a file, its input format value
        ///     will be IFF_UNKNOWN, and in that case it is written out
        ///     in a compressed but lossless format.
        /// </summary>
        /// <param name="pix"></param>
        /// <returns>output format, or 0 on error</returns>
        public static ImageFileFormatTypes pixChooseOutputFormat(this Pix pix)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixChooseOutputFormat((HandleRef)pix);
        }

        /// <summary>
        /// This determines the output file format from the extension of the input filename.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>output format, or IFF_UNKNOWN on error or invalid extension.</returns>
        public static ImageFileFormatTypes getImpliedFileFormat(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }

            return Native.DllImports.getImpliedFileFormat(filename);
        }

        /// <summary>
        /// (1) The output formats are restricted to tiff, jpeg and png
        ///     because these are the most commonly used image formats and
        ///     the ones that are typically installed with leptonica.
        /// (2) This decides what compression to use based on the pix.
        ///     It chooses tiff-g4 if 1 bpp without a colormap, jpeg with
        ///     quality 75 if grayscale, rgb or rgba (where it loses
        ///     the alpha layer), and lossless png for all other situations.
        /// </summary>
        /// <param name="pix"></param>
        /// <param name="pformat"></param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixGetAutoFormat(this Pix pix, out ImageFileFormatTypes pformat)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixGetAutoFormat((HandleRef)pix, out pformat);
        }

        /// <summary>
        /// This string is NOT owned by the caller; it is just a pointer to a global string.  Do not free it.
        /// </summary>
        /// <param name="format"></param>
        /// <returns>extension string, or NULL if format is out of range</returns>
        public static string getFormatExtension(ImageFileFormatTypes format)
        {
            var pointer = Native.DllImports.getFormatExtension(format);
            return Marshal.PtrToStringAnsi(pointer);
        }


        // Write to memory
        /// <summary>
        ///      (1) On windows, this will only write tiff and PostScript to memory.
        ///          For other formats, it requires open_memstream(3).
        ///      (2) PostScript output is uncompressed, in hex ascii.
        ///          Most printers support level 2 compression (tiff_g4 for 1 bpp,
        /// jpeg for 8 and 32 bpp).
        /// </summary>
        /// <param name="pdata">data of tiff compressed image</param>
        /// <param name="psize">size of returned data</param>
        /// <param name="pix"></param>
        /// <param name="format">defined in imageio.h</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixWriteMem(out IntPtr pdata, out IntPtr psize, Pix pix, ImageFileFormatTypes format)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixWriteMem(out pdata, out psize, (HandleRef)pix, format);
        }


        // Image display for debugging
        /// <summary>
        /// (1) This is a convenient wrapper for displaying image files.
        /// (2) Set %scale = 0 to disable display.
        /// (3) This downscales 1 bpp to gray.
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="x">location of display frame on the screen</param>
        /// <param name="y">location of display frame on the screen</param>
        /// <param name="scale">scale factor (use 0 to skip display)</param>
        /// <returns>false if OK, true on error</returns>
        public static bool l_fileDisplay(string fname, int x, int y, float scale)
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentNullException("fname cannot be null.");
            }

            return Native.DllImports.l_fileDisplay(fname, x, y, scale);
        }

        /// <summary>
        /// (1) This is debugging code that displays an image on the screen.
        ///     It uses a static internal variable to number the output files
        ///     written by a single process.  Behavior with a shared library
        ///     may be unpredictable.
        /// (2) It uses these programs to display the image:
        ///        On Unix: xzgv, xli or xv
        ///        On Windows: i_view
        ///     The display program must be on your $PATH variable.  It is
        ///     chosen by setting the global var_DISPLAY_PROG, using
        ///     l_chooseDisplayProg().  Default on Unix is xzgv.
        /// (3) Images with dimensions larger than MAX_DISPLAY_WIDTH or
        ///     MAX_DISPLAY_HEIGHT are downscaled to fit those constraints.
        ///     This is particularly important for displaying 1 bpp images
        ///     with xv, because xv automatically downscales large images
        ///     by subsampling, which looks poor.  For 1 bpp, we use
        ///     scale-to-gray to get decent-looking anti-aliased images.
        ///     In all cases, we write a temporary file to /tmp/lept/disp,
        ///     that is read by the display program.
        /// (4) The temporary file is written as png if, after initial
        ///     processing for special cases, any of these obtain:
        ///       * pix dimensions are smaller than some thresholds
        ///       * pix depth is less than 8 bpp
        ///       * pix is colormapped
        /// (5) For spp == 4, we call pixDisplayLayersRGBA() to show 3
        ///     versions of the image: the image with a fully opaque
        ///     alpha, the alpha, and the image as it would appear with
        ///     a white background.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="x">location of display frame on the screen</param>
        /// <param name="y">location of display frame on the screen</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixDisplay(this Pix pixs, int x, int y)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixDisplay((HandleRef)pixs, x, y);
        }

        /// <summary>
        /// (1) See notes for pixDisplay().
        /// (2) This displays the image if dispflag == 1; otherwise it punts.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="x">location of display frame</param>
        /// <param name="y">location of display frame</param>
        /// <param name="title">[optional] on frame; can be NULL;</param>
        /// <param name="dispflag">true to write, else disabled</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixDisplayWithTitle(this Pix pixs, int x, int y, string title, bool dispflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            return Native.DllImports.pixDisplayWithTitle((HandleRef)pixs, x, y, title, dispflag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 32 bpp</param>
        /// <param name="pixa">the pix are accumulated here</param>
        /// <param name="scalefactor">0.0 to disable; otherwise this is a scale factor</param>
        /// <param name="newrow">false if placed on the same row as previous; true otherwise</param>
        /// <param name="space">horizontal and vertical spacing, in pixels</param>
        /// <param name="dp">depth of pixa; 8 or 32 bpp; only used on first call</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSaveTiled(this Pix pixs, Pixa pixa, float scalefactor, bool newrow, int space, int dp)
        {
            if (null == pixs
             || null == pixa)
            {
                throw new ArgumentNullException("pixs, pixa cannot be null.");
            }

            return Native.DllImports.pixSaveTiled((HandleRef)pixs, (HandleRef)pixa, scalefactor, newrow, space, dp);
        }

        /// <summary>
        /// (1) Before calling this function for the first time, use
        ///     pixaCreate() to make the %pixa that will accumulate the pix.
        ///     This is passed in each time pixSaveTiled() is called.
        /// (2) %scalefactor scales the input image.  After scaling and
        ///     possible depth conversion, the image is saved in the input
        ///     pixa, along with a box that specifies the location to
        ///     place it when tiled later.  Disable saving the pix by
        ///     setting %scalefactor == 0.0.
        /// (3) %newrow and %space specify the location of the new pix
        ///     with respect to the last one(s) that were entered.
        /// (4) %dp specifies the depth at which all pix are saved.  It can
        ///     be only 8 or 32 bpp.  Any colormap is removed.  This is only
        ///     used at the first invocation.
        /// (5) This function uses two variables from call to call.
        ///     If they were static, the function would not be .so or thread
        ///     safe, and furthermore, there would be interference with two or
        ///     more pixa accumulating images at a time.  Consequently,
        ///     we use the first pix in the pixa to store and obtain both
        ///     the depth and the current position of the bottom (one pixel
        ///     below the lowest image raster line when laid out using
        ///     the boxa).  The bottom variable is stored in the input format
        ///     field, which is the only field available for storing an int.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 32 bpp</param>
        /// <param name="pixa">the pix are accumulated here</param>
        /// <param name="scalefactor">0.0 to disable; otherwise this is a scale factor</param>
        /// <param name="newrow">false if placed on the same row as previous; true otherwise</param>
        /// <param name="space">horizontal and vertical spacing, in pixels</param>
        /// <param name="linewidth">width of added outline for image; 0 for no outline</param>
        /// <param name="dp">depth of pixa; 8 or 32 bpp; only used on first call</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSaveTiledOutline(this Pix pixs, Pixa pixa, float scalefactor, bool newrow, int space, int linewidth, int dp)
        {
            if (null == pixs
             || null == pixa)
            {
                throw new ArgumentNullException("pixs, pixa cannot be null.");
            }

            return Native.DllImports.pixSaveTiledOutline((HandleRef)pixs, (HandleRef)pixa, scalefactor, newrow, space, linewidth, dp);
        }

        /// <summary>
        /// (1) Before calling this function for the first time, use
        ///     pixaCreate() to make the %pixa that will accumulate the pix.
        ///     This is passed in each time pixSaveTiled() is called.
        /// (2) %outwidth is the scaled width.  After scaling, the image is
        ///     saved in the input pixa, along with a box that specifies
        ///     the location to place it when tiled later.  Disable saving
        ///     the pix by setting %outwidth == 0.
        /// (3) %newrow and %space specify the location of the new pix
        ///     with respect to the last one(s) that were entered.
        /// (4) All pix are saved as 32 bpp RGB.
        /// (5) If both %bmf and %textstr are defined, this generates a pix
        ///     with the additional text; otherwise, no text is written.
        /// (6) The text is written before scaling, so it is properly
        ///     antialiased in the scaled pix.  However, if the pix on
        ///     different calls have different widths, the size of the
        ///     text will vary.
        /// (7) See pixSaveTiledOutline() for other implementation details.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 32 bpp</param>
        /// <param name="pixa">the pix are accumulated here; as 32 bpp</param>
        /// <param name="outwidth">in pixels; use 0 to disable entirely</param>
        /// <param name="newrow">true to start a new row; false to go on same row as previous</param>
        /// <param name="space">horizontal and vertical spacing, in pixels</param>
        /// <param name="linewidth">width of added outline for image; 0 for no outline</param>
        /// <param name="bmf">[optional] font struct</param>
        /// <param name="textstr">[optional] text string to be added</param>
        /// <param name="val">color to set the text</param>
        /// <param name="location">L_ADD_ABOVE, L_ADD_AT_TOP, L_ADD_AT_BOT, L_ADD_BELOW</param>
        /// <returns>false if OK, true on error</returns>
        public static bool pixSaveTiledWithText(this Pix pixs, Pixa pixa, int outwidth, bool newrow, int space, int linewidth, L_Bmf bmf, string textstr, uint val, FlagsForAddingTextToAPix location)
        {
            if (null == pixs
             || null == pixa)
            {
                throw new ArgumentNullException("pixs, pixa cannot be null.");
            }

            return Native.DllImports.pixSaveTiledWithText((HandleRef)pixs, (HandleRef)pixa, outwidth, newrow, space, linewidth, (HandleRef)bmf, textstr, val, location);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection"></param>
        public static void l_chooseDisplayProg(FlagsForSelectingDisplayProgram selection)
        {
            Native.DllImports.l_chooseDisplayProg(selection);
        }

        /// <summary>
        /// setLeptDebugOK()
        /// </summary>
        /// <param name="allow">allow     TRUE (1) or FALSE (0)</param>
        /// <![CDATA[
        ///  * Notes:
        ///(1) This sets or clears the global variable LeptDebugOK, to
        ///    control writing files in a temp directory with names that
        ///    are compiled in.
        ///(2) The default in the library distribution is 0.  Call with
        ///    %allow = 1 for development and debugging.
        /// ]]>
        public static void setLeptDebugOK(int allow)
        {
            Native.DllImports.setLeptDebugOK(allow);
        }

        // Deprecated pix output for debugging
        /// <summary>
        /// (0) Deprecated.
        /// (1) This is a simple interface for writing a set of files that can
        ///     be either looked at individually or saved in a pdf for viewing.
        /// (2) This defaults to jpeg output for pix that are 32 bpp or
        ///     8 bpp without a colormap.  If you want to write all images
        ///     losslessly, use format == IFF_PNG in pixDisplayWriteFormat().
        /// (3) See pixDisplayWriteFormat() for usage details.
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="reduction">-1 to reset/erase; 0 to disable; otherwise this is a reduction factor</param>
        /// <returns>false if OK, true on error</returns>
        [Obsolete("Deprecated.")]
        public static bool pixDisplayWrite(this Pix pixs, int reduction)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixDisplayWrite((HandleRef)pixs, reduction);
        }

        /// <summary>
        /// (0) Deprecated.
        /// (1) This writes files with pathnames "/tmp/lept/display/file.*"
        ///     if reduction > 0.  These can be collected into a pdf using
        ///     pixDisplayMultiple();
        /// (2) To erase any previously written files in the output directory:
        ///        pixDisplayWrite(NULL, -1);
        /// (3) If reduction > 1 and depth == 1, this does a scale-to-gray
        ///     reduction.
        /// (4) This function uses a static internal variable to number
        ///     output files written by a single process.  Behavior
        ///     with a shared library may be unpredictable. 
        /// </summary>
        /// <param name="pixs">1, 2, 4, 8, 16, 32 bpp</param>
        /// <param name="reduction">-1 to erase and reset; 0 to disable;  otherwise this is an integer reduction factor</param>
        /// <param name="format">IFF_DEFAULT or IFF_PNG</param>
        /// <returns>false if OK, true on error</returns>
        [Obsolete("Deprecated.")]
        public static bool pixDisplayWriteFormat(this Pix pixs, int reduction, ImageFileFormatTypes format)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            return Native.DllImports.pixDisplayWriteFormat((HandleRef)pixs, reduction, format);
        }

        /// <summary>
        ///      (0) Deprecated.
        ///      (1) This is a wrapper for generating a pdf of images that have
        ///            been written with pixDisplayWrite() or pixDisplayWriteFormat().
        /// </summary>
        /// <param name="res">input resolution in ppi; > 0</param>
        /// <param name="scalefactor">scaling factor applied to each image; > 0.0</param>
        /// <param name="fileout">pdf output file</param>
        /// <returns>false if OK, true on error</returns>
        [Obsolete("Deprecated.")]
        public static bool pixDisplayMultiple(int res, float scalefactor, string fileout)
        {
            return Native.DllImports.pixDisplayMultiple(res, scalefactor, fileout);
        }
    }
}
