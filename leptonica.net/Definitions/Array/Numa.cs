using System;
using System.Collections.Generic;

namespace Leptonica
{
    /// <summary>
    /// Number array: an array of floats
    /// </summary>
    public class Numa : LeptonicaObjectBase
    {
        public Numa(IntPtr pointer) : base(pointer) { }

        public int Count
        {
            get
            {
                return this.numaGetCount();
            }
        }

        public List<float> ToListFloat()
        {
            var floatList = new List<float>();
            for (int i = 0; i < Count; i++)
            {
                this.numaGetFValue(i, out float val);
                floatList.Add(val);
            }

            return floatList;
        }

        public List<int> ToListInt()
        {
            var intList = new List<int>();
            for (int i = 0; i < Count; i++)
            {
                this.numaGetIValue(i, out int val);
                intList.Add(val);
            }

            return intList;
        }

        public override string ToString()
        {
            return $"Count: {Count}";
        }
    }
}
