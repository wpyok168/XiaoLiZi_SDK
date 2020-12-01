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
            if (e.EventType == SDK.Enum.EventTypeEnum.Group_MemberUndid)
            {
                string sendstr = $"{e.TriggerQQName}({e.TriggerQQ})撤回了一条消息，内容如下：\r\n{e.MessageContent}";
                Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.SourceGroupQQ, sendstr);
            }
            if (e.EventType == SDK.Enum.EventTypeEnum.Friend_UserUndid)
            {
                string sendstr = $"{e.TriggerQQName}({e.TriggerQQ})撤回了一条消息，内容如下：\r\n{e.MessageContent}";
                Common.xlzAPI.SendPrivateMessage(e.ThisQQ, e.TriggerQQ, sendstr);
            }

        }
    }
}
