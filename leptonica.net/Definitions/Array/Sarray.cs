using System; 

namespace Leptonica
{
    /// <summary>
    /// String array: an array of C strings
    /// </summary>
    public class Sarray : LeptonicaObjectBase
    {
        public Sarray(IntPtr pointer) : base(pointer) { }
    }
}
