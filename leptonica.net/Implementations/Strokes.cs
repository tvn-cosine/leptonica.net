using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Strokes
    {
        // Stroke parameter measurement
        public static int pixFindStrokeLength(this Pix pixs, IntPtr tab8, out int plength)
        {
            throw new NotImplementedException();
        }

        public static int pixFindStrokeWidth(this Pix pixs, float thresh, IntPtr tab8, out float pwidth, out Numa pnahisto)
        {
            throw new NotImplementedException();
        }

        public static Numa pixaFindStrokeWidth(this Pixa pixa, float thresh, IntPtr tab8, int debug)
        {
            throw new NotImplementedException();
        }


        // Stroke width regulation
        public static Pixa pixaModifyStrokeWidth(this Pixa pixas, float targetw)
        {
            throw new NotImplementedException();
        }

        public static Pix pixModifyStrokeWidth(this Pix pixs, float width, float targetw)
        {
            throw new NotImplementedException();
        }

        public static Pixa pixaSetStrokeWidth(this Pixa pixas, int width, int thinfirst, int connectivity)
        {
            throw new NotImplementedException();
        }

        public static Pix pixSetStrokeWidth(this Pix pixs, int width, int thinfirst, int connectivity)
        {
            throw new NotImplementedException();
        }

    }
}
