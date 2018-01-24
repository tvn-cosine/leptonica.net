using System; 

namespace Leptonica 
{
    /// <summary>
    /// hide underlying implementation for map
    /// </summary>
    public class L_AMap : L_Rbtree
    {
        public L_AMap(IntPtr pointer) : base(pointer) { }
    }
}
