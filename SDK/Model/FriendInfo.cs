using SDK.Enum;
using SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FriendDataList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GetFriendDataList
    {
        //public int index;
        public FriendInfo friendInfo;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FriendInfo
    {
        // 邮箱
        /// <summary>
        /// 邮箱
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Email;
        // 账号
        /// <summary>
        /// 账号
        /// </summary>
        public long QQNumber;
        // 昵称
        /// <summary>
        /// 昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Name;
        // 备注
        /// <summary>
        /// 备注
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Note;
        // 在线状态 只能使用[取好友列表]获取
        /// <summary>
        /// 在线状态 只能使用[取好友列表]获取
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Status;
        // 赞数量 只能使用[查询好友信息]获取
        /// <summary>
        /// 赞数量 只能使用[查询好友信息]获取
        /// </summary>
        public uint Likes;
        // 签名 只能使用[查询好友信息]获取
        /// <summary>
        /// 签名 只能使用[查询好友信息]获取
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Signature;
        // 性别 255: 隐藏, 0: 男, 1: 女
        /// <summary>
        /// 性别 255: 隐藏, 0: 男, 1: 女
        /// </summary>
        public uint Gender;
        // Q等级 只能使用[查询好友信息]获取
        /// <summary>
        /// Q等级 只能使用[查询好友信息]获取
        /// </summary>
        public uint Level;
        // 年龄 只能使用[查询好友信息]获取
        /// <summary>
        /// 年龄 只能使用[查询好友信息]获取
        /// </summary>
        public uint Age;
        // 国家 只能使用[查询好友信息]获取
        /// <summary>
        /// 国家 只能使用[查询好友信息]获取
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Nation;
        // 省份 只能使用[查询好友信息]获取
        /// <summary>
        /// 省份 只能使用[查询好友信息]获取
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Province;
        // 城市 只能使用[查询好友信息]获取
        /// <summary>
        /// 城市 只能使用[查询好友信息]获取
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string City;
        // 服务列表 只能使用[查询好友信息]获取
        /// <summary>
        /// 服务列表 只能使用[查询好友信息]获取
        /// </summary>
        public ServiceInfo serviceInfo;
        // 连续在线天数 只能使用[查询好友信息]获取
        /// <summary>
        /// 连续在线天数 只能使用[查询好友信息]获取
        /// </summary>
        public uint ContinuousOnlineTime;
        // QQ达人 只能使用[查询好友信息]获取
        /// <summary>
        /// QQ达人 只能使用[查询好友信息]获取
        /// <para>2.7.1RC9 SDK前 是QQ达人</para>
        /// <para>2.7.1RC9 SDK后含2.7.1RC9 是所属分组名</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string QQTalent;
        // 今日已赞 只能使用[查询好友信息]获取
        /// <summary>
        /// 今日已赞 只能使用[查询好友信息]获取
        /// </summary>
        public uint LikesToday;
        // 今日可赞数 只能使用[查询好友信息]获取
        /// <summary>
        /// 今日可赞数 只能使用[查询好友信息]获取
        /// </summary>
        public uint LikesAvailableToday;
    }
   
}
