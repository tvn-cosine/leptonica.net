namespace Leptonica
{
    /// <summary>
    /// Flags for colormap conversion 
    /// </summary>
    public enum FlagsForColormapConversion
    {
        /// <summary>
        /// remove colormap for conv to 1 bpp
        /// </summary>
        REMOVE_CMAP_TO_BINARY = 0,
        /// <summary>
        /// remove colormap for conv to 8 bpp
        /// </summary>
        REMOVE_CMAP_TO_GRAYSCALE = 1,
        /// <summary>
        /// remove colormap for conv to 32 bpp
        /// </summary>
        REMOVE_CMAP_TO_FULL_COLOR = 2,
        /// <summary>
        /// remove colormap and alpha 
        /// </summary>
        REMOVE_CMAP_WITH_ALPHA = 3,
        /// <summary>
        /// remove depending on src format
        /// </summary>
        REMOVE_CMAP_BASED_ON_SRC = 4 
    }
}
