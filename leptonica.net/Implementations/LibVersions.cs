using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class LibVersions
    {
        public static string getImagelibVersions()
        {
            var pointer = Native.DllImports.getImagelibVersions();
            return Marshal.PtrToStringAnsi(pointer);
        }
    }
}
