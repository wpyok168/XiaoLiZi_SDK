using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TextCodeParameterList
    {
        /// <summary>
        /// 参数名<para>参数名,全部到【小写】处理了,(因此不管参数名实际是大写还是小写,这里结果都是小写)</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        /// <summary>
        /// 是否包含该参数名
        /// </summary>
        public bool isNull;
        /// <summary>
        /// 参数值
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string value;
    }
}
