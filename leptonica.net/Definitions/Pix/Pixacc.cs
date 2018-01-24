using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leptonica
{
    /// <summary>
    /// Pix accumulator container
    /// </summary>
    public class Pixacc : LeptonicaObjectBase
    {
        public Pixacc(IntPtr pointer) : base(pointer) { }
    }
}
