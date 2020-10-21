using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
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
            //Common.xlzAPI.GetGroupMemberBriefInfoEvent(e.ThisQQ, 480325208);247681297
            //string cookies = Common.xlzAPI.GetWebCookiesEvent(e.ThisQQ, "https://h5.qzone.qq.com/mqzone/index", "549000929", "5");
            string picpath = System.Environment.CurrentDirectory + "\\图片.png";
            if (e.MessageContent.Equals("发送群公告"))
            {
                if (File.Exists(picpath))
                {
                    string ret = Common.xlzAPI.SetAnnouncementEvent(e.ThisQQ, 247681297, "小栗子发公告", "测试发公告", picpath, null,true, true, true, true, true);
                }
            }
            if (e.MessageContent.Contains("[Shake,name="))
            {
                string Shakepath = System.Environment.CurrentDirectory + "\\Shake.txt";
                using (FileStream fs = new FileStream(Shakepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fs.Position = fs.Length;
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(e.MessageContent);
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            string lKing = GetDragonKing(e.ThisQQ, 874383398);

        }
        /// <summary>
        /// 取龙王简例
        /// </summary>
        /// <returns></returns>
        public string GetDragonKing(long thisQQ,long groupQQ)
        {
            string ck = Common.xlzAPI.GetWebCookiesEvent(thisQQ, "https://qun.qq.com", "715030901", "73");
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.CreateHttp($"https://qun.qq.com/interactive/honorlist?gc={groupQQ}&type=1");
            hwr.Method = "get";
            hwr.KeepAlive = true;
            hwr.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            hwr.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            hwr.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8,ru;q=0.7,de;q=0.6");
            hwr.Headers.Add("Cookie", ck);
            HttpWebResponse hws = null;
            try
            {
                hws = (HttpWebResponse)hwr.GetResponse();
            }
            catch (Exception)
            {

                throw;
            }
            string outhtml = string.Empty;
            if (hws.ContentEncoding.ToLower().Equals("gzip"))
            {
                outhtml = new StreamReader(new GZipStream(hws.GetResponseStream(), CompressionMode.Decompress)).ReadToEnd();
            }
            if (hws.ContentEncoding.ToLower().Equals("deflate"))
            {
                outhtml = new StreamReader(new DeflateStream(hws.GetResponseStream(), CompressionMode.Decompress)).ReadToEnd();
            }
            else
            {
                outhtml = new StreamReader(hws.GetResponseStream()).ReadToEnd();
            }
            return outhtml;
        }
    }
}
