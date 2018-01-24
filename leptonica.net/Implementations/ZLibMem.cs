using System; 

namespace Leptonica
{
    public static class ZLibMem
    {
        /// <summary>
        /// (1) We repeatedly read in and fill up an input buffer,
        ///     compress the data, and read it back out.  zlib
        ///     uses two byte buffers internally in the z_stream
        ///     data structure.  We use the bbuffers to feed data
        ///     into the fixed bufferin, and feed it out of bufferout,
        ///     in the same way that a pair of streams would normally
        ///     be used if the data were being read from one file
        ///     and written to another.  This is done iteratively,
        ///     compressing L_BUF_SIZE bytes of input data at a time.
        /// </summary>
        /// <param name="datain">byte buffer with input data</param>
        /// <param name="nin">number of bytes of input data</param>
        /// <param name="pnout">number of bytes of output data</param>
        /// <returns>dataout compressed data, or NULL on error</returns>
        public static IntPtr zlibCompress(IntPtr datain, IntPtr nin, out IntPtr pnout)
        {
            if (IntPtr.Zero == datain
             || IntPtr.Zero == nin)
            {
                throw new ArgumentNullException("datain, nin cannot be null");
            }

            return Native.DllImports.zlibCompress(datain, nin, out pnout);
        }

        /// <summary>
        /// (1) See zlibCompress().
        /// </summary>
        /// <param name="datain">byte buffer with compressed input data</param>
        /// <param name="nin">number of bytes of input data</param>
        /// <param name="pnout">number of bytes of output data</param>
        /// <returns>uncompressed data, or NULL on error</returns>
        public static IntPtr zlibUncompress(IntPtr datain, IntPtr nin, IntPtr pnout)
        {
            if (IntPtr.Zero == datain
             || IntPtr.Zero == nin)
            {
                throw new ArgumentNullException("datain, nin cannot be null");
            }

            return Native.DllImports.zlibUncompress(datain, nin, out pnout);
        }
    }
}
