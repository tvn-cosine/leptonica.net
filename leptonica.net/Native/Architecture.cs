using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Leptonica.Native
{
    /// <summary>
    /// Less than is &lt;
    /// Greater than is &gt;
    /// Ampersand is &amp;
    /// </summary>
    public static class Architecture
    {
        public static bool is64BitProcess
        {
            get
            {
                return IntPtr.Size == 8;
            }
        }

        public static bool is64BitOperatingSystem
        {
            get
            {
                return is64BitProcess || InternalCheckIsWow64();
            }
        }

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1)
             || Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool isWow64;
                    if (!IsWow64Process(p.Handle, out isWow64))
                    {
                        return false;
                    }
                    else
                    {
                        return isWow64;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool wow64Process);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
    }
}
