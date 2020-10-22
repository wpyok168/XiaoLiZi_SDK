using SDK.Enum;
using System.Runtime.InteropServices;

namespace SDK.Model
{
    /// <summary>
    /// 群员信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct OneGroupMemberInfo
    {
        /// <summary>
        /// 群名片
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string  GroupCardName;
        /// <summary>
        /// 昵称
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string NickName;
        /// <summary>
        /// 群聊等级<para>文本型等级,取决于群等级设置,如：冒泡</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string GroupChatLevel;
        /// <summary>
        /// 入群时间戳
        /// </summary>
        public long JoinTime;
        /// <summary>
        /// 最后发言时间戳
        /// </summary>
        public long LastSpeackTime;
        /// <summary>
        /// 管理权限<para>表示群成员对于所在群的群成员类型</para>
        /// </summary>
        public GroupPosition groupPosition;
        /// <summary>
        /// 头衔
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string GroupTitle;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OneGroupMemberDataList
    {
        public OneGroupMemberInfo oneGroupMemberInfo;
    }
}
