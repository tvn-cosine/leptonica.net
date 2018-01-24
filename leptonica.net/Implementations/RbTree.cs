using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RbTree
    {
        // Interface to red-black tree
        public static L_Rbtree l_rbtreeCreate(int keytype)
        {
            throw new NotImplementedException();
        }

        public static Rb_Type l_rbtreeLookup(this L_Rbtree t, Rb_Type key)
        {
            throw new NotImplementedException();
        }

        public static void l_rbtreeInsert(this L_Rbtree t, Rb_Type key, Rb_Type value)
        {
            throw new NotImplementedException();
        }

        public static void l_rbtreeDelete(this L_Rbtree t, Rb_Type key)
        {
            throw new NotImplementedException();
        }

        public static void l_rbtreeDestroy(this L_Rbtree pt)
        {
            throw new NotImplementedException();
        }

        public static L_Rbtree_Node l_rbtreeGetFirst(this L_Rbtree t)
        {
            throw new NotImplementedException();
        }

        public static L_Rbtree_Node l_rbtreeGetNext(this L_Rbtree_Node n)
        {
            throw new NotImplementedException();
        }

        public static L_Rbtree_Node l_rbtreeGetLast(this L_Rbtree t)
        {
            throw new NotImplementedException();
        }

        public static L_Rbtree_Node l_rbtreeGetPrev(this L_Rbtree_Node n)
        {
            throw new NotImplementedException();
        }

        public static int l_rbtreeGetCount(this L_Rbtree t)
        {
            throw new NotImplementedException();
        }

        public static void l_rbtreePrint(IntPtr fp, L_Rbtree t)
        {
            throw new NotImplementedException();
        } 
    }
}
