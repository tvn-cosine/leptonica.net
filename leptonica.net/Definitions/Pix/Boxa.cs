using System; 
using System.Collections.Generic;

namespace Leptonica
{
    /// <summary>
    /// Array of Box
    /// </summary>
    public class Boxa : LeptonicaObjectBase
    {
        public Boxa(IntPtr pointer) : base(pointer)
        {
        }

        public int Count { get { return this.boxaGetCount(); } }

        public List<Box> ToList()
        {
            var boxList = new List<Box>();
            for (int i = 0; i < Count; i++)
            {
                var box = this.boxaGetBox(i, (int)AccessAndStorageFlags.L_COPY);
                boxList.Add(box);
            }

            return boxList;
        }

        public override string ToString()
        {
            return $"Box Count: {Count}";
        }
    }
}
