namespace Leptonica
{
    /// <summary>
    /// Size filter flags
    /// </summary>
    public enum SizeFilterFlags
    {
        /// <summary>
        /// save if value is less than threshold
        /// </summary>
        L_SELECT_IF_LT = 1,
        /// <summary>
        /// save if value is more than threshold
        /// </summary>
        L_SELECT_IF_GT = 2,
        /// <summary>
        /// save if value is &lt;= to the threshold
        /// </summary>
        L_SELECT_IF_LTE = 3,
        /// <summary>
        /// save if value is &gt;= to the threshold
        /// </summary>
        L_SELECT_IF_GTE = 4  
    }
}
