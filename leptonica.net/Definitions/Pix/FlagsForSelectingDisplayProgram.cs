namespace Leptonica
{
    /// <summary>
    /// Flags for selecting display program 
    /// </summary>
    public enum FlagsForSelectingDisplayProgram
    {
        /// <summary>
        /// Use xzgv with pixDisplay()   
        /// </summary>
        L_DISPLAY_WITH_XZGV = 1,
        /// <summary>
        /// Use xli with pixDisplay()
        /// </summary>
        L_DISPLAY_WITH_XLI = 2,
        /// <summary>
        /// Use xv with pixDisplay()  
        /// </summary>
        L_DISPLAY_WITH_XV = 3,
        /// <summary>
        /// Use irfvanview (win) with pixDisplay() 
        /// </summary>
        L_DISPLAY_WITH_IV = 4,
        /// <summary>
        /// Use open (apple) with pixDisplay() 
        /// </summary>
        L_DISPLAY_WITH_OPEN = 5
    }
}
