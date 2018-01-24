namespace Leptonica
{
    /// <summary>
    /// Region flags (inclusion, exclusion)
    /// </summary>
    public enum RegionFlagsInclusionExclusion
    {
        /// <summary>
        /// Use hue-saturation histogram 
        /// </summary>
        L_INCLUDE_REGION = 1,
        /// <summary>
        /// Use hue-value histogram 
        /// </summary>
        L_EXCLUDE_REGION = 2
    }
}
