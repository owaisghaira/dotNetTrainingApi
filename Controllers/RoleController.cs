using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;

namespace TrainingScheduler.Controllers
{
    public class RoleController : Controller
    {
        public JsonResult Index()
        {
            List<Role> roles = RoleHandler.GetAll();

            return Json(new { Success = true, Payload = roles });
        }
    }
}
