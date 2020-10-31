using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    /// <summary>
    /// 转账类型
    /// </summary>
    public enum TransferTypeEnum
    {
        //0好友转账,1陌生人转账,默认0
        /// <summary>
        /// 好友转账
        /// </summary>
        Firend = 0,
        /// <summary>
        /// 陌生人转账
        /// </summary>
        Stranger = 1
    }
}
