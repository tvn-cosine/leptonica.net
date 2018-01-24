namespace Leptonica
{
    /// <summary>
    /// Handling overlapping bounding boxes in Boxa
    /// </summary>
    public enum HandlingOverlappingBoundingBoxesInBoxa
    {
        /// <summary>
        /// resize to bounding region; remove smaller
        /// </summary>
        L_COMBINE = 1,
        /// <summary>
        /// only remove smaller  
        /// </summary>
        L_REMOVE_SMALL = 2
    }
}
