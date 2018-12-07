using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Utils1
    {
        // Control of error, warning and info messages
        public static int setMsgSeverity(int newsev)
        {
            throw new NotImplementedException();
        }


        // Error return functions, invoked by macros
        public static int returnErrorInt(string msg, string procname, int ival)
        {
            throw new NotImplementedException();
        }

        public static float returnErrorFloat(string msg, string procname, float fval)
        {
            throw new NotImplementedException();
        }

        public static IntPtr returnErrorPtr(string msg, string procname, IntPtr pval)
        {
            throw new NotImplementedException();
        }


        // Test files for equivalence
        public static int filesAreIdentical(string fname1, string fname2, out int psame)
        {
            return Native.DllImports.filesAreIdentical(fname1, fname2, out psame);
        }


        // Byte-swapping data conversion
        public static ushort convertOnLittleEnd16(ushort shortin)
        {
            throw new NotImplementedException();
        }

        public static ushort convertOnBigEnd16(ushort shortin)
        {
            throw new NotImplementedException();
        }

        public static uint convertOnLittleEnd32(uint wordin)
        {
            throw new NotImplementedException();
        }

        public static uint convertOnBigEnd32(uint wordin)
        {
            throw new NotImplementedException();
        }


        // File corruption operation
        public static int fileCorruptByDeletion(string filein, float loc, float size, string fileout)
        {
            throw new NotImplementedException();
        }

        public static int fileCorruptByMutation(string filein, float loc, float size, string fileout)
        {
            throw new NotImplementedException();
        }


        // Generate random integer in given range
        public static int genRandomIntegerInRange(int range, int seed, out int pval)
        {
            throw new NotImplementedException();
        }


        // Simple math function
        public static int lept_roundftoi(float fval)
        {
            throw new NotImplementedException();
        }


        // 64-bit hash functions
        public static int l_hashStringToUint64(string str, out ulong phash)
        {
            throw new NotImplementedException();
        }

        public static int l_hashPtToUint64(int x, int y, out ulong phash)
        {
            throw new NotImplementedException();
        }

        public static int l_hashFloat64ToUint64(int nbuckets, double val, out ulong phash)
        {
            throw new NotImplementedException();
        }


        // Prime finders
        public static int findNextLargerPrime(int start, out uint pprime)
        {
            throw new NotImplementedException();
        }

        public static int lept_isPrime(ulong n, out int pis_prime, out uint pfactor)
        {
            throw new NotImplementedException();
        }


        // Gray code conversion
        public static uint convertBinaryToGrayCode(uint val)
        {
            throw new NotImplementedException();
        }

        public static uint convertGrayCodeToBinary(uint val)
        {
            throw new NotImplementedException();
        }


        // Leptonica version number
        public static IntPtr getLeptonicaVersion()
        {
            throw new NotImplementedException();
        }

        // Timing
        public static void startTimer(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static float stopTimer(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static IntPtr startTimerNested(IntPtr v)
        {
            throw new NotImplementedException();
        }

        public static float stopTimerNested(IntPtr rusage_start)
        {
            throw new NotImplementedException();
        }
        public static void l_getCurrentTime(out int sec, out int usec)
        {
            throw new NotImplementedException();
        }
        public static L_WallTimer startWallTimer(IntPtr v)
        {
            throw new NotImplementedException();
        }
        public static float stopWallTimer(this L_WallTimer ptimer)
        {
            throw new NotImplementedException();
        }
        public static IntPtr l_getFormattedDate()
        {
            throw new NotImplementedException();
        }
    }
}
