using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Enum;
using SDK.Events;
using SDK.Interface;

namespace MsTool
{
    public class AppEnable : IAppEnableEvent
    {
        public EventProcessEnum AppEnableEvent(AppEnableEvent e)
        {
            return EventProcessEnum.Ignore;
        }
    }
}
