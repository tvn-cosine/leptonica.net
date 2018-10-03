/*-------------------------------------------------------------------------*
 *
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
 * We would like to use the following set of definitions:
 *
 *      #define   PIX_SRC      0xc
 *      #define   PIX_DST      0xa
 *      #define   PIX_NOT(op)  ((op) ^ 0xf)
 *      #define   PIX_CLR      0x0
 *      #define   PIX_SET      0xf
 *
 * Now, these definitions differ from Sun's, in that Sun
 * left-shifted each value by 1 pixel, and used the least
 * significant bit as a flag for the "pseudo-operation" of
 * clipping.  We don't need this bit, because it is both
 * efficient and safe ALWAYS to clip the rectangles to the src
 * and dest images, which is what we do.  See the notes in rop.h
 * on the general choice of these bit flags.
 *
 * However, if you include Sun's xview package, you will get their
 * definitions, and because I like using these flags, we will
 * adopt the original Sun definitions to avoid redefinition conflicts.
 *
 * Then we have, for reference, the following 16 unique op flags:
 *
 *      PIX_CLR                           00000             0x0
 *      PIX_SET                           11110             0x1e
 *      PIX_SRC                           11000             0x18
 *      PIX_DST                           10100             0x14
 *      PIX_NOT(PIX_SRC)                  00110             0x06
 *      PIX_NOT(PIX_DST)                  01010             0x0a
 *      PIX_SRC | PIX_DST                 11100             0x1c
 *      PIX_SRC & PIX_DST                 10000             0x10
 *      PIX_SRC ^ PIX_DST                 01100             0x0c
 *      PIX_NOT(PIX_SRC) | PIX_DST        10110             0x16
 *      PIX_NOT(PIX_SRC) & PIX_DST        00100             0x04
 *      PIX_SRC | PIX_NOT(PIX_DST)        11010             0x1a
 *      PIX_SRC & PIX_NOT(PIX_DST)        01000             0x08
 *      PIX_NOT(PIX_SRC | PIX_DST)        00010             0x02
 *      PIX_NOT(PIX_SRC & PIX_DST)        01110             0x0e
 *      PIX_NOT(PIX_SRC ^ PIX_DST)        10010             0x12
 *
 *-------------------------------------------------------------------------*/
//#define   PIX_SRC      (0xc << 1)
//#define   PIX_DST      (0xa << 1)
//#define   PIX_NOT(op)  ((op) ^ 0x1e)
//#define   PIX_CLR      (0x0 << 1)
//#define   PIX_SET      (0xf << 1)

//#define   PIX_PAINT    (PIX_SRC | PIX_DST)
//#define   PIX_MASK     (PIX_SRC & PIX_DST)
//#define   PIX_SUBTRACT (PIX_DST & PIX_NOT(PIX_SRC))
//#define   PIX_XOR      (PIX_SRC ^ PIX_DST)
namespace Leptonica
{
    /// <summary>
    /// Flags used in raster operations (rop)
    /// </summary>
    [System.Flags]
    public enum FlagsForRasterOps
    {
        /// <summary>
        /// PIX_CLR                           00000             0x0
        /// PIX_CLR = (0x0 << 1)
        /// </summary>
        PIX_CLR = 0x0 << 1,

        /// <summary>
        /// PIX_SET                           11110             0x1e
        /// PIX_SET = (0xf << 1)
        /// </summary>
        PIX_SET = 0xf << 1,

        /// <summary>
        /// PIX_SRC                           11000             0x18
        /// PIX_SRC = (0xc << 1)
        /// </summary>
        PIX_SRC = 0xc << 1,

        /// <summary>
        /// PIX_DST                           10100             0x14
        /// PIX_DST = (0xa << 1)
        /// </summary>
        PIX_DST = 0xa << 1,

        /// <summary>
        /// PIX_NOT(PIX_SRC)                  00110             0x06
        /// </summary>
        PIX_NOT__PIX_SRC_ = 0x06,

        /// <summary>
        /// PIX_NOT(PIX_DST)                  01010             0x0a
        /// </summary>
        PIX_NOT__PIX_DST_ = 0x0a,

        /// <summary>
        /// PIX_SRC | PIX_DST                 11100             0x1c
        /// </summary>
        PIX_SRC_BITWISE_OR_PIX_DST = PIX_SRC | PIX_DST,

        /// <summary>
        /// PIX_SRC & PIX_DST                 10000             0x10
        /// </summary>
        PIX_SRC_BITWISE_AND_PIX_DST = PIX_SRC & PIX_DST,

        /// <summary>
        /// PIX_SRC ^ PIX_DST                 01100             0x0c
        /// </summary>
        PIX_SRC_BITWISE_XOR_PIX_DST = PIX_SRC ^ PIX_DST,

        /// <summary>
        /// PIX_NOT(PIX_SRC) | PIX_DST        10110             0x16
        /// </summary>
        PIX_NOT__PIX_SRC__BITWISE_OR_PIX_DST = 0x16,

        /// <summary>
        /// PIX_NOT(PIX_SRC) & PIX_DST        00100             0x04
        /// </summary>
        PIX_NOT__PIX_SRC__BITWISE_AND_PIX_DST = 0x04,

        /// <summary>
        /// PIX_SRC | PIX_NOT(PIX_DST)        11010             0x1a
        /// </summary>
        PIX_SRC_BITWISE_OR_PIX_NOT__PIX_DST_ = 0x1a,

        /// <summary>
        /// PIX_SRC & PIX_NOT(PIX_DST)        01000             0x08
        /// </summary>
        PIX_SRC_BITWISE_AND_PIX_NOT__PIX_DST_ = 0x08,

        /// <summary>
        /// PIX_NOT(PIX_SRC | PIX_DST)        00010             0x02
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_OR_PIX_DST_ = 0x02,

        /// <summary>
        /// PIX_NOT(PIX_SRC & PIX_DST)        01110             0x0e
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_AND_PIX_DST_ = 0x0e,

        /// <summary>
        /// PIX_NOT(PIX_SRC ^ PIX_DST)        10010             0x12
        /// </summary>
        PIX_NOT__PIX_SRC_BITWISE_XOR_PIX_DST_ = 0x12,

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
