using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDK;
using SDK.Events;
using SDK.Interface;

namespace MsTool
{
    public class RecPrivateMsg : IRecvicetPrivateMessage
    {
        public void RecvicetPrivateMsg(PrivateMessageEvent e)
        {
            //if (e.ThisQQ == e.SenderQQ)
            //{
            //    return;
            //}
            //Common.xlzAPI.OutLog("我输出的日志");
            //Common.xlzAPI.SendPrivateMessage(e.ThisQQ, e.SenderQQ, "欢迎使用小栗子SDK");
            //Common.xlzAPI.RecviceImage(e.MessageContent, e.ThisQQ, e.SenderQQ);
            //Common.xlzAPI.GetFriendList(e.ThisQQ);
            //List<SDK.Model.GroupInfo> groupInfos = Common.xlzAPI.Getgrouplist(e.ThisQQ);
            //if (groupInfos != null)
            //{
            //    Common.xlzAPI.GetgroupMemberlist(e.ThisQQ, groupInfos[0].GroupID);
            //}
            //Common.xlzAPI.GetAdministratorList(e.ThisQQ,535107725);
            //Common.xlzAPI.GetgroupMemberlist(e.ThisQQ, 535107725);
            //Common.xlzAPI.GetFriendInfoEvent(e.ThisQQ, 414725048);
            //Common.xlzAPI.CreateGroupFolderEvent(e.ThisQQ, 247681297, "小栗子");
            //Common.xlzAPI.SendFreeGiftEvent(e.ThisQQ, 247681297, 414725048, SDK.Enum.FreeGiftEnum.Gift_280);
            //Common.xlzAPI.GetGroupFileListEvent(e.ThisQQ, 480325208,"");
            //string imagepath = System.Environment.CurrentDirectory + "\\上传好友图片.png";
            //string piccode = Common.xlzAPI.UploadGroupImage(e.ThisQQ, 480325208, imagepath, false);
            //if (e.MessageContent.Contains("转发"))
            //{
            //    Common.xlzAPI.SendPrivateMessage(e.ThisQQ, e.MessageGroupQQ, e.MessageContent);
            //}
            //for (int i = 0; i < 600; i++)
            //{

            //    //SDK.Core.API aPI = new SDK.Core.API();
            //    //aPI.SendPrivateMessage(e.ThisQQ, e.SenderQQ, "VDXXH-QDN62-K2MTB-G2P88-Q7B86\r\n无法安装此密钥\r\n0xC004F025 \r\n2020/09/05 17:57:29（UTC+8)");
            //    //aPI.SendPrivateMessage(e.ThisQQ, e.SenderQQ, i.ToString());
            //    //System.Threading.Thread.Sleep(200);
            //    Common.xlzAPI.SendPrivateMessage(e.ThisQQ, e.SenderQQ, "VDXXH-QDN62-K2MTB-G2P88-Q7B86\r\n无法安装此密钥\r\n0xC004F025 \r\n2020/09/05 17:57:29（UTC+8)");
            //    Common.xlzAPI.SendPrivateMessage(e.ThisQQ, e.SenderQQ, i.ToString());
            //    System.Threading.Thread.Sleep(200);
            //}
           // Common.xlzAPI.GetGroupMemberBriefInfoEvent(e.ThisQQ, 480325208);
        }
    }
}
