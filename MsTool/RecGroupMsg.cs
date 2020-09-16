using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDK;
using SDK.Events;
using SDK.Interface;

namespace MsTool
{
    public class RecGroupMsg : IGroupMessage
    {
        public void ReceviceGroupMsg(GroupMessageEvent e)
        {
            if (e.SenderQQ == 1000032 || e.ThisQQ == e.SenderQQ)//不处理匿名信息和自己
            {
                return;
            }
            // Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, "测试小栗子C# SDK", true);
            // Common.xlzAPI.RecviceImage(e.MessageContent, e.ThisQQ, e.SenderQQ);
            if (e.MessageContent.Contains("转发"))
            {
                Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, e.MessageContent);
            }
        }
    }
}
