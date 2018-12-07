using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Byte array (analogous to C++ "string")
    /// </summary>
    public class L_Bytea : LeptonicaObjectBase
    {
        public IntPtr Pointer { get; private set; }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private L_Bytea_Members mems = new L_Bytea_Members();

        [StructLayout(LayoutKind.Sequential)]
        private class L_Bytea_Members
        {
            public int nalloc;
            public int size;
            public int refcount;
            public IntPtr data;
        }

        public L_Bytea(IntPtr pointer) : base(pointer)
        {
            if (pointer != IntPtr.Zero)
                Pointer = pointer;
            Marshal.PtrToStructure(Pointer, mems);
        }

        public L_Bytea(byte[] data) : base(IntPtr.Zero)
        {
            L_Bytea ba = ByteArray.l_byteaInitFromMem(data, data.Length);
            Pointer = ba.Pointer;
        }

        public L_Bytea(int bytes) : base (IntPtr.Zero)
        {
            var ba = ByteArray.l_byteaCreate(bytes);
            Pointer = ba.Pointer;
        }

        public IntPtr GetDataAsPointer()
        {
            var psize = 0;
            return this.l_byteaGetData(ref psize);
        }

        public int Nalloc
        {
            get
            {
                if (Pointer == IntPtr.Zero)
                    return 0;
                else
                {
                    Marshal.PtrToStructure(Pointer, mems);
                    return mems.nalloc;
                }
            }
        }

        public int Size
        {
            get
            {
                if (Pointer == IntPtr.Zero)
                    return 0;
                else
                {
                    Marshal.PtrToStructure(Pointer, mems);
                    return mems.size;
                }
            }
        }

        public int RefCount
        {
            get
            {
                if (Pointer == IntPtr.Zero)
                    return 0;
                else
                {
                    Marshal.PtrToStructure(Pointer, mems);
                    return mems.refcount;
                }
            }
        }

        public Byte[] Data
        {
            get
            {
                if (Pointer == IntPtr.Zero)
                    return null;
                else
                {
                    Marshal.PtrToStructure(Pointer, mems);
                    if (mems.data != IntPtr.Zero)
                    {
                        var _data = new Byte[mems.size];
                        Marshal.Copy(mems.data, _data, 0, _data.Length);
                        return _data;
                    }
                    else
                        return null;
                }
            }
        }
    }
}
