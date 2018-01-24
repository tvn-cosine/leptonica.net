using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Sudoku
    {
        // Read input data from file or string
         public static IntPtr sudokuReadFile(string filename)
        {
            throw new NotImplementedException();
        }

        public static IntPtr sudokuReadString(string str)
        {
            throw new NotImplementedException();
        }


        // Create/destroy
        public static L_Sudoku sudokuCreate(IntPtr array)
        {
            throw new NotImplementedException();
        }

        public static void sudokuDestroy(this L_Sudoku psud)
        {
            throw new NotImplementedException();
        }


        // Solve the puzzle
        public static int sudokuSolve(this L_Sudoku sud)
        {
            throw new NotImplementedException();
        }


        // Test for uniqueness
        public static int sudokuTestUniqueness(IntPtr array, out int punique)
        {
            throw new NotImplementedException();
        }


        // Generation
        public static L_Sudoku sudokuGenerate(IntPtr array, int seed, int minelems, int maxtries)
        {
            throw new NotImplementedException();
        }


        // Output
        public static int sudokuOutput(this L_Sudoku sud, int arraytype)
        {
            throw new NotImplementedException();
        } 
    }
}
