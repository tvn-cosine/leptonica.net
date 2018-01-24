using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Utils2
    { 
        // Safe string procs 
        public static IntPtr stringNew(string src)
        {
            throw new NotImplementedException();
        }

        public static int stringCopy(string dest, string src, int n)
        {
            throw new NotImplementedException();
        }

        public static int stringReplace(out IntPtr pdest, string src)
        {
            throw new NotImplementedException();
        }

        public static int stringLength(string src, IntPtr size)
        {
            throw new NotImplementedException();
        }


        public static int stringCat(string dest, IntPtr size, string src)
        {
            throw new NotImplementedException();
        }

        public static IntPtr stringConcatNew(string first, IntPtr ptr)
        {
            throw new NotImplementedException();
        }

        public static IntPtr stringJoin(string src1, string src2)
        {
            throw new NotImplementedException();
        }

        public static int stringJoinIP(out IntPtr psrc1, string src2)
        {
            throw new NotImplementedException();
        }

        public static IntPtr stringReverse(string src)
        {
            throw new NotImplementedException();
        }

        public static IntPtr strtokSafe(string cstr, string seps, out IntPtr psaveptr)
        {
            throw new NotImplementedException();
        }

        public static int stringSplitOnToken(string cstr, string seps, out IntPtr phead, out IntPtr ptail)
        {
            throw new NotImplementedException();
        }


        // Find and replace string and array procs 
        public static IntPtr stringRemoveChars(string src, string remchars)
        {
            throw new NotImplementedException();
        }

        public static int stringFindSubstr(string src, string sub, out int ploc)
        {
            throw new NotImplementedException();
        }

        public static IntPtr stringReplaceSubstr(string src, string sub1, string sub2, out int pfound, out int ploc)
        {
            throw new NotImplementedException();
        }

        public static IntPtr stringReplaceEachSubstr(string src, string sub1, string sub2, out int pcount)
        {
            throw new NotImplementedException();
        }

        public static IntPtr arrayFindEachSequence(IntPtr data, IntPtr datalen, IntPtr sequence, IntPtr seqlen)
        {
            throw new NotImplementedException();
        }

        public static int arrayFindSequence(IntPtr data, IntPtr datalen, IntPtr sequence, IntPtr seqlen, out int poffset, out int pfound)
        {
            throw new NotImplementedException();
        }

        // Safe realloc 
        public static IntPtr reallocNew(IntPtr pindata, int oldsize, int newsize)
        {
            throw new NotImplementedException();
        }


        // Read and write between file and memory 
        public static IntPtr l_binaryRead(string filename, out IntPtr pnbytes)
        {
            throw new NotImplementedException();
        }

        public static IntPtr l_binaryReadStream(IntPtr fp, IntPtr pnbytes)
        {
            throw new NotImplementedException();
        }

        public static IntPtr l_binaryReadSelect(string filename, IntPtr start, IntPtr nbytes, out IntPtr pnread)
        {
            throw new NotImplementedException();
        }

        public static IntPtr l_binaryReadSelectStream(IntPtr fp, IntPtr start, IntPtr nbytes, IntPtr pnread)
        {
            throw new NotImplementedException();
        }

        public static int l_binaryWrite(string filename, string operation, IntPtr data, IntPtr nbytes)
        {
            throw new NotImplementedException();
        }

        public static IntPtr nbytesInFile(string filename)
        {
            throw new NotImplementedException();
        }

        public static IntPtr fnbytesInFile(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        // Copy in memory 
        public static IntPtr l_binaryCopy(IntPtr datas, IntPtr size)
        {
            throw new NotImplementedException();
        }

        // File copy operations 
        public static int fileCopy(string srcfile, string newfile)
        {
            throw new NotImplementedException();
        }

        public static int fileConcatenate(string srcfile, string destfile)
        {
            throw new NotImplementedException();
        }

        public static int fileAppendString(string filename, string str)
        {
            throw new NotImplementedException();
        }


        // Multi-platform functions for opening file streams 
        public static IntPtr fopenReadStream(string filename)
        {
            throw new NotImplementedException();
        }

        public static IntPtr fopenWriteStream(string filename, string modestring)
        {
            throw new NotImplementedException();
        }

        public static IntPtr fopenReadFromMemory(IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }


        // Opening a windows tmpfile for writing 
        public static IntPtr fopenWriteWinTempfile()
        {
            throw new NotImplementedException();
        }


        // Multi-platform functions that avoid C-runtime boundary crossing  with Windows DLLs 
        public static IntPtr lept_fopen(string filename, string mode)
        {
            throw new NotImplementedException();
        }

        public static int lept_fclose(IntPtr fp)
        {
            throw new NotImplementedException();
        }

        public static IntPtr lept_calloc(IntPtr nmemb, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static void lept_free(IntPtr ptr)
        {
            throw new NotImplementedException();
        }


        // Multi-platform file system operations in temp directories 
        public static int lept_mkdir(string subdir)
        {
            throw new NotImplementedException();
        }

        public static int lept_rmdir(string subdir)
        {
            throw new NotImplementedException();
        }

        public static void lept_direxists(string dir, out int pexists)
        {
            throw new NotImplementedException();
        }

        public static int lept_rm_match(string subdir, string substr)
        {
            throw new NotImplementedException();
        }

        public static int lept_rm(string subdir, string tail)
        {
            throw new NotImplementedException();
        }

        public static int lept_rmfile(string filepath)
        {
            throw new NotImplementedException();
        }

        public static int lept_mv(string srcfile, string newdir, string newtail, out IntPtr pnewpath)
        {
            throw new NotImplementedException();
        }

        public static int lept_cp(string srcfile, string newdir, string newtail, out IntPtr pnewpath)
        {
            throw new NotImplementedException();
        }


        // General file name operations 
        public static int splitPathAtDirectory(string pathname, out IntPtr pdir, out IntPtr ptail)
        {
            throw new NotImplementedException();
        }

        public static int splitPathAtExtension(string pathname, out IntPtr pbasename, out IntPtr pextension)
        {
            throw new NotImplementedException();
        }

        public static IntPtr pathJoin(string dir, string fname)
        {
            throw new NotImplementedException();
        }

        public static IntPtr appendSubdirs(string basedir, string subdirs)
        {
            throw new NotImplementedException();
        }


        // Special file name operations 
        public static int convertSepCharsInPath(string path, int type)
        {
            throw new NotImplementedException();
        }

        public static IntPtr genPathname(string dir, string fname)
        {
            throw new NotImplementedException();
        }

        public static int makeTempDirname(string result, IntPtr nbytes, string subdir)
        {
            throw new NotImplementedException();
        }

        public static int modifyTrailingSlash(string path, IntPtr nbytes, int flag)
        {
            throw new NotImplementedException();
        }

        public static IntPtr l_makeTempFilename()
        {
            throw new NotImplementedException();
        }

        public static int extractNumberFromFilename(string fname, int numpre, int numpost)
        {
            throw new NotImplementedException();
        }
    }
}
