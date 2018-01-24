using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class GPLOT
    {
        // Basic plotting functions
        public static GPlot gplotCreate(string rootname, int outformat, string title, string xlabel, string ylabel)
        {
            var pointer = Native.DllImports.gplotCreate(rootname, outformat, title, xlabel, ylabel);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new GPlot(pointer);
            }
        }

        public static void gplotDestroy(this GPlot pgplot)
        {
            if (null == pgplot)
            {
                throw new ArgumentNullException("pgplot cannot be null");
            }

            var pointer = (IntPtr)pgplot;

            Native.DllImports.gplotDestroy(ref pointer);
        }

        public static int gplotAddPlot(this GPlot gplot, Numa nax, Numa nay, int plotstyle, string plottitle)
        {
            if (null == gplot
             || null == nay)
            {
                throw new ArgumentNullException("gplot, nay cannot be null");
            }

            return Native.DllImports.gplotAddPlot((HandleRef)gplot, (HandleRef)nax, (HandleRef)nay, plotstyle, plottitle);
        }

        public static int gplotSetScaling(this GPlot gplot, int scaling)
        {
            if (null == gplot)
            {
                throw new ArgumentNullException("gplot cannot be null");
            }

            return Native.DllImports.gplotSetScaling((HandleRef)gplot, scaling);
        }

        public static int gplotMakeOutput(this GPlot gplot)
        {
            if (null == gplot)
            {
                throw new ArgumentNullException("gplot cannot be null");
            }

            return Native.DllImports.gplotMakeOutput((HandleRef)gplot);
        }

        public static int gplotGenCommandFile(this GPlot gplot)
        {
            if (null == gplot)
            {
                throw new ArgumentNullException("gplot cannot be null");
            }

            return Native.DllImports.gplotGenCommandFile((HandleRef)gplot);
        }

        public static int gplotGenDataFiles(this GPlot gplot)
        {
            if (null == gplot)
            {
                throw new ArgumentNullException("gplot cannot be null");
            }

            return Native.DllImports.gplotGenDataFiles((HandleRef)gplot);
        }

        // Quick and dirty plots
        public static int gplotSimple1(this Numa na, int outformat, string outroot, string title)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            return Native.DllImports.gplotSimple1((HandleRef)na, outformat, outroot, title);
        }

        public static int gplotSimple2(this Numa na1, Numa na2, int outformat, string outroot, string title)
        {
            if (null == na1
             || null == na2)
            {
                throw new ArgumentNullException("na1, na2 cannot be null");
            }

            return Native.DllImports.gplotSimple2((HandleRef)na1, (HandleRef)na2, outformat, outroot, title);
        }

        public static int gplotSimpleN(this Numaa naa, int outformat, string outroot, string title)
        {
            if (null == naa)
            {
                throw new ArgumentNullException("naa cannot be null");
            }

            return Native.DllImports.gplotSimpleN((HandleRef)naa, outformat, outroot, title);
        }

        public static int gplotSimpleXY1(this Numa nax, Numa nay, int plotstyle, int outformat, string outroot, string title)
        {
            if (null == nay)
            {
                throw new ArgumentNullException("nay cannot be null");
            }

            return Native.DllImports.gplotSimpleXY1((HandleRef)nax, (HandleRef)nay, plotstyle, outformat, outroot, title);
        }

        public static int gplotSimpleXY2(this Numa nax, Numa nay1, Numa nay2, int plotstyle, int outformat, string outroot, string title)
        {
            if (null == nay1
             || null == nay2)
            {
                throw new ArgumentNullException("nay1, nay2 cannot be null");
            }

            return Native.DllImports.gplotSimpleXY2((HandleRef)nax, (HandleRef)nay1, (HandleRef)nay2, plotstyle, outformat, outroot, title);
        }

        public static int gplotSimpleXYN(this Numa nax, Numaa naay, int plotstyle, int outformat, string outroot, string title)
        {
            if (null == naay)
            {
                throw new ArgumentNullException("naay cannot be null");
            }

            return Native.DllImports.gplotSimpleXYN((HandleRef)nax, (HandleRef)naay, plotstyle, outformat, outroot, title);
        }

        // Serialize for I/O
        public static GPlot gplotRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.gplotRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new GPlot(pointer);
            }
        }

        public static int gplotWrite(string filename, GPlot gplot) 
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == gplot)
            {
                throw new ArgumentNullException("gplot cannot be null");
            }

            return Native.DllImports.gplotWrite(filename, (HandleRef)gplot);
        }
    }
}
