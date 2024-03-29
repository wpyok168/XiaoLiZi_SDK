﻿using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 合并信息转发<para>群消息</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class GroupMessageInfo
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
        /// <summary>
        /// 群聊等级
        /// </summary>
        public int GroupChatLevel;
        /// <summary>
        /// 挂件Id
        /// </summary>
        public int PendantID;
        /// <summary>
        /// 匿名昵称：消息是匿名消息时,此为对方的匿名昵称,否则为空
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string AnonymousNickname;
        /// <summary>
        /// 匿名标识：可用于禁言等<para>此字段需要开发者自行调用API处理返回byte[]<see cref=""/></para>
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray,SizeConst =1024*100)]
        public byte[] AnonymousFalg;
        /// <summary>
        /// 保留参数
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string ReservedParameters;

        /// <summary>
        /// 框架QQ匿名Id：用于判断框架开启匿名时,收到的消息是否为自身的消息
        /// </summary>
        public long AnonymousId;
        /// <summary>
        /// 字体Id
        /// </summary>
        public int FontId;
    }
    
        /// <summary>
    /// 获取转发消息记录详情 lerio.cn
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupMessageInfoDatList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 10)]
        public byte[] pAddrList;//每个元素的指针
    }
}
