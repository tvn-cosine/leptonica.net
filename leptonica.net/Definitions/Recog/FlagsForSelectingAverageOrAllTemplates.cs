namespace Leptonica 
{
    /// <summary>
    /// Flags for selecting average or all templates: recog->templ_use
    /// </summary>
    public enum FlagsForSelectingAverageOrAllTemplates
    {
        /// <summary>
        /// use all templates; default 
        /// </summary>
        L_USE_ALL_TEMPLATES = 0,
        /// <summary>
        /// use average templates; special cases 
        /// </summary>  
        L_USE_AVERAGE_TEMPLATES = 1
    }
}
