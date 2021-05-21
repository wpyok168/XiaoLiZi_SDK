using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupCollectionInfoPD
    {
        public GroupCollectionInfo groupCollectionInfo;
    }
    /// <summary>
    /// 群收款信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupCollectionInfo
    {
        /// <summary>
        /// 订单状态<para>1:等待支付,2:已完成,3:已主动结束</para>
        /// </summary>
        public int orderstate;
        /// <summary>
        /// 收款发起人
        /// </summary>
        public long targetQQ;
        /// <summary>
        /// 收款来源群
        /// </summary>
        public long GroupQQ;
        /// <summary>
        /// 收款留言
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string message;
        /// <summary>
        /// 目标金额<para>群收款订单目标总金额(单位分)</para>
        /// </summary>
        public int Amount;
        /// <summary>
        /// 已支付金额<para>群收款订单已支付完成金额(单位分)</para>
        /// </summary>
        public int paidAmount;
        /// <summary>
        /// 收款支付详情
        /// </summary>
        public IntPtr payerInfo;
    }

    /// <summary>
    /// 付款者信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PayerInfo
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        public long QQ;
        /// <summary>
        /// 应支付金额
        /// </summary>
        public int Amount;
        /// <summary>
        /// 支付状态<para>0:未支付,2:已支付</para>
        /// </summary>
        public int PaymentStatus;
    }

    /// <summary>
    /// 群收款信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupCollectionInfom
    {
        /// <summary>
        /// 订单状态<para>1:等待支付,2:已完成,3:已主动结束</para>
        /// </summary>
        public int orderstate;
        /// <summary>
        /// 收款发起人
        /// </summary>
        public long targetQQ;
        /// <summary>
        /// 收款来源群
        /// </summary>
        public long GroupQQ;
        /// <summary>
        /// 收款留言
        /// </summary>
        public string message;
        /// <summary>
        /// 目标金额<para>群收款订单目标总金额(单位分)</para>
        /// </summary>
        public int Amount;
        /// <summary>
        /// 已支付金额<para>群收款订单已支付完成金额(单位分)</para>
        /// </summary>
        public int paidAmount;
        /// <summary>
        /// 收款支付详情
        /// </summary>
        public List<PayerInfo> payerInfo;
    }
}
