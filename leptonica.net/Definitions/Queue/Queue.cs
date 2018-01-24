using System;

namespace Leptonica
{
    /// <summary>
    /// Expandable pointer queue for arbitrary void* data
    /// </summary>
    public class L_Queue : LeptonicaObjectBase
    {
        public L_Queue(IntPtr pointer) : base(pointer) { }
    }
}
