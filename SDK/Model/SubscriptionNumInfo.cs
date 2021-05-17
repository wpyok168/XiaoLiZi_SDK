using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 订阅号信
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Subscription
    {
        /// <summary>
        /// 订阅号Id
        /// </summary>
        public long id;
        /// <summary>
        /// 昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        /// <summary>
        /// 公众号
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string gzh;
        /// <summary>
        /// 信息简介
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string desc;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SubscriptionList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }
}
