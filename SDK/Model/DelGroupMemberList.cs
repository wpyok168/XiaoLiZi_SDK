using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DelGroupMembDataList
    {
        public DelGroupMemberList QQList;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DelGroupMemberList
    {
        //public int index;//数组索引
        //public int Amount;//数组元素数量
        ////[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public long[] QQList;
    }
}
