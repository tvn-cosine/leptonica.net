using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class BoxBasic
    {  
        // Box creation, copy, clone, destruction
        public static Box boxCreate(int x, int y, int w, int h)
        {
            var pointer = Native.DllImports.boxCreate(x, y, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxCreateValid(int x, int y, int w, int h)
        {
            var pointer = Native.DllImports.boxCreateValid(x, y, w, h);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxCopy(this Box box)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            var pointer = Native.DllImports.boxCopy((HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxClone(this Box box)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            var pointer = Native.DllImports.boxClone((HandleRef)box);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static void boxDestroy(this Box pbox)
        {
            if (null == pbox)
            {
                throw new ArgumentNullException("pbox cannot be null");
            }

            var pointer = (IntPtr)pbox;

            Native.DllImports.boxDestroy(ref pointer);
        }

        // Box accessors
        public static int boxGetGeometry(this Box box, out int px, out int py, out int pw, out int ph)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxGetGeometry((HandleRef)box, out px, out py, out pw, out ph);
        }

        public static int boxSetGeometry(this Box box, int x, int y, int w, int h)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxSetGeometry((HandleRef)box, x, y, w, h);
        }

        public static int boxGetSideLocations(this Box box, out int pl, out int pr, out int pt, out int pb)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxGetSideLocations((HandleRef)box, out pl, out pr, out pt, out pb);
        }

        public static int boxSetSideLocations(this Box box, int l, int r, int t, int b)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxSetSideLocations((HandleRef)box, l, r, t, b);
        }

        public static int boxGetRefcount(this Box box)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxGetRefcount((HandleRef)box);
        }

        public static int boxChangeRefcount(this Box box, int delta)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxChangeRefcount((HandleRef)box, delta);
        }

        public static int boxIsValid(this Box box, out int pvalid)
        {
            if (null == box)
            {
                throw new ArgumentNullException("box cannot be null");
            }

            return Native.DllImports.boxIsValid((HandleRef)box, out pvalid);
        }

        // Boxa creation, copy, destruction
        public static Boxa boxaCreate(int n)
        {
            var pointer = Native.DllImports.boxaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);

            }
        }

        public static Boxa boxaCopy(this Boxa boxa, int copyflag)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaCopy((HandleRef)boxa, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);

            }
        }

        public static void boxaDestroy(this Boxa pboxa)
        {
            if (null == pboxa)
            {
                throw new ArgumentNullException("pboxa cannot be null");
            }

            var pointer = (IntPtr)pboxa;

            Native.DllImports.boxaDestroy(ref pointer);
        }

        // Boxa array extension
        public static int boxaAddBox(this Boxa boxa, Box box, int copyflag)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaAddBox((HandleRef)boxa, (HandleRef)box, copyflag);
        }

        public static int boxaExtendArray(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaExtendArray((HandleRef)boxa);
        }

        public static int boxaExtendArrayToSize(this Boxa boxa, int size)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaExtendArrayToSize((HandleRef)boxa, size);
        }

        // Boxa accessors
        public static int boxaGetCount(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaGetCount((HandleRef)boxa);
        }

        public static int boxaGetValidCount(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaGetValidCount((HandleRef)boxa);
        }

        public static Box boxaGetBox(this Boxa boxa, int index, int accessflag)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaGetBox((HandleRef)boxa, index, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Box boxaGetValidBox(this Boxa boxa, int index, int accessflag)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaGetValidBox((HandleRef)boxa, index, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static Numa boxaFindInvalidBoxes(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            var pointer = Native.DllImports.boxaFindInvalidBoxes((HandleRef)boxa);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Numa(pointer);
            }
        }

        public static int boxaGetBoxGeometry(this Boxa boxa, int index, out int px, out int py, out int pw, out int ph)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaGetBoxGeometry((HandleRef)boxa, index, out px, out py, out pw, out ph);
        }

        public static int boxaIsFull(this Boxa boxa, out int pfull)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaIsFull((HandleRef)boxa, out pfull);
        }

        // Boxa array modifiers
        public static int boxaReplaceBox(this Boxa boxa, int index, Box box)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaReplaceBox((HandleRef)boxa, index, (HandleRef)box);
        }

        public static int boxaInsertBox(this Boxa boxa, int index, Box box)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaInsertBox((HandleRef)boxa, index, (HandleRef)box);
        }

        public static int boxaRemoveBox(this Boxa boxa, int index)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaRemoveBox((HandleRef)boxa, index);
        }

        public static int boxaRemoveBoxAndSave(this Boxa boxa, int index, out Box pbox)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            IntPtr pboxPtr;
            var answer = Native.DllImports.boxaRemoveBoxAndSave((HandleRef)boxa, index, out pboxPtr);
            if (IntPtr.Zero == pboxPtr)
            {
                pbox = null;
            }
            else
            {
                pbox = new Box(pboxPtr);
            }
            return answer;
        }

        public static Boxa boxaSaveValid(this Boxa boxas, int copyflag)
        {
            if (null == boxas)
            {
                throw new ArgumentNullException("boxas cannot be null");
            }

            var pointer = Native.DllImports.boxaSaveValid((HandleRef)boxas, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaInitFull(this Boxa boxa, Box box)
        {
            if (null == boxa
             || null == box)
            {
                throw new ArgumentNullException("boxa, box cannot be null");
            }

            return Native.DllImports.boxaInitFull((HandleRef)boxa, (HandleRef)box);
        }

        public static int boxaClear(this Boxa boxa)
        {
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaClear((HandleRef)boxa);
        }

        // Boxaa creation, copy, destruction
        public static Boxaa boxaaCreate(int n)
        {
            var pointer = Native.DllImports.boxaaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);

            }
        }

        public static Boxaa boxaaCopy(this Boxaa baas, int copyflag)
        {
            if (null == baas)
            {
                throw new ArgumentNullException("baas cannot be null");
            }

            var pointer = Native.DllImports.boxaCopy((HandleRef)baas, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);

            }
        }

        public static void boxaaDestroy(this Boxaa pbaa)
        {
            if (null == pbaa)
            {
                throw new ArgumentNullException("pbaa cannot be null");
            }

            var pointer = (IntPtr)pbaa;

            Native.DllImports.boxaaDestroy(ref pointer);
        }

        // Boxaa array extension
        public static int boxaaAddBoxa(this Boxaa baa, Boxa ba, int copyflag)
        {
            if (null == baa
             || null == ba)
            {
                throw new ArgumentNullException("baa, ba cannot be null");
            }

            return Native.DllImports.boxaaAddBoxa((HandleRef)baa, (HandleRef)ba, copyflag);
        }

        public static int boxaaExtendArray(this Boxaa baa)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaExtendArray((HandleRef)baa);
        }

        public static int boxaaExtendArrayToSize(this Boxaa baa, int size)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaExtendArrayToSize((HandleRef)baa, size);
        }

        // Boxaa accessors
        public static int boxaaGetCount(this Boxaa baa)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaGetCount((HandleRef)baa);
        }

        public static int boxaaGetBoxCount(this Boxaa baa)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaGetBoxCount((HandleRef)baa);
        }

        public static Boxa boxaaGetBoxa(this Boxaa baa, int index, int accessflag)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            var pointer = Native.DllImports.boxaGetBox((HandleRef)baa, index, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Box boxaaGetBox(this Boxaa baa, int iboxa, int ibox, int accessflag)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            var pointer = Native.DllImports.boxaaGetBox((HandleRef)baa, iboxa, ibox, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        // Boxaa array modifiers
        public static int boxaaInitFull(this Boxaa baa, Boxa boxa)
        {
            if (null == baa
             || null == boxa)
            {
                throw new ArgumentNullException("baa, boxa cannot be null");
            }

            return Native.DllImports.boxaaInitFull((HandleRef)baa, (HandleRef)boxa);
        }

        public static int boxaaExtendWithInit(this Boxaa baa, int maxindex, Boxa boxa)
        {
            if (null == baa
             || null == boxa)
            {
                throw new ArgumentNullException("baa, boxa cannot be null");
            }

            return Native.DllImports.boxaaExtendWithInit((HandleRef)baa, maxindex, (HandleRef)boxa);
        }

        public static int boxaaReplaceBoxa(this Boxaa baa, int index, Boxa boxa)
        {
            if (null == baa
             || null == boxa)
            {
                throw new ArgumentNullException("baa, boxa cannot be null");
            }

            return Native.DllImports.boxaaReplaceBoxa((HandleRef)baa, index, (HandleRef)boxa);
        }

        public static int boxaaInsertBoxa(this Boxaa baa, int index, Boxa boxa)
        {
            if (null == baa
             || null == boxa)
            {
                throw new ArgumentNullException("baa, boxa cannot be null");
            }

            return Native.DllImports.boxaaInsertBoxa((HandleRef)baa, index, (HandleRef)boxa);
        }

        public static int boxaaRemoveBoxa(this Boxaa baa, int index)
        {
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaRemoveBoxa((HandleRef)baa, index);
        }

        public static int boxaaAddBox(this Boxaa baa, int index, Box box, int accessflag)
        {
            if (null == baa
             || null == box)
            {
                throw new ArgumentNullException("baa, box cannot be null");
            }

            return Native.DllImports.boxaaAddBox((HandleRef)baa, index, (HandleRef)box, accessflag);
        }

        // Boxaa serialized I/O
        public static Boxaa boxaaReadFromFiles(string dirname, string substr, int first, int nfiles)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist");
            }

            var pointer = Native.DllImports.boxaaReadFromFiles(dirname, substr, first, nfiles);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static Boxaa boxaaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.boxaaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static Boxaa boxaaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.boxaaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static Boxaa boxaaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.boxaaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxaa(pointer);
            }
        }

        public static int boxaaWrite(string filename, Boxaa baa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == baa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.boxaaWrite(filename, (HandleRef)baa);
        }

        public static int boxaaWriteStream(IntPtr fp, Boxaa baa)
        {
            if (IntPtr.Zero == fp
             || null == baa)
            {
                throw new ArgumentNullException("fp, baa cannot be null");
            }

            return Native.DllImports.boxaaWriteStream(fp, (HandleRef)baa);
        }

        public static int boxaaWriteMem(IntPtr pdata, IntPtr psize, Boxaa baa)
        {
            if (IntPtr.Zero == pdata
             || IntPtr.Zero == psize
             || null == baa)
            {
                throw new ArgumentNullException("pdata, psize, baa cannot be null");
            }

            return Native.DllImports.boxaaWriteMem(pdata, psize, (HandleRef)baa);
        }

        // Boxa serialized I/O
        public static Boxa boxaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.boxaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.boxaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Boxa boxaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.boxaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int boxaWrite(string filename, Boxa boxa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == boxa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.boxaWrite(filename, (HandleRef)boxa);
        }

        public static int boxaWriteStream(IntPtr fp, Boxa boxa)
        {
            if (IntPtr.Zero == fp
             || null == boxa)
            {
                throw new ArgumentNullException("fp, boxa cannot be null");
            }

            return Native.DllImports.boxaWriteStream(fp, (HandleRef)boxa);
        }

        public static int boxaWriteMem(IntPtr pdata, IntPtr psize, Boxa boxa)
        {
            if (IntPtr.Zero == pdata
             || IntPtr.Zero == psize
             || null == boxa)
            {
                throw new ArgumentNullException("pdata, psize, boxa cannot be null");
            }

            return Native.DllImports.boxaWriteMem(pdata, psize, (HandleRef)boxa);
        }

        // Box print (for debug)
        public static int boxPrintStreamInfo(IntPtr fp, Box box)
        {
            if (IntPtr.Zero == fp
             || null == box)
            {
                throw new ArgumentNullException("fp, box cannot be null");
            }

            return Native.DllImports.boxPrintStreamInfo(fp, (HandleRef)box);
        }
    }
}
