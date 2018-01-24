namespace Leptonica
{
    /// <summary>
    /// Sort type flags
    /// </summary>
    public enum SortTypeFlags
    {
        /// <summary>
        /// sort box or c.c. by left edge location
        /// </summary>
        L_SORT_BY_X = 1,
        /// <summary>
        /// sort box or c.c. by top edge location 
        /// </summary>
        L_SORT_BY_Y = 2,
        /// <summary>
        /// sort box or c.c. by right edge location
        /// </summary>
        L_SORT_BY_RIGHT = 3,
        /// <summary>
        /// sort box or c.c. by bot edge location
        /// </summary>
        L_SORT_BY_BOT = 4,
        /// <summary>
        /// sort box or c.c. by width   
        /// </summary>
        L_SORT_BY_WIDTH = 5,
        /// <summary>
        /// sort box or c.c. by height   
        /// </summary>
        L_SORT_BY_HEIGHT = 6,
        /// <summary>
        /// sort box or c.c. by min dimension  
        /// </summary>
        L_SORT_BY_MIN_DIMENSION = 7,
        /// <summary>
        /// sort box or c.c. by max dimension   
        /// </summary>
        L_SORT_BY_MAX_DIMENSION = 8,
        /// <summary>
        /// sort box or c.c. by perimeter      
        /// </summary>
        L_SORT_BY_PERIMETER = 9,
        /// <summary>
        /// sort box or c.c. by area  
        /// </summary>
        L_SORT_BY_AREA = 10,
        /// <summary>
        /// sort box or c.c. by width/height ratio 
        /// </summary>
        L_SORT_BY_ASPECT_RATIO = 11 
    }
}
