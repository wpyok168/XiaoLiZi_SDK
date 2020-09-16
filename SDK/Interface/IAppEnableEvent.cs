using SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Interface
{
    /// <summary>
    /// 启动事件
    /// </summary>
    public interface IAppEnableEvent
    {
        /// <summary>
        /// 启动事件
        /// </summary>
        /// <param name="e"></param>
        void AppEnableEvent(AppEnableEvent e);
    }
}
