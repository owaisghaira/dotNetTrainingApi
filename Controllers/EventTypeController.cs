using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.Models;

namespace TrainingScheduler.Controllers
{
    public class EventTypeController : Controller
    {
        public JsonResult Index()
        {
            List<EventType> eventTypes = DAL.EventTypeHandler.GetAll();

            return Json(new { Success = true, Payload = eventTypes });
        }
    }
}
