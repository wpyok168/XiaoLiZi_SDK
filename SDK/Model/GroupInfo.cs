using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupDataList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024*10)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GetGroupData
    {
        public GroupInfo groupInfo;
    }

    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupInfo
    {
        // 群ID
        /// <summary>
        /// 群ID
        /// </summary>
        public long GroupID;
        // 群号
        /// <summary>
        /// 群号
        /// </summary>
        public long GroupQQ;
        // cFlag
        public long CFlag;
        // dwGroupInfoSeq
        public long GroupInfoSeq;
        // dwGroupFlagExt
        public long GroupFlagExt;
        // dwGroupRankSeq
        /// <summary>
        /// 群等级查询Seq
        /// </summary>
        public long GroupRankSeq;
        // dwCertificationType
        public long CertificationType;
        // 禁言时间戳
        /// <summary>
        /// 全员禁言解除时间戳
        /// </summary>
        public long ShutUpTimestamp;
        // 解除禁言时间戳
        /// <summary>
        /// 解除禁言时间戳
        /// </summary>
        public long ThisShutUpTimestamp;
        // dwCmdUinUinFlag
        public long CmdUinUinFlag;
        // dwAdditionalFlag
        public long AdditionalFlag;
        // dwGroupTypeFlag
        public long GroupTypeFlag;
        // dwGroupSecType
        public long GroupSecType;
        // dwGroupSecTypeInfo
        public long GroupSecTypeInfo;
        // dwGroupClassExt
        public long GroupClassExt;
        // dwAppPrivilegeFlag
        public long AppPrivilegeFlag;
        // dwSubscriptionUin
        public long SubscriptionUin;
        // 群成员数量
        /// <summary>
        /// 群成员数量
        /// </summary>
        public long GroupMemberCount;
        // dwMemberNumSeq
        /// <summary>
        /// 群成员名片查询Seq
        /// </summary>
        public long MemberNumSeq;
        // dwMemberCardSeq
        public long MemberCardSeq;
        // dwGroupFlagExt3
        /// <summary>
        /// 群主QQ
        /// </summary>
        public long GroupFlagExt3;
        // dwGroupOwnerUin
        public long GroupOwnerUin;
        // cIsConfGroup
        public long IsConfGroup;
        // cIsModifyConfGroupFace
        public long IsModifyConfGroupFace;
        // cIsModifyConfGroupName
        public long IsModifyConfGroupName;
        // dwCmduinJoinTime
        /// <summary>
        /// 入群时间戳
        /// </summary>
        public long CmduinJoinTime;
        // 群名称
        /// <summary>
        /// 群名称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string GroupName;
        // strGroupMemo
        /// <summary>
        /// 新人公告
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string GroupMemo;
    }
}
