using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IronOcr;

namespace dotnet_ocr_tesseract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IronOcrController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index([FromForm] IronOcr model)
        {
            var Ocr = new AutoOcr();
            var Result = Ocr.Read(model.Image.FileName);
            return Ok();
        }
    }
}