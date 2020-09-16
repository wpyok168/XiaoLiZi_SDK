using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum IsGroupRecviceEnum
    {
        //1接收并提醒 2收进群助手 3屏蔽群消息 4接收不提醒
        /// <summary>
        /// 接收并提醒
        /// </summary>
        recAndRemind = 1,
        /// <summary>
        /// 收进群助手
        /// </summary>
        shrinkGroup = 2,
        /// <summary>
        /// 屏蔽群消息
        /// </summary>
        shieldGroup = 3,
        /// <summary>
        /// 接收不提醒
        /// </summary>
        recNoRemind = 4
    }
}
