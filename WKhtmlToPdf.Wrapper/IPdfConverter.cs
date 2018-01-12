using System;
using System.Collections.Generic;

namespace WKhtmlToPdf.Wrapper
{
    /// <summary>
    /// pdf converter
    /// </summary>
    internal interface IPdfConverter
    {
        GlobalSettings GlobalSettings { get; set; }
        string ConvertToFile();
        byte[] ConvertToBytes();
    }
}
