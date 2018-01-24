namespace Leptonica 
{
    /// <summary>
    /// Format header ids
    /// </summary>
    public enum FormatHeaderIds
    {
        /// <summary>
        /// BM - for bitmaps
        /// </summary>
        BMP_ID = 0x4d42,
        /// <summary>
        /// MM - for 'motorola'
        /// </summary>
        TIFF_BIGEND_ID = 0x4d4d,
        /// <summary>
        /// II - for 'intel' 
        /// </summary>
        TIFF_LITTLEEND_ID = 0x4949
    }
}
