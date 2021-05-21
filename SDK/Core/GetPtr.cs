using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Core
{
    public class GetPtr<T>
    {
        public IntPtr[] GetIntPtrs(List<T> t)
        {
            IntPtr[] ptrs = new IntPtr[t.Count];
            for (int i = 0; i < t.Count; i++)
            {
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
                Marshal.StructureToPtr(t[i], ptr, false);
                ptrs[i] = ptr;
            }
            return ptrs;
        }
     }
}
