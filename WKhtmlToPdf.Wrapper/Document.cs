using System;
using System.Collections.Generic;

namespace WKhtmlToPdf.Wrapper
{
    /// <summary>
    /// 文档文件
    /// </summary>
    public class Document
    {
        private static IPdfConverter Initlize(GlobalSettings globalSettings)
        {
            var ipdfConverter = new WKhtmlConverter(new Assets.ResovleProvider());
            ipdfConverter.GlobalSettings = globalSettings;
            return ipdfConverter;
        }
        public static string Convert(GlobalSettings globalSettings)
        {
            var pdfConverter = Initlize(globalSettings);
            var result= pdfConverter.ConvertToFile();
            return result;
        }
        public static byte[] Serilize(GlobalSettings globalSettings)
        {
            var pdfConverter = Initlize(globalSettings);
            var result = pdfConverter.ConvertToBytes();
            return result;
        }
    }
}
