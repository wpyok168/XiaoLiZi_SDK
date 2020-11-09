using SDK;
using SDK.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Unity;
using XiaoLiZi;
using static SDK.Core.XLZMain;

namespace RobotCore
{
    public static class AppRun
    {
        
        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static string apprun([MarshalAs(UnmanagedType.LPStr)] string pluginkey, [MarshalAs(UnmanagedType.LPStr)] string apidata)
        {
            Common.unityContainer = new UnityContainer();
            RegisterCore.Register(Common.unityContainer);
            API.jsonstr = pluginkey;
            API.pluginkey = apidata;
            if (PermissionConstant.PermiCon.Count == 0)
            {
                PermissionConstant.Init();//权限常量初始化
            }
            AppInfo appInfo = new AppInfo();
            SetAppInfo(appInfo);
            try
            {
                appInfo.useproaddres = Marshal.GetFunctionPointerForDelegate(staticRotbotAppEnable).ToInt64();//插件启用
                appInfo.friendmsaddres = Marshal.GetFunctionPointerForDelegate(staticRecvicePrivateMsg).ToInt64();//接收好友信息
                appInfo.groupmsaddres = Marshal.GetFunctionPointerForDelegate(staticRecviceGroupMesg).ToInt64();//接收群消息
                appInfo.eventmsaddres = Marshal.GetFunctionPointerForDelegate(staticRecviceEventCallBack).ToInt64();//事件处理
                appInfo.setproaddres = Marshal.GetFunctionPointerForDelegate(staticAppSetting).ToInt64();//点击插件设置
                appInfo.unitproaddres = Marshal.GetFunctionPointerForDelegate(staticAppUninstall).ToInt64();//插件卸载
                appInfo.banproaddres = Marshal.GetFunctionPointerForDelegate(staticAppDisabled).ToInt64();//插件禁用 
            }
            catch (Exception)
            {
                
            }
            string json = appInfo.Info(appInfo);
            json = SetProperty(json, appInfo);
            return json;
        }

        private static void SetAppInfo(AppInfo appInfo)
        {
            appInfo.sdkv = "2.8.5.6";
            appInfo.appname = "小栗子 C# SDK 空壳";
            appInfo.author = "福建-兮";
            appInfo.describe = string.Concat(new string[]
            {
                "这是一个获取确认ID插件",
                "\r\n",
                "小栗子官网地址：http://www.xiaolz.cn/"
            });
            appInfo.appv = "1.0.0";
        }
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="json"></param>
        /// <param name="appInfo"></param>
        /// <returns></returns>
        private static string SetProperty(string json, AppInfo appInfo)
        {
            json = appInfo.SetPermission(0, "输出日志", json);
            json = appInfo.SetPermission(1, "发送好友消息", json);
            json = appInfo.SetPermission(2, "发送群消息", json);
            json = appInfo.SetPermission(3, "发送群临时消息", json);
            json = appInfo.SetPermission(4, "添加好友", json);
            json = appInfo.SetPermission(5, "添加群", json);
            json = appInfo.SetPermission(6, "删除好友", json);
            json = appInfo.SetPermission(7, "置屏蔽好友", json);
            json = appInfo.SetPermission(8, "置特别关心好友", json);
            json = appInfo.SetPermission(9, "发送好友xml消息", json);
            json = appInfo.SetPermission(10, "发送群xml消息", json);
            json = appInfo.SetPermission(11, "发送好友json消息", json);
            json = appInfo.SetPermission(12, "发送群json消息", json);
            json = appInfo.SetPermission(13, "上传好友图片", json);
            json = appInfo.SetPermission(14, "上传群图片", json);
            json = appInfo.SetPermission(15, "上传好友语音", json);
            json = appInfo.SetPermission(16, "上传群语音", json);
            json = appInfo.SetPermission(17, "上传头像", json);
            json = appInfo.SetPermission(18, "设置群名片", json);
            json = appInfo.SetPermission(19, "取昵称_从缓存", json);
            json = appInfo.SetPermission(20, "强制取昵称", json);
            json = appInfo.SetPermission(21, "获取skey", json);
            json = appInfo.SetPermission(22, "获取pskey", json);
            json = appInfo.SetPermission(23, "获取clientkey", json);
            json = appInfo.SetPermission(24, "取框架QQ", json);
            json = appInfo.SetPermission(25, "取好友列表", json);
            json = appInfo.SetPermission(26, "取群列表", json);
            json = appInfo.SetPermission(27, "取群成员列表", json);
            json = appInfo.SetPermission(28, "设置管理员", json);
            json = appInfo.SetPermission(29, "取管理层列表", json);
            json = appInfo.SetPermission(30, "取群名片", json);
            json = appInfo.SetPermission(31, "取个性签名", json);
            json = appInfo.SetPermission(32, "修改昵称", json);
            json = appInfo.SetPermission(33, "修改个性签名", json);
            json = appInfo.SetPermission(34, "删除群成员", json);
            json = appInfo.SetPermission(35, "禁言群成员", json);
            json = appInfo.SetPermission(36, "退群", json);
            json = appInfo.SetPermission(37, "解散群", json);
            json = appInfo.SetPermission(38, "上传群头像", json);
            json = appInfo.SetPermission(39, "全员禁言", json);
            json = appInfo.SetPermission(40, "群权限_发起新的群聊", json);
            json = appInfo.SetPermission(41, "群权限_发起临时会话", json);
            json = appInfo.SetPermission(42, "群权限_上传文件", json);
            json = appInfo.SetPermission(43, "群权限_上传相册", json);
            json = appInfo.SetPermission(44, "群权限_邀请好友加群", json);
            json = appInfo.SetPermission(45, "群权限_匿名聊天", json);
            json = appInfo.SetPermission(46, "群权限_坦白说", json);
            json = appInfo.SetPermission(47, "群权限_新成员查看历史消息", json);
            json = appInfo.SetPermission(48, "群权限_邀请方式设置", json);
            json = appInfo.SetPermission(49, "撤回消息_群聊", json);
            json = appInfo.SetPermission(50, "撤回消息_私聊本身", json);
            json = appInfo.SetPermission(51, "设置位置共享", json);
            json = appInfo.SetPermission(52, "上报当前位置", json);
            json = appInfo.SetPermission(53, "是否被禁言", json);
            json = appInfo.SetPermission(54, "处理好友验证事件", json);
            json = appInfo.SetPermission(55, "处理群验证事件", json);
            json = appInfo.SetPermission(56, "查看转发聊天记录内容", json);
            json = appInfo.SetPermission(57, "上传群文件", json);
            json = appInfo.SetPermission(58, "创建群文件夹", json);
            json = appInfo.SetPermission(59, "设置在线状态", json);
            json = appInfo.SetPermission(60, "QQ点赞", json);
            json = appInfo.SetPermission(61, "取图片下载地址", json);
            json = appInfo.SetPermission(63, "查询好友信息", json);
            json = appInfo.SetPermission(64, "查询群信息", json);
            json = appInfo.SetPermission(65, "框架重启", json);
            json = appInfo.SetPermission(66, "群文件转发至群", json);
            json = appInfo.SetPermission(67, "群文件转发至好友", json);
            json = appInfo.SetPermission(68, "好友文件转发至好友", json);
            json = appInfo.SetPermission(69, "置群消息接收", json);
            json = appInfo.SetPermission(70, "取群名称_从缓存", json);
            json = appInfo.SetPermission(71, "发送免费礼物", json);
            json = appInfo.SetPermission(72, "取好友在线状态", json);
            json = appInfo.SetPermission(73, "取QQ钱包个人信息", json);
            json = appInfo.SetPermission(74, "获取订单详情", json);
            json = appInfo.SetPermission(75, "提交支付验证码", json);
            json = appInfo.SetPermission(77, "分享音乐", json);
            json = appInfo.SetPermission(78, "更改群聊消息内容", json);
            json = appInfo.SetPermission(79, "更改私聊消息内容", json);
            json = appInfo.SetPermission(80, "群聊口令红包", json);
            json = appInfo.SetPermission(81, "群聊拼手气红包", json);
            json = appInfo.SetPermission(82, "群聊普通红包", json);
            json = appInfo.SetPermission(83, "群聊画图红包", json);
            json = appInfo.SetPermission(84, "群聊语音红包", json);
            json = appInfo.SetPermission(85, "群聊接龙红包", json);
            json = appInfo.SetPermission(86, "群聊专属红包", json);
            json = appInfo.SetPermission(87, "好友口令红包", json);
            json = appInfo.SetPermission(88, "好友普通红包", json);
            json = appInfo.SetPermission(89, "好友画图红包", json);
            json = appInfo.SetPermission(90, "好友语音红包", json);
            json = appInfo.SetPermission(91, "好友接龙红包", json);
            json = appInfo.SetPermission(92, "重命名群文件夹", json);
            json = appInfo.SetPermission(93, "删除群文件夹", json);
            json = appInfo.SetPermission(94, "删除群文件", json);
            json = appInfo.SetPermission(95, "保存文件到微云", json);
            json = appInfo.SetPermission(96, "移动群文件", json);
            json = appInfo.SetPermission(97, "取群文件列表", json);
            json = appInfo.SetPermission(98, "设置专属头衔", json);
            json = appInfo.SetPermission(99, "下线指定QQ", json);
            json = appInfo.SetPermission(100, "登录指定QQ", json);
            json = appInfo.SetPermission(101, "取群未领红包", json);
            json = appInfo.SetPermission(102, "发送输入状态", json);
            json = appInfo.SetPermission(103, "修改资料", json);
            json = appInfo.SetPermission(104, "打好友电话", json);
            json = appInfo.SetPermission(105, "取群文件下载地址", json);
            json = appInfo.SetPermission(106, "头像双击_好友", json);
            json = appInfo.SetPermission(107, "头像双击_群", json);
            json = appInfo.SetPermission(108, "取群成员简略信息", json);
            json = appInfo.SetPermission(109, "群聊置顶", json);
            json = appInfo.SetPermission(110, "私聊置顶", json);
            json = appInfo.SetPermission(111, "取加群链接", json);
            json = appInfo.SetPermission(112, "设为精华", json);
            json = appInfo.SetPermission(113, "群权限_设置群昵称规则", json);
            json = appInfo.SetPermission(114, "群权限_设置群发言频率", json);
            json = appInfo.SetPermission(115, "群权限_设置群查找方式", json);
            json = appInfo.SetPermission(116, "邀请好友加群", json);
            json = appInfo.SetPermission(117, "置群内消息通知", json);
            json = appInfo.SetPermission(118, "修改群名称", json);
            json = appInfo.SetPermission(119, "下线PCQQ", json);
            json = appInfo.SetPermission(120, "登录网页取ck", json);
            json = appInfo.SetPermission(121, "发送群公告", json);
            json = appInfo.SetPermission(122, "取群成员信息", json);
            json = appInfo.SetPermission(123, "发送邮件", json);
            json = appInfo.SetPermission(124, "取钱包cookie", json);
            json = appInfo.SetPermission(125, "取群网页cookie", json);
            json = appInfo.SetPermission(126, "取手Q邮箱cookie", json);
            json = appInfo.SetPermission(127, "转账", json);
            json = appInfo.SetPermission(128, "余额提现", json);
            json = appInfo.SetPermission(129, "取收款链接", json);
            json = appInfo.SetPermission(130, "取群小视频下载地址", json);
            json = appInfo.SetPermission(131, "取私聊小视频下载地址", json);
            json = appInfo.SetPermission(132, "上传小视频", json);
            json = appInfo.SetPermission(133, "取群成员概况", json);
            return json;
        }
    }
}
