using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 消息子类型
    public enum MessageSubTypeEnum
    {
        // 临时会话_群
        Temporary_Group = 0,
        // 临时会话_公众号
        Temporary_PublicAccount = 129,
        // 临时会话_网页QQ咨询
        Temporary_WebQQConsultation = 201,
    }
}
