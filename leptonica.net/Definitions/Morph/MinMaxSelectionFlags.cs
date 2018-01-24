namespace Leptonica
{
    /// <summary>
    /// Min/max selection flags
    /// </summary>
    public enum MinMaxSelectionFlags
    {
        /// <summary>
        /// useful in a downscaling "erosion" 
        /// </summary>
        L_CHOOSE_MIN = 1,
        /// <summary>
        /// useful in a downscaling "dilation"
        /// </summary>
        L_CHOOSE_MAX = 2,
        /// <summary>
        /// useful in a downscaling contrast  
        /// </summary>
        L_CHOOSE_MAXDIFF = 3,
        /// <summary>
        /// use a modification of the min value  
        /// </summary>
        L_CHOOSE_MIN_BOOST = 4,
        /// <summary>
        /// use a modification of the max value  
        /// </summary>
        L_CHOOSE_MAX_BOOST = 5
    }
}
