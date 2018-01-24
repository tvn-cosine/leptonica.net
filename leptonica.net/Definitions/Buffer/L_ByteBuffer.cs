using System;

namespace Leptonica
{
    /// <summary>
    /// Expandable byte buffer for memory read/write operations
    /// </summary>
    public class L_ByteBuffer : LeptonicaObjectBase
    {
        public L_ByteBuffer(IntPtr pointer) : base(pointer) { }
    }

    public class L_BBuffer : L_ByteBuffer
    {
        public L_BBuffer(IntPtr pointer) : base(pointer) { }
    }
}
