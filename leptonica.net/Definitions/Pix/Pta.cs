using System; 

namespace Leptonica
{
    /// <summary>
    /// Array of points
    /// </summary>
    public class Pta : LeptonicaObjectBase
    {
        public Pta(IntPtr pointer) : base(pointer) { }

        public int Count { get { return this.ptaGetCount(); } }
    }
}
