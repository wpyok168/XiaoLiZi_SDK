using SDK.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using SDK.Interface;
using SDK.Enum;

namespace SDK.Core
{
    public class XLZMain
    {

        public delegate int RecvicePrivateMsg(IntPtr intPtr);
        public delegate int RecviceGroupMesg(IntPtr intPtr);
        public delegate EventProcessEnum RotbotAppEnable();
        public delegate void RecviceEventCallBack(IntPtr intPtr);
        public delegate void AppSetting();
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
            if (Common.unityContainer.IsRegistered<IGroupMessage>())
            {
                GroupMessageEvent data = new GroupMessageEvent();
                data = (GroupMessageEvent)Marshal.PtrToStructure(intPtr, typeof(GroupMessageEvent));
                //string txt = Marshal.PtrToStringAnsi(data.MessageContent);
                Common.unityContainer.Resolve<IGroupMessage>().ReceviceGroupMsg(data);
            }
            return 1;
        }

        public static int RecvicetPrivateMessage(IntPtr intPtr)
        { 
            if (Common.unityContainer.IsRegistered<IRecvicetPrivateMessage>())
            {
                PrivateMessageEvent data = new PrivateMessageEvent();
                data = (PrivateMessageEvent)Marshal.PtrToStructure(intPtr, typeof(PrivateMessageEvent));
                //string content = Marshal.PtrToStringAnsi(data.MessageContent);
                Common.unityContainer.Resolve<IRecvicetPrivateMessage>().RecvicetPrivateMsg(data);
            }
            return 1;
        }

        public static EventProcessEnum AppEnable()
        {
            //AppEnableEvent appEnableEvent =(AppEnableEvent) Marshal.PtrToStructure(intPtr,typeof(AppEnableEvent));
            if (Common.unityContainer.IsRegistered<IAppEnableEvent>())
            {
                AppEnableEvent ae = new AppEnableEvent();
                Common.unityContainer.Resolve<IAppEnableEvent>().AppEnableEvent(ae);
                return EventProcessEnum.Ignore;
            }
            return EventProcessEnum.Block;
        }

        public static void RecviceEventcallBack(IntPtr intPtr)
        {
            if (Common.unityContainer.IsRegistered<IEventcallBack>())
            {
                EventTypeBase data = new EventTypeBase();
                data = (EventTypeBase)Marshal.PtrToStructure(intPtr, typeof(EventTypeBase));
                //string eventname = Marshal.PtrToStringAnsi(data.MessageContent);
                //Enum.EventTypeEnum eventType = data.EventType;
                //string a = eventType.ToString();
                Common.unityContainer.Resolve<IEventcallBack>().EventcallBack(data);
            }
        }

        public static void AppSettingEvent()
        {
            if (Common.unityContainer.IsRegistered<IAppSetting>())
            {
                Common.unityContainer.Resolve<IAppSetting>().AppSetting();
            }
        }
        public static void AppUninstallEvent()
        {
            if (Common.unityContainer.IsRegistered<IAppUninstall>())
            {
                Common.unityContainer.Resolve<IAppUninstall>().AppUninstall();
            }
        }
        public static void AppDisabledEvent()
        {
            if (Common.unityContainer.IsRegistered<IDisabledEvent>())
            {
                Common.unityContainer.Resolve<IDisabledEvent>().DisabledEvent();
            }
        }
    }
}
