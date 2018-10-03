namespace Leptonica
{
    /// <summary>
    /// Access and storage flags
    /// </summary>
    public enum AccessAndStorageFlags
    {
        /// <summary>
        /// do not copy the object; do not delete the ptr
        /// </summary>
        L_NOCOPY = 0,

        /// <summary>
        /// stuff it in; no copy or clone
        /// </summary>
        L_INSERT = 0,

        /// <summary>
        /// make/use a copy of the object 
        /// </summary>
        L_COPY = 1,

        /// <summary>
        ///  make/use clone (ref count) of the object
        /// </summary>
        L_CLONE = 2,

        /// <summary>
        /// make a new object and fill each object in the array(s) with clones     
        /// </summary>
        L_COPY_CLONE = 3   
    }
}
