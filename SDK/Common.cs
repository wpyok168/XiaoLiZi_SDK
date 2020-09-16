using SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SDK
{
    public static class Common
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        public static IUnityContainer unityContainer;
        /// <summary>
        /// 小栗子API 
        /// </summary>
        public static API xlzAPI = new API();
    }
}
