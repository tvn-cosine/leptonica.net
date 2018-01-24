using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class ReadBarcode
    {
        // Top level
        public static Sarray pixProcessBarcodes(this Pix pixs, int format, int method, out Sarray psaw, int debugflag)
        {
            throw new NotImplementedException();
        }


        // Next levels
        public static Pixa pixExtractBarcodes(this Pix pixs, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Sarray pixReadBarcodes(this Pixa pixa, int format, int method, out Sarray psaw, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Numa pixReadBarcodeWidths(this Pix pixs, int method, int debugflag)
        {
            throw new NotImplementedException();
        }


        // Location
        public static Boxa pixLocateBarcodes(this Pix pixs, int thresh, out Pix ppixb, out Pix ppixm)
        {
            throw new NotImplementedException();
        }


        // Extraction and deskew
        public static Pix pixDeskewBarcode(this Pix pixs, Pix pixb, HandleRef box, int margin, int threshold, out float pangle, out float pconf)
        {
            throw new NotImplementedException();
        }


        // Process to get line widths
        public static Numa pixExtractBarcodeWidths1(this Pix pixs, float thresh, float binfract, out Numa pnaehist, out Numa pnaohist, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Numa pixExtractBarcodeWidths2(this Pix pixs, float thresh, out float pwidth, out Numa pnac, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Numa pixExtractBarcodeCrossings(this Pix pixs, float thresh, int debugflag)
        {
            throw new NotImplementedException();
        }


        // Signal processing for barcode widths
        public static Numa numaQuantizeCrossingsByWidth(this Numa nas, float binfract, out Numa pnaehist, out Numa pnaohist, int debugflag)
        {
            throw new NotImplementedException();
        }

        public static Numa numaQuantizeCrossingsByWindow(this Numa nas, float ratio, out float pwidth, out float pfirstloc, out Numa pnac, int debugflag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Currently supported formats
        /// </summary>
        public static FlagsForBarcodeFormats[] SupportedBarcodeFormat = {
             FlagsForBarcodeFormats. L_BF_CODE2OF5,
             FlagsForBarcodeFormats.  L_BF_CODEI2OF5,
             FlagsForBarcodeFormats.  L_BF_CODE93,
             FlagsForBarcodeFormats.  L_BF_CODE39,
             FlagsForBarcodeFormats.  L_BF_CODABAR,
             FlagsForBarcodeFormats.  L_BF_UPCA,
             FlagsForBarcodeFormats.  L_BF_EAN13
        };

        /// <summary>
        /// Currently supported format names 
        /// </summary>
        public static string[] SupportedBarcodeFormatName = {
            "Code2of5",
            "CodeI2of5",
            "Code93",
            "Code39",
            "Codabar",
            "Upca",
            "Ean13"
        };

        /// <summary>
        /// Number of formats
        /// </summary>
        public const int NumSupportedBarcodeFormats = 7;


        /// <summary>
        /// Code 2 of 5 symbology    
        /// </summary>
        public static string[] Code2of5 = {
            "111121211", "211111112", "112111112", "212111111",   /* 0 - 3 */
            "111121112", "211121111", "112121111", "111111212",   /* 4 - 7 */
            "211111211", "112111211",                             /* 8 - 9 */
            "21211", "21112"                                      /* Start, Stop */
        };

        public const int C25_START = 10;
        public const int C25_STOP = 11;


        /// <summary>
        /// Code Interleaved 2 of 5 symbology   
        /// </summary>
        public static string[] CodeI2of5 = {
            "11221", "21112", "12112", "22111", "11212",    /*  0 - 4 */
            "21211", "12211", "11122", "21121", "12121",    /*  5 - 9 */
            "1111", "211"                                   /*  start, stop */
        };

        public const int CI25_START = 10;
        public const int CI25_STOP = 11;

        /// <summary>
        /// Code 93 symbology  
        /// </summary>
        public static string[] Code93 = {
            "131112", "111213", "111312", "111411", "121113", /* 0: 0 - 4 */
            "121212", "121311", "111114", "131211", "141111", /* 5: 5 - 9 */
            "211113", "211212", "211311", "221112", "221211", /* 10: A - E */
            "231111", "112113", "112212", "112311", "122112", /* 15: F - J */
            "132111", "111123", "111222", "111321", "121122", /* 20: K - O */
            "131121", "212112", "212211", "211122", "211221", /* 25: P - T */
            "221121", "222111", "112122", "112221", "122121", /* 30: U - Y */
            "123111", "121131", "311112", "311211", "321111", /* 35: Z,-,.,SP,$ */
            "112131", "113121", "211131", "131221", "312111", /* 40: /,+,%,($),(%) */
            "311121", "122211", "111141"                      /* 45: (/),(+), Start */
        };

        /// <summary>
        /// Use "[]{}#" to represent special codes 43-47 
        /// </summary>
        public static string Code93Val = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%[]{}#";

        public const int C93_START = 47;
        public const int C93_STOP = 47;


        /// <summary>
        ///  Code 39 symbology  
        /// </summary>
        public static string[] Code39 = {
            "111221211", "211211112", "112211112", "212211111",  /* 0: 0 - 3      */
            "111221112", "211221111", "112221111", "111211212",  /* 4: 4 - 7      */
            "211211211", "112211211", "211112112", "112112112",  /* 8: 8 - B      */
            "212112111", "111122112", "211122111", "112122111",  /* 12: C - F     */
            "111112212", "211112211", "112112211", "111122211",  /* 16: G - J     */
            "211111122", "112111122", "212111121", "111121122",  /* 20: K - N     */
            "211121121", "112121121", "111111222", "211111221",  /* 24: O - R     */
            "112111221", "111121221", "221111112", "122111112",  /* 28: S - V     */
            "222111111", "121121112", "221121111", "122121111",  /* 32: W - Z     */
            "121111212", "221111211", "122111211", "121212111",  /* 36: -,.,SP,$  */
            "121211121", "121112121", "111212121", "121121211"   /* 40: /,+,%,*   */
        };

        /// <summary>
        /// Use "*" to represent the Start and Stop codes (43)
        /// </summary>
        public static string Code39Val =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";

        public const int C39_START = 43;
        public const int C39_STOP = 43;


        /// <summary>
        /// Codabar symbology  
        /// </summary>
        public static string[] Codabar = {
            "1111122", "1111221", "1112112", "2211111", "1121121", /* 0: 0 - 4      */
            "2111121", "1211112", "1211211", "1221111", "2112111", /* 5: 5 - 9      */
            "1112211", "1122111", "2111212", "2121112", "2121211", /* 10: -,$,:,/,. */
            "1121212", "1122121", "1212112", "1112122", "1112221"  /* 15: +,A,B,C,D */
        };


        /// <summary>
        /// Ascii representations for codes 16-19: (A or T), (B or N), (C or *), (D or E).  These are used in pairs for the Start and Stop codes.
        /// </summary>
        public static string CodabarVal = "0123456789-$:/.+ABCD";



        /// <summary>
        ///  UPC-A symbology  
        /// </summary>
        public static string[] Upca = {
            "3211", "2221", "2122", "1411", "1132",  /* 0: 0 - 4              */
            "1231", "1114", "1312", "1213", "3112",  /* 5: 5 - 9              */
            "111", "111", "11111"                    /* 10: Start, Stop, Mid  */
        };

        public const int UPCA_START = 10;
        public const int UPCA_STOP = 11;
        public const int UPCA_MID = 12;

        /// <summary>
        /// Code128 symbology 
        /// </summary>
        public static string[] Code128 = {
            "212222", "222122", "222221", "121223", "121322",    /*  0 - 4 */
            "131222", "122213", "122312", "132212", "221213",    /*  5 - 9 */
            "221312", "231212", "112232", "122132", "122231",    /* 10 - 14 */
            "113222", "123122", "123221", "223211", "221132",    /* 15 - 19 */
            "221231", "213212", "223112", "312131", "311222",    /* 20 - 24 */
            "321122", "321221", "312212", "322112", "322211",    /* 25 - 29 */
            "212123", "212321", "232121", "111323", "131123",    /* 30 - 34 */
            "131321", "112313", "132113", "132311", "211313",    /* 35 - 39 */
            "231113", "231311", "112133", "112331", "132131",    /* 40 - 44 */
            "113123", "113321", "133121", "313121", "211331",    /* 45 - 49 */
            "231131", "213113", "213311", "213131", "311123",    /* 50 - 54 */
            "311321", "331121", "312113", "312311", "332111",    /* 55 - 59 */
            "314111", "221411", "431111", "111224", "111422",    /* 60 - 64 */
            "121124", "121421", "141122", "141221", "112214",    /* 65 - 69 */
            "112412", "122114", "122411", "142112", "142211",    /* 70 - 74 */
            "241211", "221114", "413111", "241112", "134111",    /* 75 - 79 */
            "111242", "121142", "121241", "114212", "124112",    /* 80 - 84 */
            "124211", "411212", "421112", "421211", "212141",    /* 85 - 89 */
            "214121", "412121", "111143", "111341", "131141",    /* 90 - 94 */
            "114113", "114311", "411113", "411311", "113141",    /* 95 - 99 */
            "114131", "311141", "411131", "211412", "211214",    /* 100 - 104 */
            "211232", "2331112"                                  /* 105 - 106 */
        };

        /// <summary>
        /// in A or B only; in C it is 96
        /// </summary>
        public const int C128_FUN_3 = 96;
        /// <summary>
        /// in A or B only; in C it is 97
        /// </summary>
        public const int C128_FUNC_2 = 97;
        /// <summary>
        /// in A or B only; in C it is 98
        /// </summary>
        public const int C128_SHIFT = 98;
        /// <summary>
        /// in A or B only; in C it is 99
        /// </summary>
        public const int C128_GOTO_C = 99;
        public const int C128_GOTO_B = 100;
        public const int C128_GOTO_A = 101;
        public const int C128_FUNC_1 = 102;
        public const int C128_START_A = 103;
        public const int C128_START_B = 104;
        public const int C128_START_C = 105;
        public const int C128_STOP = 106;
        /// <summary>
        /// code 128 symbols are 11 units
        /// </summary>
        public const int C128_SYMBOL_WIDTH = 11;
    }
}
