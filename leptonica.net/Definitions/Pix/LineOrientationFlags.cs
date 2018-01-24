namespace Leptonica
{
    /// <summary>
    /// Line orientation flags
    /// </summary>
    public enum LineOrientationFlags
    {
        /// <summary>
        /// horizontal line 
        /// </summary>
        L_HORIZONTAL_LINE = 0,
        /// <summary>
        /// 45 degree line with positive slope 
        /// </summary>
        L_POS_SLOPE_LINE = 1,
        /// <summary>
        /// vertical line 
        /// </summary>
        L_VERTICAL_LINE = 2,
        /// <summary>
        /// 45 degree line with negative slope  
        /// </summary>
        L_NEG_SLOPE_LINE = 3,
        /// <summary>
        /// neither horizontal nor vertical
        /// </summary>
        L_OBLIQUE_LINE = 4   
    }
}
