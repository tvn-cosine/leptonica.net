using System; 

namespace Leptonica 
{
    /// <summary>
    /// hide underlying implementation for set
    /// </summary>
    public class L_ASet : L_Rbtree
    {
        public L_ASet(IntPtr pointer) : base(pointer) { }
    }
}
