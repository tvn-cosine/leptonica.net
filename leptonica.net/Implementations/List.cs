using System;
using System.Runtime.InteropServices;

namespace Leptonica
{
    public static class List
    {
        // Inserting and removing elements 
        public static void listDestroy(this DoubleLinkedList phead)
        {
            if (null == phead)
            {
                throw new ArgumentNullException("pbox cannot be null");
            }

            var pointer = (IntPtr)phead;

            Native.DllImports.listDestroy(ref pointer);
        }

        public static int listAddToTail(out DoubleLinkedList phead, out DoubleLinkedList ptail, IntPtr data)
        {
            throw new NotImplementedException();
        }

        public static int listInsertBefore(out DoubleLinkedList phead, DoubleLinkedList elem, IntPtr data)
        {
            throw new NotImplementedException();
        }

        public static int listInsertAfter(out DoubleLinkedList phead, DoubleLinkedList elem, IntPtr data)
        {
            throw new NotImplementedException();
        }

        public static IntPtr listRemoveElement(out DoubleLinkedList phead, DoubleLinkedList elem)
        {
            throw new NotImplementedException();
        }

        public static IntPtr listRemoveFromHead(out DoubleLinkedList phead)
        {
            throw new NotImplementedException();
        }

        public static IntPtr listRemoveFromTail(out DoubleLinkedList phead, out DoubleLinkedList ptail)
        {
            throw new NotImplementedException();
        }


        // Other list operations 
        public static DoubleLinkedList listFindElement(this DoubleLinkedList head, IntPtr data)
        {
            if (null == head)
            {
                throw new ArgumentNullException("head cannot be null");
            }

            var pointer = Native.DllImports.listFindElement((HandleRef)head, data);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DoubleLinkedList(pointer);
            }
        }

        public static DoubleLinkedList listFindTail(this DoubleLinkedList head)
        {
            if (null == head)
            {
                throw new ArgumentNullException("head cannot be null");
            }

            var pointer = Native.DllImports.listFindTail((HandleRef)head);
            if (IntPtr.Zero == pointer)
            {
                return null;
            }
            else
            {
                return new DoubleLinkedList(pointer);
            }
        }


        public static int listGetCount(this DoubleLinkedList head)
        {
            if (null == head)
            {
                throw new ArgumentNullException("head cannot be null");
            }

            return Native.DllImports.listGetCount((HandleRef)head); 
        }

        public static int listReverse(this DoubleLinkedList phead)
        {
            throw new NotImplementedException();
        }

        public static int listJoin(this DoubleLinkedList phead1, out DoubleLinkedList phead2)
        {
            throw new NotImplementedException();
        }
    }
}
