﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    /// <summary>
    /// 讨论组信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Discussion
    {
        /// <summary>
        /// 讨论组Id
        /// </summary>
        public int id;
        /// <summary>
        /// 成员总数
        /// </summary>
        public int count;
        /// <summary>
        /// 加入时间戳
        /// </summary>
        public long addTimestamp;
    }
    
}
