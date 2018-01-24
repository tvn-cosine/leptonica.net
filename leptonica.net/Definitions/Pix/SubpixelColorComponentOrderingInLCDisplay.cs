namespace Leptonica
{
    /// <summary>
    /// Subpixel color component ordering in LC display
    /// </summary>
    public enum SubpixelColorComponentOrderingInLCDisplay
    {
        /// <summary>
        /// sensor order left-to-right RGB  
        /// </summary>
        L_SUBPIXEL_ORDER_RGB = 1,
        /// <summary>
        /// sensor order left-to-right BGR   
        /// </summary>
        L_SUBPIXEL_ORDER_BGR = 2,
        /// <summary>
        /// sensor order top-to-bottom RGB  
        /// </summary>
        L_SUBPIXEL_ORDER_VRGB = 3,
        /// <summary>
        /// sensor order top-to-bottom BGR 
        /// </summary>
        L_SUBPIXEL_ORDER_VBGR = 4
    }
}
