using System; 

namespace Leptonica
{
    /// <summary>
    /// Array of compressed pix
    /// </summary>
    public class PixaComp : LeptonicaObjectBase
    {
        public PixaComp(IntPtr pointer) : base(pointer) { }
        public int Count { get { return this.pixacompGetCount(); } }

    }
}
