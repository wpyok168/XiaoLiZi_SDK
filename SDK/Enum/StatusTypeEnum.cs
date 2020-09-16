using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 主要在线状态
    public enum StatusTypeEnum
    {
        // 在线
        /// <summary>
        /// 在线
        /// </summary>
        Online = 11,
        // 离开
        /// <summary>
        /// 离开
        /// </summary>
        Away = 31,
        // 隐身
        /// <summary>
        /// 隐身
        /// </summary>
        Invisible = 41,
        // 忙碌
        /// <summary>
        /// 忙碌
        /// </summary>
        Busy = 50,
        // Q我吧
        /// <summary>
        /// Q我吧
        /// </summary>
        TalkToMe = 60,
        // 请勿打扰
        /// <summary>
        /// 请勿打扰
        /// </summary>
        DoNotDisturb = 70
    }
}
