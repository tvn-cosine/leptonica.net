namespace Leptonica
{
    /// <summary>
    /// Blend flags
    /// </summary>
    public enum BendFlags
    {
        /// <summary>
        /// add some of src inverse to itself 
        /// </summary>
        L_BLEND_WITH_INVERSE = 1,
        /// <summary>
        /// shift src colors towards white  
        /// </summary>
        L_BLEND_TO_WHITE = 2,
        /// <summary>
        /// shift src colors towards black 
        /// </summary>
        L_BLEND_TO_BLACK = 3,
        /// <summary>
        /// blend src directly with blender 
        /// </summary>
        L_BLEND_GRAY = 4,
        /// <summary>
        /// add amount of src inverse to itself, based on blender pix value 
        /// </summary>
        L_BLEND_GRAY_WITH_INVERSE = 5 
    }
}
