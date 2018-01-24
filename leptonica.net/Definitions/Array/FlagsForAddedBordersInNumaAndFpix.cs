namespace Leptonica 
{

    /// <summary>
    /// Flags for added borders in Numa and Fpix
    /// </summary>
    public enum FlagsForAddedBordersInNumaAndFpix
    {
        /// <summary>
        /// extended with same value    
        /// </summary>
        L_CONTINUED_BORDER = 1,
        /// <summary>
        /// extended with constant normal derivative
        /// </summary>
        L_SLOPE_BORDER = 2,
        /// <summary>
        /// mirrored    
        /// </summary>
        L_MIRRORED_BORDER = 3
    }
}
