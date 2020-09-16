using SDK;
using SDK.Events;
using SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTool
{
    public class RobotEventcallBack : IEventcallBack
    {
        public void EventcallBack(EventTypeBase e)
        {
            if (e.EventType == SDK.Enum.EventTypeEnum.Group_MemberVerifying)
            {
                Common.xlzAPI.GroupVerificationEvent(e.ThisQQ, e.SourceGroupQQ, e.TriggerQQ, e.MessageSeq,SDK.Enum.GroupVerificationOperateEnum.Agree,SDK.Enum.EventTypeEnum.Group_MemberVerifying);
            }
        }
    }
}
