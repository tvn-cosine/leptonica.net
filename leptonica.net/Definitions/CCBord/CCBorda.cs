using System;

namespace Leptonica
{
    /// <summary>
    /// Array of CCBord
    /// </summary>
    public class CCBorda : LeptonicaObjectBase
    {
        public IntPtr Pointer { get; set; }

        public CCBorda(IntPtr pointer) : base(pointer)
        {
            Pointer = pointer;
        }
    }
}
