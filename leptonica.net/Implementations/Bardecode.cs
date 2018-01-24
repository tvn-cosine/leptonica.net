using System;

namespace Leptonica
{
    public static class Bardecode
    {
        // Dispatcher 
        public static IntPtr barcodeDispatchDecoder(string barstr, int format, int debugflag)
        {
            return Native.DllImports.barcodeDispatchDecoder(barstr, format, debugflag);
        }

        // Format Determination 
        public static int barcodeFormatIsSupported(int format)
        {
            return Native.DllImports.barcodeFormatIsSupported(format);
        }
    }
}
