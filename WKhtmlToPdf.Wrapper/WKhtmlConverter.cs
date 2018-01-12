using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using WKhtmlToPdf.Wrapper.Assets;

namespace WKhtmlToPdf.Wrapper
{
    /// <summary>
    /// WKhtmltopdf 工具
    /// </summary>
    internal class WKhtmlConverter:IPdfConverter
    {
        private string exePath;
        public WKhtmlConverter(ResovleProvider resovleProvider)
        {
            resovleProvider.ResovleWKhtmlToPdf();
            exePath = ResovleProvider.WKHtmlToolPath;
        }
        public GlobalSettings GlobalSettings { get; set; }
        public string ConvertToFile()
        {
            if (GlobalSettings == null)
                throw new Exception("global settings is null.");
            if (String.IsNullOrEmpty(GlobalSettings.PdfPath))
                throw new Exception("pdf file path must be quired.");
            Excute();
            return GlobalSettings.PdfPath;
        }
        public byte[] ConvertToBytes()
        {
            var filePath = ConvertToFile();
            var result= File.ReadAllBytes(filePath);
            File.Delete(filePath);
            return result;
        }
        private void Excute()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = exePath;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(exePath);
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            //processStartInfo.RedirectStandardInput = true;
            //processStartInfo.RedirectStandardOutput = true;
            //processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = GlobalSettings.Build();
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
            process.Dispose();
        }
    }
}
