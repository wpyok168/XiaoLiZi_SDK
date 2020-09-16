using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum MusicAppTypeEnum
    {
        //0QQ音乐 1虾米音乐 2酷我音乐 3酷狗音乐 4网易云音乐  默认0
        /// <summary>
        /// QQ音乐
        /// </summary>
        QQMusic = 0,
        /// <summary>
        /// 虾米音乐
        /// </summary>
        XiaMiMusic = 1,
        /// <summary>
        /// 酷我音乐
        /// </summary>
        KuWoMusic = 2,
        /// <summary>
        /// 酷狗音乐
        /// </summary>
        KuGouMusic = 3,
        /// <summary>
        /// 网易云音乐
        /// </summary>
        WangYiMusic = 4
    }
    public enum MusicShare_Type
    {
        //0私聊 1群聊  默认0
        /// <summary>
        /// 私聊
        /// </summary>
        PrivateMsg = 0,
        /// <summary>
        /// 群聊
        /// </summary>
        GroupMsg = 1
    }
}
