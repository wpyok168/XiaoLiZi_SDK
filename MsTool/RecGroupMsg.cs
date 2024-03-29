﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SDK;
using SDK.Events;
using SDK.Interface;
using SDK.Model;

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
            //if (e.MessageContent.Contains("转发"))
            //{
            //    Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, e.MessageContent);
            //}
            //byte[] by = Common.xlzAPI.AnonymousFalg2byte(e.AnonymousFalg);
            Common.xlzAPI.BanAnonymous(e.ThisQQ, e.MessageGroupQQ, e.AnonymousNickname, e.AnonymousFalg, 30);
            if (e.MessageContent.Equals("谁是龙王"))
            {
                string lKing = GetDragonKing(e.ThisQQ, e.MessageGroupQQ);
                if (lKing.Contains("acceptLanguages"))
                {
                    dynamic token = new JavaScriptSerializer().Deserialize<dynamic>(lKing);
                    Dictionary<string, object> json = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(lKing);
                    int count = ((ArrayList)json["talkativeList"]).Count;
                    if (token["gc"] != null && (string)token["gc"] == e.MessageGroupQQ.ToString())
                    {
                        Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, "现任龙王: " + (string)token["talkativeList"][0]["name"] + "(" + Convert.ToString(token["talkativeList"][0]["uin"]) + ")" + " 蝉联天数: " + (string)token["talkativeList"][0]["desc"]);
                        if (count > 1)
                        {
                            List<string> list = new List<string>();
                            for (int i = 1; i < count; i++)
                            {
                                list.Add((string)token["talkativeList"][i]["name"] + "(" + Convert.ToString(token["talkativeList"][i]["uin"]) + ")" + " 蝉联天数: " + (string)token["talkativeList"][i]["desc"]);
                                if (i > 5)
                                    break;
                            }
                            Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, "历史龙王: " + Environment.NewLine + string.Join(Environment.NewLine, list));
                        }
                    }
                }
            }
            if (e.MessageContent.Equals("群签到"))
            {
                Common.xlzAPI.GroupSigninEvent(e.ThisQQ, e.MessageGroupQQ);
            }
            if (e.MessageContent.Equals("群打卡"))
            {
                Common.xlzAPI.GroupTurnOn(e.ThisQQ, e.MessageGroupQQ);
            }
            if (e.MessageContent.Equals("群送礼"))
            {
                Common.xlzAPI.SendFreeGiftEvent(e.ThisQQ, e.MessageGroupQQ,2674931578,SDK.Enum.FreeGiftEnum.Gift_285);
            }
            if (e.MessageContent.Equals("领红包"))
            {
                Common.xlzAPI.GetReceiveRedEnvelopeEvent(e.ThisQQ, e.MessageGroupQQ,e.SenderQQ, "", 2,"");
            }
            if (e.MessageContent.Equals("取群应用列表"))
            {
                Common.xlzAPI.GetGroupApps_(e.ThisQQ, e.MessageGroupQQ);
            }
            if (e.MessageContent.Equals("查收款"))
            {
                PendingPayerinfo p = new PendingPayerinfo() { QQ = 1403875823, Amount = 2 };
                List<PendingPayerinfo> pp = new List<PendingPayerinfo>() { p};
                string ordernum = "5021052104147250481442793577";
                Common.xlzAPI.SelectGroupCollectionStatus_(e.ThisQQ, ordernum);
            }
            if (e.MessageContent.Equals("文本解析"))
            {
                XLZTextCodecnalysis xLZText = Common.xlzAPI.TextCodeAnalysis_();
                EarrayList[] earrayLists = new EarrayList[1];
                //xLZText.Parsing("[Shake,name=戳一戳,Type=2,Id=1]", ref earrayLists);
                //string command = xLZText.GetCommand("[Shake,name=戳一戳,Type=2,Id=1]");
            }
            if (e.MessageContent.Contains("翻译"))
            {
                string result = string.Empty;
                string ret = Common.xlzAPI.Translate_(e.ThisQQ, "zh", "en", e.MessageContent.Substring("翻译".Length), ref result);
                Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, result);
            }
            if (e.MessageContent.Contains("文字转语音"))
            {
                byte[] result = new byte[1024 * 100];
                string ret = Common.xlzAPI.Text2speech_(e.ThisQQ, e.MessageContent, ref result);
                string audioret = Common.xlzAPI.UploadGroupAudio(e.ThisQQ, e.MessageGroupQQ, SDK.Enum.AudioTypeEnum.Normal, "", result);
                Common.xlzAPI.SendGroupMessage(e.ThisQQ, e.MessageGroupQQ, audioret);
            }
        }

        /// <summary>
        /// 取龙王简例
        /// </summary>
        /// <param name="thisQQ">框架qq</param>
        /// <param name="groupQQ">群号</param>
        /// <returns></returns>
        public string GetDragonKing(long thisQQ, long groupQQ)
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
            else if (hws.ContentEncoding.ToLower().Equals("deflate"))
            {
                outhtml = new StreamReader(new DeflateStream(hws.GetResponseStream(), CompressionMode.Decompress)).ReadToEnd();
            }
            else
            {
                outhtml = new StreamReader(hws.GetResponseStream()).ReadToEnd();
            }
            string json = Regex.Match(outhtml, @"\{""(.)*(?>\})", RegexOptions.Multiline).Value;
            return json;
        }
    }
}
