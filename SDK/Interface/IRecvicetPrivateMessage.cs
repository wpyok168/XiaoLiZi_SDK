using SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDK.Core.XLZMain;

namespace SDK.Interface
{
    /// <summary>
    /// 接收好友信息
    /// </summary>
    public interface IRecvicetPrivateMessage
    {
        /// <summary>
        /// 接收好友信息
        /// </summary>
        /// <param name="e"></param>
        void RecvicetPrivateMsg(PrivateMessageEvent e);
    }
}
