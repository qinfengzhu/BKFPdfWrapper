using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.IO;

namespace WKhtmlToPdf.Wrapper.Assets
{
    /// <summary>
    /// Resovle WKhtmlToPdf tools  to get default pdfconverter.
    /// </summary>
    internal class ResovleProvider
    {
        public static string HomePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            }
        }
        public static string WKHtmlToolPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CompressionFile.CompressionTitle, "bin", "wkhtmltopdf.exe");
            }
        }
        static ResovleProvider()
        {
            if (File.Exists(WKHtmlToolPath))
                return;
            using (var compressionFile = CompressionFile.Instance)
            {
                string extractPath = HomePath;
                var zipArchive = compressionFile.WKhtmlToPdfZipFile;
                zipArchive.ExtractToDirectory(HomePath);
            }
        }
        public void ResovleWKhtmlToPdf()
        {
            if (File.Exists(WKHtmlToolPath))
                return;
            using (var compressionFile = CompressionFile.Instance)
            {
                string extractPath = HomePath;
                var zipArchive = compressionFile.WKhtmlToPdfZipFile;
                zipArchive.ExtractToDirectory(HomePath);
            }
        }
    }
}
