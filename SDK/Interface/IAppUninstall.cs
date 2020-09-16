using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Interface
{
    /// <summary>
    /// 插件卸载事件
    /// </summary>
    public interface IAppUninstall
    {
        /// <summary>
        /// 插件卸载事件
        /// </summary>
        void AppUninstall();
    }
}
