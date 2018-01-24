namespace Leptonica
{ /// <summary>
  /// Flags for barcode formats
  /// </summary>
    public enum FlagsForBarcodeFormats
    {
        /// <summary>
        /// unknown format  
        /// </summary>
        L_BF_UNKNOWN = 0,
        /// <summary>
        /// try decoding with all known formats 
        /// </summary>
        L_BF_ANY = 1,
        /// <summary>
        /// decode with Code128 format  
        /// </summary>
        L_BF_CODE128 = 2,
        /// <summary>
        /// decode with EAN8 format   
        /// </summary>
        L_BF_EAN8 = 3,
        /// <summary>
        /// decode with EAN13 format   
        /// </summary>
        L_BF_EAN13 = 4,
        /// <summary>
        /// decode with Code 2 of 5 format    
        /// </summary>
        L_BF_CODE2OF5 = 5,
        /// <summary>
        /// decode with Interleaved 2 of 5 format  
        /// </summary>
        L_BF_CODEI2OF5 = 6,
        /// <summary>
        /// decode with Code39 format 
        /// </summary>
        L_BF_CODE39 = 7,
        /// <summary>
        /// decode with Code93 format 
        /// </summary>
        L_BF_CODE93 = 8,
        /// <summary>
        /// decode with Code93 format 
        /// </summary>
        L_BF_CODABAR = 9,
        /// <summary>
        /// decode with UPC A format 
        /// </summary>
        L_BF_UPCA = 10
    }
}
