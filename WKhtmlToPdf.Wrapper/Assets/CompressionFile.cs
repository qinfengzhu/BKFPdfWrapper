using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace WKhtmlToPdf.Wrapper.Assets
{
    /// <summary>
    /// 压缩文件
    /// </summary>
    internal sealed class CompressionFile:IDisposable
    {
        public const string CompressionTitle = "wkhtmltopdf";
        public const string FileSplit = "-";
        public static string GetEnvironmentBit() 
        {
            return Environment.Is64BitProcess ? "64" : "32";
        }
        private static string GetExcueteAssemblyFullName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
        private static string GetCurrentCompressionFileResouceName()
        {
            string resourceName = string.Format("{0}.Assets.{1}{2}{3}.zip",GetExcueteAssemblyFullName(), CompressionTitle, FileSplit, GetEnvironmentBit());
            return resourceName;
        }
        private static Stream GetManifestResourceStream()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(GetCurrentCompressionFileResouceName());
        }
        private static ZipArchive GetWKhtmlToPdfAlltoZipArchive()
        {
            return new ZipArchive(GetManifestResourceStream());
        }
        private CompressionFile()
        {

        }
        private static CompressionFile compressionFile;
        public static CompressionFile Instance
        {
            get
            {
                if (compressionFile == null)
                {
                    compressionFile = new CompressionFile();
                    compressionFile.WKhtmlToPdfZipFile = GetWKhtmlToPdfAlltoZipArchive();
                }
                return compressionFile;
            }
        }
        public ZipArchive WKhtmlToPdfZipFile { get; private set; }

        public void Dispose()
        {
            this.WKhtmlToPdfZipFile.Dispose();
        }
    }
}
