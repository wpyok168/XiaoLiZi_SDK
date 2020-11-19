using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Core
{
    public class DisablePlugin
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 禁用插件
        /// </summary>
        public static void DisablePluginMethod()
        {
            IntPtr intPtr = MyFindWindow("禁用");
            SendMessage(intPtr, 0x201, IntPtr.Zero, IntPtr.Zero);
            SendMessage(intPtr, 0x202, IntPtr.Zero, IntPtr.Zero);
        }
        /// <summary>
        /// 卸载插件
        /// </summary>
        public static void UnInstallPluginMethod()
        {
            IntPtr intPtr = MyFindWindow("卸载");
            SendMessage(intPtr, 0x201, IntPtr.Zero, IntPtr.Zero);
            SendMessage(intPtr, 0x202, IntPtr.Zero, IntPtr.Zero);
        }
        private static IntPtr MyFindWindow(string buttonName)
        {
            const int MyMaxParentWinCount = 3;
            // 父窗口类名数组
            string[] szClassName = new string[MyMaxParentWinCount] { "WTWindow", "_EL_Tab", "Button" };
            // 父窗口标题数组
            string[] szWinName = new string[MyMaxParentWinCount] { "小栗子框架", "", buttonName };
            // 首先求得顶级父窗口
            IntPtr hLastWin = FindWindow(szClassName[0], szWinName[0]);
            // 逐次用FindWindowEx函数求出各级子窗口
            for (int i = 1; i < MyMaxParentWinCount; i++)
            {
                hLastWin = FindWindowEx(hLastWin, IntPtr.Zero,
                    szClassName[i], szWinName[i]);
            }
            return hLastWin;
        }
    }
}
