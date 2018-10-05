using System;
using System.Collections.Generic;

namespace Leptonica
{
    /// <summary>
    /// Array of pix
    /// </summary>
    public class Pixa : LeptonicaObjectBase
    {
        public Pixa(IntPtr pointer) : base(pointer)
        {
        }

        public int Count
        {
            get
            {
                return this.pixaGetCount();
            }
        }

        public List<Pix> ToList()
        {
            var pixList = new List<Pix>();
            for (int i = 0; i < Count; i++)
            {
                var pix = this.pixaGetPix(i, AccessAndStorageFlags.L_COPY);
                pixList.Add(pix);
            }

            return pixList;
        }

        public override string ToString()
        {
            return $"Pix Count: {Count}";
        }
    }
}
