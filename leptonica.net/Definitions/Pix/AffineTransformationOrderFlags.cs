namespace Leptonica
{
    /// <summary>
    /// Affine transform order flags  
    /// </summary>
    public enum AffineTransformationOrderFlags
    {
        /// <summary>
        /// translate, scale, rotate    
        /// </summary>
        L_TR_SC_RO = 1,
        /// <summary>
        /// scale, rotate, translate  
        /// </summary>
        L_SC_RO_TR = 2,
        /// <summary>
        /// rotate, translate, scale 
        /// </summary>
        L_RO_TR_SC = 3,
        /// <summary>
        /// translate, rotate, scale 
        /// </summary>
        L_TR_RO_SC = 4,
        /// <summary>
        /// rotate, scale, translate  
        /// </summary>
        L_RO_SC_TR = 5,
        /// <summary>
        /// scale, translate, rotate   
        /// </summary>
        L_SC_TR_RO = 6           
    }
}
