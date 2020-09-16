using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PersonalInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string 昵称;
        /// <summary>
        /// 1:男 2:女,默认男
        /// </summary>
        public int 性别 = 1;
        /// <summary>
        /// 格式：2020/5/5 均为整数
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string 生日;
        /// <summary>
        /// 1:IT,2:制造,3:医疗,4:金融,5:商业,6:文化,7:艺术,8:法律,9:教育,10:行政,11:模特,12:空姐,13:学生,14:其他职业，默认1
        /// </summary>
        public int 职业;
        [MarshalAs(UnmanagedType.LPStr)]
        public string 公司名;
        /// <summary>
        /// 国家代码|省份代码|市代码|区字母|区代码，如：49|13110|56|NK|51，表示中国江西省吉安市青原区，这些数据是腾讯的数据，非国际数据
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string 所在地;
        /// <summary>
        /// 国家代码|省份代码|市代码|区字母|区代码，如：49|13110|56|NK|51，表示中国江西省吉安市青原区，这些数据是腾讯的数据，非国际数据
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string 家乡;
        [MarshalAs(UnmanagedType.LPStr)]
        public string 邮箱;
        [MarshalAs(UnmanagedType.LPStr)]
        public string 个人说明;
    }
}
