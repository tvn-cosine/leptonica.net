namespace Leptonica
{
    /// <summary>
    /// Scan direction flags
    /// </summary>
    public enum ScanDirectionFlags
    {
        /// <summary>
        /// scan from left     
        /// </summary>
        L_FROM_LEFT = 0,
        /// <summary>
        /// scan from right    
        /// </summary>
        L_FROM_RIGHT = 1,
        /// <summary>
        /// scan from top    
        /// </summary>
        L_FROM_TOP = 2,
        /// <summary>
        /// scan from bottom      
        /// </summary>
        L_FROM_BOT = 3,
        /// <summary>
        /// scan in negative direction    
        /// </summary>
        L_SCAN_NEGATIVE = 4,
        /// <summary>
        /// scan in positive direction    
        /// </summary>
        L_SCAN_POSITIVE = 5,
        /// <summary>
        /// scan in both directions 
        /// </summary>
        L_SCAN_BOTH = 6,
        /// <summary>
        /// horizontal scan (direction unimportant)
        /// </summary>
        L_SCAN_HORIZONTAL = 7,
        /// <summary>
        /// vertical scan (direction unimportant) 
        /// </summary>
        L_SCAN_VERTICAL = 8 
    }
}
