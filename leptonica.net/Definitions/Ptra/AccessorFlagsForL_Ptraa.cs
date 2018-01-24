namespace Leptonica.Definitions.Ptra
{
    /// <summary>
    /// Accessor flags for L_Ptraa 
    /// </summary>
    public enum AccessorFlagsForL_Ptraa
    {
        /// <summary>
        /// ptr to L_Ptra; caller can inspect only
        /// </summary>
        L_HANDLE_ONLY = 0,
        /// <summary>
        /// caller owns; destroy or save in L_Ptraa
        /// </summary>
        L_REMOVE = 1
    }
}
