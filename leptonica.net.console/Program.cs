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
        private const string file = "Test.png";

        public static void Main(string[] args)
        {
            Leptonica.Native.DllImports.LeptonicaDirectory = @"C:\Test\leptonica"; 
            Pix pix = Pix.Read(file); 
            Console.WriteLine("Expected {0} and returned {1}", 1421, pix.Width);
            Console.WriteLine("Expected {0} and returned {1}", 1949, pix.Height);
            Console.WriteLine("Expected {0} and returned {1}", ImageFileFormatTypes.IFF_PNG, pix.InputFormat);
            Console.WriteLine("Expected {0} and returned {1}", 96, pix.XRes);
            Console.WriteLine("Expected {0} and returned {1}", 96, pix.YRes);

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
