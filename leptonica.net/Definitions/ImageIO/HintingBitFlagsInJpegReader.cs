namespace Leptonica 
{
    /// <summary>
    /// Hinting bit flags in jpeg reader
    /// </summary>
    public enum HintingBitFlagsInJpegReader
    {
        /// <summary>
        /// only want luminance data; no chroma
        /// </summary>
        L_JPEG_READ_LUMINANCE = 1,
        /// <summary>
        /// don't return possibly damaged pix
        /// </summary>
        L_JPEG_FAIL_ON_BAD_DATA = 2
    }
}
