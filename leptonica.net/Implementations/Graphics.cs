using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Graphics
    {
        // Pta generation for arbitrary shapes built with lines
        public static Pta generatePtaLine(int x1, int y1, int x2, int y2)
        {
            var pointer = Native.DllImports.generatePtaLine(x1, y1, x2, y2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaWideLine(int x1, int y1, int x2, int y2, int width)
        {
            var pointer = Native.DllImports.generatePtaWideLine(x1, y1, x2, y2, width);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaBox(this Box box, int width)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            var pointer = Native.DllImports.generatePtaBox((HandleRef)box, width);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaBoxa(this Boxa boxa, int width, int removedups)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.generatePtaBoxa((HandleRef)boxa, width, removedups);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaHashBox(this Box box, int spacing, int width, int orient, int outline)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            var pointer = Native.DllImports.generatePtaHashBox((HandleRef)box, spacing, width, orient, outline);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaHashBoxa(this Boxa boxa, int spacing, int width, int orient, int outline, int removedups)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.generatePtaHashBoxa((HandleRef)boxa, spacing, width, orient, outline, removedups);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Ptaa generatePtaaBoxa(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.generatePtaaBoxa((HandleRef)boxa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Ptaa(pointer);
            }
        }

        public static Ptaa generatePtaaHashBoxa(this Boxa boxa, int spacing, int width, int orient, int outline)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.generatePtaaHashBoxa((HandleRef)boxa, spacing, width, orient, outline);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Ptaa(pointer);
            }
        }

        public static Pta generatePtaPolyline(this Pta ptas, int width, int closeflag, int removedups)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.generatePtaPolyline((HandleRef)ptas, width, closeflag, removedups);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaGrid(int w, int h, int nx, int ny, int width)
        {
            var pointer = Native.DllImports.generatePtaGrid(w, h, nx, ny, width);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta convertPtaLineTo4cc(this Pta ptas)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.convertPtaLineTo4cc((HandleRef)ptas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaFilledCircle(int radius)
        {
            var pointer = Native.DllImports.generatePtaFilledCircle(radius);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaFilledSquare(int side)
        {
            var pointer = Native.DllImports.generatePtaFilledSquare(side);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static Pta generatePtaLineFromPt(int x, int y, double length, double radang)
        {
            var pointer = Native.DllImports.generatePtaLineFromPt(x, y, length, radang);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static int locatePtRadially(int xr, int yr, double dist, double radang, out double px, out double py)
        {
            return Native.DllImports.locatePtRadially(xr, yr, dist, radang, out px, out py);
        }

        // Rendering function plots directly on images
        public static int pixRenderPlotFromNuma(out Pix ppix, Numa na, int plotloc, int linewidth, int max, uint color)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            IntPtr ppixPtr;
            var result = Native.DllImports.pixRenderPlotFromNuma(out ppixPtr, (HandleRef)na, plotloc, linewidth, max, color);
            ppix = new Pix(ppixPtr);

            return result;
        }

        public static Pta makePlotPtaFromNuma(this Numa na, int size, int plotloc, int linewidth, int max)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            var pointer = Native.DllImports.makePlotPtaFromNuma((HandleRef)na, size, plotloc, linewidth, max);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static int pixRenderPlotFromNumaGen(out Pix ppix, Numa na, int orient, int linewidth, int refpos, int max, int drawref, uint color)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            IntPtr ppixPtr;
            var result = Native.DllImports.pixRenderPlotFromNumaGen(out ppixPtr, (HandleRef)na, orient, linewidth, refpos, max, drawref, color);
            ppix = new Pix(ppixPtr);

            return result;
        }

        public static Pta makePlotPtaFromNumaGen(this Numa na, int orient, int linewidth, int refpos, int max, int drawref)
        {
            if (null == na)
            {
                throw new ArgumentNullException("na cannot be null");
            }

            var pointer = Native.DllImports.makePlotPtaFromNumaGen((HandleRef)na, orient, linewidth, refpos, max, drawref);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        // Pta rendering
        public static int pixRenderPta(this Pix pix, Pta pta, int op)
        {
            if (null == pix
             || null == pta)
            {
                throw new ArgumentNullException("pix, pta cannot be null");
            }

            return Native.DllImports.pixRenderPta((HandleRef)pix, (HandleRef)pta, op);
        }

        public static int pixRenderPtaArb(this Pix pix, Pta pta, byte rval, byte gval, byte bval)
        {
            if (null == pix
             || null == pta)
            {
                throw new ArgumentNullException("pix, pta cannot be null");
            }

            return Native.DllImports.pixRenderPtaArb((HandleRef)pix, (HandleRef)pta, rval, gval, bval);
        }

        public static int pixRenderPtaBlend(this Pix pix, Pta pta, byte rval, byte gval, byte bval, float fract)
        {
            if (null == pix
             || null == pta)
            {
                throw new ArgumentNullException("pix, pta cannot be null");
            }

            return Native.DllImports.pixRenderPtaBlend((HandleRef)pix, (HandleRef)pta, rval, gval, bval, fract);
        }

        // Rendering of arbitrary shapes built with lines
        public static int pixRenderLine(this Pix pix, int x1, int y1, int x2, int y2, int width, int op)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixRenderLine((HandleRef)pix, x1, y1, x2, y2, width, op);
        }

        public static int pixRenderLineArb(this Pix pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixRenderLineArb((HandleRef)pix, x1, y1, x2, y2, width, rval, gval, bval);
        }

        public static int pixRenderLineBlend(this Pix pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval, float fract)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix cannot be null");
            }

            return Native.DllImports.pixRenderLineBlend((HandleRef)pix, x1, y1, x2, y2, width, rval, gval, bval, fract);
        }

        public static int pixRenderBox(this Pix pix, Box box, int width, int op)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderBox((HandleRef)pix, (HandleRef)box, width, op);
        }

        public static int pixRenderBoxArb(this Pix pix, Box box, int width, byte rval, byte gval, byte bval)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderBoxArb((HandleRef)pix, (HandleRef)box, width, rval, gval, bval);
        }

        public static int pixRenderBoxBlend(this Pix pix, Box box, int width, byte rval, byte gval, byte bval, float fract)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderBoxBlend((HandleRef)pix, (HandleRef)box, width, rval, gval, bval, fract);
        }

        public static int pixRenderBoxa(this Pix pix, Boxa boxa, int width, int op)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, boxa cannot be null");
            }

            return Native.DllImports.pixRenderBoxa((HandleRef)pix, (HandleRef)boxa, width, op);
        }

        public static int pixRenderBoxaArb(this Pix pix, Boxa boxa, int width, byte rval, byte gval, byte bval)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, boxa cannot be null");
            }

            return Native.DllImports.pixRenderBoxaArb((HandleRef)pix, (HandleRef)boxa, width, rval, gval, bval);
        }

        public static int pixRenderBoxaBlend(this Pix pix, Boxa boxa, int width, byte rval, byte gval, byte bval, float fract, int removedups)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, boxa cannot be null");
            }

            return Native.DllImports.pixRenderBoxaBlend((HandleRef)pix, (HandleRef)boxa, width, rval, gval, bval, fract, removedups);
        }

        public static int pixRenderHashBox(this Pix pix, Box box, int spacing, int width, int orient, int outline, int op)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderHashBox((HandleRef)pix, (HandleRef)box, spacing, width, orient, outline, op);
        }

        public static int pixRenderHashBoxArb(this Pix pix, Box box, int spacing, int width, int orient, int outline, int rval, int gval, int bval)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderHashBoxArb((HandleRef)pix, (HandleRef)box, spacing, width, orient, outline, rval, gval, bval);
        }

        public static int pixRenderHashBoxBlend(this Pix pix, Box box, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null");
            }

            return Native.DllImports.pixRenderHashBoxBlend((HandleRef)pix, (HandleRef)box, spacing, width, orient, outline, rval, gval, bval, fract);
        }

        public static int pixRenderHashMaskArb(this Pix pix, Pix pixm, int x, int y, int spacing, int width, int orient, int outline, int rval, int gval, int bval)
        {
            if (null == pix
             || null == pixm)
            {
                throw new ArgumentNullException("pix, pixm cannot be null");
            }

            return Native.DllImports.pixRenderHashMaskArb((HandleRef)pix, (HandleRef)pixm, x, y, spacing, width, orient, outline, rval, gval, bval);
        }

        public static int pixRenderHashBoxa(this Pix pix, Boxa boxa, int spacing, int width, int orient, int outline, int op)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, pixm cannot be null");
            }

            return Native.DllImports.pixRenderHashBoxa((HandleRef)pix, (HandleRef)boxa, spacing, width, orient, outline, op);
        }

        public static int pixRenderHashBoxaArb(this Pix pix, Boxa boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, boxa cannot be null");
            }

            return Native.DllImports.pixRenderHashBoxaArb((HandleRef)pix, (HandleRef)boxa, spacing, width, orient, outline, rval, gval, bval);
        }

        public static int pixRenderHashBoxaBlend(this Pix pix, Boxa boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract)
        {
            if (null == pix
             || null == boxa)
            {
                throw new ArgumentNullException("pix, boxa cannot be null");
            }

            return Native.DllImports.pixRenderHashBoxaBlend((HandleRef)pix, (HandleRef)boxa, spacing, width, orient, outline, rval, gval, bval, fract);
        }

        public static int pixRenderPolyline(this Pix pix, Pta ptas, int width, int op, int closeflag)
        {
            if (null == pix
             || null == ptas)
            {
                throw new ArgumentNullException("pix, ptas cannot be null");
            }

            return Native.DllImports.pixRenderPolyline((HandleRef)pix, (HandleRef)ptas, width, op, closeflag);
        }

        public static int pixRenderPolylineArb(this Pix pix, Pta ptas, int width, byte rval, byte gval, byte bval, int closeflag)
        {
            if (null == pix
             || null == ptas)
            {
                throw new ArgumentNullException("pix, ptas cannot be null");
            }

            return Native.DllImports.pixRenderPolylineArb((HandleRef)pix, (HandleRef)ptas, width, rval, gval, bval, closeflag);
        }

        public static int pixRenderPolylineBlend(this Pix pix, Pta ptas, int width, byte rval, byte gval, byte bval, float fract, int closeflag, int removedups)
        {
            if (null == pix
             || null == ptas)
            {
                throw new ArgumentNullException("pix, ptas cannot be null");
            }

            return Native.DllImports.pixRenderPolylineBlend((HandleRef)pix, (HandleRef)ptas, width, rval, gval, bval, fract, closeflag, removedups);
        }

        public static int pixRenderGridArb(this Pix pix, int nx, int ny, int width, byte rval, byte gval, byte bval)
        {
            if (null == pix)
            {
                throw new ArgumentNullException("pix, ptas cannot be null");
            }

            return Native.DllImports.pixRenderGridArb((HandleRef)pix, nx, ny, width, rval, gval, bval);
        }

        public static Pix pixRenderRandomCmapPtaa(this Pix pix, Ptaa ptaa, int polyflag, int width, int closeflag)
        {
            if (null == pix
             || null == ptaa)
            {
                throw new ArgumentNullException("pix, ptaa cannot be null");
            }

            var pointer = Native.DllImports.pixRenderRandomCmapPtaa((HandleRef)pix, (HandleRef)ptaa, polyflag, width, closeflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Rendering and filling of polygons
        public static Pix pixRenderPolygon(this Pta ptas, int width, out int pxmin, out int pymin)
        {
            if (null == ptas)
            {
                throw new ArgumentNullException("ptas cannot be null");
            }

            var pointer = Native.DllImports.pixRenderPolygon((HandleRef)ptas, width, out pxmin, out pymin);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFillPolygon(this Pix pixs, Pta pta, int xmin, int ymin)
        {
            if (null == pixs
             || null == pta)
            {
                throw new ArgumentNullException("pixs, pta cannot be null");
            }

            var pointer = Native.DllImports.pixFillPolygon((HandleRef)pixs, (HandleRef)pta, xmin, ymin);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Contour rendering on grayscale images
        public static Pix pixRenderContours(this Pix pixs, int startval, int incr, int outdepth)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("ptas cannot be null");
            }

            var pointer = Native.DllImports.pixRenderContours((HandleRef)pixs, startval, incr, outdepth);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix fpixAutoRenderContours(this FPix fpix, int ncontours)
        {
            if (null == fpix)
            {
                throw new ArgumentNullException("fpix cannot be null");
            }

            var pointer = Native.DllImports.fpixAutoRenderContours((HandleRef)fpix, ncontours);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix fpixRenderContours(this FPix fpixs, float incr, float proxim)
        {
            if (null == fpixs)
            {
                throw new ArgumentNullException("fpixs cannot be null");
            }

            var pointer = Native.DllImports.fpixRenderContours((HandleRef)fpixs, incr,   proxim);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Boundary pt generation on 1 bpp images
        public static Pta pixGeneratePtaBoundary(this Pix pixs, int width)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixGeneratePtaBoundary((HandleRef)pixs, width);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }
    }
}
