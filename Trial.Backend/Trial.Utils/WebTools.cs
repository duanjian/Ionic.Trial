using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Utils
{
    public class WebTools
    {
        /// <summary>
        /// 获取加解密设置
        /// </summary>        
        private static string KeyCode = System.Configuration.ConfigurationManager.AppSettings["DesKey"].ToString();

        #region base64编码解码

        /// <summary> 
        /// Base64加密 
        /// </summary> 
        /// <param name="codeName">加密采用的编码方式</param> 
        /// <param name="source">待加密的明文</param> 
        /// <returns></returns> 
        private static string EncodeBase64(Encoding encode, string source)
        {
            //结果
            string result = "";
            //判断字符串不为空
            if (!string.IsNullOrEmpty(source))
            {
                //获取字节
                byte[] bytes = encode.GetBytes(source);

                //转换为64
                try
                {
                    result = Convert.ToBase64String(bytes);
                }
                //异常返回源字符串
                catch
                {
                    result = source;
                }
            }
            return result;
        }

        /// <summary> 
        /// Base64加密，采用utf8编码方式加密 
        /// </summary> 
        /// <param name="source">待加密的明文</param> 
        /// <returns>加密后的字符串</returns> 
        private static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary> 
        /// Base64解密 
        /// </summary> 
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param> 
        /// <param name="result">待解密的密文</param> 
        /// <returns>解密后的字符串</returns> 
        private static string DecodeBase64(Encoding encode, string result)
        {
            //结果
            string decode = "";
            //获取字节
            byte[] bytes = Convert.FromBase64String(result);
            //解密
            try
            {
                decode = encode.GetString(bytes);
            }
            //异常
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary> 
        /// Base64解密，采用utf8编码方式解密 
        /// </summary> 
        /// <param name="result">待解密的密文</param> 
        /// <returns>解密后的字符串</returns> 
        private static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }

        #endregion

        #region 3Des加密解密

        /// <summary>
        /// 3Des加密
        /// </summary>
        /// <param name="strString">明文</param>
        /// <param name="strKey">密钥</param>
        /// <returns></returns>
        #region 3Des加密
        private static string Encrypt3DES(string strString)
        {
            //加密解密实例
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(KeyCode);
            DES.Mode = CipherMode.ECB;
            //加密接口
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            //获取字节
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        #endregion

        /// <summary>
        /// 3Des解密
        /// </summary>
        /// <param name="strString">密文</param>
        /// <param name="strKey">密钥</param>
        /// <returns></returns>
        #region 3Des解密
        private static string Decrypt3DES(string strString)
        {
            //加密解密实例
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = ASCIIEncoding.ASCII.GetBytes(KeyCode);
            DES.Mode = CipherMode.ECB;
            DES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            //创建接口
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            //返回结果
            string result = "";
            //判断不为空
            if (!string.IsNullOrEmpty(strString))
            {
                //解密操作
                try
                {
                    //获取字节
                    byte[] Buffer = Convert.FromBase64String(strString);                    
                    result = ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
                }
                //抛出异常
                catch (Exception e)
                {
                    result = e.Message;
                }
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="conStr">字符串</param>
        /// <returns></returns>
        #region 转换字符串 _为+ %为= *为/
        private static string ReplaceTo(string conStr)
        {
            //不为空
            if (!string.IsNullOrEmpty(conStr))
            {
                conStr = conStr.Replace('_', '+').Replace('%', '=').Replace('*', '/');
                return conStr;
            }
            return "";
        }
        #endregion

        /// <summary>
        /// 字符串替换 +为_ =为%
        /// </summary>
        /// <param name="conStr">需要转换的字符串</param>
        /// <returns></returns>
        #region 字符串替换 +为_ =为% /为*
        private static string FromReplace(string conStr)
        {
            //不为空
            if (!string.IsNullOrEmpty(conStr))
            {
                conStr = conStr.Replace('+', '_').Replace('=', '%').Replace('/', '*');
                return conStr;
            }
            return "";
        }
        #endregion


        /// <summary>
        /// 获取明文 解码并解密
        /// </summary>
        /// <param name="turnCode">需要转换的字符串</param>
        /// <returns></returns>
        #region 获取明文 解密并解码
        public static string DecryptBase643Des(string turnCode)
        {
            //不为空
            if (!string.IsNullOrEmpty(turnCode))
            {
                turnCode = ReplaceTo(turnCode);
                turnCode = Decrypt3DES(turnCode);
                turnCode = DecodeBase64(turnCode);
            }
            return turnCode;
        }
        #endregion

        /// <summary>
        /// 加密并编码
        /// </summary>
        /// <param name="turnCode">需要转换的字符串</param>
        /// <returns></returns>
        #region 加密并编码
        public static string EncryptBase643Des(string turnCode)
        {
            //不为空
            if (!string.IsNullOrEmpty(turnCode))
            {
                turnCode = EncodeBase64(turnCode);
                turnCode = Encrypt3DES(turnCode);
                turnCode = FromReplace(turnCode);
            }
            return turnCode;
        }
        #endregion

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="turnCode">需要转换的字符串</param>
        /// <returns></returns>
        #region 编码
        private static string ToBase64(string turnCode)
        {
            //不为空
            if (!string.IsNullOrEmpty(turnCode))
            {
                turnCode = EncodeBase64(turnCode);
                turnCode = FromReplace(turnCode);
            }
            return turnCode;
        }
        #endregion

        /// <summary>
        /// 获取明文 解码
        /// </summary>
        /// <param name="turnCode">需要转换的字符串</param>
        /// <returns></returns>
        #region 获取明文解码
        private static string GetMingwen64(string turnCode)
        {
            //不为空
            if (!string.IsNullOrEmpty(turnCode))
            {
                turnCode = ReplaceTo(turnCode);
                turnCode = DecodeBase64(turnCode);
            }
            return turnCode;
        }
        #endregion

        #endregion

        /// <summary>
        /// 替换特殊字符串半角转全角
        /// </summary>
        /// <param name="strContent">被转换字符串</param>
        /// <returns></returns>
        public static string Replace(string strContent)
        {
            return strContent.Replace("'", "＇").Replace('"', '＂');
        }

        /// <summary>
        /// 下载hightcharts图片
        /// </summary>
        /// <param name="tType"></param>
        /// <param name="tSvg"></param>
        /// <param name="tFileName"></param>
        /// <returns></returns>
        //public static string DownLoadJpg(string tType, string tSvg, string tFileName, int userid, int planId)
        //{
        //    string resultPath = "0";
        //    if (tFileName == "")
        //    {
        //        tFileName = "chart";
        //    }
        //    //将svg转换为二进制流
        //    MemoryStream tData = new MemoryStream(Encoding.UTF8.GetBytes(tSvg));
        //    MemoryStream tStream = new MemoryStream();

        //    string tTmp = new Random().Next().ToString();

        //    string tExt = "";
        //    string tTypeString = "";
        //    //获取导出类型
        //    switch (tType)
        //    {
        //        case "image/png":
        //            tTypeString = "-m image/png";
        //            tExt = "png";
        //            break;
        //        case "image/jpeg":
        //            tTypeString = "-m image/jpeg";
        //            tExt = "jpg";
        //            break;
        //        case "image/svg+xml":
        //            tTypeString = "-m image/svg+xml";
        //            tExt = "svg";
        //            break;
        //    }

        //    if (tTypeString != "")
        //    {
        //        Svg.SvgDocument tSvgObj = SvgDocument.Open(tData);

        //        switch (tExt)
        //        {
        //            case "jpg":
        //                tSvgObj.Draw().Save(tStream, ImageFormat.Jpeg);
        //                break;
        //            case "png":
        //                tSvgObj.Draw().Save(tStream, ImageFormat.Png);
        //                break;
        //            case "svg":
        //                tStream = tData;
        //                break;
        //        }

        //        if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("/PlanFile/" + userid + "/" + planId + "/")) == false)//如果不存在就创建file文件夹
        //        {
        //            resultPath = "/PlanFile/" + userid + "/" + planId + "/" + tFileName + "." + tExt;
        //            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/PlanFile/" + userid + "/" + planId + "/"));
        //            //保存图表路径 可以自己指定
        //            tFileName = System.Web.HttpContext.Current.Server.MapPath("/PlanFile/" + userid + "/" + planId + "/") + tFileName + "." + tExt;

        //        }
        //        else
        //        {
        //            resultPath = "/PlanFile/" + userid + "/" + planId + "/" + tFileName + "." + tExt;
        //            //保存图表路径 可以自己指定
        //            tFileName = System.Web.HttpContext.Current.Server.MapPath("/PlanFile/" + userid + "/" + planId + "/") + tFileName + "." + tExt;
        //        }

        //        //将二进制流保存为指定路径下的具体文件    
        //        System.IO.File.WriteAllBytes(tFileName, tStream.ToArray());
        //        tData.Close();
        //        tStream.Close();
        //    }
        //    return resultPath;
        //}

    }

    public class Base64Helper
    {
        public static string DecodeBase64(string str)
        {
            str = ReplaceTo(str);
            byte[] buffer = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8 .GetString(buffer);
        }

        private static string ReplaceTo(string conStr)
        {
            //不为空
            if (!string.IsNullOrEmpty(conStr))
            {
                conStr = conStr.Replace('_', '+').Replace('%', '=').Replace('*', '/');
                return conStr;
            }
            return "";
        }
    }
}
