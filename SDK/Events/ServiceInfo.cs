using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Events
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct ServiceInfo
    {
        public ServiceInformation ServiceList;
        public int ServiceLevel;
    }
}
