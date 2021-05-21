using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 待付款者信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PendingPayerinfo
    {
        /// <summary>
        /// 定义待被收款者的QQ
        /// </summary>
        public long QQ;
        /// <summary>
        /// 待付款金额<para>定义待被收款者的收取金额,单位为分</para>
        /// </summary>
        public int Amount;
    }
}
