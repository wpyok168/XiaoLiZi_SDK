using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum GroupFindMethodEnum
    {
        //0不允许,1通过群号或关键词,2仅可通过群号,默认0
        /// <summary>
        /// 不允许
        /// </summary>
        NotAllowed = 0,
        /// <summary>
        /// 通过群号或关键词
        /// </summary>
        GroupName = 1,
        /// <summary>
        /// 仅可通过群号
        /// </summary>
        GroupQQ = 2
    }
}
