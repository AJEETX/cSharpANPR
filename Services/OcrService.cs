using Microsoft.AspNetCore.Http;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tesseract;

namespace Services
{
    public class OcrService
    {
        public const string folderName = "images/";
        public const string GrayfolderName = "images/GrayImage/";
        public const string trainedDataFolderName = "tessdata";
        public string GetLicenseNumber(IFormFile image, string language)
        {
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(folderName + image.FileName, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            string inputFileName = folderName + image.FileName;
            string outputFileName = GrayfolderName + image.FileName;
            using (var Openimage = new Mat(inputFileName))
            using (var gray = Openimage.CvtColor(ColorConversionCodes.BGR2GRAY))
                gray.SaveImage(outputFileName);

            string tessPath = Path.Combine(trainedDataFolderName, "");
            string result = "";

            using (var engine = new TesseractEngine(tessPath, language, EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(outputFileName))
                {
                    var page = engine.Process(img);
                    result = page.GetText();
                }
            }
            return result;
        }
    }
}
