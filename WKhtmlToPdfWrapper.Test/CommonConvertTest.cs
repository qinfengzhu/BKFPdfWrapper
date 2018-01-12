using System;
using System.Collections.Generic;
using NUnit.Framework;
using WK = WKhtmlToPdf.Wrapper;
using System.IO;

namespace WKhtmlToPdfWrapper.Test
{
    [TestFixture]
    public class CommonConvertTest
    {
        [Test]
        public void HttpHtmlConvert()
        {
            var globalSetting = new WK.GlobalSettings()
            {
                HtmlPath = new List<string>()
                {
                    "www.qq.com",
                    "www.yiguo.com"
                },
                PdfPath = Path.Combine("D:\\","test.pdf")
            };
            string pdfFile = WK.Document.Convert(globalSetting);
            Assert.IsNotEmpty(pdfFile);
        }
        [Test]
        public void LocalHtmlConvert()
        {
            string localFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "html-files", "report.html");
            var globalSetting = new WK.GlobalSettings()
            {
                Header= new WK.Header(){
                    Left="我临床试验名称：LG_HAOS005",
                    HasHeaderLine=true,
                    HeaderSpacing=2,
                    FontSize=10
                },
                Footer = new WK.Footer(){
                    Right = "页面的[page]/[topage]",
                    HasFooterLine=true,
                    FooterSpacing=2,
                    FontSize=10
                },
                HtmlPath = new List<string>()
                {
                    localFile
                },
                PdfPath = Path.Combine("D:\\", "test.pdf")
            };
            string pdfFile = WK.Document.Convert(globalSetting);
            Assert.IsNotEmpty(pdfFile);
        }
        [Test]
        public void HttpAndLocalHtmlConvert()
        {
            string localFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "html-files", "report.html");
            var globalSetting = new WK.GlobalSettings()
            {
                HtmlPath = new List<string>()
                {
                    localFile,
                    "www.yiguo.com"
                },
                PdfPath = Path.Combine("D:\\", "test.pdf")
            };
            string pdfFile = WK.Document.Convert(globalSetting);
            Assert.IsNotEmpty(pdfFile);
        }
    }
}
