using System;

namespace Leptonica 
{
    /// <summary>
    /// This data structure is used for pixOctreeColorQuant(),a color octree that adjusts to the color distribution in the image that is being quantized.  The best settings are with CQ_NLEVELS = 6 and DITHERING set on.
    /// </summary>
    public class ColorQuantCell : LeptonicaObjectBase
    {
        public ColorQuantCell(IntPtr pointer) : base(pointer) { }
    }
}
