using SDK.Core;
using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Events
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct EventTypeBase
    {

        // 框架QQ
        /// <summary>
        /// 框架QQ
        /// </summary>
        public long ThisQQ;
        // 来源群号
        /// <summary>
        /// 来源群号
        /// </summary>
        public long SourceGroupQQ;
        // 操作QQ
        /// <summary>
        /// v
        /// </summary>
        public long OperateQQ;
        // 触发QQ
        /// <summary>
        /// 触发QQ
        /// </summary>
        public long TriggerQQ;
        // 消息Seq
        /// <summary>
        /// 消息Seq
        /// </summary>
        public long MessageSeq;
        // 消息时间戳
        /// <summary>
        /// 消息时间戳
        /// </summary>
        public int MessageTimestamp;
        // 来源群名
        /// <summary>
        /// 来源群名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SourceGroupName;
        // 操作QQ昵称
        /// <summary>
        /// 操作QQ昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OperateQQName;
        // 触发QQ昵称
        /// <summary>
        /// 触发QQ昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string TriggerQQName;
        // 事件内容
        /// <summary>
        /// 事件内容
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string MessageContent;
        // 事件类型
        /// <summary>
        /// 事件类型
        /// </summary>
        public EventTypeEnum EventType;
        // 事件子类型
        /// <summary>
        /// 事件子类型
        /// </summary>
        public int EventSubType;
    }

}
