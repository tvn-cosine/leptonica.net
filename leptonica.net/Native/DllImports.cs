using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Leptonica.Native
{
    public class DllImports
    {
        private const string pattern = @"lept";
        private const string x64 = @"x64";
        private const string x86 = @"x86";
#if DEBUG
        private const string leptonicaDllName = "leptonica-1.77.0d.dll";
#else
        private const string leptonicaDllName = "leptonica-1.77.0.dll";
#endif

        static DllImports()
        {
            if (string.IsNullOrWhiteSpace(LeptonicaDirectory))
            {
                LeptonicaDirectory = Environment.CurrentDirectory;
            }
            CopyDlls();
        }

        private static string leptonicaDirectory;
        public static string LeptonicaDirectory
        {
            get
            {
                return leptonicaDirectory;
            }
            set
            {
                if (value != leptonicaDirectory)
                {
                    if (Directory.Exists(value))
                    {
                        leptonicaDirectory = value;
                        CopyDlls();
                    }
                }
            }
        }

        public static void CopyDlls()
        {
            string directory = string.Format("{0}\\{1}", LeptonicaDirectory, x86);

            if (Architecture.is64BitProcess)
            {
                directory = string.Format("{0}\\{1}", LeptonicaDirectory, x64);
            }

            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Name.StartsWith(pattern)) // must copy
                    {
                        string newLocation = string.Format("{0}\\{1}",
                                                    Environment.CurrentDirectory,
                                                    fi.Name);
                        if (!File.Exists(newLocation))
                        {
                            File.Copy(file, newLocation, true);
                        }
                    }
                }
            }
        }

        internal static int pixWriteStreamBmp(object cdata, HandleRef size)
        {
            throw new NotImplementedException();
        }

        #region internal constants
        #region Colors for 32 bpp
        /// <summary>
        /// 24
        /// </summary>
        internal const int L_RED_SHIFT = 8 * (sizeof(uint) - 1 - (int)ColorsFor32Bpp.COLOR_RED);
        /// <summary>
        /// 16
        /// </summary>
        internal const int L_GREEN_SHIFT = 8 * (sizeof(uint) - 1 - (int)ColorsFor32Bpp.COLOR_GREEN);
        /// <summary>
        /// 8
        /// </summary>
        internal const int L_BLUE_SHIFT = 8 * (sizeof(uint) - 1 - (int)ColorsFor32Bpp.COLOR_BLUE);
        /// <summary>
        /// 0
        /// </summary>
        internal const int L_ALPHA_SHIFT = 8 * (sizeof(uint) - 1 - (int)ColorsFor32Bpp.L_ALPHA_CHANNEL);
        #endregion

        #region Perceptual color weights
        /// <summary>
        /// Percept. weight for red
        /// </summary>
        internal const float L_RED_WEIGHT = 0.3F;
        /// <summary>
        /// Percept. weight for green
        /// </summary>
        internal const float L_GREEN_WEIGHT = 0.5F;
        /// <summary>
        /// Percept. weight for blue
        /// </summary>
        internal const float L_BLUE_WEIGHT = 0.2F;
        #endregion

        #region Standard size of border added around images for special processing
        /// <summary>
        /// pixels, not bits
        /// </summary>
        internal const int ADDED_BORDER = 32;
        #endregion
        #endregion

        #region adaptmap.c - DONE
        // Clean background to white using background normalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCleanBackgroundToWhite")]
        internal static extern IntPtr pixCleanBackgroundToWhite(HandleRef pixs, HandleRef pixim, HandleRef pixg, float gamma, int blackval, int whiteval);

        // Adaptive background normalization (top-level functions)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormSimple")]
        internal static extern IntPtr pixBackgroundNormSimple(HandleRef pixs, HandleRef pixim, HandleRef pixg);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNorm")]
        internal static extern IntPtr pixBackgroundNorm(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormMorph")]
        internal static extern IntPtr pixBackgroundNormMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval);

        // Arrays of inverted background values for normalization (16 bpp)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormGrayArray")]
        internal static extern bool pixBackgroundNormGrayArray(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, ref IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormRGBArrays")]
        internal static extern bool pixBackgroundNormRGBArrays(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, ref IntPtr ppixr, ref IntPtr ppixg, ref IntPtr ppixb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormGrayArrayMorph")]
        internal static extern bool pixBackgroundNormGrayArrayMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval, ref IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormRGBArraysMorph")]
        internal static extern bool pixBackgroundNormRGBArraysMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, int bgval, ref IntPtr ppixr, ref IntPtr ppixg, ref IntPtr ppixb);

        // Measurement of local background
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundGrayMap")]
        internal static extern bool pixGetBackgroundGrayMap(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, ref IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundRGBMap")]
        internal static extern bool pixGetBackgroundRGBMap(HandleRef pixs, HandleRef pixim, HandleRef pixg, int sx, int sy, int thresh, int mincount, ref IntPtr ppixmr, ref IntPtr ppixmg, ref IntPtr ppixmb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundGrayMapMorph")]
        internal static extern bool pixGetBackgroundGrayMapMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, ref IntPtr ppixm);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBackgroundRGBMapMorph")]
        internal static extern bool pixGetBackgroundRGBMapMorph(HandleRef pixs, HandleRef pixim, int reduction, int size, ref IntPtr ppixmr, ref IntPtr ppixmg, ref IntPtr ppixmb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillMapHoles")]
        internal static extern bool pixFillMapHoles(HandleRef pix, int nx, int ny, GrayscaleFillingFlags filltype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtendByReplication")]
        internal static extern IntPtr pixExtendByReplication(HandleRef pixs, int addw, int addh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSmoothConnectedRegions")]
        internal static extern bool pixSmoothConnectedRegions(HandleRef pixs, HandleRef pixm, int factor);

        // Generate inverted background map for each component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetInvBackgroundMap")]
        internal static extern IntPtr pixGetInvBackgroundMap(HandleRef pixs, int bgval, int smoothx, int smoothy);

        // Apply inverse background map to image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyInvBackgroundGrayMap")]
        internal static extern IntPtr pixApplyInvBackgroundGrayMap(HandleRef pixs, HandleRef pixm, int sx, int sy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyInvBackgroundRGBMap")]
        internal static extern IntPtr pixApplyInvBackgroundRGBMap(HandleRef pixs, HandleRef pixmr, HandleRef pixmg, HandleRef pixmb, int sx, int sy);

        // Apply variable map
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyVariableGrayMap")]
        internal static extern IntPtr pixApplyVariableGrayMap(HandleRef pixs, HandleRef pixg, int target);

        // Non-adaptive (global) mapping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGlobalNormRGB")]
        internal static extern IntPtr pixGlobalNormRGB(HandleRef pixd, HandleRef pixs, int rval, int gval, int bval, int mapval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGlobalNormNoSatRGB")]
        internal static extern IntPtr pixGlobalNormNoSatRGB(HandleRef pixd, HandleRef pixs, int rval, int gval, int bval, int factor, float rank);

        // Adaptive threshold spread normalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdSpreadNorm")]
        internal static extern bool pixThresholdSpreadNorm(HandleRef pixs, EdgeFilterFlags filtertype, int edgethresh, int smoothx, int smoothy, float gamma, int minval, int maxval, int targetthresh, ref IntPtr ppixth, ref IntPtr ppixb, ref IntPtr ppixd);

        // Adaptive background normalization (flexible adaptaption)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBackgroundNormFlex")]
        internal static extern IntPtr pixBackgroundNormFlex(HandleRef pixs, int sx, int sy, int smoothx, int smoothy, int delta);

        // Adaptive contrast normalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastNorm")]
        internal static extern IntPtr pixContrastNorm(HandleRef pixd, HandleRef pixs, int sx, int sy, int mindiff, int smoothx, int smoothy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinMaxTiles")]
        internal static extern bool pixMinMaxTiles(HandleRef pixs, int sx, int sy, int mindiff, int smoothx, int smoothy, ref IntPtr ppixmin, ref IntPtr ppixmax);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetLowContrast")]
        internal static extern int pixSetLowContrast(HandleRef pixs1, HandleRef pixs2, int mindiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLinearTRCTiled")]
        internal static extern IntPtr pixLinearTRCTiled(HandleRef pixd, HandleRef pixs, int sx, int sy, HandleRef pixmin, HandleRef pixmax);
        #endregion

        #region affine.c - DONE
        // Affine (3 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSampledPta")]
        internal static extern IntPtr pixAffineSampledPta(HandleRef pixs, HandleRef ptad, HandleRef ptas, BackgroundFlags incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSampled")]
        internal static extern IntPtr pixAffineSampled(HandleRef pixs, IntPtr vc, BackgroundFlags incolor);

        // Affine (3 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePta")]
        internal static extern IntPtr pixAffinePta(HandleRef pixs, HandleRef ptad, HandleRef ptas, BackgroundFlags incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffine")]
        internal static extern IntPtr pixAffine(HandleRef pixs, IntPtr vc, BackgroundFlags incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaColor")]
        internal static extern IntPtr pixAffinePtaColor(HandleRef pixs, HandleRef ptad, HandleRef ptas, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineColor")]
        internal static extern IntPtr pixAffineColor(HandleRef pixs, IntPtr vc, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaGray")]
        internal static extern IntPtr pixAffinePtaGray(HandleRef pixs, HandleRef ptad, HandleRef ptas, byte grayval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineGray")]
        internal static extern IntPtr pixAffineGray(HandleRef pixs, IntPtr vc, byte grayval);

        // Affine transform including alpha (blend) component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffinePtaWithAlpha")]
        internal static extern IntPtr pixAffinePtaWithAlpha(HandleRef pixs, HandleRef ptad, HandleRef ptas, HandleRef pixg, float fract, int border);

        // Affine coordinate transformation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getAffineXformCoeffs")]
        internal static extern bool getAffineXformCoeffs(HandleRef ptas, HandleRef ptad, out IntPtr pvc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineInvertXform")]
        internal static extern bool affineInvertXform(IntPtr vc, out IntPtr pvci);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineXformSampledPt")]
        internal static extern bool affineXformSampledPt(IntPtr vc, int x, int y, out int pxp, out int pyp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "affineXformPt")]
        internal static extern bool affineXformPt(IntPtr vc, int x, int y, out float pxp, out float pyp);

        // Interpolation helper functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelColor")]
        internal static extern bool linearInterpolatePixelColor(IntPtr datas, int wpls, int w, int h, float x, float y, uint colorval, out uint pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelGray")]
        internal static extern bool linearInterpolatePixelGray(IntPtr datas, int wpls, int w, int h, float x, float y, int grayval, out int pval);

        // Gauss-jordan linear equation solver
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gaussjordan")]
        internal static extern bool gaussjordan(IntPtr a, IntPtr b, int n);

        // Affine image transformation using a sequence of  shear/scale/translation operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAffineSequential")]
        internal static extern IntPtr pixAffineSequential(HandleRef pixs, HandleRef ptad, HandleRef ptas, int bw, int bh);
        #endregion

        #region affinecompose.c
        // Composable coordinate transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dTranslate")]
        internal static extern IntPtr createMatrix2dTranslate(float transx, float transy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dScale")]
        internal static extern IntPtr createMatrix2dScale(float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "createMatrix2dRotate")]
        internal static extern IntPtr createMatrix2dRotate(float xc, float yc, float angle);

        // Special coordinate transforms on pta
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTranslate")]
        internal static extern IntPtr ptaTranslate(HandleRef ptas, float transx, float transy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaScale")]
        internal static extern IntPtr ptaScale(HandleRef ptas, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRotate")]
        internal static extern IntPtr ptaRotate(HandleRef ptas, float xc, float yc, float angle);

        // Special coordinate transforms on boxa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTranslate")]
        internal static extern IntPtr boxaTranslate(HandleRef boxas, float transx, float transy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaScale")]
        internal static extern IntPtr boxaScale(HandleRef boxas, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRotate")]
        internal static extern IntPtr boxaRotate(HandleRef boxas, float xc, float yc, float angle);

        // General coordinate transform on pta and boxa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaAffineTransform")]
        internal static extern IntPtr ptaAffineTransform(HandleRef ptas, IntPtr mat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAffineTransform")]
        internal static extern IntPtr boxaAffineTransform(HandleRef boxas, IntPtr mat);

        // Matrix operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMatVec")]
        internal static extern bool l_productMatVec(IntPtr mat, IntPtr vecs, IntPtr vecd, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat2")]
        internal static extern bool l_productMat2(IntPtr mat1, IntPtr mat2, IntPtr matd, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat3")]
        internal static extern bool l_productMat3(IntPtr mat1, IntPtr mat2, IntPtr mat3, IntPtr matd, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_productMat4")]
        internal static extern bool l_productMat4(IntPtr mat1, IntPtr mat2, IntPtr mat3, IntPtr mat4, IntPtr matd, int size);
        #endregion

        #region arrayaccess.c
        // Access within an array of 32-bit words
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataBit")]
        internal static extern int l_getDataBit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataBit")]
        internal static extern void l_setDataBit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataBit")]
        internal static extern void l_clearDataBit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataBitVal")]
        internal static extern void l_setDataBitVal(IntPtr line, int n, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataDibit")]
        internal static extern int l_getDataDibit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataDibit")]
        internal static extern void l_setDataDibit(IntPtr line, int n, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataDibit")]
        internal static extern void l_clearDataDibit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataQbit")]
        internal static extern int l_getDataQbit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataQbit")]
        internal static extern void l_setDataQbit(IntPtr line, int n, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_clearDataQbit")]
        internal static extern void l_clearDataQbit(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataByte")]
        internal static extern int l_getDataByte(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataByte")]
        internal static extern void l_setDataByte(IntPtr line, int n, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataTwoBytes")]
        internal static extern int l_getDataTwoBytes(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataTwoBytes")]
        internal static extern void l_setDataTwoBytes(IntPtr line, int n, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataFourBytes")]
        internal static extern int l_getDataFourBytes(IntPtr line, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setDataFourBytes")]
        internal static extern void l_setDataFourBytes(IntPtr line, int n, int val);
        #endregion

        #region bardecode.c
        // Dispatcher
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataBit")]
        internal static extern IntPtr barcodeDispatchDecoder([MarshalAs(UnmanagedType.AnsiBStr)] string barstr, int format, int debugflag);

        // Format Determination
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getDataBit")]
        internal static extern int barcodeFormatIsSupported(int format);
        #endregion

        #region baseline.c
        // Locate text baselines in an image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindBaselines")]
        internal static extern IntPtr pixFindBaselines(HandleRef pixs, out IntPtr ppta, HandleRef pixadb);

        // Projective transform to remove local skew
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewLocal")]
        internal static extern IntPtr pixDeskewLocal(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta);

        // Determine local skew
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLocalSkewTransform")]
        internal static extern int pixGetLocalSkewTransform(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, out IntPtr pptas, out IntPtr pptad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLocalSkewAngles")]
        internal static extern IntPtr pixGetLocalSkewAngles(HandleRef pixs, int nslices, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, out float pa, out float pb, int debug);
        #endregion

        #region bbuffer.c
        // Create/Destroy BBuffer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr bbufferCreate(IntPtr indata, int nalloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferDestroy")]
        internal static extern void bbufferDestroy(ref IntPtr pbb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferDestroyAndSaveData")]
        internal static extern IntPtr bbufferDestroyAndSaveData(ref IntPtr pbb, IntPtr pnbytes);

        // Operations to read data TO a BBuffer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferRead")]
        internal static extern int bbufferRead(HandleRef bb, IntPtr src, int nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferReadStream")]
        internal static extern int bbufferReadStream(HandleRef bb, IntPtr fp, int nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferExtendArray")]
        internal static extern int bbufferExtendArray(HandleRef bb, int nbytes);

        // Operations to write data FROM a BBuffer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferWrite")]
        internal static extern int bbufferWrite(HandleRef bb, IntPtr dest, IntPtr nbytes, IntPtr pnout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferWriteStream")]
        internal static extern int bbufferWriteStream(HandleRef bb, IntPtr fp, IntPtr nbytes, IntPtr pnout);
        #endregion

        #region bilateral.c
        // Top level approximate separable grayscale or color bilateral filtering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr pixBilateral(HandleRef pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr pixBilateralGray(HandleRef pixs, float spatial_stdev, float range_stdev, int ncomps, int reduction);

        // Slow, exact implementation of grayscale or color bilateral filtering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr pixBilateralExact(HandleRef pixs, HandleRef spatial_kel, HandleRef range_kel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr pixBilateralGrayExact(HandleRef pixs, HandleRef spatial_kel, HandleRef range_kel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr pixBlockBilateralExact(HandleRef pixs, float spatial_stdev, float range_stdev);

        // Kernel helper function
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bbufferCreate")]
        internal static extern IntPtr makeRangeKernel(float range_stdev);
        #endregion

        #region bilinear.c
        // Bilinear (4 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearSampledPta")]
        internal static extern IntPtr pixBilinearSampledPta(HandleRef pixs, HandleRef ptad, HandleRef ptas, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearSampled")]
        internal static extern IntPtr pixBilinearSampled(HandleRef pixs, IntPtr vc, int incolor);

        // Bilinear (4 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPta")]
        internal static extern IntPtr pixBilinearPta(HandleRef pixs, HandleRef ptad, HandleRef ptas, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinear")]
        internal static extern IntPtr pixBilinear(HandleRef pixs, IntPtr vc, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaColor")]
        internal static extern IntPtr pixBilinearPtaColor(HandleRef pixs, HandleRef ptad, HandleRef ptas, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearColor")]
        internal static extern IntPtr pixBilinearColor(HandleRef pixs, IntPtr vc, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaGray")]
        internal static extern IntPtr pixBilinearPtaGray(HandleRef pixs, HandleRef ptad, HandleRef ptas, byte grayval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearGray")]
        internal static extern IntPtr pixBilinearGray(HandleRef pixs, IntPtr vc, byte grayval);

        // Bilinear transform including alpha (blend) component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBilinearPtaWithAlpha")]
        internal static extern IntPtr pixBilinearPtaWithAlpha(HandleRef pixs, HandleRef ptad, HandleRef ptas, HandleRef pixg, float fract, int border);

        // Bilinear coordinate transformation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getBilinearXformCoeffs")]
        internal static extern int getBilinearXformCoeffs(HandleRef ptas, HandleRef ptad, out IntPtr pvc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bilinearXformSampledPt")]
        internal static extern int bilinearXformSampledPt(IntPtr vc, int x, int y, out int pxp, out int pyp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bilinearXformPt")]
        internal static extern int bilinearXformPt(IntPtr vc, int x, int y, out float pxp, out float pyp);
        #endregion

        #region binarize.c
        // Adaptive Otsu-based thresholding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOtsuAdaptiveThreshold")]
        internal static extern int pixOtsuAdaptiveThreshold(HandleRef pixs, int sx, int sy, int smoothx, int smoothy, float scorefract, out IntPtr ppixth, out IntPtr ppixd);

        // Otsu thresholding on adaptive background normalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOtsuThreshOnBackgroundNorm")]
        internal static extern IntPtr pixOtsuThreshOnBackgroundNorm(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int bgval, int smoothx, int smoothy, float scorefract, out int pthresh);

        // Masking and Otsu estimate on adaptive background normalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskedThreshOnBackgroundNorm")]
        internal static extern IntPtr pixMaskedThreshOnBackgroundNorm(HandleRef pixs, HandleRef pixim, int sx, int sy, int thresh, int mincount, int smoothx, int smoothy, float scorefract, out int pthresh);

        // Sauvola local thresholding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaBinarizeTiled")]
        internal static extern int pixSauvolaBinarizeTiled(HandleRef pixs, int whsize, float factor, int nx, int ny, out IntPtr ppixth, out IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaBinarize")]
        internal static extern int pixSauvolaBinarize(HandleRef pixs, int whsize, float factor, int addborder, out IntPtr ppixm, out IntPtr ppixsd, out IntPtr ppixth, out IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSauvolaGetThreshold")]
        internal static extern IntPtr pixSauvolaGetThreshold(HandleRef pixm, HandleRef pixms, float factor, out IntPtr ppixsd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixApplyLocalThreshold")]
        internal static extern IntPtr pixApplyLocalThreshold(HandleRef pixs, HandleRef pixth, int redfactor);

        // Thresholding using connected components
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdByConnComp")]
        internal static extern int pixThresholdByConnComp(HandleRef pixs, HandleRef pixm, int start, int end, int incr, float thresh48, float threshdiff, out int pglobthresh, out IntPtr ppixd, int debugflag);
        #endregion

        #region binexpand.c
        // Replicated expansion (integer scaling)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandBinaryReplicate")]
        internal static extern IntPtr pixExpandBinaryReplicate(HandleRef pixs, int xfact, int yfact);

        // Special case: power of 2 replicated expansion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandBinaryPower2")]
        internal static extern IntPtr pixExpandBinaryPower2(HandleRef pixs, int factor);
        #endregion

        #region binreduce.c
        // Subsampled 2x reduction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceBinary2")]
        internal static extern IntPtr pixReduceBinary2(HandleRef pixs, IntPtr intab);

        // Rank filtered 2x reductions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceRankBinaryCascade")]
        internal static extern IntPtr pixReduceRankBinaryCascade(HandleRef pixs, int level1, int level2, int level3, int level4);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReduceRankBinary2")]
        internal static extern IntPtr pixReduceRankBinary2(HandleRef pixs, int level, IntPtr intab);

        // Permutation table for 2x rank binary reduction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSubsampleTab2x")]
        internal static extern IntPtr makeSubsampleTab2x(IntPtr v);
        #endregion

        #region blend.c
        // Blending two images that are not colormapped
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlend")]
        internal static extern IntPtr pixBlend(HandleRef pixs1, HandleRef pixs2, int x, int y, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendMask")]
        internal static extern IntPtr pixBlendMask(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGray")]
        internal static extern IntPtr pixBlendGray(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract, int type, int transparent, uint transpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGrayInverse")]
        internal static extern IntPtr pixBlendGrayInverse(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendColor")]
        internal static extern IntPtr pixBlendColor(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract, int transparent, uint transpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendColorByChannel")]
        internal static extern IntPtr pixBlendColorByChannel(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float rfract, float gfract, float bfract, int transparent, uint transpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendGrayAdapt")]
        internal static extern IntPtr pixBlendGrayAdapt(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract, int shift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFadeWithGray")]
        internal static extern IntPtr pixFadeWithGray(HandleRef pixs, HandleRef pixb, float factor, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendHardLight")]
        internal static extern IntPtr pixBlendHardLight(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int x, int y, float fract);

        // Blending two colormapped images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendCmap")]
        internal static extern int pixBlendCmap(HandleRef pixs, HandleRef pixb, int x, int y, int sindex);

        // Blending two images using a third (alpha mask)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendWithGrayMask")]
        internal static extern IntPtr pixBlendWithGrayMask(HandleRef pixs1, HandleRef pixs2, HandleRef pixg, int x, int y);

        // Blending background to a specific color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendBackgroundToColor")]
        internal static extern IntPtr pixBlendBackgroundToColor(HandleRef pixd, HandleRef pixs, HandleRef box, uint color, float gamma, int minval, int maxval);

        // Multiplying by a specific color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultiplyByColor")]
        internal static extern IntPtr pixMultiplyByColor(HandleRef pixd, HandleRef pixs, HandleRef box, uint color);

        // Rendering with alpha blending over a uniform background
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAlphaBlendUniform")]
        internal static extern IntPtr pixAlphaBlendUniform(HandleRef pixs, uint color);

        // Adding an alpha layer for blending
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddAlphaToBlend")]
        internal static extern IntPtr pixAddAlphaToBlend(HandleRef pixs, float fract, int invert);

        // Setting a transparent alpha component over a white background
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAlphaOverWhite")]
        internal static extern IntPtr pixSetAlphaOverWhite(HandleRef pixs);
        #endregion

        #region bmf.c
        // Acquisition and generation of bitmap fonts.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfCreate")]
        internal static extern IntPtr bmfCreate([MarshalAs(UnmanagedType.AnsiBStr)] string dir, int fontsize);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfDestroy")]
        internal static extern void bmfDestroy(ref IntPtr pbmf);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetPix")]
        internal static extern IntPtr bmfGetPix(HandleRef bmf, char chr);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetWidth")]
        internal static extern int bmfGetWidth(HandleRef bmf, char chr, out int pw);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetBaseline")]
        internal static extern int bmfGetBaseline(HandleRef bmf, char chr, out int pbaseline);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetFont")]
        internal static extern IntPtr pixaGetFont([MarshalAs(UnmanagedType.AnsiBStr)] string dir, int fontsize, out int pbl0, out int pbl1, out int pbl2);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSaveFont")]
        internal static extern int pixaSaveFont([MarshalAs(UnmanagedType.AnsiBStr)] string indir, [MarshalAs(UnmanagedType.AnsiBStr)] string outdir, int fontsize);

        #endregion

        #region bmpio.c
        // Read bmp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamBmp")]
        internal static extern IntPtr pixReadStreamBmp(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemBmp")]
        internal static extern IntPtr pixReadMemBmp(IntPtr cdata, IntPtr size);

        // Write bmp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamBmp")]
        internal static extern int pixWriteStreamBmp(IntPtr fp, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemBmp")]
        internal static extern int pixWriteMemBmp(out IntPtr pfdata, out IntPtr pfsize, HandleRef pixs);
        #endregion

        #region bootnumgen1.c
        // Auto-generated deserializer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen1")]
        internal static extern IntPtr l_bootnum_gen1(IntPtr vo);
        #endregion

        #region bootnumgen2.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen2")]
        internal static extern IntPtr l_bootnum_gen2(IntPtr vo);
        #endregion

        #region bootnumgen3.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_bootnum_gen3")]
        internal static extern IntPtr l_bootnum_gen3(IntPtr vo);
        #endregion

        #region boxbasic.c
        // Box creation, copy, clone, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCreate")]
        internal static extern IntPtr boxCreate(int x, int y, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCreateValid")]
        internal static extern IntPtr boxCreateValid(int x, int y, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCopy")]
        internal static extern IntPtr boxCopy(HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClone")]
        internal static extern IntPtr boxClone(HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxDestroy")]
        internal static extern void boxDestroy(ref IntPtr pbox);

        // Box accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetGeometry")]
        internal static extern int boxGetGeometry(HandleRef box, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSetGeometry")]
        internal static extern int boxSetGeometry(HandleRef box, int x, int y, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetSideLocations")]
        internal static extern int boxGetSideLocations(HandleRef box, out int pl, out int pr, out int pt, out int pb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSetSideLocations")]
        internal static extern int boxSetSideLocations(HandleRef box, int l, int r, int t, int b);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetRefcount")]
        internal static extern int boxGetRefcount(HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxChangeRefcount")]
        internal static extern int boxChangeRefcount(HandleRef box, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIsValid")]
        internal static extern int boxIsValid(HandleRef box, out int pvalid);

        // Boxa creation, copy, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCreate")]
        internal static extern IntPtr boxaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCopy")]
        internal static extern IntPtr boxaCopy(HandleRef boxa, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaDestroy")]
        internal static extern void boxaDestroy(ref IntPtr pboxa);

        // Boxa array extension
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAddBox")]
        internal static extern int boxaAddBox(HandleRef boxa, HandleRef box, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtendArray")]
        internal static extern int boxaExtendArray(HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtendArrayToSize")]
        internal static extern int boxaExtendArrayToSize(HandleRef boxa, int size);

        // Boxa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetCount")]
        internal static extern int boxaGetCount(HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetValidCount")]
        internal static extern int boxaGetValidCount(HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetBox")]
        internal static extern IntPtr boxaGetBox(HandleRef boxa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetValidBox")]
        internal static extern IntPtr boxaGetValidBox(HandleRef boxa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaFindInvalidBoxes")]
        internal static extern IntPtr boxaFindInvalidBoxes(HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetBoxGeometry")]
        internal static extern int boxaGetBoxGeometry(HandleRef boxa, int index, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaIsFull")]
        internal static extern int boxaIsFull(HandleRef boxa, out int pfull);

        // Boxa array modifiers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReplaceBox")]
        internal static extern int boxaReplaceBox(HandleRef boxa, int index, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaInsertBox")]
        internal static extern int boxaInsertBox(HandleRef boxa, int index, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRemoveBox")]
        internal static extern int boxaRemoveBox(HandleRef boxa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRemoveBoxAndSave")]
        internal static extern int boxaRemoveBoxAndSave(HandleRef boxa, int index, out IntPtr pbox);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSaveValid")]
        internal static extern IntPtr boxaSaveValid(HandleRef boxas, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaInitFull")]
        internal static extern int boxaInitFull(HandleRef boxa, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaClear")]
        internal static extern int boxaClear(HandleRef boxa);

        // Boxaa creation, copy, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaCreate")]
        internal static extern IntPtr boxaaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaCopy")]
        internal static extern IntPtr boxaaCopy(HandleRef baas, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaDestroy")]
        internal static extern void boxaaDestroy(ref IntPtr pbaa);

        // Boxaa array extension
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAddBoxa")]
        internal static extern int boxaaAddBoxa(HandleRef baa, HandleRef ba, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendArray")]
        internal static extern int boxaaExtendArray(HandleRef baa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendArrayToSize")]
        internal static extern int boxaaExtendArrayToSize(HandleRef baa, int size);

        // Boxaa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetCount")]
        internal static extern int boxaaGetCount(HandleRef baa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBoxCount")]
        internal static extern int boxaaGetBoxCount(HandleRef baa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBoxa")]
        internal static extern IntPtr boxaaGetBoxa(HandleRef baa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetBox")]
        internal static extern IntPtr boxaaGetBox(HandleRef baa, int iboxa, int ibox, int accessflag);

        // Boxaa array modifiers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaInitFull")]
        internal static extern int boxaaInitFull(HandleRef baa, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaExtendWithInit")]
        internal static extern int boxaaExtendWithInit(HandleRef baa, int maxindex, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReplaceBoxa")]
        internal static extern int boxaaReplaceBoxa(HandleRef baa, int index, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaInsertBoxa")]
        internal static extern int boxaaInsertBoxa(HandleRef baa, int index, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaRemoveBoxa")]
        internal static extern int boxaaRemoveBoxa(HandleRef baa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAddBox")]
        internal static extern int boxaaAddBox(HandleRef baa, int index, HandleRef box, int accessflag);

        // Boxaa serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadFromFiles")]
        internal static extern IntPtr boxaaReadFromFiles([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int first, int nfiles);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaRead")]
        internal static extern IntPtr boxaaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadStream")]
        internal static extern IntPtr boxaaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaReadMem")]
        internal static extern IntPtr boxaaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWrite")]
        internal static extern int boxaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef baa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWriteStream")]
        internal static extern int boxaaWriteStream(IntPtr fp, HandleRef baa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaWriteMem")]
        internal static extern int boxaaWriteMem(IntPtr pdata, IntPtr psize, HandleRef baa);

        // Boxa serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRead")]
        internal static extern IntPtr boxaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReadStream")]
        internal static extern IntPtr boxaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReadMem")]
        internal static extern IntPtr boxaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWrite")]
        internal static extern int boxaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWriteStream")]
        internal static extern int boxaWriteStream(IntPtr fp, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWriteMem")]
        internal static extern int boxaWriteMem(IntPtr pdata, IntPtr psize, HandleRef boxa);

        // Box print (for debug)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxPrintStreamInfo")]
        internal static extern int boxPrintStreamInfo(IntPtr fp, HandleRef box);
        #endregion

        #region boxfunc1.c
        //  Box geometry
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxContains")]
        internal static extern int boxContains(HandleRef box1, HandleRef box2, out int presult);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIntersects")]
        internal static extern int boxIntersects(HandleRef box1, HandleRef box2, out int presult);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaContainedInBox")]
        internal static extern IntPtr boxaContainedInBox(HandleRef boxas, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaContainedInBoxCount")]
        internal static extern int boxaContainedInBoxCount(HandleRef boxa, HandleRef box, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaContainedInBoxa")]
        internal static extern int boxaContainedInBoxa(HandleRef boxa1, HandleRef boxa2, out int pcontained);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaIntersectsBox")]
        internal static extern IntPtr boxaIntersectsBox(HandleRef boxas, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaIntersectsBoxCount")]
        internal static extern int boxaIntersectsBoxCount(HandleRef boxa, HandleRef box, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaClipToBox")]
        internal static extern IntPtr boxaClipToBox(HandleRef boxas, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCombineOverlaps")]
        internal static extern IntPtr boxaCombineOverlaps(HandleRef boxas, HandleRef pixadb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCombineOverlapsInPair")]
        internal static extern int boxaCombineOverlapsInPair(HandleRef boxas1, HandleRef boxas2, out IntPtr pboxad1, out IntPtr pboxad2, HandleRef pixadb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapRegion")]
        internal static extern IntPtr boxOverlapRegion(HandleRef box1, HandleRef box2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxBoundingRegion")]
        internal static extern IntPtr boxBoundingRegion(HandleRef box1, HandleRef box2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapFraction")]
        internal static extern int boxOverlapFraction(HandleRef box1, HandleRef box2, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxOverlapArea")]
        internal static extern int boxOverlapArea(HandleRef box1, HandleRef box2, out int parea);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaHandleOverlaps")]
        internal static extern IntPtr boxaHandleOverlaps(HandleRef boxas, int op, int range, float min_overlap, float max_ratio, out IntPtr pnamap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSeparationDistance")]
        internal static extern int boxSeparationDistance(HandleRef box1, HandleRef box2, out int ph_sep, out int pv_sep);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxCompareSize")]
        internal static extern int boxCompareSize(HandleRef box1, HandleRef box2, int type, out int prel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxContainsPt")]
        internal static extern int boxContainsPt(HandleRef box, float x, float y, out int pcontains);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetNearestToPt")]
        internal static extern IntPtr boxaGetNearestToPt(HandleRef boxa, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetNearestToLine")]
        internal static extern IntPtr boxaGetNearestToLine(HandleRef boxa, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxGetCenter")]
        internal static extern int boxGetCenter(HandleRef box, out float pcx, out float pcy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxIntersectByLine")]
        internal static extern int boxIntersectByLine(HandleRef box, int x, int y, float slope, out int px1, out int py1, out int px2, out int py2, out int pn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClipToRectangle")]
        internal static extern IntPtr boxClipToRectangle(HandleRef box, int wi, int hi);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxClipToRectangleParams")]
        internal static extern int boxClipToRectangleParams(HandleRef box, int w, int h, out int pxstart, out int pystart, out int pxend, out int pyend, out int pbw, out int pbh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxRelocateOneSide")]
        internal static extern IntPtr boxRelocateOneSide(HandleRef boxd, HandleRef boxs, int loc, int sideflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAdjustSides")]
        internal static extern IntPtr boxaAdjustSides(HandleRef boxas, int delleft, int delright, int deltop, int delbot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxAdjustSides")]
        internal static extern IntPtr boxAdjustSides(HandleRef boxd, HandleRef boxs, int delleft, int delright, int deltop, int delbot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSetSide")]
        internal static extern IntPtr boxaSetSide(HandleRef boxad, HandleRef boxas, int side, int val, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAdjustWidthToTarget")]
        internal static extern IntPtr boxaAdjustWidthToTarget(HandleRef boxad, HandleRef boxas, int sides, int target, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaAdjustHeightToTarget")]
        internal static extern IntPtr boxaAdjustHeightToTarget(HandleRef boxad, HandleRef boxas, int sides, int target, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxEqual")]
        internal static extern int boxEqual(HandleRef box1, HandleRef box2, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaEqual")]
        internal static extern int boxaEqual(HandleRef boxa1, HandleRef boxa2, int maxdist, out IntPtr pnaindex, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxSimilar")]
        internal static extern int boxSimilar(HandleRef box1, HandleRef box2, int leftdiff, int rightdiff, int topdiff, int botdiff, out int psimilar);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSimilar")]
        internal static extern int boxaSimilar(HandleRef boxa1, HandleRef boxa2, int leftdiff, int rightdiff, int topdiff, int botdiff, int debug, out int psimilar, out IntPtr pnasim);

        // Boxa combine and split
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaJoin")]
        internal static extern int boxaJoin(HandleRef boxad, HandleRef boxas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaJoin")]
        internal static extern int boxaaJoin(HandleRef baad, HandleRef baas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSplitEvenOdd")]
        internal static extern int boxaSplitEvenOdd(HandleRef boxa, int fillflag, out IntPtr pboxae, out IntPtr pboxao);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMergeEvenOdd")]
        internal static extern IntPtr boxaMergeEvenOdd(HandleRef boxae, HandleRef boxao, int fillflag);
        #endregion

        #region boxfunc2.c
        // Boxa/Box transform(shift, scale) and orthogonal rotation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTransform")]
        internal static extern IntPtr boxaTransform(HandleRef boxas, int shiftx, int shifty, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxTransform")]
        internal static extern IntPtr boxTransform(HandleRef box, int shiftx, int shifty, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaTransformOrdered")]
        internal static extern IntPtr boxaTransformOrdered(HandleRef boxas, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxTransformOrdered")]
        internal static extern IntPtr boxTransformOrdered(HandleRef boxs, int shiftx, int shifty, float scalex, float scaley, int xcen, int ycen, float angle, int order);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaRotateOrth")]
        internal static extern IntPtr boxaRotateOrth(HandleRef boxas, int w, int h, int rotation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxRotateOrth")]
        internal static extern IntPtr boxRotateOrth(HandleRef box, int w, int h, int rotation);

        // Boxa sort
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort")]
        internal static extern IntPtr boxaSort(HandleRef boxas, int sorttype, int sortorder, out IntPtr pnaindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaBinSort")]
        internal static extern IntPtr boxaBinSort(HandleRef boxas, int sorttype, int sortorder, out IntPtr pnaindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSortByIndex")]
        internal static extern IntPtr boxaSortByIndex(HandleRef boxas, HandleRef naindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort2d")]
        internal static extern IntPtr boxaSort2d(HandleRef boxas, out IntPtr pnaad, int delta1, int delta2, int minh1);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSort2dByIndex")]
        internal static extern IntPtr boxaSort2dByIndex(HandleRef boxas, HandleRef naa);

        // Boxa statistics
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetRankVals")]
        internal static extern int boxaGetRankVals(HandleRef boxa, float fract, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetMedianVals")]
        internal static extern int boxaGetMedianVals(HandleRef boxa, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetAverageSize")]
        internal static extern int boxaGetAverageSize(HandleRef boxa, out float pw, out float ph);

        // Boxa array extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractAsNuma")]
        internal static extern int boxaExtractAsNuma(HandleRef boxa, out IntPtr pnal, out IntPtr pnat, out IntPtr pnar, out IntPtr pnab, out IntPtr pnaw, out IntPtr pnah, int keepinvalid);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractAsPta")]
        internal static extern int boxaExtractAsPta(HandleRef boxa, out IntPtr pptal, out IntPtr pptat, out IntPtr pptar, out IntPtr pptab, out IntPtr pptaw, out IntPtr pptah, int keepinvalid);

        //Other Boxaa functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaGetExtent")]
        internal static extern int boxaaGetExtent(HandleRef baa, out int pw, out int ph, out IntPtr pbox, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaFlattenToBoxa")]
        internal static extern IntPtr boxaaFlattenToBoxa(HandleRef baa, out IntPtr pnaindex, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaFlattenAligned")]
        internal static extern IntPtr boxaaFlattenAligned(HandleRef baa, int num, HandleRef fillerbox, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaEncapsulateAligned")]
        internal static extern IntPtr boxaEncapsulateAligned(HandleRef boxa, int num, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaTranspose")]
        internal static extern IntPtr boxaaTranspose(HandleRef baas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaAlignBox")]
        internal static extern int boxaaAlignBox(HandleRef baa, HandleRef box, int delta, out int pindex);
        #endregion

        #region boxfunc3.c
        // Boxa/Boxaa painting into pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskConnComp")]
        internal static extern IntPtr pixMaskConnComp(HandleRef pixs, int connectivity, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskBoxa")]
        internal static extern IntPtr pixMaskBoxa(HandleRef pixd, HandleRef pixs, HandleRef boxa, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintBoxa")]
        internal static extern IntPtr pixPaintBoxa(HandleRef pixs, HandleRef boxa, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBlackOrWhiteBoxa")]
        internal static extern IntPtr pixSetBlackOrWhiteBoxa(HandleRef pixs, HandleRef boxa, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintBoxaRandom")]
        internal static extern IntPtr pixPaintBoxaRandom(HandleRef pixs, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendBoxaRandom")]
        internal static extern IntPtr pixBlendBoxaRandom(HandleRef pixs, HandleRef boxa, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDrawBoxa")]
        internal static extern IntPtr pixDrawBoxa(HandleRef pixs, HandleRef boxa, int width, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDrawBoxaRandom")]
        internal static extern IntPtr pixDrawBoxaRandom(HandleRef pixs, HandleRef boxa, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaDisplay")]
        internal static extern IntPtr boxaaDisplay(HandleRef pixs, HandleRef baa, int linewba, int linewb, uint colorba, uint colorb, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayBoxaa")]
        internal static extern IntPtr pixaDisplayBoxaa(HandleRef pixas, HandleRef baa, int colorflag, int width);

        // Split mask components into Boxa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitIntoBoxa")]
        internal static extern IntPtr pixSplitIntoBoxa(HandleRef pixs, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitComponentIntoBoxa")]
        internal static extern IntPtr pixSplitComponentIntoBoxa(HandleRef pix, HandleRef box, int minsum, int skipdist, int delta, int maxbg, int maxcomps, int remainder);

        // Represent horizontal or vertical mosaic strips
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMosaicStrips")]
        internal static extern IntPtr makeMosaicStrips(int w, int h, int direction, int size);

        // Comparison between boxa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaCompareRegions")]
        internal static extern int boxaCompareRegions(HandleRef boxa1, HandleRef boxa2, int areathresh, out int pnsame, out float pdiffarea, out float pdiffxor, out IntPtr ppixdb);

        // Reliable selection of a single large box
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectLargeULComp")]
        internal static extern IntPtr pixSelectLargeULComp(HandleRef pixs, float areaslop, int yslop, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectLargeULBox")]
        internal static extern IntPtr boxaSelectLargeULBox(HandleRef boxas, float areaslop, int yslop);
        #endregion

        #region boxfunc4.c
        // Boxa and Boxaa range selection
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectRange")]
        internal static extern IntPtr boxaSelectRange(HandleRef boxas, int first, int last, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaSelectRange")]
        internal static extern IntPtr boxaaSelectRange(HandleRef baas, int first, int last, int copyflag);

        // Boxa size selection
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectBySize")]
        internal static extern IntPtr boxaSelectBySize(HandleRef boxas, int width, int height, int type, int relation, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeSizeIndicator")]
        internal static extern IntPtr boxaMakeSizeIndicator(HandleRef boxa, int width, int height, int type, int relation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectByArea")]
        internal static extern IntPtr boxaSelectByArea(HandleRef boxas, int area, int relation, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeAreaIndicator")]
        internal static extern IntPtr boxaMakeAreaIndicator(HandleRef boxa, int area, int relation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectByWHRatio")]
        internal static extern IntPtr boxaSelectByWHRatio(HandleRef boxas, float ratio, int relation, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaMakeWHRatioIndicator")]
        internal static extern IntPtr boxaMakeWHRatioIndicator(HandleRef boxa, float ratio, int relation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSelectWithIndicator")]
        internal static extern IntPtr boxaSelectWithIndicator(HandleRef boxas, HandleRef na, out int pchanged);

        // Boxa permutation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPermutePseudorandom")]
        internal static extern IntPtr boxaPermutePseudorandom(HandleRef boxas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPermuteRandom")]
        internal static extern IntPtr boxaPermuteRandom(HandleRef boxad, HandleRef boxas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSwapBoxes")]
        internal static extern int boxaSwapBoxes(HandleRef boxa, int i, int j);

        // Boxa and box conversions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaConvertToPta")]
        internal static extern IntPtr boxaConvertToPta(HandleRef boxa, int ncorners);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaConvertToBoxa")]
        internal static extern IntPtr ptaConvertToBoxa(HandleRef pta, int ncorners);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxConvertToPta")]
        internal static extern IntPtr boxConvertToPta(HandleRef box, int ncorners);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaConvertToBox")]
        internal static extern IntPtr ptaConvertToBox(HandleRef pta);

        // Boxa sequence fitting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSmoothSequenceLS")]
        internal static extern IntPtr boxaSmoothSequenceLS(HandleRef boxas, float factor, int subflag, int maxdiff, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSmoothSequenceMedian")]
        internal static extern IntPtr boxaSmoothSequenceMedian(HandleRef boxas, int halfwin, int subflag, int maxdiff, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaLinearFit")]
        internal static extern IntPtr boxaLinearFit(HandleRef boxas, float factor, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaWindowedMedian")]
        internal static extern IntPtr boxaWindowedMedian(HandleRef boxas, int halfwin, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaModifyWithBoxa")]
        internal static extern IntPtr boxaModifyWithBoxa(HandleRef boxas, HandleRef boxam, int subflag, int maxdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaConstrainSize")]
        internal static extern IntPtr boxaConstrainSize(HandleRef boxas, int width, int widthflag, int height, int heightflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReconcileEvenOddHeight")]
        internal static extern IntPtr boxaReconcileEvenOddHeight(HandleRef boxas, int sides, int delh, int op, float factor, int start);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaReconcilePairWidth")]
        internal static extern IntPtr boxaReconcilePairWidth(HandleRef boxas, int delw, int op, float factor, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPlotSides")]
        internal static extern int boxaPlotSides(HandleRef boxa, [MarshalAs(UnmanagedType.AnsiBStr)] string plotname, out IntPtr pnal, out IntPtr pnat, out IntPtr pnar, out IntPtr pnab, out IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPlotSizes")]
        internal static extern int boxaPlotSizes(HandleRef boxa, [MarshalAs(UnmanagedType.AnsiBStr)] string plotname, out IntPtr pnaw, out IntPtr pnah, out IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaFillSequence")]
        internal static extern IntPtr boxaFillSequence(HandleRef boxas, int useflag, int debug);

        // Miscellaneous boxa functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetExtent")]
        internal static extern int boxaGetExtent(HandleRef boxa, out int pw, out int ph, out IntPtr pbox);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetCoverage")]
        internal static extern int boxaGetCoverage(HandleRef boxa, int wc, int hc, int exactflag, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaSizeRange")]
        internal static extern int boxaaSizeRange(HandleRef baa, out int pminw, out int pminh, out int pmaxw, out int pmaxh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaSizeRange")]
        internal static extern int boxaSizeRange(HandleRef boxa, out int pminw, out int pminh, out int pmaxw, out int pmaxh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaLocationRange")]
        internal static extern int boxaLocationRange(HandleRef boxa, out int pminx, out int pminy, out int pmaxx, out int pmaxy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetSizes")]
        internal static extern int boxaGetSizes(HandleRef boxa, out IntPtr pnaw, out IntPtr pnah);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetArea")]
        internal static extern int boxaGetArea(HandleRef boxa, out int parea);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaDisplayTiled")]
        internal static extern IntPtr boxaDisplayTiled(HandleRef boxas, HandleRef pixa, int maxwidth, int linewidth, float scalefactor, int background, int spacing, int border);
        #endregion

        #region bytearray.c
        // Creation, copy, clone, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCreate")]
        internal static extern IntPtr l_byteaCreate(IntPtr nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromMem")]
        internal static extern IntPtr l_byteaInitFromMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromFile")]
        internal static extern IntPtr l_byteaInitFromFile([MarshalAs(UnmanagedType.AnsiBStr)]  string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaInitFromStream")]
        internal static extern IntPtr l_byteaInitFromStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCopy")]
        internal static extern IntPtr l_byteaCopy(HandleRef bas, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaDestroy")]
        internal static extern void l_byteaDestroy(ref IntPtr pba);

        // Accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaGetSize")]
        internal static extern IntPtr l_byteaGetSize(HandleRef ba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaGetData")]
        internal static extern IntPtr l_byteaGetData(HandleRef ba, IntPtr psize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaCopyData")]
        internal static extern IntPtr l_byteaCopyData(HandleRef ba, IntPtr psize);

        // Appending
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaAppendData")]
        internal static extern int l_byteaAppendData(HandleRef ba, IntPtr newdata, IntPtr newbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaAppendString")]
        internal static extern int l_byteaAppendString(HandleRef ba, [MarshalAs(UnmanagedType.AnsiBStr)]  string str);

        // Join/Split
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaJoin")]
        internal static extern int l_byteaJoin(HandleRef ba1, out IntPtr pba2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaSplit")]
        internal static extern int l_byteaSplit(HandleRef ba1, IntPtr splitloc, out IntPtr pba2);

        // Search
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaFindEachSequence")]
        internal static extern int l_byteaFindEachSequence(HandleRef ba, IntPtr sequence, int seqlen, out IntPtr pda);

        // Output to file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaWrite")]
        internal static extern int l_byteaWrite([MarshalAs(UnmanagedType.AnsiBStr)]  string fname, HandleRef ba, IntPtr startloc, IntPtr endloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_byteaWriteStream")]
        internal static extern int l_byteaWriteStream(IntPtr fp, HandleRef ba, IntPtr startloc, IntPtr endloc);
        #endregion

        #region ccbord.c
        // CCBORDA and CCBORD creation and destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaCreate")]
        internal static extern IntPtr ccbaCreate(HandleRef pixs, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDestroy")]
        internal static extern void ccbaDestroy(ref IntPtr pccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbCreate")]
        internal static extern IntPtr ccbCreate(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbDestroy")]
        internal static extern void ccbDestroy(ref IntPtr pccb);

        // CCBORDA addition
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaAddCcb")]
        internal static extern int ccbaAddCcb(HandleRef ccba, HandleRef ccb);

        // CCBORDA accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGetCount")]
        internal static extern int ccbaGetCount(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGetCcb")]
        internal static extern IntPtr ccbaGetCcb(HandleRef ccba, int index);

        // Top-level border-finding routines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAllCCBorders")]
        internal static extern IntPtr pixGetAllCCBorders(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCCBorders")]
        internal static extern IntPtr pixGetCCBorders(HandleRef pixs, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBordersPtaa")]
        internal static extern IntPtr pixGetOuterBordersPtaa(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBorderPta")]
        internal static extern IntPtr pixGetOuterBorderPta(HandleRef pixs, HandleRef box);

        // Lower-level border location routines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetOuterBorder")]
        internal static extern int pixGetOuterBorder(HandleRef ccb, HandleRef pixs, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetHoleBorder")]
        internal static extern int pixGetHoleBorder(HandleRef ccb, HandleRef pixs, HandleRef box, int xs, int ys);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findNextBorderPixel")]
        internal static extern int findNextBorderPixel(int w, int h, IntPtr data, int wpl, int px, int py, out int pqpos, out int pnpx, out int pnpy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "locateOutsideSeedPixel")]
        internal static extern void locateOutsideSeedPixel(int fpx, int fpy, int spx, int spy, out int pxs, out int pys);

        // Border conversions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateGlobalLocs")]
        internal static extern int ccbaGenerateGlobalLocs(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateStepChains")]
        internal static extern int ccbaGenerateStepChains(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaStepChainsToPixCoords")]
        internal static extern int ccbaStepChainsToPixCoords(HandleRef ccba, int coordtype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateSPGlobalLocs")]
        internal static extern int ccbaGenerateSPGlobalLocs(HandleRef ccba, int ptsflag);

        // Conversion to single path
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaGenerateSinglePath")]
        internal static extern int ccbaGenerateSinglePath(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getCutPathForHole")]
        internal static extern IntPtr getCutPathForHole(HandleRef pix, HandleRef pta, HandleRef boxinner, out int pdir, out int plen);

        // Border and full image rendering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayBorder")]
        internal static extern IntPtr ccbaDisplayBorder(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplaySPBorder")]
        internal static extern IntPtr ccbaDisplaySPBorder(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayImage1")]
        internal static extern IntPtr ccbaDisplayImage1(HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaDisplayImage2")]
        internal static extern IntPtr ccbaDisplayImage2(HandleRef ccba);

        // Serialize for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWrite")]
        internal static extern int ccbaWrite([MarshalAs(UnmanagedType.AnsiBStr)]  string filename, HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteStream")]
        internal static extern int ccbaWriteStream(IntPtr fp, HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaRead")]
        internal static extern IntPtr ccbaRead([MarshalAs(UnmanagedType.AnsiBStr)]  string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaReadStream")]
        internal static extern IntPtr ccbaReadStream(IntPtr fp);

        // SVG output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteSVG")]
        internal static extern int ccbaWriteSVG([MarshalAs(UnmanagedType.AnsiBStr)]  string filename, HandleRef ccba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ccbaWriteSVGString")]
        internal static extern IntPtr ccbaWriteSVGString([MarshalAs(UnmanagedType.AnsiBStr)]  string filename, HandleRef ccba);

        #endregion

        #region ccthin.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaThinConnected")]
        internal static extern IntPtr pixaThinConnected(HandleRef pixas, int type, int connectivity, int maxiters);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThinConnected")]
        internal static extern IntPtr pixThinConnected(HandleRef pixs, int type, int connectivity, int maxiters);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThinConnectedBySet")]
        internal static extern IntPtr pixThinConnectedBySet(HandleRef pixs, int type, HandleRef sela, int maxiters);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaMakeThinSets")]
        internal static extern IntPtr selaMakeThinSets(int index, int debug);
        #endregion

        #region classapp.c
        // Top-level jb2 correlation and rank-hausdorff
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelation")]
        internal static extern int jbCorrelation([MarshalAs(UnmanagedType.AnsiBStr)]  string dirin, float thresh, float weight, int components, [MarshalAs(UnmanagedType.AnsiBStr)]  string rootname, int firstpage, int npages, int renderflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbRankHaus")]
        internal static extern int jbRankHaus([MarshalAs(UnmanagedType.AnsiBStr)]  string dirin, int size, float rank, int components, [MarshalAs(UnmanagedType.AnsiBStr)]  string rootname, int firstpage, int npages, int renderflag);

        // Extract and classify words in textline order
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbWordsInTextlines")]
        internal static extern IntPtr jbWordsInTextlines([MarshalAs(UnmanagedType.AnsiBStr)]  string dirin, int reduction, int maxwidth, int maxheight, float thresh, float weight, out IntPtr pnatl, int firstpage, int npages);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWordsInTextlines")]
        internal static extern int pixGetWordsInTextlines(HandleRef pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, out IntPtr pboxad, out IntPtr ppixad, out IntPtr pnai);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWordBoxesInTextlines")]
        internal static extern int pixGetWordBoxesInTextlines(HandleRef pixs, int reduction, int minwidth, int minheight, int maxwidth, int maxheight, out IntPtr pboxad, out IntPtr pnai);
        //1.77
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindWordAndCharacterBoxes")]
        internal static extern int pixFindWordAndCharacterBoxes(HandleRef pixs, HandleRef boxs, int thresh, out IntPtr pboxax, out IntPtr pboxaac, [MarshalAs(UnmanagedType.AnsiBStr)] string debugdir);

        // Use word bounding boxes to compare page images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaExtractSortedPattern")]
        internal static extern IntPtr boxaExtractSortedPattern(HandleRef boxa, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCompareImagesByBoxes")]
        internal static extern int numaaCompareImagesByBoxes(HandleRef naa1, HandleRef naa2, int nperline, int nreq, int maxshiftx, int maxshifty, int delx, int dely, out int psame, int debugflag);
        #endregion

        #region colorcontent.c
        // Builds an image of the color content, on a per-pixel basis, as a measure of the amount of divergence of each color  component(R, G, B) from gray.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorContent")]
        internal static extern int pixColorContent(HandleRef pixs, int rwhite, int gwhite, int bwhite, int mingray, out IntPtr ppixr, out IntPtr ppixg, out IntPtr ppixb);

        // Finds the 'amount' of color in an image, on a per-pixel basis, as a measure of the difference of the pixel color from gray.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMagnitude")]
        internal static extern IntPtr pixColorMagnitude(HandleRef pixs, int rwhite, int gwhite, int bwhite, int type);

        // Generates a mask over pixels that have sufficient color and are not too close to gray pixels.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskOverColorPixels")]
        internal static extern IntPtr pixMaskOverColorPixels(HandleRef pixs, int threshdiff, int mindist);

        // Generates mask over pixels within a prescribed cube in RGB space
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaskOverColorRange")]
        internal static extern IntPtr pixMaskOverColorRange(HandleRef pixs, int rmin, int rmax, int gmin, int gmax, int bmin, int bmax);

        // Finds the fraction of pixels with "color" that are not close to black
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorFraction")]
        internal static extern int pixColorFraction(HandleRef pixs, int darkthresh, int lightthresh, int diffthresh, int factor, out float ppixfract, out float pcolorfract);

        // Determine if there are significant color regions that are not background in a page image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindColorRegions")]
        internal static extern int pixFindColorRegions(HandleRef pixs, HandleRef pixm, int factor, int lightthresh, int darkthresh, int mindiff, int colordiff, float edgefract, out float pcolorfract, out IntPtr pcolormask1, out IntPtr pcolormask2, HandleRef pixadb);

        // Finds the number of perceptually significant gray intensities in a grayscale image.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumSignificantGrayColors")]
        internal static extern int pixNumSignificantGrayColors(HandleRef pixs, int darkthresh, int lightthresh, float minfract, int factor, out int pncolors);

        // Identifies images where color quantization will cause posterization  due to the existence of many colors in low-gradient regions.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorsForQuantization")]
        internal static extern int pixColorsForQuantization(HandleRef pixs, int thresh, out int pncolors, out int piscolor, int debug);

        // Finds the number of unique colors in an image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumColors")]
        internal static extern int pixNumColors(HandleRef pixs, int factor, out int pncolors);

        // Find the most "populated" colors in the image(and quantize)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMostPopulatedColors")]
        internal static extern int pixGetMostPopulatedColors(HandleRef pixs, int sigbits, int factor, int ncolors, out IntPtr parray, out IntPtr pcmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSimpleColorQuantize")]
        internal static extern IntPtr pixSimpleColorQuantize(HandleRef pixs, int sigbits, int factor, int ncolors);

        // Constructs a color histogram based on rgb indices
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBHistogram")]
        internal static extern IntPtr pixGetRGBHistogram(HandleRef pixs, int sigbits, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeRGBIndexTables")]
        internal static extern int makeRGBIndexTables(out IntPtr prtab, out IntPtr pgtab, out IntPtr pbtab, int sigbits);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getRGBFromIndex")]
        internal static extern int getRGBFromIndex(uint index, int sigbits, out int prval, out int pgval, out int pbval);

        // Identify images that have highlight(red) color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHasHighlightRed")]
        internal static extern int pixHasHighlightRed(HandleRef pixs, int factor, float fract, float fthresh, out int phasred, out float pratio, out IntPtr ppixdb);
        #endregion

        #region coloring.c
        // Coloring "gray" pixels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayRegions")]
        internal static extern IntPtr pixColorGrayRegions(HandleRef pixs, HandleRef boxa, int type, int thresh, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGray")]
        internal static extern int pixColorGray(HandleRef pixs, HandleRef box, int type, int thresh, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayMasked")]
        internal static extern IntPtr pixColorGrayMasked(HandleRef pixs, HandleRef pixm, int type, int thresh, int rval, int gval, int bval);

        // Adjusting one or more colors to a target color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSnapColor")]
        internal static extern IntPtr pixSnapColor(HandleRef pixd, HandleRef pixs, uint srcval, uint dstval, int diff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSnapColorCmap")]
        internal static extern IntPtr pixSnapColorCmap(HandleRef pixd, HandleRef pixs, uint srcval, uint dstval, int diff);

        // Piecewise linear color mapping based on a source/target pair
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLinearMapToTargetColor")]
        internal static extern IntPtr pixLinearMapToTargetColor(HandleRef pixd, HandleRef pixs, uint srcval, uint dstval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelLinearMapToTargetColor")]
        internal static extern int pixelLinearMapToTargetColor(uint scolor, uint srcmap, uint dstmap, out uint pdcolor);

        // Fractional shift of RGB towards black or white
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixShiftByComponent")]
        internal static extern IntPtr pixShiftByComponent(HandleRef pixd, HandleRef pixs, uint srcval, uint dstval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelShiftByComponent")]
        internal static extern int pixelShiftByComponent(int rval, int gval, int bval, uint srcval, uint dstval, out uint ppixel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixelFractionalShift")]
        internal static extern int pixelFractionalShift(int rval, int gval, int bval, float fraction, out uint ppixel);
        #endregion

        #region colormap.c
        // Colormap creation, copy, destruction, addition
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCreate")]
        internal static extern IntPtr pixcmapCreate(int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCreateRandom")]
        internal static extern IntPtr pixcmapCreateRandom(int depth, int hasblack, int haswhite);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCreateLinear")]
        internal static extern IntPtr pixcmapCreateLinear(int d, int nlevels);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCopy")]
        internal static extern IntPtr pixcmapCopy(HandleRef cmaps);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapDestroy")]
        internal static extern void pixcmapDestroy(ref IntPtr pcmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddColor")]
        internal static extern int pixcmapAddColor(HandleRef cmap, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddRGBA")]
        internal static extern int pixcmapAddRGBA(HandleRef cmap, int rval, int gval, int bval, int aval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddNewColor")]
        internal static extern int pixcmapAddNewColor(HandleRef cmap, int rval, int gval, int bval, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddNearestColor")]
        internal static extern int pixcmapAddNearestColor(HandleRef cmap, int rval, int gval, int bval, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapUsableColor")]
        internal static extern int pixcmapUsableColor(HandleRef cmap, int rval, int gval, int bval, out int pusable);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapAddBlackOrWhite")]
        internal static extern int pixcmapAddBlackOrWhite(HandleRef cmap, int color, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSetBlackAndWhite")]
        internal static extern int pixcmapSetBlackAndWhite(HandleRef cmap, int setblack, int setwhite);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetCount")]
        internal static extern int pixcmapGetCount(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetDepth")]
        internal static extern int pixcmapGetDepth(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetMinDepth")]
        internal static extern int pixcmapGetMinDepth(HandleRef cmap, out int pmindepth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetFreeCount")]
        internal static extern int pixcmapGetFreeCount(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapClear")]
        internal static extern int pixcmapClear(HandleRef cmap);

        // Colormap random access and test
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetColor")]
        internal static extern int pixcmapGetColor(HandleRef cmap, int index, out int prval, out int pgval, out int pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetColor32")]
        internal static extern int pixcmapGetColor32(HandleRef cmap, int index, out int pval32);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRGBA")]
        internal static extern int pixcmapGetRGBA(HandleRef cmap, int index, out int prval, out int pgval, out int pbval, out int paval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRGBA32")]
        internal static extern int pixcmapGetRGBA32(HandleRef cmap, int index, out int pval32);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapResetColor")]
        internal static extern int pixcmapResetColor(HandleRef cmap, int index, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSetAlpha")]
        internal static extern int pixcmapSetAlpha(HandleRef cmap, int index, int aval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetIndex")]
        internal static extern int pixcmapGetIndex(HandleRef cmap, int rval, int gval, int bval, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapHasColor")]
        internal static extern int pixcmapHasColor(HandleRef cmap, out int pcolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapIsOpaque")]
        internal static extern int pixcmapIsOpaque(HandleRef cmap, out int popaque);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapIsBlackAndWhite")]
        internal static extern int pixcmapIsBlackAndWhite(HandleRef cmap, out int pblackwhite);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapCountGrayColors")]
        internal static extern int pixcmapCountGrayColors(HandleRef cmap, out int pngray);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRankIntensity")]
        internal static extern int pixcmapGetRankIntensity(HandleRef cmap, float rankval, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetNearestIndex")]
        internal static extern int pixcmapGetNearestIndex(HandleRef cmap, int rval, int gval, int bval, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetNearestGrayIndex")]
        internal static extern int pixcmapGetNearestGrayIndex(HandleRef cmap, int val, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetDistanceToColor")]
        internal static extern int pixcmapGetDistanceToColor(HandleRef cmap, int index, int rval, int gval, int bval, out int pdist);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGetRangeValues")]
        internal static extern int pixcmapGetRangeValues(HandleRef cmap, int select, out int pminval, out int pmaxval, out int pminindex, out int pmaxindex);

        // Colormap conversion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGrayToColor")]
        internal static extern IntPtr pixcmapGrayToColor(uint color);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapColorToGray")]
        internal static extern IntPtr pixcmapColorToGray(HandleRef cmaps, float rwt, float gwt, float bwt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertTo4")]
        internal static extern IntPtr pixcmapConvertTo4(HandleRef cmaps);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertTo8")]
        internal static extern IntPtr pixcmapConvertTo8(HandleRef cmaps);

        // Colormap I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapRead")]
        internal static extern IntPtr pixcmapRead([MarshalAs(UnmanagedType.AnsiBStr)]  string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapReadStream")]
        internal static extern IntPtr pixcmapReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapReadMem")]
        internal static extern IntPtr pixcmapReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWrite")]
        internal static extern int pixcmapWrite([MarshalAs(UnmanagedType.AnsiBStr)]  string filename, HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWriteStream")]
        internal static extern int pixcmapWriteStream(IntPtr fp, HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapWriteMem")]
        internal static extern int pixcmapWriteMem(out IntPtr pdata, out IntPtr psize, HandleRef cmap);

        // Extract colormap arrays and serialization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToArrays")]
        internal static extern int pixcmapToArrays(HandleRef cmap, out IntPtr prmap, out IntPtr pgmap, out IntPtr pbmap, out IntPtr pamap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToRGBTable")]
        internal static extern int pixcmapToRGBTable(HandleRef cmap, out IntPtr ptab, out int pncolors);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapSerializeToMemory")]
        internal static extern int pixcmapSerializeToMemory(HandleRef cmap, int cpc, out int pncolors, out IntPtr pdata);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapDeserializeFromMemory")]
        internal static extern IntPtr pixcmapDeserializeFromMemory(IntPtr data, int cpc, int ncolors);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertToHex")]
        internal static extern IntPtr pixcmapConvertToHex(IntPtr data, int ncolors);

        // Colormap transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapGammaTRC")]
        internal static extern int pixcmapGammaTRC(HandleRef cmap, float gamma, int minval, int maxval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapContrastTRC")]
        internal static extern int pixcmapContrastTRC(HandleRef cmap, float factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapShiftIntensity")]
        internal static extern int pixcmapShiftIntensity(HandleRef cmap, float fraction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapShiftByComponent")]
        internal static extern int pixcmapShiftByComponent(HandleRef cmap, uint srcval, uint dstval);
        #endregion

        #region colormorph.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMorph")]
        internal static extern IntPtr pixColorMorph(HandleRef pixs, int type, int hsize, int vsize);
        #endregion

        #region colorquant1.c
        // (1) Two-pass adaptive octree color quantization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeColorQuant")]
        internal static extern IntPtr pixOctreeColorQuant(HandleRef pixs, int colors, int ditherflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeColorQuantGeneral")]
        internal static extern IntPtr pixOctreeColorQuantGeneral(HandleRef pixs, int colors, int ditherflag, float validthresh, float colorthresh);

        // Helper index functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeRGBToIndexTables")]
        internal static extern int makeRGBToIndexTables(out IntPtr prtab, out IntPtr pgtab, out IntPtr pbtab, int cqlevels);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getOctcubeIndexFromRGB")]
        internal static extern void getOctcubeIndexFromRGB(int rval, int gval, int bval, IntPtr rtab, IntPtr gtab, IntPtr btab, out uint pindex);

        // (2) Adaptive octree quantization based on population at a fixed level
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeQuantByPopulation")]
        internal static extern IntPtr pixOctreeQuantByPopulation(HandleRef pixs, int level, int ditherflag);

        // (3) Adaptive octree quantization to 4 and 8 bpp with specified number of output colors in colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctreeQuantNumColors")]
        internal static extern IntPtr pixOctreeQuantNumColors(HandleRef pixs, int maxcolors, int subsample);

        // (4) Mixed color/gray quantization with specified number of colors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeQuantMixedWithGray")]
        internal static extern IntPtr pixOctcubeQuantMixedWithGray(HandleRef pixs, int depth, int graylevels, int delta);

        // (5) Fixed partition octcube quantization with 256 cells
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFixedOctcubeQuant256")]
        internal static extern IntPtr pixFixedOctcubeQuant256(HandleRef pixs, int ditherflag);

        // (6) Fixed partition quantization for images with few colors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuant1")]
        internal static extern IntPtr pixFewColorsOctcubeQuant1(HandleRef pixs, int level);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuant2")]
        internal static extern IntPtr pixFewColorsOctcubeQuant2(HandleRef pixs, int level, HandleRef na, int ncolors, out int pnerrors);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsOctcubeQuantMixed")]
        internal static extern IntPtr pixFewColorsOctcubeQuantMixed(HandleRef pixs, int level, int darkthresh, int lightthresh, int diffthresh, float minfract, int maxspan);

        // (7) Fixed partition octcube quantization at specified level with quantized output to RGB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFixedOctcubeQuantGenRGB")]
        internal static extern IntPtr pixFixedOctcubeQuantGenRGB(HandleRef pixs, int level);

        // (8) Color quantize RGB image using existing colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuantFromCmap")]
        internal static extern IntPtr pixQuantFromCmap(HandleRef pixs, HandleRef cmap, int mindepth, int level, int metric);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeQuantFromCmap")]
        internal static extern IntPtr pixOctcubeQuantFromCmap(HandleRef pixs, HandleRef cmap, int mindepth, int level, int metric);

        // Generation of octcube histogram
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOctcubeHistogram")]
        internal static extern IntPtr pixOctcubeHistogram(HandleRef pixs, int level, out int pncolors);

        // Get filled octcube table from colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapToOctcubeLUT")]
        internal static extern IntPtr pixcmapToOctcubeLUT(HandleRef cmap, int level, int metric);

        // Strip out unused elements in colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveUnusedColors")]
        internal static extern int pixRemoveUnusedColors(HandleRef pixs);

        // Find number of occupied octcubes at the specified level
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixNumberOccupiedOctcubes")]
        internal static extern int pixNumberOccupiedOctcubes(HandleRef pix, int level, int mincount, float minfract, out int pncolors);
        #endregion

        #region colorquant2.c
        // Modified median cut color quantization
        // High level
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuant")]
        internal static extern IntPtr pixMedianCutQuant(HandleRef pixs, int ditherflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuantGeneral")]
        internal static extern IntPtr pixMedianCutQuantGeneral(HandleRef pixs, int ditherflag, int outdepth, int maxcolors, int sigbits, int maxsub, int checkbw);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutQuantMixed")]
        internal static extern IntPtr pixMedianCutQuantMixed(HandleRef pixs, int ncolor, int ngray, int darkthresh, int lightthresh, int diffthresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFewColorsMedianCutQuantMixed")]
        internal static extern IntPtr pixFewColorsMedianCutQuantMixed(HandleRef pixs, int ncolor, int ngray, int maxncolors, int darkthresh, int lightthresh, int diffthresh);

        // Median cut indexed histogram
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianCutHisto")]
        internal static extern IntPtr pixMedianCutHisto(HandleRef pixs, int sigbits, int subsample);
        #endregion

        #region colorseg.c
        // Unsupervised color segmentation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegment")]
        internal static extern IntPtr pixColorSegment(HandleRef pixs, int maxdist, int maxcolors, int selsize, int finalcolors, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentCluster")]
        internal static extern IntPtr pixColorSegmentCluster(HandleRef pixs, int maxdist, int maxcolors, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAssignToNearestColor")]
        internal static extern int pixAssignToNearestColor(HandleRef pixd, HandleRef pixs, HandleRef pixm, int level, IntPtr countarray);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentClean")]
        internal static extern int pixColorSegmentClean(HandleRef pixs, int selsize, IntPtr countarray);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorSegmentRemoveColors")]
        internal static extern int pixColorSegmentRemoveColors(HandleRef pixd, HandleRef pixs, int finalcolors);
        #endregion

        #region colorspace.c
        // Colorspace conversion between RGB and HSV
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToHSV")]
        internal static extern IntPtr pixConvertRGBToHSV(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertHSVToRGB")]
        internal static extern IntPtr pixConvertHSVToRGB(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToHSV")]
        internal static extern int convertRGBToHSV(int rval, int gval, int bval, out int phval, out int psval, out int pvval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertHSVToRGB")]
        internal static extern int convertHSVToRGB(int hval, int sval, int vval, out int prval, out int pgval, out int pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertRGBToHSV")]
        internal static extern int pixcmapConvertRGBToHSV(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertHSVToRGB")]
        internal static extern int pixcmapConvertHSVToRGB(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToHue")]
        internal static extern IntPtr pixConvertRGBToHue(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToSaturation")]
        internal static extern IntPtr pixConvertRGBToSaturation(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToValue")]
        internal static extern IntPtr pixConvertRGBToValue(HandleRef pixs);

        // Selection and display of range of colors in HSV space
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskHS")]
        internal static extern IntPtr pixMakeRangeMaskHS(HandleRef pixs, int huecenter, int huehw, int satcenter, int sathw, int regionflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskHV")]
        internal static extern IntPtr pixMakeRangeMaskHV(HandleRef pixs, int huecenter, int huehw, int valcenter, int valhw, int regionflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeRangeMaskSV")]
        internal static extern IntPtr pixMakeRangeMaskSV(HandleRef pixs, int satcenter, int sathw, int valcenter, int valhw, int regionflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoHS")]
        internal static extern IntPtr pixMakeHistoHS(HandleRef pixs, int factor, out IntPtr pnahue, out IntPtr pnasat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoHV")]
        internal static extern IntPtr pixMakeHistoHV(HandleRef pixs, int factor, out IntPtr pnahue, out IntPtr pnaval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeHistoSV")]
        internal static extern IntPtr pixMakeHistoSV(HandleRef pixs, int factor, out IntPtr pnasat, out IntPtr pnaval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindHistoPeaksHSV")]
        internal static extern int pixFindHistoPeaksHSV(HandleRef pixs, int type, int width, int height, int npeaks, float erasefactor, out IntPtr ppta, out IntPtr pnatot, out IntPtr ppixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "displayHSVColorRange")]
        internal static extern IntPtr displayHSVColorRange(int hval, int sval, int vval, int huehw, int sathw, int nsamp, int factor);

        // Colorspace conversion between RGB and YUV
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToYUV")]
        internal static extern IntPtr pixConvertRGBToYUV(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertYUVToRGB")]
        internal static extern IntPtr pixConvertYUVToRGB(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToYUV")]
        internal static extern int convertRGBToYUV(int rval, int gval, int bval, out int pyval, out int puval, out int pvval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertYUVToRGB")]
        internal static extern int convertYUVToRGB(int yval, int uval, int vval, out int prval, out int pgval, out int pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertRGBToYUV")]
        internal static extern int pixcmapConvertRGBToYUV(HandleRef cmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcmapConvertYUVToRGB")]
        internal static extern int pixcmapConvertYUVToRGB(HandleRef cmap);

        // Colorspace conversion between RGB and XYZ
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToXYZ")]
        internal static extern IntPtr pixConvertRGBToXYZ(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertXYZToRGB")]
        internal static extern IntPtr fpixaConvertXYZToRGB(HandleRef fpixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToXYZ")]
        internal static extern int convertRGBToXYZ(int rval, int gval, int bval, out float pfxval, out float pfyval, out float pfzval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertXYZToRGB")]
        internal static extern int convertXYZToRGB(float fxval, float fyval, float fzval, int blackout, out int prval, out int pgval, out int pbval);

        // Colorspace conversion between XYZ and LAB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertXYZToLAB")]
        internal static extern IntPtr fpixaConvertXYZToLAB(HandleRef fpixas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertLABToXYZ")]
        internal static extern IntPtr fpixaConvertLABToXYZ(HandleRef fpixas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertXYZToLAB")]
        internal static extern int convertXYZToLAB(float xval, float yval, float zval, out float plval, out float paval, out float pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertLABToXYZ")]
        internal static extern int convertLABToXYZ(float lval, float aval, float bval, out float pxval, out float pyval, out float pzval);

        // Colorspace conversion between RGB and LAB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToLAB")]
        internal static extern IntPtr pixConvertRGBToLAB(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaConvertLABToRGB")]
        internal static extern IntPtr fpixaConvertLABToRGB(HandleRef fpixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertRGBToLAB")]
        internal static extern int convertRGBToLAB(int rval, int gval, int bval, out float pflval, out float pfaval, out float pfbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertLABToRGB")]
        internal static extern int convertLABToRGB(float flval, float faval, float fbval, out int prval, out int pgval, out int pbval);
        #endregion

        #region compare.c
        // Test for pix equality
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqual")]
        internal static extern int pixEqual(HandleRef pix1, HandleRef pix2, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualWithAlpha")]
        internal static extern int pixEqualWithAlpha(HandleRef pix1, HandleRef pix2, int use_alpha, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualWithCmap")]
        internal static extern int pixEqualWithCmap(HandleRef pix1, HandleRef pix2, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cmapEqual")]
        internal static extern int cmapEqual(HandleRef cmap1, HandleRef cmap2, int ncomps, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUsesCmapColor")]
        internal static extern int pixUsesCmapColor(HandleRef pixs, out int pcolor);

        // Binary correlation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationBinary")]
        internal static extern int pixCorrelationBinary(HandleRef pix1, HandleRef pix2, out float pval);

        // Difference of two images of same size
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayDiffBinary")]
        internal static extern IntPtr pixDisplayDiffBinary(HandleRef pix1, HandleRef pix2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareBinary")]
        internal static extern int pixCompareBinary(HandleRef pix1, HandleRef pix2, int comptype, out float pfract, out IntPtr ppixdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGrayOrRGB")]
        internal static extern int pixCompareGrayOrRGB(HandleRef pix1, HandleRef pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out IntPtr ppixdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGray")]
        internal static extern int pixCompareGray(HandleRef pix1, HandleRef pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out IntPtr ppixdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareRGB")]
        internal static extern int pixCompareRGB(HandleRef pix1, HandleRef pix2, int comptype, int plottype, out int psame, out float pdiff, out float prmsdiff, out IntPtr ppixdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareTiled")]
        internal static extern int pixCompareTiled(HandleRef pix1, HandleRef pix2, int sx, int sy, int type, out IntPtr ppixdiff);

        // Other measures of the difference of two images of the same size
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareRankDifference")]
        internal static extern IntPtr pixCompareRankDifference(HandleRef pix1, HandleRef pix2, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTestForSimilarity")]
        internal static extern int pixTestForSimilarity(HandleRef pix1, HandleRef pix2, int factor, int mindiff, float maxfract, float maxave, out int psimilar, int printstats);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDifferenceStats")]
        internal static extern int pixGetDifferenceStats(HandleRef pix1, HandleRef pix2, int factor, int mindiff, out float pfractdiff, out float pavediff, int printstats);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDifferenceHistogram")]
        internal static extern IntPtr pixGetDifferenceHistogram(HandleRef pix1, HandleRef pix2, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPerceptualDiff")]
        internal static extern int pixGetPerceptualDiff(HandleRef pixs1, HandleRef pixs2, int sampling, int dilation, int mindiff, out float pfract, out IntPtr ppixdiff1, out IntPtr ppixdiff2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPSNR")]
        internal static extern int pixGetPSNR(HandleRef pix1, HandleRef pix2, int factor, out float ppsnr);

        // Comparison of photo regions by histogram
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaComparePhotoRegionsByHisto")]
        internal static extern int pixaComparePhotoRegionsByHisto(HandleRef pixa, float minratio, float textthresh, int factor, int nx, int ny, float simthresh, out IntPtr pnai, out IntPtr pscores, out IntPtr ppixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixComparePhotoRegionsByHisto")]
        internal static extern int pixComparePhotoRegionsByHisto(HandleRef pix1, HandleRef pix2, HandleRef box1, HandleRef box2, float minratio, int factor, int nx, int ny, out float pscore, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenPhotoHistos")]
        internal static extern int pixGenPhotoHistos(HandleRef pixs, HandleRef box, int factor, float thresh, int nx, int ny, out IntPtr pnaa, out int pw, out int ph, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPadToCenterCentroid")]
        internal static extern IntPtr pixPadToCenterCentroid(HandleRef pixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCentroid8")]
        internal static extern int pixCentroid8(HandleRef pixs, int factor, out float pcx, out float pcy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDecideIfPhotoImage")]
        internal static extern int pixDecideIfPhotoImage(HandleRef pix, int factor, int nx, int ny, float thresh, out IntPtr pnaa, HandleRef pixadebug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "compareTilesByHisto")]
        internal static extern int compareTilesByHisto(HandleRef naa1, HandleRef naa2, float minratio, int w1, int h1, int w2, int h2, out float pscore, HandleRef pixadebug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareGrayByHisto")]
        internal static extern int pixCompareGrayByHisto(HandleRef pix1, HandleRef pix2, HandleRef box1, HandleRef box2, float minratio, int maxgray, int factor, int nx, int ny, out float pscore, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropAlignedToCentroid")]
        internal static extern int pixCropAlignedToCentroid(HandleRef pix1, HandleRef pix2, int factor, out IntPtr pbox1, out IntPtr pbox2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_compressGrayHistograms")]
        internal static extern IntPtr l_compressGrayHistograms(HandleRef naa, int w, int h, IntPtr psize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_uncompressGrayHistograms")]
        internal static extern IntPtr l_uncompressGrayHistograms(IntPtr bytea, IntPtr size, out int pw, out int ph);

        // Translated images at the same resolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCompareWithTranslation")]
        internal static extern int pixCompareWithTranslation(HandleRef pix1, HandleRef pix2, int thresh, out int pdelx, out int pdely, out float pscore, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBestCorrelation")]
        internal static extern int pixBestCorrelation(HandleRef pix1, HandleRef pix2, int area1, int area2, int etransx, int etransy, int maxshift, out int tab8, out int pdelx, out int pdely, out float pscore, int debugflag);
        #endregion

        #region conncomp.c
        // Top-level calls:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnComp")]
        internal static extern IntPtr pixConnComp(HandleRef pixs, out IntPtr ppixa, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompPixa")]
        internal static extern IntPtr pixConnCompPixa(HandleRef pixs, out IntPtr ppixa, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompBB")]
        internal static extern IntPtr pixConnCompBB(HandleRef pixs, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountConnComp")]
        internal static extern int pixCountConnComp(HandleRef pixs, int connectivity, out int pcount);

        // Identify the next c.c.to be erased:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nextOnPixelInRaster")]
        internal static extern int nextOnPixelInRaster(HandleRef pixs, int xstart, int ystart, out int px, out int py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nextOnPixelInRasterLow")]
        internal static extern int nextOnPixelInRasterLow(IntPtr data, int w, int h, int wpl, int xstart, int ystart, out int px, out int py);

        // Erase the c.c., saving the b.b.:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBB")]
        internal static extern IntPtr pixSeedfillBB(HandleRef pixs, HandleRef stack, int x, int y, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill4BB")]
        internal static extern IntPtr pixSeedfill4BB(HandleRef pixs, HandleRef stack, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill8BB")]
        internal static extern IntPtr pixSeedfill8BB(HandleRef pixs, HandleRef stack, int x, int y);

        // Just erase the c.c.:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill")]
        internal static extern int pixSeedfill(HandleRef pixs, HandleRef stack, int x, int y, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill4")]
        internal static extern int pixSeedfill4(HandleRef pixs, HandleRef stack, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfill8")]
        internal static extern int pixSeedfill8(HandleRef pixs, HandleRef stack, int x, int y);
        #endregion

        #region convertfiles.c
        // Conversion to 1 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesTo1bpp")]
        internal static extern int convertFilesTo1bpp([MarshalAs(UnmanagedType.AnsiBStr)] string dirin, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int upscaling, int thresh, int firstpage, int npages, [MarshalAs(UnmanagedType.AnsiBStr)] string dirout, int outformat);
        #endregion

        #region convolve.c
        // Top level grayscale or color block convolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconv")]
        internal static extern IntPtr pixBlockconv(HandleRef pix, int wc, int hc);

        // Grayscale block convolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGray")]
        internal static extern IntPtr pixBlockconvGray(HandleRef pixs, HandleRef pixacc, int wc, int hc);

        // Accumulator for 1, 8 and 32 bpp convolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvAccum")]
        internal static extern IntPtr pixBlockconvAccum(HandleRef pixs);

        // Un-normalized grayscale block convolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGrayUnnormalized")]
        internal static extern IntPtr pixBlockconvGrayUnnormalized(HandleRef pixs, int wc, int hc);

        // Tiled grayscale or color block convolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvTiled")]
        internal static extern IntPtr pixBlockconvTiled(HandleRef pix, int wc, int hc, int nx, int ny);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockconvGrayTile")]
        internal static extern IntPtr pixBlockconvGrayTile(HandleRef pixs, HandleRef pixacc, int wc, int hc);

        // Convolution for mean, mean square, variance and rms deviation in specified window
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedStats")]
        internal static extern int pixWindowedStats(HandleRef pixs, int wc, int hc, int hasborder, out IntPtr ppixm, out IntPtr ppixms, out IntPtr pfpixv, out IntPtr pfpixrv);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedMean")]
        internal static extern IntPtr pixWindowedMean(HandleRef pixs, int wc, int hc, int hasborder, int normflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedMeanSquare")]
        internal static extern IntPtr pixWindowedMeanSquare(HandleRef pixs, int wc, int hc, int hasborder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedVariance")]
        internal static extern int pixWindowedVariance(HandleRef pixm, HandleRef pixms, out IntPtr pfpixv, out IntPtr pfpixrv);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeanSquareAccum")]
        internal static extern IntPtr pixMeanSquareAccum(HandleRef pixs);

        // Binary block sum and rank filter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlockrank")]
        internal static extern IntPtr pixBlockrank(HandleRef pixs, HandleRef pixacc, int wc, int hc, float rank);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlocksum")]
        internal static extern IntPtr pixBlocksum(HandleRef pixs, HandleRef pixacc, int wc, int hc);

        // Census transform
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCensusTransform")]
        internal static extern IntPtr pixCensusTransform(HandleRef pixs, int halfsize, HandleRef pixacc);

        // Generic convolution(with Pix)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolve")]
        internal static extern IntPtr pixConvolve(HandleRef pixs, HandleRef kel, int outdepth, int normflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveSep")]
        internal static extern IntPtr pixConvolveSep(HandleRef pixs, HandleRef kelx, HandleRef kely, int outdepth, int normflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveRGB")]
        internal static extern IntPtr pixConvolveRGB(HandleRef pixs, HandleRef kel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveRGBSep")]
        internal static extern IntPtr pixConvolveRGBSep(HandleRef pixs, HandleRef kelx, HandleRef kely);

        // Generic convolution(with float arrays)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvolve")]
        internal static extern IntPtr fpixConvolve(HandleRef fpixs, HandleRef kel, int normflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvolveSep")]
        internal static extern IntPtr fpixConvolveSep(HandleRef fpixs, HandleRef kelx, HandleRef kely, int normflag);

        // Convolution with bias(for non-negative output)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvolveWithBias")]
        internal static extern IntPtr pixConvolveWithBias(HandleRef pixs, HandleRef kel1, HandleRef kel2, int force8, out int pbias);

        // Set parameter for convolution subsampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setConvolveSampling")]
        internal static extern void l_setConvolveSampling(int xfact, int yfact);

        //  Additive gaussian noise
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGaussianNoise")]
        internal static extern IntPtr pixAddGaussianNoise(HandleRef pixs, float stdev);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gaussDistribSampling")]
        internal static extern float gaussDistribSampling();
        #endregion

        #region correlscore.c
        // Optimized 2 pix correlators(for jbig2 clustering)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScore")]
        internal static extern int pixCorrelationScore(HandleRef pix1, HandleRef pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out float pscore);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreThresholded")]
        internal static extern int pixCorrelationScoreThresholded(HandleRef pix1, HandleRef pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out int downcount, float score_threshold);

        // Simple 2 pix correlators
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreSimple")]
        internal static extern int pixCorrelationScoreSimple(HandleRef pix1, HandleRef pix2, int area1, int area2, float delx, float dely, int maxdiffw, int maxdiffh, out int tab, out float pscore);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCorrelationScoreShifted")]
        internal static extern int pixCorrelationScoreShifted(HandleRef pix1, HandleRef pix2, int area1, int area2, int delx, int dely, out int tab, out float pscore);
        #endregion

        #region dewarp1.c
        // Create/destroy dewarp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpCreate")]
        internal static extern IntPtr dewarpCreate(HandleRef pixs, int pageno);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpCreateRef")]
        internal static extern IntPtr dewarpCreateRef(int pageno, int refpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpDestroy")]
        internal static extern void dewarpDestroy(ref IntPtr pdew);

        // Create/destroy dewarpa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaCreate")]
        internal static extern IntPtr dewarpaCreate(int nptrs, int sampling, int redfactor, int minlines, int maxdist);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaCreateFromPixacomp")]
        internal static extern IntPtr dewarpaCreateFromPixacomp(HandleRef pixac, int useboth, int sampling, int minlines, int maxdist);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaDestroy")]
        internal static extern void dewarpaDestroy(ref IntPtr pdewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaDestroyDewarp")]
        internal static extern int dewarpaDestroyDewarp(ref IntPtr dewa, int pageno);

        // Dewarpa insertion/extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInsertDewarp")]
        internal static extern int dewarpaInsertDewarp(HandleRef dewa, HandleRef dew);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaGetDewarp")]
        internal static extern IntPtr dewarpaGetDewarp(HandleRef dewa, int index);

        // Setting parameters to control rendering from the model
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetCurvatures")]
        internal static extern int dewarpaSetCurvatures(HandleRef dewa, int max_linecurv, int min_diff_linecurv, int max_diff_linecurv, int max_edgecurv, int max_diff_edgecurv, int max_edgeslope);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaUseBothArrays")]
        internal static extern int dewarpaUseBothArrays(HandleRef dewa, int useboth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetCheckColumns")]
        internal static extern int dewarpaSetCheckColumns(HandleRef dewa, int check_columns);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetMaxDistance")]
        internal static extern int dewarpaSetMaxDistance(HandleRef dewa, int maxdist);

        // Dewarp serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpRead")]
        internal static extern IntPtr dewarpRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpReadStream")]
        internal static extern IntPtr dewarpReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpReadMem")]
        internal static extern IntPtr dewarpReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWrite")]
        internal static extern int dewarpWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef dew);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWriteStream")]
        internal static extern int dewarpWriteStream(IntPtr fp, HandleRef dew);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpWriteMem")]
        internal static extern int dewarpWriteMem(out IntPtr pdata, IntPtr psize, HandleRef dew);

        // Dewarpa serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaRead")]
        internal static extern IntPtr dewarpaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaReadStream")]
        internal static extern IntPtr dewarpaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaReadMem")]
        internal static extern IntPtr dewarpaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWrite")]
        internal static extern int dewarpaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef dewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWriteStream")]
        internal static extern int dewarpaWriteStream(IntPtr fp, HandleRef dewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaWriteMem")]
        internal static extern int dewarpaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef dewa);
        #endregion

        #region dewarp2.c
        // Build basic page disparity model
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpBuildPageModel")]
        internal static extern int dewarpBuildPageModel(HandleRef dew, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpFindVertDisparity")]
        internal static extern int dewarpFindVertDisparity(HandleRef dew, HandleRef ptaa, int rotflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpFindHorizDisparity")]
        internal static extern int dewarpFindHorizDisparity(HandleRef dew, HandleRef ptaa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpGetTextlineCenters")]
        internal static extern IntPtr dewarpGetTextlineCenters(HandleRef pixs, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpRemoveShortLines")]
        internal static extern IntPtr dewarpRemoveShortLines(HandleRef pixs, HandleRef ptaas, float fract, int debugflag);

        // Build disparity model for slope near binding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpFindHorizSlopeDisparity")]
        internal static extern int dewarpFindHorizSlopeDisparity(HandleRef dew, HandleRef pixb, float fractthresh, int parity);

        // Build the line disparity model
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpBuildLineModel")]
        internal static extern int dewarpBuildLineModel(HandleRef dew, int opensize, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);

        // Query model status
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaModelStatus")]
        internal static extern int dewarpaModelStatus(HandleRef dewa, int pageno, out int pvsuccess, out int phsuccess);
        #endregion

        #region dewarp3.c
        // Apply disparity array to pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaApplyDisparity")]
        internal static extern int dewarpaApplyDisparity(HandleRef dewa, int pageno, HandleRef pixs, int grayin, int x, int y, out IntPtr ppixd, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);

        // Apply disparity array to boxa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaApplyDisparityBoxa")]
        internal static extern int dewarpaApplyDisparityBoxa(HandleRef dewa, int pageno, HandleRef pixs, HandleRef boxas, int mapdir, int x, int y, out IntPtr pboxad, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);

        // Stripping out data and populating full res disparity
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpMinimize")]
        internal static extern int dewarpMinimize(HandleRef dew);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpPopulateFullRes")]
        internal static extern int dewarpPopulateFullRes(HandleRef dew, HandleRef pix, int x, int y);
        #endregion

        #region dewarp4.c
        // Top-level single page dewarper
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePage")]
        internal static extern int dewarpSinglePage(HandleRef pixs, int thresh, int adaptive, int useboth, int check_columns, out IntPtr ppixd, out IntPtr pdewa, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePageInit")]
        internal static extern int dewarpSinglePageInit(HandleRef pixs, int thresh, int adaptive, int useboth, int check_columns, out IntPtr ppixb, out IntPtr pdewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpSinglePageRun")]
        internal static extern int dewarpSinglePageRun(HandleRef pixs, HandleRef pixb, HandleRef dewa, out IntPtr ppixd, int debug);

        // Operations on dewarpa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaListPages")]
        internal static extern int dewarpaListPages(HandleRef dewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaSetValidModels")]
        internal static extern int dewarpaSetValidModels(HandleRef dewa, int notests, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInsertRefModels")]
        internal static extern int dewarpaInsertRefModels(HandleRef dewa, int notests, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaStripRefModels")]
        internal static extern int dewarpaStripRefModels(HandleRef dewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaRestoreModels")]
        internal static extern int dewarpaRestoreModels(HandleRef dewa);

        // Dewarp debugging output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaInfo")]
        internal static extern int dewarpaInfo(IntPtr fp, HandleRef dewa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaModelStats")]
        internal static extern int dewarpaModelStats(HandleRef dewa, out int pnnone, out int pnvsuccess, out int pnvvalid, out int pnhsuccess, out int pnhvalid, out int pnref);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpaShowArrays")]
        internal static extern int dewarpaShowArrays(HandleRef dewa, float scalefact, int first, int last);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpDebug")]
        internal static extern int dewarpDebug(HandleRef dew, [MarshalAs(UnmanagedType.AnsiBStr)] string subdirs, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dewarpShowResults")]
        internal static extern int dewarpShowResults(HandleRef dewa, HandleRef sa, HandleRef boxa, int firstpage, int lastpage, [MarshalAs(UnmanagedType.AnsiBStr)] string pdfout);
        #endregion

        #region dnabasic.c
        // Dna creation, destruction, copy, clone, etc.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreate")]
        internal static extern IntPtr l_dnaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreateFromIArray")]
        internal static extern IntPtr l_dnaCreateFromIArray(IntPtr iarray, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCreateFromDArray")]
        internal static extern IntPtr l_dnaCreateFromDArray(IntPtr darray, int size, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaMakeSequence")]
        internal static extern IntPtr l_dnaMakeSequence(double startval, double increment, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaDestroy")]
        internal static extern void l_dnaDestroy(ref IntPtr pda);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCopy")]
        internal static extern IntPtr l_dnaCopy(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaClone")]
        internal static extern IntPtr l_dnaClone(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaEmpty")]
        internal static extern int l_dnaEmpty(HandleRef da);

        // Dna: add/remove number and extend array
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaAddNumber")]
        internal static extern int l_dnaAddNumber(HandleRef da, double val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaInsertNumber")]
        internal static extern int l_dnaInsertNumber(HandleRef da, int index, double val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveNumber")]
        internal static extern int l_dnaRemoveNumber(HandleRef da, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaReplaceNumber")]
        internal static extern int l_dnaReplaceNumber(HandleRef da, int index, double val);

        // Dna accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetCount")]
        internal static extern int l_dnaGetCount(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetCount")]
        internal static extern int l_dnaSetCount(HandleRef da, int newcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetDValue")]
        internal static extern int l_dnaGetDValue(HandleRef da, int index, out double pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetIValue")]
        internal static extern int l_dnaGetIValue(HandleRef da, int index, out int pival);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetValue")]
        internal static extern int l_dnaSetValue(HandleRef da, int index, double val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaShiftValue")]
        internal static extern int l_dnaShiftValue(HandleRef da, int index, double diff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetIArray")]
        internal static extern IntPtr l_dnaGetIArray(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetDArray")]
        internal static extern IntPtr l_dnaGetDArray(HandleRef da, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetRefcount")]
        internal static extern int l_dnaGetRefcount(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaChangeRefcount")]
        internal static extern int l_dnaChangeRefcount(HandleRef da, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaGetParameters")]
        internal static extern int l_dnaGetParameters(HandleRef da, out double pstartx, out double pdelx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaSetParameters")]
        internal static extern int l_dnaSetParameters(HandleRef da, double startx, double delx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaCopyParameters")]
        internal static extern int l_dnaCopyParameters(HandleRef dad, HandleRef das);

        // Serialize Dna for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRead")]
        internal static extern IntPtr l_dnaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaReadStream")]
        internal static extern IntPtr l_dnaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaWrite")]
        internal static extern int l_dnaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaWriteStream")]
        internal static extern int l_dnaWriteStream(IntPtr fp, HandleRef da);

        // Dnaa creation, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaCreate")]
        internal static extern IntPtr l_dnaaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaCreateFull")]
        internal static extern IntPtr l_dnaaCreateFull(int nptr, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaTruncate")]
        internal static extern int l_dnaaTruncate(HandleRef daa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaDestroy")]
        internal static extern void l_dnaaDestroy(ref IntPtr pdaa);

        // Add Dna to Dnaa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaAddDna")]
        internal static extern int l_dnaaAddDna(HandleRef daa, HandleRef da, int copyflag);

        // Dnaa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetCount")]
        internal static extern int l_dnaaGetCount(HandleRef daa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetDnaCount")]
        internal static extern int l_dnaaGetDnaCount(HandleRef daa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetNumberCount")]
        internal static extern int l_dnaaGetNumberCount(HandleRef daa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetDna")]
        internal static extern IntPtr l_dnaaGetDna(HandleRef daa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaReplaceDna")]
        internal static extern int l_dnaaReplaceDna(HandleRef daa, int index, HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaGetValue")]
        internal static extern int l_dnaaGetValue(HandleRef daa, int i, int j, out double pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaAddNumber")]
        internal static extern int l_dnaaAddNumber(HandleRef daa, int index, double val);

        // Serialize Dnaa for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaRead")]
        internal static extern IntPtr l_dnaaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaReadStream")]
        internal static extern IntPtr l_dnaaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaWrite")]
        internal static extern int l_dnaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef daa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaWriteStream")]
        internal static extern int l_dnaaWriteStream(IntPtr fp, HandleRef daa);
        #endregion

        #region dnafunc1.c
        // Rearrangements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaJoin")]
        internal static extern int l_dnaJoin(HandleRef dad, HandleRef das, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaaFlattenToDna")]
        internal static extern IntPtr l_dnaaFlattenToDna(HandleRef daa);

        // Conversion between numa and dna
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaConvertToNuma")]
        internal static extern IntPtr l_dnaConvertToNuma(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToDna")]
        internal static extern IntPtr numaConvertToDna(HandleRef na);

        // Set operations using aset (rbtree)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaUnionByAset")]
        internal static extern IntPtr l_dnaUnionByAset(HandleRef da1, HandleRef da2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveDupsByAset")]
        internal static extern IntPtr l_dnaRemoveDupsByAset(HandleRef das);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaIntersectionByAset")]
        internal static extern IntPtr l_dnaIntersectionByAset(HandleRef da1, HandleRef da2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromDna")]
        internal static extern IntPtr l_asetCreateFromDna(HandleRef da);

        // Miscellaneous operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaDiffAdjValues")]
        internal static extern IntPtr l_dnaDiffAdjValues(HandleRef das);
        #endregion

        #region dnahash.c
        // DnaHash creation, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreate")]
        internal static extern IntPtr l_dnaHashCreate(int nbuckets, int initsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashDestroy")]
        internal static extern void l_dnaHashDestroy(ref IntPtr pdahash);

        // DnaHash: Accessors and modifiers*
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetCount")]
        internal static extern int l_dnaHashGetCount(HandleRef dahash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetTotalCount")]
        internal static extern int l_dnaHashGetTotalCount(HandleRef dahash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashGetDna")]
        internal static extern IntPtr l_dnaHashGetDna(HandleRef dahash, long key, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashAdd")]
        internal static extern int l_dnaHashAdd(HandleRef dahash, long key, double value);

        // DnaHash: Operations on Dna
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromDna")]
        internal static extern IntPtr l_dnaHashCreateFromDna(HandleRef da);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaRemoveDupsByHash")]
        internal static extern int l_dnaRemoveDupsByHash(HandleRef das, out IntPtr pdad, out IntPtr pdahash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaMakeHistoByHash")]
        internal static extern int l_dnaMakeHistoByHash(HandleRef das, out IntPtr pdahash, out IntPtr pdav, out IntPtr pdac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaIntersectionByHash")]
        internal static extern IntPtr l_dnaIntersectionByHash(HandleRef da1, HandleRef da2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaFindValByHash")]
        internal static extern int l_dnaFindValByHash(HandleRef da, HandleRef dahash, double val, out int pindex);
        #endregion

        #region dwacomb.2.c
        // Top-level fast binary morphology with auto-generated sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphDwa_2")]
        internal static extern IntPtr pixMorphDwa_2(HandleRef pixd, HandleRef pixs, int operation, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFMorphopGen_2")]
        internal static extern IntPtr pixFMorphopGen_2(HandleRef pixd, HandleRef pixs, int operation, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        #endregion

        #region dwacomblow.2.c
        //  Dispatcher:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphopgen_low_2")]
        internal static extern int fmorphopgen_low_2(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);
        #endregion

        #region edge.c
        // Sobel edge detecting filter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSobelEdgeFilter")]
        internal static extern IntPtr pixSobelEdgeFilter(HandleRef pixs, int orientflag);

        // Two-sided edge gradient filter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTwoSidedEdgeFilter")]
        internal static extern IntPtr pixTwoSidedEdgeFilter(HandleRef pixs, int orientflag);

        // Measurement of edge smoothness
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeasureEdgeSmoothness")]
        internal static extern int pixMeasureEdgeSmoothness(HandleRef pixs, int side, int minjump, int minreversal, out float pjpl, out float pjspl, out float prpl, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetEdgeProfile")]
        internal static extern IntPtr pixGetEdgeProfile(HandleRef pixs, int side, [MarshalAs(UnmanagedType.AnsiBStr)] string debugfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLastOffPixelInRun")]
        internal static extern int pixGetLastOffPixelInRun(HandleRef pixs, int x, int y, int direction, out int ploc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLastOnPixelInRun")]
        internal static extern int pixGetLastOnPixelInRun(HandleRef pixs, int x, int y, int direction, out int ploc);
        #endregion

        #region encoding.c
        // Base64
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "encodeBase64")]
        internal static extern IntPtr encodeBase64(IntPtr inarray, int insize, out int poutsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "decodeBase64")]
        internal static extern IntPtr decodeBase64([MarshalAs(UnmanagedType.AnsiBStr)] string inarray, int insize, out int poutsize);

        // Ascii85
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "encodeAscii85")]
        internal static extern IntPtr encodeAscii85(IntPtr inarray, int insize, out int poutsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "decodeAscii85")]
        internal static extern IntPtr decodeAscii85([MarshalAs(UnmanagedType.AnsiBStr)] string inarray, int insize, out int poutsize);

        // String reformatting for base 64 encoded data
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "reformatPacked64")]
        internal static extern IntPtr reformatPacked64([MarshalAs(UnmanagedType.AnsiBStr)] string inarray, int insize, int leadspace, int linechars, int addquotes, out int poutsize);
        #endregion

        #region enhance.c
        // Gamma TRC(tone reproduction curve) mapping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRC")]
        internal static extern IntPtr pixGammaTRC(HandleRef pixd, HandleRef pixs, float gamma, int minval, int maxval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRCMasked")]
        internal static extern IntPtr pixGammaTRCMasked(HandleRef pixd, HandleRef pixs, HandleRef pixm, float gamma, int minval, int maxval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGammaTRCWithAlpha")]
        internal static extern IntPtr pixGammaTRCWithAlpha(HandleRef pixd, HandleRef pixs, float gamma, int minval, int maxval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGammaTRC")]
        internal static extern IntPtr numaGammaTRC(float gamma, int minval, int maxval);

        // Contrast enhancement
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastTRC")]
        internal static extern IntPtr pixContrastTRC(HandleRef pixd, HandleRef pixs, float factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixContrastTRCMasked")]
        internal static extern IntPtr pixContrastTRCMasked(HandleRef pixd, HandleRef pixs, HandleRef pixm, float factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaContrastTRC")]
        internal static extern IntPtr numaContrastTRC(float factor);

        // Histogram equalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEqualizeTRC")]
        internal static extern IntPtr pixEqualizeTRC(HandleRef pixd, HandleRef pixs, float fract, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEqualizeTRC")]
        internal static extern IntPtr numaEqualizeTRC(HandleRef pix, float fract, int factor);

        // Generic TRC mapper
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTRCMap")]
        internal static extern int pixTRCMap(HandleRef pixs, HandleRef pixm, HandleRef na);

        // Unsharp-masking
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMasking")]
        internal static extern IntPtr pixUnsharpMasking(HandleRef pixs, int halfwidth, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray")]
        internal static extern IntPtr pixUnsharpMaskingGray(HandleRef pixs, int halfwidth, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingFast")]
        internal static extern IntPtr pixUnsharpMaskingFast(HandleRef pixs, int halfwidth, float fract, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGrayFast")]
        internal static extern IntPtr pixUnsharpMaskingGrayFast(HandleRef pixs, int halfwidth, float fract, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray1D")]
        internal static extern IntPtr pixUnsharpMaskingGray1D(HandleRef pixs, int halfwidth, float fract, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnsharpMaskingGray2D")]
        internal static extern IntPtr pixUnsharpMaskingGray2D(HandleRef pixs, int halfwidth, float fract);

        // Hue and saturation modification
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyHue")]
        internal static extern IntPtr pixModifyHue(HandleRef pixd, HandleRef pixs, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifySaturation")]
        internal static extern IntPtr pixModifySaturation(HandleRef pixd, HandleRef pixs, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeasureSaturation")]
        internal static extern int pixMeasureSaturation(HandleRef pixs, int factor, out float psat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyBrightness")]
        internal static extern IntPtr pixModifyBrightness(HandleRef pixd, HandleRef pixs, float fract);

        // Color shifting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorShiftRGB")]
        internal static extern IntPtr pixColorShiftRGB(HandleRef pixs, float rfract, float gfract, float bfract);

        // General multiplicative constant color transform
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstantColor")]
        internal static extern IntPtr pixMultConstantColor(HandleRef pixs, float rfact, float gfact, float bfact);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultMatrixColor")]
        internal static extern IntPtr pixMultMatrixColor(HandleRef pixs, HandleRef kel);

        // Edge by bandpass
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHalfEdgeByBandpass")]
        internal static extern IntPtr pixHalfEdgeByBandpass(HandleRef pixs, int sm1h, int sm1v, int sm2h, int sm2v);
        #endregion

        #region fhmtauto.c
        // Main function calls:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen")]
        internal static extern int fhmtautogen(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen1")]
        internal static extern int fhmtautogen1(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtautogen2")]
        internal static extern int fhmtautogen2(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        #endregion

        #region fhmtgen.1.c
        // Top-level fast hit-miss transform with auto-generated sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHMTDwa_1")]
        internal static extern IntPtr pixHMTDwa_1(HandleRef pixd, HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFHMTGen_1")]
        internal static extern IntPtr pixFHMTGen_1(HandleRef pixd, HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        #endregion

        #region fhmtgenlow.1.c
        // Fast hmt dispatcher
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fhmtgen_low_1")]
        internal static extern int fhmtgen_low_1(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);
        #endregion

        #region finditalic.c
        // Locate italic words.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixItalicWords")]
        internal static extern int pixItalicWords(HandleRef pixs, HandleRef boxaw, HandleRef pixw, out IntPtr pboxa, int debugflag);
        #endregion

        #region flipdetect.c
        // Page orientation detection(pure rotation by 90 degree increments):
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOrientDetect")]
        internal static extern int pixOrientDetect(HandleRef pixs, out float pupconf, out float pleftconf, int mincount, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeOrientDecision")]
        internal static extern int makeOrientDecision(float upconf, float leftconf, float minupconf, float minratio, out int porient, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetect")]
        internal static extern int pixUpDownDetect(HandleRef pixs, out float pconf, int mincount, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectGeneral")]
        internal static extern int pixUpDownDetectGeneral(HandleRef pixs, out float pconf, int mincount, int npixels, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOrientDetectDwa")]
        internal static extern int pixOrientDetectDwa(HandleRef pixs, out float pupconf, out float pleftconf, int mincount, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectDwa")]
        internal static extern int pixUpDownDetectDwa(HandleRef pixs, out float pconf, int mincount, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUpDownDetectGeneralDwa")]
        internal static extern int pixUpDownDetectGeneralDwa(HandleRef pixs, out float pconf, int mincount, int npixels, int debug);

        // Page mirror detection(flip 180 degrees about line in plane of image):
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirrorDetect")]
        internal static extern int pixMirrorDetect(HandleRef pixs, out float pconf, int mincount, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirrorDetectDwa")]
        internal static extern int pixMirrorDetectDwa(HandleRef pixs, out float pconf, int mincount, int debug);
        #endregion

        #region fliphmtgen.c
        // DWA implementation of hit-miss transforms with auto-generated sels for pixOrientDetectDwa() and pixUpDownDetectDwa() in flipdetect.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipFHMTGen")]
        internal static extern IntPtr pixFlipFHMTGen(HandleRef pixd, HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        #endregion

        #region fmorphauto.c
        // Main function calls:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen")]
        internal static extern int fmorphautogen(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen1")]
        internal static extern int fmorphautogen1(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphautogen2")]
        internal static extern int fmorphautogen2(HandleRef sela, int fileindex, [MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        #endregion

        #region fmorphgen.1.c
        // Top-level fast binary morphology with auto-generated sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphDwa_1")]
        internal static extern IntPtr pixMorphDwa_1(HandleRef pixd, HandleRef pixs, int operation, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFMorphopGen_1")]
        internal static extern IntPtr pixFMorphopGen_1(HandleRef pixd, HandleRef pixs, int operation, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);
        #endregion

        #region fmorphgenlow.1.c
        // Low-level fast binary morphology with auto-generated sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fmorphopgen_low_1")]
        internal static extern int fmorphopgen_low_1(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, int index);
        #endregion

        #region fpix1.c
        // FPix Create/copy/destroy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCreate")]
        internal static extern IntPtr fpixCreate(int width, int height);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCreateTemplate")]
        internal static extern IntPtr fpixCreateTemplate(HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixClone")]
        internal static extern IntPtr fpixClone(HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCopy")]
        internal static extern IntPtr fpixCopy(HandleRef fpixd, HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixResizeImageData")]
        internal static extern int fpixResizeImageData(HandleRef fpixd, HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixDestroy")]
        internal static extern void fpixDestroy(ref IntPtr pfpix);

        // FPix accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetDimensions")]
        internal static extern int fpixGetDimensions(HandleRef fpix, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetDimensions")]
        internal static extern int fpixSetDimensions(HandleRef fpix, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetWpl")]
        internal static extern int fpixGetWpl(HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetWpl")]
        internal static extern int fpixSetWpl(HandleRef fpix, int wpl);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetRefcount")]
        internal static extern int fpixGetRefcount(HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixChangeRefcount")]
        internal static extern int fpixChangeRefcount(HandleRef fpix, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetResolution")]
        internal static extern int fpixGetResolution(HandleRef fpix, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetResolution")]
        internal static extern int fpixSetResolution(HandleRef fpix, int xres, int yres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixCopyResolution")]
        internal static extern int fpixCopyResolution(HandleRef fpixd, HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetData")]
        internal static extern IntPtr fpixGetData(HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetData")]
        internal static extern int fpixSetData(HandleRef fpix, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetPixel")]
        internal static extern int fpixGetPixel(HandleRef fpix, int x, int y, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetPixel")]
        internal static extern int fpixSetPixel(HandleRef fpix, int x, int y, float val);

        // FPixa Create/copy/destroy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaCreate")]
        internal static extern IntPtr fpixaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaCopy")]
        internal static extern IntPtr fpixaCopy(HandleRef fpixa, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaDestroy")]
        internal static extern void fpixaDestroy(ref IntPtr pfpixa);

        // FPixa addition
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaAddFPix")]
        internal static extern int fpixaAddFPix(HandleRef fpixa, HandleRef fpix, int copyflag);

        // FPixa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetCount")]
        internal static extern int fpixaGetCount(HandleRef fpixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaChangeRefcount")]
        internal static extern int fpixaChangeRefcount(HandleRef fpixa, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetFPix")]
        internal static extern IntPtr fpixaGetFPix(HandleRef fpixa, int index, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetFPixDimensions")]
        internal static extern int fpixaGetFPixDimensions(HandleRef fpixa, int index, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetData")]
        internal static extern IntPtr fpixaGetData(HandleRef fpixa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaGetPixel")]
        internal static extern int fpixaGetPixel(HandleRef fpixa, int index, int x, int y, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaSetPixel")]
        internal static extern int fpixaSetPixel(HandleRef fpixa, int index, int x, int y, float val);

        // DPix Create/copy/destroy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCreate")]
        internal static extern IntPtr dpixCreate(int width, int height);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCreateTemplate")]
        internal static extern IntPtr dpixCreateTemplate(HandleRef dpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixClone")]
        internal static extern IntPtr dpixClone(HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCopy")]
        internal static extern IntPtr dpixCopy(HandleRef dpixd, HandleRef dpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixResizeImageData")]
        internal static extern int dpixResizeImageData(HandleRef dpixd, HandleRef dpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixDestroy")]
        internal static extern void dpixDestroy(ref IntPtr pdpix);

        // DPix accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetDimensions")]
        internal static extern int dpixGetDimensions(HandleRef dpix, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetDimensions")]
        internal static extern int dpixSetDimensions(HandleRef dpix, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetWpl")]
        internal static extern int dpixGetWpl(HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetWpl")]
        internal static extern int dpixSetWpl(HandleRef dpix, int wpl);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetRefcount")]
        internal static extern int dpixGetRefcount(HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixChangeRefcount")]
        internal static extern int dpixChangeRefcount(HandleRef dpix, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetResolution")]
        internal static extern int dpixGetResolution(HandleRef dpix, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetResolution")]
        internal static extern int dpixSetResolution(HandleRef dpix, int xres, int yres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixCopyResolution")]
        internal static extern int dpixCopyResolution(HandleRef dpixd, HandleRef dpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetData")]
        internal static extern IntPtr dpixGetData(HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetData")]
        internal static extern int dpixSetData(HandleRef dpix, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetPixel")]
        internal static extern int dpixGetPixel(HandleRef dpix, int x, int y, out double pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetPixel")]
        internal static extern int dpixSetPixel(HandleRef dpix, int x, int y, double val);

        // FPix serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRead")]
        internal static extern IntPtr fpixRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixReadStream")]
        internal static extern IntPtr fpixReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixReadMem")]
        internal static extern IntPtr fpixReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWrite")]
        internal static extern int fpixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWriteStream")]
        internal static extern int fpixWriteStream(IntPtr fp, HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixWriteMem")]
        internal static extern int fpixWriteMem(out IntPtr pdata, IntPtr psize, HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixEndianByteSwap")]
        internal static extern IntPtr fpixEndianByteSwap(HandleRef fpixd, HandleRef fpixs);

        // DPix serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixRead")]
        internal static extern IntPtr dpixRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixReadStream")]
        internal static extern IntPtr dpixReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixReadMem")]
        internal static extern IntPtr dpixReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWrite")]
        internal static extern int dpixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWriteStream")]
        internal static extern int dpixWriteStream(IntPtr fp, HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixWriteMem")]
        internal static extern int dpixWriteMem(out IntPtr pdata, IntPtr psize, HandleRef dpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixEndianByteSwap")]
        internal static extern IntPtr dpixEndianByteSwap(HandleRef dpixd, HandleRef dpixs);

        // Print FPix(subsampled, for debugging)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixPrintStream")]
        internal static extern int fpixPrintStream(IntPtr fp, HandleRef fpix, int factor);
        #endregion

        #region fpix2.c
        // Interconversions between Pix, FPix and DPix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToFPix")]
        internal static extern IntPtr pixConvertToFPix(HandleRef pixs, int ncomps);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToDPix")]
        internal static extern IntPtr pixConvertToDPix(HandleRef pixs, int ncomps);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvertToPix")]
        internal static extern IntPtr fpixConvertToPix(HandleRef fpixs, int outdepth, int negvals, int errorflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixDisplayMaxDynamicRange")]
        internal static extern IntPtr fpixDisplayMaxDynamicRange(HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixConvertToDPix")]
        internal static extern IntPtr fpixConvertToDPix(HandleRef fpix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixConvertToPix")]
        internal static extern IntPtr dpixConvertToPix(HandleRef dpixs, int outdepth, int negvals, int errorflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixConvertToFPix")]
        internal static extern IntPtr dpixConvertToFPix(HandleRef dpix);

        // Min/max value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetMin")]
        internal static extern int fpixGetMin(HandleRef fpix, out float pminval, out int pxminloc, out int pyminloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixGetMax")]
        internal static extern int fpixGetMax(HandleRef fpix, out float pmaxval, out int pxmaxloc, out int pymaxloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetMin")]
        internal static extern int dpixGetMin(HandleRef dpix, out double pminval, out int pxminloc, out int pyminloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixGetMax")]
        internal static extern int dpixGetMax(HandleRef dpix, out double pmaxval, out int pxmaxloc, out int pymaxloc);

        // Integer scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixScaleByInteger")]
        internal static extern IntPtr fpixScaleByInteger(HandleRef fpixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixScaleByInteger")]
        internal static extern IntPtr dpixScaleByInteger(HandleRef dpixs, int factor);

        // Arithmetic operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixLinearCombination")]
        internal static extern IntPtr fpixLinearCombination(HandleRef fpixd, HandleRef fpixs1, HandleRef fpixs2, float a, float b);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddMultConstant")]
        internal static extern int fpixAddMultConstant(HandleRef fpix, float addc, float multc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixLinearCombination")]
        internal static extern IntPtr dpixLinearCombination(HandleRef dpixd, HandleRef dpixs1, HandleRef dpixs2, float a, float b);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixAddMultConstant")]
        internal static extern int dpixAddMultConstant(HandleRef dpix, double addc, double multc);

        // Set all
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixSetAllArbitrary")]
        internal static extern int fpixSetAllArbitrary(HandleRef fpix, float inval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "dpixSetAllArbitrary")]
        internal static extern int dpixSetAllArbitrary(HandleRef dpix, double inval);

        // FPix border functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddBorder")]
        internal static extern IntPtr fpixAddBorder(HandleRef fpixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRemoveBorder")]
        internal static extern IntPtr fpixRemoveBorder(HandleRef fpixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddMirroredBorder")]
        internal static extern IntPtr fpixAddMirroredBorder(HandleRef fpixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddContinuedBorder")]
        internal static extern IntPtr fpixAddContinuedBorder(HandleRef fpixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAddSlopeBorder")]
        internal static extern IntPtr fpixAddSlopeBorder(HandleRef fpixs, int left, int right, int top, int bot);

        // FPix simple rasterop
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRasterop")]
        internal static extern int fpixRasterop(HandleRef fpixd, int dx, int dy, int dw, int dh, HandleRef fpixs, int sx, int sy);

        // FPix rotation by multiples of 90 degrees
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotateOrth")]
        internal static extern IntPtr fpixRotateOrth(HandleRef fpixs, int quads);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotate180")]
        internal static extern IntPtr fpixRotate180(HandleRef fpixd, HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRotate90")]
        internal static extern IntPtr fpixRotate90(HandleRef fpixs, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixFlipLR")]
        internal static extern IntPtr fpixFlipLR(HandleRef fpixd, HandleRef fpixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixFlipTB")]
        internal static extern IntPtr fpixFlipTB(HandleRef fpixd, HandleRef fpixs);

        // FPix affine and projective interpolated transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAffinePta")]
        internal static extern IntPtr fpixAffinePta(HandleRef fpixs, HandleRef ptad, HandleRef ptas, int border, float inval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAffine")]
        internal static extern IntPtr fpixAffine(HandleRef fpixs, IntPtr vc, float inval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixProjectivePta")]
        internal static extern IntPtr fpixProjectivePta(HandleRef fpixs, HandleRef ptad, HandleRef ptas, int border, float inval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixProjective")]
        internal static extern IntPtr fpixProjective(HandleRef fpixs, IntPtr vc, float inval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearInterpolatePixelFloat")]
        internal static extern int linearInterpolatePixelFloat(IntPtr datas, int w, int h, float x, float y, float inval, out float pval);

        // Thresholding to 1 bpp Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixThresholdToPix")]
        internal static extern IntPtr fpixThresholdToPix(HandleRef fpix, float thresh);

        // Generate function from components
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixComponentFunction")]
        internal static extern IntPtr pixComponentFunction(HandleRef pix, float rnum, float gnum, float bnum, float rdenom, float gdenom, float bdenom);
        #endregion

        #region gifio.c
        // Read gif file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamGif")]
        internal static extern IntPtr pixReadStreamGif(IntPtr fp);

        // Write gif file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamGif")]
        internal static extern int pixWriteStreamGif(IntPtr fp, HandleRef pix);

        // Read/write gif from/to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemGif")]
        internal static extern IntPtr pixReadMemGif(IntPtr cdata, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemGif")]
        internal static extern int pixWriteMemGif(out IntPtr pdata, IntPtr psize, HandleRef pix);
        #endregion

        #region gplot.c
        // Basic plotting functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotCreate")]
        internal static extern IntPtr gplotCreate([MarshalAs(UnmanagedType.AnsiBStr)] string rootname, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string xlabel, [MarshalAs(UnmanagedType.AnsiBStr)] string ylabel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotDestroy")]
        internal static extern void gplotDestroy(ref IntPtr pgplot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotAddPlot")]
        internal static extern int gplotAddPlot(HandleRef gplot, HandleRef nax, HandleRef nay, int plotstyle, [MarshalAs(UnmanagedType.AnsiBStr)] string plottitle);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSetScaling")]
        internal static extern int gplotSetScaling(HandleRef gplot, int scaling);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotMakeOutput")]
        internal static extern int gplotMakeOutput(HandleRef gplot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotGenCommandFile")]
        internal static extern int gplotGenCommandFile(HandleRef gplot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotGenDataFiles")]
        internal static extern int gplotGenDataFiles(HandleRef gplot);

        // Quick and dirty plots
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimple1")]
        internal static extern int gplotSimple1(HandleRef na, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimple2")]
        internal static extern int gplotSimple2(HandleRef na1, HandleRef na2, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleN")]
        internal static extern int gplotSimpleN(HandleRef naa, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXY1")]
        internal static extern int gplotSimpleXY1(HandleRef nax, HandleRef nay, int plotstyle, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXY2")]
        internal static extern int gplotSimpleXY2(HandleRef nax, HandleRef nay1, HandleRef nay2, int plotstyle, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotSimpleXYN")]
        internal static extern int gplotSimpleXYN(HandleRef nax, HandleRef naay, int plotstyle, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string outroot, [MarshalAs(UnmanagedType.AnsiBStr)] string title);

        // Serialize for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotRead")]
        internal static extern IntPtr gplotRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gplotWrite")]
        internal static extern int gplotWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef gplot);
        #endregion

        #region graphics.c
        // Pta generation for arbitrary shapes built with lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaLine")]
        internal static extern IntPtr generatePtaLine(int x1, int y1, int x2, int y2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaWideLine")]
        internal static extern IntPtr generatePtaWideLine(int x1, int y1, int x2, int y2, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaBox")]
        internal static extern IntPtr generatePtaBox(HandleRef box, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaBoxa")]
        internal static extern IntPtr generatePtaBoxa(HandleRef boxa, int width, int removedups);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaHashBox")]
        internal static extern IntPtr generatePtaHashBox(HandleRef box, int spacing, int width, int orient, int outline);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaHashBoxa")]
        internal static extern IntPtr generatePtaHashBoxa(HandleRef boxa, int spacing, int width, int orient, int outline, int removedups);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaaBoxa")]
        internal static extern IntPtr generatePtaaBoxa(HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaaHashBoxa")]
        internal static extern IntPtr generatePtaaHashBoxa(HandleRef boxa, int spacing, int width, int orient, int outline);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaPolyline")]
        internal static extern IntPtr generatePtaPolyline(HandleRef ptas, int width, int closeflag, int removedups);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaGrid")]
        internal static extern IntPtr generatePtaGrid(int w, int h, int nx, int ny, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertPtaLineTo4cc")]
        internal static extern IntPtr convertPtaLineTo4cc(HandleRef ptas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaFilledCircle")]
        internal static extern IntPtr generatePtaFilledCircle(int radius);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaFilledSquare")]
        internal static extern IntPtr generatePtaFilledSquare(int side);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generatePtaLineFromPt")]
        internal static extern IntPtr generatePtaLineFromPt(int x, int y, double length, double radang);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "locatePtRadially")]
        internal static extern int locatePtRadially(int xr, int yr, double dist, double radang, out double px, out double py);

        // Rendering function plots directly on images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPlotFromNuma")]
        internal static extern int pixRenderPlotFromNuma(out IntPtr ppix, HandleRef na, int plotloc, int linewidth, int max, uint color);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePlotPtaFromNuma")]
        internal static extern IntPtr makePlotPtaFromNuma(HandleRef na, int size, int plotloc, int linewidth, int max);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPlotFromNumaGen")]
        internal static extern int pixRenderPlotFromNumaGen(out IntPtr ppix, HandleRef na, int orient, int linewidth, int refpos, int max, int drawref, uint color);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePlotPtaFromNumaGen")]
        internal static extern IntPtr makePlotPtaFromNumaGen(HandleRef na, int orient, int linewidth, int refpos, int max, int drawref);

        // Pta rendering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPta")]
        internal static extern int pixRenderPta(HandleRef pix, HandleRef pta, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPtaArb")]
        internal static extern int pixRenderPtaArb(HandleRef pix, HandleRef pta, byte rval, byte gval, byte bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPtaBlend")]
        internal static extern int pixRenderPtaBlend(HandleRef pix, HandleRef pta, byte rval, byte gval, byte bval, float fract);

        // Rendering of arbitrary shapes built with lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLine")]
        internal static extern int pixRenderLine(HandleRef pix, int x1, int y1, int x2, int y2, int width, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLineArb")]
        internal static extern int pixRenderLineArb(HandleRef pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderLineBlend")]
        internal static extern int pixRenderLineBlend(HandleRef pix, int x1, int y1, int x2, int y2, int width, byte rval, byte gval, byte bval, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBox")]
        internal static extern int pixRenderBox(HandleRef pix, HandleRef box, int width, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxArb")]
        internal static extern int pixRenderBoxArb(HandleRef pix, HandleRef box, int width, byte rval, byte gval, byte bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxBlend")]
        internal static extern int pixRenderBoxBlend(HandleRef pix, HandleRef box, int width, byte rval, byte gval, byte bval, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxa")]
        internal static extern int pixRenderBoxa(HandleRef pix, HandleRef boxa, int width, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxaArb")]
        internal static extern int pixRenderBoxaArb(HandleRef pix, HandleRef boxa, int width, byte rval, byte gval, byte bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderBoxaBlend")]
        internal static extern int pixRenderBoxaBlend(HandleRef pix, HandleRef boxa, int width, byte rval, byte gval, byte bval, float fract, int removedups);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBox")]
        internal static extern int pixRenderHashBox(HandleRef pix, HandleRef box, int spacing, int width, int orient, int outline, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxArb")]
        internal static extern int pixRenderHashBoxArb(HandleRef pix, HandleRef box, int spacing, int width, int orient, int outline, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxBlend")]
        internal static extern int pixRenderHashBoxBlend(HandleRef pix, HandleRef box, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashMaskArb")]
        internal static extern int pixRenderHashMaskArb(HandleRef pix, HandleRef pixm, int x, int y, int spacing, int width, int orient, int outline, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxa")]
        internal static extern int pixRenderHashBoxa(HandleRef pix, HandleRef boxa, int spacing, int width, int orient, int outline, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxaArb")]
        internal static extern int pixRenderHashBoxaArb(HandleRef pix, HandleRef boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderHashBoxaBlend")]
        internal static extern int pixRenderHashBoxaBlend(HandleRef pix, HandleRef boxa, int spacing, int width, int orient, int outline, int rval, int gval, int bval, float fract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolyline")]
        internal static extern int pixRenderPolyline(HandleRef pix, HandleRef ptas, int width, int op, int closeflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolylineArb")]
        internal static extern int pixRenderPolylineArb(HandleRef pix, HandleRef ptas, int width, byte rval, byte gval, byte bval, int closeflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolylineBlend")]
        internal static extern int pixRenderPolylineBlend(HandleRef pix, HandleRef ptas, int width, byte rval, byte gval, byte bval, float fract, int closeflag, int removedups);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderGridArb")]
        internal static extern int pixRenderGridArb(HandleRef pix, int nx, int ny, int width, byte rval, byte gval, byte bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderRandomCmapPtaa")]
        internal static extern IntPtr pixRenderRandomCmapPtaa(HandleRef pix, HandleRef ptaa, int polyflag, int width, int closeflag);

        // Rendering and filling of polygons
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderPolygon")]
        internal static extern IntPtr pixRenderPolygon(HandleRef ptas, int width, out int pxmin, out int pymin);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillPolygon")]
        internal static extern IntPtr pixFillPolygon(HandleRef pixs, HandleRef pta, int xmin, int ymin);

        // Contour rendering on grayscale images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRenderContours")]
        internal static extern IntPtr pixRenderContours(HandleRef pixs, int startval, int incr, int outdepth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixAutoRenderContours")]
        internal static extern IntPtr fpixAutoRenderContours(HandleRef fpix, int ncontours);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixRenderContours")]
        internal static extern IntPtr fpixRenderContours(HandleRef fpixs, float incr, float proxim);

        // Boundary pt generation on 1 bpp images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGeneratePtaBoundary")]
        internal static extern IntPtr pixGeneratePtaBoundary(HandleRef pixs, int width);
        #endregion

        #region graymorph.c
        // Top-level grayscale morphological operations(van Herk / Gil-Werman)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeGray")]
        internal static extern IntPtr pixErodeGray(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateGray")]
        internal static extern IntPtr pixDilateGray(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGray")]
        internal static extern IntPtr pixOpenGray(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGray")]
        internal static extern IntPtr pixCloseGray(HandleRef pixs, int hsize, int vsize);

        // Special operations for 1x3, 3x1 and 3x3 Sels(direct)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeGray3")]
        internal static extern IntPtr pixErodeGray3(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateGray3")]
        internal static extern IntPtr pixDilateGray3(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGray3")]
        internal static extern IntPtr pixOpenGray3(HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGray3")]
        internal static extern IntPtr pixCloseGray3(HandleRef pixs, int hsize, int vsize);
        #endregion

        #region grayquant.c
        // Floyd-Steinberg dithering to binary
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherToBinary")]
        internal static extern IntPtr pixDitherToBinary(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherToBinarySpec")]
        internal static extern IntPtr pixDitherToBinarySpec(HandleRef pixs, int lowerclip, int upperclip);

        // Simple(pixelwise) binarization with fixed threshold
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdToBinary")]
        internal static extern IntPtr pixThresholdToBinary(HandleRef pixs, int thresh);

        // Binarization with variable threshold
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarThresholdToBinary")]
        internal static extern IntPtr pixVarThresholdToBinary(HandleRef pixs, HandleRef pixg);

        // Binarization by adaptive mapping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAdaptThresholdToBinary")]
        internal static extern IntPtr pixAdaptThresholdToBinary(HandleRef pixs, HandleRef pixm, float gamma);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAdaptThresholdToBinaryGen")]
        internal static extern IntPtr pixAdaptThresholdToBinaryGen(HandleRef pixs, HandleRef pixm, float gamma, int blackval, int whiteval, int thresh);

        // Generate a binary mask from pixels of particular values
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByValue")]
        internal static extern IntPtr pixGenerateMaskByValue(HandleRef pixs, int val, int usecmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByBand")]
        internal static extern IntPtr pixGenerateMaskByBand(HandleRef pixs, int lower, int upper, int inband, int usecmap);

        // Dithering to 2 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherTo2bpp")]
        internal static extern IntPtr pixDitherTo2bpp(HandleRef pixs, int cmapflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDitherTo2bppSpec")]
        internal static extern IntPtr pixDitherTo2bppSpec(HandleRef pixs, int lowerclip, int upperclip, int cmapflag);

        // Simple(pixelwise) thresholding to 2 bpp with optional cmap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdTo2bpp")]
        internal static extern IntPtr pixThresholdTo2bpp(HandleRef pixs, int nlevels, int cmapflag);

        // Simple(pixelwise) thresholding from 8 bpp to 4 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdTo4bpp")]
        internal static extern IntPtr pixThresholdTo4bpp(HandleRef pixs, int nlevels, int cmapflag);

        // Simple(pixelwise) quantization on 8 bpp grayscale
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdOn8bpp")]
        internal static extern IntPtr pixThresholdOn8bpp(HandleRef pixs, int nlevels, int cmapflag);

        // Arbitrary(pixelwise) thresholding from 8 bpp to 2, 4 or 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdGrayArb")]
        internal static extern IntPtr pixThresholdGrayArb(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string edgevals, int outdepth, int use_average, int setblack, int setwhite);

        // Quantization tables for linear thresholds of grayscale images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantIndexTable")]
        internal static extern IntPtr makeGrayQuantIndexTable(int nlevels);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantTargetTable")]
        internal static extern IntPtr makeGrayQuantTargetTable(int nlevels, int depth);

        // Quantization table for arbitrary thresholding of grayscale images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantTableArb")]
        internal static extern int makeGrayQuantTableArb(HandleRef na, int outdepth, out IntPtr ptab, out IntPtr pcmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGrayQuantColormapArb")]
        internal static extern int makeGrayQuantColormapArb(HandleRef pixs, IntPtr tab, int outdepth, out IntPtr pcmap);

        // Thresholding from 32 bpp rgb to 1 bpp (really color quantization, but it's better placed in this file)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByBand32")]
        internal static extern IntPtr pixGenerateMaskByBand32(HandleRef pixs, uint refval, int delm, int delp, float fractm, float fractp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateMaskByDiscr32")]
        internal static extern IntPtr pixGenerateMaskByDiscr32(HandleRef pixs, uint refval1, uint refval2, int distflag);

        // Histogram - based grayscale quantization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayQuantFromHisto")]
        internal static extern IntPtr pixGrayQuantFromHisto(HandleRef pixd, HandleRef pixs, HandleRef pixm, float minfract, int maxsize);

        // Color quantize grayscale image using existing colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayQuantFromCmap")]
        internal static extern IntPtr pixGrayQuantFromCmap(HandleRef pixs, HandleRef cmap, int mindepth);
        #endregion

        #region grayquantlow.c
        // Floyd-Steinberg dithering to binary
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherToBinaryLow")]
        internal static extern void ditherToBinaryLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherToBinaryLineLow")]
        internal static extern void ditherToBinaryLineLow(IntPtr lined, int w, IntPtr bufs1, IntPtr bufs2, int lowerclip, int upperclip, int lastlineflag);

        // Simple(pixelwise) binarization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdToBinaryLow")]
        internal static extern void thresholdToBinaryLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int d, int wpls, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdToBinaryLineLow")]
        internal static extern void thresholdToBinaryLineLow(IntPtr lined, int w, IntPtr lines, int d, int thresh);

        // Thresholding from 8 bpp to 2 bpp
        // Floyd-Steinberg-like dithering to 2 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherTo2bppLow")]
        internal static extern void ditherTo2bppLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ditherTo2bppLineLow")]
        internal static extern void ditherTo2bppLineLow(IntPtr lined, int w, IntPtr bufs1, IntPtr bufs2, IntPtr tabval, IntPtr tab38, IntPtr tab14, int lastlineflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "make8To2DitherTables")]
        internal static extern int make8To2DitherTables(out IntPtr ptabval, out IntPtr ptab38, out IntPtr ptab14, int cliptoblack, int cliptowhite);

        // Simple thresholding to 2 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdTo2bppLow")]
        internal static extern void thresholdTo2bppLow(IntPtr datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab);

        // Simple thresholding to 4 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "thresholdTo4bppLow")]
        internal static extern void thresholdTo4bppLow(IntPtr datad, int h, int wpld, IntPtr datas, int wpls, IntPtr tab);
        #endregion

        #region heap.c
        // Create/Destroy L_Heap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapCreate")]
        internal static extern IntPtr lheapCreate(int nalloc, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapDestroy")]
        internal static extern void lheapDestroy(ref IntPtr plh, int freeflag);

        // Operations to add/remove to/from the heap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapAdd")]
        internal static extern int lheapAdd(HandleRef lh, IntPtr item);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapRemove")]
        internal static extern IntPtr lheapRemove(HandleRef lh);

        // Heap operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSwapUp")]
        internal static extern int lheapSwapUp(HandleRef lh, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSwapDown")]
        internal static extern int lheapSwapDown(HandleRef lh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSort")]
        internal static extern int lheapSort(HandleRef lh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapSortStrictOrder")]
        internal static extern int lheapSortStrictOrder(HandleRef lh);

        // Accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapGetCount")]
        internal static extern int lheapGetCount(HandleRef lh);

        // Debug output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lheapPrint")]
        internal static extern int lheapPrint(IntPtr fp, HandleRef lh);
        #endregion

        #region jbclass.c
        // Initialization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbRankHausInit")]
        internal static extern IntPtr jbRankHausInit(int components, int maxwidth, int maxheight, int size, float rank);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelationInit")]
        internal static extern IntPtr jbCorrelationInit(int components, int maxwidth, int maxheight, float thresh, float weightfactor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbCorrelationInitWithoutComponents")]
        internal static extern IntPtr jbCorrelationInitWithoutComponents(int components, int maxwidth, int maxheight, float thresh, float weightfactor);

        // Classify the pages
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPages")]
        internal static extern int jbAddPages(HandleRef classer, HandleRef safiles);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPage")]
        internal static extern int jbAddPage(HandleRef classer, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAddPageComponents")]
        internal static extern int jbAddPageComponents(HandleRef classer, HandleRef pixs, HandleRef boxas, HandleRef pixas);

        // Rank hausdorff classifier
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClassifyRankHaus")]
        internal static extern int jbClassifyRankHaus(HandleRef classer, HandleRef boxa, HandleRef pixas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHaustest")]
        internal static extern int pixHaustest(HandleRef pix1, HandleRef pix2, HandleRef pix3, HandleRef pix4, float delx, float dely, int maxdiffw, int maxdiffh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankHaustest")]
        internal static extern int pixRankHaustest(HandleRef pix1, HandleRef pix2, HandleRef pix3, HandleRef pix4, float delx, float dely, int maxdiffw, int maxdiffh, int area1, int area3, float rank, IntPtr tab8);

        // Binary correlation classifier
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClassifyCorrelation")]
        internal static extern int jbClassifyCorrelation(HandleRef classer, HandleRef boxa, HandleRef pixas);

        // Determine the image components we start with
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetComponents")]
        internal static extern int jbGetComponents(HandleRef pixs, int components, int maxwidth, int maxheight, out IntPtr pboxad, out IntPtr ppixad);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWordMaskByDilation")]
        //internal static extern int pixWordMaskByDilation(HandleRef pixs, int maxdil, out IntPtr ppixm, out int psize);
        internal static extern int pixWordMaskByDilation(HandleRef pixs, out IntPtr ppixm, out int psize, out IntPtr pixadb);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWordBoxesByDilation")]
        internal static extern int pixWordBoxesByDilation(HandleRef pixs, int maxdil, int minwidth, int minheight, int maxwidth, int maxheight, out IntPtr pboxa, out int psize);

        // Build grayscale composites(templates)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbAccumulateComposites")]
        internal static extern IntPtr jbAccumulateComposites(HandleRef pixaa, out IntPtr pna, out IntPtr pptat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbTemplatesFromComposites")]
        internal static extern IntPtr jbTemplatesFromComposites(HandleRef pixac, HandleRef na);

        // Utility functions for Classer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClasserCreate")]
        internal static extern IntPtr jbClasserCreate(int method, int components);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbClasserDestroy")]
        internal static extern void jbClasserDestroy(ref IntPtr pclasser);

        // Utility functions for Data
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataSave")]
        internal static extern IntPtr jbDataSave(HandleRef classer);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataDestroy")]
        internal static extern void jbDataDestroy(ref IntPtr pdata);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataWrite")]
        internal static extern int jbDataWrite([MarshalAs(UnmanagedType.AnsiBStr)] string rootout, HandleRef jbdata);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataRead")]
        internal static extern IntPtr jbDataRead([MarshalAs(UnmanagedType.AnsiBStr)] string rootname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbDataRender")]
        internal static extern IntPtr jbDataRender(HandleRef data, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetULCorners")]
        internal static extern int jbGetULCorners(HandleRef classer, HandleRef pixs, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "jbGetLLCorners")]
        internal static extern int jbGetLLCorners(HandleRef classer);
        #endregion

        #region jp2kheader.c
        // Read header
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderJp2k")]
        internal static extern int readHeaderJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pw, out int ph, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderJp2k")]
        internal static extern int freadHeaderJp2k(IntPtr fp, out int pw, out int ph, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemJp2k")]
        internal static extern int readHeaderMemJp2k(IntPtr data, IntPtr size, out int pw, out int ph, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJp2kResolution")]
        internal static extern int fgetJp2kResolution(IntPtr fp, out int pxres, out int pyres);
        #endregion

        #region jp2kio.c
        // Read jp2k from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadJp2k")]
        internal static extern IntPtr pixReadJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, uint reduction, HandleRef box, int hint, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamJp2k")]
        internal static extern IntPtr pixReadStreamJp2k(IntPtr fp, uint reduction, HandleRef box, int hint, int debug);

        // Write jp2k to file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteJp2k")]
        internal static extern int pixWriteJp2k([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, int quality, int nlevels, int hint, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamJp2k")]
        internal static extern int pixWriteStreamJp2k(IntPtr fp, HandleRef pix, int quality, int nlevels, int hint, int debug);

        // Read/write to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemJp2k")]
        internal static extern IntPtr pixReadMemJp2k(IntPtr data, IntPtr size, uint reduction, HandleRef box, int hint, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemJp2k")]
        internal static extern int pixWriteMemJp2k(out IntPtr pdata, IntPtr psize, HandleRef pix, int quality, int nlevels, int hint, int debug);
        #endregion

        #region jpegio.c
        // Read jpeg from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadJpeg")]
        internal static extern IntPtr pixReadJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int cmapflag, int reduction, out int pnwarn, int hint);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamJpeg")]
        internal static extern IntPtr pixReadStreamJpeg(IntPtr fp, int cmapflag, int reduction, out int pnwarn, int hint);

        // Read jpeg metadata from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderJpeg")]
        internal static extern int readHeaderJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderJpeg")]
        internal static extern int freadHeaderJpeg(IntPtr fp, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJpegResolution")]
        internal static extern int fgetJpegResolution(IntPtr fp, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetJpegComment")]
        internal static extern int fgetJpegComment(IntPtr fp, out IntPtr pcomment);

        // Write jpeg to file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteJpeg")]
        internal static extern int pixWriteJpeg([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, int quality, int progressive);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamJpeg")]
        internal static extern int pixWriteStreamJpeg(IntPtr fp, HandleRef pixs, int quality, int progressive);

        // Read/write to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemJpeg")]
        internal static extern IntPtr pixReadMemJpeg(IntPtr data, IntPtr size, int cmflag, int reduction, out int pnwarn, int hint);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemJpeg")]
        internal static extern int readHeaderMemJpeg(IntPtr data, IntPtr size, out int pw, out int ph, out int pspp, out int pycck, out int pcmyk);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemJpeg")]
        internal static extern int pixWriteMemJpeg(out IntPtr pdata, IntPtr psize, HandleRef pix, int quality, int progressive);

        // Setting special flag for chroma sampling on write
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetChromaSampling")]
        internal static extern int pixSetChromaSampling(HandleRef pix, int sampling);
        #endregion

        #region kernel.c
        // Create/destroy/copy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreate")]
        internal static extern IntPtr kernelCreate(int height, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelDestroy")]
        internal static extern void kernelDestroy(ref IntPtr pkel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCopy")]
        internal static extern IntPtr kernelCopy(HandleRef kels);

        // Accessors:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetElement")]
        internal static extern int kernelGetElement(HandleRef kel, int row, int col, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelSetElement")]
        internal static extern int kernelSetElement(HandleRef kel, int row, int col, float val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetParameters")]
        internal static extern int kernelGetParameters(HandleRef kel, out int psy, out int psx, out int pcy, out int pcx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelSetOrigin")]
        internal static extern int kernelSetOrigin(HandleRef kel, int cy, int cx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetSum")]
        internal static extern int kernelGetSum(HandleRef kel, out float psum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelGetMinMax")]
        internal static extern int kernelGetMinMax(HandleRef kel, out float pmin, out float pmax);

        // Normalize/invert
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelNormalize")]
        internal static extern IntPtr kernelNormalize(HandleRef kels, float normsum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelInvert")]
        internal static extern IntPtr kernelInvert(HandleRef kels);

        // Helper function
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "create2dFloatArray")]
        internal static extern IntPtr create2dFloatArray(int sy, int sx);

        // Serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelRead")]
        internal static extern IntPtr kernelRead([MarshalAs(UnmanagedType.AnsiBStr)] string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelReadStream")]
        internal static extern IntPtr kernelReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelWrite")]
        internal static extern int kernelWrite([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef kel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelWriteStream")]
        internal static extern int kernelWriteStream(IntPtr fp, HandleRef kel);

        //  Making a kernel from a compiled string
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromString")]
        internal static extern IntPtr kernelCreateFromString(int h, int w, int cy, int cx, [MarshalAs(UnmanagedType.AnsiBStr)] string kdata);

        // Making a kernel from a simple file format
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromFile")]
        internal static extern IntPtr kernelCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        // Making a kernel from a Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelCreateFromPix")]
        internal static extern IntPtr kernelCreateFromPix(HandleRef pix, int cy, int cx);

        // Display a kernel in a pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "kernelDisplayInPix")]
        internal static extern IntPtr kernelDisplayInPix(HandleRef kel, int size, int gthick);

        // Parse string to extract numbers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "parseStringForNumbers")]
        internal static extern IntPtr parseStringForNumbers([MarshalAs(UnmanagedType.AnsiBStr)] string str, [MarshalAs(UnmanagedType.AnsiBStr)] string seps);

        // Simple parametric kernels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeFlatKernel")]
        internal static extern IntPtr makeFlatKernel(int height, int width, int cy, int cx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGaussianKernel")]
        internal static extern IntPtr makeGaussianKernel(int halfheight, int halfwidth, float stdev, float max);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeGaussianKernelSep")]
        internal static extern int makeGaussianKernelSep(int halfheight, int halfwidth, float stdev, float max, out IntPtr pkelx, out IntPtr pkely);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeDoGKernel")]
        internal static extern IntPtr makeDoGKernel(int halfheight, int halfwidth, float stdev, float ratio);
        #endregion

        #region libversions.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getImagelibVersions")]
        internal static extern IntPtr getImagelibVersions();
        #endregion

        #region list.c
        // Inserting and removing elements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listDestroy")]
        internal static extern void listDestroy(ref IntPtr phead);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listAddToHead")]
        internal static extern int listAddToHead(out IntPtr phead, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listAddToTail")]
        internal static extern int listAddToTail(out IntPtr phead, out IntPtr ptail, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listInsertBefore")]
        internal static extern int listInsertBefore(out IntPtr phead, HandleRef elem, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listInsertAfter")]
        internal static extern int listInsertAfter(out IntPtr phead, HandleRef elem, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveElement")]
        internal static extern IntPtr listRemoveElement(out IntPtr phead, HandleRef elem);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveFromHead")]
        internal static extern IntPtr listRemoveFromHead(out IntPtr phead);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listRemoveFromTail")]
        internal static extern IntPtr listRemoveFromTail(out IntPtr phead, out IntPtr ptail);

        // Other list operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listFindElement")]
        internal static extern IntPtr listFindElement(HandleRef head, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listFindTail")]
        internal static extern IntPtr listFindTail(HandleRef head);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listGetCount")]
        internal static extern int listGetCount(HandleRef head);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listReverse")]
        internal static extern int listReverse(out IntPtr phead);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "listJoin")]
        internal static extern int listJoin(out IntPtr phead1, out IntPtr phead2);

        #endregion

        #region map.c
        // Interface to(a) map using a general key and storing general values
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapCreate")]
        internal static extern IntPtr l_amapCreate(int keytype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapFind")]
        internal static extern IntPtr l_amapFind(HandleRef m, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapInsert")]
        internal static extern void l_amapInsert(HandleRef m, HandleRef key, HandleRef value);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapDelete")]
        internal static extern void l_amapDelete(HandleRef m, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapDestroy")]
        internal static extern void l_amapDestroy(ref IntPtr pm);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapGetFirst")]
        internal static extern IntPtr l_amapGetFirst(HandleRef m);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapGetNext")]
        internal static extern IntPtr l_amapGetNext(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapGetLast")]
        internal static extern IntPtr l_amapGetLast(HandleRef m);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapGetPrev")]
        internal static extern IntPtr l_amapGetPrev(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_amapSize")]
        internal static extern int l_amapSize(HandleRef m);

        // Interface to(a) set using a general key
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreate")]
        internal static extern IntPtr l_asetCreate(int keytype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetFind")]
        internal static extern IntPtr l_asetFind(HandleRef s, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetInsert")]
        internal static extern void l_asetInsert(HandleRef s, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetDelete")]
        internal static extern void l_asetDelete(HandleRef s, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetDestroy")]
        internal static extern void l_asetDestroy(ref IntPtr ps);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetGetFirst")]
        internal static extern IntPtr l_asetGetFirst(HandleRef s);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetGetNext")]
        internal static extern IntPtr l_asetGetNext(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetGetLast")]
        internal static extern IntPtr l_asetGetLast(HandleRef s);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetGetPrev")]
        internal static extern IntPtr l_asetGetPrev(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetSize")]
        internal static extern int l_asetSize(HandleRef s);
        #endregion

        #region maze.c
        // This is a game with a pedagogical slant.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateBinaryMaze")]
        internal static extern IntPtr generateBinaryMaze(int w, int h, int xi, int yi, float wallps, float ranis);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSearchBinaryMaze")]
        internal static extern IntPtr pixSearchBinaryMaze(HandleRef pixs, int xi, int yi, int xf, int yf, out IntPtr ppixd);

        // Generalizing a maze to a grayscale image, the search is now for the  shortest  or least cost path, for some given cost function.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSearchGrayMaze")]
        internal static extern IntPtr pixSearchGrayMaze(HandleRef pixs, int xi, int yi, int xf, int yf, out IntPtr ppixd);
        #endregion

        #region morph.c
        // Generic binary morphological ops implemented with rasterop
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilate")]
        internal static extern IntPtr pixDilate(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErode")]
        internal static extern IntPtr pixErode(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHMT")]
        internal static extern IntPtr pixHMT(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpen")]
        internal static extern IntPtr pixOpen(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClose")]
        internal static extern IntPtr pixClose(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafe")]
        internal static extern IntPtr pixCloseSafe(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenGeneralized")]
        internal static extern IntPtr pixOpenGeneralized(HandleRef pixd, HandleRef pixs, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseGeneralized")]
        internal static extern IntPtr pixCloseGeneralized(HandleRef pixd, HandleRef pixs, HandleRef sel);

        // Binary morphological(raster) ops with brick Sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateBrick")]
        internal static extern IntPtr pixDilateBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeBrick")]
        internal static extern IntPtr pixErodeBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenBrick")]
        internal static extern IntPtr pixOpenBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseBrick")]
        internal static extern IntPtr pixCloseBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafeBrick")]
        internal static extern IntPtr pixCloseSafeBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);

        // Binary composed morphological(raster) ops with brick Sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectComposableSels")]
        internal static extern int selectComposableSels(int size, int direction, out IntPtr psel1, out IntPtr psel2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectComposableSizes")]
        internal static extern int selectComposableSizes(int size, out int pfactor1, out int pfactor2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrick")]
        internal static extern IntPtr pixDilateCompBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrick")]
        internal static extern IntPtr pixErodeCompBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrick")]
        internal static extern IntPtr pixOpenCompBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrick")]
        internal static extern IntPtr pixCloseCompBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseSafeCompBrick")]
        internal static extern IntPtr pixCloseSafeCompBrick(HandleRef pixd, HandleRef pixs, int hsize, int vsize);

        // Functions associated with boundary conditions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "resetMorphBoundaryCondition")]
        internal static extern void resetMorphBoundaryCondition(int bc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getMorphBorderPixelColor")]
        internal static extern uint getMorphBorderPixelColor(int type, int depth);
        #endregion

        #region morphapp.c
        // Extraction of boundary pixels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBoundary")]
        internal static extern IntPtr pixExtractBoundary(HandleRef pixs, int type);

        // Selective morph sequence operation under mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceMasked")]
        internal static extern IntPtr pixMorphSequenceMasked(HandleRef pixs, HandleRef pixm, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep);

        // Selective morph sequence operation on each component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceByComponent")]
        internal static extern IntPtr pixMorphSequenceByComponent(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int connectivity, int minw, int minh, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMorphSequenceByComponent")]
        internal static extern IntPtr pixaMorphSequenceByComponent(HandleRef pixas, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int minw, int minh);

        // Selective morph sequence operation on each region
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceByRegion")]
        internal static extern IntPtr pixMorphSequenceByRegion(HandleRef pixs, HandleRef pixm, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int connectivity, int minw, int minh, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMorphSequenceByRegion")]
        internal static extern IntPtr pixaMorphSequenceByRegion(HandleRef pixs, HandleRef pixam, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int minw, int minh);

        // Union and intersection of parallel composite operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnionOfMorphOps")]
        internal static extern IntPtr pixUnionOfMorphOps(HandleRef pixs, HandleRef sela, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixIntersectionOfMorphOps")]
        internal static extern IntPtr pixIntersectionOfMorphOps(HandleRef pixs, HandleRef sela, int type);

        // Selective connected component filling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectiveConnCompFill")]
        internal static extern IntPtr pixSelectiveConnCompFill(HandleRef pixs, int connectivity, int minw, int minh);

        // Removal of matched patterns
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveMatchedPattern")]
        internal static extern int pixRemoveMatchedPattern(HandleRef pixs, HandleRef pixp, HandleRef pixe, int x0, int y0, int dsize);

        // Display of matched patterns
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayMatchedPattern")]
        internal static extern IntPtr pixDisplayMatchedPattern(HandleRef pixs, HandleRef pixp, HandleRef pixe, int x0, int y0, uint color, float scale, int nlevels);

        // Extension of pixa by iterative erosion or dilation(and by scaling)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendByMorph")]
        internal static extern IntPtr pixaExtendByMorph(HandleRef pixas, int type, int niters, HandleRef sel, int include);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendByScaling")]
        internal static extern IntPtr pixaExtendByScaling(HandleRef pixas, HandleRef nasc, int type, int include);

        // Iterative morphological seed filling(don't use for real work)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillMorph")]
        internal static extern IntPtr pixSeedfillMorph(HandleRef pixs, HandleRef pixm, int maxiters, int connectivity);

        // Granulometry on binary images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRunHistogramMorph")]
        internal static extern IntPtr pixRunHistogramMorph(HandleRef pixs, int runtype, int direction, int maxsize);

        // Composite operations on grayscale images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTophat")]
        internal static extern IntPtr pixTophat(HandleRef pixs, int hsize, int vsize, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHDome")]
        internal static extern IntPtr pixHDome(HandleRef pixs, int height, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFastTophat")]
        internal static extern IntPtr pixFastTophat(HandleRef pixs, int xsize, int ysize, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphGradient")]
        internal static extern IntPtr pixMorphGradient(HandleRef pixs, int hsize, int vsize, int smoothing);

        // Centroid of component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCentroids")]
        internal static extern IntPtr pixaCentroids(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCentroid")]
        internal static extern int pixCentroid(HandleRef pix, IntPtr centtab, IntPtr sumtab, out float pxave, out float pyave);
        #endregion

        #region morphdwa.c
        // Binary morphological(dwa) ops with brick Sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateBrickDwa")]
        internal static extern IntPtr pixDilateBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeBrickDwa")]
        internal static extern IntPtr pixErodeBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenBrickDwa")]
        internal static extern IntPtr pixOpenBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseBrickDwa")]
        internal static extern IntPtr pixCloseBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);

        // Binary composite morphological(dwa) ops with brick Sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrickDwa")]
        internal static extern IntPtr pixDilateCompBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrickDwa")]
        internal static extern IntPtr pixErodeCompBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrickDwa")]
        internal static extern IntPtr pixOpenCompBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrickDwa")]
        internal static extern IntPtr pixCloseCompBrickDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);

        // Binary extended composite morphological(dwa) ops with brick Sels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDilateCompBrickExtendDwa")]
        internal static extern IntPtr pixDilateCompBrickExtendDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixErodeCompBrickExtendDwa")]
        internal static extern IntPtr pixErodeCompBrickExtendDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOpenCompBrickExtendDwa")]
        internal static extern IntPtr pixOpenCompBrickExtendDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCloseCompBrickExtendDwa")]
        internal static extern IntPtr pixCloseCompBrickExtendDwa(HandleRef pixd, HandleRef pixs, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getExtendedCompositeParameters")]
        internal static extern int getExtendedCompositeParameters(int size, out int pn, out int pextra, out int pactualsize);
        #endregion

        #region morphseq.c
        // Run a sequence of binary rasterop morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequence")]
        internal static extern IntPtr pixMorphSequence(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep);

        // Run a sequence of binary composite rasterop morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphCompSequence")]
        internal static extern IntPtr pixMorphCompSequence(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep);

        // Run a sequence of binary dwa morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphSequenceDwa")]
        internal static extern IntPtr pixMorphSequenceDwa(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep);

        // Run a sequence of binary composite dwa morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMorphCompSequenceDwa")]
        internal static extern IntPtr pixMorphCompSequenceDwa(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep);

        // Parser verifier for binary morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "morphSequenceVerify")]
        internal static extern int morphSequenceVerify(HandleRef sa);

        // Run a sequence of grayscale morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGrayMorphSequence")]
        internal static extern IntPtr pixGrayMorphSequence(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep, int dispy);

        // Run a sequence of color morphological operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorMorphSequence")]
        internal static extern IntPtr pixColorMorphSequence(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string sequence, int dispsep, int dispy);
        #endregion

        #region numabasic.c
        // Numa creation, destruction, copy, clone, etc.
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreate")]
        internal static extern IntPtr numaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromIArray")]
        internal static extern IntPtr numaCreateFromIArray(IntPtr iarray, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromFArray")]
        internal static extern IntPtr numaCreateFromFArray(IntPtr farray, int size, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCreateFromString")]
        internal static extern IntPtr numaCreateFromString([MarshalAs(UnmanagedType.AnsiBStr)] string str);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDestroy")]
        internal static extern void numaDestroy(ref IntPtr pna);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCopy")]
        internal static extern IntPtr numaCopy(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClone")]
        internal static extern IntPtr numaClone(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEmpty")]
        internal static extern int numaEmpty(HandleRef na);

        // Add/remove number(float or integer)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddNumber")]
        internal static extern int numaAddNumber(HandleRef na, float val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInsertNumber")]
        internal static extern int numaInsertNumber(HandleRef na, int index, float val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRemoveNumber")]
        internal static extern int numaRemoveNumber(HandleRef na, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReplaceNumber")]
        internal static extern int numaReplaceNumber(HandleRef na, int index, float val);

        // Numa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetCount")]
        internal static extern int numaGetCount(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetCount")]
        internal static extern int numaSetCount(HandleRef na, int newcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetFValue")]
        internal static extern int numaGetFValue(HandleRef na, int index, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetIValue")]
        internal static extern int numaGetIValue(HandleRef na, int index, out int pival);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetValue")]
        internal static extern int numaSetValue(HandleRef na, int index, float val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaShiftValue")]
        internal static extern int numaShiftValue(HandleRef na, int index, float diff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetIArray")]
        internal static extern IntPtr numaGetIArray(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetFArray")]
        internal static extern IntPtr numaGetFArray(HandleRef na, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRefcount")]
        internal static extern int numaGetRefcount(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaChangeRefcount")]
        internal static extern int numaChangeRefcount(HandleRef na, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetParameters")]
        internal static extern int numaGetParameters(HandleRef na, out float pstartx, out float pdelx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSetParameters")]
        internal static extern int numaSetParameters(HandleRef na, float startx, float delx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCopyParameters")]
        internal static extern int numaCopyParameters(HandleRef nad, HandleRef nas);

        // Convert to string array
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToSarray")]
        internal static extern IntPtr numaConvertToSarray(HandleRef na, int size1, int size2, int addzeros, int type);

        // Serialize numa for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRead")]
        internal static extern IntPtr numaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReadStream")]
        internal static extern IntPtr numaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReadMem")]
        internal static extern IntPtr numaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWrite")]
        internal static extern int numaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWriteStream")]
        internal static extern int numaWriteStream(IntPtr fp, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWriteMem")]
        internal static extern int numaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef na);

        // Numaa creation, destruction, truncation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCreate")]
        internal static extern IntPtr numaaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaCreateFull")]
        internal static extern IntPtr numaaCreateFull(int nptr, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaTruncate")]
        internal static extern int numaaTruncate(HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaDestroy")]
        internal static extern void numaaDestroy(ref IntPtr pnaa);

        // Add Numa to Numaa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaAddNuma")]
        internal static extern int numaaAddNuma(HandleRef naa, HandleRef na, int copyflag);

        // Numaa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetCount")]
        internal static extern int numaaGetCount(HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNumaCount")]
        internal static extern int numaaGetNumaCount(HandleRef naa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNumberCount")]
        internal static extern int numaaGetNumberCount(HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetPtrArray")]
        internal static extern IntPtr numaaGetPtrArray(HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetNuma")]
        internal static extern IntPtr numaaGetNuma(HandleRef naa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReplaceNuma")]
        internal static extern int numaaReplaceNuma(HandleRef naa, int index, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaGetValue")]
        internal static extern int numaaGetValue(HandleRef naa, int i, int j, out float pfval, out int pival);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaAddNumber")]
        internal static extern int numaaAddNumber(HandleRef naa, int index, float val);

        // Serialize numaa for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaRead")]
        internal static extern IntPtr numaaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReadStream")]
        internal static extern IntPtr numaaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaReadMem")]
        internal static extern IntPtr numaaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWrite")]
        internal static extern int numaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWriteStream")]
        internal static extern int numaaWriteStream(IntPtr fp, HandleRef naa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaWriteMem")]
        internal static extern int numaaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef naa);
        #endregion

        #region numafunc1.c
        // Arithmetic and logic
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaArithOp")]
        internal static extern IntPtr numaArithOp(HandleRef nad, HandleRef na1, HandleRef na2, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaLogicalOp")]
        internal static extern IntPtr numaLogicalOp(HandleRef nad, HandleRef na1, HandleRef na2, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInvert")]
        internal static extern IntPtr numaInvert(HandleRef nad, HandleRef nas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSimilar")]
        internal static extern int numaSimilar(HandleRef na1, HandleRef na2, float maxdiff, out int psimilar);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddToNumber")]
        internal static extern int numaAddToNumber(HandleRef na, int index, float val);

        // Simple extractions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMin")]
        internal static extern int numaGetMin(HandleRef na, out float pminval, out int piminloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMax")]
        internal static extern int numaGetMax(HandleRef na, out float pmaxval, out int pimaxloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSum")]
        internal static extern int numaGetSum(HandleRef na, out float psum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetPartialSums")]
        internal static extern IntPtr numaGetPartialSums(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSumOnInterval")]
        internal static extern int numaGetSumOnInterval(HandleRef na, int first, int last, out float psum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHasOnlyIntegers")]
        internal static extern int numaHasOnlyIntegers(HandleRef na, int maxsamples, out int pallints);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSubsample")]
        internal static extern IntPtr numaSubsample(HandleRef nas, int subfactor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeDelta")]
        internal static extern IntPtr numaMakeDelta(HandleRef nas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeSequence")]
        internal static extern IntPtr numaMakeSequence(float startval, float increment, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeConstant")]
        internal static extern IntPtr numaMakeConstant(float val, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeAbsValue")]
        internal static extern IntPtr numaMakeAbsValue(HandleRef nad, HandleRef nas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddBorder")]
        internal static extern IntPtr numaAddBorder(HandleRef nas, int left, int right, float val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaAddSpecifiedBorder")]
        internal static extern IntPtr numaAddSpecifiedBorder(HandleRef nas, int left, int right, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRemoveBorder")]
        internal static extern IntPtr numaRemoveBorder(HandleRef nas, int left, int right);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCountNonzeroRuns")]
        internal static extern int numaCountNonzeroRuns(HandleRef na, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetNonzeroRange")]
        internal static extern int numaGetNonzeroRange(HandleRef na, float eps, out int pfirst, out int plast);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetCountRelativeToZero")]
        internal static extern int numaGetCountRelativeToZero(HandleRef na, int type, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClipToInterval")]
        internal static extern IntPtr numaClipToInterval(HandleRef nas, int first, int last);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeThresholdIndicator")]
        internal static extern IntPtr numaMakeThresholdIndicator(HandleRef nas, float thresh, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaUniformSampling")]
        internal static extern IntPtr numaUniformSampling(HandleRef nas, int nsamp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaReverse")]
        internal static extern IntPtr numaReverse(HandleRef nad, HandleRef nas);

        // Signal feature extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaLowPassIntervals")]
        internal static extern IntPtr numaLowPassIntervals(HandleRef nas, float thresh, float maxn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaThresholdEdges")]
        internal static extern IntPtr numaThresholdEdges(HandleRef nas, float thresh1, float thresh2, float maxn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSpanValues")]
        internal static extern int numaGetSpanValues(HandleRef na, int span, out int pstart, out int pend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetEdgeValues")]
        internal static extern int numaGetEdgeValues(HandleRef na, int edge, out int pstart, out int pend, out int psign);

        // Interpolation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateEqxVal")]
        internal static extern int numaInterpolateEqxVal(float startx, float deltax, HandleRef nay, int type, float xval, out float pyval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateArbxVal")]
        internal static extern int numaInterpolateArbxVal(HandleRef nax, HandleRef nay, int type, float xval, out float pyval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateEqxInterval")]
        internal static extern int numaInterpolateEqxInterval(float startx, float deltax, HandleRef nasy, int type, float x0, float x1, int npts, out IntPtr pnax, out IntPtr pnay);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInterpolateArbxInterval")]
        internal static extern int numaInterpolateArbxInterval(HandleRef nax, HandleRef nay, int type, float x0, float x1, int npts, out IntPtr pnadx, out IntPtr pnady);

        // Functions requiring interpolation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFitMax")]
        internal static extern int numaFitMax(HandleRef na, out float pmaxval, HandleRef naloc, out float pmaxloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDifferentiateInterval")]
        internal static extern int numaDifferentiateInterval(HandleRef nax, HandleRef nay, float x0, float x1, int npts, out IntPtr pnadx, out IntPtr pnady);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaIntegrateInterval")]
        internal static extern int numaIntegrateInterval(HandleRef nax, HandleRef nay, float x0, float x1, int npts, out float psum);

        // Sorting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortGeneral")]
        internal static extern int numaSortGeneral(HandleRef na, out IntPtr pnasort, out IntPtr pnaindex, out IntPtr pnainvert, int sortorder, int sorttype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortAutoSelect")]
        internal static extern IntPtr numaSortAutoSelect(HandleRef nas, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortIndexAutoSelect")]
        internal static extern IntPtr numaSortIndexAutoSelect(HandleRef nas, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaChooseSortType")]
        internal static extern int numaChooseSortType(HandleRef nas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSort")]
        internal static extern IntPtr numaSort(HandleRef naout, HandleRef nain, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaBinSort")]
        internal static extern IntPtr numaBinSort(HandleRef nas, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetSortIndex")]
        internal static extern IntPtr numaGetSortIndex(HandleRef na, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetBinSortIndex")]
        internal static extern IntPtr numaGetBinSortIndex(HandleRef nas, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortByIndex")]
        internal static extern IntPtr numaSortByIndex(HandleRef nas, HandleRef naindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaIsSorted")]
        internal static extern int numaIsSorted(HandleRef nas, int sortorder, out int psorted);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSortPair")]
        internal static extern int numaSortPair(HandleRef nax, HandleRef nay, int sortorder, out IntPtr pnasx, out IntPtr pnasy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaInvertMap")]
        internal static extern IntPtr numaInvertMap(HandleRef nas);

        // Random permutation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaPseudorandomSequence")]
        internal static extern IntPtr numaPseudorandomSequence(int size, int seed);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRandomPermutation")]
        internal static extern IntPtr numaRandomPermutation(HandleRef nas, int seed);

        // Functions requiring sorting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRankValue")]
        internal static extern int numaGetRankValue(HandleRef na, float fract, HandleRef nasort, int usebins, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMedian")]
        internal static extern int numaGetMedian(HandleRef na, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetBinnedMedian")]
        internal static extern int numaGetBinnedMedian(HandleRef na, out int pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMode")]
        internal static extern int numaGetMode(HandleRef na, out float pval, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetMedianVariation")]
        internal static extern int numaGetMedianVariation(HandleRef na, out float pmedval, out float pmedvar);

        // Rearrangements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaJoin")]
        internal static extern int numaJoin(HandleRef nad, HandleRef nas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaJoin")]
        internal static extern int numaaJoin(HandleRef naad, HandleRef naas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaaFlattenToNuma")]
        internal static extern IntPtr numaaFlattenToNuma(HandleRef naa);
        #endregion

        #region numafunc2.c
        // Morphological(min/max) operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaErode")]
        internal static extern IntPtr numaErode(HandleRef nas, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDilate")]
        internal static extern IntPtr numaDilate(HandleRef nas, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaOpen")]
        internal static extern IntPtr numaOpen(HandleRef nas, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaClose")]
        internal static extern IntPtr numaClose(HandleRef nas, int size);

        // Other transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaTransform")]
        internal static extern IntPtr numaTransform(HandleRef nas, float shift, float scale);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSimpleStats")]
        internal static extern int numaSimpleStats(HandleRef na, int first, int last, out float pmean, out float pvar, out float prvar);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedStats")]
        internal static extern int numaWindowedStats(HandleRef nas, int wc, out IntPtr pnam, out IntPtr pnams, out IntPtr pnav, out IntPtr pnarv);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMean")]
        internal static extern IntPtr numaWindowedMean(HandleRef nas, int wc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMeanSquare")]
        internal static extern IntPtr numaWindowedMeanSquare(HandleRef nas, int wc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedVariance")]
        internal static extern int numaWindowedVariance(HandleRef nam, HandleRef nams, out IntPtr pnav, out IntPtr pnarv);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaWindowedMedian")]
        internal static extern IntPtr numaWindowedMedian(HandleRef nas, int halfwin);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToInt")]
        internal static extern IntPtr numaConvertToInt(HandleRef nas);

        // Histogram generation and statistics
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogram")]
        internal static extern IntPtr numaMakeHistogram(HandleRef na, int maxbins, out int pbinsize, out int pbinstart);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogramAuto")]
        internal static extern IntPtr numaMakeHistogramAuto(HandleRef na, int maxbins);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeHistogramClipped")]
        internal static extern IntPtr numaMakeHistogramClipped(HandleRef na, float binsize, float maxsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaRebinHistogram")]
        internal static extern IntPtr numaRebinHistogram(HandleRef nas, int newsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaNormalizeHistogram")]
        internal static extern IntPtr numaNormalizeHistogram(HandleRef nas, float tsum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetStatsUsingHistogram")]
        internal static extern int numaGetStatsUsingHistogram(HandleRef na, int maxbins, out float pmin, out float pmax, out float pmean, out float pvariance, out float pmedian, float rank, out float prval, out IntPtr phisto);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetHistogramStats")]
        internal static extern int numaGetHistogramStats(HandleRef nahisto, float startx, float deltax, out float pxmean, out float pxmedian, out float pxmode, out float pxvariance);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetHistogramStatsOnInterval")]
        internal static extern int numaGetHistogramStatsOnInterval(HandleRef nahisto, float startx, float deltax, int ifirst, int ilast, out float pxmean, out float pxmedian, out float pxmode, out float pxvariance);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaMakeRankFromHistogram")]
        internal static extern int numaMakeRankFromHistogram(float startx, float deltax, HandleRef nasy, int npts, out IntPtr pnax, out IntPtr pnay);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHistogramGetRankFromVal")]
        internal static extern int numaHistogramGetRankFromVal(HandleRef na, float rval, out float prank);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaHistogramGetValFromRank")]
        internal static extern int numaHistogramGetValFromRank(HandleRef na, float rank, out float prval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaDiscretizeRankAndIntensity")]
        internal static extern int numaDiscretizeRankAndIntensity(HandleRef na, int nbins, out IntPtr pnarbin, out IntPtr pnam, out IntPtr pnar, out IntPtr pnabb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaGetRankBinValues")]
        internal static extern int numaGetRankBinValues(HandleRef na, int nbins, out IntPtr pnarbin, out IntPtr pnam);

        // Splitting a distribution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSplitDistribution")]
        internal static extern int numaSplitDistribution(HandleRef na, float scorefract, out int psplitindex, out float pave1, out float pave2, out float pnum1, out float pnum2, out IntPtr pnascore);

        // Comparing histograms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "grayHistogramsToEMD")]
        internal static extern int grayHistogramsToEMD(HandleRef naa1, HandleRef naa2, out IntPtr pnad);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEarthMoverDistance")]
        internal static extern int numaEarthMoverDistance(HandleRef na1, HandleRef na2, out float pdist);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "grayInterHistogramStats")]
        internal static extern int grayInterHistogramStats(HandleRef naa, int wc, out IntPtr pnam, out IntPtr pnams, out IntPtr pnav, out IntPtr pnarv);

        // Extrema finding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFindPeaks")]
        internal static extern IntPtr numaFindPeaks(HandleRef nas, int nmax, float fract1, float fract2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaFindExtrema")]
        internal static extern IntPtr numaFindExtrema(HandleRef nas, float delta, out IntPtr pnav);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCountReversals")]
        internal static extern int numaCountReversals(HandleRef nas, float minreversal, out int pnr, out float pnrpl);

        // Threshold crossings and frequency analysis
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaSelectCrossingThreshold")]
        internal static extern int numaSelectCrossingThreshold(HandleRef nax, HandleRef nay, float estthresh, out float pbestthresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCrossingsByThreshold")]
        internal static extern IntPtr numaCrossingsByThreshold(HandleRef nax, HandleRef nay, float thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaCrossingsByPeaks")]
        internal static extern IntPtr numaCrossingsByPeaks(HandleRef nax, HandleRef nay, float delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEvalBestHaarParameters")]
        internal static extern int numaEvalBestHaarParameters(HandleRef nas, float relweight, int nwidth, int nshift, float minwidth, float maxwidth, out float pbestwidth, out float pbestshift, out float pbestscore);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaEvalHaarSum")]
        internal static extern int numaEvalHaarSum(HandleRef nas, float width, float shift, float relweight, out float pscore);

        // Generating numbers in a range under constraints
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genConstrainedNumaInRange")]
        internal static extern IntPtr genConstrainedNumaInRange(int first, int last, int nmax, int use_pairs);
        #endregion

        #region pageseg.c
        // Top level page segmentation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRegionsBinary")]
        internal static extern int pixGetRegionsBinary(HandleRef pixs, out IntPtr ppixhm, out IntPtr ppixtm, out IntPtr ppixtb, HandleRef pixadb);

        // Halftone region extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenHalftoneMask")]
        internal static extern IntPtr pixGenHalftoneMask(HandleRef pixs, out IntPtr ppixtext, out int phtfound, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateHalftoneMask")]
        internal static extern IntPtr pixGenerateHalftoneMask(HandleRef pixs, out IntPtr ppixtext, out int phtfound, HandleRef pixadb);

        // Textline extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenTextlineMask")]
        internal static extern IntPtr pixGenTextlineMask(HandleRef pixs, out IntPtr ppixvws, out int ptlfound, HandleRef pixadb);

        // Textblock extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenTextblockMask")]
        internal static extern IntPtr pixGenTextblockMask(HandleRef pixs, HandleRef pixvws, HandleRef pixadb);

        // Location of page foreground
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPageForeground")]
        internal static extern IntPtr pixFindPageForeground(HandleRef pixs, int threshold, int mindist, int erasedist, int pagenum, int showmorph, int display, [MarshalAs(UnmanagedType.AnsiBStr)] string pdfdir);

        // Extraction of characters from image with only text
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitIntoCharacters")]
        internal static extern int pixSplitIntoCharacters(HandleRef pixs, int minw, int minh, out IntPtr pboxa, out IntPtr ppixa, out IntPtr ppixdebug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitComponentWithProfile")]
        internal static extern IntPtr pixSplitComponentWithProfile(HandleRef pixs, int delta, int mindel, out IntPtr ppixdebug);

        // Extraction of lines of text
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractTextlines")]
        internal static extern IntPtr pixExtractTextlines(HandleRef pixs, int maxw, int maxh, int minw, int minh, int adjw, int adjh, HandleRef pixadb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractRawTextlines")]
        internal static extern IntPtr pixExtractRawTextlines(HandleRef pixs, int maxw, int maxh, int adjw, int adjh, HandleRef pixadb);

        // How many text columns
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountTextColumns")]
        internal static extern int pixCountTextColumns(HandleRef pixs, float deltafract, float peakfract, float clipfract, out int pncols, HandleRef pixadb);

        // Decision: text vs photo
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDecideIfText")]
        internal static extern int pixDecideIfText(HandleRef pixs, HandleRef box, out int pistext, HandleRef pixadb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindThreshFgExtent")]
        internal static extern int pixFindThreshFgExtent(HandleRef pixs, int thresh, out int ptop, out int pbot);

        // Decision: table vs text
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDecideIfTable")]
        internal static extern int pixDecideIfTable(HandleRef pixs, HandleRef box, int orient, out int pscore, HandleRef pixadb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPrepare1bpp")]
        internal static extern IntPtr pixPrepare1bpp(HandleRef pixs, HandleRef box, float cropfract, int outres);

        // Estimate the grayscale background value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEstimateBackground")]
        internal static extern int pixEstimateBackground(HandleRef pixs, int darkthresh, float edgecrop, out int pbg);

        // Largest white or black rectangles in an image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindLargeRectangles")]
        internal static extern int pixFindLargeRectangles(HandleRef pixs, int polarity, int nrect, out IntPtr pboxa, out IntPtr ppixdb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindLargestRectangle")]
        internal static extern int pixFindLargestRectangle(HandleRef pixs, int polarity, out IntPtr pbox, out IntPtr ppixdb);
        #endregion

        #region paintcmap.c
        // Repaint selected pixels in region
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSelectCmap")]
        internal static extern int pixSetSelectCmap(HandleRef pixs, HandleRef box, int sindex, int rval, int gval, int bval);

        // Repaint non-white pixels in region
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayRegionsCmap")]
        internal static extern int pixColorGrayRegionsCmap(HandleRef pixs, HandleRef boxa, int type, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayCmap")]
        internal static extern int pixColorGrayCmap(HandleRef pixs, HandleRef box, int type, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorGrayMaskedCmap")]
        internal static extern int pixColorGrayMaskedCmap(HandleRef pixs, HandleRef pixm, int type, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "addColorizedGrayToCmap")]
        internal static extern int addColorizedGrayToCmap(HandleRef cmap, int type, int rval, int gval, int bval, out IntPtr pna);

        // Repaint selected pixels through mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSelectMaskedCmap")]
        internal static extern int pixSetSelectMaskedCmap(HandleRef pixs, HandleRef pixm, int x, int y, int sindex, int rval, int gval, int bval);

        // Repaint all pixels through mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMaskedCmap")]
        internal static extern int pixSetMaskedCmap(HandleRef pixs, HandleRef pixm, int x, int y, int rval, int gval, int bval);
        #endregion

        #region parseprotos.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "parseForProtos")]
        internal static extern IntPtr parseForProtos([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string prestring);
        #endregion

        #region partition.c
        // Whitespace block extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaGetWhiteblocks")]
        internal static extern IntPtr boxaGetWhiteblocks(HandleRef boxas, HandleRef box, int sortflag, int maxboxes, float maxoverlap, int maxperim, float fract, int maxpops);

        // Helpers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaPruneSortedOnOverlap")]
        internal static extern IntPtr boxaPruneSortedOnOverlap(HandleRef boxas, float maxoverlap);
        #endregion

        #region pdfio1.c
        // 1. Convert specified image files to pdf(one image file per page)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesToPdf")]
        internal static extern int convertFilesToPdf([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertFilesToPdf")]
        internal static extern int saConvertFilesToPdf(HandleRef sa, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertFilesToPdfData")]
        internal static extern int saConvertFilesToPdfData(HandleRef sa, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selectDefaultPdfEncoding")]
        internal static extern int selectDefaultPdfEncoding(HandleRef pix, out int ptype);

        // 2. Convert specified image files to pdf without scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertUnscaledFilesToPdf")]
        internal static extern int convertUnscaledFilesToPdf([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertUnscaledFilesToPdf")]
        internal static extern int saConvertUnscaledFilesToPdf(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConvertUnscaledFilesToPdfData")]
        internal static extern int saConvertUnscaledFilesToPdfData(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertUnscaledToPdfData")]
        internal static extern int convertUnscaledToPdfData([MarshalAs(UnmanagedType.AnsiBStr)] string fname, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);

        // 3. Convert multiple images to pdf(one image per page)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToPdf")]
        internal static extern int pixaConvertToPdf(HandleRef pixa, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToPdfData")]
        internal static extern int pixaConvertToPdfData(HandleRef pixa, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);

        // 4. Single page, multi-image converters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdf")]
        internal static extern int convertToPdf([MarshalAs(UnmanagedType.AnsiBStr)] string filein, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertImageDataToPdf")]
        internal static extern int convertImageDataToPdf(IntPtr imdata, IntPtr size, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfData")]
        internal static extern int convertToPdfData([MarshalAs(UnmanagedType.AnsiBStr)] string filein, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertImageDataToPdfData")]
        internal static extern int convertImageDataToPdfData(IntPtr imdata, IntPtr size, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdf")]
        internal static extern int pixConvertToPdf(HandleRef pix, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPdf")]
        internal static extern int pixWriteStreamPdf(IntPtr fp, HandleRef pix, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPdf")]
        internal static extern int pixWriteMemPdf(out IntPtr pdata, IntPtr pnbytes, HandleRef pix, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title);

        // 5. Segmented multi-page, multi-image converter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSegmentedFilesToPdf")]
        internal static extern int convertSegmentedFilesToPdf([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int res, int type, int thresh, HandleRef baa, int quality, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertNumberedMasksToBoxaa")]
        internal static extern IntPtr convertNumberedMasksToBoxaa([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int numpre, int numpost);

        // 6. Segmented single page, multi-image converters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfSegmented")]
        internal static extern int convertToPdfSegmented([MarshalAs(UnmanagedType.AnsiBStr)] string filein, int res, int type, int thresh, HandleRef boxa, int quality, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfSegmented")]
        internal static extern int pixConvertToPdfSegmented(HandleRef pixs, int res, int type, int thresh, HandleRef boxa, int quality, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPdfDataSegmented")]
        internal static extern int convertToPdfDataSegmented([MarshalAs(UnmanagedType.AnsiBStr)] string filein, int res, int type, int thresh, HandleRef boxa, int quality, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfDataSegmented")]
        internal static extern int pixConvertToPdfDataSegmented(HandleRef pixs, int res, int type, int thresh, HandleRef boxa, int quality, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);

        // 7. Multipage concatenation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "concatenatePdf")]
        internal static extern int concatenatePdf([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConcatenatePdf")]
        internal static extern int saConcatenatePdf(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraConcatenatePdf")]
        internal static extern int ptraConcatenatePdf(HandleRef pa, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "concatenatePdfToData")]
        internal static extern int concatenatePdfToData([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "saConcatenatePdfToData")]
        internal static extern int saConcatenatePdfToData(HandleRef sa, out IntPtr pdata, IntPtr pnbytes);
        #endregion

        #region pdfio2.c
        // Intermediate function for single page, multi-image conversion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToPdfData")]
        internal static extern int pixConvertToPdfData(HandleRef pix, int type, int quality, out IntPtr pdata, IntPtr pnbytes, int x, int y, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr plpd, int position);

        // Intermediate function for generating multipage pdf output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraConcatenatePdfToData")]
        internal static extern int ptraConcatenatePdfToData(HandleRef pa_data, HandleRef sa, out IntPtr pdata, IntPtr pnbytes);

        // Convert tiff multipage to pdf file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertTiffMultipageToPdf")]
        internal static extern int convertTiffMultipageToPdf([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        // Low-level CID-based operations Without transcoding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateCIDataForPdf")]
        internal static extern int l_generateCIDataForPdf([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef pix, int quality, out IntPtr pcid);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateFlateDataPdf")]
        internal static extern IntPtr l_generateFlateDataPdf([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateJpegData")]
        internal static extern IntPtr l_generateJpegData([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int ascii85flag);

        // With transcoding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateCIData")]
        internal static extern int l_generateCIData([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int type, int quality, int ascii85, out IntPtr pcid);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateCIData")]
        internal static extern int pixGenerateCIData(HandleRef pixs, int type, int quality, int ascii85, out IntPtr pcid);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateFlateData")]
        internal static extern IntPtr l_generateFlateData([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int ascii85flag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_generateG4Data")]
        internal static extern IntPtr l_generateG4Data([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int ascii85flag);

        // Other
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cidConvertToPdfData")]
        internal static extern int cidConvertToPdfData(HandleRef cid, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_CIDataDestroy")]
        internal static extern void l_CIDataDestroy(ref IntPtr pcid);

        // Set flags for special modes
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pdfSetG4ImageMask")]
        internal static extern void l_pdfSetG4ImageMask(int flag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pdfSetDateAndVersion")]
        internal static extern void l_pdfSetDateAndVersion(int flag);
        #endregion

        #region pix1.c
        // Pix memory management(allows custom allocator and deallocator)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setPixMemoryManager")]
        internal static extern void setPixMemoryManager(IntPtr allocator, IntPtr deallocator);

        // Pix creation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreate")]
        internal static extern IntPtr pixCreate(int width, int height, int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateNoInit")]
        internal static extern IntPtr pixCreateNoInit(int width, int height, int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateTemplate")]
        internal static extern IntPtr pixCreateTemplate(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateTemplateNoInit")]
        internal static extern IntPtr pixCreateTemplateNoInit(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateHeader")]
        internal static extern IntPtr pixCreateHeader(int width, int height, int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClone")]
        internal static extern IntPtr pixClone(HandleRef pixs);

        // Pix destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroy")]
        internal static extern void pixDestroy(ref IntPtr ppix);

        // Pix copy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopy")]
        internal static extern IntPtr pixCopy(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixResizeImageData")]
        internal static extern bool pixResizeImageData(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyColormap")]
        internal static extern bool pixCopyColormap(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSizesEqual")]
        internal static extern bool pixSizesEqual(HandleRef pix1, HandleRef pix2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTransferAllData")]
        internal static extern bool pixTransferAllData(HandleRef pixd, ref IntPtr ppixs, bool copytext, bool copyformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSwapAndDestroy")]
        internal static extern bool pixSwapAndDestroy(ref IntPtr ppixd, ref IntPtr ppixs);

        // Pix accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWidth")]
        internal static extern int pixGetWidth(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetWidth")]
        internal static extern bool pixSetWidth(HandleRef pix, int width);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetHeight")]
        internal static extern int pixGetHeight(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetHeight")]
        internal static extern bool pixSetHeight(HandleRef pix, int height);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDepth")]
        internal static extern int pixGetDepth(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetDepth")]
        internal static extern bool pixSetDepth(HandleRef pix, int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetDimensions")]
        internal static extern bool pixGetDimensions(HandleRef pix, out int pw, out int ph, out int pd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetDimensions")]
        internal static extern bool pixSetDimensions(HandleRef pix, int w, int h, int d);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyDimensions")]
        internal static extern bool pixCopyDimensions(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetSpp")]
        internal static extern int pixGetSpp(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSpp")]
        internal static extern bool pixSetSpp(HandleRef pix, int spp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopySpp")]
        internal static extern bool pixCopySpp(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetWpl")]
        internal static extern int pixGetWpl(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetWpl")]
        internal static extern bool pixSetWpl(HandleRef pix, int wpl);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRefcount")]
        internal static extern int pixGetRefcount(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixChangeRefcount")]
        internal static extern bool pixChangeRefcount(HandleRef pix, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetXRes")]
        internal static extern int pixGetXRes(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetXRes")]
        internal static extern bool pixSetXRes(HandleRef pix, int res);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetYRes")]
        internal static extern int pixGetYRes(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetYRes")]
        internal static extern bool pixSetYRes(HandleRef pix, int res);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetResolution")]
        internal static extern bool pixGetResolution(HandleRef pix, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetResolution")]
        internal static extern bool pixSetResolution(HandleRef pix, int xres, int yres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyResolution")]
        internal static extern bool pixCopyResolution(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleResolution")]
        internal static extern bool pixScaleResolution(HandleRef pix, float xscale, float yscale);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetInputFormat")]
        internal static extern ImageFileFormatTypes pixGetInputFormat(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInputFormat")]
        internal static extern bool pixSetInputFormat(HandleRef pix, ImageFileFormatTypes informat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyInputFormat")]
        internal static extern bool pixCopyInputFormat(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetSpecial")]
        internal static extern bool pixSetSpecial(HandleRef pix, int special);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetText")]
        internal static extern IntPtr pixGetText(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetText")]
        internal static extern bool pixSetText(HandleRef pix, [MarshalAs(UnmanagedType.AnsiBStr)] string textstring);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddText")]
        internal static extern bool pixAddText(HandleRef pix, [MarshalAs(UnmanagedType.AnsiBStr)] string textstring);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyText")]
        internal static extern bool pixCopyText(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColormap")]
        internal static extern IntPtr pixGetColormap(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetColormap")]
        internal static extern bool pixSetColormap(HandleRef pix, HandleRef colormap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDestroyColormap")]
        internal static extern bool pixDestroyColormap(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetData")]
        internal static extern IntPtr pixGetData(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetData")]
        internal static extern bool pixSetData(HandleRef pix, IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractData")]
        internal static extern IntPtr pixExtractData(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFreeData")]
        internal static extern bool pixFreeData(HandleRef pix);

        // Pix line ptrs
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetLinePtrs")]
        internal static extern IntPtr pixGetLinePtrs(HandleRef pix, out int psize);

        // Pix debug
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPrintStreamInfo")]
        internal static extern bool pixPrintStreamInfo(IntPtr fp, HandleRef pix, [MarshalAs(UnmanagedType.AnsiBStr)] string text);
        #endregion

        #region pix2.c
        // Pixel poking
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetPixel")]
        internal static extern bool pixGetPixel(HandleRef pix, int x, int y, out uint pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPixel")]
        internal static extern bool pixSetPixel(HandleRef pix, int x, int y, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBPixel")]
        internal static extern bool pixGetRGBPixel(HandleRef pix, int x, int y, out int prval, out int pgval, out int pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetRGBPixel")]
        internal static extern bool pixSetRGBPixel(HandleRef pix, int x, int y, int rval, int gval, int bval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRandomPixel")]
        internal static extern bool pixGetRandomPixel(HandleRef pix, out uint pval, out int px, out int py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearPixel")]
        internal static extern bool pixClearPixel(HandleRef pix, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipPixel")]
        internal static extern bool pixFlipPixel(HandleRef pix, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setPixelLow")]
        internal static extern void setPixelLow(IntPtr line, int x, int depth, uint val);

        // Find black or white value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBlackOrWhiteVal")]
        internal static extern bool pixGetBlackOrWhiteVal(HandleRef pixs, FlagsForGettingWhiteOrBlackValue op, out uint pval);

        // Full image clear/set/set-to-arbitrary-value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearAll")]
        internal static extern bool pixClearAll(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAll")]
        internal static extern bool pixSetAll(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAllGray")]
        internal static extern bool pixSetAllGray(HandleRef pix, int grayval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetAllArbitrary")]
        internal static extern bool pixSetAllArbitrary(HandleRef pix, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBlackOrWhite")]
        internal static extern bool pixSetBlackOrWhite(HandleRef pixs, FlagsForSettingToBlackOrWhite op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetComponentArbitrary")]
        internal static extern bool pixSetComponentArbitrary(HandleRef pix, ColorsFor32Bpp comp, int val);

        // Rectangular region clear/set/set-to-arbitrary-value/blend
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClearInRect")]
        internal static extern bool pixClearInRect(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInRect")]
        internal static extern bool pixSetInRect(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetInRectArbitrary")]
        internal static extern bool pixSetInRectArbitrary(HandleRef pix, HandleRef box, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixBlendInRect")]
        internal static extern bool pixBlendInRect(HandleRef pixs, HandleRef box, uint val, float fract);

        // Set pad bits
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPadBits")]
        internal static extern bool pixSetPadBits(HandleRef pix, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPadBitsBand")]
        internal static extern bool pixSetPadBitsBand(HandleRef pix, int by, int bh, int val);

        // Assign border pixels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetOrClearBorder")]
        internal static extern bool pixSetOrClearBorder(HandleRef pixs, int left, int right, int top, int bot, ClearOrSetPixels op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBorderVal")]
        internal static extern bool pixSetBorderVal(HandleRef pixs, int left, int right, int top, int bot, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetBorderRingVal")]
        internal static extern bool pixSetBorderRingVal(HandleRef pixs, int dist, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMirroredBorder")]
        internal static extern bool pixSetMirroredBorder(HandleRef pixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyBorder")]
        internal static extern IntPtr pixCopyBorder(HandleRef pixd, HandleRef pixs, int left, int right, int top, int bot);

        // Add and remove border
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBorder")]
        internal static extern IntPtr pixAddBorder(HandleRef pixs, int npix, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBlackOrWhiteBorder")]
        internal static extern IntPtr pixAddBlackOrWhiteBorder(HandleRef pixs, int left, int right, int top, int bot, FlagsForGettingWhiteOrBlackValue op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddBorderGeneral")]
        internal static extern IntPtr pixAddBorderGeneral(HandleRef pixs, int left, int right, int top, int bot, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorder")]
        internal static extern IntPtr pixRemoveBorder(HandleRef pixs, int npix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderGeneral")]
        internal static extern IntPtr pixRemoveBorderGeneral(HandleRef pixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderToSize")]
        internal static extern IntPtr pixRemoveBorderToSize(HandleRef pixs, int wd, int hd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMirroredBorder")]
        internal static extern IntPtr pixAddMirroredBorder(HandleRef pixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddRepeatedBorder")]
        internal static extern IntPtr pixAddRepeatedBorder(HandleRef pixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMixedBorder")]
        internal static extern IntPtr pixAddMixedBorder(HandleRef pixs, int left, int right, int top, int bot);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddContinuedBorder")]
        internal static extern IntPtr pixAddContinuedBorder(HandleRef pixs, int left, int right, int top, int bot);

        // Helper functions using alpha
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixShiftAndTransferAlpha")]
        internal static extern bool pixShiftAndTransferAlpha(HandleRef pixd, HandleRef pixs, float shiftx, float shifty);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayLayersRGBA")]
        internal static extern IntPtr pixDisplayLayersRGBA(HandleRef pixs, uint val, int maxw);

        // Color sample setting and extraction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateRGBImage")]
        internal static extern IntPtr pixCreateRGBImage(HandleRef pixr, HandleRef pixg, HandleRef pixb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBComponent")]
        internal static extern IntPtr pixGetRGBComponent(HandleRef pixs, ColorsFor32Bpp comp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetRGBComponent")]
        internal static extern bool pixSetRGBComponent(HandleRef pixd, HandleRef pixs, ColorsFor32Bpp comp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBComponentCmap")]
        internal static extern IntPtr pixGetRGBComponentCmap(HandleRef pixs, ColorsFor32Bpp comp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCopyRGBComponent")]
        internal static extern bool pixCopyRGBComponent(HandleRef pixd, HandleRef pixs, ColorsFor32Bpp comp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "composeRGBPixel")]
        internal static extern bool composeRGBPixel(int rval, int gval, int bval, out uint ppixel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "composeRGBAPixel")]
        internal static extern int composeRGBAPixel(int rval, int gval, int bval, int aval, out uint ppixel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractRGBValues")]
        internal static extern void extractRGBValues(uint pixel, out int prval, out int pgval, out int pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractRGBAValues")]
        internal static extern void extractRGBAValues(uint pixel, out int prval, out int pgval, out int pbval, out int paval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractMinMaxComponent")]
        internal static extern int extractMinMaxComponent(uint pixel, MinMaxSelectionFlags type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRGBLine")]
        internal static extern bool pixGetRGBLine(HandleRef pixs, int row, IntPtr bufr, IntPtr bufg, IntPtr bufb);

        // Conversion between big and little endians
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianByteSwapNew")]
        internal static extern IntPtr pixEndianByteSwapNew(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianByteSwap")]
        internal static extern bool pixEndianByteSwap(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lineEndianByteSwap")]
        internal static extern bool lineEndianByteSwap(IntPtr datad, IntPtr datas, int wpl);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianTwoByteSwapNew")]
        internal static extern IntPtr pixEndianTwoByteSwapNew(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEndianTwoByteSwap")]
        internal static extern bool pixEndianTwoByteSwap(HandleRef pixs);

        // Extract raster data as binary string
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRasterData")]
        internal static extern bool pixGetRasterData(HandleRef pixs, out IntPtr pdata, out IntPtr pnbytes);

        // Test alpha component opaqueness
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAlphaIsOpaque")]
        internal static extern bool pixAlphaIsOpaque(HandleRef pix, out bool popaque);

        // Setup helpers for 8 bpp byte processing
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetupByteProcessing")]
        internal static extern IntPtr pixSetupByteProcessing(HandleRef pix, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCleanupByteProcessing")]
        internal static extern int pixCleanupByteProcessing(HandleRef pix, out IntPtr lineptrs);

        // Setting parameters for antialias masking with alpha transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setAlphaMaskBorder")]
        internal static extern void l_setAlphaMaskBorder(float val1, float val2);
        #endregion

        #region pix3.c
        // Masked operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMasked")]
        internal static extern int pixSetMasked(HandleRef pixd, HandleRef pixm, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetMaskedGeneral")]
        internal static extern int pixSetMaskedGeneral(HandleRef pixd, HandleRef pixm, uint val, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCombineMasked")]
        internal static extern int pixCombineMasked(HandleRef pixd, HandleRef pixs, HandleRef pixm);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCombineMaskedGeneral")]
        internal static extern int pixCombineMaskedGeneral(HandleRef pixd, HandleRef pixs, HandleRef pixm, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintThroughMask")]
        internal static extern int pixPaintThroughMask(HandleRef pixd, HandleRef pixm, int x, int y, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPaintSelfThroughMask")]
        internal static extern int pixPaintSelfThroughMask(HandleRef pixd, HandleRef pixm, int x, int y, int searchdir, int mindist, int tilesize, int ntiles, int distblend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeMaskFromVal")]
        internal static extern IntPtr pixMakeMaskFromVal(HandleRef pixs, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeMaskFromLUT")]
        internal static extern IntPtr pixMakeMaskFromLUT(HandleRef pixs, IntPtr tab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeArbMaskFromRGB")]
        internal static extern IntPtr pixMakeArbMaskFromRGB(HandleRef pixs, float rc, float gc, float bc, float thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetUnderTransparency")]
        internal static extern IntPtr pixSetUnderTransparency(HandleRef pixs, uint val, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeAlphaFromMask")]
        internal static extern IntPtr pixMakeAlphaFromMask(HandleRef pixs, int dist, out IntPtr pbox);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorNearMaskBoundary")]
        internal static extern int pixGetColorNearMaskBoundary(HandleRef pixs, HandleRef pixm, HandleRef box, int dist, out uint pval, int debug);

        // One and two-image boolean operations on arbitrary depth images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixInvert")]
        internal static extern IntPtr pixInvert(HandleRef pixd, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixOr")]
        internal static extern IntPtr pixOr(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAnd")]
        internal static extern IntPtr pixAnd(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixXor")]
        internal static extern IntPtr pixXor(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubtract")]
        internal static extern IntPtr pixSubtract(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);

        // Foreground pixel counting in 1 bpp images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixZero")]
        internal static extern int pixZero(HandleRef pix, out int pempty);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixForegroundFraction")]
        internal static extern int pixForegroundFraction(HandleRef pix, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCountPixels")]
        internal static extern IntPtr pixaCountPixels(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixels")]
        internal static extern int pixCountPixels(HandleRef pix, out int pcount, IntPtr tab8);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountByRow")]
        internal static extern IntPtr pixCountByRow(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountByColumn")]
        internal static extern IntPtr pixCountByColumn(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsByRow")]
        internal static extern IntPtr pixCountPixelsByRow(HandleRef pix, IntPtr tab8);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsByColumn")]
        internal static extern IntPtr pixCountPixelsByColumn(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountPixelsInRow")]
        internal static extern int pixCountPixelsInRow(HandleRef pix, int row, out int pcount, IntPtr tab8);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMomentByColumn")]
        internal static extern IntPtr pixGetMomentByColumn(HandleRef pix, int order);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdPixelSum")]
        internal static extern int pixThresholdPixelSum(HandleRef pix, int thresh, out int pabove, IntPtr tab8);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePixelSumTab8")]
        internal static extern IntPtr makePixelSumTab8(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makePixelCentroidTab8")]
        internal static extern IntPtr makePixelCentroidTab8(IntPtr v);

        // Average of pixel values in gray images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageByRow")]
        internal static extern IntPtr pixAverageByRow(HandleRef pix, HandleRef box, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageByColumn")]
        internal static extern IntPtr pixAverageByColumn(HandleRef pix, HandleRef box, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageInRect")]
        internal static extern int pixAverageInRect(HandleRef pix, HandleRef box, out float pave);

        // Variance of pixel values in gray images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceByRow")]
        internal static extern IntPtr pixVarianceByRow(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceByColumn")]
        internal static extern IntPtr pixVarianceByColumn(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceInRect")]
        internal static extern int pixVarianceInRect(HandleRef pix, HandleRef box, out float prootvar);

        // Average of absolute value of pixel differences in gray images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffByRow")]
        internal static extern IntPtr pixAbsDiffByRow(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffByColumn")]
        internal static extern IntPtr pixAbsDiffByColumn(HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffInRect")]
        internal static extern int pixAbsDiffInRect(HandleRef pix, HandleRef box, int dir, out float pabsdiff);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDiffOnLine")]
        internal static extern int pixAbsDiffOnLine(HandleRef pix, int x1, int y1, int x2, int y2, out float pabsdiff);

        // Count of pixels with specific value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountArbInRect")]
        internal static extern int pixCountArbInRect(HandleRef pixs, HandleRef box, int val, int factor, out int pcount);

        // Mirrored tiling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMirroredTiling")]
        internal static extern IntPtr pixMirroredTiling(HandleRef pixs, int w, int h);

        // Representative tile near but outside region
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindRepCloseTile")]
        internal static extern int pixFindRepCloseTile(HandleRef pixs, HandleRef box, int searchdir, int mindist, int tsize, int ntiles, out IntPtr pboxtile, int debug);
        #endregion

        #region pix4.c
        // Pixel histogram, rank val, averaging and min/max
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogram")]
        internal static extern IntPtr pixGetGrayHistogram(HandleRef pixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramMasked")]
        internal static extern IntPtr pixGetGrayHistogramMasked(HandleRef pixs, HandleRef pixm, int x, int y, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramInRect")]
        internal static extern IntPtr pixGetGrayHistogramInRect(HandleRef pixs, HandleRef box, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetGrayHistogramTiled")]
        internal static extern IntPtr pixGetGrayHistogramTiled(HandleRef pixs, int factor, int nx, int ny);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorHistogram")]
        internal static extern int pixGetColorHistogram(HandleRef pixs, int factor, out IntPtr pnar, out IntPtr pnag, out IntPtr pnab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorHistogramMasked")]
        internal static extern int pixGetColorHistogramMasked(HandleRef pixs, HandleRef pixm, int x, int y, int factor, out IntPtr pnar, out IntPtr pnag, out IntPtr pnab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogram")]
        internal static extern IntPtr pixGetCmapHistogram(HandleRef pixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogramMasked")]
        internal static extern IntPtr pixGetCmapHistogramMasked(HandleRef pixs, HandleRef pixm, int x, int y, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetCmapHistogramInRect")]
        internal static extern IntPtr pixGetCmapHistogramInRect(HandleRef pixs, HandleRef box, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCountRGBColors")]
        internal static extern int pixCountRGBColors(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColorAmapHistogram")]
        internal static extern IntPtr pixGetColorAmapHistogram(HandleRef pixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "amapGetCountForColor")]
        internal static extern int amapGetCountForColor(HandleRef amap, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValue")]
        internal static extern int pixGetRankValue(HandleRef pixs, int factor, float rank, out uint pvalue);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValueMaskedRGB")]
        internal static extern int pixGetRankValueMaskedRGB(HandleRef pixs, HandleRef pixm, int x, int y, int factor, float rank, out float prval, out float pgval, out float pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankValueMasked")]
        internal static extern int pixGetRankValueMasked(HandleRef pixs, HandleRef pixm, int x, int y, int factor, float rank, out float pval, out IntPtr pna);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageValue")]
        internal static extern int pixGetAverageValue(HandleRef pixs, int factor, int type, out uint pvalue);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageMaskedRGB")]
        internal static extern int pixGetAverageMaskedRGB(HandleRef pixs, HandleRef pixm, int x, int y, int factor, int type, out float prval, out float pgval, out float pbval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageMasked")]
        internal static extern int pixGetAverageMasked(HandleRef pixs, HandleRef pixm, int x, int y, int factor, int type, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageTiledRGB")]
        internal static extern int pixGetAverageTiledRGB(HandleRef pixs, int sx, int sy, int type, out IntPtr ppixr, out IntPtr ppixg, out IntPtr ppixb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAverageTiled")]
        internal static extern IntPtr pixGetAverageTiled(HandleRef pixs, int sx, int sy, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRowStats")]
        internal static extern int pixRowStats(HandleRef pixs, HandleRef box, out IntPtr pnamean, out IntPtr pnamedian, out IntPtr pnamode, out IntPtr pnamodecount, out IntPtr pnavar, out IntPtr pnarootvar);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColumnStats")]
        internal static extern int pixColumnStats(HandleRef pixs, HandleRef box, out IntPtr pnamean, out IntPtr pnamedian, out IntPtr pnamode, out IntPtr pnamodecount, out IntPtr pnavar, out IntPtr pnarootvar);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRangeValues")]
        internal static extern int pixGetRangeValues(HandleRef pixs, int factor, int color, out int pminval, out int pmaxval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetExtremeValue")]
        internal static extern int pixGetExtremeValue(HandleRef pixs, int factor, int type, out int prval, out int pgval, out int pbval, out int pgrayval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetMaxValueInRect")]
        internal static extern int pixGetMaxValueInRect(HandleRef pixs, HandleRef box, out uint pmaxval, out int pxmax, out int pymax);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBinnedComponentRange")]
        internal static extern int pixGetBinnedComponentRange(HandleRef pixs, int nbins, int factor, int color, out int pminval, out int pmaxval, out IntPtr pcarray, int fontsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRankColorArray")]
        internal static extern int pixGetRankColorArray(HandleRef pixs, int nbins, int type, int factor, out IntPtr pcarray, int debugflag, int fontsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetBinnedColor")]
        internal static extern int pixGetBinnedColor(HandleRef pixs, HandleRef pixg, int factor, int nbins, HandleRef nalut, out IntPtr pcarray, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayColorArray")]
        internal static extern IntPtr pixDisplayColorArray(IntPtr carray, int ncolors, int side, int ncols, int fontsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankBinByStrip")]
        internal static extern IntPtr pixRankBinByStrip(HandleRef pixs, int direction, int size, int nbins, int type);

        // Pixelwise aligned statistics
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetAlignedStats")]
        internal static extern IntPtr pixaGetAlignedStats(HandleRef pixa, int type, int nbins, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtractColumnFromEachPix")]
        internal static extern int pixaExtractColumnFromEachPix(HandleRef pixa, int col, HandleRef pixd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRowStats")]
        internal static extern int pixGetRowStats(HandleRef pixs, int type, int nbins, int thresh, IntPtr colvect);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetColumnStats")]
        internal static extern int pixGetColumnStats(HandleRef pixs, int type, int nbins, int thresh, IntPtr rowvect);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetPixelColumn")]
        internal static extern int pixSetPixelColumn(HandleRef pix, int col, IntPtr colvect);

        // Foreground/background estimation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdForFgBg")]
        internal static extern int pixThresholdForFgBg(HandleRef pixs, int factor, int thresh, out int pfgval, out int pbgval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSplitDistributionFgBg")]
        internal static extern int pixSplitDistributionFgBg(HandleRef pixs, float scorefract, int factor, out int pthresh, out int pfgval, out int pbgval, out IntPtr ppixdb);
        #endregion

        #region pix5.c - DONE
        // Measurement of properties
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindDimensions")]
        internal static extern bool pixaFindDimensions(HandleRef pixa, ref IntPtr pnaw, ref IntPtr pnah);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaPerimRatio")]
        internal static extern bool pixFindAreaPerimRatio(HandleRef pixs, IntPtr tab, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindPerimToAreaRatio")]
        internal static extern IntPtr pixaFindPerimToAreaRatio(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPerimToAreaRatio")]
        internal static extern bool pixFindPerimToAreaRatio(HandleRef pixs, IntPtr tab, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindPerimSizeRatio")]
        internal static extern IntPtr pixaFindPerimSizeRatio(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindPerimSizeRatio")]
        internal static extern bool pixFindPerimSizeRatio(HandleRef pixs, IntPtr tab, out float pratio);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindAreaFraction")]
        internal static extern IntPtr pixaFindAreaFraction(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaFraction")]
        internal static extern bool pixFindAreaFraction(HandleRef pixs, IntPtr tab, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindAreaFractionMasked")]
        internal static extern IntPtr pixaFindAreaFractionMasked(HandleRef pixa, HandleRef pixm, bool debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindAreaFractionMasked")]
        internal static extern bool pixFindAreaFractionMasked(HandleRef pixs, HandleRef box, HandleRef pixm, IntPtr tab, out float pfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindWidthHeightRatio")]
        internal static extern IntPtr pixaFindWidthHeightRatio(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindWidthHeightProduct")]
        internal static extern IntPtr pixaFindWidthHeightProduct(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindOverlapFraction")]
        internal static extern bool pixFindOverlapFraction(HandleRef pixs1, HandleRef pixs2, int x2, int y2, IntPtr tab, out float pratio, out int pnoverlap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindRectangleComps")]
        internal static extern IntPtr pixFindRectangleComps(HandleRef pixs, int dist, int minw, int minh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConformsToRectangle")]
        internal static extern bool pixConformsToRectangle(HandleRef pixs, HandleRef box, int dist, out bool pconforms);

        // Extract rectangular region
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipRectangles")]
        internal static extern IntPtr pixClipRectangles(HandleRef pixs, HandleRef boxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipRectangle")]
        internal static extern IntPtr pixClipRectangle(HandleRef pixs, HandleRef box, ref IntPtr pboxc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipMasked")]
        internal static extern IntPtr pixClipMasked(HandleRef pixs, HandleRef pixm, int x, int y, uint outval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropToMatch")]
        internal static extern bool pixCropToMatch(HandleRef pixs1, HandleRef pixs2, ref IntPtr ppixd1, ref IntPtr ppixd2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCropToSize")]
        internal static extern IntPtr pixCropToSize(HandleRef pixs, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixResizeToMatch")]
        internal static extern IntPtr pixResizeToMatch(HandleRef pixs, HandleRef pixt, int w, int h);

        // Make a frame mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMakeFrameMask")]
        internal static extern IntPtr pixMakeFrameMask(int w, int h, float hf1, float hf2, float vf1, float vf2);

        // Fraction of Fg pixels under a mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFractionFgInMask")]
        internal static extern bool pixFractionFgInMask(HandleRef pix1, HandleRef pix2, out float pfract);

        // Clip to foreground
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipToForeground")]
        internal static extern bool pixClipToForeground(HandleRef pixs, ref IntPtr ppixd, ref IntPtr pbox);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTestClipToForeground")]
        internal static extern bool pixTestClipToForeground(HandleRef pixs, out bool pcanclip);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipBoxToForeground")]
        internal static extern bool pixClipBoxToForeground(HandleRef pixs, HandleRef boxs, ref IntPtr ppixd, ref IntPtr pboxd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScanForForeground")]
        internal static extern bool pixScanForForeground(HandleRef pixs, HandleRef box, ScanDirectionFlags scanflag, out int ploc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixClipBoxToEdges")]
        internal static extern bool pixClipBoxToEdges(HandleRef pixs, HandleRef boxs, int lowthresh, int highthresh, int maxwidth, int factor, ref IntPtr ppixd, ref IntPtr pboxd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScanForEdge")]
        internal static extern bool pixScanForEdge(HandleRef pixs, HandleRef box, int lowthresh, int highthresh, int maxwidth, int factor, ScanDirectionFlags scanflag, out int ploc);

        // Extract pixel averages and reversals along lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractOnLine")]
        internal static extern IntPtr pixExtractOnLine(HandleRef pixs, int x1, int y1, int x2, int y2, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageOnLine")]
        internal static extern float pixAverageOnLine(HandleRef pixs, int x1, int y1, int x2, int y2, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAverageIntensityProfile")]
        internal static extern IntPtr pixAverageIntensityProfile(HandleRef pixs, float fract, LineOrientationFlags dir, int first, int last, int factor1, int factor2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReversalProfile")]
        internal static extern IntPtr pixReversalProfile(HandleRef pixs, float fract, LineOrientationFlags dir, int first, int last, int minreversal, int factor1, int factor2);

        // Extract windowed variance along a line
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWindowedVarianceOnLine")]
        internal static extern bool pixWindowedVarianceOnLine(HandleRef pixs, LineOrientationFlags dir, int loc, int c1, int c2, int size, ref IntPtr pnad);

        // Extract min/max of pixel values near lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinMaxNearLine")]
        internal static extern bool pixMinMaxNearLine(HandleRef pixs, int x1, int y1, int x2, int y2, int dist, ScanDirectionFlags direction, ref IntPtr pnamin, ref IntPtr pnamax, out float pminave, out float pmaxave);

        // Rank row and column transforms
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankRowTransform")]
        internal static extern IntPtr pixRankRowTransform(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankColumnTransform")]
        internal static extern IntPtr pixRankColumnTransform(HandleRef pixs);
        #endregion

        #region pixabasic.c - DONE
        // Pixa creation, destruction, copying
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreate")]
        internal static extern IntPtr pixaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromPix")]
        internal static extern IntPtr pixaCreateFromPix(HandleRef pixs, int n, int cellw, int cellh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromBoxa")]
        internal static extern IntPtr pixaCreateFromBoxa(HandleRef pixs, HandleRef boxa, out int pcropwarn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSplitPix")]
        internal static extern IntPtr pixaSplitPix(HandleRef pixs, int nx, int ny, int borderwidth, uint bordercolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDestroy")]
        internal static extern void pixaDestroy(ref IntPtr ppixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCopy")]
        internal static extern IntPtr pixaCopy(HandleRef pixa, int copyflag);

        // Pixa addition
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddPix")]
        internal static extern int pixaAddPix(HandleRef pixa, HandleRef pix, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddBox")]
        internal static extern int pixaAddBox(HandleRef pixa, HandleRef box, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaExtendArrayToSize")]
        internal static extern int pixaExtendArrayToSize(HandleRef pixa, int size);

        // Pixa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetCount")]
        internal static extern int pixaGetCount(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaChangeRefcount")]
        internal static extern int pixaChangeRefcount(HandleRef pixa, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPix")]
        internal static extern IntPtr pixaGetPix(HandleRef pixa, int index, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPixDimensions")]
        internal static extern int pixaGetPixDimensions(HandleRef pixa, int index, out int pw, out int ph, out int pd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxa")]
        internal static extern IntPtr pixaGetBoxa(HandleRef pixa, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxaCount")]
        internal static extern int pixaGetBoxaCount(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBox")]
        internal static extern IntPtr pixaGetBox(HandleRef pixa, int index, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetBoxGeometry")]
        internal static extern int pixaGetBoxGeometry(HandleRef pixa, int index, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetBoxa")]
        internal static extern int pixaSetBoxa(HandleRef pixa, HandleRef boxa, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetPixArray")]
        internal static extern IntPtr pixaGetPixArray(HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaVerifyDepth")]
        internal static extern int pixaVerifyDepth(HandleRef pixa, out int pmaxdepth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaIsFull")]
        internal static extern int pixaIsFull(HandleRef pixa, out int pfullpa, out int pfullba);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCountText")]
        internal static extern int pixaCountText(HandleRef pixa, out int pntext);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetText")]
        internal static extern int pixaSetText(HandleRef pixa, HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetLinePtrs")]
        internal static extern IntPtr pixaGetLinePtrs(HandleRef pixa, out int psize);

        // Pixa output info
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteStreamInfo")]
        internal static extern int pixaWriteStreamInfo(IntPtr fp, HandleRef pixa);

        // Pixa array modifiers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReplacePix")]
        internal static extern int pixaReplacePix(HandleRef pixa, int index, HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInsertPix")]
        internal static extern int pixaInsertPix(HandleRef pixa, int index, HandleRef pixs, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemovePix")]
        internal static extern int pixaRemovePix(HandleRef pixa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemovePixAndSave")]
        internal static extern int pixaRemovePixAndSave(HandleRef pixa, int index, out IntPtr ppix, out IntPtr pbox);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInitFull")]
        internal static extern int pixaInitFull(HandleRef pixa, HandleRef pix, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClear")]
        internal static extern int pixaClear(HandleRef pixa);

        // Pixa and Pixaa combination
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaJoin")]
        internal static extern int pixaJoin(HandleRef pixad, HandleRef pixas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaInterleave")]
        internal static extern IntPtr pixaInterleave(HandleRef pixa1, HandleRef pixa2, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaJoin")]
        internal static extern int pixaaJoin(HandleRef paad, HandleRef paas, int istart, int iend);

        // Pixaa creation, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaCreate")]
        internal static extern IntPtr pixaaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaCreateFromPixa")]
        internal static extern IntPtr pixaaCreateFromPixa(HandleRef pixa, int n, int type, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDestroy")]
        internal static extern void pixaaDestroy(ref IntPtr ppaa);

        // Pixaa addition
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddPixa")]
        internal static extern int pixaaAddPixa(HandleRef paa, HandleRef pixa, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaExtendArray")]
        internal static extern int pixaaExtendArray(HandleRef paa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddPix")]
        internal static extern int pixaaAddPix(HandleRef paa, int index, HandleRef pix, HandleRef box, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaAddBox")]
        internal static extern int pixaaAddBox(HandleRef paa, HandleRef box, int copyflag);

        // Pixaa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetCount")]
        internal static extern int pixaaGetCount(HandleRef paa, out IntPtr pna);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetPixa")]
        internal static extern IntPtr pixaaGetPixa(HandleRef paa, int index, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetBoxa")]
        internal static extern IntPtr pixaaGetBoxa(HandleRef paa, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaGetPix")]
        internal static extern IntPtr pixaaGetPix(HandleRef paa, int index, int ipix, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaVerifyDepth")]
        internal static extern int pixaaVerifyDepth(HandleRef paa, out int pmaxdepth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaIsFull")]
        internal static extern int pixaaIsFull(HandleRef paa, out int pfull);

        // Pixaa array modifiers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaInitFull")]
        internal static extern int pixaaInitFull(HandleRef paa, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReplacePixa")]
        internal static extern int pixaaReplacePixa(HandleRef paa, int index, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaClear")]
        internal static extern int pixaaClear(HandleRef paa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaTruncate")]
        internal static extern int pixaaTruncate(HandleRef paa);

        // Pixa serialized I/O(requires png support)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRead")]
        internal static extern IntPtr pixaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadStream")]
        internal static extern IntPtr pixaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadMem")]
        internal static extern IntPtr pixaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWrite")]
        internal static extern int pixaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteStream")]
        internal static extern int pixaWriteStream(IntPtr fp, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteMem")]
        internal static extern int pixaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadBoth")]
        internal static extern IntPtr pixaReadBoth([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        // Pixaa serialized I/O(requires png support)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadFromFiles")]
        internal static extern IntPtr pixaaReadFromFiles([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int first, int nfiles);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaRead")]
        internal static extern IntPtr pixaaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadStream")]
        internal static extern IntPtr pixaaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaReadMem")]
        internal static extern IntPtr pixaaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWrite")]
        internal static extern int pixaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef paa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWriteStream")]
        internal static extern int pixaaWriteStream(IntPtr fp, HandleRef paa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaWriteMem")]
        internal static extern int pixaaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef paa);
        #endregion

        #region pixacc.c
        // Pixacc creation, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccCreate")]
        internal static extern IntPtr pixaccCreate(int w, int h, int negflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccCreateFromPix")]
        internal static extern IntPtr pixaccCreateFromPix(HandleRef pix, int negflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccDestroy")]
        internal static extern void pixaccDestroy(ref IntPtr ppixacc);

        // Pixacc finalization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccFinal")]
        internal static extern IntPtr pixaccFinal(HandleRef pixacc, int outdepth);

        // Pixacc accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccGetPix")]
        internal static extern IntPtr pixaccGetPix(HandleRef pixacc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccGetOffset")]
        internal static extern int pixaccGetOffset(HandleRef pixacc);

        // Pixacc accumulators
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccAdd")]
        internal static extern int pixaccAdd(HandleRef pixacc, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccSubtract")]
        internal static extern int pixaccSubtract(HandleRef pixacc, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccMultConst")]
        internal static extern int pixaccMultConst(HandleRef pixacc, float factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaccMultConstAccumulate")]
        internal static extern int pixaccMultConstAccumulate(HandleRef pixacc, HandleRef pix, float factor);
        #endregion

        #region pixafunc1.c
        // Filters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectBySize")]
        internal static extern IntPtr pixSelectBySize(HandleRef pixs, int width, int height, int connectivity, int type, int relation, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectBySize")]
        internal static extern IntPtr pixaSelectBySize(HandleRef pixas, int width, int height, int type, int relation, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaMakeSizeIndicator")]
        internal static extern IntPtr pixaMakeSizeIndicator(HandleRef pixa, int width, int height, int type, int relation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByPerimToAreaRatio")]
        internal static extern IntPtr pixSelectByPerimToAreaRatio(HandleRef pixs, float thresh, int connectivity, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByPerimToAreaRatio")]
        internal static extern IntPtr pixaSelectByPerimToAreaRatio(HandleRef pixas, float thresh, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByPerimSizeRatio")]
        internal static extern IntPtr pixSelectByPerimSizeRatio(HandleRef pixs, float thresh, int connectivity, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByPerimSizeRatio")]
        internal static extern IntPtr pixaSelectByPerimSizeRatio(HandleRef pixas, float thresh, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByAreaFraction")]
        internal static extern IntPtr pixSelectByAreaFraction(HandleRef pixs, float thresh, int connectivity, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByAreaFraction")]
        internal static extern IntPtr pixaSelectByAreaFraction(HandleRef pixas, float thresh, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectByWidthHeightRatio")]
        internal static extern IntPtr pixSelectByWidthHeightRatio(HandleRef pixs, float thresh, int connectivity, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByWidthHeightRatio")]
        internal static extern IntPtr pixaSelectByWidthHeightRatio(HandleRef pixas, float thresh, int type, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectByNumConnComp")]
        internal static extern IntPtr pixaSelectByNumConnComp(HandleRef pixas, int nmin, int nmax, int connectivity, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectWithIndicator")]
        internal static extern IntPtr pixaSelectWithIndicator(HandleRef pixas, HandleRef na, out int pchanged);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveWithIndicator")]
        internal static extern int pixRemoveWithIndicator(HandleRef pixs, HandleRef pixa, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddWithIndicator")]
        internal static extern int pixAddWithIndicator(HandleRef pixs, HandleRef pixa, HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectWithString")]
        internal static extern IntPtr pixaSelectWithString(HandleRef pixas, [MarshalAs(UnmanagedType.AnsiBStr)] string str, IntPtr perror);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRenderComponent")]
        internal static extern IntPtr pixaRenderComponent(HandleRef pixs, HandleRef pixa, int index);

        // Sort functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSort")]
        internal static extern IntPtr pixaSort(HandleRef pixas, int sorttype, int sortorder, out IntPtr pnaindex, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaBinSort")]
        internal static extern IntPtr pixaBinSort(HandleRef pixas, int sorttype, int sortorder, out IntPtr pnaindex, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSortByIndex")]
        internal static extern IntPtr pixaSortByIndex(HandleRef pixas, HandleRef naindex, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSort2dByIndex")]
        internal static extern IntPtr pixaSort2dByIndex(HandleRef pixas, HandleRef naa, int copyflag);

        // Pixa and Pixaa range selection
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectRange")]
        internal static extern IntPtr pixaSelectRange(HandleRef pixas, int first, int last, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaSelectRange")]
        internal static extern IntPtr pixaaSelectRange(HandleRef paas, int first, int last, int copyflag);

        // Pixa and Pixaa scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaScaleToSize")]
        internal static extern IntPtr pixaaScaleToSize(HandleRef paas, int wd, int hd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaScaleToSizeVar")]
        internal static extern IntPtr pixaaScaleToSizeVar(HandleRef paas, HandleRef nawd, HandleRef nahd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScaleToSize")]
        internal static extern IntPtr pixaScaleToSize(HandleRef pixas, int wd, int hd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScaleToSizeRel")]
        internal static extern IntPtr pixaScaleToSizeRel(HandleRef pixas, int delw, int delh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaScale")]
        internal static extern IntPtr pixaScale(HandleRef pixas, float scalex, float scaley);

        // Miscellaneous
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddBorderGeneral")]
        internal static extern IntPtr pixaAddBorderGeneral(HandleRef pixad, HandleRef pixas, int left, int right, int top, int bot, uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaFlattenToPixa")]
        internal static extern IntPtr pixaaFlattenToPixa(HandleRef paa, out IntPtr pnaindex, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaSizeRange")]
        internal static extern int pixaaSizeRange(HandleRef paa, out int pminw, out int pminh, out int pmaxw, out int pmaxh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSizeRange")]
        internal static extern int pixaSizeRange(HandleRef pixa, out int pminw, out int pminh, out int pmaxw, out int pmaxh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClipToPix")]
        internal static extern IntPtr pixaClipToPix(HandleRef pixas, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaClipToForeground")]
        internal static extern int pixaClipToForeground(HandleRef pixas, out IntPtr ppixad, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetRenderingDepth")]
        internal static extern int pixaGetRenderingDepth(HandleRef pixa, out int pdepth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaHasColor")]
        internal static extern int pixaHasColor(HandleRef pixa, out int phascolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAnyColormaps")]
        internal static extern int pixaAnyColormaps(HandleRef pixa, out int phascmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaGetDepthInfo")]
        internal static extern int pixaGetDepthInfo(HandleRef pixa, out int pmaxdepth, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToSameDepth")]
        internal static extern IntPtr pixaConvertToSameDepth(HandleRef pixas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaEqual")]
        internal static extern int pixaEqual(HandleRef pixa1, HandleRef pixa2, int maxdist, out IntPtr pnaindex, out int psame);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRotateOrth")]
        internal static extern IntPtr pixaRotateOrth(HandleRef pixas, int rotation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetFullSizeBoxa")]
        internal static extern int pixaSetFullSizeBoxa(HandleRef pixa);
        #endregion

        #region pixafunc2.c
        // Pixa display(render into a pix)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplay")]
        internal static extern IntPtr pixaDisplay(HandleRef pixa, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayOnColor")]
        internal static extern IntPtr pixaDisplayOnColor(HandleRef pixa, int w, int h, uint bgcolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayRandomCmap")]
        internal static extern IntPtr pixaDisplayRandomCmap(HandleRef pixa, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayLinearly")]
        internal static extern IntPtr pixaDisplayLinearly(HandleRef pixas, int direction, float scalefactor, int background, int spacing, int border, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayOnLattice")]
        internal static extern IntPtr pixaDisplayOnLattice(HandleRef pixa, int cellw, int cellh, out int pncols, out IntPtr pboxa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayUnsplit")]
        internal static extern IntPtr pixaDisplayUnsplit(HandleRef pixa, int nx, int ny, int borderwidth, uint bordercolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiled")]
        internal static extern IntPtr pixaDisplayTiled(HandleRef pixa, int maxwidth, int background, int spacing);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledInRows")]
        internal static extern IntPtr pixaDisplayTiledInRows(HandleRef pixa, int outdepth, int maxwidth, float scalefactor, int background, int spacing, int border);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledInColumns")]
        internal static extern IntPtr pixaDisplayTiledInColumns(HandleRef pixas, int nx, float scalefactor, int spacing, int border);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledAndScaled")]
        internal static extern IntPtr pixaDisplayTiledAndScaled(HandleRef pixa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledWithText")]
        internal static extern IntPtr pixaDisplayTiledWithText(HandleRef pixa, int maxwidth, float scalefactor, int spacing, int border, int fontsize, uint textcolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayTiledByIndex")]
        internal static extern IntPtr pixaDisplayTiledByIndex(HandleRef pixa, HandleRef na, int width, int spacing, int border, int fontsize, uint textcolor);

        // Pixaa display(render into a pix)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplay")]
        internal static extern IntPtr pixaaDisplay(HandleRef paa, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplayByPixa")]
        internal static extern IntPtr pixaaDisplayByPixa(HandleRef paa, int xspace, int yspace, int maxw);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaaDisplayTiledAndScaled")]
        internal static extern IntPtr pixaaDisplayTiledAndScaled(HandleRef paa, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);

        // Conversion of all pix to specified type(e.g., depth)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo1")]
        internal static extern IntPtr pixaConvertTo1(HandleRef pixas, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo8")]
        internal static extern IntPtr pixaConvertTo8(HandleRef pixas, int cmapflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo8Color")]
        internal static extern IntPtr pixaConvertTo8Color(HandleRef pixas, int dither);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertTo32")]
        internal static extern IntPtr pixaConvertTo32(HandleRef pixas);

        // Pixa constrained selection and pdf generation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConstrainedSelect")]
        internal static extern IntPtr pixaConstrainedSelect(HandleRef pixas, int first, int last, int nmax, int use_pairs, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSelectToPdf")]
        internal static extern int pixaSelectToPdf(HandleRef pixas, int first, int last, int res, float scalefactor, int type, int quality, uint color, int fontsize, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        // Pixa display into multiple tiles
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaDisplayMultiTiled")]
        internal static extern IntPtr pixaDisplayMultiTiled(HandleRef pixas, int nx, int ny, int maxw, int maxh, float scalefactor, int spacing, int border);

        // Split pixa into files
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSplitIntoFiles")]
        internal static extern int pixaSplitIntoFiles(HandleRef pixas, int nsplit, float scale, int outwidth, int write_pixa, int write_pix, int write_pdf);

        // Tile N-Up
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToNUpFiles")]
        internal static extern int convertToNUpFiles([MarshalAs(UnmanagedType.AnsiBStr)] string dir, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int nx, int ny, int tw, int spacing, int border, int fontsize, [MarshalAs(UnmanagedType.AnsiBStr)] string outdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToNUpPixa")]
        internal static extern IntPtr convertToNUpPixa([MarshalAs(UnmanagedType.AnsiBStr)] string dir, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int nx, int ny, int tw, int spacing, int border, int fontsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaConvertToNUpPixa")]
        internal static extern IntPtr pixaConvertToNUpPixa(HandleRef pixas, HandleRef sa, int nx, int ny, int tw, int spacing, int border, int fontsize);

        // Render two pixa side-by-side for comparison*
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCompareInPdf")]
        internal static extern int pixaCompareInPdf(HandleRef pixa1, HandleRef pixa2, int nx, int ny, int tw, int spacing, int border, int fontsize, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        #endregion

        #region pixalloc.c
        //  Custom memory storage with allocator and deallocator
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCreate")]
        internal static extern int pmsCreate(IntPtr minsize, IntPtr smallest, HandleRef numalloc, [MarshalAs(UnmanagedType.AnsiBStr)] string logfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsDestroy")]
        internal static extern void pmsDestroy();
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCustomAlloc")]
        internal static extern IntPtr pmsCustomAlloc(IntPtr nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsCustomDealloc")]
        internal static extern void pmsCustomDealloc(IntPtr data);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetAlloc")]
        internal static extern IntPtr pmsGetAlloc(IntPtr nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetLevelForAlloc")]
        internal static extern int pmsGetLevelForAlloc(IntPtr nbytes, IntPtr plevel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsGetLevelForDealloc")]
        internal static extern int pmsGetLevelForDealloc(IntPtr data, IntPtr plevel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pmsLogInfo")]
        internal static extern void pmsLogInfo();
        #endregion

        #region pixarith.c
        // One-image grayscale arithmetic operations(8, 16, 32 bpp)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddConstantGray")]
        internal static extern int pixAddConstantGray(HandleRef pixs, int val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstantGray")]
        internal static extern int pixMultConstantGray(HandleRef pixs, float val);

        // Two-image grayscale arithmetic operations(8, 16, 32 bpp)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGray")]
        internal static extern IntPtr pixAddGray(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubtractGray")]
        internal static extern IntPtr pixSubtractGray(HandleRef pixd, HandleRef pixs1, HandleRef pixs2);

        // Grayscale threshold operation(8, 16, 32 bpp)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThresholdToValue")]
        internal static extern IntPtr pixThresholdToValue(HandleRef pixd, HandleRef pixs, int threshval, int setval);

        // Image accumulator arithmetic operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixInitAccumulate")]
        internal static extern IntPtr pixInitAccumulate(int w, int h, uint offset);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFinalAccumulate")]
        internal static extern IntPtr pixFinalAccumulate(HandleRef pixs, uint offset, int depth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFinalAccumulateThreshold")]
        internal static extern IntPtr pixFinalAccumulateThreshold(HandleRef pixs, uint offset, uint threshold);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAccumulate")]
        internal static extern int pixAccumulate(HandleRef pixd, HandleRef pixs, int op);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMultConstAccumulate")]
        internal static extern int pixMultConstAccumulate(HandleRef pixs, float factor, uint offset);

        // Absolute value of difference
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAbsDifference")]
        internal static extern IntPtr pixAbsDifference(HandleRef pixs1, HandleRef pixs2);

        // Sum of color images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddRGB")]
        internal static extern IntPtr pixAddRGB(HandleRef pixs1, HandleRef pixs2);

        // Two-image min and max operations(8 and 16 bpp)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMinOrMax")]
        internal static extern IntPtr pixMinOrMax(HandleRef pixd, HandleRef pixs1, HandleRef pixs2, int type);

        // Scale pix for maximum dynamic range
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaxDynamicRange")]
        internal static extern IntPtr pixMaxDynamicRange(HandleRef pixs, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMaxDynamicRangeRGB")]
        internal static extern IntPtr pixMaxDynamicRangeRGB(HandleRef pixs, int type);

        // RGB pixel value scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "linearScaleRGBVal")]
        internal static extern uint linearScaleRGBVal(uint sval, float factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "logScaleRGBVal")]
        internal static extern uint logScaleRGBVal(uint sval, IntPtr tab, float factor);

        // Log base2 lookup
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeLogBase2Tab")]
        internal static extern IntPtr makeLogBase2Tab(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getLogBase2")]
        internal static extern float getLogBase2(int val, IntPtr logtab);
        #endregion

        #region pixcomp.c
        // Pixcomp creation and destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromPix")]
        internal static extern IntPtr pixcompCreateFromPix(HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromString")]
        internal static extern IntPtr pixcompCreateFromString(IntPtr data, IntPtr size, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCreateFromFile")]
        internal static extern IntPtr pixcompCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompDestroy")]
        internal static extern void pixcompDestroy(ref IntPtr ppixc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompCopy")]
        internal static extern IntPtr pixcompCopy(HandleRef pixcs);

        // Pixcomp accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompGetDimensions")]
        internal static extern int pixcompGetDimensions(HandleRef pixc, out int pw, out int ph, out int pd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompDetermineFormat")]
        internal static extern int pixcompDetermineFormat(int comptype, int d, int cmapflag, out int pformat);

        // Pixcomp conversion to Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixCreateFromPixcomp")]
        internal static extern IntPtr pixCreateFromPixcomp(HandleRef pixc);

        // Pixacomp creation and destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreate")]
        internal static extern IntPtr pixacompCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateWithInit")]
        internal static extern IntPtr pixacompCreateWithInit(int n, int offset, HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromPixa")]
        internal static extern IntPtr pixacompCreateFromPixa(HandleRef pixa, int comptype, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromFiles")]
        internal static extern IntPtr pixacompCreateFromFiles([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompCreateFromSA")]
        internal static extern IntPtr pixacompCreateFromSA(HandleRef sa, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompDestroy")]
        internal static extern void pixacompDestroy(ref IntPtr ppixac);

        // Pixacomp addition/replacement
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddPix")]
        internal static extern int pixacompAddPix(HandleRef pixac, HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddPixcomp")]
        internal static extern int pixacompAddPixcomp(HandleRef pixac, HandleRef pixc, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReplacePix")]
        internal static extern int pixacompReplacePix(HandleRef pixac, int index, HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReplacePixcomp")]
        internal static extern int pixacompReplacePixcomp(HandleRef pixac, int index, HandleRef pixc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompAddBox")]
        internal static extern int pixacompAddBox(HandleRef pixac, HandleRef box, int copyflag);

        // Pixacomp accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetCount")]
        internal static extern int pixacompGetCount(HandleRef pixac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPixcomp")]
        internal static extern IntPtr pixacompGetPixcomp(HandleRef pixac, int index, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPix")]
        internal static extern IntPtr pixacompGetPix(HandleRef pixac, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetPixDimensions")]
        internal static extern int pixacompGetPixDimensions(HandleRef pixac, int index, out int pw, out int ph, out int pd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxa")]
        internal static extern IntPtr pixacompGetBoxa(HandleRef pixac, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxaCount")]
        internal static extern int pixacompGetBoxaCount(HandleRef pixac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBox")]
        internal static extern IntPtr pixacompGetBox(HandleRef pixac, int index, int accesstype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetBoxGeometry")]
        internal static extern int pixacompGetBoxGeometry(HandleRef pixac, int index, out int px, out int py, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompGetOffset")]
        internal static extern int pixacompGetOffset(HandleRef pixac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompSetOffset")]
        internal static extern int pixacompSetOffset(HandleRef pixac, int offset);

        // Pixacomp conversion to Pixa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaCreateFromPixacomp")]
        internal static extern IntPtr pixaCreateFromPixacomp(HandleRef pixac, int accesstype);

        // Combining pixacomp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompJoin")]
        internal static extern int pixacompJoin(HandleRef pixacd, HandleRef pixacs, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompInterleave")]
        internal static extern IntPtr pixacompInterleave(HandleRef pixac1, HandleRef pixac2);

        // Pixacomp serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompRead")]
        internal static extern IntPtr pixacompRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReadStream")]
        internal static extern IntPtr pixacompReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompReadMem")]
        internal static extern IntPtr pixacompReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWrite")]
        internal static extern int pixacompWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pixac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteStream")]
        internal static extern int pixacompWriteStream(IntPtr fp, HandleRef pixac);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteMem")]
        internal static extern int pixacompWriteMem(out IntPtr pdata, IntPtr psize, HandleRef pixac);

        // Conversion to pdf
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompConvertToPdf")]
        internal static extern int pixacompConvertToPdf(HandleRef pixac, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompConvertToPdfData")]
        internal static extern int pixacompConvertToPdfData(HandleRef pixac, int res, float scalefactor, int type, int quality, [MarshalAs(UnmanagedType.AnsiBStr)] string title, out IntPtr pdata, IntPtr pnbytes);

        // Output for debugging
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompWriteStreamInfo")]
        internal static extern int pixacompWriteStreamInfo(IntPtr fp, HandleRef pixac, [MarshalAs(UnmanagedType.AnsiBStr)] string text);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixcompWriteStreamInfo")]
        internal static extern int pixcompWriteStreamInfo(IntPtr fp, HandleRef pixc, [MarshalAs(UnmanagedType.AnsiBStr)] string text);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixacompDisplayTiledAndScaled")]
        internal static extern IntPtr pixacompDisplayTiledAndScaled(HandleRef pixac, int outdepth, int tilewidth, int ncols, int background, int spacing, int border);
        #endregion

        #region pixconv.c
        // Conversion from 8 bpp grayscale to 1, 2, 4 and 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixThreshold8")]
        internal static extern IntPtr pixThreshold8(HandleRef pixs, int d, int nlevels, int cmapflag);

        // Conversion from colormap to full color or grayscale
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveColormapGeneral")]
        internal static extern IntPtr pixRemoveColormapGeneral(HandleRef pixs, int type, int ifnocmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveColormap")]
        internal static extern IntPtr pixRemoveColormap(HandleRef pixs, int type);

        // Add colormap losslessly(8 to 8)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddGrayColormap8")]
        internal static extern int pixAddGrayColormap8(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddMinimalGrayColormap8")]
        internal static extern IntPtr pixAddMinimalGrayColormap8(HandleRef pixs);

        // Conversion from RGB color to grayscale
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToLuminance")]
        internal static extern IntPtr pixConvertRGBToLuminance(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGray")]
        internal static extern IntPtr pixConvertRGBToGray(HandleRef pixs, float rwt, float gwt, float bwt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayFast")]
        internal static extern IntPtr pixConvertRGBToGrayFast(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayMinMax")]
        internal static extern IntPtr pixConvertRGBToGrayMinMax(HandleRef pixs, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGraySatBoost")]
        internal static extern IntPtr pixConvertRGBToGraySatBoost(HandleRef pixs, int refval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToGrayArb")]
        internal static extern IntPtr pixConvertRGBToGrayArb(HandleRef pixs, float rc, float gc, float bc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToBinaryArb")]
        internal static extern IntPtr pixConvertRGBToBinaryArb(HandleRef pixs, float rc, float gc, float bc, int thresh, int relation);

        // Conversion from grayscale to colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToColormap")]
        internal static extern IntPtr pixConvertGrayToColormap(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToColormap8")]
        internal static extern IntPtr pixConvertGrayToColormap8(HandleRef pixs, int mindepth);

        // Colorizing conversion from grayscale to color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixColorizeGray")]
        internal static extern IntPtr pixColorizeGray(HandleRef pixs, uint color, int cmapflag);

        // Conversion from RGB color to colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertRGBToColormap")]
        internal static extern IntPtr pixConvertRGBToColormap(HandleRef pixs, int ditherflag);

        // Conversion from colormap to 1 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertCmapTo1")]
        internal static extern IntPtr pixConvertCmapTo1(HandleRef pixs);

        // Quantization for relatively small number of colors in source
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuantizeIfFewColors")]
        internal static extern int pixQuantizeIfFewColors(HandleRef pixs, int maxcolors, int mingraycolors, int octlevel, out IntPtr ppixd);

        // Conversion from 16 bpp to 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert16To8")]
        internal static extern IntPtr pixConvert16To8(HandleRef pixs, int type);

        // Conversion from grayscale to false color
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToFalseColor")]
        internal static extern IntPtr pixConvertGrayToFalseColor(HandleRef pixs, float gamma);

        // Unpacking conversion from 1 bpp to 2, 4, 8, 16 and 32 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixUnpackBinary")]
        internal static extern IntPtr pixUnpackBinary(HandleRef pixs, int depth, int invert);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To16")]
        internal static extern IntPtr pixConvert1To16(HandleRef pixd, HandleRef pixs, ushort val0, ushort val1);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To32")]
        internal static extern IntPtr pixConvert1To32(HandleRef pixd, HandleRef pixs, uint val0, uint val1);

        // Unpacking conversion from 1 bpp to 2 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To2Cmap")]
        internal static extern IntPtr pixConvert1To2Cmap(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To2")]
        internal static extern IntPtr pixConvert1To2(HandleRef pixd, HandleRef pixs, int val0, int val1);

        // Unpacking conversion from 1 bpp to 4 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To4Cmap")]
        internal static extern IntPtr pixConvert1To4Cmap(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To4")]
        internal static extern IntPtr pixConvert1To4(HandleRef pixd, HandleRef pixs, int val0, int val1);

        // Unpacking conversion from 1, 2 and 4 bpp to 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To8Cmap")]
        internal static extern IntPtr pixConvert1To8Cmap(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert1To8")]
        internal static extern IntPtr pixConvert1To8(HandleRef pixd, HandleRef pixs, byte val0, byte val1);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert2To8")]
        internal static extern IntPtr pixConvert2To8(HandleRef pixs, byte val0, byte val1, byte val2, byte val3, int cmapflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert4To8")]
        internal static extern IntPtr pixConvert4To8(HandleRef pixs, int cmapflag);

        // Unpacking conversion from 8 bpp to 16 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert8To16")]
        internal static extern IntPtr pixConvert8To16(HandleRef pixs, int leftshift);

        // Top-level conversion to 1 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo1")]
        internal static extern IntPtr pixConvertTo1(HandleRef pixs, int threshold);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo1BySampling")]
        internal static extern IntPtr pixConvertTo1BySampling(HandleRef pixs, int factor, int threshold);

        // Top-level conversion to 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8")]
        internal static extern IntPtr pixConvertTo8(HandleRef pixs, int cmapflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8BySampling")]
        internal static extern IntPtr pixConvertTo8BySampling(HandleRef pixs, int factor, int cmapflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8Color")]
        internal static extern IntPtr pixConvertTo8Color(HandleRef pixs, int dither);

        // Top-level conversion to 16 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo16")]
        internal static extern IntPtr pixConvertTo16(HandleRef pixs);

        // Top-level conversion to 32 bpp(RGB)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo32")]
        internal static extern IntPtr pixConvertTo32(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo32BySampling")]
        internal static extern IntPtr pixConvertTo32BySampling(HandleRef pixs, int factor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert8To32")]
        internal static extern IntPtr pixConvert8To32(HandleRef pixs);

        // Top-level conversion to 8 or 32 bpp, without colormap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertTo8Or32")]
        internal static extern IntPtr pixConvertTo8Or32(HandleRef pixs, int copyflag, int warnflag);

        // Conversion between 24 bpp and 32 bpp rgb
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert24To32")]
        internal static extern IntPtr pixConvert24To32(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To24")]
        internal static extern IntPtr pixConvert32To24(HandleRef pixs);

        // Conversion between 32 bpp(1 spp) and 16 or 8 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To16")]
        internal static extern IntPtr pixConvert32To16(HandleRef pixs, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvert32To8")]
        internal static extern IntPtr pixConvert32To8(HandleRef pixs, int type16, int type8);

        // Removal of alpha component by blending with white background
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveAlpha")]
        internal static extern IntPtr pixRemoveAlpha(HandleRef pixs);

        // Addition of alpha component to 1 bpp
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddAlphaTo1bpp")]
        internal static extern IntPtr pixAddAlphaTo1bpp(HandleRef pixd, HandleRef pixs);

        // Lossless depth conversion(unpacking)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertLossless")]
        internal static extern IntPtr pixConvertLossless(HandleRef pixs, int d);

        // Conversion for printing in PostScript
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertForPSWrap")]
        internal static extern IntPtr pixConvertForPSWrap(HandleRef pixs);

        // Scaling conversion to subpixel RGB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertToSubpixelRGB")]
        internal static extern IntPtr pixConvertToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertGrayToSubpixelRGB")]
        internal static extern IntPtr pixConvertGrayToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConvertColorToSubpixelRGB")]
        internal static extern IntPtr pixConvertColorToSubpixelRGB(HandleRef pixs, float scalex, float scaley, int order);

        // Setting neutral point for min/max boost conversion to gray
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_setNeutralBoostVal")]
        internal static extern void l_setNeutralBoostVal(int val);
        #endregion

        #region pixlabel.c
        // Label pixels by an index for connected component membership
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompTransform")]
        internal static extern IntPtr pixConnCompTransform(HandleRef pixs, int connect, int depth);

        // Label pixels by the area of their connected component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompAreaTransform")]
        internal static extern IntPtr pixConnCompAreaTransform(HandleRef pixs, int connect);

        // Label pixels to allow incremental computation of connected components
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompIncrInit")]
        internal static extern int pixConnCompIncrInit(HandleRef pixs, int conn, out IntPtr ppixd, out IntPtr pptaa, out int pncc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixConnCompIncrAdd")]
        internal static extern int pixConnCompIncrAdd(HandleRef pixs, HandleRef ptaa, out int pncc, float x, float y, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetSortedNeighborValues")]
        internal static extern int pixGetSortedNeighborValues(HandleRef pixs, int x, int y, int conn, out IntPtr pneigh, out int pnvals);

        // Label pixels with spatially-dependent color coding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocToColorTransform")]
        internal static extern IntPtr pixLocToColorTransform(HandleRef pixs);
        #endregion

        #region pixtiling.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingCreate")]
        internal static extern IntPtr pixTilingCreate(HandleRef pixs, int nx, int ny, int w, int h, int xoverlap, int yoverlap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingDestroy")]
        internal static extern void pixTilingDestroy(ref IntPtr ppt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetCount")]
        internal static extern int pixTilingGetCount(HandleRef pt, out int pnx, out int pny);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetSize")]
        internal static extern int pixTilingGetSize(HandleRef pt, out int pw, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingGetTile")]
        internal static extern IntPtr pixTilingGetTile(HandleRef pt, int i, int j);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingNoStripOnPaint")]
        internal static extern int pixTilingNoStripOnPaint(HandleRef pt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTilingPaintTile")]
        internal static extern int pixTilingPaintTile(HandleRef pixd, int i, int j, HandleRef pixs, HandleRef pt);
        #endregion

        #region pngio.c
        // Reading png through stream
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamPng")]
        internal static extern IntPtr pixReadStreamPng(IntPtr fp);

        // Reading png header
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderPng")]
        internal static extern int readHeaderPng([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pw, out int ph, out int pbps, out int pspp, out int piscmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderPng")]
        internal static extern int freadHeaderPng(IntPtr fp, out int pw, out int ph, out int pbps, out int pspp, out int piscmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemPng")]
        internal static extern int readHeaderMemPng(IntPtr data, IntPtr size, out int pw, out int ph, out int pbps, out int pspp, out int piscmap);

        // Reading png metadata
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetPngResolution")]
        internal static extern int fgetPngResolution(IntPtr fp, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "isPngInterlaced")]
        internal static extern int isPngInterlaced([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pinterlaced);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fgetPngColormapInfo")]
        internal static extern int fgetPngColormapInfo(IntPtr fp, out IntPtr pcmap, out int ptransparency);

        // Writing png through stream
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWritePng")]
        internal static extern int pixWritePng([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, float gamma);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPng")]
        internal static extern int pixWriteStreamPng(IntPtr fp, HandleRef pix, float gamma);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetZlibCompression")]
        internal static extern int pixSetZlibCompression(HandleRef pix, int compval);

        // Set flag for special read mode
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_pngSetReadStrip16To8")]
        internal static extern void l_pngSetReadStrip16To8(int flag);

        // Reading png from memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemPng")]
        internal static extern IntPtr pixReadMemPng(IntPtr filedata, IntPtr filesize);

        // Writing png to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPng")]
        internal static extern int pixWriteMemPng(out IntPtr pfiledata, IntPtr pfilesize, HandleRef pix, float gamma);
        #endregion

        #region pnmio.c
        // Stream interface
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamPnm")]
        internal static extern IntPtr pixReadStreamPnm(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderPnm")]
        internal static extern int readHeaderPnm([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderPnm")]
        internal static extern int freadHeaderPnm(IntPtr fp, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPnm")]
        internal static extern int pixWriteStreamPnm(IntPtr fp, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamAsciiPnm")]
        internal static extern int pixWriteStreamAsciiPnm(IntPtr fp, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPam")]
        internal static extern int pixWriteStreamPam(IntPtr fp, HandleRef pix);

        // Read/write to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemPnm")]
        internal static extern IntPtr pixReadMemPnm(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemPnm")]
        internal static extern int readHeaderMemPnm(IntPtr data, IntPtr size, out int pw, out int ph, out int pd, out int ptype, out int pbps, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPnm")]
        internal static extern int pixWriteMemPnm(out IntPtr pdata, IntPtr psize, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPam")]
        internal static extern int pixWriteMemPam(out IntPtr pdata, IntPtr psize, HandleRef pix);
        #endregion

        #region projective.c
        // Projective(4 pt) image transformation using a sampled (to nearest integer) transform on each dest point
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveSampledPta")]
        internal static extern IntPtr pixProjectiveSampledPta(HandleRef pixs, HandleRef ptad, HandleRef ptas, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveSampled")]
        internal static extern IntPtr pixProjectiveSampled(HandleRef pixs, IntPtr vc, int incolor);

        // Projective(4 pt) image transformation using interpolation (or area mapping) for anti-aliasing images that are 2, 4, or 8 bpp gray, or colormapped, or 32 bpp RGB
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePta")]
        internal static extern IntPtr pixProjectivePta(HandleRef pixs, HandleRef ptad, HandleRef ptas, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjective")]
        internal static extern IntPtr pixProjective(HandleRef pixs, IntPtr vc, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaColor")]
        internal static extern IntPtr pixProjectivePtaColor(HandleRef pixs, HandleRef ptad, HandleRef ptas, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveColor")]
        internal static extern IntPtr pixProjectiveColor(HandleRef pixs, IntPtr vc, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaGray")]
        internal static extern IntPtr pixProjectivePtaGray(HandleRef pixs, HandleRef ptad, HandleRef ptas, byte grayval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectiveGray")]
        internal static extern IntPtr pixProjectiveGray(HandleRef pixs, IntPtr vc, byte grayval);

        // Projective transform including alpha(blend) component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProjectivePtaWithAlpha")]
        internal static extern IntPtr pixProjectivePtaWithAlpha(HandleRef pixs, HandleRef ptad, HandleRef ptas, HandleRef pixg, float fract, int border);

        // Projective coordinate transformation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getProjectiveXformCoeffs")]
        internal static extern int getProjectiveXformCoeffs(HandleRef ptas, HandleRef ptad, out IntPtr pvc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "projectiveXformSampledPt")]
        internal static extern int projectiveXformSampledPt(IntPtr vc, int x, int y, out int pxp, out int pyp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "projectiveXformPt")]
        internal static extern int projectiveXformPt(IntPtr vc, int x, int y, out float pxp, out float pyp);
        #endregion

        #region psio1.c
        // Convert specified files to PS
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesToPS")]
        internal static extern int convertFilesToPS([MarshalAs(UnmanagedType.AnsiBStr)] string dirin, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertFilesToPS")]
        internal static extern int sarrayConvertFilesToPS(HandleRef sa, int res, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFilesFittedToPS")]
        internal static extern int convertFilesFittedToPS([MarshalAs(UnmanagedType.AnsiBStr)] string dirin, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, float xpts, float ypts, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertFilesFittedToPS")]
        internal static extern int sarrayConvertFilesFittedToPS(HandleRef sa, float xpts, float ypts, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeImageCompressedToPSFile")]
        internal static extern int writeImageCompressedToPSFile([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int res, out int pfirstfile, out int pindex);

        // Convert mixed text/image files to PS
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSegmentedPagesToPS")]
        internal static extern int convertSegmentedPagesToPS([MarshalAs(UnmanagedType.AnsiBStr)] string pagedir, [MarshalAs(UnmanagedType.AnsiBStr)] string pagestr, int page_numpre, [MarshalAs(UnmanagedType.AnsiBStr)] string maskdir, [MarshalAs(UnmanagedType.AnsiBStr)] string maskstr, int mask_numpre, int numpost, int maxnum, float textscale, float imagescale, int threshold, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteSegmentedPageToPS")]
        internal static extern int pixWriteSegmentedPageToPS(HandleRef pixs, HandleRef pixm, float textscale, float imagescale, int threshold, int pageno, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMixedToPS")]
        internal static extern int pixWriteMixedToPS(HandleRef pixb, HandleRef pixc, float scale, int pageno, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        // Convert any image file to PS for embedding
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertToPSEmbed")]
        internal static extern int convertToPSEmbed([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int level);

        // Write all images in a pixa out to PS
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteCompressedToPS")]
        internal static extern int pixaWriteCompressedToPS(HandleRef pixa, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, int res, int level);
        #endregion

        #region psio2.c
        // For uncompressed images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWritePSEmbed")]
        internal static extern int pixWritePSEmbed([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamPS")]
        internal static extern int pixWriteStreamPS(IntPtr fp, HandleRef pix, HandleRef box, int res, float scale);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStringPS")]
        internal static extern IntPtr pixWriteStringPS(HandleRef pixs, HandleRef box, int res, float scale);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateUncompressedPS")]
        internal static extern IntPtr generateUncompressedPS([MarshalAs(UnmanagedType.AnsiBStr)] string hexdata, int w, int h, int d, int psbpl, int bps, float xpt, float ypt, float wpt, float hpt, int boxflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getScaledParametersPS")]
        internal static extern void getScaledParametersPS(HandleRef box, int wpix, int hpix, int res, float scale, out float pxpt, out float pypt, out float pwpt, out float phpt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertByteToHexAscii")]
        internal static extern void convertByteToHexAscii(byte byteval, [MarshalAs(UnmanagedType.AnsiBStr)] string pnib1, [MarshalAs(UnmanagedType.AnsiBStr)] string pnib2);

        // For jpeg compressed images(use dct compression)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPSEmbed")]
        internal static extern int convertJpegToPSEmbed([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPS")]
        internal static extern int convertJpegToPS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, [MarshalAs(UnmanagedType.AnsiBStr)] string operation, int x, int y, int res, float scale, int pageno, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertJpegToPSString")]
        internal static extern int convertJpegToPSString([MarshalAs(UnmanagedType.AnsiBStr)] string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateJpegPS")]
        internal static extern IntPtr generateJpegPS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, HandleRef cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage);

        // For g4 fax compressed images(use ccitt g4 compression)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPSEmbed")]
        internal static extern int convertG4ToPSEmbed([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPS")]
        internal static extern int convertG4ToPS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, [MarshalAs(UnmanagedType.AnsiBStr)] string operation, int x, int y, int res, float scale, int pageno, int maskflag, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertG4ToPSString")]
        internal static extern int convertG4ToPSString([MarshalAs(UnmanagedType.AnsiBStr)] string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int maskflag, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateG4PS")]
        internal static extern IntPtr generateG4PS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, HandleRef cid, float xpt, float ypt, float wpt, float hpt, int maskflag, int pageno, int endpage);

        // For multipage tiff images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertTiffMultipageToPS")]
        internal static extern int convertTiffMultipageToPS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, float fillfract);

        // For flate(gzip) compressed images(e.g., png)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPSEmbed")]
        internal static extern int convertFlateToPSEmbed([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPS")]
        internal static extern int convertFlateToPS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout, [MarshalAs(UnmanagedType.AnsiBStr)] string operation, int x, int y, int res, float scale, int pageno, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertFlateToPSString")]
        internal static extern int convertFlateToPSString([MarshalAs(UnmanagedType.AnsiBStr)] string filein, out IntPtr poutstr, IntPtr pnbytes, int x, int y, int res, float scale, int pageno, int endpage);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "generateFlatePS")]
        internal static extern IntPtr generateFlatePS([MarshalAs(UnmanagedType.AnsiBStr)] string filein, HandleRef cid, float xpt, float ypt, float wpt, float hpt, int pageno, int endpage);

        // Write to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemPS")]
        internal static extern int pixWriteMemPS(out IntPtr pdata, IntPtr psize, HandleRef pix, HandleRef box, int res, float scale);

        // Converting resolution
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getResLetterPage")]
        internal static extern int getResLetterPage(int w, int h, float fillfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getResA4Page")]
        internal static extern int getResA4Page(int w, int h, float fillfract);

        // Setting flag for writing bounding box hint
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_psWriteBoundingBox")]
        internal static extern void l_psWriteBoundingBox(int flag);
        #endregion

        #region ptabasic.c
        // Pta creation, destruction, copy, clone, empty
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCreate")]
        internal static extern IntPtr ptaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCreateFromNuma")]
        internal static extern IntPtr ptaCreateFromNuma(HandleRef nax, HandleRef nay);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaDestroy")]
        internal static extern void ptaDestroy(ref IntPtr ppta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCopy")]
        internal static extern IntPtr ptaCopy(HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCopyRange")]
        internal static extern IntPtr ptaCopyRange(HandleRef ptas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaClone")]
        internal static extern IntPtr ptaClone(HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaEmpty")]
        internal static extern int ptaEmpty(HandleRef pta);

        // Pta array extension
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaAddPt")]
        internal static extern int ptaAddPt(HandleRef pta, float x, float y);

        // Pta insertion and removal
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaInsertPt")]
        internal static extern int ptaInsertPt(HandleRef pta, int index, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemovePt")]
        internal static extern int ptaRemovePt(HandleRef pta, int index);

        // Pta accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetRefcount")]
        internal static extern int ptaGetRefcount(HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaChangeRefcount")]
        internal static extern int ptaChangeRefcount(HandleRef pta, int delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetCount")]
        internal static extern int ptaGetCount(HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetPt")]
        internal static extern int ptaGetPt(HandleRef pta, int index, out float px, out float py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetIPt")]
        internal static extern int ptaGetIPt(HandleRef pta, int index, out int px, out int py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSetPt")]
        internal static extern int ptaSetPt(HandleRef pta, int index, float x, float y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetArrays")]
        internal static extern int ptaGetArrays(HandleRef pta, out IntPtr pnax, out IntPtr pnay);

        // Pta serialized for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRead")]
        internal static extern IntPtr ptaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReadStream")]
        internal static extern IntPtr ptaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReadMem")]
        internal static extern IntPtr ptaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWrite")]
        internal static extern int ptaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pta, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWriteStream")]
        internal static extern int ptaWriteStream(IntPtr fp, HandleRef pta, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaWriteMem")]
        internal static extern int ptaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef pta, int type);

        // Ptaa creation, destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaCreate")]
        internal static extern IntPtr ptaaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaDestroy")]
        internal static extern void ptaaDestroy(ref IntPtr pptaa);

        // Ptaa array extension
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaAddPta")]
        internal static extern int ptaaAddPta(HandleRef ptaa, HandleRef pta, int copyflag);

        // Ptaa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetCount")]
        internal static extern int ptaaGetCount(HandleRef ptaa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetPta")]
        internal static extern IntPtr ptaaGetPta(HandleRef ptaa, int index, int accessflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetPt")]
        internal static extern int ptaaGetPt(HandleRef ptaa, int ipta, int jpt, out float px, out float py);

        // Ptaa array modifiers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaInitFull")]
        internal static extern int ptaaInitFull(HandleRef ptaa, HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReplacePta")]
        internal static extern int ptaaReplacePta(HandleRef ptaa, int index, HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaAddPt")]
        internal static extern int ptaaAddPt(HandleRef ptaa, int ipta, float x, float y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaTruncate")]
        internal static extern int ptaaTruncate(HandleRef ptaa);

        // Ptaa serialized for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaRead")]
        internal static extern IntPtr ptaaRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReadStream")]
        internal static extern IntPtr ptaaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaReadMem")]
        internal static extern IntPtr ptaaReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWrite")]
        internal static extern int ptaaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef ptaa, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWriteStream")]
        internal static extern int ptaaWriteStream(IntPtr fp, HandleRef ptaa, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaWriteMem")]
        internal static extern int ptaaWriteMem(out IntPtr pdata, IntPtr psize, HandleRef ptaa, int type);
        #endregion

        #region ptafunc1.c
        // Simple rearrangements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSubsample")]
        internal static extern IntPtr ptaSubsample(HandleRef ptas, int subfactor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaJoin")]
        internal static extern int ptaJoin(HandleRef ptad, HandleRef ptas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaJoin")]
        internal static extern int ptaaJoin(HandleRef ptaad, HandleRef ptaas, int istart, int iend);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReverse")]
        internal static extern IntPtr ptaReverse(HandleRef ptas, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTranspose")]
        internal static extern IntPtr ptaTranspose(HandleRef ptas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCyclicPerm")]
        internal static extern IntPtr ptaCyclicPerm(HandleRef ptas, int xs, int ys);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSelectRange")]
        internal static extern IntPtr ptaSelectRange(HandleRef ptas, int first, int last);

        // Geometric
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetBoundingRegion")]
        internal static extern IntPtr ptaGetBoundingRegion(HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetRange")]
        internal static extern int ptaGetRange(HandleRef pta, out float pminx, out float pmaxx, out float pminy, out float pmaxy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetInsideBox")]
        internal static extern IntPtr ptaGetInsideBox(HandleRef ptas, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindCornerPixels")]
        internal static extern IntPtr pixFindCornerPixels(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaContainsPt")]
        internal static extern int ptaContainsPt(HandleRef pta, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTestIntersection")]
        internal static extern int ptaTestIntersection(HandleRef pta1, HandleRef pta2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaTransform")]
        internal static extern IntPtr ptaTransform(HandleRef ptas, int shiftx, int shifty, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaPtInsidePolygon")]
        internal static extern int ptaPtInsidePolygon(HandleRef pta, float x, float y, out int pinside);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_angleBetweenVectors")]
        internal static extern float l_angleBetweenVectors(float x1, float y1, float x2, float y2);

        // Min/max and filtering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetMinMax")]
        internal static extern int ptaGetMinMax(HandleRef pta, out float pxmin, out float pymin, out float pxmax, out float pymax);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSelectByValue")]
        internal static extern IntPtr ptaSelectByValue(HandleRef ptas, float xth, float yth, int type, int relation);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaCropToMask")]
        internal static extern IntPtr ptaCropToMask(HandleRef ptas, HandleRef pixm);

        // Least Squares Fit
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetLinearLSF")]
        internal static extern int ptaGetLinearLSF(HandleRef pta, out float pa, out float pb, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetQuadraticLSF")]
        internal static extern int ptaGetQuadraticLSF(HandleRef pta, out float pa, out float pb, out float pc, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetCubicLSF")]
        internal static extern int ptaGetCubicLSF(HandleRef pta, out float pa, out float pb, out float pc, out float pd, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetQuarticLSF")]
        internal static extern int ptaGetQuarticLSF(HandleRef pta, out float pa, out float pb, out float pc, out float pd, out float pe, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaNoisyLinearLSF")]
        internal static extern int ptaNoisyLinearLSF(HandleRef pta, float factor, out IntPtr pptad, out float pa, out float pb, out float pmederr, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaNoisyQuadraticLSF")]
        internal static extern int ptaNoisyQuadraticLSF(HandleRef pta, float factor, out IntPtr pptad, out float pa, out float pb, out float pc, out float pmederr, out IntPtr pnafit);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyLinearFit")]
        internal static extern int applyLinearFit(float a, float b, float x, out float py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyQuadraticFit")]
        internal static extern int applyQuadraticFit(float a, float b, float c, float x, out float py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyCubicFit")]
        internal static extern int applyCubicFit(float a, float b, float c, float d, float x, out float py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "applyQuarticFit")]
        internal static extern int applyQuarticFit(float a, float b, float c, float d, float e, float x, out float py);

        // Interconversions with Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixPlotAlongPta")]
        internal static extern int pixPlotAlongPta(HandleRef pixs, HandleRef pta, int outformat, [MarshalAs(UnmanagedType.AnsiBStr)] string title);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetPixelsFromPix")]
        internal static extern IntPtr ptaGetPixelsFromPix(HandleRef pixs, HandleRef box);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateFromPta")]
        internal static extern IntPtr pixGenerateFromPta(HandleRef pta, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetBoundaryPixels")]
        internal static extern IntPtr ptaGetBoundaryPixels(HandleRef pixs, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaGetBoundaryPixels")]
        internal static extern IntPtr ptaaGetBoundaryPixels(HandleRef pixs, int type, int connectivity, out IntPtr pboxa, out IntPtr ppixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaIndexLabeledPixels")]
        internal static extern IntPtr ptaaIndexLabeledPixels(HandleRef pixs, out int pncc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetNeighborPixLocs")]
        internal static extern IntPtr ptaGetNeighborPixLocs(HandleRef pixs, int x, int y, int conn);

        // Interconversion with Numa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToPta1")]
        internal static extern IntPtr numaConvertToPta1(HandleRef na);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaConvertToPta2")]
        internal static extern IntPtr numaConvertToPta2(HandleRef nax, HandleRef nay);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaConvertToNuma")]
        internal static extern int ptaConvertToNuma(HandleRef pta, out IntPtr pnax, out IntPtr pnay);

        // Display Pta and Ptaa
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPta")]
        internal static extern IntPtr pixDisplayPta(HandleRef pixd, HandleRef pixs, HandleRef pta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaaPattern")]
        internal static extern IntPtr pixDisplayPtaaPattern(HandleRef pixd, HandleRef pixs, HandleRef ptaa, HandleRef pixp, int cx, int cy);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaPattern")]
        internal static extern IntPtr pixDisplayPtaPattern(HandleRef pixd, HandleRef pixs, HandleRef pta, HandleRef pixp, int cx, int cy, uint color);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaReplicatePattern")]
        internal static extern IntPtr ptaReplicatePattern(HandleRef ptas, HandleRef pixp, HandleRef ptap, int cx, int cy, int w, int h);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayPtaa")]
        internal static extern IntPtr pixDisplayPtaa(HandleRef pixs, HandleRef ptaa);
        #endregion

        #region ptafunc2.c
        // Sorting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSort")]
        internal static extern IntPtr ptaSort(HandleRef ptas, int sorttype, int sortorder, out IntPtr pnaindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetSortIndex")]
        internal static extern int ptaGetSortIndex(HandleRef ptas, int sorttype, int sortorder, out IntPtr pnaindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaSortByIndex")]
        internal static extern IntPtr ptaSortByIndex(HandleRef ptas, HandleRef naindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaaSortByIndex")]
        internal static extern IntPtr ptaaSortByIndex(HandleRef ptaas, HandleRef naindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaGetRankValue")]
        internal static extern int ptaGetRankValue(HandleRef pta, float fract, HandleRef ptasort, int sorttype, out float pval);

        // Set operations using aset (rbtree)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaUnionByAset")]
        internal static extern IntPtr ptaUnionByAset(HandleRef pta1, HandleRef pta2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemoveDupsByAset")]
        internal static extern IntPtr ptaRemoveDupsByAset(HandleRef ptas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaIntersectionByAset")]
        internal static extern IntPtr ptaIntersectionByAset(HandleRef pta1, HandleRef pta2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromPta")]
        internal static extern IntPtr l_asetCreateFromPta(HandleRef pta);

        // Set operations using hashing (dnahash)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaUnionByHash")]
        internal static extern IntPtr ptaUnionByHash(HandleRef pta1, HandleRef pta2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaRemoveDupsByHash")]
        internal static extern int ptaRemoveDupsByHash(HandleRef ptas, out IntPtr pptad, out IntPtr pdahash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaIntersectionByHash")]
        internal static extern IntPtr ptaIntersectionByHash(HandleRef pta1, HandleRef pta2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptaFindPtByHash")]
        internal static extern int ptaFindPtByHash(HandleRef pta, HandleRef dahash, int x, int y, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromPta")]
        internal static extern IntPtr l_dnaHashCreateFromPta(HandleRef pta);
        #endregion

        #region ptra.c
        // Ptra creation and destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraCreate")]
        internal static extern IntPtr ptraCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraDestroy")]
        internal static extern void ptraDestroy(ref IntPtr ppa, int freeflag, int warnflag);

        // Add/insert/remove/replace generic ptr object
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraAdd")]
        internal static extern int ptraAdd(HandleRef pa, IntPtr item);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraInsert")]
        internal static extern int ptraInsert(HandleRef pa, int index, IntPtr item, int shiftflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraRemove")]
        internal static extern IntPtr ptraRemove(HandleRef pa, int index, int flag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraRemoveLast")]
        internal static extern IntPtr ptraRemoveLast(HandleRef pa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraReplace")]
        internal static extern IntPtr ptraReplace(HandleRef pa, int index, IntPtr item, int freeflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraSwap")]
        internal static extern int ptraSwap(HandleRef pa, int index1, int index2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraCompactArray")]
        internal static extern int ptraCompactArray(HandleRef pa);

        // Other array operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraReverse")]
        internal static extern int ptraReverse(HandleRef pa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraJoin")]
        internal static extern int ptraJoin(HandleRef pa1, HandleRef pa2);

        // Simple Ptra accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetMaxIndex")]
        internal static extern int ptraGetMaxIndex(HandleRef pa, out int pmaxindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetActualCount")]
        internal static extern int ptraGetActualCount(HandleRef pa, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraGetPtrToItem")]
        internal static extern IntPtr ptraGetPtrToItem(HandleRef pa, int index);

        // Ptraa creation and destruction
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaCreate")]
        internal static extern IntPtr ptraaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaDestroy")]
        internal static extern void ptraaDestroy(ref IntPtr ppaa, int freeflag, int warnflag);

        // Ptraa accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaGetSize")]
        internal static extern int ptraaGetSize(HandleRef paa, out int psize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaInsertPtra")]
        internal static extern int ptraaInsertPtra(HandleRef paa, int index, HandleRef pa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaGetPtra")]
        internal static extern IntPtr ptraaGetPtra(HandleRef paa, int index, int accessflag);

        // Ptraa conversion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ptraaFlattenToPtra")]
        internal static extern IntPtr ptraaFlattenToPtra(HandleRef paa);
        #endregion

        #region quadtree.c
        // Top level quadtree linear statistics
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadtreeMean")]
        internal static extern int pixQuadtreeMean(HandleRef pixs, int nlevels, HandleRef pix_ma, out IntPtr pfpixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadtreeVariance")]
        internal static extern int pixQuadtreeVariance(HandleRef pixs, int nlevels, HandleRef pix_ma, HandleRef dpix_msa, out IntPtr pfpixa_v, out IntPtr pfpixa_rv);

        // Statistics in an arbitrary rectangle
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMeanInRectangle")]
        internal static extern int pixMeanInRectangle(HandleRef pixs, HandleRef box, HandleRef pixma, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVarianceInRectangle")]
        internal static extern int pixVarianceInRectangle(HandleRef pixs, HandleRef box, HandleRef pix_ma, HandleRef dpix_msa, out float pvar, out float prvar);

        // Quadtree regions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "boxaaQuadtreeRegions")]
        internal static extern IntPtr boxaaQuadtreeRegions(int w, int h, int nlevels);

        // Quadtree access
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeGetParent")]
        internal static extern int quadtreeGetParent(HandleRef fpixa, int level, int x, int y, out float pval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeGetChildren")]
        internal static extern int quadtreeGetChildren(HandleRef fpixa, int level, int x, int y, out float pval00, out float pval10, out float pval01, out float pval11);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "quadtreeMaxLevels")]
        internal static extern int quadtreeMaxLevels(int w, int h);

        // Display quadtree
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fpixaDisplayQuadtree")]
        internal static extern IntPtr fpixaDisplayQuadtree(HandleRef fpixa, int factor, int fontsize);
        #endregion

        #region queue.c
        // Create/Destroy L_Queue
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueCreate")]
        internal static extern IntPtr lqueueCreate(int nalloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueDestroy")]
        internal static extern void lqueueDestroy(ref IntPtr plq, int freeflag);

        // Operations to add/remove to/from a L_Queue
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueAdd")]
        internal static extern int lqueueAdd(HandleRef lq, IntPtr item);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueRemove")]
        internal static extern IntPtr lqueueRemove(HandleRef lq);

        // Accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueueGetCount")]
        internal static extern int lqueueGetCount(HandleRef lq);

        // Debug output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lqueuePrint")]
        internal static extern int lqueuePrint(IntPtr fp, HandleRef lq);
        #endregion

        #region rank.c
        // Rank filter(gray and rgb)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilter")]
        internal static extern IntPtr pixRankFilter(HandleRef pixs, int wf, int hf, float rank);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterRGB")]
        internal static extern IntPtr pixRankFilterRGB(HandleRef pixs, int wf, int hf, float rank);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterGray")]
        internal static extern IntPtr pixRankFilterGray(HandleRef pixs, int wf, int hf, float rank);

        // Median filter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixMedianFilter")]
        internal static extern IntPtr pixMedianFilter(HandleRef pixs, int wf, int hf);

        // Rank filter(accelerated with downscaling)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRankFilterWithScaling")]
        internal static extern IntPtr pixRankFilterWithScaling(HandleRef pixs, int wf, int hf, float rank, float scalefactor);
        #endregion

        #region rbtree.c
        // Interface to red-black tree
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeCreate")]
        internal static extern IntPtr l_rbtreeCreate(int keytype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeLookup")]
        internal static extern IntPtr l_rbtreeLookup(HandleRef t, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeInsert")]
        internal static extern void l_rbtreeInsert(HandleRef t, HandleRef key, HandleRef value);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeDelete")]
        internal static extern void l_rbtreeDelete(HandleRef t, HandleRef key);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeDestroy")]
        internal static extern void l_rbtreeDestroy(ref IntPtr pt);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeGetFirst")]
        internal static extern IntPtr l_rbtreeGetFirst(HandleRef t);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeGetNext")]
        internal static extern IntPtr l_rbtreeGetNext(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeGetLast")]
        internal static extern IntPtr l_rbtreeGetLast(HandleRef t);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeGetPrev")]
        internal static extern IntPtr l_rbtreeGetPrev(HandleRef n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreeGetCount")]
        internal static extern int l_rbtreeGetCount(HandleRef t);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_rbtreePrint")]
        internal static extern void l_rbtreePrint(IntPtr fp, HandleRef t);
        #endregion

        #region readbarcode.c
        // Top level
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixProcessBarcodes")]
        internal static extern IntPtr pixProcessBarcodes(HandleRef pixs, int format, int method, out IntPtr psaw, int debugflag);

        // Next levels
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodes")]
        internal static extern IntPtr pixExtractBarcodes(HandleRef pixs, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadBarcodes")]
        internal static extern IntPtr pixReadBarcodes(HandleRef pixa, int format, int method, out IntPtr psaw, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadBarcodeWidths")]
        internal static extern IntPtr pixReadBarcodeWidths(HandleRef pixs, int method, int debugflag);

        // Location
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocateBarcodes")]
        internal static extern IntPtr pixLocateBarcodes(HandleRef pixs, int thresh, out IntPtr ppixb, out IntPtr ppixm);

        // Extraction and deskew
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewBarcode")]
        internal static extern IntPtr pixDeskewBarcode(HandleRef pixs, HandleRef pixb, HandleRef box, int margin, int threshold, out float pangle, out float pconf);

        // Process to get line widths
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeWidths1")]
        internal static extern IntPtr pixExtractBarcodeWidths1(HandleRef pixs, float thresh, float binfract, out IntPtr pnaehist, out IntPtr pnaohist, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeWidths2")]
        internal static extern IntPtr pixExtractBarcodeWidths2(HandleRef pixs, float thresh, out float pwidth, out IntPtr pnac, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBarcodeCrossings")]
        internal static extern IntPtr pixExtractBarcodeCrossings(HandleRef pixs, float thresh, int debugflag);

        // Signal processing for barcode widths
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaQuantizeCrossingsByWidth")]
        internal static extern IntPtr numaQuantizeCrossingsByWidth(HandleRef nas, float binfract, out IntPtr pnaehist, out IntPtr pnaohist, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "numaQuantizeCrossingsByWindow")]
        internal static extern IntPtr numaQuantizeCrossingsByWindow(HandleRef nas, float ratio, out float pwidth, out float pfirstloc, out IntPtr pnac, int debugflag);
        #endregion

        #region readfile.c - DONE
        // Top-level functions for reading images from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadFiles")]
        internal static extern IntPtr pixaReadFiles([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadFilesSA")]
        internal static extern IntPtr pixaReadFilesSA(HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRead")]
        internal static extern IntPtr pixRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadWithHint")]
        internal static extern IntPtr pixReadWithHint([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int hint);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadIndexed")]
        internal static extern IntPtr pixReadIndexed(HandleRef sa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStream")]
        internal static extern IntPtr pixReadStream(IntPtr fp, int hint);

        // Read header information from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadHeader")]
        internal static extern bool pixReadHeader([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out ImageFileFormatTypes pformat, out int pw, out int ph, out int pbps, out int pspp, out bool piscmap);

        // Format finders
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormat")]
        internal static extern bool findFileFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out ImageFileFormatTypes pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormatStream")]
        internal static extern bool findFileFormatStream(IntPtr fp, out ImageFileFormatTypes pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findFileFormatBuffer")]
        internal static extern bool findFileFormatBuffer(IntPtr buf, out ImageFileFormatTypes pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileFormatIsTiff")]
        internal static extern bool fileFormatIsTiff(IntPtr fp);

        // Read from memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMem")]
        internal static extern IntPtr pixReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadHeaderMem")]
        internal static extern bool pixReadHeaderMem(IntPtr data, IntPtr size, out ImageFileFormatTypes pformat, out int pw, out int ph, out int pbps, out int pspp, out bool piscmap);

        // Output image file information
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeImageFileInfo")]
        internal static extern bool writeImageFileInfo([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr fpout, bool headeronly);

        // Test function for I/O with different formats
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "ioFormatTest")]
        internal static extern bool ioFormatTest([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        #endregion

        #region recogbasic.c
        // Recog creation, destruction and access
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCreateFromRecog")]
        internal static extern IntPtr recogCreateFromRecog(HandleRef recs, int scalew, int scaleh, int linew, int threshold, int maxyshift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCreateFromPixa")]
        internal static extern IntPtr recogCreateFromPixa(HandleRef pixa, int scalew, int scaleh, int linew, int threshold, int maxyshift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCreateFromPixaNoFinish")]
        internal static extern IntPtr recogCreateFromPixaNoFinish(HandleRef pixa, int scalew, int scaleh, int linew, int threshold, int maxyshift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCreate")]
        internal static extern IntPtr recogCreate(int scalew, int scaleh, int linew, int threshold, int maxyshift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogDestroy")]
        internal static extern void recogDestroy(ref IntPtr precog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogGetCount")]
        internal static extern int recogGetCount(HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogSetParams")]
        internal static extern int recogSetParams(HandleRef recog, int type, int min_nopad, float max_wh_ratio, float max_ht_ratio);

        // Character/index lookup
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogGetClassIndex")]
        internal static extern int recogGetClassIndex(HandleRef recog, int val, [MarshalAs(UnmanagedType.AnsiBStr)] string text, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogStringToIndex")]
        internal static extern int recogStringToIndex(HandleRef recog, [MarshalAs(UnmanagedType.AnsiBStr)] string text, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogGetClassString")]
        internal static extern int recogGetClassString(HandleRef recog, int index, out IntPtr pcharstr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_convertCharstrToInt")]
        internal static extern int l_convertCharstrToInt([MarshalAs(UnmanagedType.AnsiBStr)] string str, out int pval);

        // Serialization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogRead")]
        internal static extern IntPtr recogRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogReadStream")]
        internal static extern IntPtr recogReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogReadMem")]
        internal static extern IntPtr recogReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogWrite")]
        internal static extern int recogWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogWriteStream")]
        internal static extern int recogWriteStream(IntPtr fp, HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogWriteMem")]
        internal static extern int recogWriteMem(out IntPtr pdata, IntPtr psize, HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogExtractPixa")]
        internal static extern IntPtr recogExtractPixa(HandleRef recog);
        #endregion

        #region recogdid.c
        // Top-level identification
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogDecode")]
        internal static extern IntPtr recogDecode(HandleRef recog, HandleRef pixs, int nlevels, out IntPtr ppixdb);

        // Create/destroy temporary DID data
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCreateDid")]
        internal static extern int recogCreateDid(HandleRef recog, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogDestroyDid")]
        internal static extern int recogDestroyDid(HandleRef recog);

        // Various helpers
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogDidExists")]
        internal static extern int recogDidExists(HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogGetDid")]
        internal static extern IntPtr recogGetDid(HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogSetChannelParams")]
        internal static extern int recogSetChannelParams(HandleRef recog, int nlevels);
        #endregion

        #region recogident.c
        // Top-level identification
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogIdentifyMultiple")]
        internal static extern int recogIdentifyMultiple(HandleRef recog, HandleRef pixs, int minh, int skipsplit, out IntPtr pboxa, out IntPtr ppixa, out IntPtr ppixdb, int debugsplit);

        // Segmentation and noise removal
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogSplitIntoCharacters")]
        internal static extern int recogSplitIntoCharacters(HandleRef recog, HandleRef pixs, int minh, int skipsplit, out IntPtr pboxa, out IntPtr ppixa, int debug);

        // Greedy character splitting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCorrelationBestRow")]
        internal static extern int recogCorrelationBestRow(HandleRef recog, HandleRef pixs, out IntPtr pboxa, out IntPtr pnascore, out IntPtr pnaindex, out IntPtr psachar, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogCorrelationBestChar")]
        internal static extern int recogCorrelationBestChar(HandleRef recog, HandleRef pixs, out IntPtr pbox, out float pscore, out int pindex, out IntPtr pcharstr, out IntPtr ppixdb);

        // Low-level identification of single characters
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogIdentifyPixa")]
        internal static extern int recogIdentifyPixa(HandleRef recog, HandleRef pixa, out IntPtr ppixdb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogIdentifyPix")]
        internal static extern int recogIdentifyPix(HandleRef recog, HandleRef pixs, out IntPtr ppixdb);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogSkipIdentify")]
        internal static extern int recogSkipIdentify(HandleRef recog);

        // Operations for handling identification results
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rchaDestroy")]
        internal static extern void rchaDestroy(ref IntPtr prcha);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rchDestroy")]
        internal static extern void rchDestroy(ref IntPtr prch);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rchaExtract")]
        internal static extern int rchaExtract(HandleRef rcha, out IntPtr pnaindex, out IntPtr pnascore, out IntPtr psatext, out IntPtr pnasample, out IntPtr pnaxloc, out IntPtr pnayloc, out IntPtr pnawidth);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rchExtract")]
        internal static extern int rchExtract(HandleRef rch, out int pindex, out float pscore, out IntPtr ptext, out int psample, out int pxloc, out int pyloc, out int pwidth);

        // Preprocessing and filtering
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogProcessToIdentify")]
        internal static extern IntPtr recogProcessToIdentify(HandleRef recog, HandleRef pixs, int pad);

        // Postprocessing
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogExtractNumbers")]
        internal static extern IntPtr recogExtractNumbers(HandleRef recog, HandleRef boxas, float scorethresh, int spacethresh, out IntPtr pbaa, out IntPtr pnaa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "showExtractNumbers")]
        internal static extern IntPtr showExtractNumbers(HandleRef pixs, HandleRef sa, HandleRef baa, HandleRef naa, out IntPtr ppixdb);
        #endregion

        #region recogtrain.c
        // Training on labeled data
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogTrainLabeled")]
        internal static extern int recogTrainLabeled(HandleRef recog, HandleRef pixs, HandleRef box, [MarshalAs(UnmanagedType.AnsiBStr)] string text, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogProcessLabeled")]
        internal static extern int recogProcessLabeled(HandleRef recog, HandleRef pixs, HandleRef box, [MarshalAs(UnmanagedType.AnsiBStr)] string text, out IntPtr ppix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogAddSample")]
        internal static extern int recogAddSample(HandleRef recog, HandleRef pix, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogModifyTemplate")]
        internal static extern IntPtr recogModifyTemplate(HandleRef recog, HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogAverageSamples")]
        internal static extern int recogAverageSamples(IntPtr precog, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAccumulateSamples")]
        internal static extern int pixaAccumulateSamples(HandleRef pixa, HandleRef pta, out IntPtr ppixd, out float px, out float py);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogTrainingFinished")]
        internal static extern int recogTrainingFinished(IntPtr precog, int modifyflag, int minsize, float minfract);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogFilterPixaBySize")]
        internal static extern IntPtr recogFilterPixaBySize(HandleRef pixas, int setsize, int maxkeep, float max_ht_ratio, out IntPtr pna);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogSortPixaByClass")]
        internal static extern IntPtr recogSortPixaByClass(HandleRef pixa, int setsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogRemoveOutliers1")]
        internal static extern int recogRemoveOutliers1(IntPtr precog, float minscore, int mintarget, int minsize, out IntPtr ppixsave, out IntPtr ppixrem);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemoveOutliers1")]
        internal static extern IntPtr pixaRemoveOutliers1(HandleRef pixas, float minscore, int mintarget, int minsize, out IntPtr ppixsave, out IntPtr ppixrem);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogRemoveOutliers2")]
        internal static extern int recogRemoveOutliers2(IntPtr precog, float minscore, int minsize, out IntPtr ppixsave, out IntPtr ppixrem);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaRemoveOutliers2")]
        internal static extern IntPtr pixaRemoveOutliers2(HandleRef pixas, float minscore, int minsize, out IntPtr ppixsave, out IntPtr ppixrem);

        // Training on unlabeled data
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogTrainFromBoot")]
        internal static extern IntPtr recogTrainFromBoot(HandleRef recogboot, HandleRef pixas, float minscore, int threshold, int debug);

        // Padding the digit training set
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogPadDigitTrainingSet")]
        internal static extern int recogPadDigitTrainingSet(IntPtr precog, int scaleh, int linew);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogIsPaddingNeeded")]
        internal static extern int recogIsPaddingNeeded(HandleRef recog, out IntPtr psa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogAddDigitPadTemplates")]
        internal static extern IntPtr recogAddDigitPadTemplates(HandleRef recog, HandleRef sa);

        // Making a boot digit recognizer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogMakeBootDigitRecog")]
        internal static extern IntPtr recogMakeBootDigitRecog(int scaleh, int linew, int maxyshift, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogMakeBootDigitTemplates")]
        internal static extern IntPtr recogMakeBootDigitTemplates(int debug);

        // Debugging
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogShowContent")]
        internal static extern int recogShowContent(IntPtr fp, HandleRef recog, int index, int display);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogDebugAverages")]
        internal static extern int recogDebugAverages(IntPtr precog, int debug);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogShowAverageTemplates")]
        internal static extern int recogShowAverageTemplates(HandleRef recog);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogShowMatchesInRange")]
        internal static extern int recogShowMatchesInRange(HandleRef recog, HandleRef pixa, float minscore, float maxscore, int display);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "recogShowMatch")]
        internal static extern IntPtr recogShowMatch(HandleRef recog, HandleRef pix1, HandleRef pix2, HandleRef box, int index, float score);

        #endregion

        #region regutils.c
        // Regression test utilities
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestSetup")]
        //internal static extern int regTestSetup(int argc, IntPtr argv, out IntPtr prp);
        internal static extern int regTestSetup(int argc, string[] argv, out IntPtr prp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCleanup")]
        internal static extern int regTestCleanup(HandleRef rp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCompareValues")]
        internal static extern int regTestCompareValues(HandleRef rp, float val1, float val2, float delta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCompareStrings")]
        internal static extern int regTestCompareStrings(HandleRef rp, IntPtr string1, IntPtr bytes1, IntPtr string2, IntPtr bytes2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestComparePix")]
        internal static extern int regTestComparePix(HandleRef rp, HandleRef pix1, HandleRef pix2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCompareSimilarPix")]
        internal static extern int regTestCompareSimilarPix(HandleRef rp, HandleRef pix1, HandleRef pix2, int mindiff, float maxfract, int printstats);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCheckFile")]
        internal static extern int regTestCheckFile(HandleRef rp, [MarshalAs(UnmanagedType.AnsiBStr)] string localname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestCompareFiles")]
        internal static extern int regTestCompareFiles(HandleRef rp, int index1, int index2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestWritePixAndCheck")]
        internal static extern int regTestWritePixAndCheck(HandleRef rp, HandleRef pix, int format);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "regTestGenLocalFilename")]
        internal static extern IntPtr regTestGenLocalFilename(HandleRef rp, int index, int format);
        #endregion

        #region rop.c
        // General rasterop
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasterop")]
        internal static extern int pixRasterop(HandleRef pixd, int dx, int dy, int dw, int dh, int op, HandleRef pixs, int sx, int sy);

        // In-place full band translation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropVip")]
        internal static extern int pixRasteropVip(HandleRef pixd, int bx, int bw, int vshift, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropHip")]
        internal static extern int pixRasteropHip(HandleRef pixd, int by, int bh, int hshift, int incolor);

        // Full image translation(general and in-place)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixTranslate")]
        internal static extern IntPtr pixTranslate(HandleRef pixd, HandleRef pixs, int hshift, int vshift, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropIP")]
        internal static extern int pixRasteropIP(HandleRef pixd, int hshift, int vshift, int incolor);

        // Full image rasterop with no translation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRasteropFullImage")]
        internal static extern int pixRasteropFullImage(HandleRef pixd, HandleRef pixs, int op);
        #endregion

        #region ropiplow.c
        // Low level in-place full height vertical block transfer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropVipLow")]
        internal static extern void rasteropVipLow(IntPtr data, int pixw, int pixh, int depth, int wpl, int x, int w, int shift);

        // Low level in-place full width horizontal block transfer
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropHipLow")]
        internal static extern void rasteropHipLow(IntPtr data, int pixh, int depth, int wpl, int y, int h, int shift);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "shiftDataHorizontalLow")]
        internal static extern void shiftDataHorizontalLow(IntPtr datad, int wpld, IntPtr datas, int wpls, int shift);
        #endregion

        #region ropow.c
        // Low level dest-only
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropUniLow")]
        internal static extern void rasteropUniLow(IntPtr datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op);

        // Low level src and dest
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rasteropLow")]
        internal static extern void rasteropLow(IntPtr datad, int dpixw, int dpixh, int depth, int dwpl, int dx, int dy, int dw, int dh, int op, IntPtr datas, int spixw, int spixh, int swpl, int sx, int sy);
        #endregion

        #region rotate.c - DONE
        // General rotation about image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate")]
        internal static extern IntPtr pixRotate(HandleRef pixs, float angle, RotateFlags type, BackgroundFlags incolor, int width, int height);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixEmbedForRotation")]
        internal static extern IntPtr pixEmbedForRotation(HandleRef pixs, float angle, BackgroundFlags incolor, int width, int height);

        // General rotation by sampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateBySampling")]
        internal static extern IntPtr pixRotateBySampling(HandleRef pixs, int xcen, int ycen, float angle, BackgroundFlags incolor);

        // Nice(slow) rotation of 1 bpp image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateBinaryNice")]
        internal static extern IntPtr pixRotateBinaryNice(HandleRef pixs, float angle, BackgroundFlags incolor);

        // Rotation including alpha(blend) component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateWithAlpha")]
        internal static extern IntPtr pixRotateWithAlpha(HandleRef pixs, float angle, HandleRef pixg, float fract);
        #endregion

        #region rotateam.c
        // Rotation about the image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAM")]
        internal static extern IntPtr pixRotateAM(HandleRef pixs, float angle, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColor")]
        internal static extern IntPtr pixRotateAMColor(HandleRef pixs, float angle, uint colorval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMGray")]
        internal static extern IntPtr pixRotateAMGray(HandleRef pixs, float angle, byte grayval);

        // Rotation about the UL corner of the image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMCorner")]
        internal static extern IntPtr pixRotateAMCorner(HandleRef pixs, float angle, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColorCorner")]
        internal static extern IntPtr pixRotateAMColorCorner(HandleRef pixs, float angle, uint fillval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMGrayCorner")]
        internal static extern IntPtr pixRotateAMGrayCorner(HandleRef pixs, float angle, byte grayval);

        // Faster color rotation about the image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateAMColorFast")]
        internal static extern IntPtr pixRotateAMColorFast(HandleRef pixs, float angle, uint colorval);
        #endregion

        #region rotateamlow.c
        // 32 bpp grayscale rotation about image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorLow")]
        internal static extern void rotateAMColorLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);

        // 8 bpp grayscale rotation about image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMGrayLow")]
        internal static extern void rotateAMGrayLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval);

        // 32 bpp grayscale rotation about UL corner of image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorCornerLow")]
        internal static extern void rotateAMColorCornerLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);

        // 8 bpp grayscale rotation about UL corner of image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMGrayCornerLow")]
        internal static extern void rotateAMGrayCornerLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, byte grayval);

        // Fast RGB color rotation about center:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "rotateAMColorFastLow")]
        internal static extern void rotateAMColorFastLow(IntPtr datad, int w, int h, int wpld, IntPtr datas, int wpls, float angle, uint colorval);
        #endregion

        #region rotateorth.c
        // Top-level rotation by multiples of 90 degrees
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateOrth")]
        internal static extern IntPtr pixRotateOrth(HandleRef pixs, int quads);

        // 180-degree rotation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate180")]
        internal static extern IntPtr pixRotate180(HandleRef pixd, HandleRef pixs);

        // 90-degree rotation(both directions)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate90")]
        internal static extern IntPtr pixRotate90(HandleRef pixs, int direction);

        // Left-right flip
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipLR")]
        internal static extern IntPtr pixFlipLR(HandleRef pixd, HandleRef pixs);

        // Top-bottom flip
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFlipTB")]
        internal static extern IntPtr pixFlipTB(HandleRef pixd, HandleRef pixs);
        #endregion

        #region rotateshear.c
        // Shear rotation about arbitrary point using 2 and 3 shears
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShear")]
        internal static extern IntPtr pixRotateShear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate2Shear")]
        internal static extern IntPtr pixRotate2Shear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotate3Shear")]
        internal static extern IntPtr pixRotate3Shear(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        // Shear rotation in-place about arbitrary point using 3 shears
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearIP")]
        internal static extern int pixRotateShearIP(HandleRef pixs, int xcen, int ycen, float angle, int incolor);

        // Shear rotation around the image center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearCenter")]
        internal static extern IntPtr pixRotateShearCenter(HandleRef pixs, float angle, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRotateShearCenterIP")]
        internal static extern int pixRotateShearCenterIP(HandleRef pixs, float angle, int incolor);
        #endregion

        #region runlength.c
        // Label pixels by membership in runs
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStrokeWidthTransform")]
        internal static extern IntPtr pixStrokeWidthTransform(HandleRef pixs, int color, int depth, int nangles);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRunlengthTransform")]
        internal static extern IntPtr pixRunlengthTransform(HandleRef pixs, int color, int direction, int depth);

        // Find runs along horizontal and vertical lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindHorizontalRuns")]
        internal static extern int pixFindHorizontalRuns(HandleRef pix, int y, IntPtr xstart, IntPtr xend, out int pn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindVerticalRuns")]
        internal static extern int pixFindVerticalRuns(HandleRef pix, int x, IntPtr ystart, IntPtr yend, out int pn);

        // Find max runs along horizontal and vertical lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxRuns")]
        internal static extern IntPtr pixFindMaxRuns(HandleRef pix, int direction, out IntPtr pnastart);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxHorizontalRunOnLine")]
        internal static extern int pixFindMaxHorizontalRunOnLine(HandleRef pix, int y, IntPtr pxstart, out int psize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindMaxVerticalRunOnLine")]
        internal static extern int pixFindMaxVerticalRunOnLine(HandleRef pix, int x, IntPtr pystart, out int psize);

        // Compute runlength-to-membership transform on a line
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "runlengthMembershipOnLine")]
        internal static extern int runlengthMembershipOnLine(IntPtr buffer, int size, int depth, IntPtr start, IntPtr end, int n);

        // Make byte position LUT
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern IntPtr makeMSBitLocTab(int bitval);
        #endregion

        #region sarray1.c
        // Create/Destroy/Copy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreate")]
        internal static extern IntPtr sarrayCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateInitialized")]
        internal static extern IntPtr sarrayCreateInitialized(int n, [MarshalAs(UnmanagedType.AnsiBStr)] string initstr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateWordsFromString")]
        internal static extern IntPtr sarrayCreateWordsFromString([MarshalAs(UnmanagedType.AnsiBStr)] string str);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCreateLinesFromString")]
        internal static extern IntPtr sarrayCreateLinesFromString([MarshalAs(UnmanagedType.AnsiBStr)] string str, int blankflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayDestroy")]
        internal static extern void sarrayDestroy(ref IntPtr psa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayCopy")]
        internal static extern IntPtr sarrayCopy(HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayClone")]
        internal static extern IntPtr sarrayClone(HandleRef sa);

        // Add/Remove string
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern int sarrayAddString(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string str, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern IntPtr sarrayRemoveString(HandleRef sa, int index);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern int sarrayReplaceString(HandleRef sa, int index, [MarshalAs(UnmanagedType.AnsiBStr)] string newstr, int copyflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeMSBitLocTab")]
        internal static extern int sarrayClear(HandleRef sa);

        // Accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetCount")]
        internal static extern int sarrayGetCount(HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetArray")]
        internal static extern IntPtr sarrayGetArray(HandleRef sa, out int pnalloc, out int pn);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetString")]
        internal static extern IntPtr sarrayGetString(HandleRef sa, int index, int copyflag);

        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGetRefcount")]
        internal static extern int sarrayGetRefcount(HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayChangeRefcount")]
        internal static extern int sarrayChangeRefcount(HandleRef sa, int delta);

        // Conversion back to string
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayToString")]
        internal static extern IntPtr sarrayToString(HandleRef sa, int addnlflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayToStringRange")]
        internal static extern IntPtr sarrayToStringRange(HandleRef sa, int first, int nstrings, int addnlflag);

        // Join 2 sarrays
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayJoin")]
        internal static extern int sarrayJoin(HandleRef sa1, HandleRef sa2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayAppendRange")]
        internal static extern int sarrayAppendRange(HandleRef sa1, HandleRef sa2, int start, int end);

        // Pad an sarray to be the same size as another sarray
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayPadToSameSize")]
        internal static extern int sarrayPadToSameSize(HandleRef sa1, HandleRef sa2, [MarshalAs(UnmanagedType.AnsiBStr)] string padstring);

        // Convert word sarray to(formatted) line sarray
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayConvertWordsToLines")]
        internal static extern IntPtr sarrayConvertWordsToLines(HandleRef sa, int linesize);

        // Split string on separator list
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySplitString")]
        internal static extern int sarraySplitString(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string str, [MarshalAs(UnmanagedType.AnsiBStr)] string separators);

        // Filter sarray
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySelectBySubstring")]
        internal static extern IntPtr sarraySelectBySubstring(HandleRef sain, [MarshalAs(UnmanagedType.AnsiBStr)] string substr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySelectByRange")]
        internal static extern IntPtr sarraySelectByRange(HandleRef sain, int first, int last);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayParseRange")]
        internal static extern int sarrayParseRange(HandleRef sa, int start, out int pactualstart, out int pend, out int pnewstart, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int loc);

        // Serialize for I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRead")]
        internal static extern IntPtr sarrayRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayReadStream")]
        internal static extern IntPtr sarrayReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayReadMem")]
        internal static extern IntPtr sarrayReadMem(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWrite")]
        internal static extern int sarrayWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWriteStream")]
        internal static extern int sarrayWriteStream(IntPtr fp, HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayWriteMem")]
        internal static extern int sarrayWriteMem(out IntPtr pdata, IntPtr psize, HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayAppend")]
        internal static extern int sarrayAppend([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef sa);

        // Directory filenames
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getNumberedPathnamesInDirectory")]
        internal static extern IntPtr getNumberedPathnamesInDirectory([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int numpre, int numpost, int maxnum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getSortedPathnamesInDirectory")]
        internal static extern IntPtr getSortedPathnamesInDirectory([MarshalAs(UnmanagedType.AnsiBStr)] string dirname, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, int first, int nfiles);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSortedToNumberedPathnames")]
        internal static extern IntPtr convertSortedToNumberedPathnames(HandleRef sa, int numpre, int numpost, int maxnum);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getFilenamesInDirectory")]
        internal static extern IntPtr getFilenamesInDirectory([MarshalAs(UnmanagedType.AnsiBStr)] string dirname);
        #endregion

        #region sarray1.c
        // Sort
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySort")]
        internal static extern IntPtr sarraySort(HandleRef saout, HandleRef sain, int sortorder);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarraySortByIndex")]
        internal static extern IntPtr sarraySortByIndex(HandleRef sain, HandleRef naindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCompareLexical")]
        internal static extern int stringCompareLexical([MarshalAs(UnmanagedType.AnsiBStr)] string str1, [MarshalAs(UnmanagedType.AnsiBStr)] string str2);

        // Set operations using aset (rbtree)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayUnionByAset")]
        internal static extern IntPtr sarrayUnionByAset(HandleRef sa1, HandleRef sa2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRemoveDupsByAset")]
        internal static extern IntPtr sarrayRemoveDupsByAset(HandleRef sas);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayIntersectionByAset")]
        internal static extern IntPtr sarrayIntersectionByAset(HandleRef sa1, HandleRef sa2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_asetCreateFromSarray")]
        internal static extern IntPtr l_asetCreateFromSarray(HandleRef sa);

        // Set operations using hashing (dnahash)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayRemoveDupsByHash")]
        internal static extern int sarrayRemoveDupsByHash(HandleRef sas, out IntPtr psad, out IntPtr pdahash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayIntersectionByHash")]
        internal static extern IntPtr sarrayIntersectionByHash(HandleRef sa1, HandleRef sa2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayFindStringByHash")]
        internal static extern int sarrayFindStringByHash(HandleRef sa, HandleRef dahash, [MarshalAs(UnmanagedType.AnsiBStr)] string str, out int pindex);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_dnaHashCreateFromSarray")]
        internal static extern IntPtr l_dnaHashCreateFromSarray(HandleRef sa);

        // Miscellaneous operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sarrayGenerateIntegers")]
        internal static extern IntPtr sarrayGenerateIntegers(int n);
        #endregion

        #region scale.c
        // Top-level scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScale")]
        internal static extern IntPtr pixScale(HandleRef pixs, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToSizeRel")]
        internal static extern IntPtr pixScaleToSizeRel(HandleRef pixs, int delw, int delh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToSize")]
        internal static extern IntPtr pixScaleToSize(HandleRef pixs, int wd, int hd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGeneral")]
        internal static extern IntPtr pixScaleGeneral(HandleRef pixs, float scalex, float scaley, float sharpfract, int sharpwidth);
        //1.77
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToResolution")]
        internal static extern IntPtr pixScaleToResolution(HandleRef pixs, float target, float assumed, float pscalefact);

        // Linearly interpreted(usually up-) scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleLI")]
        internal static extern IntPtr pixScaleLI(HandleRef pixs, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColorLI")]
        internal static extern IntPtr pixScaleColorLI(HandleRef pixs, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColor2xLI")]
        internal static extern IntPtr pixScaleColor2xLI(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleColor4xLI")]
        internal static extern IntPtr pixScaleColor4xLI(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayLI")]
        internal static extern IntPtr pixScaleGrayLI(HandleRef pixs, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLI")]
        internal static extern IntPtr pixScaleGray2xLI(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLI")]
        internal static extern IntPtr pixScaleGray4xLI(HandleRef pixs);

        // Scaling by closest pixel sampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBySampling")]
        internal static extern IntPtr pixScaleBySampling(HandleRef pixs, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBySamplingToSize")]
        internal static extern IntPtr pixScaleBySamplingToSize(HandleRef pixs, int wd, int hd);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleByIntSampling")]
        internal static extern IntPtr pixScaleByIntSampling(HandleRef pixs, int factor);

        // Fast integer factor subsampling RGB to gray and to binary
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToGrayFast")]
        internal static extern IntPtr pixScaleRGBToGrayFast(HandleRef pixs, int factor, ColorsFor32Bpp color);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToBinaryFast")]
        internal static extern IntPtr pixScaleRGBToBinaryFast(HandleRef pixs, int factor, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayToBinaryFast")]
        internal static extern IntPtr pixScaleGrayToBinaryFast(HandleRef pixs, int factor, int thresh);

        // Downscaling with(antialias) smoothing
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleSmooth")]
        internal static extern IntPtr pixScaleSmooth(HandleRef pix, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleRGBToGray2")]
        internal static extern IntPtr pixScaleRGBToGray2(HandleRef pixs, float rwt, float gwt, float bwt);

        // Downscaling with(antialias) area mapping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAreaMap")]
        internal static extern IntPtr pixScaleAreaMap(HandleRef pix, float scalex, float scaley);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAreaMap2")]
        internal static extern IntPtr pixScaleAreaMap2(HandleRef pix);

        // Binary scaling by closest pixel sampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleBinary")]
        internal static extern IntPtr pixScaleBinary(HandleRef pixs, float scalex, float scaley);

        // Scale-to-gray(1 bpp --> 8 bpp; arbitrary downscaling)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray")]
        internal static extern IntPtr pixScaleToGray(HandleRef pixs, float scalefactor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGrayFast")]
        internal static extern IntPtr pixScaleToGrayFast(HandleRef pixs, float scalefactor);

        // Scale-to-gray(1 bpp --> 8 bpp; integer downscaling)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray2")]
        internal static extern IntPtr pixScaleToGray2(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray3")]
        internal static extern IntPtr pixScaleToGray3(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray4")]
        internal static extern IntPtr pixScaleToGray4(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray6")]
        internal static extern IntPtr pixScaleToGray6(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray8")]
        internal static extern IntPtr pixScaleToGray8(HandleRef pixs);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGray16")]
        internal static extern IntPtr pixScaleToGray16(HandleRef pixs);

        // Scale-to-gray by mipmap(1 bpp --> 8 bpp, arbitrary reduction)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleToGrayMipmap")]
        internal static extern IntPtr pixScaleToGrayMipmap(HandleRef pixs, float scalefactor);

        // Grayscale scaling using mipmap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleMipmap")]
        internal static extern IntPtr pixScaleMipmap(HandleRef pixs1, HandleRef pixs2, float scale);

        // Replicated(integer) expansion(all depths)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExpandReplicate")]
        internal static extern IntPtr pixExpandReplicate(HandleRef pixs, int factor);

        // Upscale 2x followed by binarization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLIThresh")]
        internal static extern IntPtr pixScaleGray2xLIThresh(HandleRef pixs, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray2xLIDither")]
        internal static extern IntPtr pixScaleGray2xLIDither(HandleRef pixs);

        // Upscale 4x followed by binarization
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLIThresh")]
        internal static extern IntPtr pixScaleGray4xLIThresh(HandleRef pixs, int thresh);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGray4xLIDither")]
        internal static extern IntPtr pixScaleGray4xLIDither(HandleRef pixs);

        // Grayscale downscaling using min and max
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayMinMax")]
        internal static extern IntPtr pixScaleGrayMinMax(HandleRef pixs, int xfact, int yfact, MinMaxSelectionFlags type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayMinMax2")]
        internal static extern IntPtr pixScaleGrayMinMax2(HandleRef pixs, MinMaxSelectionFlags type);

        // Grayscale downscaling using rank value
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayRankCascade")]
        internal static extern IntPtr pixScaleGrayRankCascade(HandleRef pixs, int level1, int level2, int level3, int level4);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleGrayRank2")]
        internal static extern IntPtr pixScaleGrayRank2(HandleRef pixs, int rank);

        // Helper function for transferring alpha with scaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleAndTransferAlpha")]
        internal static extern bool pixScaleAndTransferAlpha(HandleRef pixd, HandleRef pixs, float scalex, float scaley);

        // RGB scaling including alpha(blend) component
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixScaleWithAlpha")]
        internal static extern IntPtr pixScaleWithAlpha(HandleRef pixs, float scalex, float scaley, HandleRef pixg, float fract);
        #endregion

        #region scalelow.c
        // Color(interpolated) scaling: general case
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColorLILow")]
        internal static extern void scaleColorLILow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        // Grayscale(interpolated) scaling: general case
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGrayLILow")]
        internal static extern void scaleGrayLILow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        // Color(interpolated) scaling: 2x upscaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColor2xLILow")]
        internal static extern void scaleColor2xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColor2xLILineLow")]
        internal static extern void scaleColor2xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        // Grayscale(interpolated) scaling: 2x upscaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray2xLILow")]
        internal static extern void scaleGray2xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray2xLILineLow")]
        internal static extern void scaleGray2xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        // Grayscale(interpolated) scaling: 4x upscaling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray4xLILow")]
        internal static extern void scaleGray4xLILow(IntPtr datad, int wpld, IntPtr datas, int ws, int hs, int wpls);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGray4xLILineLow")]
        internal static extern void scaleGray4xLILineLow(IntPtr lined, int wpld, IntPtr lines, int ws, int wpls, int lastlineflag);

        // Grayscale and color scaling by closest pixel sampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleBySamplingLow")]
        internal static extern int scaleBySamplingLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls);

        // Color and grayscale downsampling with(antialias) lowpass filter
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleSmoothLow")]
        internal static extern int scaleSmoothLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int d, int wpls, int size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleRGBToGray2Low")]
        internal static extern void scaleRGBToGray2Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, float rwt, float gwt, float bwt);

        // Color and grayscale downsampling with(antialias) area mapping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleColorAreaMapLow")]
        internal static extern void scaleColorAreaMapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleGrayAreaMapLow")]
        internal static extern void scaleGrayAreaMapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleAreaMapLow2")]
        internal static extern void scaleAreaMapLow2(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int d, int wpls);

        // Binary scaling by closest pixel sampling
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleBinaryLow")]
        internal static extern int scaleBinaryLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int ws, int hs, int wpls);

        // Scale-to-gray 2x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray2Low")]
        internal static extern void scaleToGray2Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG2")]
        internal static extern IntPtr makeSumTabSG2(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG2")]
        internal static extern IntPtr makeValTabSG2(IntPtr v);

        // Scale-to-gray 3x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray3Low")]
        internal static extern void scaleToGray3Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG3")]
        internal static extern IntPtr makeSumTabSG3(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG3")]
        internal static extern IntPtr makeValTabSG3(IntPtr v);

        // Scale-to-gray 4x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray4Low")]
        internal static extern void scaleToGray4Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr sumtab, IntPtr valtab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeSumTabSG4")]
        internal static extern IntPtr makeSumTabSG4(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG4")]
        internal static extern IntPtr makeValTabSG4(IntPtr v);

        // Scale-to-gray 6x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray6Low")]
        internal static extern void scaleToGray6Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG6")]
        internal static extern IntPtr makeValTabSG6(IntPtr v);

        // Scale-to-gray 8x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray8Low")]
        internal static extern void scaleToGray8Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8, IntPtr valtab);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeValTabSG8")]
        internal static extern IntPtr makeValTabSG8(IntPtr v);

        // Scale-to-gray 16x
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleToGray16Low")]
        internal static extern void scaleToGray16Low(IntPtr datad, int wd, int hd, int wpld, IntPtr datas, int wpls, IntPtr tab8);

        // Grayscale mipmap
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "scaleMipmapLow")]
        internal static extern int scaleMipmapLow(IntPtr datad, int wd, int hd, int wpld, IntPtr datas1, int wpls1, IntPtr datas2, int wpls2, float red);
        #endregion

        #region seedfill.c
        // Binary seedfill(source: Luc Vincent)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBinary")]
        internal static extern IntPtr pixSeedfillBinary(HandleRef pixd, HandleRef pixs, HandleRef pixm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillBinaryRestricted")]
        internal static extern IntPtr pixSeedfillBinaryRestricted(HandleRef pixd, HandleRef pixs, HandleRef pixm, int connectivity, int xmax, int ymax);

        // Applications of binary seedfill to find and fill holes, remove c.c.touching the border and fill bg from border:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHolesByFilling")]
        internal static extern IntPtr pixHolesByFilling(HandleRef pixs, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillClosedBorders")]
        internal static extern IntPtr pixFillClosedBorders(HandleRef pixs, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixExtractBorderConnComps")]
        internal static extern IntPtr pixExtractBorderConnComps(HandleRef pixs, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRemoveBorderConnComps")]
        internal static extern IntPtr pixRemoveBorderConnComps(HandleRef pixs, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillBgFromBorder")]
        internal static extern IntPtr pixFillBgFromBorder(HandleRef pixs, int connectivity);

        // Hole-filling of components to bounding rectangle
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFillHolesToBoundingRect")]
        internal static extern IntPtr pixFillHolesToBoundingRect(HandleRef pixs, int minsize, float maxhfract, float minfgfract);

        // Gray seedfill(source: Luc Vincent:fast-hybrid-grayscale-reconstruction)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGray")]
        internal static extern int pixSeedfillGray(HandleRef pixs, HandleRef pixm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayInv")]
        internal static extern int pixSeedfillGrayInv(HandleRef pixs, HandleRef pixm, int connectivity);

        // Gray seedfill(source: Luc Vincent: sequential-reconstruction algorithm)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGraySimple")]
        internal static extern int pixSeedfillGraySimple(HandleRef pixs, HandleRef pixm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayInvSimple")]
        internal static extern int pixSeedfillGrayInvSimple(HandleRef pixs, HandleRef pixm, int connectivity);

        // Gray seedfill variations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedfillGrayBasin")]
        internal static extern IntPtr pixSeedfillGrayBasin(HandleRef pixb, HandleRef pixm, int delta, int connectivity);

        // Distance function(source: Luc Vincent)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDistanceFunction")]
        internal static extern IntPtr pixDistanceFunction(HandleRef pixs, int connectivity, int outdepth, int boundcond);

        // Seed spread(based on distance function)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSeedspread")]
        internal static extern IntPtr pixSeedspread(HandleRef pixs, int connectivity);

        // Local extrema:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixLocalExtrema")]
        internal static extern int pixLocalExtrema(HandleRef pixs, int maxmin, int minmax, out IntPtr ppixmin, out IntPtr ppixmax);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectedLocalExtrema")]
        internal static extern int pixSelectedLocalExtrema(HandleRef pixs, int mindist, out IntPtr ppixmin, out IntPtr ppixmax);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindEqualValues")]
        internal static extern IntPtr pixFindEqualValues(HandleRef pixs1, HandleRef pixs2);

        // Selection of minima in mask of connected components
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSelectMinInConnComp")]
        internal static extern int pixSelectMinInConnComp(HandleRef pixs, HandleRef pixm, out IntPtr ppta, out IntPtr pnav);

        // Removal of seeded connected components from a mask
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "RemoveSeededComponents")]
        internal static extern IntPtr RemoveSeededComponents(HandleRef pixd, HandleRef pixs, HandleRef pixm, int connectivity, int bordersize);
        #endregion

        #region seedfilllow.c
        // Seedfill: Gray seedfill(source: Luc Vincent:fast-hybrid-grayscale-reconstruction)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillBinaryLow")]
        internal static extern void seedfillBinaryLow(IntPtr datas, int hs, int wpls, IntPtr datam, int hm, int wplm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayLow")]
        internal static extern void seedfillGrayLow(IntPtr datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayInvLow")]
        internal static extern void seedfillGrayInvLow(IntPtr datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayLowSimple")]
        internal static extern void seedfillGrayLowSimple(IntPtr datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedfillGrayInvLowSimple")]
        internal static extern void seedfillGrayInvLowSimple(IntPtr datas, int w, int h, int wpls, IntPtr datam, int wplm, int connectivity);

        //  Distance function:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "distanceFunctionLow")]
        internal static extern void distanceFunctionLow(IntPtr datad, int w, int h, int d, int wpld, int connectivity);

        // Seed spread:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "seedspreadLow")]
        internal static extern void seedspreadLow(IntPtr datad, int w, int h, int wpld, IntPtr datat, int wplt, int connectivity);
        #endregion

        #region sel1.c
        // Create/destroy/copy:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaCreate")]
        internal static extern IntPtr selaCreate(int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaDestroy")]
        internal static extern void selaDestroy(ref IntPtr psela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreate")]
        internal static extern IntPtr selCreate(int height, int width, [MarshalAs(UnmanagedType.AnsiBStr)] string name);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selDestroy")]
        internal static extern void selDestroy(ref IntPtr psel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCopy")]
        internal static extern IntPtr selCopy(HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateBrick")]
        internal static extern IntPtr selCreateBrick(int h, int w, int cy, int cx, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateComb")]
        internal static extern IntPtr selCreateComb(int factor1, int factor2, int direction);

        // Helper proc:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "create2dIntArray")]
        internal static extern IntPtr create2dIntArray(int sy, int sx);

        // Extension of sela:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddSel")]
        internal static extern int selaAddSel(HandleRef sela, HandleRef sel, [MarshalAs(UnmanagedType.AnsiBStr)] string selname, int copyflag);

        // Accessors:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetCount")]
        internal static extern int selaGetCount(HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetSel")]
        internal static extern IntPtr selaGetSel(HandleRef sela, int i);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetName")]
        internal static extern IntPtr selGetName(HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetName")]
        internal static extern int selSetName(HandleRef sel, [MarshalAs(UnmanagedType.AnsiBStr)] string name);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaFindSelByName")]
        internal static extern int selaFindSelByName(HandleRef sela, [MarshalAs(UnmanagedType.AnsiBStr)] string name, out int pindex, out IntPtr psel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetElement")]
        internal static extern int selGetElement(HandleRef sel, int row, int col, out int ptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetElement")]
        internal static extern int selSetElement(HandleRef sel, int row, int col, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetParameters")]
        internal static extern int selGetParameters(HandleRef sel, out int psy, out int psx, out int pcy, out int pcx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selSetOrigin")]
        internal static extern int selSetOrigin(HandleRef sel, int cy, int cx);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selGetTypeAtOrigin")]
        internal static extern int selGetTypeAtOrigin(HandleRef sel, out int ptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetBrickName")]
        internal static extern IntPtr selaGetBrickName(HandleRef sela, int hsize, int vsize);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetCombName")]
        internal static extern IntPtr selaGetCombName(HandleRef sela, int size, int direction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getCompositeParameters")]
        internal static extern int getCompositeParameters(int size, out int psize1, out int psize2, out IntPtr pnameh1, out IntPtr pnameh2, out IntPtr pnamev1, out IntPtr pnamev2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaGetSelnames")]
        internal static extern IntPtr selaGetSelnames(HandleRef sela);

        // Max translations for erosion and hmt
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selFindMaxTranslations")]
        internal static extern int selFindMaxTranslations(HandleRef sel, out int pxp, out int pyp, out int pxn, out int pyn);

        // Rotation by multiples of 90 degrees
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selRotateOrth")]
        internal static extern IntPtr selRotateOrth(HandleRef sel, int quads);

        // Sela and Sel serialized I/O
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaRead")]
        internal static extern IntPtr selaRead([MarshalAs(UnmanagedType.AnsiBStr)] string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaReadStream")]
        internal static extern IntPtr selaReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selRead")]
        internal static extern IntPtr selRead([MarshalAs(UnmanagedType.AnsiBStr)] string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selReadStream")]
        internal static extern IntPtr selReadStream(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaWrite")]
        internal static extern int selaWrite([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaWriteStream")]
        internal static extern int selaWriteStream(IntPtr fp, HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selWrite")]
        internal static extern int selWrite([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef sel);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selWriteStream")]
        internal static extern int selWriteStream(IntPtr fp, HandleRef sel);

        // Building custom hit-miss sels from compiled strings
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromString")]
        internal static extern IntPtr selCreateFromString([MarshalAs(UnmanagedType.AnsiBStr)] string text, int h, int w, [MarshalAs(UnmanagedType.AnsiBStr)] string name);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selPrintToString")]
        internal static extern IntPtr selPrintToString(HandleRef sel);

        // Building custom hit-miss sels from a simple file format
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaCreateFromFile")]
        internal static extern IntPtr selaCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename);

        // Making hit-only sels from Pta and Pix
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromPta")]
        internal static extern IntPtr selCreateFromPta(HandleRef pta, int cy, int cx, [MarshalAs(UnmanagedType.AnsiBStr)] string name);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromPix")]
        internal static extern IntPtr selCreateFromPix(HandleRef pix, int cy, int cx, [MarshalAs(UnmanagedType.AnsiBStr)] string name);

        // Making hit-miss sels from Pix and image files
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selReadFromColorImage")]
        internal static extern IntPtr selReadFromColorImage([MarshalAs(UnmanagedType.AnsiBStr)] string pathname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selCreateFromColorPix")]
        internal static extern IntPtr selCreateFromColorPix(HandleRef pixs, [MarshalAs(UnmanagedType.AnsiBStr)] string selname);

        // Printable display of sel
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selDisplayInPix")]
        internal static extern IntPtr selDisplayInPix(HandleRef sel, int size, int gthick);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaDisplayInPix")]
        internal static extern IntPtr selaDisplayInPix(HandleRef sela, int size, int gthick, int spacing, int ncols);
        #endregion

        #region sel2.c
        // Basic brick structuring elements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddBasic")]
        internal static extern IntPtr selaAddBasic(HandleRef sela);

        // Simple hit-miss structuring elements
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddHitMiss")]
        internal static extern IntPtr selaAddHitMiss(HandleRef sela);

        // Structuring elements for comparing with DWA operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddDwaLinear")]
        internal static extern IntPtr selaAddDwaLinear(HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddDwaCombs")]
        internal static extern IntPtr selaAddDwaCombs(HandleRef sela);

        // Structuring elements for the intersection of lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddCrossJunctions")]
        internal static extern IntPtr selaAddCrossJunctions(HandleRef sela, float hlsize, float mdist, int norient, int debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "selaAddTJunctions")]
        internal static extern IntPtr selaAddTJunctions(HandleRef sela, float hlsize, float mdist, int norient, int debugflag);

        // Structuring elements for connectivity-preserving thinning operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela4ccThin")]
        internal static extern IntPtr sela4ccThin(HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela8ccThin")]
        internal static extern IntPtr sela8ccThin(HandleRef sela);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sela4and8ccThin")]
        internal static extern IntPtr sela4and8ccThin(HandleRef sela);
        #endregion

        #region selgen.c
        // Generate a subsampled structuring element
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelWithRuns")]
        internal static extern IntPtr pixGenerateSelWithRuns(HandleRef pixs, int nhlines, int nvlines, int distance, int minlength, int toppix, int botpix, int leftpix, int rightpix, out IntPtr ppixe);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelRandom")]
        internal static extern IntPtr pixGenerateSelRandom(HandleRef pixs, float hitfract, float missfract, int distance, int toppix, int botpix, int leftpix, int rightpix, out IntPtr ppixe);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGenerateSelBoundary")]
        internal static extern IntPtr pixGenerateSelBoundary(HandleRef pixs, int hitdist, int missdist, int hitskip, int missskip, int topflag, int botflag, int leftflag, int rightflag, out IntPtr ppixe);

        // Accumulate data on runs along lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRunCentersOnLine")]
        internal static extern IntPtr pixGetRunCentersOnLine(HandleRef pixs, int x, int y, int minlength);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetRunsOnLine")]
        internal static extern IntPtr pixGetRunsOnLine(HandleRef pixs, int x1, int y1, int x2, int y2);

        // Subsample boundary pixels in relatively ordered way
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSubsampleBoundaryPixels")]
        internal static extern IntPtr pixSubsampleBoundaryPixels(HandleRef pixs, int skip);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "adjacentOnPixelInRaster")]
        internal static extern int adjacentOnPixelInRaster(HandleRef pixs, int x, int y, out int pxa, out int pya);

        // Display generated sel with originating image
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayHitMissSel")]
        internal static extern IntPtr pixDisplayHitMissSel(HandleRef pixs, HandleRef sel, int scalefactor, uint hitcolor, uint misscolor);
        #endregion

        #region shear.c
        // About arbitrary lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShear")]
        internal static extern IntPtr pixHShear(HandleRef pixd, HandleRef pixs, int yloc, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShear")]
        internal static extern IntPtr pixVShear(HandleRef pixd, HandleRef pixs, int xloc, float radang, int incolor);

        // About special 'points': UL corner and center
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearCorner")]
        internal static extern IntPtr pixHShearCorner(HandleRef pixd, HandleRef pixs, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearCorner")]
        internal static extern IntPtr pixVShearCorner(HandleRef pixd, HandleRef pixs, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearCenter")]
        internal static extern IntPtr pixHShearCenter(HandleRef pixd, HandleRef pixs, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearCenter")]
        internal static extern IntPtr pixVShearCenter(HandleRef pixd, HandleRef pixs, float radang, int incolor);

        // In place about arbitrary lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearIP")]
        internal static extern int pixHShearIP(HandleRef pixs, int yloc, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearIP")]
        internal static extern int pixVShearIP(HandleRef pixs, int xloc, float radang, int incolor);

        // Linear interpolated shear about arbitrary lines
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixHShearLI")]
        internal static extern IntPtr pixHShearLI(HandleRef pixs, int yloc, float radang, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixVShearLI")]
        internal static extern IntPtr pixVShearLI(HandleRef pixs, int xloc, float radang, int incolor);
        #endregion

        #region skew.c - DONE
        // Top-level deskew interfaces
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewBoth")]
        internal static extern IntPtr pixDeskewBoth(HandleRef pixs, int redsearch);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskew")]
        internal static extern IntPtr pixDeskew(HandleRef pixs, int redsearch);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewAndDeskew")]
        internal static extern IntPtr pixFindSkewAndDeskew(HandleRef pixs, int redsearch, out float pangle, out float pconf);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeskewGeneral")]
        internal static extern IntPtr pixDeskewGeneral(HandleRef pixs, int redsweep, float sweeprange, float sweepdelta, int redsearch, int thresh, out float pangle, out float pconf);

        // Top-level angle-finding interface
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkew")]
        internal static extern bool pixFindSkew(HandleRef pixs, out float pangle, out float pconf);

        // Basic angle-finding functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweep")]
        internal static extern bool pixFindSkewSweep(HandleRef pixs, out float pangle, int reduction, float sweeprange, float sweepdelta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearch")]
        internal static extern bool pixFindSkewSweepAndSearch(HandleRef pixs, out float pangle, out float pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearchScore")]
        internal static extern bool pixFindSkewSweepAndSearchScore(HandleRef pixs, out float pangle, out float pconf, out float pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewSweepAndSearchScorePivot")]
        internal static extern bool pixFindSkewSweepAndSearchScorePivot(HandleRef pixs, out float pangle, out float pconf, out float pendscore, int redsweep, int redsearch, float sweepcenter, float sweeprange, float sweepdelta, float minbsdelta, ShearFlags pivot);

        // Search over arbitrary range of angles in orthogonal directions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindSkewOrthogonalRange")]
        internal static extern bool pixFindSkewOrthogonalRange(HandleRef pixs, out float pangle, out float pconf, int redsweep, int redsearch, float sweeprange, float sweepdelta, float minbsdelta, float confprior);

        // Differential square sum function for scoring
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindDifferentialSquareSum")]
        internal static extern bool pixFindDifferentialSquareSum(HandleRef pixs, out float psum);

        // Measures of variance of row sums
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindNormalizedSquareSum")]
        internal static extern bool pixFindNormalizedSquareSum(HandleRef pixs, out float phratio, out float pvratio, out float pfract);
        #endregion

        #region spixio.c
        // Reading spix from file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamSpix")]
        internal static extern IntPtr pixReadStreamSpix(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderSpix")]
        internal static extern int readHeaderSpix([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderSpix")]
        internal static extern int freadHeaderSpix(IntPtr fp, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sreadHeaderSpix")]
        internal static extern int sreadHeaderSpix(IntPtr data, out int pwidth, out int pheight, out int pbps, out int pspp, out int piscmap);

        // Writing spix to file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamSpix")]
        internal static extern int pixWriteStreamSpix(IntPtr fp, HandleRef pix);

        // Low-level serialization of pix to/from memory(uncompressed)
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemSpix")]
        internal static extern IntPtr pixReadMemSpix(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemSpix")]
        internal static extern int pixWriteMemSpix(out IntPtr pdata, IntPtr psize, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSerializeToMemory")]
        internal static extern int pixSerializeToMemory(HandleRef pixs, out IntPtr pdata, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDeserializeFromMemory")]
        internal static extern IntPtr pixDeserializeFromMemory(IntPtr data, IntPtr nbytes);
        #endregion

        #region stack.c
        // Create/Destroy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackCreate")]
        internal static extern IntPtr lstackCreate(int nalloc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackDestroy")]
        internal static extern void lstackDestroy(ref IntPtr plstack, int freeflag);

        // Accessors
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackAdd")]
        internal static extern int lstackAdd(HandleRef lstack, IntPtr item);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackRemove")]
        internal static extern IntPtr lstackRemove(HandleRef lstack);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackGetCount")]
        internal static extern int lstackGetCount(HandleRef lstack);

        // Text description
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lstackPrint")]
        internal static extern int lstackPrint(IntPtr fp, HandleRef lstack);
        #endregion

        #region stringcode.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strcodeCreate")]
        internal static extern IntPtr strcodeCreate(int fileno);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strcodeCreateFromFile")]
        internal static extern int strcodeCreateFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filein, int fileno, [MarshalAs(UnmanagedType.AnsiBStr)] string outdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strcodeGenerate")]
        internal static extern int strcodeGenerate(HandleRef strcode, [MarshalAs(UnmanagedType.AnsiBStr)] string filein, [MarshalAs(UnmanagedType.AnsiBStr)] string type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strcodeFinalize")]
        internal static extern int strcodeFinalize(ref IntPtr pstrcode, [MarshalAs(UnmanagedType.AnsiBStr)] string outdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getStructStrFromFile")]
        internal static extern int l_getStructStrFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int field, out IntPtr pstr);
        #endregion

        #region strokes.c
        // Stroke parameter measurement
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindStrokeLength")]
        internal static extern int pixFindStrokeLength(HandleRef pixs, IntPtr tab8, out int plength);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixFindStrokeWidth")]
        internal static extern int pixFindStrokeWidth(HandleRef pixs, float thresh, IntPtr tab8, out float pwidth, out IntPtr pnahisto);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaFindStrokeWidth")]
        internal static extern IntPtr pixaFindStrokeWidth(HandleRef pixa, float thresh, IntPtr tab8, int debug);

        // Stroke width regulation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaModifyStrokeWidth")]
        internal static extern IntPtr pixaModifyStrokeWidth(HandleRef pixas, float targetw);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixModifyStrokeWidth")]
        internal static extern IntPtr pixModifyStrokeWidth(HandleRef pixs, float width, float targetw);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaSetStrokeWidth")]
        internal static extern IntPtr pixaSetStrokeWidth(HandleRef pixas, int width, int thinfirst, int connectivity);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetStrokeWidth")]
        internal static extern IntPtr pixSetStrokeWidth(HandleRef pixs, int width, int thinfirst, int connectivity);
        #endregion

        #region sudoku.c
        // Read input data from file or string
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuReadFile")]
        internal static extern IntPtr sudokuReadFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuReadString")]
        internal static extern IntPtr sudokuReadString([MarshalAs(UnmanagedType.AnsiBStr)] string str);

        // Create/destroy
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuCreate")]
        internal static extern IntPtr sudokuCreate(IntPtr array);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuDestroy")]
        internal static extern void sudokuDestroy(ref IntPtr psud);

        // Solve the puzzle
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuSolve")]
        internal static extern int sudokuSolve(HandleRef sud);

        // Test for uniqueness
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuTestUniqueness")]
        internal static extern int sudokuTestUniqueness(IntPtr array, out int punique);

        // Generation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuGenerate")]
        internal static extern IntPtr sudokuGenerate(IntPtr array, int seed, int minelems, int maxtries);

        // Output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sudokuOutput")]
        internal static extern int sudokuOutput(HandleRef sud, int arraytype);
        #endregion

        #region textops.c
        // Font layout
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddSingleTextblock")]
        internal static extern IntPtr pixAddSingleTextblock(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int location, out int poverflow);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixAddTextlines")]
        internal static extern IntPtr pixAddTextlines(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int location);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetTextblock")]
        internal static extern int pixSetTextblock(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int x0, int y0, int wtext, int firstindent, out int poverflow);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSetTextline")]
        internal static extern int pixSetTextline(HandleRef pixs, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int x0, int y0, out int pwidth, out int poverflow);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddTextNumber")]
        internal static extern IntPtr pixaAddTextNumber(HandleRef pixas, HandleRef bmf, HandleRef na, uint val, int location);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddTextlines")]
        internal static extern IntPtr pixaAddTextlines(HandleRef pixas, HandleRef bmf, HandleRef sa, uint val, int location);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaAddPixWithText")]
        internal static extern int pixaAddPixWithText(HandleRef pixa, HandleRef pixs, int reduction, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, int location);

        // Text size estimation and partitioning
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetLineStrings")]
        internal static extern IntPtr bmfGetLineStrings(HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, int maxw, int firstindent, out int ph);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetWordWidths")]
        internal static extern IntPtr bmfGetWordWidths(HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, HandleRef sa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bmfGetStringWidth")]
        internal static extern int bmfGetStringWidth(HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, out int pw);

        // Text splitting
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitStringToParagraphs")]
        internal static extern IntPtr splitStringToParagraphs([MarshalAs(UnmanagedType.AnsiBStr)] string textstr, int splitflag);
        #endregion

        #region tiffio.c
        // Reading tiff:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadTiff")]
        internal static extern IntPtr pixReadTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamTiff")]
        internal static extern IntPtr pixReadStreamTiff(IntPtr fp, int n);

        // Writing tiff:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteTiff")]
        internal static extern int pixWriteTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, int comptype, [MarshalAs(UnmanagedType.AnsiBStr)] string modestr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteTiffCustom")]
        internal static extern int pixWriteTiffCustom([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, int comptype, [MarshalAs(UnmanagedType.AnsiBStr)] string modestr, HandleRef natags, HandleRef savals, HandleRef satypes, HandleRef nasizes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamTiff")]
        internal static extern int pixWriteStreamTiff(IntPtr fp, HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamTiffWA")]
        internal static extern int pixWriteStreamTiffWA(IntPtr fp, HandleRef pix, int comptype, [MarshalAs(UnmanagedType.AnsiBStr)] string modestr);

        // Reading and writing multipage tiff
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadFromMultipageTiff")]
        internal static extern IntPtr pixReadFromMultipageTiff([MarshalAs(UnmanagedType.AnsiBStr)] string fname, out IntPtr poffset);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadMultipageTiff")]
        internal static extern IntPtr pixaReadMultipageTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteMultipageTiff")]
        internal static extern int pixaWriteMultipageTiff([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeMultipageTiff")]
        internal static extern int writeMultipageTiff([MarshalAs(UnmanagedType.AnsiBStr)] string dirin, [MarshalAs(UnmanagedType.AnsiBStr)] string substr, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "writeMultipageTiffSA")]
        internal static extern int writeMultipageTiffSA(HandleRef sa, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        // Information about tiff file
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fprintTiffInfo")]
        internal static extern int fprintTiffInfo(IntPtr fpout, [MarshalAs(UnmanagedType.AnsiBStr)] string tiffile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "tiffGetCount")]
        internal static extern int tiffGetCount(IntPtr fp, out int pn);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getTiffResolution")]
        internal static extern int getTiffResolution(IntPtr fp, out int pxres, out int pyres);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderTiff")]
        internal static extern int readHeaderTiff([MarshalAs(UnmanagedType.AnsiBStr)] string filename, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "freadHeaderTiff")]
        internal static extern int freadHeaderTiff(IntPtr fp, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemTiff")]
        internal static extern int readHeaderMemTiff(IntPtr cdata, IntPtr size, int n, out int pwidth, out int pheight, out int pbps, out int pspp, out int pres, out int pcmap, out int pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findTiffCompression")]
        internal static extern int findTiffCompression(IntPtr fp, out int pcomptype);

        // Extraction of tiff g4 data:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractG4DataFromFile")]
        internal static extern int extractG4DataFromFile([MarshalAs(UnmanagedType.AnsiBStr)] string filein, out IntPtr pdata, IntPtr pnbytes, out int pw, out int ph, out int pminisblack);

        // Memory I/O: reading memory --> pix and writing pix --> memory [10 static helper functions]
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemTiff")]
        internal static extern IntPtr pixReadMemTiff(IntPtr cdata, IntPtr size, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemFromMultipageTiff")]
        internal static extern IntPtr pixReadMemFromMultipageTiff(IntPtr cdata, IntPtr size, IntPtr poffset);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaReadMemMultipageTiff")]
        internal static extern IntPtr pixaReadMemMultipageTiff(IntPtr data, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteMemMultipageTiff")]
        internal static extern int pixaWriteMemMultipageTiff(out IntPtr pdata, IntPtr psize, HandleRef pixa);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemTiff")]
        internal static extern int pixWriteMemTiff(out IntPtr pdata, IntPtr psize, HandleRef pix, int comptype);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemTiffCustom")]
        internal static extern int pixWriteMemTiffCustom(out IntPtr pdata, IntPtr psize, HandleRef pix, int comptype, HandleRef natags, HandleRef savals, HandleRef satypes, HandleRef nasizes);
        #endregion

        #region utils1.c
        // Control of error, warning and info messages
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setMsgSeverity")]
        internal static extern int setMsgSeverity(int newsev);

        // Error return functions, invoked by macros
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorInt")]
        internal static extern int returnErrorInt([MarshalAs(UnmanagedType.AnsiBStr)] string msg, [MarshalAs(UnmanagedType.AnsiBStr)] string procname, int ival);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorFloat")]
        internal static extern float returnErrorFloat([MarshalAs(UnmanagedType.AnsiBStr)] string msg, [MarshalAs(UnmanagedType.AnsiBStr)] string procname, float fval);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "returnErrorPtr")]
        internal static extern IntPtr returnErrorPtr([MarshalAs(UnmanagedType.AnsiBStr)] string msg, [MarshalAs(UnmanagedType.AnsiBStr)] string procname, IntPtr pval);

        // Test files for equivalence
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "filesAreIdentical")]
        internal static extern int filesAreIdentical([MarshalAs(UnmanagedType.AnsiBStr)] string fname1, [MarshalAs(UnmanagedType.AnsiBStr)] string fname2, out int psame);

        // Byte-swapping data conversion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnLittleEnd16")]
        internal static extern ushort convertOnLittleEnd16(ushort shortin);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnBigEnd16")]
        internal static extern ushort convertOnBigEnd16(ushort shortin);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnLittleEnd32")]
        internal static extern uint convertOnLittleEnd32(uint wordin);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertOnBigEnd32")]
        internal static extern uint convertOnBigEnd32(uint wordin);

        // File corruption operation
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCorruptByDeletion")]
        internal static extern int fileCorruptByDeletion([MarshalAs(UnmanagedType.AnsiBStr)] string filein, float loc, float size, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCorruptByMutation")]
        internal static extern int fileCorruptByMutation([MarshalAs(UnmanagedType.AnsiBStr)] string filein, float loc, float size, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);

        // Generate random integer in given range
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genRandomIntegerInRange")]
        internal static extern int genRandomIntegerInRange(int range, int seed, out int pval);

        // Simple math function
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_roundftoi")]
        internal static extern int lept_roundftoi(float fval);

        // 64-bit hash functions
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashStringToUint64")]
        internal static extern int l_hashStringToUint64([MarshalAs(UnmanagedType.AnsiBStr)] string str, out ulong phash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashPtToUint64")]
        internal static extern int l_hashPtToUint64(int x, int y, out ulong phash);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_hashFloat64ToUint64")]
        internal static extern int l_hashFloat64ToUint64(int nbuckets, double val, out ulong phash);

        // Prime finders
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "findNextLargerPrime")]
        internal static extern int findNextLargerPrime(int start, out uint pprime);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_isPrime")]
        internal static extern int lept_isPrime(ulong n, out int pis_prime, out uint pfactor);

        // Gray code conversion
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertBinaryToGrayCode")]
        internal static extern uint convertBinaryToGrayCode(uint val);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertGrayCodeToBinary")]
        internal static extern uint convertGrayCodeToBinary(uint val);

        // Leptonica version number
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getLeptonicaVersion")]
        internal static extern IntPtr getLeptonicaVersion();

        // Timing
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "startTimer")]
        internal static extern void startTimer(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stopTimer")]
        internal static extern float stopTimer(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "startTimerNested")]
        internal static extern IntPtr startTimerNested(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stopTimerNested")]
        internal static extern float stopTimerNested(IntPtr rusage_start);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getCurrentTime")]
        internal static extern void l_getCurrentTime(out int sec, out int usec);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "startWallTimer")]
        internal static extern IntPtr startWallTimer(IntPtr v);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stopWallTimer")]
        internal static extern float stopWallTimer(ref IntPtr ptimer);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_getFormattedDate")]
        internal static extern IntPtr l_getFormattedDate();
        #endregion

        #region utils2.c
        // Safe string procs
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringNew")]
        internal static extern IntPtr stringNew([MarshalAs(UnmanagedType.AnsiBStr)] string src);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCopy")]
        internal static extern int stringCopy([MarshalAs(UnmanagedType.AnsiBStr)] string dest, [MarshalAs(UnmanagedType.AnsiBStr)] string src, int n);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplace")]
        internal static extern int stringReplace(out IntPtr pdest, [MarshalAs(UnmanagedType.AnsiBStr)] string src);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringLength")]
        internal static extern int stringLength([MarshalAs(UnmanagedType.AnsiBStr)] string src, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringCat")]
        internal static extern int stringCat([MarshalAs(UnmanagedType.AnsiBStr)] string dest, IntPtr size, [MarshalAs(UnmanagedType.AnsiBStr)] string src);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringConcatNew")]
        internal static extern IntPtr stringConcatNew([MarshalAs(UnmanagedType.AnsiBStr)] string first, IntPtr ptr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringJoin")]
        internal static extern IntPtr stringJoin([MarshalAs(UnmanagedType.AnsiBStr)] string src1, [MarshalAs(UnmanagedType.AnsiBStr)] string src2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringJoinIP")]
        internal static extern int stringJoinIP(out IntPtr psrc1, [MarshalAs(UnmanagedType.AnsiBStr)] string src2);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReverse")]
        internal static extern IntPtr stringReverse([MarshalAs(UnmanagedType.AnsiBStr)] string src);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "strtokSafe")]
        internal static extern IntPtr strtokSafe([MarshalAs(UnmanagedType.AnsiBStr)] string cstr, [MarshalAs(UnmanagedType.AnsiBStr)] string seps, out IntPtr psaveptr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringSplitOnToken")]
        internal static extern int stringSplitOnToken([MarshalAs(UnmanagedType.AnsiBStr)] string cstr, [MarshalAs(UnmanagedType.AnsiBStr)] string seps, out IntPtr phead, out IntPtr ptail);

        // Find and replace string and array procs
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringRemoveChars")]
        internal static extern IntPtr stringRemoveChars([MarshalAs(UnmanagedType.AnsiBStr)] string src, [MarshalAs(UnmanagedType.AnsiBStr)] string remchars);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringFindSubstr")]
        internal static extern int stringFindSubstr([MarshalAs(UnmanagedType.AnsiBStr)] string src, [MarshalAs(UnmanagedType.AnsiBStr)] string sub, out int ploc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplaceSubstr")]
        internal static extern IntPtr stringReplaceSubstr([MarshalAs(UnmanagedType.AnsiBStr)] string src, [MarshalAs(UnmanagedType.AnsiBStr)] string sub1, [MarshalAs(UnmanagedType.AnsiBStr)] string sub2, out int pfound, out int ploc);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "stringReplaceEachSubstr")]
        internal static extern IntPtr stringReplaceEachSubstr([MarshalAs(UnmanagedType.AnsiBStr)] string src, [MarshalAs(UnmanagedType.AnsiBStr)] string sub1, [MarshalAs(UnmanagedType.AnsiBStr)] string sub2, out int pcount);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "arrayFindEachSequence")]
        internal static extern IntPtr arrayFindEachSequence(IntPtr data, IntPtr datalen, IntPtr sequence, IntPtr seqlen);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "arrayFindSequence")]
        internal static extern int arrayFindSequence(IntPtr data, IntPtr datalen, IntPtr sequence, IntPtr seqlen, out int poffset, out int pfound);

        // Safe realloc
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "reallocNew")]
        internal static extern IntPtr reallocNew(IntPtr pindata, int oldsize, int newsize);

        // Read and write between file and memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryRead")]
        internal static extern IntPtr l_binaryRead([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadStream")]
        internal static extern IntPtr l_binaryReadStream(IntPtr fp, IntPtr pnbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadSelect")]
        internal static extern IntPtr l_binaryReadSelect([MarshalAs(UnmanagedType.AnsiBStr)] string filename, IntPtr start, IntPtr nbytes, out IntPtr pnread);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryReadSelectStream")]
        internal static extern IntPtr l_binaryReadSelectStream(IntPtr fp, IntPtr start, IntPtr nbytes, IntPtr pnread);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryWrite")]
        internal static extern int l_binaryWrite([MarshalAs(UnmanagedType.AnsiBStr)] string filename, [MarshalAs(UnmanagedType.AnsiBStr)] string operation, IntPtr data, IntPtr nbytes);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nbytesInFile")]
        internal static extern IntPtr nbytesInFile([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fnbytesInFile")]
        internal static extern IntPtr fnbytesInFile(IntPtr fp);

        // Copy in memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_binaryCopy")]
        internal static extern IntPtr l_binaryCopy(IntPtr datas, IntPtr size);

        // File copy operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileCopy")]
        internal static extern int fileCopy([MarshalAs(UnmanagedType.AnsiBStr)] string srcfile, [MarshalAs(UnmanagedType.AnsiBStr)] string newfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileConcatenate")]
        internal static extern int fileConcatenate([MarshalAs(UnmanagedType.AnsiBStr)] string srcfile, [MarshalAs(UnmanagedType.AnsiBStr)] string destfile);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fileAppendString")]
        internal static extern int fileAppendString([MarshalAs(UnmanagedType.AnsiBStr)] string filename, [MarshalAs(UnmanagedType.AnsiBStr)] string str);

        // Multi-platform functions for opening file streams
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenReadStream")]
        internal static extern IntPtr fopenReadStream([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenWriteStream")]
        internal static extern IntPtr fopenWriteStream([MarshalAs(UnmanagedType.AnsiBStr)] string filename, [MarshalAs(UnmanagedType.AnsiBStr)] string modestring);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenReadFromMemory")]
        internal static extern IntPtr fopenReadFromMemory(IntPtr data, IntPtr size);

        // Opening a windows tmpfile for writing
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "fopenWriteWinTempfile")]
        internal static extern IntPtr fopenWriteWinTempfile();

        // Multi-platform functions that avoid C-runtime boundary crossing  with Windows DLLs
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_fopen")]
        internal static extern IntPtr lept_fopen([MarshalAs(UnmanagedType.AnsiBStr)] string filename, [MarshalAs(UnmanagedType.AnsiBStr)] string mode);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_fclose")]
        internal static extern int lept_fclose(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_calloc")]
        internal static extern IntPtr lept_calloc(IntPtr nmemb, IntPtr size);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_free")]
        internal static extern void lept_free(IntPtr ptr);

        // Multi-platform file system operations in temp directories
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_mkdir")]
        internal static extern int lept_mkdir([MarshalAs(UnmanagedType.AnsiBStr)] string subdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rmdir")]
        internal static extern int lept_rmdir([MarshalAs(UnmanagedType.AnsiBStr)] string subdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_direxists")]
        internal static extern void lept_direxists([MarshalAs(UnmanagedType.AnsiBStr)] string dir, out int pexists);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rm_match")]
        internal static extern int lept_rm_match([MarshalAs(UnmanagedType.AnsiBStr)] string subdir, [MarshalAs(UnmanagedType.AnsiBStr)] string substr);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rm")]
        internal static extern int lept_rm([MarshalAs(UnmanagedType.AnsiBStr)] string subdir, [MarshalAs(UnmanagedType.AnsiBStr)] string tail);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_rmfile")]
        internal static extern int lept_rmfile([MarshalAs(UnmanagedType.AnsiBStr)] string filepath);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_mv")]
        internal static extern int lept_mv([MarshalAs(UnmanagedType.AnsiBStr)] string srcfile, [MarshalAs(UnmanagedType.AnsiBStr)] string newdir, [MarshalAs(UnmanagedType.AnsiBStr)] string newtail, out IntPtr pnewpath);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "lept_cp")]
        internal static extern int lept_cp([MarshalAs(UnmanagedType.AnsiBStr)] string srcfile, [MarshalAs(UnmanagedType.AnsiBStr)] string newdir, [MarshalAs(UnmanagedType.AnsiBStr)] string newtail, out IntPtr pnewpath);

        // General file name operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitPathAtDirectory")]
        internal static extern int splitPathAtDirectory([MarshalAs(UnmanagedType.AnsiBStr)] string pathname, out IntPtr pdir, out IntPtr ptail);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "splitPathAtExtension")]
        internal static extern int splitPathAtExtension([MarshalAs(UnmanagedType.AnsiBStr)] string pathname, out IntPtr pbasename, out IntPtr pextension);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pathJoin")]
        internal static extern IntPtr pathJoin([MarshalAs(UnmanagedType.AnsiBStr)] string dir, [MarshalAs(UnmanagedType.AnsiBStr)] string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "appendSubdirs")]
        internal static extern IntPtr appendSubdirs([MarshalAs(UnmanagedType.AnsiBStr)] string basedir, [MarshalAs(UnmanagedType.AnsiBStr)] string subdirs);

        // Special file name operations
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "convertSepCharsInPath")]
        internal static extern int convertSepCharsInPath([MarshalAs(UnmanagedType.AnsiBStr)] string path, int type);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "genPathname")]
        internal static extern IntPtr genPathname([MarshalAs(UnmanagedType.AnsiBStr)] string dir, [MarshalAs(UnmanagedType.AnsiBStr)] string fname);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "makeTempDirname")]
        internal static extern int makeTempDirname([MarshalAs(UnmanagedType.AnsiBStr)] string result, IntPtr nbytes, [MarshalAs(UnmanagedType.AnsiBStr)] string subdir);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "modifyTrailingSlash")]
        internal static extern int modifyTrailingSlash([MarshalAs(UnmanagedType.AnsiBStr)] string path, IntPtr nbytes, int flag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_makeTempFilename")]
        internal static extern IntPtr l_makeTempFilename();
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "extractNumberFromFilename")]
        internal static extern int extractNumberFromFilename([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int numpre, int numpost);
        #endregion

        #region warper.c
        // High-level captcha interface
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSimpleCaptcha")]
        internal static extern IntPtr pixSimpleCaptcha(HandleRef pixs, int border, int nterms, uint seed, uint color, int cmapflag);

        // Random sinusoidal warping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixRandomHarmonicWarp")]
        internal static extern IntPtr pixRandomHarmonicWarp(HandleRef pixs, float xmag, float ymag, float xfreq, float yfreq, int nx, int ny, uint seed, int grayval);

        // Stereoscopic warping
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWarpStereoscopic")]
        internal static extern IntPtr pixWarpStereoscopic(HandleRef pixs, int zbend, int zshiftt, int zshiftb, int ybendt, int ybendb, int redleft);

        // Linear and quadratic horizontal stretching
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontal")]
        internal static extern IntPtr pixStretchHorizontal(HandleRef pixs, int dir, int type, int hmax, int operation, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontalSampled")]
        internal static extern IntPtr pixStretchHorizontalSampled(HandleRef pixs, int dir, int type, int hmax, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStretchHorizontalLI")]
        internal static extern IntPtr pixStretchHorizontalLI(HandleRef pixs, int dir, int type, int hmax, int incolor);

        // Quadratic vertical shear
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShear")]
        internal static extern IntPtr pixQuadraticVShear(HandleRef pixs, int dir, int vmaxt, int vmaxb, int operation, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShearSampled")]
        internal static extern IntPtr pixQuadraticVShearSampled(HandleRef pixs, int dir, int vmaxt, int vmaxb, int incolor);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixQuadraticVShearLI")]
        internal static extern IntPtr pixQuadraticVShearLI(HandleRef pixs, int dir, int vmaxt, int vmaxb, int incolor);

        // Stereo from a pair of images
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixStereoFromPair")]
        internal static extern IntPtr pixStereoFromPair(HandleRef pix1, HandleRef pix2, float rwt, float gwt, float bwt);
        #endregion

        #region watershed.c - DONE
        // Top-level
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedCreate")]
        internal static extern IntPtr wshedCreate(HandleRef pixs, HandleRef pixm, int mindepth, bool debugflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedDestroy")]
        internal static extern void wshedDestroy(ref IntPtr pwshed);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedApply")]
        internal static extern bool wshedApply(HandleRef wshed);

        // Output
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedBasins")]
        internal static extern bool wshedBasins(HandleRef wshed, ref IntPtr ppixa, ref IntPtr pnalevels);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedRenderFill")]
        internal static extern IntPtr wshedRenderFill(HandleRef wshed);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "wshedRenderColors")]
        internal static extern IntPtr wshedRenderColors(HandleRef wshed);
        #endregion

        #region webpio.c
        // Reading WebP
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadStreamWebP")]
        internal static extern IntPtr pixReadStreamWebP(IntPtr fp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixReadMemWebP")]
        internal static extern IntPtr pixReadMemWebP(IntPtr filedata, IntPtr filesize);

        // Reading WebP header
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderWebP")]
        internal static extern int readHeaderWebP([MarshalAs(UnmanagedType.AnsiBStr)] string filename, out int pw, out int ph, out int pspp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "readHeaderMemWebP")]
        internal static extern int readHeaderMemWebP(IntPtr data, IntPtr size, out int pw, out int ph, out int pspp);

        // Writing WebP
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteWebP")]
        internal static extern int pixWriteWebP([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pixs, int quality, int lossless);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStreamWebP")]
        internal static extern int pixWriteStreamWebP(IntPtr fp, HandleRef pixs, int quality, int lossless);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMemWebP")]
        internal static extern int pixWriteMemWebP(out IntPtr pencdata, IntPtr pencsize, HandleRef pixs, int quality, int lossless);
        #endregion

        #region writefile.c - DONE
        // High-level procedures for writing images to file:
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixaWriteFiles")]
        internal static extern bool pixaWriteFiles([MarshalAs(UnmanagedType.AnsiBStr)] string rootname, HandleRef pixa, ImageFileFormatTypes format);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWrite")]
        internal static extern bool pixWrite([MarshalAs(UnmanagedType.AnsiBStr)] string fname, HandleRef pix, ImageFileFormatTypes format);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteAutoFormat")]
        internal static extern bool pixWriteAutoFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteStream")]
        internal static extern bool pixWriteStream(IntPtr fp, HandleRef pix, ImageFileFormatTypes format);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteImpliedFormat")]
        internal static extern bool pixWriteImpliedFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename, HandleRef pix, int quality, int progressive);

        // Selection of output format if default is requested
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixChooseOutputFormat")]
        internal static extern ImageFileFormatTypes pixChooseOutputFormat(HandleRef pix);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getImpliedFileFormat")]
        internal static extern ImageFileFormatTypes getImpliedFileFormat([MarshalAs(UnmanagedType.AnsiBStr)] string filename);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixGetAutoFormat")]
        internal static extern bool pixGetAutoFormat(HandleRef pix, out ImageFileFormatTypes pformat);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "getFormatExtension")]
        internal static extern IntPtr getFormatExtension(ImageFileFormatTypes format);

        // Write to memory
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixWriteMem")]
        internal static extern bool pixWriteMem(out IntPtr pdata, out IntPtr psize, HandleRef pix, ImageFileFormatTypes format);

        // Image display for debugging
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_fileDisplay")]
        internal static extern bool l_fileDisplay([MarshalAs(UnmanagedType.AnsiBStr)] string fname, int x, int y, float scale);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplay")]
        internal static extern bool pixDisplay(HandleRef pixs, int x, int y);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWithTitle")]
        internal static extern bool pixDisplayWithTitle(HandleRef pixs, int x, int y, [MarshalAs(UnmanagedType.AnsiBStr)] string title, bool dispflag);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiled")]
        internal static extern bool pixSaveTiled(HandleRef pixs, HandleRef pixa, float scalefactor, bool newrow, int space, int dp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiledOutline")]
        internal static extern bool pixSaveTiledOutline(HandleRef pixs, HandleRef pixa, float scalefactor, bool newrow, int space, int linewidth, int dp);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixSaveTiledWithText")]
        internal static extern bool pixSaveTiledWithText(HandleRef pixs, HandleRef pixa, int outwidth, bool newrow, int space, int linewidth, HandleRef bmf, [MarshalAs(UnmanagedType.AnsiBStr)] string textstr, uint val, FlagsForAddingTextToAPix location);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "l_chooseDisplayProg")]
        internal static extern void l_chooseDisplayProg(FlagsForSelectingDisplayProgram selection);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "setLeptDebugOK")]
        internal static extern void setLeptDebugOK(int allow);

        // Deprecated pix output for debugging
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWrite")]
        internal static extern bool pixDisplayWrite(HandleRef pixs, int reduction);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayWriteFormat")]
        internal static extern bool pixDisplayWriteFormat(HandleRef pixs, int reduction, ImageFileFormatTypes format);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "pixDisplayMultiple")]
        internal static extern bool pixDisplayMultiple(int res, float scalefactor, [MarshalAs(UnmanagedType.AnsiBStr)] string fileout);
        #endregion

        #region zlibmem.c
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "zlibCompress")]
        internal static extern IntPtr zlibCompress(IntPtr datain, IntPtr nin, out IntPtr pnout);
        [DllImport(leptonicaDllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "zlibUncompress")]
        internal static extern IntPtr zlibUncompress(IntPtr datain, IntPtr nin, out IntPtr pnout);
        #endregion
    }
}
