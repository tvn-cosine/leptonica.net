using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Kernel
    {
        // Create/destroy/copy
        public static L_Kernel kernelCreate(int height, int width)
        {
            var pointer = Native.DllImports.kernelCreate(width, height);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static void kernelDestroy(this L_Kernel pkel)
        {
            if (null == pkel)
            {
                throw new ArgumentNullException("pkel cannot be null");
            }

            var pointer = (IntPtr)pkel;

            Native.DllImports.kernelDestroy(ref pointer);
        }

        public static L_Kernel kernelCopy(this L_Kernel kels)
        {
            if (null == kels)
            {
                throw new ArgumentNullException("kels cannot be null.");
            }

            var pointer = Native.DllImports.kernelCopy((HandleRef)kels);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        // Accessors:
        public static int kernelGetElement(this L_Kernel kel, int row, int col, out float pval)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelGetElement((HandleRef)kel, row, col, out pval);
        }

        public static int kernelSetElement(this L_Kernel kel, int row, int col, float val)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelSetElement((HandleRef)kel, row, col, val);
        }

        public static int kernelGetParameters(this L_Kernel kel, out int psy, out int psx, out int pcy, out int pcx)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelGetParameters((HandleRef)kel, out psy, out psx, out pcy, out pcx);
        }

        public static int kernelSetOrigin(this L_Kernel kel, int cy, int cx)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelSetOrigin((HandleRef)kel, cy, cx);
        }

        public static int kernelGetSum(this L_Kernel kel, out float psum)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelGetSum((HandleRef)kel, out psum);
        }

        public static int kernelGetMinMax(this L_Kernel kel, out float pmin, out float pmax)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelGetMinMax((HandleRef)kel, out pmin, out pmax);
        }

        // Normalize/invert
        public static L_Kernel kernelNormalize(this L_Kernel kels, float normsum)
        {
            if (null == kels)
            {
                throw new ArgumentNullException("kels cannot be null.");
            }

            var pointer = Native.DllImports.kernelNormalize((HandleRef)kels, normsum);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static L_Kernel kernelInvert(this L_Kernel kels)
        {
            if (null == kels)
            {
                throw new ArgumentNullException("kels cannot be null.");
            }

            var pointer = Native.DllImports.kernelInvert((HandleRef)kels);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        // Helper function
        public static IntPtr create2dFloatArray(int sy, int sx)
        {
            return Native.DllImports.create2dFloatArray(sy, sx);
        }

        // Serialized I/O
        public static L_Kernel kernelRead(string fname)
        {
            var pointer = Native.DllImports.kernelRead(fname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static L_Kernel kernelReadStream(IntPtr fp)
        {
            var pointer = Native.DllImports.kernelReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static int kernelWrite(string fname, L_Kernel kel)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelWrite(fname, (HandleRef)kel);
        }

        public static int kernelWriteStream(IntPtr fp, L_Kernel kel)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            return Native.DllImports.kernelWriteStream(fp, (HandleRef)kel);
        }

        //  Making a kernel from a compiled string
        public static L_Kernel kernelCreateFromString(int h, int w, int cy, int cx, string kdata)
        {
            var pointer = Native.DllImports.kernelCreateFromString(h, w, cy, cx, kdata);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        // Making a kernel from a simple file format
        public static L_Kernel kernelCreateFromFile(string filename)
        {
            var pointer = Native.DllImports.kernelCreateFromFile(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        // Making a kernel from a Pix
        public static L_Kernel kernelCreateFromPix(Pix pix, int cy, int cx)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null.");
            }

            var pointer = Native.DllImports.kernelCreateFromPix((HandleRef)pix, cy, cx);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        // Display a kernel in a pix
        public static Pix kernelDisplayInPix(this L_Kernel kel, int size, int gthick)
        {
            if (null == kel)
            {
                throw new ArgumentNullException("kel cannot be null.");
            }

            var pointer = Native.DllImports.kernelDisplayInPix((HandleRef)kel, size, gthick);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
         
        // Parse string to extract numbers
        public static Numa parseStringForNumbers(string str, string seps)
        {
            var pointer = Native.DllImports.parseStringForNumbers(str, seps);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Simple parametric kernels
        public static L_Kernel makeFlatKernel(int height, int width, int cy, int cx)
        {
            var pointer = Native.DllImports.makeFlatKernel(height, width, cy, cx);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static L_Kernel makeGaussianKernel(int halfheight, int halfwidth, float stdev, float max)
        {
            var pointer = Native.DllImports.makeGaussianKernel(halfheight, halfwidth, stdev, max);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }

        public static int makeGaussianKernelSep(int halfheight, int halfwidth, float stdev, float max, out L_Kernel pkelx, out L_Kernel pkely)
        {
            IntPtr pkelxPtr, pkelyPtr;
            var result = Native.DllImports.makeGaussianKernelSep(halfheight, halfwidth, stdev, max, out pkelxPtr, out pkelyPtr);
            pkelx = new L_Kernel(pkelxPtr);
            pkely = new L_Kernel(pkelyPtr);

            return result;
        }

        public static L_Kernel makeDoGKernel(int halfheight, int halfwidth, float stdev, float ratio)
        {
            var pointer = Native.DllImports.makeDoGKernel(halfheight, halfwidth, stdev, ratio);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Kernel(pointer);
            }
        }
    }
}
