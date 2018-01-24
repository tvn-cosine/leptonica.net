namespace Leptonica.Enums
{
    /// <summary>
    /// Box size adjustment and location flags
    /// </summary>
    public enum BoxSizeAdjustmentAndLocationFlags
    {
        /// <summary>
        /// do not adjust     
        /// </summary>
        L_ADJUST_SKIP = 0,
        /// <summary>
        /// adjust left edge  
        /// </summary>
        L_ADJUST_LEFT = 1,
        /// <summary>
        /// adjust right edge    
        /// </summary>
        L_ADJUST_RIGHT = 2,
        /// <summary>
        /// adjust both left and right edges 
        /// </summary>
        L_ADJUST_LEFT_AND_RIGHT = 3,
        /// <summary>
        /// adjust top edge  
        /// </summary>
        L_ADJUST_TOP = 4,
        /// <summary>
        /// adjust bottom edge      
        /// </summary>
        L_ADJUST_BOT = 5,
        /// <summary>
        /// adjust both top and bottom edges 
        /// </summary>
        L_ADJUST_TOP_AND_BOT = 6,
        /// <summary>
        /// choose the min median value 
        /// </summary>
        L_ADJUST_CHOOSE_MIN = 7,
        /// <summary>
        /// choose the max median value   
        /// </summary>
        L_ADJUST_CHOOSE_MAX = 8,
        /// <summary>
        /// set left side to a given value  
        /// </summary>
        L_SET_LEFT = 9,
        /// <summary>
        /// set right side to a given value 
        /// </summary>
        L_SET_RIGHT = 10,
        /// <summary>
        /// set top side to a given value   
        /// </summary>
        L_SET_TOP = 11,
        /// <summary>
        /// set bottom side to a given value   
        /// </summary>
        L_SET_BOT = 12,
        /// <summary>
        /// get left side location     
        /// </summary>
        L_GET_LEFT = 13,
        /// <summary>
        /// get right side location  
        /// </summary>
        L_GET_RIGHT = 14,
        /// <summary>
        /// get top side location   
        /// </summary>
        L_GET_TOP = 15,
        /// <summary>
        /// get bottom side location 
        /// </summary>
        L_GET_BOT = 16
    } 
}
