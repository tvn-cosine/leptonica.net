using System; 

namespace Leptonica
{
    /// <summary>
    /// Colormap table entry (after the BMP version).
    /// Note that the BMP format stores the colormap table exactly
    /// as it appears here, with color samples being stored sequentially,
    /// in the order(b, g, r, a).
    /// </summary>
    public class RGBA_Quad : LeptonicaObjectBase
    {
        public RGBA_Quad(IntPtr pointer) : base(pointer) { }
    }
}
