using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class RecogDid
    {
        // Top-level identification
        public static Boxa recogDecode(L_Recog recog, Pix pixs, int nlevels, out Pix ppixdb)
        {
            throw new NotImplementedException();
        }


        // Create/destroy temporary DID data
        public static int recogCreateDid(this L_Recog recog, Pix pixs)
        {
            throw new NotImplementedException();
        }

        public static int recogDestroyDid(this L_Recog recog)
        {
            throw new NotImplementedException();
        }


        // Various helpers
        public static int recogDidExists(this L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static L_Rdid recogGetDid(this L_Recog recog)
        {
            throw new NotImplementedException();
        }

        public static int recogSetChannelParams(this L_Recog recog, int nlevels)
        {
            throw new NotImplementedException();
        }
    }
}
