using System; 

namespace Leptonica 
{
    /// <summary>
    /// The struct FillSeg is used by the Heckbert seedfill algorithm to hold information about image segments that are waiting to be
    /// investigated.  We use two Stacks, one to hold the FillSegs in use, and an auxiliary Stack as a reservoir to hold FillSegs for re-use.
    /// </summary>
    public class FillSeg : LeptonicaObjectBase
    {
        public FillSeg(IntPtr pointer) : base(pointer) { }
    }
}
