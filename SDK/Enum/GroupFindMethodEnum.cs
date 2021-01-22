using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Enum
{
    public enum GroupFindMethodEnum
    {
        //0不允许,1通过群号或关键词,2仅可通过群号,默认0
        /// <summary>
        /// 不允许
        /// </summary>
        NotAllowed = 0,
        /// <summary>
        /// 通过群号或关键词
        /// </summary>
        GroupName = 1,
        /// <summary>
        /// 仅可通过群号
        /// </summary>
        GroupQQ = 2
    }
    public enum AddGroupMethodEnum
    {
        //0允许任何人 1需要发送验证消息 2需要回答问题并由管理员审核 3需要正确回答问题 4不允许任何人加群,默认0
        /// <summary>
        /// 不允许
        /// </summary>
        Allow = 0,
        /// <summary>
        /// 需要发送验证消息
        /// </summary>
        Verification = 1,
        /// <summary>
        /// 需要回答问题并由管理员审核
        /// </summary>
        AnswerTheQuestions = 2,
        /// <summary>
        /// 需要正确回答问题
        /// </summary>
        AnswerTheQuestionCorrectly = 3,
        /// <summary>
        /// 不允许任何人加群
        /// </summary>
        NotAllowed = 4
    }
}
