using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// A base abstract definition for leptonica objects
    /// </summary>
    public abstract class LeptonicaObjectBase
    {
        /// <summary>
        /// The handle reference for the object
        /// </summary>
        private readonly HandleRef handleRef;

        /// <summary>
        /// Instantiating a base leptonica object
        /// </summary>
        /// <param name="pointer"></param>
        public LeptonicaObjectBase(IntPtr pointer)
        {
            handleRef = new HandleRef(this, pointer);
        }

        /// <summary>
        /// Convert to IntPtr
        /// </summary>
        /// <param name="obj">The object to convert</param>
        public static explicit operator IntPtr(LeptonicaObjectBase obj)
        {
            if (null == obj)
            {
                return IntPtr.Zero;
            }
            else
            {
                return obj.handleRef.Handle;
            }
        }

        /// <summary>
        /// Convert to HandleRef
        /// </summary>
        /// <param name="obj">The object to convert</param>
        public static explicit operator HandleRef(LeptonicaObjectBase obj)
        {
            if (null == obj)
            {
                return new HandleRef(null, IntPtr.Zero);
            }
            else
            {
                return obj.handleRef;
            }
        }
    }
}
