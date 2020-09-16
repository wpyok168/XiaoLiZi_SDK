using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RedEnvelopesDataList
    {
        //public int index;
        public NotReRedEnvelopes notReRedEnvelopes;
    }
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct NotReRedEnvelopes
    {
        /// <summary>
        /// 来源QQ
        /// </summary>
        public long SourceQQ;
        /// <summary>
        /// listid
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string listid;
        /// <summary>
        /// authkey
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string authkey;
        /// <summary>
        /// 标题
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string title;
        /// <summary>
        /// channel
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string channel;

    }
}
