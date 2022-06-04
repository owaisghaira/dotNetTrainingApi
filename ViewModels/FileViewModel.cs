using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class FileViewModel
    {
        public IFormFile UserFile { get; set; }
    }
}
