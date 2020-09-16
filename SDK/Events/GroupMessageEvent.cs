using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDK.Enum;

namespace SDK.Events
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupMessageEvent
    {
        // 发送人QQ
        /// <summary>
        /// 发送人QQ
        /// </summary>
        public long SenderQQ;
        // 框架QQ
        /// <summary>
        /// 框架QQ
        /// </summary>
        public long ThisQQ;
        // 消息Req
        /// <summary>
        /// 消息Req
        /// </summary>
        public int MessageReq;
        // 消息接收时间
        /// <summary>
        /// 消息接收时间
        /// </summary>
        public int MessageReceiveTime;
        // 消息群号
        /// <summary>
        /// 消息群号
        /// </summary>
        public long MessageGroupQQ;
        // 消息来源群名（貌似失效了）etext SourceGroupName = nullptr;
        /// <summary>
        /// 消息来源群名（貌似失效了）etext SourceGroupName = nullptr;
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SourceGroupName;
        // 发送人群名片 没有名片则为空白etext SenderNickname = nullptr;
        /// <summary>
        /// 发送人群名片 没有名片则为空白
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SenderNickname;
        // 消息发送时间
        /// <summary>
        /// 消息发送时间
        /// </summary>
        public int MessageSendTime;
        // 消息Random
        /// <summary>
        /// 消息Random
        /// </summary>
        public long MessageRandom;
        // 消息分片序列
        /// <summary>
        /// 消息分片序列
        /// </summary>
        public int MessageClip;
        // 消息分片数量
        /// <summary>
        /// 消息分片数量
        /// </summary>
        public int MessageClipCount;
        // 消息分片标识
        /// <summary>
        /// 消息分片标识
        /// </summary>
        public long MessageClipID;
        // 消息类型
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageTypeEnum MessageType;
        // 发送人群头衔 etext SenderTitle = nullptr;
        /// <summary>
        /// 发送人群头衔
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SenderTitle;
        // 消息内容 etext MessageContent = nullptr;
        /// <summary>
        /// 消息内容
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string MessageContent;
        // 回复对象消息内容 如果是回复消息 etext ReplyMessageContent = nullptr;
        /// <summary>
        /// 回复对象消息内容 如果是回复消息
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string ReplyMessageContent;
        // 发送者气泡ID
        /// <summary>
        /// 发送者气泡ID
        /// </summary>
        public int BubbleID;
        // 框架QQ匿名Id，用于区分别人和自己(当天从未使用过匿名则为0)
        /// <summary>
        /// 框架QQ匿名Id
        /// </summary>
        public int ThisQQAnonymousID;
        // 保留参数，请勿使用
        /// <summary>
        /// 保留参数，请勿使用
        /// </summary>
        public int reserved_;
        // 文件Id
        /// <summary>
        /// 文件Id
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileID;
        // 文件Md5
        /// <summary>
        /// 文件Md5
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileMD5;
        // 文件名
        /// <summary>
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileName;
        // 文件大小
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize;
        // 消息AppID
        /// <summary>
        /// 消息AppID
        /// </summary>
        public int MessageAppID;
    }
}
