namespace Leptonica
{
    /// <summary>
    /// Flags for method of extracting barcode widths
    /// </summary>
    public enum FlagsForMethodOfExtractingBarcodeWidths
    {
        /// <summary>
        /// use histogram of barcode widths
        /// </summary>
        L_USE_WIDTHS = 1,
        /// <summary>
        /// find best window for decoding transitions
        /// </summary>
        L_USE_WINDOWS = 2
    }
}
