using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    /// <summary>
    /// Basic rectangle
    /// </summary>
    public class Box : LeptonicaObjectBase
    {
        public Box(IntPtr pointer) : base(pointer)
        {
            if (Native.DllImports.boxGetGeometry((HandleRef)this, out int x, out int y, out int w, out int h) == 0)
            {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
        }

        public int Width { get; }
        public int X { get; }
        public int Y { get; }
        public int Height { get; }

        public override string ToString()
        {
            return $"X: {X} Y: {Y} Width: {Width} Height: {Height}";
        }
    }
}
