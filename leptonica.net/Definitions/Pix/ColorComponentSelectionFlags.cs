namespace Leptonica
{
    /// <summary>
    /// Color component selection flags
    /// </summary>
    public enum ColorComponentSelectionFlags
    {
        /// <summary>
        /// use red component 
        /// </summary>
        L_SELECT_RED = 1,
        /// <summary>
        /// use green component  
        /// </summary>
        L_SELECT_GREEN = 2,
        /// <summary>
        /// use blue component 
        /// </summary>
        L_SELECT_BLUE = 3,
        /// <summary>
        /// use min color component  
        /// </summary>
        L_SELECT_MIN = 4,
        /// <summary>
        /// use max color component 
        /// </summary>
        L_SELECT_MAX = 5,
        /// <summary>
        /// use average of color components 
        /// </summary>
        L_SELECT_AVERAGE = 6,
        /// <summary>
        /// use hue value (in HSV color space) 
        /// </summary>
        L_SELECT_HUE = 7,
        /// <summary>
        /// use saturation value (in HSV space)  
        /// </summary>
        L_SELECT_SATURATION = 8  
    }
}
