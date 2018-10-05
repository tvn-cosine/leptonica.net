using System;

namespace Leptonica
{
    /// <summary>
    /// String array: an array of C strings
    /// </summary>
    public class Sarray : LeptonicaObjectBase
    {
        public Sarray(IntPtr pointer) : base(pointer)
        {
        }

        public int Count
        {
            get
            {
                return Sarray1.sarrayGetCount(this);
            }
        }

        public int RefCount
        {
            get
            {
                return Sarray1.sarrayGetRefcount(this);
            }
        }
    }
}
