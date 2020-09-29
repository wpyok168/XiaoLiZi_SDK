using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 消息类型
    public enum MessageTypeEnum
    {
        // 临时会话
        /// <summary>
        /// 临时会话
        /// </summary>
        Temporary = 141,
        // 好友通常消息
        /// <summary>
        /// 好友通常消息
        /// </summary>
        FriendUsualMessage = 166,

        // 好友文件
        /// <summary>
        /// 好友文件
        /// </summary>
        FriendFile = 529,
        // 好友语音
        /// <summary>
        /// 好友语音
        /// </summary>
        FriendAudio = 208,
        // 群红包
        /// <summary>
        ///  群红包
        /// </summary>
        GroupRedEnvelope = 78,
        // 群聊通常消息
        /// <summary>
        /// 群聊通常消息
        /// </summary>
        GroupUsualMessage = 134
    }
}
