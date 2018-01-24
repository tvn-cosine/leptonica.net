using System;

namespace Leptonica
{
    /// <summary>
    /// Data structure to hold accumulating generated code for storing
    /// and extracing serializable leptonica objects (e.g., pixa, recog).
    /// </summary>
    public class L_StrCode : LeptonicaObjectBase
    {
        public L_StrCode(IntPtr pointer) : base(pointer) { }
    } 
}
