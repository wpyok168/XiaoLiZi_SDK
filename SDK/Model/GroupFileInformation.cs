using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GroupFileInfoDataList
    {
        public int index;//数组索引
        public int Amount;//数组元素数量
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]//5000人群 5000/4+8 =1258
        public byte[] pAddrList;//每个元素的指针
    }
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct GroupFileInformation
    {
        // 文件夹fileid或者文件fileid
        /// <summary>
        /// 文件夹fileid或者文件fileid
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileID;
        // 文件夹名或文件名
        /// <summary>
        /// 文件夹名或文件名
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileName;
        // 文件大小，文件夹时表示有多少个文件
        /// <summary>
        /// 文件大小，文件夹时表示有多少个文件
        /// </summary>
        public long FileSize;
        // 文件md5，文件夹时为空，部分文件类型也可能是空
        /// <summary>
        /// 文件md5，文件夹时为空，部分文件类型也可能是空
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string FileMd5;
        // 创建文件夹或上传文件的QQ
        /// <summary>
        /// 创建文件夹或上传文件的QQ
        /// </summary>
        public long FileFromUin;
        // 创建文件夹或上传文件的QQ
        /// <summary>
        /// 创建文件夹或上传文件的QQ
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string  FileFromNick;
        // 文件类型  1: 文件, 2: 文件夹
        /// <summary>
        /// 文件类型  1: 文件, 2: 文件夹
        /// </summary>
        public FiletypeEnum FileType;
    }
}
