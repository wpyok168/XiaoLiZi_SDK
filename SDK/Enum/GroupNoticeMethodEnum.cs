using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum GroupNoticeMethodEnum
    {
        //0不接收此人消息,1特别关注,2默认(接受此人消息) 如果参数为空则默认方式为2
        /// <summary>
        /// 不接收此人消息
        /// </summary>
        no = 0,
        /// <summary>
        /// 特别关注
        /// </summary>
        SpecialAttention = 1,
        /// <summary>
        /// 默认
        /// </summary>
        Default = 2,

    }
}
