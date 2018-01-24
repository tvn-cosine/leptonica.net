using System;
using System.Runtime.InteropServices;

namespace Leptonica.Implementations
{
    public static class Dewarp1
    {
        // Create/destroy dewarp
        public static L_Dewarp dewarpCreate(this Pix pixs, int pageno)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null.");
            }

            var pointer = Native.DllImports.dewarpCreate((HandleRef)pixs, pageno);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }

        public static L_Dewarp dewarpCreateRef(int pageno, int refpage)
        {
            var pointer = Native.DllImports.dewarpCreateRef(pageno, refpage);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }

        public static void dewarpDestroy(this L_Dewarp pdew)
        {
            if (null == pdew)
            {
                throw new ArgumentNullException("pdew cannot be null");
            }

            var pointer = (IntPtr)pdew;

            Native.DllImports.dewarpDestroy(ref pointer);
        }

        // Create/destroy dewarpa
        public static L_Dewarpa dewarpaCreate(int nptrs, int sampling, int redfactor, int minlines, int maxdist)
        {
            var pointer = Native.DllImports.dewarpaCreate(nptrs, sampling, redfactor, minlines, maxdist);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarpa(pointer);
            }
        }

        public static L_Dewarpa dewarpaCreateFromPixacomp(this Pixacc pixac, int useboth, int sampling, int minlines, int maxdist)
        {
            if (null == pixac)
            {
                throw new ArgumentNullException("pixac cannot be null.");
            }

            var pointer = Native.DllImports.dewarpaCreateFromPixacomp((HandleRef)pixac, useboth, sampling, minlines, maxdist);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarpa(pointer);
            }
        }

        public static void dewarpaDestroy(this L_Dewarpa pdewa)
        {
            if (null == pdewa)
            {
                throw new ArgumentNullException("pdewa cannot be null");
            }

            var pointer = (IntPtr)pdewa;

            Native.DllImports.dewarpaDestroy(ref pointer);
        }

        public static int dewarpaDestroyDewarp(this L_Dewarpa dewa, int pageno)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null");
            }

            var pointer = (IntPtr)dewa;

            return Native.DllImports.dewarpaDestroyDewarp(ref pointer, pageno);
        }

        // Dewarpa insertion/extraction
        public static int dewarpaInsertDewarp(this L_Dewarpa dewa, L_Dewarp dew)
        {
            if (null == dewa
             || null == dew)
            {
                throw new ArgumentNullException("dewa, dew cannot be null");
            }

            var pointer = (IntPtr)dewa;

            return Native.DllImports.dewarpaInsertDewarp((HandleRef)dewa, (HandleRef)dew);
        }

        public static L_Dewarp dewarpaGetDewarp(this L_Dewarpa dewa, int index)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            var pointer = Native.DllImports.dewarpaGetDewarp((HandleRef)dewa, index);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }

        // Setting parameters to control rendering from the model
        public static int dewarpaSetCurvatures(this L_Dewarpa dewa, int max_linecurv, int min_diff_linecurv, int max_diff_linecurv, int max_edgecurv, int max_diff_edgecurv, int max_edgeslope)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaSetCurvatures((HandleRef)dewa, max_linecurv, min_diff_linecurv, max_diff_linecurv, max_edgecurv, max_diff_edgecurv, max_edgeslope);
        }

        public static int dewarpaUseBothArrays(this L_Dewarpa dewa, int useboth)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaUseBothArrays((HandleRef)dewa, useboth);
        }

        public static int dewarpaSetCheckColumns(this L_Dewarpa dewa, int check_columns)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaSetCheckColumns((HandleRef)dewa, check_columns);
        }

        public static int dewarpaSetMaxDistance(this L_Dewarpa dewa, int maxdist)
        {
            if (null == dewa)
            {
                throw new ArgumentNullException("dewa cannot be null.");
            }

            return Native.DllImports.dewarpaSetMaxDistance((HandleRef)dewa, maxdist);
        }

        // Dewarp serialized I/O
        public static L_Dewarp dewarpRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist.");
            }

            var pointer = Native.DllImports.dewarpRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }

        public static L_Dewarp dewarpReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.dewarpReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }

        public static L_Dewarp dewarpReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null.");
            }

            var pointer = Native.DllImports.dewarpReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarp(pointer);
            }
        }
         
        public static int dewarpWrite(string filename, L_Dewarp dew)
        {
            if (null == dew
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename, dewa cannot be null.");
            }

            return Native.DllImports.dewarpWrite(filename, (HandleRef)dew);
        }

        public static int dewarpWriteStream(IntPtr fp, L_Dewarp dew)
        {
            if (IntPtr.Zero == fp
             || null == dew)
            {
                throw new ArgumentNullException("fp, dew cannot be null.");
            }

            return Native.DllImports.dewarpWriteStream(fp, (HandleRef)dew);
        }

        public static int dewarpWriteMem(out IntPtr pdata, IntPtr psize, L_Dewarp dew)
        {
            if (IntPtr.Zero == psize
             || null == dew)
            {
                throw new ArgumentNullException("psize, dew cannot be null.");
            }

            return Native.DllImports.dewarpWriteMem(out pdata, psize, (HandleRef)dew);
        }

        // Dewarpa serialized I/O
        public static L_Dewarpa dewarpaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null.");
            }
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist.");
            }

            var pointer = Native.DllImports.dewarpaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarpa(pointer);
            }
        }

        public static L_Dewarpa dewarpaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null.");
            }

            var pointer = Native.DllImports.dewarpaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarpa(pointer);
            }
        }

        public static L_Dewarpa dewarpaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null.");
            }

            var pointer = Native.DllImports.dewarpaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_Dewarpa(pointer);
            }
        }

        public static int dewarpaWrite(string filename, L_Dewarpa dewa)
        {
            if (null == dewa
             || string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename, dewa cannot be null.");
            }

            return Native.DllImports.dewarpaWrite(filename, (HandleRef)dewa);
        }

        public static int dewarpaWriteStream(IntPtr fp, L_Dewarpa dewa)
        {
            if (IntPtr.Zero == fp
             || null == dewa)
            {
                throw new ArgumentNullException("fp, dewa cannot be null.");
            }

            return Native.DllImports.dewarpaWriteStream(fp, (HandleRef)dewa);
        }

        public static int dewarpaWriteMem(out IntPtr pdata, IntPtr psize, L_Dewarpa dewa)
        {
            if (IntPtr.Zero == psize
             || null == dewa)
            {
                throw new ArgumentNullException("psize, dewa cannot be null.");
            }

            return Native.DllImports.dewarpaWriteMem(out pdata, psize, (HandleRef)dewa);
        }
    }
}
