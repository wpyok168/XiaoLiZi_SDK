using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Core
{
    public class TextFormat
    {
        /// <summary>
        /// 艾特某人
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public string GetAt(long qq)
        {
            return $"[@{qq.ToString()}]";
        }
        /// <summary>
        /// 艾特全体
        /// </summary>
        /// <returns></returns>
        public string GetAtAll()
        {
            return "[@all]";
        }
        /// <summary>
        /// 表情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetFace(int id,string name)
        {
            return $"[Face,Id={id},name={name}]";
        }
        /// <summary>
        /// 大表情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string GetFace(int id, string name,string hash,string flag)
        {
            return $"[bigFace,Id={id},name={name},hash={hash},flag={flag}]";
        }
        /// <summary>
        /// 小表情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSmallFace(int id, string name)
        {
            return $"[smallFace,name={name},Id={id}]";
        }
        /// <summary>
        /// 抖一抖
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetShake(string name, int id, int type)
        {
            return $"[Shake,name={name} ,Type={type},Id={id}]";
        }
        /// <summary>
        /// 厘米秀 目前不支持3D消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetLimiShow(string name, int id, int type,long QQ)
        {
            return $"[limiShow,Id={id},name={name},type={type},object={QQ}]";
        }
        /// <summary>
        /// 闪照_本地
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public string GetFlashPicFile(string path)
        {
            return $"[flashPicFile,path={path}]";
        }
        /// <summary>
        /// 闪字
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="resid"></param>
        /// <param name="prompt">闪字内容，注意此处不支持其他文本代码</param>
        /// <returns></returns>
        public string GetFlashWord(string desc, string resid, string prompt)
        {
            return $"[flashWord,Desc={desc},Resid={resid},Prompt={prompt}]";
        }
        /// <summary>
        /// 坦白说
        /// </summary>
        /// <param name="QQ">对方QQ--可自定义</param>
        /// <param name="name">对方昵称--可自定义</param>
        /// <param name="desc">描述--可自定义</param>
        /// <param name="time">文本型--10位时间戳，可自定义</param>
        /// <param name="Random">发送Random--可自定义</param>
        /// <param name="backgroundtype">背景类型--可自定义，不同背景对应的值日志查看</param>
        /// <returns></returns>
        public string GetHonest(long QQ, string name, string desc, string time, string Random,string backgroundtype)
        {
            return $"[Honest,ToUin={QQ},ToNick={name},Desc={desc},Time={time},Random={Random},Bgtype={backgroundtype}]";
        }
        /// <summary>
        /// 图片_本地
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public string GetPicFile(string path)
        {
            return $"[picFile,path={path}]";
        }
        /// <summary>
        /// 涂鸦
        /// </summary>
        /// <param name="id">模型Id</param>
        /// <param name="hash">涂鸦hash</param>
        /// <param name="address">涂鸦图片地址</param>
        /// <returns></returns>
        public string GetGraffiti(int id, string hash, string address)
        {
            return $"[Graffiti,ModelId={id},hash={hash},url={address}]";
        }
        /// <summary>
        /// 小黄豆表情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Getbq(int id)
        {
            return $"[bq{id}]";
        }
        /// <summary>
        /// 小视频
        /// </summary>
        /// <param name="linkParam"></param>
        /// <param name="hash1"></param>
        /// <param name="hash2"></param>
        /// <returns></returns>
        public string GetLitleVideo(string linkParam, string hash1, string hash2)
        {
            return $"[litleVideo,linkParam={linkParam},hash1={hash1},hash2={hash2}]";
        }
        /// <summary>
        /// 语音_本地
        /// </summary>
        /// <param name="path">必须是silk_v3编码的文件</param>
        /// <returns></returns>
        public string GetAudioFile(string path)
        {
            return $"[AudioFile,path={path}]";
        }
        /// <summary>
        /// 秀图<para>秀图文本代码只支持群聊发送</para>
        /// </summary>
        /// <param name="pichash">通过群图片代码获得</param>
        /// <param name="showpictype">40000普通,40001幻影,40002抖动,40003生日,40004爱你,40005征友，默认普通</param>
        /// <returns></returns>
        public string GetShopPic(string pichash, ShowPicEnum showpictype)
        {
            return $"[picShow,hash={pichash},showtype={showpictype.ToString()}]";
        }
        /// <summary>
        /// 自定义骰子
        /// </summary>
        /// <param name="num">默认为6</param>
        /// <returns></returns>
        public string RandomDice(int num = 6)
        {
            if (num < 1 || num > 6)
            {
                num = 6;
            }
            return "[bigFace,Id=11464,name=[随机骰子]" + num + ",hash=4823D3ADB15DF08014CE5D6796B76EE1,flag=409e2a69b16918f9]";
        }
    }

}
