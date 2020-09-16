using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GetCaptchaInfoDataList
    {
        //public int index;
        public CaptchaInformation CaptchaInfo;
    }
    /// <summary>
    /// 验证码信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CaptchaInformation
    {
        // token_id
        /// <summary>
        /// token_id
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string TokenID;
        // skey
        /// <summary>
        /// skey
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string SKey;
        // bank_type
        /// <summary>
        /// bank_type
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string BankType;
        // mobile
        /// <summary>
        /// mobile
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Mobile;
        // business_type
        /// <summary>
        /// business_type
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string BusinessType;
        // random
        /// <summary>
        /// random
        /// </summary>
        public int Random;
        // transaction_id
        /// <summary>
        /// transaction_id
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string TransactionID;
        // purchaser_id
        /// <summary>
        /// purchaser_id
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string PurchaserID;
        // token
        /// <summary>
        /// token
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string Token;
        // auth_params
        /// <summary>
        /// auth_params
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string AuthParams;
    }
}
