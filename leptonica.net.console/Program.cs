using Leptonica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leptonica.net.console
{
    class Program
    {
        private const string file = @"..\..\..\images\Test.png";

        public static void Main(string[] args)
        {
            testSimple();
           // testIsTable();
        }

        private static void testSimple()
        {
            Leptonica.Native.DllImports.LeptonicaDirectory = @"..\..\..\leptonica.net\lib";
            Pix pix = Pix.Read(file);
            Console.WriteLine("Expected {0} and returned {1}", 1421, pix.Width);
            Console.WriteLine("Expected {0} and returned {1}", 1949, pix.Height);
            Console.WriteLine("Expected {0} and returned {1}", ImageFileFormatTypes.IFF_PNG, pix.InputFormat);
            Console.WriteLine("Expected {0} and returned {1}", 96, pix.XRes);
            Console.WriteLine("Expected {0} and returned {1}", 96, pix.YRes);

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static void testIsTable()
        {
            int pscore;
            Leptonica.Native.DllImports.LeptonicaDirectory = @"..\..\..\leptonica.net\lib";
            Pix pix1 = Pix.Read(file);
            Pixa pixadb = PixaBasic.pixaCreate(0);
            PageSeg.pixDecideIfTable(pix1, null, Leptonica.Definitions.Pix.ImageOrientationFlags.L_PORTRAIT_MODE, out pscore, pixadb);
            var istable = (pscore >= 2) ? 1.0F : 0.0F;
            Console.WriteLine("Is this a table result: {0}", istable);
            pix1.pixDestroy();
            pixadb.pixaDestroy();

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
