using SDK.Enum;
using SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Interface
{
    /// <summary>
    /// 接收群消息
    /// </summary>
    public interface IGroupMessage
    {
        /// <summary>
        /// 接收群消息
        /// </summary>
        /// <param name="e"></param>
        EventMessageEnum ReceviceGroupMsg(GroupMessageEvent e);
    }
}
