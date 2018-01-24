using System;

namespace Leptonica 
{
    /// <summary>
    /// Expandable pointer stack for arbitrary void* data. Note that array[n] is the first null ptr in the array
    /// </summary>
    public class L_Stack : LeptonicaObjectBase
    {
        public L_Stack(IntPtr pointer) : base(pointer) { }
    }
}
