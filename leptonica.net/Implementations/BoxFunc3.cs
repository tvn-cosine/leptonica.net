using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leptonica 
{
    public static class BoxFunc3
    {    // Boxa/Boxaa painting into pix
        public static Pix pixMaskConnComp(this Pix pixs, int connectivity, out Boxa pboxa)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr;
            var pointer = Native.DllImports.pixMaskConnComp((HandleRef)pixs, connectivity, out pboxaPtr);
            if (IntPtr.Zero == pboxaPtr)
            {
                pboxa = null;
            }
            else
            {
                pboxa = new Boxa(pboxaPtr);
            }

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMaskBoxa(this Pix pixd, Pix pixs, Boxa boxa, int op)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixMaskBoxa((HandleRef)pixd, (HandleRef)pixs, (HandleRef)boxa, op);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixPaintBoxa(this Pix pixs, Boxa boxa, uint val)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixPaintBoxa((HandleRef)pixs, (HandleRef)boxa, val);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixSetBlackOrWhiteBoxa(this Pix pixs, Boxa boxa, int op)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixSetBlackOrWhiteBoxa((HandleRef)pixs, (HandleRef)boxa, op);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixPaintBoxaRandom(this Pix pixs, Boxa boxa)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixPaintBoxaRandom((HandleRef)pixs, (HandleRef)boxa);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixBlendBoxaRandom(this Pix pixs, Boxa boxa, float fract)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixBlendBoxaRandom((HandleRef)pixs, (HandleRef)boxa, fract);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDrawBoxa(this Pix pixs, Boxa boxa, int width, uint val)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixDrawBoxa((HandleRef)pixs, (HandleRef)boxa, width, val);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixDrawBoxaRandom(this Pix pixs, Boxa boxa, int width)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null.");
            }

            var pointer = Native.DllImports.pixDrawBoxaRandom((HandleRef)pixs, (HandleRef)boxa, width);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix boxaaDisplay(this Pix pixs, Boxaa baa, int linewba, int linewb, uint colorba, uint colorb, int w, int h)
        {
            if (null == pixs
             || null == baa)
            {
                throw new ArgumentNullException("pixs, baa cannot be null.");
            }

            var pointer = Native.DllImports.boxaaDisplay((HandleRef)pixs, (HandleRef)baa, linewba, linewb, colorba, colorb, w, h);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pixa pixaDisplayBoxaa(this Pixa pixas, Boxaa baa, int colorflag, int width)
        {
            if (null == pixas
             || null == baa)
            {
                throw new ArgumentNullException("pixas, baa cannot be null.");
            }

            var pointer = Native.DllImports.pixaDisplayBoxaa((HandleRef)pixas, (HandleRef)baa, colorflag, width);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Split mask components into Boxa
        public static Boxa pixSplitIntoBoxa(this Pix pixs, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSplitIntoBoxa((HandleRef)pixs, minsum, skipdist, delta, maxbg, maxcomps, remainder);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa pixSplitComponentIntoBoxa(this Pix pix, Box box, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder)
        {
            if (null == pix
             || null == box)
            {
                throw new ArgumentNullException("pix, box cannot be null.");
            }

            var pointer = Native.DllImports.pixSplitComponentIntoBoxa((HandleRef)pix, (HandleRef)box, minsum, skipdist, delta, maxbg, maxcomps, remainder);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // Represent horizontal or vertical mosaic strips
        public static Boxa makeMosaicStrips(int w, int h, int direction, int size)
        {
            var pointer = Native.DllImports.makeMosaicStrips(w, h, direction, size);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        // Comparison between boxa
        public static int boxaCompareRegions(this Boxa boxa1, Boxa boxa2, int areathresh, out int pnsame, out float pdiffarea, out float pdiffxor, out Pix ppixdb)
        {
            if (null == boxa1
             || null == boxa2)
            {
                throw new ArgumentNullException("boxa1, boxa2 cannot be null.");
            }

            IntPtr ppixdbPtr;
            var result = Native.DllImports.boxaCompareRegions((HandleRef)boxa1, (HandleRef)boxa2, areathresh, out pnsame, out pdiffarea, out pdiffxor, out ppixdbPtr);
            if (IntPtr.Zero == ppixdbPtr)
            {
                ppixdb = null;
            }
            else
            {
                ppixdb = new Pix(ppixdbPtr);
            }

            return result;
        }

        // Reliable selection of a single large box
        public static Box pixSelectLargeULComp(this Pix pixs, float areaslop, int yslop, int connectivity)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixSelectLargeULComp((HandleRef)pixs, areaslop, yslop, connectivity);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxaSelectLargeULBox(this Boxa boxas, float areaslop, int yslop)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null.");
            }

            var pointer = Native.DllImports.boxaSelectLargeULBox((HandleRef)boxas, areaslop, yslop);

            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }
    }
}
