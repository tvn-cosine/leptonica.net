/*------------------------------------------------------------------------*
 *!
 * <pre>
 * The following operation bit flags have been modified from
 * Sun's pixrect.h.
 *
 * The 'op' in 'rasterop' is represented by an integer
 * composed with Boolean functions using the set of five integers
 * given below.  The integers, and the op codes resulting from
 * boolean expressions on them, need only be in the range from 0 to 15.
 * The function is applied on a per-pixel basis.
 *
 * Examples: the op code representing ORing the src and dest
 * is computed using the bit OR, as PIX_SRC | PIX_DST;  the op
 * code representing XORing src and dest is found from
 * PIX_SRC ^ PIX_DST;  the op code representing ANDing src and dest
 * is found from PIX_SRC & PIX_DST.  Note that
 * PIX_NOT(PIX_CLR) = PIX_SET, and v.v., as they must be.
 *
 * We use the following set of definitions:
 *
 *      #define   PIX_SRC      0xc
 *      #define   PIX_DST      0xa
 *      #define   PIX_NOT(op)  (op) ^ 0xf
 *      #define   PIX_CLR      0x0
 *      #define   PIX_SET      0xf
 *
 * These definitions differ from Sun's, in that Sun left-shifted
 * each value by 1 pixel, and used the least significant bit as a
 * flag for the "pseudo-operation" of clipping.  We don't need
 * this bit, because it is both efficient and safe ALWAYS to clip
 * the rectangles to the src and dest images, which is what we do.
 * See the notes in rop.h on the general choice of these bit flags.
 *
 * [If for some reason you need compatibility with Sun's xview package,
 * you can adopt the original Sun definitions to avoid redefinition conflicts:
 *
 *      #define   PIX_SRC      (0xc << 1)
 *      #define   PIX_DST      (0xa << 1)
 *      #define   PIX_NOT(op)  ((op) ^ 0x1e)
 *      #define   PIX_CLR      (0x0 << 1)
 *      #define   PIX_SET      (0xf << 1)
 * ]
 *
 * We have, for reference, the following 16 unique op flags:
 *
 *      PIX_CLR                           0000             0x0
 *      PIX_SET                           1111             0xf
 *      PIX_SRC                           1100             0xc
 *      PIX_DST                           1010             0xa
 *      PIX_NOT(PIX_SRC)                  0011             0x3
 *      PIX_NOT(PIX_DST)                  0101             0x5
 *      PIX_SRC | PIX_DST                 1110             0xe
 *      PIX_SRC & PIX_DST                 1000             0x8
 *      PIX_SRC ^ PIX_DST                 0110             0x6
 *      PIX_NOT(PIX_SRC) | PIX_DST        1011             0xb
 *      PIX_NOT(PIX_SRC) & PIX_DST        0010             0x2
 *      PIX_SRC | PIX_NOT(PIX_DST)        1101             0xd
 *      PIX_SRC & PIX_NOT(PIX_DST)        0100             0x4
 *      PIX_NOT(PIX_SRC | PIX_DST)        0001             0x1
 *      PIX_NOT(PIX_SRC & PIX_DST)        0111             0x7
 *      PIX_NOT(PIX_SRC ^ PIX_DST)        1001             0x9
 *
 * </pre>
 *-------------------------------------------------------------------------*/
//#define PIX_SRC      (0xc)                        /*!< use source pixels      */
//#define PIX_DST      (0xa)                        /*!< use destination pixels */
//#define PIX_NOT(op)  ((op) ^ 0x0f)                /*!< invert operation %op   */
//#define PIX_CLR      (0x0)                        /*!< clear pixels           */
//#define PIX_SET      (0xf)                        /*!< set pixels             */
//#define PIX_PAINT    (PIX_SRC | PIX_DST)          /*!< paint = src | dst      */
//#define PIX_MASK     (PIX_SRC & PIX_DST)          /*!< mask = src & dst       */
//#define PIX_SUBTRACT (PIX_DST & PIX_NOT(PIX_SRC)) /*!< subtract =             */
//#define PIX_XOR      (PIX_SRC ^ PIX_DST)          /*!< xor = src ^ dst        */
namespace Leptonica
{
    /// <summary>
    /// Flags used in raster operations (rop)
    /// </summary>
    [System.Flags]
    public enum FlagsForRasterOps
    {
        /// <summary>
        /// PIX_CLR                           0000             0x0
        /// </summary>
        PIX_CLR = 0x0,

        /// <summary>
        /// PIX_SET                           1111             0xf
        /// </summary>
        PIX_SET = 0xf,

        /// <summary>
        /// PIX_SRC                           1100             0xc
        /// </summary>
        PIX_SRC = 0xc,

        /// <summary>
        /// PIX_DST                           1010             0xa
        /// </summary>
        PIX_DST = 0xa,

        /// <summary>
        /// PIX_NOT(PIX_SRC)                  0011             0x3
        /// </summary>
        PIX_NOT__PIX_SRC_ = 0x3,

        /// <summary>
        /// PIX_NOT(PIX_DST)                  0101             0x5
        /// </summary>
        PIX_NOT__PIX_DST_ = 0x5,

        /// <summary>
        /// PIX_SRC | PIX_DST                 1110             0xe
        /// </summary>
        PIX_SRC_BITWISE_OR_PIX_DST = PIX_SRC | PIX_DST,

        /// <summary>
        /// PIX_SRC & PIX_DST                 1000             0x8
        /// </summary>
        PIX_SRC_BITWISE_AND_PIX_DST = PIX_SRC & PIX_DST,

        /// <summary>
        /// PIX_SRC ^ PIX_DST                 0110             0x6
        /// </summary>
        PIX_SRC_BITWISE_XOR_PIX_DST = PIX_SRC ^ PIX_DST,

        /// <summary>
        /// PIX_NOT(PIX_SRC) | PIX_DST        1011             0xb
        /// </summary>
        PIX_NOT__PIX_SRC__BITWISE_OR_PIX_DST = 0xb,

        /// <summary>
        /// PIX_NOT(PIX_SRC) & PIX_DST        0010             0x2
        /// </summary>
        PIX_NOT__PIX_SRC__BITWISE_AND_PIX_DST = 0x2,

        /// <summary>
        /// PIX_SRC | PIX_NOT(PIX_DST)        1101             0xd
        /// </summary>
        PIX_SRC_BITWISE_OR_PIX_NOT__PIX_DST_ = 0xd,

        /// <summary>
        /// PIX_SRC & PIX_NOT(PIX_DST)        0100             0x4
        /// </summary>
        PIX_SRC_BITWISE_AND_PIX_NOT__PIX_DST_ = 0x4,

        /// <summary>
        /// PIX_NOT(PIX_SRC | PIX_DST)        0001             0x1
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_OR_PIX_DST_ = 0x1,

        /// <summary>
        /// PIX_NOT(PIX_SRC & PIX_DST)        0111             0x7
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_AND_PIX_DST_ = 0x7,

        /// <summary>
        /// PIX_NOT(PIX_SRC ^ PIX_DST)        1001             0x9
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_XOR_PIX_DST_ = 0x9,

        /// <summary>
        /// PIX_PAINT    (PIX_SRC | PIX_DST)
        /// </summary>
        PIX_PAINT = PIX_SRC | PIX_DST,

        /// <summary>
        /// PIX_MASK     (PIX_SRC & PIX_DST)
        /// </summary>
        PIX_MASK = PIX_SRC & PIX_DST,

        /// <summary>
        /// PIX_SUBTRACT (PIX_DST & PIX_NOT(PIX_SRC))
        /// </summary>
        PIX_SUBTRACT = PIX_DST & PIX_NOT__PIX_SRC_,

        /// <summary>
        /// PIX_XOR      (PIX_SRC ^ PIX_DST)
        /// </summary>
        PIX_XOR = PIX_SRC_BITWISE_XOR_PIX_DST
    }
}
