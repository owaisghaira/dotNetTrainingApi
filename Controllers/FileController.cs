using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.ViewModels;

namespace TrainingScheduler.Controllers
{
    [Route("file")]
    public class FileController : Controller
    {
        [HttpPost]
        public JsonResult Upload(IFormFile userFile)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", userFile.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                userFile.CopyTo(stream);
            }

            string url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/{userFile.FileName}";

            return Json(new { Success = true, Payload = url });
        }
    }
}
