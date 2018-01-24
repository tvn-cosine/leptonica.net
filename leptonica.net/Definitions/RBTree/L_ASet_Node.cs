using System; 

namespace Leptonica 
{
    /// <summary>
    /// hide underlying implementation for set
    /// </summary>
    public class L_ASet_Node : L_Rbtree_Node
    {
        public L_ASet_Node(IntPtr pointer) : base(pointer) { }
    }
}
