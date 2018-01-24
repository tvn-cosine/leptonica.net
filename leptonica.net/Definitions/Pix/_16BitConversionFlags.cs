namespace Leptonica
{
    /// <summary>
    /// 16-bit conversion flags
    /// </summary>
    public enum _16BitConversionFlags
    {
        /// <summary>
        /// use LSB 
        /// </summary>
        L_LS_BYTE = 1,
        /// <summary>
        /// use MSB   
        /// </summary>
        L_MS_BYTE = 2,
        /// <summary>
        /// use LSB if max(val) &lt; 256; else MSB
        /// </summary>
        L_AUTO_BYTE = 3,
        /// <summary>
        /// use max(val, 255)    
        /// </summary>
        L_CLIP_TO_FF = 4,
        /// <summary>
        /// use two LSB   
        /// </summary>
        L_LS_TWO_BYTES = 5,
        /// <summary>
        /// use two MSB         
        /// </summary>
        L_MS_TWO_BYTES = 6,
        /// <summary>
        /// use max(val, 65535)    
        /// </summary>
        L_CLIP_TO_FFFF = 7 
    }
}
