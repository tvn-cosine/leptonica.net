using System;

namespace Leptonica 
{
    /// <summary>
    /// The JbData struct holds all the data required for the compressed jbig-type representation of a set of images.
    /// </summary>
    public class JbData : LeptonicaObjectBase
    {
        public JbData(IntPtr pointer) : base(pointer) { }
    } 
}
