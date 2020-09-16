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
    public struct MessageEvent
    {
        // 框架QQ
        /// <summary>
        /// 框架QQ
        /// </summary>
        public long ThisQQ;
        /// <summary>
        /// 消息群号
        /// </summary>
        public long SourceMessageGroupQQ;
        /// <summary>
        /// 操作QQ
        /// </summary>
        public long OperationEventQQ;
        //触发QQ
        /// <summary>
        /// 触发QQ
        /// </summary>
        public long SourceEventQQ;
        //消息Seq
        /// <summary>
        /// 消息Seq
        /// </summary>
        public long MessageSeq;
        //消息时间戳
        /// <summary>
        /// 消息时间戳
        /// </summary>
        public uint MessageSendTime;
        //来源群名
        /// <summary>
        /// 来源群名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SourceGroupName;
        //操作QQ昵称
        /// <summary>
        /// 操作QQ昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string OperationQQName;
        //触发QQ昵称
        /// <summary>
        /// 触发QQ昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SourceQQName;
        //消息内容
        /// <summary>
        /// 消息内容
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string MessageContent;
        // 消息类型
        /// <summary>
        /// 消息类型
        /// </summary>
        public EventTypeEnum MessageType;
        //消息子类型  
        /// <summary>
        /// 消息类型
        /// </summary>
        public uint MessageSubType;
    }
}
