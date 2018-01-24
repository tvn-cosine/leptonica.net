using System;
using System.Runtime.InteropServices;

namespace Leptonica 
{
    public static class DwaComb2
    { 
        // Top-level fast binary morphology with auto-generated sels
        public static Pix pixMorphDwa_2(this Pix pixd, Pix pixs, int operation, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixMorphDwa_2((HandleRef)pixd, (HandleRef)pixs, operation, selname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public static Pix pixFMorphopGen_2(this Pix pixd, Pix pixs, int operation, string selname)
        {
            if (null == pixs)
            {
                throw new ArgumentNullException("pixs cannot be null");
            }

            var pointer = Native.DllImports.pixFMorphopGen_2((HandleRef)pixd, (HandleRef)pixs, operation, selname);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Pix(pointer);
            }
        }

        public const int NUM_SELS_GENERATED = 76;
        public static string[] SEL_NAMES = {
                             "sel_comb_4h",
                             "sel_comb_4v",
                             "sel_comb_5h",
                             "sel_comb_5v",
                             "sel_comb_6h",
                             "sel_comb_6v",
                             "sel_comb_7h",
                             "sel_comb_7v",
                             "sel_comb_8h",
                             "sel_comb_8v",
                             "sel_comb_9h",
                             "sel_comb_9v",
                             "sel_comb_10h",
                             "sel_comb_10v",
                             "sel_comb_12h",
                             "sel_comb_12v",
                             "sel_comb_14h",
                             "sel_comb_14v",
                             "sel_comb_15h",
                             "sel_comb_15v",
                             "sel_comb_16h",
                             "sel_comb_16v",
                             "sel_comb_18h",
                             "sel_comb_18v",
                             "sel_comb_20h",
                             "sel_comb_20v",
                             "sel_comb_21h",
                             "sel_comb_21v",
                             "sel_comb_22h",
                             "sel_comb_22v",
                             "sel_comb_24h",
                             "sel_comb_24v",
                             "sel_comb_25h",
                             "sel_comb_25v",
                             "sel_comb_27h",
                             "sel_comb_27v",
                             "sel_comb_28h",
                             "sel_comb_28v",
                             "sel_comb_30h",
                             "sel_comb_30v",
                             "sel_comb_32h",
                             "sel_comb_32v",
                             "sel_comb_33h",
                             "sel_comb_33v",
                             "sel_comb_35h",
                             "sel_comb_35v",
                             "sel_comb_36h",
                             "sel_comb_36v",
                             "sel_comb_39h",
                             "sel_comb_39v",
                             "sel_comb_40h",
                             "sel_comb_40v",
                             "sel_comb_42h",
                             "sel_comb_42v",
                             "sel_comb_44h",
                             "sel_comb_44v",
                             "sel_comb_45h",
                             "sel_comb_45v",
                             "sel_comb_48h",
                             "sel_comb_48v",
                             "sel_comb_49h",
                             "sel_comb_49v",
                             "sel_comb_50h",
                             "sel_comb_50v",
                             "sel_comb_52h",
                             "sel_comb_52v",
                             "sel_comb_54h",
                             "sel_comb_54v",
                             "sel_comb_55h",
                             "sel_comb_55v",
                             "sel_comb_56h",
                             "sel_comb_56v",
                             "sel_comb_60h",
                             "sel_comb_60v",
                             "sel_comb_63h",
                             "sel_comb_63v"};
    }
}
