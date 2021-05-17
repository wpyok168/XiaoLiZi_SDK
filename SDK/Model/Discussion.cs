using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 讨论组信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Discussion
    {
        /// <summary>
        /// 讨论组Id
        /// </summary>
        public int id;
        /// <summary>
        /// 成员总数
        /// </summary>
        public int count;
        /// <summary>
        /// 加入时间戳
        /// </summary>
        public long addTimestamp;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EarrayList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 100)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }
}
