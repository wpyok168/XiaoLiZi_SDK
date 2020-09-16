using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GMBriefDataList
    {
        public GMBriefInfo groupMemberBriefInfo;
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GMBriefInfo
    {
        /// <summary>
        /// 群上限
        /// </summary>
        public uint GroupMAax;
        /// <summary>
        /// 群人数
        /// </summary>
        public uint GruoupNum;
        /// <summary>
        /// 群主
        /// </summary>
        public long GroupOwner;
        /// <summary>
        /// 群管理员列表
        /// </summary>
        public IntPtr AdminiList;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AdminListDataList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray,SizeConst =1024)]
        //public byte[] pdatalist;
        public long[] pdatalist;
    }
    /// <summary>
    /// 群成员状况简略信息
    /// </summary>
    public class GroupMemberBriefInfo
    {
        /// <summary>
        /// 群上限
        /// </summary>
        public uint GroupMAax;
        /// <summary>
        /// 群人数
        /// </summary>
        public uint GruoupNum;
        /// <summary>
        /// 群主
        /// </summary>
        public long GroupOwner;
        /// <summary>
        /// 群管理员列表
        /// </summary>
        public long[] AdminiList;
    }
}
