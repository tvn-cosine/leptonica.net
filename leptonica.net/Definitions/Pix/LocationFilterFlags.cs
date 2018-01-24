namespace Leptonica
{
    public enum LocationFilterFlags
    {
        /// <summary>
        /// width must satisfy constraint
        /// </summary>
        L_SELECT_WIDTH = 1,
        /// <summary>
        /// height must satisfy constraint   
        /// </summary>
        L_SELECT_HEIGHT = 2,
        /// <summary>
        /// x value satisfy constraint 
        /// </summary>
        L_SELECT_XVAL = 3,
        /// <summary>
        /// y value must satisfy constraint 
        /// </summary>
        L_SELECT_YVAL = 4,
        /// <summary>
        /// either width or height (or xval or yval) can satisfy 
        /// </summary>
        L_SELECT_IF_EITHER = 5,
        /// <summary>
        /// both width and height (or xval and yval must satisfy
        /// </summary>
        L_SELECT_IF_BOTH = 6 
    }
}
