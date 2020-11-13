using SDK.Core;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="log"></param>
        public static void BugLog(string log)
        {
            string logpath = xlzAPI.GetPluginDataDirectoryEvent() + "XlzLogs";
            if (!Directory.Exists(logpath))
            {
                Directory.CreateDirectory(logpath);
            }
            File.AppendAllText(logpath + "\\log.txt", log + "\n");
        }
    }
}
