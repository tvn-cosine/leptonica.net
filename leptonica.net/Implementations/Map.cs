using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class Map
    {
        // Interface to(a) map using a general key and storing general values
        public static L_AMap l_amapCreate(int keytype)
        {
            var pointer = Native.DllImports.l_amapCreate(keytype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap(pointer);
            }
        }

        public static Rb_Type l_amapFind(this L_AMap m, Rb_Type key)
        {
            if (null == m
             || null == key)
            {
                throw new ArgumentNullException("m, key cannot be null.");
            }

            var pointer = Native.DllImports.l_amapFind((HandleRef)m, (HandleRef)key);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Rb_Type(pointer);
            }
        }

        public static void l_amapInsert(this L_AMap m, Rb_Type key, Rb_Type value)
        {
            if (null == m
             || null == key
             || null == value)
            {
                throw new ArgumentNullException("m, key, value cannot be null.");
            }

            Native.DllImports.l_amapInsert((HandleRef)m, (HandleRef)key, (HandleRef)value);
        }

        public static void l_amapDelete(this L_AMap m, Rb_Type key)
        {
            if (null == m
             || null == key)
            {
                throw new ArgumentNullException("m, key cannot be null.");
            }

            Native.DllImports.l_amapDelete((HandleRef)m, (HandleRef)key);
        }

        public static void l_amapDestroy(this L_AMap pm)
        {
            if (null == pm)
            {
                throw new ArgumentNullException("pm cannot be null");
            }

            var pointer = (IntPtr)pm;

            Native.DllImports.l_amapDestroy(ref pointer);
        }

        public static L_AMap_Node l_amapGetFirst(this L_AMap m)
        {
            if (null == m)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_amapGetFirst((HandleRef)m);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap_Node(pointer);
            }
        }

        public static L_AMap_Node l_amapGetNext(this L_AMap_Node n)
        {
            if (null == n)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_amapGetNext((HandleRef)n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap_Node(pointer);
            }
        }

        public static L_AMap_Node l_amapGetLast(this L_AMap m)
        {
            if (null == m)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_amapGetLast((HandleRef)m);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap_Node(pointer);
            }
        }

        public static L_AMap_Node l_amapGetPrev(this L_AMap_Node n)
        {
            if (null == n)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_amapGetPrev((HandleRef)n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_AMap_Node(pointer);
            }
        }

        public static int l_amapSize(this L_AMap m)
        {
            if (null == m)
            {
                throw new ArgumentNullException("pm cannot be null");
            }

            return Native.DllImports.l_amapSize((HandleRef)m);
        }

        // Interface to(a) set using a general key
        public static L_ASet l_asetCreate(int keytype)
        {
            var pointer = Native.DllImports.l_asetCreate(keytype);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet(pointer);
            }
        }

        public static Rb_Type l_asetFind(this L_ASet s, Rb_Type key)
        {
            if (null == s
             || null == key)
            {
                throw new ArgumentNullException("s, key cannot be null.");
            }

            var pointer = Native.DllImports.l_asetFind((HandleRef)s, (HandleRef)key);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new Rb_Type(pointer);
            }
        }

        public static void l_asetInsert(this L_ASet s, Rb_Type key)
        {
            if (null == s
             || null == key)
            {
                throw new ArgumentNullException("s, key cannot be null.");
            }

            Native.DllImports.l_asetInsert((HandleRef)s, (HandleRef)key);
        }

        public static void l_asetDelete(this L_ASet s, Rb_Type key)
        {
            if (null == s
             || null == key)
            {
                throw new ArgumentNullException("m, key cannot be null.");
            }

            Native.DllImports.l_asetDelete((HandleRef)s, (HandleRef)key);
        }

        public static void l_asetDestroy(this L_ASet ps)
        {
            if (null == ps)
            {
                throw new ArgumentNullException("ps cannot be null");
            }

            var pointer = (IntPtr)ps;

            Native.DllImports.l_asetDestroy(ref pointer);
        }

        public static L_ASet_Node l_asetGetFirst(this L_ASet s)
        {
            if (null == s)
            {
                throw new ArgumentNullException("s cannot be null.");
            }

            var pointer = Native.DllImports.l_asetGetFirst((HandleRef)s);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet_Node(pointer);
            }
        }

        public static L_ASet_Node l_asetGetNext(this L_ASet_Node n)
        {
            if (null == n)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_asetGetNext((HandleRef)n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet_Node(pointer);
            }
        }

        public static L_ASet_Node l_asetGetLast(this L_ASet s)
        {
            if (null == s)
            {
                throw new ArgumentNullException("s cannot be null.");
            }

            var pointer = Native.DllImports.l_asetGetLast((HandleRef)s);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet_Node(pointer);
            }
        }

        public static L_ASet_Node l_asetGetPrev(this L_ASet_Node n)
        {
            if (null == n)
            {
                throw new ArgumentNullException("m cannot be null.");
            }

            var pointer = Native.DllImports.l_asetGetPrev((HandleRef)n);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new L_ASet_Node(pointer);
            }
        }

        public static int l_asetSize(this L_ASet s)
        {
            if (null == s)
            {
                throw new ArgumentNullException("s cannot be null");
            }

            return Native.DllImports.l_amapSize((HandleRef)s);
        }
    }
}
