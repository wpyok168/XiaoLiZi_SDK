using SDK.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Interface
{
    public interface ISliderRecognition
    {
        /// <summary>
        /// 滑块识别
        /// </summary>
        /// <param name="e"></param>
        string SliderRecognition(SliderVerificationEvent e);
    }
    public interface ISMSVerification
    {
        /// <summary>
        /// 短信验证码
        /// </summary>
        /// <param name="e"></param>
        string SliderRecognition(SMSVerificationEvent e);
    }
}
