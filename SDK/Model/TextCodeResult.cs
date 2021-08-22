using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TextCodeResult
    {
        /// <summary>
        /// 结果类型:0:普通文本,1:文本代码
        /// </summary>
        public int resultType;
        /// <summary>
        /// 命令<para>文本代码类型,全部到【小写】处理了(因此不管文本代码命令实际是大写还是小写,这里结果都是小写),比如图片类型命令是:pic,厘米秀类型命令是:limishow</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string command;
        /// <summary>
        /// 文本代码数据<para>普通文本原内容 或 文本代码参数数据</para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string textcodedata;

    }
}
