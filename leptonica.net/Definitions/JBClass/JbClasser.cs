using System;

namespace Leptonica 
{
    /// <summary>
    /// The JbClasser struct holds all the data accumulated during the classification process that can be used for a compressed jbig2-type representation of a set of images. 
    /// </summary>
    public class JbClasser : LeptonicaObjectBase
    {
        public JbClasser(IntPtr pointer) : base(pointer) { }
    }
}
