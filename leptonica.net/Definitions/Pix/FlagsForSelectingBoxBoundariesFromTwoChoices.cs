namespace Leptonica 
{
    /// <summary>
    /// Flags for selecting box boundaries from two choices
    /// </summary>
    public enum FlagsForSelectingBoxBoundariesFromTwoChoices
    {
        /// <summary>
        /// use boundaries giving min size
        /// </summary>
        L_USE_MINSIZE = 1,
        /// <summary>
        /// use boundaries giving max size  
        /// </summary>
        L_USE_MAXSIZE = 2,
        /// <summary>
        /// substitute boundary if big abs diff
        /// </summary>
        L_SUB_ON_BIG_DIFF = 3,
        /// <summary>
        /// substitute boundary with capped min
        /// </summary>
        L_USE_CAPPED_MIN = 4,
        /// <summary>
        /// substitute boundary with capped max 
        /// </summary>
        L_USE_CAPPED_MAX = 5
    }
}
