using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Colormap of a Pix
    /// </summary>
    public class PixColormap : LeptonicaObjectBase
    {
        private HandleRef handle;

        public PixColormap(IntPtr pointer) : base(pointer) { }

        internal HandleRef Handle
        {
            get { return handle; }
        }

        public Color this[int index]
        {
            get
            {
                if (Native.DllImports.pixcmapGetColor32(handle, index, out int value) == 0)
                {
                    return Color.FromArgb(
                        (byte)(value & 0xFF),
                        (byte)((value >> 24) & 0xFF),
                        (byte)((value >> 16) & 0xFF),
                        (byte)((value >> 8) & 0xFF));
                }
                else
                    throw new InvalidOperationException("Failed to retrieve color.");
            }
            //set
            //{
            //    if (Native.DllImports.pixcmapResetColor(handle, index, value.Red, value.Green, value.Blue) != 0)
            //    {

            //    }
            //}
        }
    }
}
