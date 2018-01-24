using System;

namespace Leptonica
{
    /// <summary>
    /// Heap of arbitrary void* data
    /// </summary>
    public class L_Heap : LeptonicaObjectBase
    {
        public L_Heap(IntPtr pointer) : base(pointer) { }
    }
}
