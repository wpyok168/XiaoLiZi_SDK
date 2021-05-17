using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupApps
    {
        /// <summary>
        /// 应用Id<para>当唤醒链接是qq.com时,需要根据应用Id来唤醒应用</para>
        /// </summary>
        public long id;
        /// <summary>
        /// 应用名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string appName;
        /// <summary>
        /// 唤醒链接<para>mqqapi,部分是qq.com,如:一起看、一起听歌,内含变量,如:$GCODE$代表群号,自行替换</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string appUrl;
        /// <summary>
        /// 应用图标
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string appICON;
    }
}
