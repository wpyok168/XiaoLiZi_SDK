using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDK.Enum;

namespace SDK.Events
{
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PrivateMessageEvent  //128个字节0x80
    {
        //发送人QQ
        /// <summary>
        /// 发送人QQ
        /// </summary>
        public long SenderQQ;
        //框架QQ
        /// <summary>
        /// 框架QQ
        /// </summary>
        public long ThisQQ;
        //消息Req
        /// <summary>
        /// 消息Req
        /// </summary>
        public uint MessageReq;
        //消息Seq
        /// <summary>
        /// 消息Seq
        /// </summary>
        public long MessageSeq;
        //消息接收时间
        /// <summary>
        /// 消息接收时间
        /// </summary>
        public uint MessageReceiveTime;
        //消息群号 当为群临时会话时可取
        /// <summary>
        /// 消息群号 当为群临时会话时可取
        /// </summary>
        public long MessageGroupQQ;
        //消息发送时间
        /// <summary>
        /// 消息发送时间
        /// </summary>
        public uint MessageSendTime;
        //消息Random
        /// <summary>
        /// 消息Random
        /// </summary>
        public long MessageRandom;
        //消息分片序列
        /// <summary>
        /// 消息分片序列
        /// </summary>
        public uint MessageClip;
        //消息分片数量
        /// <summary>
        /// 消息分片数量
        /// </summary>
        public uint MessageClipCount;
        //消息分片标识
        /// <summary>
        /// 消息分片标识
        /// </summary>
        public long MessageClipID;
        //消息内容
        /// <summary>
        /// 消息内容
        /// </summary>
        //public string MessageContent;
        [MarshalAs(UnmanagedType.LPStr)]
        public string MessageContent;
        //气泡Id
        /// <summary>
        /// 气泡Id
        /// </summary>
        public uint BubbleID;
        // 消息类型
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageTypeEnum MessageType;
        //消息子类型  
        /// <summary>
        /// 消息子类型 
        /// </summary>
        public MessageSubTypeEnum MessageSubType;
        //消息子临时类型 0 群 1 讨论组 129 腾讯公众号 201 QQ咨询
        /// <summary>
        /// 消息子临时类型 0 群 1 讨论组 129 腾讯公众号 201 QQ咨询
        /// </summary>
        public MessageSubTypeEnum MessageSubTemporaryType;
        //红包类型
        /// <summary>
        /// 红包类型<para> 2已转入余额 4点击收款 10红包</para>
        /// </summary>
        public uint RedEnvelopeType;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //会话token
        /// <summary>
        /// 会话token
        /// </summary>
        //[MarshalAs(UnmanagedType.LPStr)]
        public IntPtr SessionToken;
        //来源事件QQ
        /// <summary>
        /// 来源事件QQ
        /// </summary>
        public long SourceEventQQ;
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        //来源事件QQ昵称
        /// <summary>
        /// 来源事件QQ昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SourceEventQQName;
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        //文件Id
        /// <summary>
        /// 文件Id
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileID;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //文件Md5
        /// <summary>
        /// 文件Md5
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileMD5;
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        //文件名
        /// <summary>
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileName;
        //消息群Id
        /// <summary>
        /// 消息群Id<para>当为群临时会话时可取</para>
        /// </summary>
        public long MsgGroupId; //文件大小FileSize 调整为 消息群Id
    }
}
