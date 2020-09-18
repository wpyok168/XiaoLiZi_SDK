using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 群卡片信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupCardInfo
    {
        // 群名称
        /// <summary>
        /// 群名称
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string GroupName;
        // 群地点
        /// <summary>
        /// 群地点
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string GroupLocation;
        // 群分类
        /// <summary>
        /// 群分类
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string GroupClassification;
        // 群标签 以|分割
        /// <summary>
        /// 群标签 以|分割
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string GroupTags;
        // 群介绍
        /// <summary>
        /// 群介绍
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string GroupDescription;
    }
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupCardInfoDatList
    {
        public GroupCardInfo groupCardInfo;
    }
}
