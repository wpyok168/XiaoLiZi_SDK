using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 语音类型
    public enum AudioTypeEnum
    {
        // 普通语音
        /// <summary>
        /// 普通语音
        /// </summary>
        Normal = 0,
        // 变声语音
        /// <summary>
        /// 变声语音
        /// </summary>
        Change = 1,
        // 文字语音
        /// <summary>
        /// 文字语音
        /// </summary>
        Text = 2,
        // (红包)匹配语音
        /// <summary>
        /// (红包)匹配语音
        /// </summary>
        Match = 3,
    }
}
