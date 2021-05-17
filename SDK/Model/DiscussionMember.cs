using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DiscussionMember
    {
        /// <summary>
        /// 账号
        /// </summary>
        public int id;
        /// <summary>
        /// 昵称
        /// </summary>
        public string name;
        /// <summary>
        /// 加入时间
        /// </summary>
        public long addTimestamp;
    }
}
