using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    /// <summary>
    /// 消息事件处理
    /// </summary>
    public enum EventMessageEnum
    {
        // 阻止其他插件继续处理此事件
        /// <summary>
        /// 阻止其他插件继续处理此事件
        /// </summary>
        Block = 1,
        // 允许其他插件继续处理此事件
        /// <summary>
        /// 允许其他插件继续处理此事件
        /// </summary>
        Ignore = 0
    }
}
