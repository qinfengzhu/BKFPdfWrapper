using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WKhtmlToPdf.Wrapper
{
    /// <summary>
    /// 构建配置
    /// </summary>
    public interface BuildSetting
    {
        string Build();
    }
    /// <summary>
    /// 配置设置,主要是配置转换的各种参数
    /// 参数参考:https://wkhtmltopdf.org/usage/wkhtmltopdf.txt
    /// </summary>
    public class GlobalSettings : BuildSetting
    {
        public GlobalSettings()
        {
            Header = new Header();
            Footer = new Footer();
            MarginBottom = 0;
            MarginLeft = 10;
            MarginRight = 10;
            MarginTop = 0;
            PageSize = "A4";
        }
        #region 全局详细配置
        /// <summary>
        /// --margin-bottom (default 0mm)
        /// </summary>
        public int MarginBottom { get; set; }
        /// <summary>
        /// --margin-left (default 10mm)
        /// </summary>
        public int MarginLeft { get; set; }
        /// <summary>
        /// --margin-right (default 10mm)
        /// </summary>
        public int MarginRight { get; set; }
        /// <summary>
        /// --margin-top (default 0mm)
        /// </summary>
        public int MarginTop { get; set; }
        /// <summary>
        /// --page-size (default A4)
        /// </summary>
        public string PageSize { get; set; }
        #endregion
        /// <summary>
        /// Pdf文件存储的位置
        /// </summary>
        public string PdfPath { get; set; }
        /// <summary>
        /// Html 待转换的Uri路径
        /// </summary>
        public List<string> HtmlPath { get; set; }
        /// <summary>
        /// 页眉配置
        /// </summary>
        public Header Header { get; set; }
        /// <summary>
        /// 页脚配置
        /// </summary>
        public Footer Footer { get; set; }
        public string Build()
        {
            StringBuilder builder = new StringBuilder();
            if (MarginBottom != 0)
                builder.AppendFormat(" --margin-bottom {0} ", MarginBottom);
            if (MarginLeft != 10)
                builder.AppendFormat(" --margin-left {0} ", MarginLeft);
            if (MarginRight != 10)
                builder.AppendFormat(" --margin-right {0} ", MarginRight);
            if (MarginTop != 0)
                builder.AppendFormat(" --margin-top {0} ", MarginTop);
            if (PageSize != "A4")
                builder.AppendFormat(" --page-size {0} ", PageSize);
            //Header 配置构建
            builder.AppendFormat(" {0} ", Header.Build());
            //Footer 配置构建
            builder.AppendFormat(" {0} ", Footer.Build());

            //Html 资源集合参数,可以是网络资源可以是本地资源
            foreach (var htmlPath in HtmlPath)
            {
                builder.Append(" " + htmlPath + " ");
            }
            //Pdf存储的位置
            builder.Append(" " + PdfPath + " "); 
            return builder.ToString();
        }
    }
    /*
    *[page]       Replaced by the number of the pages currently being printed
    * [frompage]   Replaced by the number of the first page to be printed
    * [topage]     Replaced by the number of the last page to be printed
    * [webpage]    Replaced by the URL of the page being printed
    * [section]    Replaced by the name of the current section
    * [subsection] Replaced by the name of the current subsection
    * [date]       Replaced by the current date in system local format
    * [isodate]    Replaced by the current date in ISO 8601 extended format
    * [time]       Replaced by the current time in system local format
    * [title]      Replaced by the title of the of the current page object
    * [doctitle]   Replaced by the title of the output document
    * [sitepage]   Replaced by the number of the page in the current site being converted
    * [sitepages]  Replaced by the number of pages in the current site being converted
     */
    /// <summary>
    /// 页脚      
    /// </summary>
    public class Footer : BuildSetting
    {
        public Footer()
        {
            HasFooterLine = false;
            FooterSpacing = 0;
            FontSize = 12;
            FontName = "Arial";
        }
        /// <summary>
        /// --footer-center 
        /// </summary>
        public string Center { get; set; }
        /// <summary>
        /// --footer-left
        /// </summary>
        public string Left { get; set; }
        /// <summary>
        /// --footer-line  | --no-footer-line (default)
        /// </summary>
        public bool HasFooterLine { get; set; }
        /// <summary>
        /// --footer-right
        /// </summary>
        public string Right { get; set; }
        /// <summary>
        /// --footer-spacing  (default 0)
        /// </summary>
        public int FooterSpacing { get; set; }
        /// <summary>
        /// --footer-font-size (default 12)
        /// </summary>
        public int FontSize { get; set; }
        /// <summary>
        /// --footer-font-name (default Arial)
        /// </summary>
        public string FontName { get; set; }
        public string Build()
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(Center))
                builder.AppendFormat(" --footer-center {0} ", Center.Trim());
            if (!string.IsNullOrEmpty(Left))
                builder.AppendFormat(" --footer-left {0} ", Left.Trim());
            if (!string.IsNullOrEmpty(Right))
                builder.AppendFormat(" --footer-right {0} ", Right.Trim());
            if (HasFooterLine)
                builder.Append(" --footer-line ");
            if (FooterSpacing != 0)
                builder.AppendFormat(" --footer-spacing {0} ", FooterSpacing);
            if (FontSize != 12)
                builder.AppendFormat(" --footer-font-size {0} ", FontSize);
            if (!string.IsNullOrEmpty(FontName))
                builder.AppendFormat(" --footer-font-name {0} ", FontName);
            return builder.ToString();
        }
    }
    /// <summary>
    /// 页眉
    /// </summary>
    public class Header : BuildSetting
    {
        public Header()
        {
            HasHeaderLine = false;
            HeaderSpacing = 0;
            FontSize = 12;
            FontName = "Arial";
        }
        /// <summary>
        /// --header-center 
        /// </summary>
        public string Center { get; set; }
        /// <summary>
        /// --header-left
        /// </summary>
        public string Left { get; set; }
        /// <summary>
        /// --header-line  | --no-header-line (default)
        /// </summary>
        public bool HasHeaderLine { get; set; }
        /// <summary>
        /// --header-right
        /// </summary>
        public string Right { get; set; }
        /// <summary>
        /// --header-spacing  (default 0)
        /// </summary>
        public int HeaderSpacing { get; set; }
        /// <summary>
        /// --header-font-size (default 12)
        /// </summary>
        public int FontSize { get; set; }
        /// <summary>
        /// --header-font-name (default Arial)
        /// </summary>
        public string FontName { get; set; }
        public string Build()
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(Center))
                builder.AppendFormat(" --header-center {0} ", Center.Trim());
            if (!string.IsNullOrEmpty(Left))
                builder.AppendFormat(" --header-left {0} ", Left.Trim());
            if (!string.IsNullOrEmpty(Right))
                builder.AppendFormat(" --header-right {0} ", Right.Trim());
            if (HasHeaderLine)
                builder.Append(" --header-line ");
            if (HeaderSpacing != 0)
                builder.AppendFormat(" --header-spacing {0} ", HeaderSpacing);
            if (FontSize != 12)
                builder.AppendFormat(" --header-font-size {0} ", FontSize);
            if (!string.IsNullOrEmpty(FontName))
                builder.AppendFormat(" --header-font-name {0} ", FontName);
            return builder.ToString();
        }
    }
}
