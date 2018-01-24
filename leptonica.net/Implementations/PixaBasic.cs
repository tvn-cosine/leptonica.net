using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class PixaBasic
    {
        // Pixa creation, destruction, copying
        public static Pixa pixaCreate(int n)
        {
            var pointer = Native.DllImports.pixaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);

            }
        }

        public static Pixa pixaCreateFromPix(this Pix pixs, int n, int cellw, int cellh)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixaCreateFromPix((HandleRef)pixs, n, cellw, cellh);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);

            }
        }

        public static Pixa pixaCreateFromBoxa(this Pix pixs, Boxa boxa, out int pcropwarn)
        {
            if (null == pixs
             || null == boxa)
            {
                throw new ArgumentNullException("pixs, boxa cannot be null");
            }

            var pointer = Native.DllImports.pixaCreateFromBoxa((HandleRef)pixs, (HandleRef)boxa, out pcropwarn);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaSplitPix(this Pix pixs, int nx, int ny, int borderwidth, uint bordercolor)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixaSplitPix((HandleRef)pixs, nx, ny, borderwidth, bordercolor);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static void pixaDestroy(this Pixa ppixa)
        {
            if (null == ppixa)
            {
                throw new ArgumentNullException("ppixa cannot be null");
            }

            var pointer = (IntPtr)ppixa;

            Native.DllImports.pixaDestroy(ref pointer);
        }

        public static Pixa pixaCopy(this Pixa pixa, int copyflag)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaCopy((HandleRef)pixa, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer); 
            }
        }

        // Pixa addition
        public static int pixaAddPix(this Pixa pixa, Pix pix, int copyflag)
        {
            if (null == pixa
             || null == pix)
            {
                throw new ArgumentNullException("pixa, pix cannot be null");
            }

            return Native.DllImports.pixaAddPix((HandleRef)pixa, (HandleRef)pix, copyflag);
        }

        public static int pixaAddBox(this Pixa pixa, Box box, int copyflag)
        {
            if (null == pixa
             || null == box)
            {
                throw new ArgumentNullException("pixa, box cannot be null");
            }

            return Native.DllImports.pixaAddBox((HandleRef)pixa, (HandleRef)box, copyflag);
        }

        public static int pixaExtendArrayToSize(this Pixa pixa, int size)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("boxa cannot be null");
            }

            return Native.DllImports.pixaExtendArrayToSize((HandleRef)pixa, size);
        }

        // Pixa accessors
        public static int pixaGetCount(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetCount((HandleRef)pixa);
        }

        public static int pixaChangeRefcount(this Pixa pixa, int delta)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaChangeRefcount((HandleRef)pixa, delta);
        }

        public static Pix pixaGetPix(this Pixa pixa, int index, int accesstype)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaGetPix((HandleRef)pixa, index, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixaGetPixDimensions(this Pixa pixa, int index, out int pw, out int ph, out int pd)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetPixDimensions((HandleRef)pixa, index, out pw, out ph, out pd);
        }

        public static Boxa pixaGetBoxa(this Pixa pixa, int accesstype)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaGetBoxa((HandleRef)pixa, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static int pixaGetBoxaCount(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetBoxaCount((HandleRef)pixa);
        }

        public static Box pixaGetBox(this Pixa pixa, int index, int accesstype)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaGetBox((HandleRef)pixa, index, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Box(pointer);
            }
        }

        public static int pixaGetBoxGeometry(this Pixa pixa, int index, out int px, out int py, out int pw, out int ph)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetBoxGeometry((HandleRef)pixa, index, out px, out py, out pw, out ph);
        }

        public static int pixaSetBoxa(this Pixa pixa, Boxa boxa, int accesstype)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaSetBoxa((HandleRef)pixa, (HandleRef)boxa, accesstype);
        }

        public static IntPtr pixaGetPixArray(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetPixArray((HandleRef)pixa);
        }

        public static int pixaVerifyDepth(this Pixa pixa, out int pmaxdepth)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaVerifyDepth((HandleRef)pixa, out pmaxdepth);
        }

        public static int pixaIsFull(this Pixa pixa, out int pfullpa, out int pfullba)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaIsFull((HandleRef)pixa, out pfullpa, out pfullba);
        }

        public static int pixaCountText(this Pixa pixa, out int pntext)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaCountText((HandleRef)pixa, out pntext);
        }

        public static int pixaSetText(this Pixa pixa, Sarray sa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaSetText((HandleRef)pixa, (HandleRef)sa);
        }

        public static IntPtr pixaGetLinePtrs(this Pixa pixa, out int psize)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaGetLinePtrs((HandleRef)pixa, out psize);
        }

        // Pixa output info
        public static int pixaWriteStreamInfo(IntPtr fp, Pixa pixa)
        {
            if (IntPtr.Zero == fp
             || null == pixa)
            {
                throw new ArgumentNullException("fp, pixa cannot be null");
            }

            return Native.DllImports.pixaWriteStreamInfo(fp, (HandleRef)pixa);
        }

        // Pixa array modifiers
        public static int pixaReplacePix(this Pixa pixa, int index, Pix pix, Box box)
        {
            if (null == pixa
             || null == pix)
            {
                throw new ArgumentNullException("pixa, pix cannot be null");
            }

            return Native.DllImports.pixaReplacePix((HandleRef)pixa, index, (HandleRef)pix, (HandleRef)box);
        }

        public static int pixaInsertPix(this Pixa pixa, int index, Pix pixs, Box box)
        {
            if (null == pixa
             || null == pixs)
            {
                throw new ArgumentNullException("pixa, pix cannot be null");
            }

            return Native.DllImports.pixaInsertPix((HandleRef)pixa, index, (HandleRef)pixs, (HandleRef)box);
        }

        public static int pixaRemovePix(this Pixa pixa, int index)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaRemovePix((HandleRef)pixa, index);
        }

        public static int pixaRemovePixAndSave(this Pixa pixa, int index, out Pix ppix, out Box pbox)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            IntPtr ppixPtr, pboxPtr;
            var result = Native.DllImports.pixaRemovePixAndSave((HandleRef)pixa, index, out ppixPtr, out pboxPtr);
            ppix = new Pix(ppixPtr);
            pbox = new Box(pboxPtr);

            return result;
        }

        public static int pixaInitFull(this Pixa pixa, Pix pix, Box box)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaInitFull((HandleRef)pixa, (HandleRef)pix, (HandleRef)box);
        }

        public static int pixaClear(this Pixa pixa)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaClear((HandleRef)pixa);
        }

        // Pixa and Pixaa combination
        public static int pixaJoin(this Pixa pixad, Pixa pixas, int istart, int iend)
        {
            if (null == pixad)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaJoin((HandleRef)pixad, (HandleRef)pixas, istart, iend);
        }

        public static Pixa pixaInterleave(this Pixa pixa1, Pixa pixa2, int copyflag)
        {
            if (null == pixa1
             || null == pixa2)
            {
                throw new ArgumentNullException("pixa1, pixa2 cannot be null");
            }

            var pointer = Native.DllImports.pixaInterleave((HandleRef)pixa1, (HandleRef)pixa2, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaaJoin(this Pixaa paad, Pixaa paas, int istart, int iend)
        {
            if (null == paad)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaaJoin((HandleRef)paad, (HandleRef)paas, istart, iend);
        }

        // Pixaa creation, destruction
        public static Pixaa pixaaCreate(int n)
        {
            var pointer = Native.DllImports.pixaaCreate(n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);

            }
        }

        public static Pixaa pixaaCreateFromPixa(this Pixa pixa, int n, int type, int copyflag)
        {
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            var pointer = Native.DllImports.pixaaCreateFromPixa((HandleRef)pixa, n, type, copyflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);

            }
        }

        public static void pixaaDestroy(this Pixaa ppaa)
        {
            if (null == ppaa)
            {
                throw new ArgumentNullException("ppaa cannot be null");
            }

            var pointer = (IntPtr)ppaa;

            Native.DllImports.pixaaDestroy(ref pointer);
        }

        // Pixaa addition
        public static int pixaaAddPixa(this Pixaa paa, Pixa pixa, int copyflag)
        {
            if (null == paa
             || null == pixa)
            {
                throw new ArgumentNullException("paa, pixa cannot be null");
            }

            return Native.DllImports.pixaaAddPixa((HandleRef)paa, (HandleRef)pixa, copyflag);
        }

        public static int pixaaExtendArray(this Pixaa paa)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("baa cannot be null");
            }

            return Native.DllImports.pixaaExtendArray((HandleRef)paa);
        }

        public static int pixaaAddPix(this Pixaa paa, int index, Pix pix, Box box, int copyflag)
        {
            if (null == paa
             || null == box)
            {
                throw new ArgumentNullException("paa, box cannot be null");
            }

            return Native.DllImports.pixaaAddPix((HandleRef)paa, index, (HandleRef)pix, (HandleRef)box, copyflag);
        }

        public static int pixaaAddBox(this Pixaa paa, Box box, int copyflag)
        {
            if (null == paa
             || null == box)
            {
                throw new ArgumentNullException("paa, box cannot be null");
            }

            return Native.DllImports.pixaaAddBox((HandleRef)paa, (HandleRef)box, copyflag);
        }


        // Pixaa accessors
        public static int pixaaGetCount(this Pixaa paa, out Numa pna)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            IntPtr pnaPtr;
            var result = Native.DllImports.pixaaGetCount((HandleRef)paa, out pnaPtr);
            pna = new Numa(pnaPtr);

            return result;
        }

        public static Pixa pixaaGetPixa(this Pixaa paa, int index, int accesstype)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaGetPixa((HandleRef)paa, index, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Boxa pixaaGetBoxa(this Pixaa paa, int accesstype)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaGetBoxa((HandleRef)paa, accesstype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Boxa(pointer);
            }
        }

        public static Pix pixaaGetPix(this Pixaa paa, int index, int ipix, int accessflag)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            var pointer = Native.DllImports.pixaaGetPix((HandleRef)paa, index, ipix, accessflag);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static int pixaaVerifyDepth(this Pixaa paa, out int pmaxdepth)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaVerifyDepth((HandleRef)paa, out pmaxdepth);
        }

        public static int pixaaIsFull(this Pixaa paa, out int pfull)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaIsFull((HandleRef)paa, out pfull);
        }

        // Pixaa array modifiers
        public static int pixaaInitFull(this Pixaa paa, Pixa pixa)
        {
            if (null == paa
             || null == pixa)
            {
                throw new ArgumentNullException("paa, pixa cannot be null");
            }

            return Native.DllImports.pixaaInitFull((HandleRef)paa, (HandleRef)pixa);
        }

        public static int pixaaReplacePixa(this Pixaa paa, int index, Pixa pixa)
        {
            if (null == paa
             || null == pixa)
            {
                throw new ArgumentNullException("paa, pixa cannot be null");
            }

            return Native.DllImports.pixaaReplacePixa((HandleRef)paa, index, (HandleRef)pixa);
        }

        public static int pixaaClear(this Pixaa paa)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaClear((HandleRef)paa);
        }
         
        public static int pixaaTruncate(this Pixaa paa)
        {
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaTruncate((HandleRef)paa);
        }


        // Pixa serialized I/O(requires png support)
        public static Pixa pixaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static Pixa pixaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.pixaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        public static int pixaWrite(string filename, Pixa pixa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == pixa)
            {
                throw new ArgumentNullException("pixa cannot be null");
            }

            return Native.DllImports.pixaWrite(filename, (HandleRef)pixa);
        }

        public static int pixaWriteStream(IntPtr fp, Pixa pixa)
        {
            if (IntPtr.Zero == fp
             || null == pixa)
            {
                throw new ArgumentNullException("fp, boxa cannot be null");
            }

            return Native.DllImports.pixaWriteStream(fp, (HandleRef)pixa);
        }

        public static int pixaWriteMem(out IntPtr pdata, IntPtr psize, Pixa pixa)
        {
            if (IntPtr.Zero == psize
             || null == pixa)
            {
                throw new ArgumentNullException("psize, pixa cannot be null");
            }

            return Native.DllImports.pixaWriteMem(out pdata, psize, (HandleRef)pixa);
        }

        public static Pixa pixaReadBoth(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixaReadBoth(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixa(pointer);
            }
        }

        // Pixaa serialized I/O(requires png support)
        public static Pixaa pixaaReadFromFiles(string dirname, string substr, int first, int nfiles)
        {
            if (string.IsNullOrWhiteSpace(dirname))
            {
                throw new ArgumentNullException("dirname cannot be null");
            }

            if (!System.IO.Directory.Exists(dirname))
            {
                throw new System.IO.DirectoryNotFoundException("dirname does not exist");
            }

            var pointer = Native.DllImports.pixaaReadFromFiles(dirname, substr, first, nfiles);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static Pixaa pixaaRead(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }

            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException("filename does not exist");
            }

            var pointer = Native.DllImports.pixaaRead(filename);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static Pixaa pixaaReadStream(IntPtr fp)
        {
            if (IntPtr.Zero == fp)
            {
                throw new ArgumentNullException("fp cannot be null");
            }

            var pointer = Native.DllImports.pixaaReadStream(fp);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static Pixaa pixaaReadMem(IntPtr data, IntPtr size)
        {
            if (IntPtr.Zero == data
             || IntPtr.Zero == size)
            {
                throw new ArgumentNullException("data, size cannot be null");
            }

            var pointer = Native.DllImports.pixaaReadMem(data, size);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pixaa(pointer);
            }
        }

        public static int pixaaWrite(string filename, Pixaa paa)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename cannot be null");
            }
            if (null == paa)
            {
                throw new ArgumentNullException("paa cannot be null");
            }

            return Native.DllImports.pixaaWrite(filename, (HandleRef)paa);
        }

        public static int pixaaWriteStream(IntPtr fp, Pixaa paa)
        {
            if (IntPtr.Zero == fp
             || null == paa)
            {
                throw new ArgumentNullException("fp, paa cannot be null");
            }

            return Native.DllImports.pixaaWriteStream(fp, (HandleRef)paa);
        }

        public static int pixaaWriteMem(out IntPtr pdata, IntPtr psize, Pixaa paa)
        {
            if (IntPtr.Zero == psize
             || null == paa)
            {
                throw new ArgumentNullException("psize, paa cannot be null");
            }

            return Native.DllImports.pixaaWriteMem(out pdata, psize, (HandleRef)paa);
        }
    }
}
