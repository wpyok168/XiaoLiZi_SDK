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
    /// 机器人人事件处理类
    /// </summary>
    public interface IEventcallBack
    {
        /// <summary>
        /// 机器人人事件处理类
        /// </summary>
        /// <param name="e"></param>
        EventMessageEnum EventcallBack(EventTypeBase e);
    }
}
