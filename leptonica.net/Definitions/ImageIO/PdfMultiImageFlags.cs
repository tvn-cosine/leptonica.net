namespace Leptonica 
{
    /// <summary>
    /// Pdf multi image flags
    /// </summary>
    public enum PdfMultiImageFlags
    {
        /// <summary>
        /// first image to be used
        /// </summary>
        L_FIRST_IMAGE = 1,
        /// <summary>
        /// intermediate image; not first or last 
        /// </summary>
        L_NEXT_IMAGE = 2,
        /// <summary>
        /// last image to be used
        /// </summary>
        L_LAST_IMAGE = 3
    }
}
