namespace Leptonica
{
    /// <summary>
    /// Flags for 8 bit and 16 bit pixel sums
    /// </summary>
    public enum FlagsFor8BitAnd16BitSums
    {
        /// <summary>
        /// white pixels are 0xff or 0xffff; black are 0
        /// </summary>
        L_WHITE_IS_MAX = 1,
        /// <summary>
        /// black pixels are 0xff or 0xffff; white are 0
        /// </summary>
        L_BLACK_IS_MAX = 2 
    }
}
