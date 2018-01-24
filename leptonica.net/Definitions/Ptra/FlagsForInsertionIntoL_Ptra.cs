namespace Leptonica.Definitions.Ptra
{
    /// <summary>
    /// Flags for insertion into L_Ptra
    /// </summary>
    public enum FlagsForInsertionIntoL_Ptra
    {
        /// <summary>
        /// choose based on number of holes 
        /// </summary>
        L_AUTO_DOWNSHIFT = 0,
        /// <summary>
        /// downshifts min # of ptrs below insert
        /// </summary>
        L_MIN_DOWNSHIFT = 1,
        /// <summary>
        /// downshifts all ptrs below insert 
        /// </summary>
        L_FULL_DOWNSHIFT = 2
    }
}
