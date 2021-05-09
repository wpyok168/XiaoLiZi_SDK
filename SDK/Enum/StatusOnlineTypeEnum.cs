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
        //1033在小区 41034在学校 41035在公园 41036在海边 41037在机场 41038在商场 41039在咖啡厅 41041在餐厅
        //1022度假中 1020健身中 1056嗨到起飞 1058元气满满 1057美滋滋 1059悠哉哉 1060无聊中 1061想静静 1062我太难了 1063一言难尽 1064吃鸡中 1069遇见春天
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
        Moving = 4102,
        /// <summary>
        /// 1033在小区
        /// </summary>
        IntheCommunity = 1033,
        /// <summary>
        /// 41034在学校
        /// </summary>
        inSchool = 41034,
        /// <summary>
        /// 41035在公园
        /// </summary>
        inthePark = 41035,
        /// <summary>
        /// 41036在海边
        /// </summary>
        attheSeaside = 41036,
        /// <summary>
        /// 41037在机场
        /// </summary>
        attheAirport = 41037,
        /// <summary>
        /// 41038在商场
        /// </summary>
        AttheMall = 41038,
        /// <summary>
        /// 41039在咖啡厅
        /// </summary>
        intheCoffeeShop = 41039,
        /// <summary>
        /// 41041在餐厅
        /// </summary>
        intheRestaurant = 41041,
        /// <summary>
        /// 1022度假中
        /// </summary>
        onVacation = 1022,
        /// <summary>
        /// 1020健身中
        /// </summary>
        onFitness = 1020,
        /// <summary>
        /// 1056嗨到起飞
        /// </summary>
        toTakeOff = 1056,
        /// <summary>
        /// 1058元气满满
        /// </summary>
        fullOfVitality = 1058,
        /// <summary>
        /// 1057美滋滋
        /// </summary>
        beautiful = 1057,
        /// <summary>
        /// 1059悠哉哉
        /// </summary>
        leisurely = 1059,
        /// <summary>
        /// 1060无聊中
        /// </summary>
        boring = 1060,
        /// <summary>
        /// 1061想静静
        /// </summary>
        wantToTeQuiet = 1061,
        /// <summary>
        /// 1062我太难了
        /// </summary>
        IamTooHard = 1062,
        /// <summary>
        /// 1063一言难尽
        /// </summary>
        hardToSay = 1063,
        /// <summary>
        /// 1064吃鸡中
        /// </summary>
        eatChicken = 1064,
        /// <summary>
        /// 1069遇见春天
        /// </summary>
        meetSpring = 1069,       
    }

}
