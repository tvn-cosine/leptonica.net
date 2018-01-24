using System;

namespace Leptonica
{
    /// <summary>
    /// Generic pointer array
    /// </summary>
    public class L_Ptra : LeptonicaObjectBase
    {
        public L_Ptra(IntPtr pointer) : base(pointer) { }
    }  
}
