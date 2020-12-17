using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SDK.Enum;
using SDK.Events;
using SDK.Model;

namespace SDK.Core
{
    public class API : TextFormat
    {

        public static string pluginkey { get; set; }
        public static string jsonstr { get; set; }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendPivateMsg(string pkey, long ThisQQ, long SenderQQ, [MarshalAs(UnmanagedType.LPStr)]  string MessageContent, ref long MessageRandom, ref uint MessageReq);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr OutputLog(string pkey, [MarshalAs(UnmanagedType.LPStr)]  string message, int text_color, int background_color);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupMsg(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string msgcontent, bool anonymous);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr Recviceimage(string pkey, string guid, long thisQQ, long groupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetFriendlist(string pkey, long thisQQ, ref FriendDataList[] friendInfos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetGrouplist(string pkey, long thisQQ, ref GroupDataList[] GroupInfos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GroupMemberlist(string pkey, long thisQQ, long groupNumber, ref GroupMemberDataList[] GroupInfos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetadministratorList(string pkey, long thisQQ, long gruopQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void Restart(string pkey);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void FriendverificationEvent(string pkey, long thisQQ, long triggerQQ, long message_seq, FriendVerificationOperateEnum operate_type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SaveFileToWeiYun(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string file_id);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void ReadForwardedChatHistory(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string resID, ref IntPtr intPtr);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetFriendInfo(string pkey, long thisQQ, long otherQQ, ref GetFriendDataList[] friendInfos);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void GroupVerification(string pkey, long thisQQ, long source_groupQQ, long triggerQQ, long message_seq, GroupVerificationOperateEnum operate_type, EventTypeEnum event_type, [MarshalAs(UnmanagedType.LPStr)]  string refuse_reason);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGroupInfo(string pkey, long thisQQ, long otherGroupQQ, ref GetGroupData[] getGroupDatas);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetGroupCardInfo(string pkey, long thisQQ, long otherGroupQQ, ref GroupCardInfoDatList[] groupCardInfo);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool Undo_Group(string pkey, long thisQQ, long groupQQ, long message_random, int message_req);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool Undo_Private(string pkey, long thisQQ, long otherQQ, long message_random, int message_req, int time);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr CreateGroupFolder(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendFriendJSONMessage(string pkey, long thisQQ, long friendQQ, [MarshalAs(UnmanagedType.LPStr)]  string json_content);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendFreeGift(string pkey, long thisQQ, long groupQQ, long otherQQ, int gift);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupJSONMessage(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string json_content, bool anonymous);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupTemporaryMessage(string pkey, long thisQQ, long groupQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]  string content, ref long random, ref int req);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ShareMusic(string pkey, long thisQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]  string music_name, [MarshalAs(UnmanagedType.LPStr)]  string artist_name, [MarshalAs(UnmanagedType.LPStr)]  string redirect_link, [MarshalAs(UnmanagedType.LPStr)]  string cover_link, [MarshalAs(UnmanagedType.LPStr)]  string file_path, int app_type, int share_type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ModifyGroupMessageContent(string pkey, [MarshalAs(UnmanagedType.SysInt)] int data_pointer, [MarshalAs(UnmanagedType.LPStr)] string new_message_content);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ModifyPrivateMessageContent(string pkey, [MarshalAs(UnmanagedType.SysInt)] int data_pointer, [MarshalAs(UnmanagedType.LPStr)] string new_message_content);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GroupDrawRedEnvelope(string pkey, long thisQQ, int total_number, int total_amount, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string question, [MarshalAs(UnmanagedType.LPStr)]  string payment_password, int card_serial,ref GetCaptchaInfoDataList[] captchaInfo);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GroupExclusiveRedEnvelope(string pkey, long thisQQ, int total_number, int total_amount, long groupQQ, [MarshalAs(UnmanagedType.LPStr)] string otherQQ, [MarshalAs(UnmanagedType.LPStr)] string blessing, bool isEvenlysplit, [MarshalAs(UnmanagedType.LPStr)] string payment_password, int card_serial, ref GetCaptchaInfoDataList[] captchaInfo);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr FriendNormalRedEnvelope(string pkey, long thisQQ, int total_number, int total_amount, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string question, int skinID, [MarshalAs(UnmanagedType.LPStr)]  string payment_password, int card_serial, ref GetCaptchaInfoDataList[] ciDataLists);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool FriendFileToFriend(string pkey, long thisQQ, long sourceQQ, long targetQQ, [MarshalAs(UnmanagedType.LPStr)]  string fileID, [MarshalAs(UnmanagedType.LPStr)]  string file_name, long file_size, ref int msgReq, ref long Random, ref int time);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetPluginDataDirectory(string pkey);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetClientKey(string pkey, long thisQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetPSKey(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string domain);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetOrderDetail(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string orderID, ref OrderDetaildDataList[] data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool DissolveGroup(string pkey, long thisQQ, long gruopNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ShutUpGroupMember(string pkey, long thisQQ, long groupQQ, long otherQQ, int time);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetNameForce(string pkey, long thisQQ, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetQQWalletPersonalInformation(string pkey, long thisQQ, ref QQWalletDataList[] qQWalletInfoDataLists);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetNameFromCache(string pkey, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupNickname(string pkey, long thisQQ, long groupQQ, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetGroupFileList(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string folder, ref GroupFileInfoDataList[] groupFileInfoDataLists);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ShutUpAll(string pkey, long thisQQ, long groupQQ, bool is_shut_up_all);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GroupPermission_SetInviteMethod(string pkey, long thisQQ, long groupQQ, int method);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ForwardGroupFileToFriend(string pkey, long thisQQ, long source_groupQQ, long target_groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string fileID, [MarshalAs(UnmanagedType.LPStr)]  string filename, long filesize, ref int msgReq, ref long Random, ref int time);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ForwardGroupFileToGroup(string pkey, long thisQQ, long source_groupQQ, long target_groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string fileID);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool RemoveGroupMember(string pkey, long thisQQ, long groupQQ, long otherQQ, bool is_verification_refused);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr DeleteGroupFile(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string file_id, [MarshalAs(UnmanagedType.LPStr)]  string folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr DeleteGroupFolder(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr RenameGroupFolder(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string old_folder, [MarshalAs(UnmanagedType.LPStr)]  string new_folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadGroupFile(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string path, [MarshalAs(UnmanagedType.LPStr)]  string folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr MoveGroupFile(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string file_id, [MarshalAs(UnmanagedType.LPStr)]  string old_folder, [MarshalAs(UnmanagedType.LPStr)]  string new_folder);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadFriendImage(string pkey, long thisQQ, long friendQQ, bool is_flash, [MarshalAs(UnmanagedType.LPArray)] byte[] pic, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool UploadGroupAvatar(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPArray)] byte[] pic, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadAvatar(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPArray)] byte[] pic, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadFriendAudio(string pkey, long thisQQ, long friendQQ, int audio_type, [MarshalAs(UnmanagedType.LPStr)]  string audio_text, [MarshalAs(UnmanagedType.LPArray)] byte[] audio, int audiosize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool ReportCurrent(string pkey, long thisQQ, long groupQQ, double Longitude, double Latitude);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SetGroupNickname(string pkey, long thisQQ, long groupQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]  string nickname);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetLocationShare(string pkey, long thisQQ, long groupQQ, double Longitude, double Latitude, bool is_enabled);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetStatus(string pkey, long thisQQ, int main, int sun, int battery);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool Setexclusivetitle(string pkey, long thisQQ, long groupQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]  string name);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate long IsShuttedUp(string pkey, long thisQQ, long groupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr AddFriend(string pkey, long thisQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]  string verification, [MarshalAs(UnmanagedType.LPStr)]  string comment);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr AddGroup(string pkey, long thisQQ, long groupQQ, [MarshalAs(UnmanagedType.LPStr)]  string verification);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool QuitGroup(string pkey, long thisQQ, long groupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetSignature(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string signature, [MarshalAs(UnmanagedType.LPStr)]  string location);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetName(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string name);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SetBlockFriend(string pkey, long thisQQ, long otherQQ, bool is_blocked);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetGroupMessageReceive(string pkey, long thisQQ, long groupQQ, int set_type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SetSpecialFriend(string pkey, long thisQQ, long otherQQ, bool is_special);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SubmitPaymentCaptcha(string pkey, long thisQQ, IntPtr captcha_information, [MarshalAs(UnmanagedType.LPStr)] string captcha, [MarshalAs(UnmanagedType.LPStr)]  string payment_password);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool LoginSpecifyQQ(string pkey, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SendIMEStatus(string pkey, long thisQQ, long ohterQQ, int iMEStatus);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool CheckPermission(string pkey, int permission);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr QQLike(string pkey, long thisQQ, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool Modifyinformation(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)]  string json);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int GetRedEnvelope(string pkey, long thisQQ, long GroupQQ, ref RedEnvelopesDataList[] reDataList);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void CallPhone(string pkey, long thisQQ, long otherQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GroupFileDownloadLink(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPTStr)] string FileID, [MarshalAs(UnmanagedType.LPTStr)] string FileName);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool DoubleclickGroupFace(string pkey, long thisQQ, long otherQQ, long groupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GroupTop(string pkey, long thisQQ, long GroupQQ, bool istop);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetEssence(string pkey, long thisQQ, long groupQQ, int message_req, long message_random );
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetGroupNickRules(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPWStr)]string rules);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetGroupLimitNumber(string pkey, long thisQQ, long GroupQQ, int LimitNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool FriendjoinGroup(string pkey, long thisQQ, long GroupQQ, long otherQQ, long otherGroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GroupNoticeMethod(string pkey, long thisQQ, long GroupQQ, long otherQQ, int metohd);
        delegate IntPtr GetGroupMemberBriefInfo(string pkey, long thisQQ, long GroupQQ, ref GMBriefDataList[] gMBriefDataLists);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool UpdataGroupName(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPStr)]string NewGroupName);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void ReloadItSelf(string pkey, [MarshalAs(UnmanagedType.LPStr)] string dllpath);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool OfflinePCQQ(string pkey, long QQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetFrameVersion(string pkey);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GetWebCookies(string pkey, long thisQQ, string JumpUrl, string appid, string daid, [MarshalAs(UnmanagedType.LPStr)] ref string retCookies);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SetAnnouncement(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string title, [MarshalAs(UnmanagedType.LPStr)] string msgcotent, [MarshalAs(UnmanagedType.LPStr)] string video, bool isShow, bool isConfrim, bool isTop, bool isSendNewMember, bool setGroupNickName, [MarshalAs(UnmanagedType.LPArray)] byte[] picpath, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetOneGroupMember(string pkey, long thisQQ, long groupQQ, long otherQQ,ref OneGroupMemberDataList[] oneGroupMemberDatas);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendMail(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)] string mailaddr, [MarshalAs(UnmanagedType.LPStr)] string mailtitle, [MarshalAs(UnmanagedType.LPStr)] string msgContent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr Transfer(string pkey, long thisQQ, int Amount, long otherQQ, [MarshalAs(UnmanagedType.LPStr)]string leaveMsg, int type, [MarshalAs(UnmanagedType.LPStr)]string PaymentPWD, int bankCard, ref GetCaptchaInfoDataList[] captchaInfo);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr BalanceWithdrawal(string pkey, long thisQQ, int Amount, int bankCard, [MarshalAs(UnmanagedType.LPStr)]string PaymentPWD);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GetRecPayment(string pkey, long thisQQ, int Amount, [MarshalAs(UnmanagedType.LPStr)] string desc);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SmallVideoDownloadUrl(string pkey, long thisQQ, long GroupQQ, long SourceQQ, [MarshalAs(UnmanagedType.LPStr)] string param, [MarshalAs(UnmanagedType.LPStr)] string harsh1, [MarshalAs(UnmanagedType.LPStr)] string filename);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr FriendSmallVideoDownloadUrl(string pkey, long thisQQ, long SourceQQ, [MarshalAs(UnmanagedType.LPStr)] string param, [MarshalAs(UnmanagedType.LPStr)] string harsh1, [MarshalAs(UnmanagedType.LPStr)] string filename);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr UploadVideo(string pkey, long thisQQ, long GroupQQ, string videolpath, [MarshalAs(UnmanagedType.LPArray)] byte[] picpath, int picsize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendFriendXml(string pkey, long thisQQ, long otherQQ, [MarshalAs(UnmanagedType.LPStr)] string xmlcode, ref long Random, ref int Req);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr SendGroupXml(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string xmlcode, bool anonymous);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr GroupMemberOverview(string pkey, long thisQQ, long GroupQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool GroupSignin(string pkey, long thisQQ, long GroupQQ, [MarshalAs(UnmanagedType.LPStr)] string desc);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr ForwardRedEnvelope(string pkey, long thisQQ, [MarshalAs(UnmanagedType.LPStr)] string redEnvelopeID, long QQ, int type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SendDataPack(string pkey, long thisQQ, int packID, int maxwaittime, ref IntPtr bytes);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int Getssoseq(string pkey, long thisQQ);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate bool SetFriendAuthenticationM(string pkey, long thisQQ, FriendAuthenticationModeEnum type, [MarshalAs(UnmanagedType.LPStr)] string Q_and_A);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate IntPtr Payment(string pkey, long thisQQ,  [MarshalAs(UnmanagedType.LPStr)] string QrcodeUrl, int bankCard, [MarshalAs(UnmanagedType.LPStr)] string PaymentPWD, ref GetCaptchaInfoDataList[] captchaInfo);
        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="text_color"></param>
        /// <param name="background_color"></param>
        /// <returns></returns>
        public string OutLog(string message, int text_color = 16711680, int background_color = 16777215)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("输出日志").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            OutputLog outputLog = (OutputLog)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(OutputLog));
            ret = Marshal.PtrToStringAnsi(outputLog(pluginkey, message, text_color, background_color));
            outputLog = null;
            return ret;
        }
        /// <summary>
        /// 输出日志1
        /// </summary>
        /// <param name="message"></param>
        /// <param name="text_color"></param>
        /// <param name="background_color"></param>
        /// <returns></returns>
        public string OutLog1(string message, Color text_color, Color background_color)
        {
            return OutLog(message, Colr2Int(text_color), Colr2Int(background_color));
        }

        private int Colr2Int(Color color)
        {
            //RGB函数计算公式:    颜色值    ＝    (65536    *    Blue)    +    (256    *    Green)    +    (Red)
            return (65536 * color.B) + (256 * color.G) + color.R;
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="ThisQQ"></param>
        /// <param name="SenderQQ"></param>
        /// <param name="MessageContent"></param>
        /// <param name="MessageRandom"></param>
        /// <param name="MessageReq"></param>
        /// <returns></returns>
        public string SendPrivateMessage(long ThisQQ, long SenderQQ, string MessageContent, long MessageRandom = 0, uint MessageReq = 0)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送好友消息").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            SendPivateMsg sendmsg = (SendPivateMsg)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SendPivateMsg));
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, ThisQQ, SenderQQ, MessageContent, ref MessageRandom, ref MessageReq));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="msgcontent"></param>
        /// <param name="anonymous"></param>
        /// <returns></returns>
        public string SendGroupMessage(long thisQQ, long groupQQ, string msgcontent, bool anonymous = false)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送群消息").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            SendGroupMsg sendmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SendGroupMsg));
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, msgcontent, anonymous));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取插件数据目录<para>没有权限限制，建议将设置文件之类的都写这里面，结果结尾带\</para>
        /// </summary>
        /// <returns></returns>
        public string GetPluginDataDirectoryEvent()
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取插件数据目录").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetPluginDataDirectory sendmsg = (GetPluginDataDirectory)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetPluginDataDirectory));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取图片下载地址
        /// </summary>
        /// <param name="msgcontent"></param>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <returns>返回URL下载地址</returns>
        public List<string> RecviceImage(string msgcontent, long thisQQ, long groupQQ)
        {
            List<string> guids = GetGuidImage(msgcontent);
            if (guids == null)
            {
                return null;
            }
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取图片下载地址").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            Recviceimage sendmsg = (Recviceimage)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(Recviceimage));
            List<string> imageurl = new List<string>();
            foreach (string guid in guids)
            {
                ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, guid, thisQQ, groupQQ));
                imageurl.Add(ret);
            }
            sendmsg = null;
            return imageurl;
        }

        /// <summary>
        /// 获取guid
        /// </summary>
        /// <param name="msgcontent"></param>
        /// <returns></returns>
        private List<string> GetGuidImage(string msgcontent)
        {
            if (msgcontent.Contains("[pic,hash="))
            {
                try
                {
                    MatchCollection guids = Regex.Matches(msgcontent, @"(\[pic,hash=)(.){32}");
                    //string guid = Regex.Match(msgcontent, @"(\[pic,hash=)(.)+?(?=\])]").Value;
                    if (guids != null)
                    {
                        List<string> list = new List<string>();
                        foreach (Match item in guids)
                        {
                            list.Add(item.Value + "]");
                        }
                        return list;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// 取好友列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public List<FriendInfo> GetFriendList(long thisQQ)
        {
            List<FriendInfo> list = new List<FriendInfo>();
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取好友列表").ToString());
            FriendDataList[] ptrArray = new FriendDataList[2];
            GetFriendlist sendmsg = (GetFriendlist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetFriendlist));
            int count = sendmsg(pluginkey, thisQQ, ref ptrArray);
            if (count > 0)
            {
                byte[] pAddrBytes = ptrArray[0].pAddrList;
                for (int i = 0; i < count; i++)
                {
                    byte[] readByte = new byte[4];
                    Array.Copy(pAddrBytes, i * 4, readByte, 0, readByte.Length);
                    IntPtr StuctPtr = new IntPtr(BitConverter.ToInt32(readByte, 0));
                    FriendInfo info = (FriendInfo)Marshal.PtrToStructure(StuctPtr, typeof(FriendInfo));
                    list.Add(info);
                }
            }
            sendmsg = null;
            return list;
        }

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public List<GroupInfo> Getgrouplist(long thisQQ)
        {
            List<GroupInfo> list = new List<GroupInfo>();
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群列表").ToString());
            GroupDataList[] ptrArray = new GroupDataList[2];
            GetGrouplist sendmsg = (GetGrouplist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGrouplist));
            int count = sendmsg(pluginkey, thisQQ, ref ptrArray);
            if (count > 0)
            {
                byte[] pAddrBytes = ptrArray[0].pAddrList;
                for (int i = 0; i < count; i++)
                {
                    byte[] readByte = new byte[4];
                    Array.Copy(pAddrBytes, i * 4, readByte, 0, readByte.Length);
                    IntPtr StuctPtr = new IntPtr(BitConverter.ToInt32(readByte, 0));
                    GroupInfo info = (GroupInfo)Marshal.PtrToStructure(StuctPtr, typeof(GroupInfo));
                    list.Add(info);
                }
            }
            sendmsg = null;
            return list;
        }
        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="gruopNumber"></param>
        /// <returns></returns>
        public List<GroupMemberInfo> GetgroupMemberlist(long thisQQ, long gruopNumber)
        {
            List<GroupMemberInfo> list = new List<GroupMemberInfo>();
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群成员列表").ToString());
            GroupMemberDataList[] ptrArray = new GroupMemberDataList[2];
            GroupMemberlist sendmsg = (GroupMemberlist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupMemberlist));
            int count = sendmsg(pluginkey, thisQQ, gruopNumber, ref ptrArray);
            if (count > 0)
            {
                byte[] pAddrBytes = ptrArray[0].pAddrList;
                for (int i = 0; i < count; i++)
                {
                    byte[] readByte = new byte[4];
                    Array.Copy(pAddrBytes, i * 4, readByte, 0, readByte.Length);
                    IntPtr StuctPtr = new IntPtr(BitConverter.ToInt32(readByte, 0));
                    GroupMemberInfo info = (GroupMemberInfo)Marshal.PtrToStructure(StuctPtr, typeof(GroupMemberInfo));
                    list.Add(info);
                }
            }
            sendmsg = null;
            return list;
        }
        /// <summary>
        /// 取管理层列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="gruopNumber"></param>
        /// <returns>首个为群主</returns>
        public string[] GetAdministratorList(long thisQQ, long gruopNumber)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取管理层列表").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetadministratorList sendmsg = (GetadministratorList)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetadministratorList));
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, gruopNumber));
            string[] adminlist = ret.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            sendmsg = null;
            return adminlist;
        }
        /// <summary>
        /// 框架重启
        /// </summary>
        /// <returns></returns>
        public int ReStart()
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("框架重启").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            Restart sendmsg = (Restart)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(Restart));
            sendmsg(pluginkey);
            sendmsg = null;
            return 1;
        }

        /// <summary>
        /// 处理好友验证事件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="triggerQQ"></param>
        /// <param name="message_seq"></param>
        /// <param name="operate_type"></param>
        /// <returns></returns>
        public void FriendVerificationEvent(long thisQQ, long triggerQQ, long message_seq, FriendVerificationOperateEnum operate_type)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("处理好友验证事件").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            FriendverificationEvent sendmsg = (FriendverificationEvent)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(FriendverificationEvent));
            sendmsg(pluginkey, thisQQ, triggerQQ, message_seq, operate_type);
            sendmsg = null;
        }
        /// <summary>
        /// 处理群验证事件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="source_groupQQ"></param>
        /// <param name="triggerQQ"></param>
        /// <param name="message_seq"></param>
        /// <param name="operate_type"></param>
        /// <param name="event_type"></param>
        /// <param name="refuse_reason"></param>
        public void GroupVerificationEvent(long thisQQ, long source_groupQQ, long triggerQQ, long message_seq, GroupVerificationOperateEnum operate_type, EventTypeEnum event_type, string refuse_reason = "")
        {
            if (event_type == EventTypeEnum.Group_MemberVerifying || event_type == EventTypeEnum.Group_Invited)
            {
                int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("处理群验证事件").ToString());
                IntPtr intPtr = new IntPtr(MsgAddress);
                GroupVerification sendmsg = (GroupVerification)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GroupVerification));
                sendmsg(pluginkey, thisQQ, source_groupQQ, triggerQQ, message_seq, operate_type, event_type, refuse_reason);
                sendmsg = null;
            }
        }


        /// <summary>
        /// 查看转发聊天记录内容
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="resID"></param>
        /// <returns></returns>
        public string ReadForwardedChatHistoryEvent(long thisQQ, string resID)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("查看转发聊天记录内容").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ReadForwardedChatHistory sendmsg = (ReadForwardedChatHistory)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ReadForwardedChatHistory));
            IntPtr intPtr1 = new IntPtr();
            Marshal.StructureToPtr(typeof(MessageEvent), intPtr1, false);
            sendmsg(pluginkey, thisQQ, resID, ref intPtr1);
            MessageEvent messageEvent = (MessageEvent)Marshal.PtrToStructure(intPtr1, typeof(MessageEvent));
            sendmsg = null;
            return messageEvent.MessageContent;
        }
        /// <summary>
        /// 查询好友信息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public FriendInfo GetFriendInfoEvent(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("查询好友信息").ToString());
            GetFriendDataList[] ptrArray = new GetFriendDataList[2];
            GetFriendInfo sendmsg = (GetFriendInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetFriendInfo));
            bool count = sendmsg(pluginkey, thisQQ, otherQQ, ref ptrArray);
            sendmsg = null;
            return ptrArray[0].friendInfo;
        }
        /// <summary>
        /// 查询群信息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherGroupQQ"></param>
        /// <returns></returns>
        public GroupCardInfo GetGroupInfoEvent(long thisQQ, long otherGroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("查询群信息").ToString());
            GroupCardInfoDatList[] ptrArray = new GroupCardInfoDatList[2];
            GetGroupCardInfo sendmsg = (GetGroupCardInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupCardInfo));
            bool count = sendmsg(pluginkey, thisQQ, otherGroupQQ, ref ptrArray);
            sendmsg = null;
            return ptrArray[0].groupCardInfo;
        }
        /// <summary>
        /// 撤回消息_群聊
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="message_random"></param>
        /// <param name="message_req"></param>
        /// <returns></returns>
        public bool Undo_GroupEvent(long thisQQ, long groupQQ, long message_random, int message_req)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("撤回消息_群聊").ToString());
            Undo_Group sendmsg = (Undo_Group)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Undo_Group));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, message_random, message_req);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 撤回消息_私聊本身
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="message_random"></param>
        /// <param name="message_req"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool Undo_PrivateEvent(long thisQQ, long otherQQ, long message_random, int message_req, int time)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("撤回消息_私聊本身").ToString());
            Undo_Private sendmsg = (Undo_Private)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Undo_Private));
            bool ret = sendmsg(pluginkey, thisQQ, otherQQ, message_random, message_req, time);
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 发送好友json消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="friendQQ"></param>
        /// <param name="json_content"></param>
        /// <returns></returns>
        public string SendFriendJSONMessageEvent(long thisQQ, long friendQQ, string json_content)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送好友json消息").ToString());
            SendFriendJSONMessage sendmsg = (SendFriendJSONMessage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendFriendJSONMessage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, friendQQ, json_content));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送免费礼物（绕过广告）
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="gift"></param>
        /// <returns></returns>
        public string SendFreeGiftEvent(long thisQQ, long groupQQ, long otherQQ, FreeGiftEnum gift)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送免费礼物").ToString());
            SendFreeGift sendmsg = (SendFreeGift)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendFreeGift));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, (int)gift));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送群json消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="json_content"></param>
        /// <param name="anonymous"></param>
        /// <returns></returns>
        public string SendGroupJSONMessageEvent(long thisQQ, long groupQQ, string json_content, bool anonymous = false)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送群json消息").ToString());
            SendGroupJSONMessage sendmsg = (SendGroupJSONMessage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupJSONMessage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, json_content, anonymous));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送群临时消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="content"></param>
        /// <param name="random"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public string SendGroupTemporaryMessageEvent(long thisQQ, long groupQQ, long otherQQ, string content, long random = 0, int req = 0)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送群临时消息").ToString());
            SendGroupTemporaryMessage sendmsg = (SendGroupTemporaryMessage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupTemporaryMessage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, content, ref random, ref req));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 分享音乐
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="music_name">歌曲名</param>
        /// <param name="artist_name">歌手名</param>
        /// <param name="redirect_link">跳转地址 点击音乐json后跳转的地址</param>
        /// <param name="cover_link">封面地址 音乐的封面图片地址</param>
        /// <param name="file_path">文件地址 音乐源文件地址，如https://xxx.com/xxx.mp3</param>
        /// <param name="app_type">应用类型 0QQ音乐 1虾米音乐 2酷我音乐 3酷狗音乐 4网易云音乐  默认0</param>
        /// <param name="share_type">分享类型 0私聊 1群聊  默认0</param>
        /// <returns></returns>
        public bool ShareMusicEvent(long thisQQ, long otherQQ, string music_name, string artist_name, string redirect_link, string cover_link, string file_path, MusicAppTypeEnum app_type = MusicAppTypeEnum.QQMusic, MusicShare_Type share_type = MusicShare_Type.GroupMsg)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("分享音乐").ToString());
            ShareMusic sendmsg = (ShareMusic)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ShareMusic));
            bool ret = sendmsg(pluginkey, thisQQ, otherQQ, music_name, artist_name, redirect_link, cover_link, file_path, (int)app_type, (int)share_type);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 更改群聊消息内容<para>使用此命令可以更改当前群聊消息内容，并使更改后的内容投递给之后的插件，无权限返回假</para>
        /// </summary>
        /// <param name="data_pointer"></param>
        /// <param name="new_message_content"></param>
        /// <returns></returns>
        public bool ModifyGroupMessageContentEvent(int data_pointer, string new_message_content)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("更改群聊消息内容").ToString());
            ModifyGroupMessageContent sendmsg = (ModifyGroupMessageContent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ModifyGroupMessageContent));
            bool ret = sendmsg(pluginkey, data_pointer, new_message_content);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 更改私聊消息内容<para>使用此命令可以更改当前私聊消息内容，并使更改后的内容投递给之后的插件，无权限返回假</para>
        /// </summary>
        /// <param name="data_pointer"></param>
        /// <param name="new_message_content"></param>
        /// <returns></returns>
        public bool ModifyPrivateMessageContentEvent(int data_pointer, string new_message_content)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("更改私聊消息内容").ToString());
            ModifyPrivateMessageContent sendmsg = (ModifyPrivateMessageContent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ModifyPrivateMessageContent));
            bool ret = sendmsg(pluginkey, data_pointer, new_message_content);
            sendmsg = null;
            return ret;
        }
        #region 好友红包
        /// <summary>
        /// 好友接龙红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="follow_content">接龙内容</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string FriendFollowRedEnvelopeEvent(long thisQQ, int total_number, int total_amount, long otherQQ, string follow_content, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友接龙红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, otherQQ, follow_content, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 好友画图红包 不支持非好友！
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="question">题目名<para>只能填手Q有的，如：庄周</para></param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string FriendDrawRedEnvelope(long thisQQ, int total_number, int total_amount, long otherQQ, string question, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友画图红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, otherQQ, question, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 好友口令红包 不支持非好友！
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="kouling">口令</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string FriendPasswordRedEnvelope(long thisQQ, int total_number, int total_amount, long otherQQ, string kouling, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友口令红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, otherQQ, kouling, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 好友普通红包 不支持非好友！
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="blessing">祝福语</param>
        /// <param name="skinID">红包皮肤Id<para>红包皮肤Id 1522: 光与夜之恋, 1527: 代号：三国（打了一辈子仗）, 1525: 街霸：对决, 1518: 代号：三国（俺送红包来了）, 1476: 天涯明月刀, 1512: 一人之下，其他皮肤id自己找</para></param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string FriendNormalRedEnvelopeEvent(long thisQQ, int total_number, int total_amount, long otherQQ, string blessing, int skinID, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友普通红包").ToString());
            FriendNormalRedEnvelope sendmsg = (FriendNormalRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendNormalRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, otherQQ, blessing, skinID, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 好友语音红包 不支持非好友！
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="audio_password">语音口令</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string FriendAudioRedEnvelope(long thisQQ, int total_number, int total_amount, long otherQQ, string audio_password, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友语音红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, otherQQ, audio_password, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        #endregion
        #region 群聊红包
        /// <summary>
        /// 群聊画图红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="question">题目名<para>只能填手Q有的，如：庄周</para></param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupDrawRedEnvelopeEvent(long thisQQ, int total_number, int total_amount, long groupQQ, string question, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊画图红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, question, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊口令红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="password">口令</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupPasswordRedEnvelope(long thisQQ, int total_number, int total_amount, long groupQQ, string password, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊口令红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, password, payment_password, card_serial,ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊接龙红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="follow_content">接龙内容</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupFollowRedEnvelope(long thisQQ, int total_number, int total_amount, long groupQQ, string follow_content, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊接龙红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, follow_content, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊拼手气红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="blessing">祝福语</param>
        /// <param name="skinID">皮肤<para>1522光与夜之恋,1527代号:三国(打了一辈子仗),1525街霸:对决,1518代号:三国(俺送红包来了),1476天涯明月刀,1512一人之下。其他皮肤id自己找</para></param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupRandomRedEnvelope(long thisQQ, int total_number, int total_amount, long groupQQ, string blessing, int skinID, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊拼手气红包").ToString());
            FriendNormalRedEnvelope sendmsg = (FriendNormalRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendNormalRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, blessing, skinID, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊普通红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="blessing">祝福语</param>
        /// <param name="skinID">皮肤<para>1522光与夜之恋,1527代号:三国(打了一辈子仗),1525街霸:对决,1518代号:三国(俺送红包来了),1476天涯明月刀,1512一人之下。其他皮肤id自己找</para></param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupNormalRedEnvelope(long thisQQ, int total_number, int total_amount, long groupQQ, string blessing, int skinID, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊普通红包").ToString());
            FriendNormalRedEnvelope sendmsg = (FriendNormalRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendNormalRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, blessing, skinID, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊语音红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="audio_password">语音口令</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupAudioRedEnvelope(long thisQQ, int total_number, int total_amount, long groupQQ, string audio_password, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊语音红包").ToString());
            GroupDrawRedEnvelope sendmsg = (GroupDrawRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupDrawRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, audio_password, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊专属红包
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="total_number">总数量</param>
        /// <param name="total_amount">总金额 单位分</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="otherQQ">领取人 多个领取人QQ用|分隔</param>
        /// <param name="blessing">祝福语</param>
        /// <param name="isEvenlysplit">是否均分</param>
        /// <param name="payment_password">支付密码</param>
        /// <param name="card_serial">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">银行卡支付时，若需要短信验证码，将在此传回验证码信息</param>
        /// <returns></returns>
        public string GroupExclusiveRedEnvelopeEvent(long thisQQ, int total_number, int total_amount, long groupQQ, string otherQQ, string blessing, bool isEvenlysplit, string payment_password, int card_serial, ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊专属红包").ToString());
            GroupExclusiveRedEnvelope sendmsg = (GroupExclusiveRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupExclusiveRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, total_number, total_amount, groupQQ, otherQQ, blessing, isEvenlysplit, payment_password, card_serial, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }

        #endregion
        /// <summary>
        /// 好友文件转发至好友
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="sourceQQ">来源QQ</param>
        /// <param name="targetQQ">目标QQ</param>
        /// <param name="fileID">FileId</param>
        /// <param name="file_name">file_name</param>
        /// <param name="file_size">文件大小</param>
        /// <param name="msgReq">Req 撤回消息用</param>
        /// <param name="Random">Random 撤回消息用</param>
        /// <param name="time">time 撤回消息用</param>
        /// <returns></returns>
        public bool FriendFileToFriendEvent(long thisQQ, long sourceQQ, long targetQQ, string fileID, string file_name, long file_size, int msgReq = 0, long Random = 0, int time = 0)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("好友文件转发至好友").ToString());
            FriendFileToFriend sendmsg = (FriendFileToFriend)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendFileToFriend));
            bool ret = sendmsg(pluginkey, thisQQ, sourceQQ, targetQQ, fileID, file_name, file_size, ref msgReq, ref Random, ref time);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取clientkey
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public string GetClientKeyEvent(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("获取clientkey").ToString());
            GetClientKey sendmsg = (GetClientKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetClientKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取pskey
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="domain">tenpay.com;openmobile.qq.com;docs.qq.com;connect.qq.com;qzone.qq.com;vip.qq.com;gamecenter.qq.com;qun.qq.com;game.qq.com;qqweb.qq.com;ti.qq.com;office.qq.com;mail.qq.com;mma.qq.com</param>
        /// <returns></returns>
        public string GetPSKeyEvent(long thisQQ, string domain)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("获取pskey").ToString());
            GetPSKey sendmsg = (GetPSKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetPSKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, domain));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取skey
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string GetSKey(long thisQQ, string domain)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("获取skey").ToString());
            GetClientKey sendmsg = (GetClientKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetClientKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="orderID">订单号 或者称之为listid</param>
        /// <returns></returns>
        public OrderDetail GetOrderDetailEvent(long thisQQ, string orderID)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("获取订单详情").ToString());
            GetOrderDetail sendmsg = (GetOrderDetail)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetOrderDetail));
            OrderDetaildDataList[] pdatalist = new OrderDetaildDataList[2];
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, orderID, ref pdatalist));
            sendmsg = null;
            return pdatalist[0].orderDetail;
        }
        /// <summary>
        /// 解散群
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public bool DissolveGroupEvent(long thisQQ, long groupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("解散群").ToString());
            DissolveGroup sendmsg = (DissolveGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DissolveGroup));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 禁言群成员
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="groupQQ">群号</param>
        /// <param name="otherQQ">群成员QQ</param>
        /// <param name="time">禁言时长 单位：秒，为0时解除禁言</param>
        /// <returns></returns>
        public bool ShutUpGroupMemberEvent(long thisQQ, long groupQQ, long otherQQ, int time)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("禁言群成员").ToString());
            ShutUpGroupMember sendmsg = (ShutUpGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ShutUpGroupMember));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, time);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 强制取昵称
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string GetNameForceEvent(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("强制取昵称").ToString());
            GetNameForce sendmsg = (GetNameForce)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetNameForce));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取QQ钱包个人信息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public RetQQWalletInformation GetQQWalletPersonalInformationEvent(long thisQQ)
        {
            var ptr = Marshal.AllocHGlobal(4);
            CardInformation CardInfo = new CardInformation();
            Marshal.StructureToPtr(CardInfo, ptr, false);
            CardListIntptr[] ptrs = new CardListIntptr[1];
            ptrs[0].addr = ptr;

            QQWalletInformation QQWalletInfo = new QQWalletInformation();
            QQWalletInfo.Balance = "";
            QQWalletInfo.RealName = "";
            QQWalletInfo.ID = "";
            QQWalletInfo.CardList = ptrs;

            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取QQ钱包个人信息").ToString());
            QQWalletDataList[] QQWallet = new QQWalletDataList[1];
            QQWallet[0].qQWalletInformation = QQWalletInfo;
            GetQQWalletPersonalInformation sendmsg = (GetQQWalletPersonalInformation)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetQQWalletPersonalInformation));
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, ref QQWallet));
            PDataList adminList = (PDataList)Marshal.PtrToStructure(QQWallet[0].qQWalletInformation.CardList[0].addr, typeof(PDataList));
            List<CardInformation> list = new List<CardInformation>();
            if (adminList.Amount > 0)
            {
                byte[] pAddrBytes = adminList.pdatalist;
                for (int i = 0; i < adminList.Amount; i++)
                {
                    byte[] readByte = new byte[4];
                    Array.Copy(pAddrBytes, i * 4, readByte, 0, readByte.Length);
                    IntPtr StuctPtr = new IntPtr(BitConverter.ToInt32(readByte, 0));
                    CardInformation info = (CardInformation)Marshal.PtrToStructure(StuctPtr, typeof(CardInformation));
                    list.Add(info);
                }
            }
            RetQQWalletInformation retQQWalletInformation = new RetQQWalletInformation();
            retQQWalletInformation.ID = QQWallet[0].qQWalletInformation.ID;
            retQQWalletInformation.RealName = QQWallet[0].qQWalletInformation.RealName;
            retQQWalletInformation.Balance = QQWallet[0].qQWalletInformation.Balance;
            retQQWalletInformation.CardList = list;
            Marshal.FreeHGlobal(ptr);
            sendmsg = null;
            return retQQWalletInformation;
        }
        /// <summary>
        /// 取个性签名
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ">可以填框架QQ本身</param>
        /// <returns></returns>
        public string GetSignature(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取个性签名").ToString());
            GetNameForce sendmsg = (GetNameForce)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetNameForce));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取好友在线状态 失败或无权限返回空，支持查询陌生人
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string GetFriendStatus(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取好友在线状态").ToString());
            GetNameForce sendmsg = (GetNameForce)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetNameForce));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取框架QQ
        /// </summary>
        /// <returns></returns>
        public string GetThisQQ()
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取框架QQ").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetPluginDataDirectory sendmsg = (GetPluginDataDirectory)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetPluginDataDirectory));
            //string thisqq = sendmsg(pluginkey);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 从缓存获取昵称
        /// </summary>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string GetNameFromCacheEvent(long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取昵称_从缓存").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetNameFromCache sendmsg = (GetNameFromCache)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetNameFromCache));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群名称_从缓存<para>成功返回群名称，如果是框架QQ没加的群，请使用[查询群信息]，查询后也会记录缓存</para>
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public string GetGroupNameFromCache(long groupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群名称_从缓存").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetNameFromCache sendmsg = (GetNameFromCache)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetNameFromCache));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, groupQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群名片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string GetGroupNicknameEvent(long thisQQ, long groupQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群名片").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetGroupNickname sendmsg = (GetGroupNickname)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetGroupNickname));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, otherQQ));
            sendmsg = null;
            return ret;
        }

        #region 群权限
        /// <summary>
        /// 全员禁言
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_shut_up_all">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool ShutUpAllEvent(long thisQQ, long groupQQ, bool is_shut_up_all)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("全员禁言").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_shut_up_all);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_发起临时会话
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_CreateTemporaryConversation(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_发起临时会话").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_发起新的群聊
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_CreateGroup(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_发起新的群聊").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_匿名聊天
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_Anonymous(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_匿名聊天").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_上传文件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_UploadFile(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_上传文件").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_上传相册
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_UploadPicture(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_上传相册").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_坦白说
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_ChatFrankly(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_坦白说").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_新成员查看历史消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_NewMemberReadChatHistory(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_新成员查看历史消息").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_邀请好友加群
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="is_allowed">是否开启</param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_InviteFriend(long thisQQ, long groupQQ, bool is_allowed)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_邀请好友加群").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            ShutUpAll sendmsg = (ShutUpAll)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(ShutUpAll));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, is_allowed);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_邀请方式设置
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="method">审核方式 1 无需审核;2 需要管理员审核;3 100人以内无需审核 </param>
        /// <returns>失败或无权限返回假</returns>
        public bool GroupPermission_SetInviteMethodEvent(long thisQQ, long groupQQ, GroupPermission_SetInviteMethodEnum method)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_邀请方式设置").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GroupPermission_SetInviteMethod sendmsg = (GroupPermission_SetInviteMethod)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GroupPermission_SetInviteMethod));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, (int)method);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_设置群昵称规则<para>需要管理员权限</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="rules">名片规则</param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool SetGroupNickRulesEvent(long thisQQ, long GroupQQ, string rules)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_设置群昵称规则").ToString());
            SetGroupNickRules sendmsg = (SetGroupNickRules)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupNickRules));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, rules);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_设置群发言频率
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="LimitNumber">限制每分钟多少条发言,为0表示无限制</param>
        /// <returns></returns>
        public bool SetGroupLimitNumberEvent(long thisQQ, long GroupQQ, int LimitNumber)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_设置群发言频率").ToString());
            SetGroupLimitNumber sendmsg = (SetGroupLimitNumber)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupLimitNumber));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, LimitNumber);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群权限_设置群查找方式<para>需要管理员权限</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="method">0不允许,1通过群号或关键词,2仅可通过群号,默认0</param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool SetGroupFindMethodEvent(long thisQQ, long GroupQQ, GroupFindMethodEnum method = 0)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群权限_设置群查找方式").ToString());
            SetGroupLimitNumber sendmsg = (SetGroupLimitNumber)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupLimitNumber));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, (int)method);
            sendmsg = null;
            return ret;
        }
        #endregion
        #region 群文件管理
        /// <summary>
        /// 保存文件到微云
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public string SaveFileToWeiYunEvent(long thisQQ, long groupQQ, string file_id)
        {
            string ret = string.Empty;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("保存文件到微云").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            SaveFileToWeiYun sendmsg = (SaveFileToWeiYun)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SaveFileToWeiYun));
            ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, file_id));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 创建群文件夹
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public string CreateGroupFolderEvent(long thisQQ, long groupQQ, string folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("创建群文件夹").ToString());
            CreateGroupFolder sendmsg = (CreateGroupFolder)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(CreateGroupFolder));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群文件列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="folder">欲查看的文件夹名，根目录留空或填/</param>
        /// <returns></returns>
        public List<GroupFileInformation> GetGroupFileListEvent(long thisQQ, long groupQQ, string folder)
        {
            GroupFileInfoDataList[] pdatalist = new GroupFileInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群文件列表").ToString());
            IntPtr intPtr = new IntPtr(MsgAddress);
            GetGroupFileList sendmsg = (GetGroupFileList)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetGroupFileList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, folder, ref pdatalist));
            if (pdatalist[0].Amount > 0)
            {
                List<GroupFileInformation> list = new List<GroupFileInformation>();
                for (int i = 0; i < pdatalist[0].Amount; i++)
                {
                    byte[] recbyte = new byte[4];
                    Array.Copy(pdatalist[0].pAddrList, i * 4, recbyte, 0, recbyte.Length);
                    IntPtr ptr = new IntPtr(BitConverter.ToInt32(recbyte, 0));
                    GroupFileInformation gf = (GroupFileInformation)Marshal.PtrToStructure(ptr, typeof(GroupFileInformation));
                    //string fn = Marshal.PtrToStringAnsi(gf.FileName);
                    list.Add(gf);
                }
                sendmsg = null;
                return list;
            }
            return null;
        }
        /// <summary>
        /// 转发群文件至好友
        /// </summary>
        /// <param name="thisQQ">框架QQ</param>
        /// <param name="source_groupQQ">来源群号</param>
        /// <param name="target_QQ">目标QQ</param>
        /// <param name="fileID"></param>
        /// <param name="filename"></param>
        /// <param name="filesize"></param>
        /// <param name="msgReq">Req 撤回消息用</param>
        /// <param name="Random">Random 撤回消息用</param>
        /// <param name="time">time 撤回消息用</param>
        /// <returns></returns>
        public bool ForwardGroupFileToFriendEvent(long thisQQ, long source_groupQQ, long target_QQ, string fileID, string filename, long filesize, int msgReq = 0, long Random = 0, int time = 0)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群文件转发至好友").ToString());
            ForwardGroupFileToFriend sendmsg = (ForwardGroupFileToFriend)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ForwardGroupFileToFriend));
            bool ret = sendmsg(pluginkey, thisQQ, source_groupQQ, target_QQ, fileID, filename, filesize, ref msgReq, ref Random, ref time);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群文件转发至群
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="source_groupQQ"></param>
        /// <param name="target_groupQQ"></param>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public bool ForwardGroupFileToGroupEvent(long thisQQ, long source_groupQQ, long target_groupQQ, string fileID)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群文件转发至群").ToString());
            ForwardGroupFileToGroup sendmsg = (ForwardGroupFileToGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ForwardGroupFileToGroup));
            bool ret = sendmsg(pluginkey, thisQQ, source_groupQQ, target_groupQQ, fileID);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 删除群文件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="file_id"></param>
        /// <param name="folder">文件所在的文件夹名，根目录留空或填/</param>
        /// <returns></returns>
        public string DeleteGroupFileEvent(long thisQQ, long groupQQ, string file_id, string folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("删除群文件").ToString());
            DeleteGroupFile sendmsg = (DeleteGroupFile)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DeleteGroupFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, file_id, folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 删除群文件夹
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public string DeleteGroupFolderEvent(long thisQQ, long groupQQ, string folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("删除群文件夹").ToString());
            DeleteGroupFolder sendmsg = (DeleteGroupFolder)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DeleteGroupFolder));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 重命名群文件夹
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="old_folder"></param>
        /// <param name="new_folder"></param>
        /// <returns></returns>
        public string RenameGroupFolderEvent(long thisQQ, long groupQQ, string old_folder, string new_folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("重命名群文件夹").ToString());
            RenameGroupFolder sendmsg = (RenameGroupFolder)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(RenameGroupFolder));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, old_folder, new_folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传群文件 <para>本命令为耗时操作，请另开线程执行，本命令不支持上百mb的文件，无权限时不执行</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="path">文件路径 本地文件路径</param>
        /// <param name="folder">文件夹名 上传到哪个文件夹，填文件夹名，根目录留空或填/</param>
        /// <returns></returns>
        public string UploadGroupFileEvent(long thisQQ, long groupQQ, string path, string folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传群文件").ToString());
            UploadGroupFile sendmsg = (UploadGroupFile)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadGroupFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, path, folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 移动群文件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="file_id"></param>
        /// <param name="old_folder">文件所在的文件夹名，根目录留空或填/</param>
        /// <param name="new_folder">根目录留空或填/</param>
        /// <returns></returns>
        public string MoveGroupFileEvent(long thisQQ, long groupQQ, string file_id, string old_folder, string new_folder)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("移动群文件").ToString());
            MoveGroupFile sendmsg = (MoveGroupFile)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(MoveGroupFile));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, file_id, old_folder, new_folder));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送好友图片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="friendQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <param name="is_flash">是否设置为闪照</param>
        /// <returns></returns>
        public string SendFriendImage(long thisQQ, long friendQQ, string picpath, bool is_flash)
        {
            string piccode = Common.xlzAPI.UploadFriendImageEvent(thisQQ, friendQQ, picpath, is_flash);
            return Common.xlzAPI.SendPrivateMessage(thisQQ, friendQQ, piccode);
        }
        /// <summary>
        /// 上传好友图片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="friendQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <param name="is_flash">是否设置为闪照</param>
        /// <returns>成功返回图片代码</returns>
        public string UploadFriendImageEvent(long thisQQ, long friendQQ, string picpath, bool is_flash)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            //byte[] picture = System.Text.Encoding.UTF8.GetBytes(picpath); 
            //int picsize = picture.Length;
            //IntPtr intPtr = Marshal.AllocHGlobal(picture.Length);
            //Marshal.Copy(picture, 0, intPtr, picture.Length);
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传好友图片").ToString());
            UploadFriendImage sendmsg = (UploadFriendImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFriendImage));
            //string ret = sendmsg(pluginkey, thisQQ, friendQQ, is_flash, intPtr, picsize);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, friendQQ, is_flash, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 图片转为二进制
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private byte[] GetByteArrayByImage(Bitmap bitmap)
        {
            byte[] result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                byte[] array = new byte[memoryStream.Length];
                memoryStream.Position = 0L;
                memoryStream.Read(array, 0, (int)memoryStream.Length);
                memoryStream.Close();
                result = array;
            }
            catch
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 上传群图片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <param name="is_flash">是否设置为闪照</param>
        /// <returns>成功返回图片代码</returns>
        public string UploadGroupImage(long thisQQ, long groupQQ, string picpath, bool is_flash)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            //IntPtr picptr = Marshal.AllocHGlobal(picture.Length);
            //Marshal.Copy(picture, 0, picptr, picture.Length);
            //int picsize = picture.Length;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传群图片").ToString());
            UploadFriendImage sendmsg = (UploadFriendImage)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFriendImage));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, is_flash, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送群图片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <param name="is_flash">是否设置为闪照</param>
        /// <returns>成功返回图片代码</returns>
        public string SendGroupImage(long thisQQ, long groupQQ, string picpath, bool is_flash)
        {
            string piccode = Common.xlzAPI.UploadGroupImage(thisQQ, groupQQ, picpath, is_flash);
            return Common.xlzAPI.SendGroupMessage(thisQQ, groupQQ, piccode);
        }

        /// <summary>
        /// 上传群头像
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <returns></returns>
        public bool UploadGroupAvatarEvent(long thisQQ, long groupQQ, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            //IntPtr picptr = Marshal.AllocHGlobal(picture.Length);
            //Marshal.Copy(picture, 0, picptr, picture.Length);
            //int picsize = picture.Length;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传群头像").ToString());
            UploadGroupAvatar sendmsg = (UploadGroupAvatar)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadGroupAvatar));
            //return sendmsg(pluginkey, thisQQ, groupQQ, picptr, picsize);
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, picture, picture.Length);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <returns></returns>
        public string UploadAvatarEvent(long thisQQ, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            //IntPtr picptr = Marshal.AllocHGlobal(picture.Length);
            //Marshal.Copy(picture, 0, picptr, picture.Length);
            //int picsize = picture.Length;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传头像").ToString());
            UploadAvatar sendmsg = (UploadAvatar)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadAvatar));
            //return sendmsg(pluginkey, thisQQ, picptr, picsize);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传好友语音
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="friendQQ"></param>
        /// <param name="audio_type">语音类型 <para>0普通语音,1变声语音,2文字语音,3红包匹配语音</para></param>
        /// <param name="audio_text">语音文字<para>文字语音填附加文字(腾讯貌似会自动替换为语音对应的文本),匹配语音填a、b、s、ss、sss，注意是小写</para></param>
        /// <param name="audio">语音数据 需要使用silk编码</param>
        /// <returns></returns>
        public string UploadFriendAudioEvent(long thisQQ, long friendQQ, AudioTypeEnum audio_type, string audio_text, byte[] audio)
        {
            //byte[] audiobyte = Encoding.UTF8.GetBytes(audio);
            //IntPtr intPtr = Marshal.AllocHGlobal(audio.Length);
            //Marshal.Copy(audio, 0, intPtr, audio.Length);
            //int size = audio.Length;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传好友语音").ToString());
            UploadFriendAudio sendmsg = (UploadFriendAudio)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFriendAudio));
            //return sendmsg(pluginkey, thisQQ, friendQQ, (int)audio_type, audio_text, intPtr, size);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, friendQQ, (int)audio_type, audio_text, audio, audio.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传群语音
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="audio_type">语音类型 <para>0普通语音,1变声语音,2文字语音,3红包匹配语音</para></param>
        /// <param name="audio_text">语音文字<para>文字语音填附加文字(腾讯貌似会自动替换为语音对应的文本),匹配语音填a、b、s、ss、sss，注意是小写</para></param>
        /// <param name="audio">语音数据 需要使用silk编码</param>
        /// <returns></returns>
        public string UploadGroupAudio(long thisQQ, long groupQQ, AudioTypeEnum audio_type, string audio_text, byte[] audio)
        {
            //byte[] audiobyte = Encoding.UTF8.GetBytes(audio);
            //IntPtr intPtr = Marshal.AllocHGlobal(audio.Length);
            //Marshal.Copy(audio, 0, intPtr, audio.Length);
            //int size = audio.Length;
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传群语音").ToString());
            UploadFriendAudio sendmsg = (UploadFriendAudio)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadFriendAudio));
            //return sendmsg(pluginkey, thisQQ, groupQQ, (int)audio_type, audio_text, intPtr, size);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, (int)audio_type, audio_text, audio, audio.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上报当前位置 <para>大约3s上报一次，不得过快，失败或无权限返回假</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="Longitude">经度</param>
        /// <param name="Latitude">纬度</param>
        /// <returns></returns>
        public bool ReportCurrentEvent(long thisQQ, long groupQQ, double Longitude, double Latitude)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上报当前位置").ToString());
            ReportCurrent sendmsg = (ReportCurrent)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ReportCurrent));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, Longitude, Latitude);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设置位置共享 <para>开启后需要上报位置，大约3s上报一次，否则会自动关闭，失败或无权限返回假</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="Longitude">经度</param>
        /// <param name="Latitude">纬度</param>
        /// <param name="is_enabled">是否开启</param>
        /// <returns></returns>
        public bool SetLocationShareEvent(long thisQQ, long groupQQ, double Longitude, double Latitude, bool is_enabled)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设置位置共享").ToString());
            SetLocationShare sendmsg = (SetLocationShare)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetLocationShare));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, Longitude, Latitude, is_enabled);
            sendmsg = null;
            return ret;
        }
        #endregion


        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string RemoveFriend(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("删除好友").ToString());
            GetadministratorList sendmsg = (GetadministratorList)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetadministratorList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 删除群成员
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="is_verification_refused">拒绝加群申请</param>
        /// <returns></returns>
        public bool RemoveGroupMemberEvent(long thisQQ, long groupQQ, long otherQQ, bool is_verification_refused)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("删除群成员").ToString());
            RemoveGroupMember sendmsg = (RemoveGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(RemoveGroupMember));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, is_verification_refused);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设置管理员
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="is_administrator">取消或设置管理</param>
        /// <returns>失败或无权限返回假</returns>
        public bool SetAdministratorEvent(long thisQQ, long groupQQ, long otherQQ, bool is_administrator)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设置管理员").ToString());
            RemoveGroupMember sendmsg = (RemoveGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(RemoveGroupMember));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, is_administrator);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设置群名片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ">可以是自己，无权限修改别人时会失败</param>
        /// <param name="nickname">新名片</param>
        /// <returns></returns>
        public string SetGroupNicknameEvent(long thisQQ, long groupQQ, long otherQQ, string nickname)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设置群名片").ToString());
            SetGroupNickname sendmsg = (SetGroupNickname)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupNickname));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, nickname));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设置在线状态
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="main">主要在线状态</param>
        /// <param name="sun">详细在线状态 当main为Online(在线)时，可进一步设置详细在线状态</param>
        /// <param name="battery">电量 当sun为ShowBattery(我的电量)时，可以设置上报电量，取值1到100</param>
        /// <returns>失败或无权限返回false</returns>
        public bool SetStatusEvent(long thisQQ, StatusTypeEnum main, StatusOnlineTypeEnum sun, int battery)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设置在线状态").ToString());
            SetStatus sendmsg = (SetStatus)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetStatus));
            bool ret = sendmsg(pluginkey, thisQQ, (int)main, (int)sun, battery);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设置专属头衔<para>只能群主调用</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="name">专属头衔</param>
        /// <returns></returns>
        public bool SetexclusivetitleEvent(long thisQQ, long groupQQ, long otherQQ, string name)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设置专属头衔").ToString());
            Setexclusivetitle sendmsg = (Setexclusivetitle)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Setexclusivetitle));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, otherQQ, name);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 机器人是否被禁言
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public long IsShuttedUpEvent(long thisQQ, long groupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("是否被禁言").ToString());
            IsShuttedUp sendmsg = (IsShuttedUp)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(IsShuttedUp));
            long ret = sendmsg(pluginkey, thisQQ, groupQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="verification">问题答案<para>可设置回答问题答案或是验证消息，多个问题答案用"|"分隔开</para></param>
        /// <param name="comment">备注<para>自定义给对方的备注</para></param>
        /// <returns></returns>
        public string AddFriendEvent(long thisQQ, long otherQQ, string verification, string comment)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("添加好友").ToString());
            AddFriend sendmsg = (AddFriend)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(AddFriend));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ, verification, comment));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 添加群<para>注意加群腾讯不会判断你是否在群内，你在群内或需要付费入群都会直接发送验证消息</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="verification">验证消息：可设置回答问题答案或是验证消息</param>
        /// <returns></returns>
        public string AddGroupEvent(long thisQQ, long groupQQ, string verification)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("添加群").ToString());
            AddGroup sendmsg = (AddGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(AddGroup));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, groupQQ, verification));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 退群
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public bool QuitGroupEvent(long thisQQ, long groupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("退群").ToString());
            QuitGroup sendmsg = (QuitGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(QuitGroup));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 修改个性签名
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="signature">签名</param>
        /// <param name="location">可自定义签名地点</param>
        /// <returns>失败或无权限返回假</returns>
        public bool SetSignatureEvent(long thisQQ, string signature, string location)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("修改个性签名").ToString());
            SetSignature sendmsg = (SetSignature)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetSignature));
            bool ret = sendmsg(pluginkey, thisQQ, signature, location);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 修改昵称
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SetNameEvent(long thisQQ, string name)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("修改昵称").ToString());
            SetName sendmsg = (SetName)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetName));
            bool ret = sendmsg(pluginkey, thisQQ, name);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置屏蔽好友
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="is_blocked">是否屏蔽</param>
        /// <returns></returns>
        public string SetBlockFriendEvent(long thisQQ, long otherQQ, bool is_blocked)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置屏蔽好友").ToString());
            SetBlockFriend sendmsg = (SetBlockFriend)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetBlockFriend));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ, is_blocked));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置群消息接收
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ"></param>
        /// <param name="set_type">设置类型 <para>1接收并提醒 2收进群助手 3屏蔽群消息 4接收不提醒</para></param>
        /// <returns>失败或无权限返回假，此API未对返回结果进行分析，返回真不一定成功</returns>
        public bool SetGroupMessageReceiveEvent(long thisQQ, long groupQQ, IsGroupRecviceEnum set_type)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置群消息接收").ToString());
            SetGroupMessageReceive sendmsg = (SetGroupMessageReceive)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetGroupMessageReceive));
            bool ret = sendmsg(pluginkey, thisQQ, groupQQ, (int)set_type);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置特别关心好友
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="is_special">是否关心</param>
        /// <returns></returns>
        public string SetSpecialFriendEvent(long thisQQ, long otherQQ, bool is_special)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置特别关心好友").ToString());
            SetSpecialFriend sendmsg = (SetSpecialFriend)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetSpecialFriend));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ, is_special));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 提交支付验证码  用于配合发红包使用  ---  发红包返回的 验证码信息，框架作者似乎忘记了返回 所以此部分无法使用
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="captcha_information">验证码信息<para>银行卡发红包时传回的</para></param>
        /// <param name="captcha">验证码<para>手机收到的短信验证码</para></param>
        /// <param name="payment_password">支付密码<para>用于验证并支付</para></param>
        /// <returns></returns>
        public string SubmitPaymentCaptchaEvent(long thisQQ, ref CaptchaInformation captcha_information, string captcha, string payment_password)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("提交支付验证码").ToString());
            SubmitPaymentCaptcha sendmsg = (SubmitPaymentCaptcha)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SubmitPaymentCaptcha));
            CaptchaInformation[] captchaInformation = new CaptchaInformation[2];
            captchaInformation[0] = captcha_information;
            IntPtr intPtr = Marshal.AllocHGlobal(captchaInformation.Length);
            Marshal.StructureToPtr(captchaInformation, intPtr, false);
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, intPtr, captcha, payment_password));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 登录指定QQ <para>敏感权限，建议使用前检查是否有权限，</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns>返回真表示成功投递密码登录任务，不代表对应QQ登录成功</returns>
        public bool LoginSpecifyQQEvent(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("登录指定QQ").ToString());
            LoginSpecifyQQ sendmsg = (LoginSpecifyQQ)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(LoginSpecifyQQ));
            bool ret = sendmsg(pluginkey, thisQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 下线指定QQ <para>敏感权限，建议使用前检查是否有权限，</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns>返回真表示成功投递下线任务，不代表对应QQ下线成功</returns>
        public bool SignoutQQEvent(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("下线指定QQ").ToString());
            LoginSpecifyQQ sendmsg = (LoginSpecifyQQ)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(LoginSpecifyQQ));
            bool ret = sendmsg(pluginkey, thisQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送输入状态 <para>在与他人私聊时，在发消息前使用，显得更有真实感，输入状态默认为1</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="ohterQQ"></param>
        /// <param name="iMEStatus">1:正在输入,2:关闭显示,3:正在说话</param>
        /// <returns></returns>
        public bool SendIMEStatusEvent(long thisQQ,long ohterQQ, IMEStatusEnum iMEStatus)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送输入状态").ToString());
            SendIMEStatus sendmsg = (SendIMEStatus)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendIMEStatus));
            bool ret = sendmsg(pluginkey, thisQQ, ohterQQ, (int)iMEStatus);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// api是否有权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool CheckPermissionEvent(PermissionEnum permission)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("api是否有权限").ToString());
            CheckPermission sendmsg = (CheckPermission)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(CheckPermission));
            bool ret = sendmsg(pluginkey, (int)permission);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// QQ点赞
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public string QQLikeEvent(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("QQ点赞").ToString());
            QQLike sendmsg = (QQLike)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(QQLike));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ));
            sendmsg = null;
            return ret;
        }
        #region
        /// <summary>
        /// Silk解码
        /// </summary>
        /// <param name="audio_path">音频文件路径<para>注意文件后缀必须和文件格式相对应</para></param>
        /// <returns>返回null 可能是corn文件夹缺少语音转码库，请自行到官网或交流群下载</returns>
        public byte[] SilkDecoding(string audio_path)
        {
            SilkHelp silkHelp = new SilkHelp();
            return silkHelp.SilkDecoding(audio_path);
        }
        /// <summary>
        /// Silk编码
        /// </summary>
        /// <param name="audio_path">音频文件路径<para>注意文件后缀必须和文件格式相对应</para></param>
        /// <returns>返回null 可能是corn文件夹缺少语音转码库，请自行到官网或交流群下载</returns>
        public byte[] SilkEncoding(string audio_path)
        {
            SilkHelp silkHelp = new SilkHelp();
            return silkHelp.SilkEncoding(audio_path);
        }
        /// <summary>
        /// arm编码
        /// </summary>
        /// <param name="audio_path">音频文件路径<para>注意文件后缀必须和文件格式相对应</para></param>
        /// <returns>返回null 可能是corn文件夹缺少语音转码库，请自行到官网或交流群下载</returns>
        public byte[] ArmEncoding(string audio_path)
        {
            SilkHelp silkHelp = new SilkHelp();
            return silkHelp.AmrEncoding(audio_path);
        }
        #endregion
        /// <summary>
        /// 修改资料 <para>生日、家乡、所在地 参数格式和子参数数量必须正确，否则修改资料无法成功，不需要修改的项就不要填</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="name">昵称<para>如果用户没有填此项，就不加入json，否则会出错</para></param>
        /// <param name="sex">性别</param>
        /// <param name="birthday">生日<para>格式：2020/5/5 均为整数</para></param>
        /// <param name="Profession">职业</param>
        /// <param name="CompanyName">公司名</param>
        /// <param name="city">所在地<para>国家代码|省份代码|市代码|区字母|区代码，如：49|13110|56|NK|51，表示中国江西省吉安市青原区，这些数据是腾讯的数据，非国际数据</para></param>
        /// <param name="hometown">家乡<para>国家代码|省份代码|市代码|区字母|区代码，如：49|13110|56|NK|51，表示中国江西省吉安市青原区，这些数据是腾讯的数据，非国际数据</para></param>
        /// <param name="email">邮箱</param>
        /// <param name="personalStatement">个人说明</param>
        /// <returns></returns>
        public bool ModifyinformationEvent(long thisQQ,string name,SexEnum sex, string birthday, ProfessionEnum Profession,string CompanyName,string city,string hometown,string email,string personalStatement)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            PersonalInfo personalInfo = new PersonalInfo();
            personalInfo.昵称 = name;
            personalInfo.性别 = (int)sex;
            personalInfo.生日 = birthday;
            personalInfo.职业 = (int)Profession;
            personalInfo.公司名 = CompanyName;
            personalInfo.所在地 = city;
            personalInfo.家乡 = hometown;
            personalInfo.邮箱 = email;
            personalInfo.个人说明= personalStatement;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(personalInfo);

            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("修改资料").ToString());
            Modifyinformation sendmsg = (Modifyinformation)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Modifyinformation));
            bool ret = sendmsg(pluginkey, thisQQ, json);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群未领红包
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <returns>成功返回未领红包数量，注意：使用此API获取的红包只能用手Q上"群未领红包"入口的http请求领取</returns>
        public List<NotReRedEnvelopes> GetRedEnvelopeEvent(long thisQQ, long GroupQQ)
        {
            RedEnvelopesDataList[] reDataList = new RedEnvelopesDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群未领红包").ToString());
            GetRedEnvelope sendmsg = (GetRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRedEnvelope));
            int count = sendmsg(pluginkey, thisQQ, GroupQQ, ref reDataList);
            List<NotReRedEnvelopes> list = new List<NotReRedEnvelopes>();
            if (count > 0)
            {
                byte[] pAddrBytes = reDataList[0].pAddrList;
                for (int i = 0; i < count; i++)
                {
                    byte[] readByte = new byte[4];
                    Array.Copy(pAddrBytes, i * 4, readByte, 0, readByte.Length);
                    IntPtr StuctPtr = new IntPtr(BitConverter.ToInt32(readByte, 0));
                    NotReRedEnvelopes info = (NotReRedEnvelopes)Marshal.PtrToStructure(StuctPtr, typeof(NotReRedEnvelopes));
                    list.Add(info);
                }
            }
            sendmsg = null;
            return list;
        }
        /// <summary>
        /// 打好友电话 -- 不建议频繁使用<para>可向好友发起语音通话(不能传递语音数据)</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        public void CallPhoneEvent(long thisQQ,long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("打好友电话").ToString());
            CallPhone sendmsg = (CallPhone)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(CallPhone));
            sendmsg(pluginkey, thisQQ, otherQQ);
            sendmsg = null;
        }
        /// <summary>
        /// 是否上传了文件
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool IsUploadfiles(string msg)
        {
            string pattern = @"\[file,fileId=(.)+,fileName=(.)+,fileSize=(.)+\]";
            return Regex.IsMatch(msg, pattern);
        }
        /// <summary>
        /// 取群文件下载地址
        /// </summary>
        /// <param name="thisQQ">框架QQ必须在群内</param>
        /// <param name="GroupQQ">群号</param>
        /// <param name="fileid">文件id</param>
        /// <param name="filename">文件名<para>可自定义，必须带文件后缀</para></param>
        /// <returns>文件下载地址在返回的json里面，具有时效性，请及时下载</returns>
        public string GroupFileDownloadLinkEvent(long thisQQ,long GroupQQ,string fileid,string filename)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群文件下载地址").ToString());
            GroupFileDownloadLink sendmsg = (GroupFileDownloadLink)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupFileDownloadLink));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, fileid, filename));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 头像双击_好友
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <returns></returns>
        public bool DoubleclickFirendFacePic(long thisQQ, long otherQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("头像双击_好友").ToString());
            QuitGroup sendmsg = (QuitGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(QuitGroup));
            bool ret = sendmsg(pluginkey, thisQQ, otherQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 头像双击_群
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public bool DoubleclickGroupFacePic(long thisQQ, long otherQQ,long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("头像双击_群").ToString());
            DoubleclickGroupFace sendmsg = (DoubleclickGroupFace)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(DoubleclickGroupFace));
            bool ret = sendmsg(pluginkey, thisQQ, otherQQ, GroupQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊置顶
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="istop">是否置顶,默认假</param>
        /// <returns>成功返回真，失败或无权限返回假</returns>
        public bool GroupTopEvent(long thisQQ, long GroupQQ,bool istop = false)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊置顶").ToString());
            GroupTop sendmsg = (GroupTop)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupTop));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ,istop);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 私聊置顶
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="istop">是否置顶,默认假</param>
        /// <returns>成功返回真，失败或无权限返回假</returns>
        public bool PrivateTopEvent(long thisQQ, long otherQQ, bool istop = false)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("私聊置顶").ToString());
            GroupTop sendmsg = (GroupTop)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupTop));
            bool ret = sendmsg(pluginkey, thisQQ, otherQQ, istop);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取加群链接
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public string GroupTopEvent(long thisQQ, long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取加群链接").ToString());
            GetadministratorList sendmsg = (GetadministratorList)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetadministratorList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 设为精华<para>需要管理员权限</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="MsgReq"></param>
        /// <param name="MsgRandom"></param>
        /// <returns>置指定群消息为精华内容,成功返回真,失败或无权限返回假</returns>
        public bool SetEssenceEvent(long thisQQ, long GroupQQ, int MsgReq,long MsgRandom)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("设为精华").ToString());
            SetEssence sendmsg = (SetEssence)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetEssence));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, MsgReq, MsgRandom);
            sendmsg = null;
            return ret;
        }
        
        /// <summary>
        /// 邀请好友加群<para>邀请一个好友或从群聊中邀请一个QQ加入指定群聊，需要群聊开启了邀请</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ">让好友加入的群聊</param>
        /// <param name="otherQQ">被邀请的QQ,如果参数三不为0则通过参数三的群号邀请,否则视为邀请好友</param>
        /// <param name="otherGroupQQ">必须在群里,如果不为0则从群中邀请该目标</param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool InvitefriendJoinGroup(long thisQQ, long GroupQQ,long otherQQ,long otherGroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("邀请好友加群").ToString());
            FriendjoinGroup sendmsg = (FriendjoinGroup)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendjoinGroup));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, otherQQ, otherGroupQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置群内消息通知<para>设置群内指定QQ的消息通知</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="metohd">方式<para>0不接收此人消息,1特别关注,2默认(接受此人消息) 如果参数为空则默认方式为2</para></param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool GroupNoticeMethodEvent(long thisQQ, long GroupQQ, long otherQQ, GroupNoticeMethodEnum metohd)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置群内消息通知").ToString());
            GroupNoticeMethod sendmsg = (GroupNoticeMethod)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupNoticeMethod));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, otherQQ, (int)metohd);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群成员简略信息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public GroupMemberBriefInfo GetGroupMemberBriefInfoEvent(long thisQQ, long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群成员简略信息").ToString());
            GetGroupMemberBriefInfo sendmsg = (GetGroupMemberBriefInfo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGroupMemberBriefInfo));
            GMBriefDataList[] gMBriefDataLists = new GMBriefDataList[2];
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, ref gMBriefDataLists));
            AdminListDataList adminList = (AdminListDataList)Marshal.PtrToStructure(gMBriefDataLists[0].groupMemberBriefInfo.AdminiList, typeof(AdminListDataList));
            GroupMemberBriefInfo groupMemberBriefInfo = new GroupMemberBriefInfo();
            groupMemberBriefInfo.GroupMAax = gMBriefDataLists[0].groupMemberBriefInfo.GroupMAax;
            groupMemberBriefInfo.GroupOwner = gMBriefDataLists[0].groupMemberBriefInfo.GroupOwner;
            groupMemberBriefInfo.GruoupNum = gMBriefDataLists[0].groupMemberBriefInfo.GruoupNum;
            Array.Resize(ref adminList.pdatalist, adminList.Amount);//重置数组大小
            long[] pdatalist = adminList.pdatalist;
            groupMemberBriefInfo.AdminiList = pdatalist;
            //byte[] pdatalist = groupMemberInfo.pdatalist;
            //byte[] readbyte = new byte[8];
            //Array.Copy(pdatalist, 0, readbyte, 0, readbyte.Length);
            //UInt64 qq = BitConverter.ToUInt64(readbyte, 0);
            sendmsg = null;
            return groupMemberBriefInfo;
        }
        /// <summary>
        /// 修改群名称<para>需要管理员权限</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="NewGroupName"></param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool UpdataGroupNameEvent(long thisQQ,long GroupQQ, string NewGroupName)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("修改群名称").ToString());
            UpdataGroupName sendmsg = (UpdataGroupName)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UpdataGroupName));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, NewGroupName);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 重载自身
        /// </summary>
        /// <param name="dllpath">若需重载自身并替换更新自身，在此处填入新dll文件路径</param>
        public void ReloadItSelfEvent(string dllpath = null)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("重载自身").ToString());
            ReloadItSelf sendmsg = (ReloadItSelf)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ReloadItSelf));
            sendmsg(pluginkey, dllpath);
            sendmsg = null;
        }
        /// <summary>
        /// 下线PCQQ
        /// </summary>
        /// <param name="PCQQ"></param>
        /// <returns>成功返回真,失败或无权限返回假</returns>
        public bool OfflinePCQQEvent(long PCQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("下线PCQQ").ToString());
            OfflinePCQQ sendmsg = (OfflinePCQQ)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(OfflinePCQQ));
            bool ret = sendmsg(pluginkey, PCQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取框架版本
        /// </summary>
        /// <returns></returns>
        public string GetFrameVersionEvent()
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取框架版本").ToString());
            GetFrameVersion sendmsg = (GetFrameVersion)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetFrameVersion));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 登录网页取ck
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="JumpUrl">不能url编码！如QQ空间是：https://h5.qzone.qq.com/mqzone/index 群：https://qun.qq.com</param>
        /// <param name="appid">如QQ空间是：549000929，群：715030901</param>
        /// <param name="daid">如QQ空间是：5；群：73</param>
        /// <returns></returns>
        public string GetWebCookiesEvent(long thisQQ,string JumpUrl,string appid,string daid)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("登录网页取ck").ToString());
            GetWebCookies sendmsg = (GetWebCookies)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetWebCookies));
            string retCookies = string.Empty;
            bool ret =sendmsg(pluginkey, thisQQ, JumpUrl, appid, daid, ref retCookies);
            sendmsg = null;
            return retCookies;
        }
        /// <summary>
        /// 发送群公告
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="title">标题<para>支持emoji表情,如：\uD83D\uDE01</para></param>
        /// <param name="msgcotent">内容<para>支持emoji表情,如：\uD83D\uDE01</para></param>
        /// <param name="picpath">图片,图片必需大于300*200像素<para>在公告当中插入图片,如果设置了[腾讯视频]参数,则不显示图片只显示视频</para></param>
        /// <param name="video">公告当中插入视频,只支持腾讯视频,如：https://v.qq.com/x/cover/4gl2i78zd9idpi0/j0024zknymk.html</param>
        /// <param name="isShow">弹窗展示</param>
        /// <param name="isConfrim">需要确认</param>
        /// <param name="isTop">置顶</param>
        /// <param name="isSendNewMember">发送给新成员</param>
        /// <param name="setGroupNickName">引导修改群昵称</param>
        /// <returns>ec=0表示成功</returns>
        public string SetAnnouncementEvent(long thisQQ, long GroupQQ, string title, string msgcotent, string picpath,string video, bool isShow = false, bool isConfrim=false, bool isTop=false, bool isSendNewMember=false, bool setGroupNickName = false)
        {
            byte[] picture = null;
            if (!string.IsNullOrEmpty(picpath))
            {
                Bitmap bitmap = new Bitmap(picpath);
                picture = GetByteArrayByImage(bitmap);
            }
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送群公告").ToString());
            SetAnnouncement sendmsg = (SetAnnouncement)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetAnnouncement));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, title, msgcotent, video, isShow, isConfrim, isTop, isSendNewMember, setGroupNickName, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群成员信息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="groupQQ">群号</param>
        /// <param name="otherQQ">群成员QQ</param>
        /// <returns></returns>
        public OneGroupMemberInfo GetOneGroupMemberInfo(long thisQQ,long GroupQQ, long otherQQ)
        {
            OneGroupMemberDataList[] pdataLists = new OneGroupMemberDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群成员信息").ToString());
            GetOneGroupMember sendmsg = (GetOneGroupMember)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetOneGroupMember));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, otherQQ,ref pdataLists));
            sendmsg = null;
            return pdataLists[0].oneGroupMemberInfo;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="mailaddr">邮箱地址</param>
        /// <param name="mailtitle">邮件标题</param>
        /// <param name="msgContent">邮件内容<para>支持html</para></param>
        /// <returns></returns>
        public string SendMailEvent(long thisQQ,string mailaddr,string mailtitle,string msgContent)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送邮件").ToString());
            SendMail sendmsg = (SendMail)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendMail));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, mailaddr, mailtitle, msgContent));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// QQ bkn
        /// </summary>
        /// <param name="skey"></param>
        /// <returns></returns>
        public long GetBkn(string skey)
        {
            var hash = 5381;
            for (int i = 0, len = skey.Length; i < len; ++i)
            {
                hash += (hash << 5) + (int)skey[i];
            }
            return hash & 2147483647;
        }
        /// <summary>
        /// QQ gtk
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public long GetGTK(string sKey)
        {
            int hash = 5381;
            for (int i = 0, len = sKey.Length; i < len; ++i)
            {
                hash += (hash << 5) + (int)sKey[i];
            }
            return (hash & 0x7fffffff);
        }
        /// <summary>
        /// 组Cookie<para>需要获取skey和获取pskey权限</para><para>有时效性，随时可能失效</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="domin"></param>
        /// <param name="retCookie"></param>
        /// <param name="skey"></param>
        /// <param name="pskey"></param>
        public void GetCookie(long thisQQ, string domin,ref string retCookie,ref string skey,ref string pskey)
        {
            skey = Common.xlzAPI.GetSKey(thisQQ, domin);
            pskey = Common.xlzAPI.GetPSKeyEvent(thisQQ, domin);
            retCookie = $"uin=o{thisQQ}; skey={skey}; pt2gguin=o{thisQQ}; p_uin=o{thisQQ}; p_skey={pskey};";
        }
        /// <summary>
        /// 组Cookie<para>需要获取skey和获取pskey权限</para><para>有时效性，随时可能失效</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="domin"></param>
        public string GetCookie(long thisQQ, string domin)
        {
            string skey = Common.xlzAPI.GetSKey(thisQQ, domin);
            string pskey = Common.xlzAPI.GetPSKeyEvent(thisQQ, domin);
            string retCookie = $"uin=o{thisQQ}; skey={skey}; pt2gguin=o{thisQQ}; p_uin=o{thisQQ}; p_skey={pskey};";
            return retCookie;
        }
        /// <summary>
        /// 取钱包cookie<para>敏感API,框架4h刷新一次</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public string GetMoneyCookie(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取钱包cookie").ToString());
            GetClientKey sendmsg = (GetClientKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetClientKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取手Q邮箱cookie<para>敏感API,框架4h刷新一次,邮箱sid在cookie当中,键名为xxsid</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public string GetMailCookie(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取手Q邮箱cookie").ToString());
            GetClientKey sendmsg = (GetClientKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetClientKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="Amount">转账金额 单位分</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="leaveMsg">转账留言<para>支持emoji</para></param>
        /// <param name="type">转账类型</param>
        /// <param name="PaymentPWD">支付密码</param>
        /// <param name="bankCard">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="captchaInfo">验证码信息<para>银行卡支付时，若需要短信验证码，将在此传回验证码信息</para></param>
        /// <returns></returns>
        public string TransferEvent(long thisQQ,int Amount,long otherQQ,string leaveMsg, TransferTypeEnum type,string PaymentPWD,int bankCard,ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("转账").ToString());
            Transfer sendmsg = (Transfer)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Transfer));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, Amount, otherQQ,leaveMsg, (int)type, PaymentPWD, bankCard, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 余额提现
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="Amount">提现金额 单位分</param>
        /// <param name="PaymentPWD">支付密码</param>
        /// <param name="bankCard">银行卡序列<para>指定提现到的银行卡</para></param>
        /// <returns></returns>
        public string BalanceWithdrawalEvent(long thisQQ,int Amount, string PaymentPWD, int bankCard)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("余额提现").ToString());
            BalanceWithdrawal sendmsg = (BalanceWithdrawal)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(BalanceWithdrawal));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, Amount, bankCard, PaymentPWD));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取收款链接
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="Amount">指定收款金额,单位：分</param>
        /// <param name="desc">说明文本</param>
        /// <returns>返回收款链接,可以借此生成收款二维码</returns>
        public string GetRecPaymentEvent(long thisQQ, int Amount, string desc)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取收款链接").ToString());
            GetRecPayment sendmsg = (GetRecPayment)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetRecPayment));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, Amount, desc));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群小视频下载地址
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ">来源群号</param>
        /// <param name="SourceQQ">来源QQ</param>
        /// <param name="param"></param>
        /// <param name="harsh1"></param>
        /// <param name="filename">文件名(如：xxx.mp4),必须带上文件后缀</param>
        /// <returns>成功返回json含下载链接</returns>
        public string GetGroupSmallVideoDownloadUrl(long thisQQ,long GroupQQ,long SourceQQ,string param,string harsh1,string filename)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群小视频下载地址").ToString());
            SmallVideoDownloadUrl sendmsg = (SmallVideoDownloadUrl)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SmallVideoDownloadUrl));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, SourceQQ, param, harsh1, filename));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取私聊小视频下载地址
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="SourceQQ">来源QQ</param>
        /// <param name="param"></param>
        /// <param name="harsh1"></param>
        /// <param name="filename">文件名(如：xxx.mp4),必须带上文件后缀</param>
        /// <returns>成功返回json含下载链接</returns>
        public string GetFrienderSmallVideoDownloadUrl(long thisQQ, long SourceQQ, string param, string harsh1, string filename)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取私聊小视频下载地址").ToString());
            FriendSmallVideoDownloadUrl sendmsg = (FriendSmallVideoDownloadUrl)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(FriendSmallVideoDownloadUrl));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ,SourceQQ, param, harsh1, filename));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传小视频<para>请另开线程调用本API,使用的手机录小视频入口,因此不支持较大文件</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ">得到的文本代码也可在私聊使用,上传到私聊时,群号可乱填</param>
        /// <param name="videopath">本地小视频路径</param>
        /// <param name="picpath">小视频封面图</param>
        /// <returns>成功返回文本代码</returns>
        public string UploadVideoEvent(long thisQQ, long GroupQQ,string videopath,string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传小视频").ToString());
            UploadVideo sendmsg = (UploadVideo)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadVideo));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, videopath, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送好友xml消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="otherQQ"></param>
        /// <param name="xmlcode">xml代码</param>
        /// <param name="Random">撤回消息用</param>
        /// <param name="Req">撤回消息用</param>
        /// <returns>成功返回的time用于撤回消息</returns>
        public string SendFriendXmlEvent(long thisQQ, long otherQQ, string xmlcode, ref long Random,ref int Req)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送好友xml消息").ToString());
            SendFriendXml sendmsg = (SendFriendXml)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendFriendXml));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, otherQQ, xmlcode, ref Random, ref Req));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送群xml消息
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="xmlcode">xml代码</param>
        /// <param name="anonymous">匿名发送</param>
        /// <returns></returns>
        public string SendGroupXmlEvent(long thisQQ, long GroupQQ, string xmlcode, bool anonymous = false)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送群xml消息").ToString());
            SendGroupXml sendmsg = (SendGroupXml)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendGroupXml));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ, xmlcode, anonymous));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取群成员概况
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <returns>成功返回json,含有群上限、群人数、群成员统计概况</returns>
        public string GetGroupMemberOverview(long thisQQ, long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取群成员概况").ToString());
            GroupMemberOverview sendmsg = (GroupMemberOverview)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupMemberOverview));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 添加好友_取验证类型
        /// </summary>
        /// <param name="uin"></param>
        /// <returns></returns>
        public string GetAuthenticationType(long thisQQ, long uin)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("添加好友_取验证类型").ToString());
            GetadministratorList sendmsg = (GetadministratorList)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetadministratorList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, uin));
            sendmsg = null;
            return ret;
        }

        /// <summary>
        /// 群聊打卡
        /// </summary>
        /// <param name="GroupQQ"></param>
        /// <returns>返回json</returns>
        public string GroupTurnOn(long thisQQ, long GroupQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊打卡").ToString());
            GetadministratorList sendmsg = (GetadministratorList)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetadministratorList));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, GroupQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 群聊签到<para>暂不支持自定义内容</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="desc">签到数据<para>如:template_data=&gallery_info=%7B%22category_id%22%3A9%2C%22page%22%3A0%2C%22pic_id%22%3A124%7D&template_id=%7B%7D&client=2&lgt=0&lat=0&poi=&pic_id=&text=%E5%AD%A6%E4%B9%A0%E6%89%93%E5%8D%A1</para></param>
        /// <returns>成功返回真,失败返回假</returns>
        public bool GroupSigninEvent(long thisQQ, long GroupQQ, string desc = null)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("群聊签到").ToString());
            GroupSignin sendmsg = (GroupSignin)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupSignin));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, desc);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置群聊备注
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="Remarks">备注</param>
        /// <returns>成功返回真,失败返回假,无权限返回假</returns>
        public bool GroupRemarks(long thisQQ, long GroupQQ, string Remarks)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置群聊备注").ToString());
            GroupSignin sendmsg = (GroupSignin)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GroupSignin));
            bool ret = sendmsg(pluginkey, thisQQ, GroupQQ, Remarks);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 红包转发
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="redEnvelopeID"></param>
        /// <param name="QQ">QQ号或群号：以Type类型为准,如果是1则判断为QQ号否则判断为群号</param>
        /// <param name="type">类型：1为好友,2为群</param>
        /// <returns></returns>
        public string ForwardRedEnvelopeEvent(long thisQQ, string redEnvelopeID, long QQ, RedE2TypeEnum type)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("红包转发").ToString());
            ForwardRedEnvelope sendmsg = (ForwardRedEnvelope)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(ForwardRedEnvelope));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, redEnvelopeID, QQ, (int)type));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="packID">包体序号<para>ssoseq,通过【请求ssoseq】API获取</para></param>
        /// <param name="maxwaittime">最大等待时长<para>毫秒,不填或小于0时不等待返回包,大于0时等待返回包</para></param>
        /// <param name="bytes">数据: 返回数据参考传回,拉取返回包失败参考回空字节集</param>
        /// <returns></returns>
        public bool SendDataPackEvent(long thisQQ, int packID,int maxwaittime,ref byte[] bytes)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("发送数据包").ToString());
            SendDataPack sendmsg = (SendDataPack)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SendDataPack));
            IntPtr intPtr = IntPtr.Zero;
            bool ret = sendmsg(pluginkey, thisQQ, packID, maxwaittime, ref intPtr);
            Marshal.Copy(intPtr, bytes, 0, bytes.Length);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 请求ssoseq
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns>无权限等返回0</returns>
        public int GetssoseqEvent(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("请求ssoseq").ToString());
            Getssoseq sendmsg = (Getssoseq)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Getssoseq));
            int ret = sendmsg(pluginkey, thisQQ);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 取sessionkey<para>敏感权限</para>
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns>成功返回16进制秘钥,敏感权限</returns>
        public string Getsessionkey(long thisQQ)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("取sessionkey").ToString());
            GetClientKey sendmsg = (GetClientKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetClientKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 获取bkn_gtk
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="bkn_gtk">自定义bkn_gtk<para>如果此参数不为空值则提交自定义值,否则框架返回内部值</para></param>
        /// <returns>返回网页用到的bkn或者gtk,也可以自定义计算的值</returns>
        public string GetBkn_Gtk(long thisQQ, string bkn_gtk)
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("获取bkn_gtk").ToString());
            GetPSKey sendmsg = (GetPSKey)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetPSKey));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, bkn_gtk));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 置好友验证方式
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="type">验证类型<para>1：禁止任何人添加 2：允许任何人添加 3：需要验证信息 4：需要正确回答问题 5：需要回答问题并由我确认</para></param>
        /// <param name="Q_and_A">验证问题和答案<para>可空,如果类型为4则填写问题和答案用‘|’分割,如果类型为5则根据情况填写问题至少一个最多三个问题,用‘|’分割</para></param>
        /// <returns></returns>
        public bool SetFriendAuthenticationMode(long thisQQ, FriendAuthenticationModeEnum type, string Q_and_A="")
        {
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("置好友验证方式").ToString());
            SetFriendAuthenticationM sendmsg = (SetFriendAuthenticationM)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(SetFriendAuthenticationM));
            bool ret = sendmsg(pluginkey, thisQQ, type, Q_and_A);
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 上传照片墙图片
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="picpath">图片路径</param>
        /// <returns>上传一照片至照片墙,成功返回带有‘上传成功’字样的json,失败或无权限返回json</returns>
        public string UploadPhotoWall(long thisQQ, string picpath)
        {
            Bitmap bitmap = new Bitmap(picpath);
            byte[] picture = GetByteArrayByImage(bitmap);
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("上传照片墙图片").ToString());
            UploadAvatar sendmsg = (UploadAvatar)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(UploadAvatar));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, picture, picture.Length));
            sendmsg = null;
            return ret;
        }
        /// <summary>
        /// 付款
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <param name="QrcodeUrl">QQ钱包支付二维码内容(需要自己识别二维码,将识别结果填入)</param>
        /// <param name="bankCard">银行卡序列<para>大于0时使用银行卡支付</para></param>
        /// <param name="PaymentPWD">支付密码</param>
        /// <param name="captchaInfo">验证码信息<para>银行卡支付时，若需要短信验证码，将在此传回验证码信息</para></param>
        /// <returns>银行卡支付时，若需要短信验证码，将在此传回验证码信息</returns>
        public string PaymentEvent(long thisQQ, string QrcodeUrl, int bankCard, string PaymentPWD,  ref CaptchaInformation captchaInfo)
        {
            GetCaptchaInfoDataList[] ciDataLists = new GetCaptchaInfoDataList[2];
            int MsgAddress = int.Parse(JObject.Parse(jsonstr).SelectToken("付款").ToString());
            Payment sendmsg = (Payment)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(Payment));
            string ret = Marshal.PtrToStringAnsi(sendmsg(pluginkey, thisQQ, QrcodeUrl, bankCard, PaymentPWD, ref ciDataLists));
            captchaInfo = ciDataLists[0].CaptchaInfo;
            sendmsg = null;
            return ret;
        }
    }
}
