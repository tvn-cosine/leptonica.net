using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class MorphApp
    {
        // Extraction of boundary pixels
        public static Pix pixExtractBoundary(this Pix pixs, int type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixExtractBoundary((HandleRef)pixs, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Selective morph sequence operation under mask
        public static Pix pixMorphSequenceMasked(this Pix pixs, Pix pixm, string sequence, int dispsep)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphSequenceMasked((HandleRef)pixs, (HandleRef)pixm, sequence, dispsep);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Selective morph sequence operation on each component
        public static Pix pixMorphSequenceByComponent(this Pix pixs, string sequence, int connectivity, int minw, int minh, out Boxa pboxa)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr;
            var pointer = Native.DllImports.pixMorphSequenceByComponent((HandleRef)pixs, sequence, connectivity, minw, minh, out pboxaPtr);
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

        public static Pixa pixaMorphSequenceByComponent(this Pixa pixas, string sequence, int minw, int minh)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null.");
            }

            var pointer = Native.DllImports.pixaMorphSequenceByComponent((HandleRef)pixas, sequence, minw, minh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Selective morph sequence operation on each region
        public static Pix pixMorphSequenceByRegion(this Pix pixs, Pix pixm, string sequence, int connectivity, int minw, int minh, out Boxa pboxa)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            IntPtr pboxaPtr;
            var pointer = Native.DllImports.pixMorphSequenceByRegion((HandleRef)pixs, (HandleRef)pixm, sequence, connectivity, minw, minh, out pboxaPtr);
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

        public static Pixa pixaMorphSequenceByRegion(this Pix pixs, Pixa pixam, string sequence, int minw, int minh)
        {
            if (null == pixs
             || null == pixam)
            {
                throw new ArgumentNullException("pixas, pixam cannot be null.");
            }

            var pointer = Native.DllImports.pixaMorphSequenceByRegion((HandleRef)pixs, (HandleRef)pixam, sequence, minw, minh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }


        // Union and intersection of parallel composite operations
        public static Pix pixUnionOfMorphOps(this Pix pixs, Sela sela, int type)
        {
            if (null == pixs
             || null == sela)
            {
                throw new ArgumentNullException("pixas, sela cannot be null.");
            }

            var pointer = Native.DllImports.pixUnionOfMorphOps((HandleRef)pixs, (HandleRef)sela, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixIntersectionOfMorphOps(this Pix pixs, Sela sela, int type)
        {
            if (null == pixs
             || null == sela)
            {
                throw new ArgumentNullException("pixas, sela cannot be null.");
            }

            var pointer = Native.DllImports.pixIntersectionOfMorphOps((HandleRef)pixs, (HandleRef)sela, type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Selective connected component filling
        public static Pix pixSelectiveConnCompFill(this Pix pixs, int connectivity, int minw, int minh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixas cannot be null.");
            }

            var pointer = Native.DllImports.pixSelectiveConnCompFill((HandleRef)pixs, connectivity, minw, minh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Removal of matched patterns
        public static int pixRemoveMatchedPattern(this Pix pixs, Pix pixp, Pix pixe, int x0, int y0, int dsize)
        {
            if (null == pixs
             || null == pixp
             || null == pixe)
            {
                throw new ArgumentNullException("pixs, pixp, pixe cannot be null.");
            }

            return Native.DllImports.pixRemoveMatchedPattern((HandleRef)pixs, (HandleRef)pixp, (HandleRef)pixe, x0, y0, dsize);
        }

        // Display of matched patterns
        public static Pix pixDisplayMatchedPattern(this Pix pixs, Pix pixp, Pix pixe, int x0, int y0, uint color, float scale, int nlevels)
        {
            if (null == pixs
             || null == pixp
             || null == pixe)
            {
                throw new ArgumentNullException("pixs, pixp, pixe cannot be null.");
            }

            var pointer = Native.DllImports.pixDisplayMatchedPattern((HandleRef)pixs, (HandleRef)pixp, (HandleRef)pixe, x0, y0, color, scale, nlevels);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Extension of pixa by iterative erosion or dilation(and by scaling)
        public static Pixa pixaExtendByMorph(this Pixa pixas, int type, int niters, Sel sel, int include)
        {
            if (null == pixas)
            {
                throw new ArgumentNullException("pixas cannot be null.");
            }

            var pointer = Native.DllImports.pixaExtendByMorph((HandleRef)pixas, type, niters, (HandleRef)sel, include);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaExtendByScaling(this Pixa pixas, Numa nasc, int type, int include)
        {
            if (null == pixas
             || null == nasc)
            {
                throw new ArgumentNullException("pixas, nasc cannot be null.");
            }

            var pointer = Native.DllImports.pixaExtendByScaling((HandleRef)pixas, (HandleRef)nasc, type, include);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Iterative morphological seed filling(don't use for real work)
        public static Pix pixSeedfillMorph(this Pix pixs, Pix pixm, int maxiters, int connectivity)
        {
            if (null == pixs
             || null == pixm)
            {
                throw new ArgumentNullException("pixs, pixm cannot be null.");
            }

            var pointer = Native.DllImports.pixSeedfillMorph((HandleRef)pixs, (HandleRef)pixm, maxiters, connectivity);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Granulometry on binary images
        public static Numa pixRunHistogramMorph(this Pix pixs, RunlengthFlagsForGranulometry runtype, DirectionFlags direction, int maxsize)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixRunHistogramMorph((HandleRef)pixs, (int)runtype, (int)direction, maxsize);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        // Composite operations on grayscale images
        public static Pix pixTophat(this Pix pixs, int hsize, int vsize, MorphologicalTophatFlags type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixTophat((HandleRef)pixs, hsize, vsize, (int)type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixHDome(this Pix pixs, int height, int connectivity)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixHDome((HandleRef)pixs, height, connectivity);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
        public static Pix pixFastTophat(this Pix pixs, int xsize, int ysize, MorphologicalTophatFlags type)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixFastTophat((HandleRef)pixs, xsize, ysize, (int)type);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixMorphGradient(this Pix pixs, int hsize, int vsize, int smoothing)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphGradient((HandleRef)pixs, hsize, vsize, smoothing);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Centroid of component
        public static Pta pixaCentroids(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null.");
            }

            var pointer = Native.DllImports.pixaCentroids((HandleRef)pixa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pta(pointer);
            }
        }

        public static int pixCentroid(this Pix pix, IntPtr centtab, IntPtr sumtab, out float pxave, out float pyave)
        {
            if (null == pix
             || IntPtr.Zero == centtab
             || IntPtr.Zero == sumtab)
            {
                throw new ArgumentNullException("pixa, centtab, sumtab cannot be null.");
            }

            return Native.DllImports.pixCentroid((HandleRef)pix, centtab, sumtab, out pxave, out pyave);
        }
    }
}
