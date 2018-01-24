namespace Leptonica
{ 
    /// <summary>
    /// Flags for adding text to a Pix
    /// </summary>
    public enum FlagsForAddingTextToAPix
    {
        /// <summary>
        /// Add text above the image 
        /// </summary>
        L_ADD_ABOVE = 1,
        /// <summary>
        /// Add text below the image   
        /// </summary>
        L_ADD_BELOW = 2,
        /// <summary>
        /// Add text to the left of the image  
        /// </summary>
        L_ADD_LEFT = 3,
        /// <summary>
        /// Add text to the right of the image
        /// </summary>
        L_ADD_RIGHT = 4,
        /// <summary>
        /// Add text over the top of the image 
        /// </summary>
        L_ADD_AT_TOP = 5,
        /// <summary>
        /// Add text over the bottom of the image 
        /// </summary>
        L_ADD_AT_BOT = 6,
        /// <summary>
        /// Add text over left side of the image  
        /// </summary>
        L_ADD_AT_LEFT = 7,
        /// <summary>
        /// Add text over right side of the image 
        /// </summary>
        L_ADD_AT_RIGHT = 8
    }
}
