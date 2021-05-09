using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 消息子类型
    /// <summary>
    /// 消息子类型
    /// </summary>
    public enum MessageSubTypeEnum
    {
        // 临时会话_群
        /// <summary>
        /// 临时会话_群临时
        /// </summary>
        Temporary_Group = 0,
        // 临时会话_公众号
        /// <summary>
        /// 临时会话_公众号
        /// </summary>
        Temporary_PublicAccount = 129,
        // 临时会话_网页QQ咨询
        /// <summary>
        /// 临时会话_网页QQ咨询
        /// </summary>
        Temporary_WebQQConsultation = 201,
        /// <summary>
        /// 临时会话
        /// </summary>
        Temporary_onversation = 141,
        /// <summary>
        /// 临时会话_讨论组临时
        /// </summary>
        temporary_conversation_group = 1,
        /// <summary>
        /// 好友通常消息
        /// </summary>
        friend_usualMsg = 166,
        /// <summary>
        /// 讨论组消息
        /// </summary>
        discussion_group_message = 83,
    }
}
