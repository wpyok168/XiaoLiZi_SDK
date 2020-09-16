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
        Temporary = 141,
        // 好友通常消息
        FriendUsualMessage = 166,
        // 好友文件
        FriendFile = 529,
        // 好友语音
        FriendAudio = 208,
        // 群红包
        GroupRedEnvelope = 78,
        // 群聊通常消息
        GroupUsualMessage = 134
    }
}
