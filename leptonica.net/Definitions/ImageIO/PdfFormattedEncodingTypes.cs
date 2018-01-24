namespace Leptonica 
{
    /// <summary>
    /// Pdf formatted encoding types
    /// </summary>
    public enum PdfFormattedEncodingTypes
    {
        /// <summary>
        /// use default encoding based on image
        /// </summary>
        L_DEFAULT_ENCODE = 0,
        /// <summary>
        /// use dct encoding: 8 and 32 bpp, no cmap
        /// </summary>
        L_JPEG_ENCODE = 1,
        /// <summary>
        /// use ccitt g4 fax encoding: 1 bpp
        /// </summary>
        L_G4_ENCODE = 2,
        /// <summary>
        /// use flate encoding: any depth, cmap ok
        /// </summary>
        L_FLATE_ENCODE = 3,
        /// <summary>
        /// use jp2k encoding: 8 and 32 bpp, no cmap
        /// </summary>
        L_JP2K_ENCODE = 4
    }
}
