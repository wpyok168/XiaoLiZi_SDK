using SDK.Enum;
using SDK.Events;
using SDK.Interface;
using System;
using System.Runtime.InteropServices;
using Unity;

namespace SDK.Core
{
    public class XLZMain
    {

        public delegate int RecvicePrivateMsg(IntPtr intPtr);
        public delegate int RecviceGroupMesg(IntPtr intPtr);
        public delegate int RotbotAppEnable();
        public delegate int RecviceEventCallBack(IntPtr intPtr);
        public delegate int AppSetting();
        public delegate void AppUninstall();
        public delegate void AppDisabled();
        public static RecvicePrivateMsg staticRecvicePrivateMsg = new RecvicePrivateMsg(RecvicetPrivateMessage);
        public static RecviceGroupMesg staticRecviceGroupMesg = new RecviceGroupMesg(RecvicetGroupMessage);
        public static RotbotAppEnable staticRotbotAppEnable = new RotbotAppEnable(AppEnable);
        public static RecviceEventCallBack staticRecviceEventCallBack = new RecviceEventCallBack(RecviceEventcallBack);
        public static AppSetting staticAppSetting = new AppSetting(AppSettingEvent);
        public static AppUninstall staticAppUninstall = new AppUninstall(AppUninstallEvent);
        public static AppDisabled staticAppDisabled = new AppDisabled(AppDisabledEvent);

        public static int RecvicetGroupMessage(IntPtr intPtr)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IGroupMessage>())
                {
                    GroupMessageEvent data = new GroupMessageEvent();
                    data = (GroupMessageEvent)Marshal.PtrToStructure(intPtr, typeof(GroupMessageEvent));
                    //string txt = Marshal.PtrToStringAnsi(data.MessageContent);
                    Common.unityContainer.Resolve<IGroupMessage>().ReceviceGroupMsg(data);
                    return (int)EventMessageEnum.Ignore;
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("群聊：" + ex.ToString());
            }
            return (int)EventMessageEnum.Ignore;
        }

        public static int RecvicetPrivateMessage(IntPtr intPtr)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IRecvicetPrivateMessage>())
                {
                    PrivateMessageEvent data = new PrivateMessageEvent();
                    data = (PrivateMessageEvent)Marshal.PtrToStructure(intPtr, typeof(PrivateMessageEvent));
                    //string content = Marshal.PtrToStringAnsi(data.MessageContent);
                    Common.unityContainer.Resolve<IRecvicetPrivateMessage>().RecvicetPrivateMsg(data);
                    return (int)EventMessageEnum.Ignore;
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("私聊：" + ex.ToString());
            }
            return (int)EventMessageEnum.Ignore;
        }

        public static int AppEnable()
        {
            try
            {
                //AppEnableEvent appEnableEvent =(AppEnableEvent) Marshal.PtrToStructure(intPtr,typeof(AppEnableEvent));
                if (Common.unityContainer.IsRegistered<IAppEnableEvent>())
                {
                    AppEnableEvent ae = new AppEnableEvent();
                    Common.unityContainer.Resolve<IAppEnableEvent>().AppEnableEvent(ae);
                    return (int)EventProcessEnum.Ignore;
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("启动：" + ex.ToString());
            }
            return (int)EventProcessEnum.Ignore;
        }

        public static int RecviceEventcallBack(IntPtr intPtr)
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IEventcallBack>())
                {
                    EventTypeBase data = new EventTypeBase();
                    data = (EventTypeBase)Marshal.PtrToStructure(intPtr, typeof(EventTypeBase));
                    //string eventname = Marshal.PtrToStringAnsi(data.MessageContent);
                    //Enum.EventTypeEnum eventType = data.EventType;
                    //string a = eventType.ToString();
                    Common.unityContainer.Resolve<IEventcallBack>().EventcallBack(data);
                    return (int)EventMessageEnum.Ignore;
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("事件：" + ex.ToString());
            }
            return (int)EventMessageEnum.Ignore;
        }

        public static int AppSettingEvent()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IAppSetting>())
                {
                    Common.unityContainer.Resolve<IAppSetting>().AppSetting();
                    return (int)EventMessageEnum.Ignore;
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("窗体：" + ex.ToString());
            }
            return (int)EventMessageEnum.Ignore;
        }
        public static void AppUninstallEvent()
        {
            try
            {
                //DisablePlugin.DisablePluginMethod();//卸载前先禁用插件，避免报内存未释放
                
                if (Common.unityContainer.IsRegistered<IAppUninstall>())
                {
                    Common.unityContainer.Resolve<IAppUninstall>().AppUninstall();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("卸载：" + ex.ToString());
            }

        }
        public static void AppDisabledEvent()
        {
            try
            {
                if (Common.unityContainer.IsRegistered<IDisabledEvent>())
                {
                    Common.unityContainer.Resolve<IDisabledEvent>().DisabledEvent();
                }
            }
            catch (Exception ex)
            {
                Common.BugLog("禁用：" + ex.ToString());
            }

        }
    }
}
