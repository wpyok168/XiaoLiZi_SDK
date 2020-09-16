using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum ServiceInformation
    {
        //1svip 105star 102yellow 103 green 101red 4film 104 yellowlove 6musicpackage 107 svip&film  109svip&green 110svip&kMusic
        SVIP = 1, //SVIP
        VIDEO_VIP = 4, //视频会员
        MUSIC_PACK = 6, //音乐包
        STAR = 105, //star
        YELLOW_DIAMOND = 102, //黄钻
        GREEN_DIAMOND = 103, //绿钻
        RED_DIAMOND = 101, //红钻
        YELLOWLOVE = 104, //yellowlove
        SVIP_WITH_VIDEO = 107, //SVIP&视频会员
        SVIP_WITH_GREEN = 109, //SVIP&绿钻
        SVIP_WITH_MUSIC = 110 //SVIP&音乐包
    }
}
