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
        /// <param name="wide">宽度</param>
        /// <param name="high">高度</param>
        /// <param name="time">时长</param>
        /// <returns></returns>
        public string GetLitleVideo(string linkParam, string hash1, string hash2, int wide=0, int high = 0, int time = 0)
        {
            return $"[litleVideo,linkParam={linkParam},hash1={hash1},hash2={hash2},wide={wide},high={high},time={time}]";
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
        /// <param name="wide">宽度</param>
        /// <param name="high">高度</param>
        /// <param name="cartoon">动图,为真时可自动播放动图</param>
        /// <returns></returns>
        public string GetShopPic(string pichash, ShowPicEnum showpictype, int wide = 0, int high = 0, bool cartoon = false)
        {
            return $"[picShow,hash={pichash},showtype={showpictype.ToString()},wide={wide},high={high},cartoon={cartoon}]";
        }
        /// <summary>
        /// 自定义骰子
        /// </summary>
        /// <param name="num">1-6,不在1-6的范围时,默认无结果(无限摇骰子)</param>
        /// <returns></returns>
        public string GetRandomDice(int num = 0)
        {
            return "[bigFace,Id=11464,name=[随机骰子]" + ((num < 1 || num > 6) ? "" : num.ToString()) + ",hash=4823D3ADB15DF08014CE5D6796B76EE1,flag=409e2a69b16918f9]";
        }
        /// <summary>
        /// 粘贴消息<para>粘贴内容直接追加在本命令后面,粘贴内容只支持图片、表情</para>
        /// </summary>
        /// <param name="x">X值：与粘贴位置有关,由横向位置经过特定算法得到</param>
        /// <param name="y">Y值：与粘贴位置有关,由纵向位置经过特定算法得到</param>
        /// <param name="msgWitdh">粘贴内容宽值：可决定粘贴内容的宽度,由缩放宽度经过特定算法得到</param>
        /// <param name="msgHight">粘贴内容高值：可决定粘贴内容的高度,由缩放高度经过特定算法得到</param>
        /// <param name="msgAngle">粘贴倾角：粘贴内容与水平位置的倾角</param>
        /// <param name="msgRecTime">消息接收时间</param>
        /// <param name="msgReq">消息req</param>
        /// <param name="msgRandom">消息random</param>
        /// <returns></returns>
        public string GetPasteMsg(string x, string y,string msgWitdh,string msgHight,string msgAngle,int msgRecTime,int msgReq,long msgRandom)
        {
            return $"[Sticker,X={x},Y={y},Width={msgWitdh},Height={msgHight},Rotate={msgAngle},Req={msgReq.ToString()},Random={msgRandom.ToString()},SendTime={msgRecTime.ToString()}]";
        }
        /// <summary>
        /// 分享名片
        /// </summary>
        /// <param name="type">0为群分享,其他则为好友分享</param>
        /// <param name="otherQQ">Type为0则表示QQ号,Type为其他则表示群号</param>
        /// <returns></returns>
        public string GetShareCard(int type,long otherQQ)
        {
            string type1 = string.Empty;
            if (type == 0)
            {
                type1 = "Group";
            }
            else
            {
                type1 = "Friend";
            }
            return $"[Share,ID={otherQQ},Type={type1}]";
        }
        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="otherMsg">对方发的信息</param>
        /// <param name="otherQQ">对方QQ</param>
        /// <param name="msgrectime">消息接收时间</param>
        /// <param name="msgreq">消息req</param>
        /// <param name="random">消息random</param>
        /// <returns></returns>
        public string ReplyTxt(string otherMsg, long otherQQ, int msgrectime, int msgreq, long random)
        {
            return $"[Reply,Content={otherMsg},SendQQID={otherQQ},Req={msgreq.ToString()},Random={random.ToString()},SendTime={msgrectime.ToString()}]";
        }
        /// <summary>
        /// 自定义猜拳
        /// </summary>
        /// <param name="num">1-3,1石头,2剪刀,3布,不在1-3的范围时,默认无结果(无限改变猜拳结果)</param>
        /// <returns></returns>
        public string GetGuessing(int num = 0)
        {
            return "[bigFace,Id=11415,name=[猜拳]" + ((num < 1 || num > 3) ? "" : num.ToString()) + ",hash=83C8A293AE65CA140F348120A77448EE,flag=7de39febcf45e6db]";
        }
    }

}
