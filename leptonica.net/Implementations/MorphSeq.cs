using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class MorphSeq
    {
        // Run a sequence of binary rasterop morphological operations
        public static Pix pixMorphSequence(this Pix pixs, string sequence, int dispsep)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphSequence((HandleRef)pixs, sequence, dispsep);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Run a sequence of binary composite rasterop morphological operations
        public static Pix pixMorphCompSequence(this Pix pixs, string sequence, int dispsep)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphCompSequence((HandleRef)pixs, sequence, dispsep);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Run a sequence of binary dwa morphological operations
        public static Pix pixMorphSequenceDwa(this Pix pixs, string sequence, int dispsep)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphSequenceDwa((HandleRef)pixs, sequence, dispsep);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Run a sequence of binary composite dwa morphological operations
        public static Pix pixMorphCompSequenceDwa(this Pix pixs, string sequence, int dispsep)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixMorphCompSequenceDwa((HandleRef)pixs, sequence, dispsep);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Parser verifier for binary morphological operations
        public static int morphSequenceVerify(this Sarray sa)
        {
            if (null == sa)
            {
                throw new ArgumentNullException("sa cannot be null.");
            }

            return Native.DllImports.morphSequenceVerify((HandleRef)sa);
        }

        // Run a sequence of grayscale morphological operations
        public static Pix pixGrayMorphSequence(this Pix pixs, string sequence, int dispsep, int dispy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixGrayMorphSequence((HandleRef)pixs, sequence, dispsep, dispy);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        // Run a sequence of color morphological operations
        public static Pix pixColorMorphSequence(this Pix pixs, string sequence, int dispsep, int dispy)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.pixColorMorphSequence((HandleRef)pixs, sequence, dispsep, dispy);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }
    }
}
