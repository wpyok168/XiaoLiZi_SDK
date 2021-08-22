using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XLZTextCodecnalysis
    {
        public delegate void start();

        public delegate void stop();

        public delegate int Parsing([MarshalAs(UnmanagedType.LPStr)] string textcode, ref EarrayList[] intPtr);

        public delegate string GetParameterValue([MarshalAs(UnmanagedType.LPStr)] string textcode, [MarshalAs(UnmanagedType.LPStr)] string ParameterName);

        public delegate bool IsParameter([MarshalAs(UnmanagedType.LPStr)] string textcode, [MarshalAs(UnmanagedType.LPStr)] string ParameterName);

        public delegate int GetParameterList([MarshalAs(UnmanagedType.LPStr)] string textcode, ref EarrayList[] ParameterList);

        public delegate IntPtr GetCommand([MarshalAs(UnmanagedType.LPStr)]string textcode);

        public delegate string GetTextCode(EarrayList[] textCodeResult);
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EArrayByClass
    {
        [MarshalAs(UnmanagedType.ByValArray,SizeConst =8)]
        public IntPtr[] intPtrs;
    }
}
