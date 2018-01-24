using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class ColorSpace
    {
        // Colorspace conversion between RGB and HSV
        public static Pix pixConvertRGBToHSV(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToHSV((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvertHSVToRGB(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertHSVToRGB((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int convertRGBToHSV(int rval, int gval, int bval, out int phval, out int psval, out int pvval)
        {
            return Native.DllImports.convertRGBToHSV(rval, gval, bval, out phval, out psval, out pvval);
        }

        public static int convertHSVToRGB(int hval, int sval, int vval, out int prval, out int pgval, out int pbval)
        {
            return Native.DllImports.convertHSVToRGB(hval, sval, vval, out prval, out pgval, out pbval);
        }

        public static int pixcmapConvertRGBToHSV(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null.");
            }

            return Native.DllImports.pixcmapConvertRGBToHSV((HandleRef)cmap);
        }

        public static int pixcmapConvertHSVToRGB(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null.");
            }

            return Native.DllImports.pixcmapConvertHSVToRGB((HandleRef)cmap);
        }

        public static Pix pixConvertRGBToHue(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToHue((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvertRGBToSaturation(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToSaturation((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvertRGBToValue(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToValue((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Selection and display of range of colors in HSV space
        public static Pix pixMakeRangeMaskHS(this Pix pixs, int huecenter, int huehw, int satcenter, int sathw, int regionflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMakeRangeMaskHS((HandleRef)pixs, huecenter, huehw, satcenter, sathw, regionflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeRangeMaskHV(this Pix pixs, int huecenter, int huehw, int valcenter, int valhw, int regionflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMakeRangeMaskHV((HandleRef)pixs, huecenter, huehw, valcenter, valhw, regionflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeRangeMaskSV(this Pix pixs, int satcenter, int sathw, int valcenter, int valhw, int regionflag)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMakeRangeMaskSV((HandleRef)pixs, satcenter, sathw, valcenter, valhw, regionflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeHistoHS(this Pix pixs, int factor, out Numa pnahue, out Numa pnasat)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pnahuePtr, pnasatPtr;
            var pointer = Native.DllImports.pixMakeHistoHS((HandleRef)pixs, factor, out pnahuePtr, out pnasatPtr);
            pnahue = new Numa(pnahuePtr);
            pnasat = new Numa(pnasatPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeHistoHV(this Pix pixs, int factor, out Numa pnahue, out Numa pnaval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pnahuePtr, pnavalPtr;
            var pointer = Native.DllImports.pixMakeHistoHV((HandleRef)pixs, factor, out pnahuePtr, out pnavalPtr);
            pnahue = new Numa(pnahuePtr);
            pnaval = new Numa(pnavalPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMakeHistoSV(this Pix pixs, int factor, out Numa pnasat, out Numa pnaval)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pnasatPtr, pnavalPtr;
            var pointer = Native.DllImports.pixMakeHistoSV((HandleRef)pixs, factor, out pnasatPtr, out pnavalPtr);
            pnasat = new Numa(pnasatPtr);
            pnaval = new Numa(pnavalPtr);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixFindHistoPeaksHSV(this Pix pixs, int type, int width, int height, int npeaks, float erasefactor, out Pta ppta, out Numa pnatot, out Pixa ppixa)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pptaPtr, pnatotPtr, ppixaPtr;
            var result = Native.DllImports.pixFindHistoPeaksHSV((HandleRef)pixs, type, width, height, npeaks, erasefactor, out pptaPtr, out pnatotPtr, out ppixaPtr);
            ppta = new Pta(pptaPtr);
            pnatot = new Numa(pnatotPtr);
            ppixa = new Pixa(ppixaPtr);

            return result;
        }

        public static Pix displayHSVColorRange(int hval, int sval, int vval, int huehw, int sathw, int nsamp, int factor)
        {
            var pointer = Native.DllImports.displayHSVColorRange(hval, sval, vval, huehw, sathw, nsamp, factor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Colorspace conversion between RGB and YUV
        public static Pix pixConvertRGBToYUV(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToYUV((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixConvertYUVToRGB(this Pix pixd, Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertYUVToRGB((HandleRef)pixd, (HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int convertRGBToYUV(int rval, int gval, int bval, out int pyval, out int puval, out int pvval)
        {
            return Native.DllImports.convertRGBToYUV(rval, gval, bval, out pyval, out puval, out pvval);
        }

        public static int convertYUVToRGB(int yval, int uval, int vval, out int prval, out int pgval, out int pbval)
        {
            return Native.DllImports.convertYUVToRGB(yval, uval, vval, out prval, out pgval, out pbval);
        }

        public static int pixcmapConvertRGBToYUV(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null.");
            }

            return Native.DllImports.pixcmapConvertRGBToYUV((HandleRef)cmap);
        }

        public static int pixcmapConvertYUVToRGB(this PixColormap cmap)
        {
            if (null == cmap)
            {
                throw new ArgumentNullException("cmap cannot be null.");
            }

            return Native.DllImports.pixcmapConvertYUVToRGB((HandleRef)cmap);
        }

        // Colorspace conversion between RGB and XYZ
        public static FPixa pixConvertRGBToXYZ(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToXYZ((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static Pix fpixaConvertXYZToRGB(this FPixa fpixa)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa cannot be null.");
            }

            var pointer = Native.DllImports.fpixaConvertXYZToRGB((HandleRef)fpixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int convertRGBToXYZ(int rval, int gval, int bval, out float pfxval, out float pfyval, out float pfzval)
        {
            return Native.DllImports.convertRGBToXYZ(rval, gval, bval, out pfxval, out pfyval, out pfzval);
        }

        public static int convertXYZToRGB(float fxval, float fyval, float fzval, int blackout, out int prval, out int pgval, out int pbval)
        {
            return Native.DllImports.convertXYZToRGB(fxval, fyval, fzval, blackout, out prval, out pgval, out pbval);
        }


        // Colorspace conversion between XYZ and LAB
        public static FPixa fpixaConvertXYZToLAB(this FPixa fpixas)
        {
            if (null == fpixas)
            {
                throw new ArgumentNullException("fpixas cannot be null.");
            }

            var pointer = Native.DllImports.fpixaConvertXYZToLAB((HandleRef)fpixas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static FPixa fpixaConvertLABToXYZ(this FPixa fpixas)
        {
            if (null == fpixas)
            {
                throw new ArgumentNullException("fpixas cannot be null.");
            }

            var pointer = Native.DllImports.fpixaConvertLABToXYZ((HandleRef)fpixas);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static int convertXYZToLAB(float xval, float yval, float zval, out float plval, out float paval, out float pbval)
        {
            return Native.DllImports.convertXYZToLAB(xval, yval, zval, out plval, out paval, out pbval);
        }

        public static int convertLABToXYZ(float lval, float aval, float bval, out float pxval, out float pyval, out float pzval)
        {
            return Native.DllImports.convertLABToXYZ(lval, aval, bval, out pxval, out pyval, out pzval);
        }

        // Colorspace conversion between RGB and LAB
        public static FPixa pixConvertRGBToLAB(this Pix pixs)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixConvertRGBToLAB((HandleRef)pixs);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new FPixa(pointer);
            }
        }

        public static Pix fpixaConvertLABToRGB(this FPixa fpixa)
        {
            if (null == fpixa)
            {
                throw new ArgumentNullException("fpixa cannot be null.");
            }

            var pointer = Native.DllImports.fpixaConvertLABToRGB((HandleRef)fpixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int convertRGBToLAB(int rval, int gval, int bval, out float pflval, out float pfaval, out float pfbval)
        {
            return Native.DllImports.convertRGBToLAB(rval, gval, bval, out pflval, out pfaval, out pfbval);
        }

        public static int convertLABToRGB(float flval, float faval, float fbval, out int prval, out int pgval, out int pbval)
        {
            return Native.DllImports.convertLABToRGB(flval, faval, fbval, out prval, out pgval, out pbval);
        }
    }
}
