using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    // 详细在线状态
    public enum StatusOnlineTypeEnum
    {
        //当main=11时，可进一步设置 0普通在线 1000我的电量 1011信号弱 1024在线学习 1025在家旅游 1027TiMi中 1016睡觉中 1017游戏中 1018学习中 1019吃饭中 
        //1021煲剧中 1053汪汪汪 1032熬夜中 1050打球中 1051恋爱中 1052我没事 1028我在听歌 40001在地球 41042移动中
        // 普通在线
        /// <summary>
        /// 普通在线
        /// </summary>
        Normal = 0,
        // 我的电量
        /// <summary>
        /// 我的电量
        /// </summary>
        Battery = 1000,
        // 信号弱
        /// <summary>
        /// 信号弱
        /// </summary>
        WeakSignal = 1011,
        // 睡觉中
        /// <summary>
        /// 睡觉中
        /// </summary>
        Sleeping = 1016,
        // 游戏中
        /// <summary>
        /// 游戏中
        /// </summary>
        Gaming = 1017,
        // 学习中
        /// <summary>
        /// 学习中
        /// </summary>
        Studying = 1018,
        // 吃饭中
        /// <summary>
        /// 吃饭中
        /// </summary>
        Eating = 1019,
        // 煲剧中
        /// <summary>
        /// 煲剧中
        /// </summary>
        WatchingTVSeries = 1021,
        // 度假中
        /// <summary>
        /// 度假中
        /// </summary>
        OnVacation = 1022,
        // 在线学习
        /// <summary>
        ///  在线学习
        /// </summary>
        OnlineStudying = 1024,
        // 在家旅游
        /// <summary>
        /// 在家旅游
        /// </summary>
        TravelAtHome = 1025,
        // TiMi中
        /// <summary>
        /// TiMi中
        /// </summary>
        TiMiing = 1027,
        // 我在听歌
        /// <summary>
        /// 我在听歌
        /// </summary>
        ListeningToMusic = 1028,
        // 熬夜中
        /// <summary>
        /// 熬夜中
        /// </summary>
        StayingUpLate = 1032,
        // 打球中
        /// <summary>
        /// 打球中
        /// </summary>
        PlayingBall = 1050,
        // 恋爱中
        /// <summary>
        /// 恋爱中
        /// </summary>
        FallInLove = 1051,
        // 我没事(实际上有事)
        /// <summary>
        /// 我没事(实际上有事)
        /// </summary>
        ImOK = 1052,
        /// <summary>
        /// 汪汪汪
        /// </summary>
        Barking = 1053,
        /// <summary>
        /// 40001在地球
        /// </summary>
        OnEarth = 40001,
        /// <summary>
        /// 移动中
        /// </summary>
        Moving = 4102
    }

}
