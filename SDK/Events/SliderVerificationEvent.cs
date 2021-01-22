using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Events
{
    /// <summary>
    /// 滑块识别
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SliderVerificationEvent
    {
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long sourceQQ;
        /// <summary>
        /// url
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string url;
    }
    /// <summary>
    /// 取短信验证码
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SMSVerificationEvent
    {
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long sourceQQ;
        /// <summary>
        /// 手机号
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string phone;
    }
}
