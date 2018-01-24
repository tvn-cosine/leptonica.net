using System;

namespace Leptonica 
{
    /// <summary>
    /// This data structure is used for pixOctreeQuantNumColors(),
    /// a color octree that adjusts in a simple way to the to the color
    /// distribution in the image that is being quantized.It outputs
    /// colormapped images, either 4 bpp or 8 bpp, depending on the
    /// max number of colors and the compression desired.
    /// </summary>
    public class OctcubeQuantCell : LeptonicaObjectBase
    {
        public OctcubeQuantCell(IntPtr pointer) : base(pointer) { }
    }
}
