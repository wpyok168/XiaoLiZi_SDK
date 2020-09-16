using System.Runtime.InteropServices;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupMemberDataList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupMemberInfo
    {
        // 账号
        [MarshalAs(UnmanagedType.LPStr)]
        public string QQNumber;
        // 年龄
        public uint Age;
        // 性别
        public uint Gender;
        // 昵称
        [MarshalAs(UnmanagedType.LPStr)]
        public string Name;
        // 邮箱
        [MarshalAs(UnmanagedType.LPStr)]
        public string Email;
        // 名片
        [MarshalAs(UnmanagedType.LPStr)]
        public string Nickname;
        // 备注
        public string Note;
        // 头衔
        [MarshalAs(UnmanagedType.LPStr)]
        public string Title;
        // 手机号
        [MarshalAs(UnmanagedType.LPStr)]
        public string Phone;
        // 头衔到期时间
        public long TitleTimeout;
        // 禁言时间戳
        public long ShutUpTimestamp;
        // 加群时间
        public long JoinTime;
        // 发言时间
        public long ChatTime;
        // 群等级
        public long Level;
    }
}
