using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    /// <summary>
    /// 好友验证方式
    /// </summary>
    public enum FriendAuthenticationModeEnum
    {
        //1：禁止任何人添加 2：允许任何人添加 3：需要验证信息 4：需要正确回答问题 5：需要回答问题并由我确认
        /// <summary>
        /// 禁止任何人添加
        /// </summary>
        disable = 1,
        /// <summary>
        /// 允许任何人添加
        /// </summary>
        allow = 2,
        /// <summary>
        /// 需要验证信息
        /// </summary>
        verification = 3,
        /// <summary>
        /// 需要正确回答问题
        /// </summary>
        ATQC = 4,
        /// <summary>
        /// 需要回答问题并由我确认
        /// </summary>
        ATQACPM = 5
    }
}
