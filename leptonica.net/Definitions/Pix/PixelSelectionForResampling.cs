namespace Leptonica
{
    /// <summary>
    /// Pixel selection for resampling
    /// </summary>
    public enum PixelSelectionForResampling
    {
        /// <summary>
        /// linear interpolation from src pixels 
        /// </summary>
        L_INTERPOLATED = 1,
        /// <summary>
        /// nearest src pixel sampling only    
        /// </summary>
        L_SAMPLED = 2
    }
}
