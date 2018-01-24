using System; 

namespace Leptonica
{
    /// <summary>
    /// Byte array (analogous to C++ "string")
    /// </summary>
    public class L_Bytea : LeptonicaObjectBase
    {
        public L_Bytea(IntPtr pointer) : base(pointer) { }
    }
}
