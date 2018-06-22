using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace QRcodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QRcode qrcode = new QRcode();
            qrcode.Create("太原", 2018, @"E:\file\");
        }
    }

    public class QRcode
    {
        //生成二维码类
        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="size">图片大小</param>
        /// <param name="path">图片位置 
        /// 例如  /abc/abc/
        /// </param>
        /// <returns>返回生成的二维码图片路径</returns>
        public string Create(string str, int size, string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Bitmap bt;
                string enCodeString = str;
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeVersion = 5;
                bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

                string filename =   path + Guid.NewGuid() + ".jpg";
                bt.Save(filename);

                return filename.Replace("~", "");
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
