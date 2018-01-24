using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class CCBoard
    {
        // CCBORDA and CCBORD creation and destruction
        public static CCBorda ccbaCreate(this Pix pixs, int n)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.ccbaCreate((HandleRef)pixs, n);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBorda(pointer);
            }
        }

        public static void ccbaDestroy(this CCBorda pccba)
        {
            if (null == pccba)
            {
                throw new ArgumentNullException("pccba cannot be null");
            }

            var pointer = (IntPtr)pccba;

            Native.DllImports.ccbaDestroy(ref pointer);
        }

        public static CCBord ccbCreate(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.ccbCreate((HandleRef)pixs);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBord(pointer);
            }
        }

        public static void ccbDestroy(this CCBord pccb)
        {
            if (null == pccb)
            {
                throw new ArgumentNullException("pccb cannot be null");
            }

            var pointer = (IntPtr)pccb;

            Native.DllImports.ccbDestroy(ref pointer);
        }


        // CCBORDA addition
        public static int ccbaAddCcb(this CCBorda ccba, CCBord ccb)
        {
            if (null == ccba
             || null == ccb)
            {
                throw new ArgumentNullException("ccba, ccb cannot be null.");
            }

            return Native.DllImports.ccbaAddCcb((HandleRef)ccba, (HandleRef)ccb);
        }

        // CCBORDA accessors
        public static int ccbaGetCount(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaGetCount((HandleRef)ccba);
        }

        public static CCBord ccbaGetCcb(this CCBorda ccba, int index)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaGetCcb((HandleRef)ccba, index);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBord(pointer);
            }
        }

        // Top-level border-finding routines
        public static CCBorda pixGetAllCCBorders(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGetAllCCBorders((HandleRef)pixs);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBorda(pointer);
            }
        }

        public static CCBord pixGetCCBorders(this Pix pixs, Box box)
        {
            if (null == pixs
             || null == box)
            {
                throw new ArgumentNullException("pixs, box cannot be null.");
            }

            var pointer = Native.DllImports.pixGetCCBorders((HandleRef)pixs, (HandleRef)box);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBord(pointer);
            }
        }

        public static Ptaa pixGetOuterBordersPtaa(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGetOuterBordersPtaa((HandleRef)pixs);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Ptaa(pointer);
            }
        }

        public static Pta pixGetOuterBorderPta(this Pix pixs, Box box)
        {
            if (null == pixs
             || null == box)
            {
                throw new ArgumentNullException("pixs, box cannot be null.");
            }

            var pointer = Native.DllImports.pixGetOuterBorderPta((HandleRef)pixs, (HandleRef)box);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        // Lower-level border location routines
        public static int pixGetOuterBorder(this CCBord ccb, Pix pixs, Box box)
        {
            if (null == pixs
             || null == pixs
             || null == box)
            {
                throw new ArgumentNullException("ccb, pixs, box cannot be null.");
            }

            return Native.DllImports.pixGetOuterBorder((HandleRef)ccb, (HandleRef)pixs, (HandleRef)box);
        }

        public static int pixGetHoleBorder(this CCBord ccb, Pix pixs, Box box, int xs, int ys)
        {
            if (null == pixs
             || null == pixs
             || null == box)
            {
                throw new ArgumentNullException("ccb, pixs, box cannot be null.");
            }

            return Native.DllImports.pixGetHoleBorder((HandleRef)ccb, (HandleRef)pixs, (HandleRef)box, xs, ys);
        }

        public static int findNextBorderPixel(int w, int h, IntPtr data, int wpl, int px, int py, out int pqpos, out int pnpx, out int pnpy)
        {
            if (IntPtr.Zero == data)
            {
                throw new ArgumentNullException("data cannot be null.");
            }

            return Native.DllImports.findNextBorderPixel(w, h, data, wpl, px, py, out pqpos, out pnpx, out pnpy);
        }

        public static void locateOutsideSeedPixel(int fpx, int fpy, int spx, int spy, out int pxs, out int pys)
        {
            Native.DllImports.locateOutsideSeedPixel(fpx, fpy, spx, spy, out pxs, out pys);
        }

        // Border conversions
        public static int ccbaGenerateGlobalLocs(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaGenerateGlobalLocs((HandleRef)ccba);
        }

        public static int ccbaGenerateStepChains(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaGenerateStepChains((HandleRef)ccba);
        }

        public static int ccbaStepChainsToPixCoords(this CCBorda ccba, int coordtype)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaStepChainsToPixCoords((HandleRef)ccba, coordtype);
        }

        public static int ccbaGenerateSPGlobalLocs(this CCBorda ccba, int ptsflag)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaGenerateSPGlobalLocs((HandleRef)ccba, ptsflag);
        }

        // Conversion to single path
        public static int ccbaGenerateSinglePath(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            return Native.DllImports.ccbaGenerateSinglePath((HandleRef)ccba);
        }

        public static Pta getCutPathForHole(this Pix pix, Pta pta, Box boxinner, out int pdir, out int plen)
        {
            if (null == pix
             || null == pta
             || null == boxinner)
            {
                throw new ArgumentNullException("pix, pta, boxinner cannot be null.");
            }

            var pointer = Native.DllImports.getCutPathForHole((HandleRef)pix, (HandleRef)pta, (HandleRef)boxinner, out pdir, out plen);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        // Border and full image rendering
        public static Pix ccbaDisplayBorder(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaDisplayBorder((HandleRef)ccba);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix ccbaDisplaySPBorder(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaDisplaySPBorder((HandleRef)ccba);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix ccbaDisplayImage1(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaDisplayImage1((HandleRef)ccba);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix ccbaDisplayImage2(this CCBorda ccba)
        {
            if (null == ccba)
            {
                throw new ArgumentNullException("ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaDisplayImage2((HandleRef)ccba);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Serialize for I/O
        public static int ccbaWrite(string filename, CCBorda ccba)
        {
            if (null == ccba
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename, ccba cannot be null.");
            }

            return Native.DllImports.ccbaWrite(filename, (HandleRef)ccba);
        }

        public static int ccbaWriteStream(IntPtr fp, CCBorda ccba)
        {
            if (null == ccba
             || IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp, ccba cannot be null.");
            }

            return Native.DllImports.ccbaWriteStream(fp, (HandleRef)ccba);
        }

        public static CCBorda ccbaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.ccbaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBorda(pointer);
            }
        }

        public static CCBorda ccbaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.ccbaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new CCBorda(pointer);
            }
        }

        // SVG output
        public static int ccbaWriteSVG(string filename, CCBorda ccba)
        {
            if (null == ccba
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename, ccba cannot be null.");
            }

            return Native.DllImports.ccbaWriteSVG(filename, (HandleRef)ccba);
        }

        public static string ccbaWriteSVGString(string filename, CCBorda ccba)
        {
            if (null == ccba
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename, ccba cannot be null.");
            }

            var pointer = Native.DllImports.ccbaWriteSVGString(filename, (HandleRef)ccba);
            return Marshal.PtrToStringAnsi(pointer);
        }
    }
}
