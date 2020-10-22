using System.ComponentModel;

namespace SDK.Enum
{
    /// <summary>
    /// 表示群成员对于所在群的群成员类型
    /// </summary>
    public enum GroupPosition
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        Member = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Manage = 2,
        /// <summary>
        /// 群主
        /// </summary>
        [Description("群主")]
        Creator = 3
    }
}
