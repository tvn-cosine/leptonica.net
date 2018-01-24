using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Bmf
    {
        // Acquisition and generation of bitmap fonts. 
        public static L_Bmf bmfCreate(string dir, int fontsize)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                throw new ArgumentNullException("dir cannot be null.");
            }

            if (!System.IO.Directory.Exists(dir))
            {
                throw new System.IO.DirectoryNotFoundException("dir does not exist");
            }

            var pointer = Native.DllImports.bmfCreate(dir, fontsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Bmf(pointer);
            }
        }

        public static void bmfDestroy(this L_Bmf pbmf)
        {
            if (null == pbmf)
            {
                throw new ArgumentNullException("pbmf cannot be null.");
            }

            var pointer = (IntPtr)pbmf;
            Native.DllImports.bmfDestroy(ref pointer);
        }

        public static Pix bmfGetPix(L_Bmf bmf, char chr)
        {
            if (null == bmf)
            {
                throw new ArgumentNullException("bmf cannot be null.");
            }

            var pointer = Native.DllImports.bmfGetPix((HandleRef)bmf, chr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int bmfGetWidth(this L_Bmf bmf, char chr, out int pw)
        {
            if (null == bmf)
            {
                throw new ArgumentNullException("bmf cannot be null.");
            }

            return Native.DllImports.bmfGetWidth((HandleRef)bmf, chr, out pw);
        }

        public static int bmfGetBaseline(this L_Bmf bmf, char chr, out int pbaseline)
        {
            if (null == bmf)
            {
                throw new ArgumentNullException("bmf cannot be null.");
            }

            return Native.DllImports.bmfGetBaseline((HandleRef)bmf, chr, out pbaseline);
        }

        public static Pixa pixaGetFont(string dir, int fontsize, out int pbl0, out int pbl1, out int pbl2)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                throw new ArgumentNullException("dir cannot be null.");
            }

            if (!System.IO.Directory.Exists(dir))
            {
                throw new System.IO.DirectoryNotFoundException("dir does not exist");
            }

            var pointer = Native.DllImports.pixaGetFont(dir, fontsize, out pbl0, out pbl1, out pbl2);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaSaveFont(string indir, string outdir, int fontsize)
        {
            if (string.IsNullOrWhiteSpace(indir) || string.IsNullOrWhiteSpace(outdir))
            {
                throw new ArgumentNullException("outdir, outdir cannot be null.");
            }

            if (!System.IO.Directory.Exists(indir) || !System.IO.Directory.Exists(outdir))
            {
                throw new System.IO.DirectoryNotFoundException("indir, outdir does not exist");
            }

            return Native.DllImports.pixaSaveFont(indir, outdir, fontsize);
        }
    }
}
