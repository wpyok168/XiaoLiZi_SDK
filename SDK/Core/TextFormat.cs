using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SDK.Core
{
    public class TextFormat
    {
        #region 创建方法
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
        public string GetFace(int id, string name)
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
        public string GetFace(int id, string name, string hash, string flag)
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
        public string GetLimiShow(string name, int id, int type, long QQ)
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
        public string GetHonest(long QQ, string name, string desc, string time, string Random, string backgroundtype)
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
        public string GetLitleVideo(string linkParam, string hash1, string hash2, int wide = 0, int high = 0, int time = 0)
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
        /// <param name="num">默认为6</param>
        /// <returns></returns>
        public string GetRandomDice(int num = 6)
        {
            if (num < 1 || num > 6)
            {
                num = 6;
            }
            return "[bigFace,Id=11464,name=[随机骰子]" + num + ",hash=4823D3ADB15DF08014CE5D6796B76EE1,flag=409e2a69b16918f9]";
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
        public string GetPasteMsg(string x, string y, string msgWitdh, string msgHight, string msgAngle, int msgRecTime, int msgReq, long msgRandom)
        {
            return $"[Sticker,X={x},Y={y},Width={msgWitdh},Height={msgHight},Rotate={msgAngle},Req={msgReq.ToString()},Random={msgRandom.ToString()},SendTime={msgRecTime.ToString()}]";
        }
        public string GetShareCard(int type, long otherQQ)
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
            return $"[Share,ID={otherQQ},Type={type1}]]";
        }
        #endregion
        #region 解析方法
        public static string TextCodeEncode(string source)
        {
            if (source == null) return string.Empty;
            StringBuilder builder = new StringBuilder(source);
            builder = builder.Replace("[", "\\u005b");
            builder = builder.Replace("]", "\\u005d");
            return builder.ToString();
        }
        public static string TextCodeDecode(string source)
        {
            if (source == null) return string.Empty;
            StringBuilder builder = new StringBuilder(source);
            builder = builder.Replace("\\u005b", "[");
            builder = builder.Replace("\\u005d", "]");
            return builder.ToString();
        }

        /*
[@4342334]
[@all]
[Face,Id={id},name={name}]
[bigFace,Id={id},name={name},hash={hash},flag={flag}]
[smallFace,name={name},Id={id}]
[Shake,name={name} ,Type={type},Id={id}]
[limiShow,Id={id},name={name},type={type},object={QQ}]
[flashPicFile,path={path}]
[flashWord,Desc={desc},Resid={resid},Prompt={prompt}]
[Honest,ToUin={QQ},ToNick={name},Desc={desc},Time={time},Random={Random},Bgtype={backgroundtype}]
[picFile,path={path}]
[Graffiti,ModelId={id},hash={hash},url={address}]
[litleVideo,linkParam={linkParam},hash1={hash1},hash2={hash2},wide={wide},high={high},time={time}]
[AudioFile,path={path}]
[picShow,hash={pichash},showtype={showpictype.ToString()},wide={wide},high={high},cartoon={cartoon}]
[Sticker,X={x},Y={y},Width={msgWitdh},Height={msgHight},Rotate={msgAngle},Req={msgReq.ToString()},Random={msgRandom.ToString()},SendTime={msgRecTime.ToString()}]
[Share,ID={otherQQ},Type={type1}]
         */
        public enum XiaoLzFunction
        {
            /// <summary>
            /// 表示小栗子文本转义的[@xxxx]类型
            /// </summary>
            At,
            /// <summary>
            /// 表示小栗子文本转义的[@all]类型
            /// </summary>
            AtAll,
            /// <summary>
            /// 表情
            /// </summary>
            Face,
            /// <summary>
            /// 大表情
            /// </summary>
            bigFace,
            /// <summary>
            /// 小表情
            /// </summary>
            smallFace, Shake, limiShow, flashPicFile,
            flashWord, Honest, picFile, Graffiti,
            litleVideo, AudioFile, picShow, Sticker,
            /// <summary>
            /// 分享（链接）
            /// </summary>
            Share,
            /// <summary>
            /// 其他类型（未列举出的）
            /// </summary>
            Other
        }
        /// <summary>
        /// 表示 小栗子文本转义码 的类
        /// </summary>
        public class XiaoLzTextCode
        {
            #region --字段--
            private static readonly Lazy<Regex[]> _regices = new Lazy<Regex[]>(InitializeRegex);
            private readonly string _originalString;
            private readonly XiaoLzFunction _type;
            private readonly string _functionTypeRaw;
            private readonly string _target = null;
            private Dictionary<string, string> _items;
            #endregion
            #region --属性--
            /// <summary>
            /// 当前动作的目标qq号（如 <see cref="XiaoLzFunction.At"/> 时该值有效）
            /// </summary>
            public string Target { get => _target; }
            /// <summary>
            /// 表示解析前的原文
            /// </summary>
            public string Original { get => _originalString; }
            /// <summary>
            /// 获取一个值, 指示当前实例的功能
            /// </summary>
            public XiaoLzFunction Function { get { return _type; } }
            /// <summary>
            /// 获取当前实例所包含的所有项目
            /// </summary>
            public Dictionary<string, string> Items { get { return _items; } }
            /// <summary>
            /// 解析时存储的原类型(原 <see cref="string"/> )
            /// </summary>
            public string FunctionTypeRaw { get => _functionTypeRaw; }
            #endregion
            #region --构造函数--
            /// <summary>
            /// 使用 小栗子文本转义码 字符串初始化 <see cref="XiaoLzTextCode"/> 类的新实例
            /// </summary>
            /// <param name="str">小栗子文本转义码字符串 或 包含小栗子文本转义码的字符串</param>
            private XiaoLzTextCode(string str)
            {
                this._originalString = str;
                #region --解析 XiaoLzTextCode--
                Match match = _regices.Value[0].Match(str);
                if (!match.Success) { throw new FormatException("无法解析所传入的字符串, 字符串非小栗子文本转义码格式!"); }
                #endregion
                #region --解析XiaoLzTextCode类型--
                _functionTypeRaw = match.Groups[1].Value;// 原匹配字符串存于FunctionTypeRaw
                if (!System.Enum.TryParse<XiaoLzFunction>(_functionTypeRaw, true, out _type))
                {
                    if (_functionTypeRaw.StartsWith("@"))
                    {
                        _target = _functionTypeRaw.Substring(1);
                        if (long.TryParse(_target, out _)) { this._type = XiaoLzFunction.At; }
                        else if (_target.ToLower() == "all") { this._type = XiaoLzFunction.AtAll; }
                        else { this._type = XiaoLzFunction.Other; }
                    }
                    else
                    {
                        this._type = XiaoLzFunction.Other;    // 解析不出来的时候, 直接给一个默认
                    }
                }
                #endregion
                #region --解析键值对--
                MatchCollection collection = _regices.Value[1].Matches(match.Groups[2].Value);
                this._items = new Dictionary<string, string>(collection.Count);
                foreach (Match item in collection)
                {
                    this._items.Add(item.Groups[1].Value, TextCodeDecode(item.Groups[2].Value));
                }
                #endregion
            }
            #endregion
            #region --公开方法--
            /// <summary>
            /// 从字符串中解析出所有的 小栗子文本转义码, 转换为 <see cref="XiaoLzTextCode"/> 集合
            /// </summary>
            /// <param name="source">原始字符串</param>
            /// <returns>返回等效的 <see cref="List{XiaoLzTextCode}"/></returns>
            public static List<XiaoLzTextCode> Parse(string source)
            {
                MatchCollection collection = _regices.Value[0].Matches(source);
                List<XiaoLzTextCode> codes = new List<XiaoLzTextCode>(collection.Count);
                foreach (Match item in collection)
                {
                    codes.Add(new XiaoLzTextCode(item.Groups[0].Value));
                }
                return codes;
            }
            #endregion
            #region --私有方法--
            /// <summary>
            /// 延时初始化正则表达式
            /// </summary>
            /// <returns></returns>
            private static Regex[] InitializeRegex()
            {
                // 此处延时加载, 以提升运行速度
                return new Regex[]
                {
                new Regex(@"\[([A-Za-z]*|@(?:all|\d+))(?:(,[^\[\]]+))?\]", RegexOptions.Compiled),    // 匹配小栗子文本转义码
                new Regex(@",([A-Za-z]+)=([^,\[\]]+)", RegexOptions.Compiled)               // 匹配键值对
                };
            }
            #endregion
        }
        #endregion
    }
}
