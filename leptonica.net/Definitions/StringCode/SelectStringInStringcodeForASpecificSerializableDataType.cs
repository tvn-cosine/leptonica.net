namespace Leptonica 
{
    /// <summary>
    /// Select string in stringcode for a specific serializable data type
    /// </summary>
    public enum SelectStringInStringcodeForASpecificSerializableDataType
    {
        /// <summary>
        /// typedef for the data type 
        /// </summary>
        L_STR_TYPE = 0,
        /// <summary>
        /// name of the data type   
        /// </summary>
        L_STR_NAME = 1,
        /// <summary>
        /// reader to get the data type from file 
        /// </summary>
        L_STR_READER = 2,
        /// <summary>
        /// reader to get the compressed string in memory
        /// </summary>
        L_STR_MEMREADER = 3  
    }
}
