using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PtaFunc1
    {
        // Simple rearrangements
        public static Pta ptaSubsample(this Pta ptas, int subfactor)
        {
            throw new NotImplementedException();
        }

        public static int ptaJoin(this Pta ptad, Pta ptas, int istart, int iend)
        {
            throw new NotImplementedException();
        }

        public static int ptaaJoin(this Ptaa ptaad, Ptaa ptaas, int istart, int iend)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaReverse(this Pta ptas, int type)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaTranspose(this Pta ptas)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaCyclicPerm(this Pta ptas, int xs, int ys)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaSelectRange(this Pta ptas, int first, int last)
        {
            throw new NotImplementedException();
        }


        // Geometric
        public static Box ptaGetBoundingRegion(this Pta pta)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetRange(this Pta pta, out float pminx, out float pmaxx, out float pminy, out float pmaxy)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaGetInsideBox(this Pta ptas, HandleRef box)
        {
            throw new NotImplementedException();
        }

        public static Pta pixFindCornerPixels(this Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static int ptaContainsPt(this Pta pta, int x, int y)
        {
            throw new NotImplementedException();
        }

        public static int ptaTestIntersection(this Pta pta1, Pta pta2)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaTransform(this Pta ptas, int shiftx, int shifty, float scalex, float scaley)
        {
            throw new NotImplementedException();
        }

        public static int ptaPtInsidePolygon(this Pta pta, float x, float y, out int pinside)
        {
            throw new NotImplementedException();
        }

        public static float l_angleBetweenVectors(float x1, float y1, float x2, float y2)
        {
            throw new NotImplementedException();
        }


        // Min/max and filtering
        public static int ptaGetMinMax(this Pta pta, out float pxmin, out float pymin, out float pxmax, out float pymax)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaSelectByValue(this Pta ptas, float xth, float yth, int type, int relation)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaCropToMask(this Pta ptas, Pix pixm)
        {
            throw new NotImplementedException();
        }


        // Least Squares Fit
        public static int ptaGetLinearLSF(this Pta pta, out float pa, out float pb, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetQuadraticLSF(this Pta pta, out float pa, out float pb, out float pc, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetCubicLSF(this Pta pta, out float pa, out float pb, out float pc, out float pd, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int ptaGetQuarticLSF(this Pta pta, out float pa, out float pb, out float pc, out float pd, out float pe, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int ptaNoisyLinearLSF(this Pta pta, float factor, out Pta pptad, out float pa, out float pb, out float pmederr, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int ptaNoisyQuadraticLSF(this Pta pta, float factor, out Pta pptad, out float pa, out float pb, out float pc, out float pmederr, out Numa pnafit)
        {
            throw new NotImplementedException();
        }

        public static int applyLinearFit(float a, float b, float x, out float py)
        {
            throw new NotImplementedException();
        }

        public static int applyQuadraticFit(float a, float b, float c, float x, out float py)
        {
            throw new NotImplementedException();
        }

        public static int applyCubicFit(float a, float b, float c, float d, float x, out float py)
        {
            throw new NotImplementedException();
        }

        public static int applyQuarticFit(float a, float b, float c, float d, float e, float x, out float py)
        {
            throw new NotImplementedException();
        }


        // Interconversions with Pix
        public static int pixPlotAlongPta(this Pix pixs, Pta pta, int outformat, string title)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaGetPixelsFromPix(this Pix pixs, Box box)
        {
            throw new NotImplementedException();
        }

        public static Pix pixGenerateFromPta(this Pta pta, int w, int h)
        {
            var pointer = Native.DllImports.pixGenerateFromPta((HandleRef)pta, w, h);
            return new Pix(pointer);
        }

        public static Pta ptaGetBoundaryPixels(this Pix pixs, int type)
        {
            throw new NotImplementedException();
        }

        public static Ptaa ptaaGetBoundaryPixels(this Pix pixs, DistanceFunctionBCFlags type, int connectivity, out Boxa pboxa, out Pixa ppixa)
        {
            IntPtr pboxaPtr, ppixaPtr;
            var pointer = Native.DllImports.ptaaGetBoundaryPixels((HandleRef)pixs, (int)type, connectivity, out pboxaPtr, out ppixaPtr);
            if (pboxaPtr == IntPtr.Zero)
                pboxa = null;
            else
                pboxa = new Boxa(pboxaPtr);
            if (ppixaPtr == IntPtr.Zero)
                ppixa = null;
            else
                ppixa = new Pixa(ppixaPtr);

            return new Ptaa(pointer);
        }

        public static Ptaa ptaaIndexLabeledPixels(this Pix pixs, out int pncc)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaGetNeighborPixLocs(this Pix pixs, int x, int y, int conn)
        {
            throw new NotImplementedException();
        }


        // Interconversion with Numa
        public static Pta numaConvertToPta1(this Numa na)
        {
            throw new NotImplementedException();
        }

        public static Pta numaConvertToPta2(this Numa nax, Numa nay)
        {
            throw new NotImplementedException();
        }

        public static int ptaConvertToNuma(this Pta pta, out Numa pnax, out Numa pnay)
        {
            throw new NotImplementedException();
        }


        // Display Pta and Ptaa
        public static Pix pixDisplayPta(this Pix pixd, Pix pixs, Pta pta)
        {
            throw new NotImplementedException();
        }

        public static Pix pixDisplayPtaaPattern(this Pix pixd, Pix pixs, Ptaa ptaa, Pix pixp, int cx, int cy)
        {
            throw new NotImplementedException();
        }

        public static Pix pixDisplayPtaPattern(this Pix pixd, Pix pixs, Pta pta, Pix pixp, int cx, int cy, uint color)
        {
            throw new NotImplementedException();
        }

        public static Pta ptaReplicatePattern(this Pta ptas, Pix pixp, Pta ptap, int cx, int cy, int w, int h)
        {
            throw new NotImplementedException();
        }

        public static Pix pixDisplayPtaa(this Pix pixs, Ptaa ptaa)
        {
            throw new NotImplementedException();
        }
    }
}
