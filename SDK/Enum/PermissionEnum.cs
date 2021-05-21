using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    //const std::unordered_map<std::string, eint> FreeGiftMap =
    //        {
    // 367: 告白话筒, 299: 卡布奇诺, 302: 猫咪手表, 280: 牵你的手, 281: 可爱猫咪, 284: 神秘面具, 285: 甜wink, 286: 我超忙的, 289: 快乐肥宅水, 290: 幸运手链, 313: 坚强, 307: 绒绒手套, 312: 爱心口罩, 308: 彩虹糖果
    //        }

    // 某些API中可能会用
    // 权限（有感叹号的是危险权限！）
    public enum PermissionEnum
    {
        #region 英文
        /**
         
        // 输出日志
        OutputLog = 0,
        // 发送好友消息
        SendFriendMessage = 1,
        // 发送群消息
        SendGroupMessage = 2,
        // 发送群临时消息
        SendGroupTemporaryMessage = 3,
        // 添加好友
        AddFriend = 4,
        // 添加群
        AddGroup = 5,
        // 删除好友！
        RemoveFriend = 6,
        // 置屏蔽好友！
        SetBlockFriend = 7,
        // 置特别关心好友
        SetSpecialFriend = 8,
        // 发送好友json消息
        SendFriendJSONMessage = 11,
        // 发送群json消息
        SendGroupJSONMessage = 12,
        // 上传好友图片
        UploadFriendPicture = 13,
        // 上传群图片
        UploadGroupPicture = 14,
        // 上传好友语音
        UploadFriendAudio = 15,
        // 上传群语音
        UploadGroupAudio = 16,
        // 上传头像！
        UploadAvatar = 17,
        // 设置群名片
        SetGroupMemberNickname = 18,
        // 取昵称_从缓存
        GetNameFromCache = 19,
        // 强制取昵称
        GetNameForce = 20,
        // 获取skey！
        GetSKey = 21,
        // 获取pskey！
        GetPSKey = 22,
        // 获取clientkey！
        GetClientKey = 23,
        // 取框架QQ
        GetThisQQ = 24,
        // 取好友列表
        GetFriendList = 25,
        // 取群列表
        GetGroupList = 26,
        // 取群成员列表
        GetGroupMemberList = 27,
        // 设置管理员
        SetAdministrator = 28,
        // 取管理层列表
        GetAdministratorList = 29,
        // 取群名片
        GetGroupMemberNickname = 30,
        // 取个性签名
        GetSignature = 31,
        // 修改昵称！
        SetName = 32,
        // 修改个性签名！
        SetSignature = 33,
        // 删除群成员
        KickGroupMember = 34,
        // 禁言群成员
        BanGroupMember = 35,
        // 退群！
        QuitGroup = 36,
        // 解散群！
        DissolveGroup = 37,
        // 上传群头像
        UploadGroupAvatar = 38,
        // 全员禁言
        BanAll = 39,
        // 群权限_发起新的群聊
        Group_Create = 40,
        // 群权限_发起临时会话
        Group_CreateTemporary = 41,
        // 群权限_上传文件
        Group_UploadFile = 42,
        // 群权限_上传相册
        Group_UploadPicture = 43,
        // 群权限_邀请好友加群
        Group_InviteFriend = 44,
        // 群权限_匿名聊天
        Group_Anonymous = 45,
        // 群权限_坦白说
        Group_ChatFrankly = 46,
        // 群权限_新成员查看历史消息
        Group_NewMemberReadChatHistory = 47,
        // 群权限_邀请方式设置
        Group_SetInviteMethod = 48,
        // 撤回消息_群聊
        Undo_Group = 49,
        // 撤回消息_私聊本身
        Undo_Private = 50,
        // 设置位置共享
        SetLocationShare = 51,
        // 上报当前位置
        ReportCurrentLocation = 52,
        // 是否被禁言
        IsShutUp = 53,
        // 处理好友验证事件
        ProcessFriendVerification = 54,
        // 处理群验证事件
        ProcessGroupVerification = 55,
        // 查看转发聊天记录内容
        ReadForwardedChatHistory = 56,
        // 上传群文件
        UploadGroupFile = 57,
        // 创建群文件夹
        CreateGroupFolder = 58,
        // 设置在线状态
        SetStatus = 59,
        // QQ点赞！
        QQLike = 60,
        // 取图片下载地址
        GetImageDownloadLink = 61,
        // 查询好友信息
        QueryFriendInformation = 63,
        // 查询群信息
        QueryGroupInformation = 64,
        // 框架重启！
        Reboot = 65,
        // 群文件转发至群
        GroupFileForwardToGroup = 66,
        // 群文件转发至好友
        GroupFileForwardToFriend = 67,
        // 好友文件转发至好友
        FriendFileForwardToFriend = 68,
        // 置群消息接收
        SetGroupMessageReceive = 69,
        // 取群名称_从缓存
        GetGroupNameFromCache = 70,
        // 发送免费礼物
        SendFreeGift = 71,
        // 取好友在线状态
        GetFriendStatus = 72,
        // 取QQ钱包个人信息！
        GetQQWalletPersonalInformation = 73,
        // 获取订单详情
        GetOrderDetail = 74,
        // 提交支付验证码
        SubmitPaymentCaptcha = 75,
        // 分享音乐
        ShareMusic = 77,
        // 更改群聊消息内容！
        ModifyGroupMessageContent = 78,
        // 更改私聊消息内容！
        ModifyPrivateMessageContent = 79,
        // 群聊口令红包
        GroupPasswordRedEnvelope = 80,
        // 群聊拼手气红包
        GroupRandomRedEnvelope = 81,
        // 群聊普通红包
        GroupNormalRedEnvelope = 82,
        // 群聊画图红包
        GroupDrawRedEnvelope = 83,
        // 群聊语音红包
        GroupAudioRedEnvelope = 84,
        // 群聊接龙红包
        GroupFollowRedEnvelope = 85,
        // 群聊专属红包
        GroupExclusiveRedEnvelope = 86,
        // 好友口令红包
        FriendPasswordRedEnvelope = 87,
        // 好友普通红包
        FriendNormalRedEnvelope = 88,
        // 好友画图红包
        FriendDrawRedEnvelope = 89,
        // 好友语音红包
        FriendAudioRedEnvelope = 90,
        // 好友接龙红包
        FriendFollowRedEnvelope = 91,
        //.常量 权限_重命名群文件夹, "92", 公开
        Grour_RenmeFolder = 92,
        //.常量 权限_删除群文件夹, "93", 公开
        Grour_DeleteFolder = 93,
        //.常量 权限_删除群文件, "94", 公开
        Grour_DeleteFile = 94,
        //.常量 权限_保存文件到微云, "95", 公开
        Grour_Save2WwiYun = 95,
        //.常量 权限_移动群文件, "96", 公开
        Grour_MoveFile = 96,
        //.常量 权限_取群文件列表, "97", 公开
        Grour_GetFileList = 97,
        //.常量 权限_设置专属头衔, "98", 公开
        Grour_SetMemerTitle = 98,
        //.常量 权限_下线指定QQ, "99", 公开
        Grour_OfflineQQ = 99,
        //.常量 权限_登录指定QQ, "100", 公开
        Grour_LoginQQ = 100,
        //.常量 权限_取群未领红包, "101", 公开
        Grour_UnclaimedRedEnvelope = 101,
        //.常量 权限_发送输入状态, "102", 公开
        Grour_SendInputStatusr = 102,
        //.常量 权限_修改资料, "103", 公开
        Grour_ModifyInformation = 103,
        //.常量 权限_打好友电话, "104", 公开
        Grour_CallFriendsTel = 104,
        //.常量 权限_取群文件下载地址, "105", 公开
        Grour_GetFileDownload = 105,
        //.常量 权限_头像双击_好友, "106", 公开
        DoubleClickFriend = 106,
        //.常量 权限_头像双击_群, "107", 公开
        DoubleClickGroup = 107,
        //.常量 权限_取群成员简略信息, "108", 公开
        Grour_SimpleInfo = 108,
        //.常量 权限_群聊置顶, "109", 公开
        Grour_ChatTop = 109,
        //.常量 权限_私聊置顶, "110", 公开
        Grour_PrivateTop = 110,
        //.常量 权限_取加群链接, "111", 公开
        Grour_AddUrl = 111,
        //.常量 权限_设为精华, "112", 公开
        Grour_SetEssence = 112,
        //.常量 权限_群权限_设置群昵称规则, "113", 公开
        Grour_SetNiceRules = 113,
        //.常量 权限_群权限_设置群发言频率, "114", 公开
        Grour_SpeckFrequency = 114,
        //.常量 权限_群权限_设置群查找方式, "115", 公开
        Grour_FindMethod = 115,
        //.常量 权限_邀请好友加群, "116", 公开
        Grour_SetInviteFrindeAdd = 116,
        //.常量 权限_置群内消息通知, "117", 公开
        Grour_Notification = 117,
        //.常量 权限_修改群名称, "118", 公开
        Grour_UpdateName = 118,
         */
        #endregion 英文
        #region 中文权限
        输出日志 = 0,
        发送好友消息 = 1,
        发送群消息 = 2,
        发送群临时消息 = 3,
        添加好友 = 4,
        添加群 = 5,
        删除好友 = 6,
        置屏蔽好友 = 7,
        置特别关心好友 = 8,
        发送好友xml消息 = 9,
        发送群xml消息 = 10,
        发送好友json消息 = 11,
        发送群json消息 = 12,
        上传好友图片 = 13,
        上传群图片 = 14,
        上传好友语音 = 15,
        上传群语音 = 16,
        上传头像 = 17,
        设置群名片 = 18,
        取昵称_从缓存 = 19,
        强制取昵称 = 20,
        获取skey = 21,
        获取pskey = 22,
        获取clientkey = 23,
        取框架QQ = 24,
        取好友列表 = 25,
        取群列表 = 26,
        取群成员列表 = 27,
        设置管理员 = 28,
        取管理层列表 = 29,
        取群名片 = 30,
        取个性签名 = 31,
        修改昵称 = 32,
        修改个性签名 = 33,
        删除群成员 = 34,
        禁言群成员 = 35,
        退群 = 36,
        解散群 = 37,
        上传群头像 = 38,
        全员禁言 = 39,
        群权限_发起新的群聊 = 40,
        群权限_发起临时会话 = 41,
        群权限_上传文件 = 42,
        群权限_上传相册 = 43,
        群权限_邀请好友加群 = 44,
        群权限_匿名聊天 = 45,
        群权限_坦白说 = 46,
        群权限_新成员查看历史消息 = 47,
        群权限_邀请方式设置 = 48,
        撤回消息_群聊 = 49,
        撤回消息_私聊本身 = 50,
        设置位置共享 = 51,
        上报当前位置 = 52,
        是否被禁言 = 53,
        处理好友验证事件 = 54,
        处理群验证事件 = 55,
        查看转发聊天记录内容 = 56,
        上传群文件 = 57,
        创建群文件夹 = 58,
        设置在线状态 = 59,
        QQ点赞 = 60,
        取图片下载地址 = 61,
        查询好友信息 = 63,
        查询群信息 = 64,
        框架重启 = 65,
        群文件转发至群 = 66,
        群文件转发至好友 = 67,
        好友文件转发至好友 = 68,
        置群消息接收 = 69,
        取群名称_从缓存 = 70,
        发送免费礼物 = 71,
        取好友在线状态 = 72,
        取QQ钱包个人信息 = 73,
        获取订单详情 = 74,
        提交支付验证码 = 75,
        分享音乐 = 77,
        更改群聊消息内容 = 78,
        更改私聊消息内容 = 79,
        群聊口令红包 = 80,
        群聊拼手气红包 = 81,
        群聊普通红包 = 82,
        群聊画图红包 = 83,
        群聊语音红包 = 84,
        群聊接龙红包 = 85,
        群聊专属红包 = 86,
        好友口令红包 = 87,
        好友普通红包 = 88,
        好友画图红包 = 89,
        好友语音红包 = 90,
        好友接龙红包 = 91,
        重命名群文件夹 = 92,
        删除群文件夹 = 93,
        删除群文件 = 94,
        保存文件到微云 = 95,
        移动群文件 = 96,
        取群文件列表 = 97,
        设置专属头衔 = 98,
        下线指定QQ = 99,
        登录指定QQ = 100,
        取群未领红包 = 101,
        发送输入状态 = 102,
        修改资料 = 103,
        打好友电话 = 104,
        取群文件下载地址 = 105,
        头像双击_好友 = 106,
        头像双击_群 = 107,
        取群成员简略信息 = 108,
        群聊置顶 = 109,
        私聊置顶 = 110,
        取加群链接 = 111,
        设为精华 = 112,
        群权限_设置群昵称规则 = 113,
        群权限_设置群发言频率 = 114,
        群权限_设置群查找方式 = 115,
        邀请好友加群 = 116,
        置群内消息通知 = 117,
        修改群名称 = 118,
        下线其他设备 = 119,
        登录网页取ck = 120,
        发送群公告 = 121,
        取群成员信息 = 122,
        取钱包cookie = 124,
        取群网页cookie = 125,
        转账 = 127,
        余额提现 = 128,
        取收款链接 = 129,
        取群小视频下载地址 = 130,
        取私聊小视频下载地址 = 131,
        上传小视频 = 132,
        取群成员概况 = 133,
        添加好友_取验证类型 = 134,
        群聊打卡 = 135,
        群聊签到 = 136,
        置群聊备注 = 137,
        红包转发 = 138,
        发送数据包 = 139,
        请求ssoseq = 140,
        取sessionkey = 141,
        获取bkn_gtk = 142,
        置好友验证方式 = 143,
        上传照片墙图片 = 144,
        付款 = 145,
        修改支付密码 = 146,
        账号搜索 = 147,
        添加群_取验证类型 = 148,
        领取红包 = 149,
        获取红包领取详情 = 150,
        取好友文件下载地址 = 151,
        删除群成员_批量 = 152,
        取扩列资料 = 153,
        取资料展示设置 = 157,
        设置资料展示 = 158,
        获取当前登录设备信息 = 159,
        提取图片文字 = 160,
        取消精华 = 161,
        群权限_设置加群方式 = 162,
        群权限_群幸运字符 = 163,
        群权限_一起写 = 164,
        取QQ空间cookie = 165,
        修改指定QQ缓存密码 = 166,
        处理群验证事件_风险号 = 167,
        查询网址安全性 = 168,
        消息合并转发至好友 = 169,
        消息合并转发至群 = 170,
        禁言群匿名 = 171,
        领取私聊普通红包 = 172,
        领取群聊专属红包 = 173,
        发送讨论组消息 = 174,
        发送讨论组json消息 = 175,
        发送讨论组xml消息 = 176,
        发送讨论组临时消息 = 177,
        撤回消息_讨论组 = 178,
        回复QQ咨询会话 = 179,
        发送订阅号私聊消息 = 180,
        取讨论组名称_从缓存 = 181,
        修改讨论组名称 = 182,
        取讨论组成员列表 = 183,
        强制取自身匿名Id = 184,
        取订阅号列表 = 185,
        取讨论组列表 = 186,
        邀请好友加群_批量 = 187,
        邀请好友加入讨论组_批量 = 188,
        讨论组口令红包 = 189,
        讨论组拼手气红包 = 190,
        讨论组普通红包 = 191,
        讨论组画图红包 = 192,
        讨论组语音红包 = 193,
        讨论组接龙红包 = 194,
        讨论组专属红包 = 195,
        领取讨论组专属红包 = 196,
        取讨论组未领红包 = 197,
        取讨论组文件下载地址 = 198,
        发送QQ咨询会话 = 199,
        创建群聊 = 200,
        取群应用列表 = 201,
        退出讨论组 = 202,
        群验证消息接收设置 = 203,
        转让群 = 204,
        修改好友备注 = 205,
        删除讨论组成员 = 206,
        讨论组文件转发至群 = 207,
        讨论组文件转发至好友 = 208,
        拉起群收款 = 209,
        结束群收款 = 210,
        查询群收款状态 = 211,
        支付群收款 = 212,
        消息合并转发至讨论组 = 213,
        群收款_催单 = 214,
        取好友Diy名片数据 = 215,
        设置Diy名片 = 216,
        #endregion 中文权限
    }
}
