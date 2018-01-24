using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixaFunc2
    {
        // Pixa display(render into a pix)
        public static Pix pixaDisplay(this Pixa pixa, int w, int h)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplay((HandleRef)pixa, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayOnColor(this Pixa pixa, int w, int h, uint bgcolor)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayOnColor((HandleRef)pixa, w, h, bgcolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayRandomCmap(this Pixa pixa, int w, int h)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayRandomCmap((HandleRef)pixa, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayLinearly(this Pixa pixas, int direction, float scalefactor, int background, int spacing, int border, out Boxa pboxa)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            IntPtr pboxaPtr;
            var pointer = Native.DllImports.pixaDisplayLinearly((HandleRef)pixas, direction, scalefactor, background, spacing, border, out pboxaPtr);
            pboxa = new Boxa(pboxaPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayOnLattice(this Pixa pixa, int cellw, int cellh, out int pncols, out Boxa pboxa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            IntPtr pboxaPtr;
            var pointer = Native.DllImports.pixaDisplayOnLattice((HandleRef)pixa, cellw, cellh, out pncols, out pboxaPtr);
            pboxa = new Boxa(pboxaPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayUnsplit(this Pixa pixa, int nx, int ny, int borderwidth, uint bordercolor)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayUnsplit((HandleRef)pixa, nx, ny, borderwidth, bordercolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiled(this Pixa pixa, int maxwidth, int background, int spacing)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiled((HandleRef)pixa, maxwidth, background, spacing);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiledInRows(this Pixa pixa, int outdepth, int maxwidth, float scalefactor, int background, int spacing, int border)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiledInRows((HandleRef)pixa, outdepth, maxwidth, scalefactor, background, spacing, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiledInColumns(this Pixa pixas, int nx, float scalefactor, int spacing, int border)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiledInColumns((HandleRef)pixas, nx, scalefactor, spacing, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiledAndScaled(this Pixa pixa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiledAndScaled((HandleRef)pixa, outdepth, tilewidth, ncols, background, spacing, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiledWithText(this Pixa pixa, int maxwidth, float scalefactor, int spacing, int border, int fontsize, uint textcolor)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiledWithText((HandleRef)pixa, maxwidth, scalefactor, spacing, border, fontsize, textcolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaDisplayTiledByIndex(this Pixa pixa, Numa na, int width, int spacing, int border, int fontsize, uint textcolor)
        {
            if (null == pixa
             || null == na)
            {
                throw new ArgumentNullException("pixa, na cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayTiledByIndex((HandleRef)pixa, (HandleRef)na, width, spacing, border, fontsize, textcolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Pixaa display(render into a pix)
        public static Pix pixaaDisplay(this Pixaa paa, int w, int h)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaDisplay((HandleRef)paa, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixaaDisplayByPixa(this Pixaa paa, int xspace, int yspace, int maxw)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaDisplayByPixa((HandleRef)paa, xspace, yspace, maxw);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaaDisplayTiledAndScaled(this Pixaa paa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaDisplayTiledAndScaled((HandleRef)paa, outdepth, tilewidth, ncols, background, spacing, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Conversion of all pix to specified type(e.g., depth)
        public static Pixa pixaConvertTo1(this Pixa pixas, int thresh)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertTo1((HandleRef)pixas, thresh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaConvertTo8(this Pixa pixas, int cmapflag)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertTo8((HandleRef)pixas, cmapflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaConvertTo8Color(this Pixa pixas, int dither)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertTo8Color((HandleRef)pixas, dither);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaConvertTo32(this Pixa pixas)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertTo32((HandleRef)pixas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Pixa constrained selection and pdf generation
        public static Pixa pixaConstrainedSelect(this Pixa pixas, int first, int last, int nmax, int use_pairs, int copyflag)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConstrainedSelect((HandleRef)pixas, first, last, nmax, use_pairs, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaSelectToPdf(this Pixa pixas, int first, int last, int res, float scalefactor, int type, int quality, uint color, int fontsize, string fileout)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            return Native.DllImports.pixaSelectToPdf((HandleRef)pixas, first, last, res, scalefactor, type, quality, color, fontsize, fileout);
        }

        // Pixa display into multiple tiles
        public static Pixa pixaDisplayMultiTiled(this Pixa pixas, int nx, int ny, int maxw, int maxh, float scalefactor, int spacing, int border)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaDisplayMultiTiled((HandleRef)pixas, nx, ny, maxw, maxh, scalefactor, spacing, border);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Split pixa into files
        public static int pixaSplitIntoFiles(this Pixa pixas, int nsplit, float scale, int outwidth, int write_pixa, int write_pix, int write_pdf)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            return Native.DllImports.pixaSplitIntoFiles((HandleRef)pixas, nsplit, scale, outwidth, write_pixa, write_pix, write_pdf);
        }

        // Tile N-Up
        public static int convertToNUpFiles(string dir, string substr, int nx, int ny, int tw, int spacing, int border, int fontsize, string outdir)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                throw new ArgumentNullException("dir cannot be null");
            }
            if (!System.IO.Directory.Exists(dir))
            {
                throw new System.IO.DirectoryNotFoundException("dir does not exist.");
            }

            return Native.DllImports.convertToNUpFiles(dir, substr, nx, ny, tw, spacing, border, fontsize, outdir);
        }

        public static Pixa convertToNUpPixa(string dir, string substr, int nx, int ny, int tw, int spacing, int border, int fontsize)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                throw new ArgumentNullException("dir cannot be null");
            }
            if (!System.IO.Directory.Exists(dir))
            {
                throw new System.IO.DirectoryNotFoundException("dir does not exist.");
            }

            var pointer = Native.DllImports.convertToNUpPixa(dir, substr, nx, ny, tw, spacing, border, fontsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaConvertToNUpPixa(this Pixa pixas, Sarray sa, int nx, int ny, int tw, int spacing, int border, int fontsize)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null");
            }

            var pointer = Native.DllImports.pixaConvertToNUpPixa((HandleRef)pixas, (HandleRef)sa, nx, ny, tw, spacing, border, fontsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Render two pixa side-by-side for comparison*
        public static int pixaCompareInPdf(this Pixa pixa1, Pixa pixa2, int nx, int ny, int tw, int spacing, int border, int fontsize, string fileout)
        {
            if (null == pixa1 || null == pixa2)
            {
                throw new ArgumentNullException("pixa1, pixa2 cannot be null");
            }

            return Native.DllImports.pixaCompareInPdf((HandleRef)pixa1, (HandleRef)pixa2, nx, ny, tw, spacing, border, fontsize, fileout);
        } 
    }
}
