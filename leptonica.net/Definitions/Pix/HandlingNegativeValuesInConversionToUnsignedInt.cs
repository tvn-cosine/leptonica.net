namespace Leptonica
{
    /// <summary>
    /// Handling negative values in conversion to unsigned int
    /// </summary>
    public enum HandlingNegativeValuesInConversionToUnsignedInt
    {
        /// <summary>
        /// Clip negative values to 0 
        /// </summary>
        L_CLIP_TO_ZERO = 1,
        /// <summary>
        /// Convert to positive using L_ABS()  
        /// </summary>
        L_TAKE_ABSVAL = 2
    }
}
