namespace Leptonica
{
    /// <summary>
    /// Text orientation flags
    /// </summary>
    public enum TextOrientationFlags
    {
        /// <summary>
        /// low confidence on text orientation  
        /// </summary>
        L_TEXT_ORIENT_UNKNOWN = 0,
        /// <summary>
        /// portrait, text rightside-up  
        /// </summary>
        L_TEXT_ORIENT_UP = 1,
        /// <summary>
        /// landscape, text up to left    
        /// </summary>
        L_TEXT_ORIENT_LEFT = 2,
        /// <summary>
        /// portrait, text upside-down  
        /// </summary>
        L_TEXT_ORIENT_DOWN = 3,
        /// <summary>
        /// landscape, text up to right   
        /// </summary>
        L_TEXT_ORIENT_RIGHT = 4    
    }
}
