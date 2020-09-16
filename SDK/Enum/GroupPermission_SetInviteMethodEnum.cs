using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    /// <summary>
    /// 群邀请权限
    /// </summary>
    public enum GroupPermission_SetInviteMethodEnum
    {
        //1 无需审核;2 需要管理员审核;3 100人以内无需审核
        /// <summary>
        /// 无需审核
        /// </summary>
        No_review_required = 1,
        /// <summary>
        /// 需要管理员审核
        /// </summary>
        Admin_review = 2,
        /// <summary>
        /// 100人以内无需审核
        /// </summary>
        No_review_required_within_100_people = 3

    }
}
