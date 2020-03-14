using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using Services;
using Tesseract;


namespace dotnet_ocr_tesseract.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        public const string folderName = "images/";
        public const string trainedDataFolderName = "tessdata";

        [HttpPost]
        public String DoOCR([FromForm] OcrModel request)
        {
            var result = new OcrService().GetLicenseNumber(request.Image, request.DestinationLanguage);

            return String.IsNullOrWhiteSpace(result) ? "Ocr is finished. Return empty" : result;
        }

    }
}
