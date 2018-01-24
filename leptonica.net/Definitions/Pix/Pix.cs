using System;

namespace Leptonica
{
    /// <summary>
    /// Basic Pix
    /// </summary>
    public class Pix : LeptonicaObjectBase, IDisposable, ICloneable
    {
        public Pix(IntPtr pointer) : base(pointer) { }

        public bool Write(string filename, ImageFileFormatTypes format)
        {
            return WriteFile.pixWrite(filename, this, format);
        }

        public int Width
        {
            get
            {
                return this.pixGetWidth();
            }
            set
            {
                if (this.pixSetWidth(value))
                {
                    throw new Exception("An error occurred while trying to set the width.");
                }
            }
        }

        public int Height
        {
            get
            {
                return this.pixGetHeight();
            }
            set
            {
                if (this.pixSetHeight(value))
                {
                    throw new Exception("An error occurred while trying to set the height.");
                }
            }
        }

        public int Depth
        {
            get
            {
                return this.pixGetDepth();
            }
            set
            {
                if (this.pixSetDepth(value))
                {
                    throw new Exception("An error occurred while trying to set the depth.");
                }
            }
        }

        public int Spp
        {
            get
            {
                return this.pixGetSpp();
            }
            set
            {
                if (this.pixSetSpp(value))
                {
                    throw new Exception("An error occurred while trying to set the spp.");
                }
            }
        }

        public int Wpl
        {
            get
            {
                return this.pixGetWpl();
            }
            set
            {
                if (this.pixSetWpl(value))
                {
                    throw new Exception("An error occurred while trying to set the wpl.");
                }
            }
        }

        public int RefCount
        {
            get
            {
                return this.pixGetRefcount();
            }
            set
            {
                if (this.pixChangeRefcount(value))
                {
                    throw new Exception("An error occurred while trying to change the refcount.");
                }
            }
        }

        public int XRes
        {
            get
            {
                return this.pixGetXRes();
            }
            set
            {
                if (this.pixSetXRes(value))
                {
                    throw new Exception("An error occurred while trying to set the x res.");
                }
            }
        }

        public int YRes
        {
            get
            {
                return this.pixGetYRes();
            }
            set
            {
                if (this.pixSetYRes(value))
                {
                    throw new Exception("An error occurred while trying to set the y res.");
                }
            }
        }

        public ImageFileFormatTypes InputFormat
        {
            get
            {
                return this.pixGetInputFormat();
            }
            set
            {
                if (this.pixSetInputFormat(value))
                {
                    throw new Exception("An error occurred while trying to set the input format.");
                }
            }
        }

        public PixColormap Colormap
        {
            get
            {
                return this.pixGetColormap();
            }
            set
            {
                if (this.pixSetColormap(value))
                {
                    throw new Exception("An error occurred while trying to set the colormap.");
                }
            }
        }


        public static Pix Read(string filename)
        {
            return ReadFile.pixRead(filename);
        }

        public static Pix Create(int width, int height, int depth)
        {
            return Pix1.pixCreate(width, height, depth);
        }

        public static explicit operator Pix(IntPtr pointer)
        {
            return new Pix(pointer);
        }

        public void Dispose()
        {
            this.pixDestroy();
        }

        public object Clone()
        {
            return this.pixCopy(null);
        }
    }
}
