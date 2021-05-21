using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EArrayByObject
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public IntPtr[] obj;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EarrayList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024*100)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }

}
