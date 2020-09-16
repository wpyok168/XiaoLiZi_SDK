using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OrderDetaildDataList
    {
        public OrderDetail orderDetail;
    }
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct OrderDetail
    {
        // 订单时间
        /// <summary>
        /// 订单时间
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OrderTime;
        // 订单说明
        /// <summary>
        /// 订单说明
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OrderDescription;
        // 订单类名
        /// <summary>
        /// 订单类名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OrderClassification;
        // 订单类型
        /// <summary>
        /// 订单类型
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OrderType;
        // 订单手续费
        /// <summary>
        /// 订单手续费
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OrderCommission;
        // 操作人QQ
        /// <summary>
        /// 操作人QQ
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OperatorQQ;
        // 操作人昵称
        /// <summary>
        /// 操作人昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OperatorName;
        // 接收人QQ
        /// <summary>
        /// 接收人QQ
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string ReceiverQQ;
        // 接收人昵称
        /// <summary>
        /// 接收人昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string ReceiverName;
        // 操作金额
        /// <summary>
        /// 操作金额
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OperateAmount;
    }
}
