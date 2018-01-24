using System;

namespace Leptonica
{
    public static class ArrayAccess
    {
        // Access within an array of 32-bit words 
        public static int l_getDataBit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataBit(line, n);
        }

        public static void l_setDataBit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataBit(line, n);
        }

        public static void l_clearDataBit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_clearDataBit(line, n);
        }

        public static void l_setDataBitVal(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataBitVal(line, n, val);
        }

        public static int l_getDataDibit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataDibit(line, n);
        }

        public static void l_setDataDibit(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataDibit(line, n, val);
        }

        public static void l_clearDataDibit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_clearDataDibit(line, n);
        }

        public static int l_getDataQbit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataQbit(line, n);
        }

        public static void l_setDataQbit(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataQbit(line, n, val);
        }

        public static void l_clearDataQbit(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_clearDataQbit(line, n);
        }

        public static int l_getDataByte(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataByte(line, n);
        }

        public static void l_setDataByte(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataByte(line, n, val);
        }

        public static int l_getDataTwoBytes(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataTwoBytes(line, n);
        }

        public static void l_setDataTwoBytes(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataTwoBytes(line, n, val);
        }

        public static int l_getDataFourBytes(IntPtr line, int n)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            return Native.DllImports.l_getDataFourBytes(line, n);
        }

        public static void l_setDataFourBytes(IntPtr line, int n, int val)
        {
            if (IntPtr.Zero == line)
            {
                throw new ArgumentNullException("line cannot be null.");
            }

            Native.DllImports.l_setDataFourBytes(line, n, val);
        }
    }
}
