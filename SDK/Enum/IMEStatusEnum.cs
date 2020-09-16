using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum IMEStatusEnum
    {
        // 1:正在输入,2:关闭显示,3:正在说话
        /// <summary>
        /// 正在输入
        /// </summary>
        Input = 1,
        /// <summary>
        /// 关闭显示
        /// </summary>
        CloseShow = 2,
        /// <summary>
        /// 正在说话
        /// </summary>
        Talking = 3
    }
}
