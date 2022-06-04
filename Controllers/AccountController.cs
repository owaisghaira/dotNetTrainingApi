using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;
using TrainingScheduler.ViewModels;

namespace TrainingScheduler.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : Controller
    {
        [HttpPost]
        public JsonResult Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Username,
                    Password = model.Password,
                };

                User result = UserHandler.Get(user);

                if (result != null)
                {
                    UserRole userRole = UserRoleHandler.GetByUserID(result.UserID);
                    Role role = RoleHandler.Get(userRole.RoleID);

                    result.StationID = model.StationID;
                    result.IsReady = false;

                    UserHandler.Update(result);

                    return Json(new { Success = true, Payload = result , Role = role.Name });
                }
                else
                {
                    return Json(new { Success = false, Error = "Invalid login credentials" });
                }
            }
            else
            {
                return Json(new { Success = false, Error = "Username and password fields are required" });
            }
        }




        [HttpPost]
        public JsonResult Logout([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Username,
                    Password = model.Password,
                };

                User result = UserHandler.Get(user);

                if (result != null)
                {
                    result.StationID = string.Empty;
                    result.IsReady = false;

                    UserHandler.Update(result);

                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false, Error = "Unable to logout. Please try again" });
                }
            }
            else
            {
                return Json(new { Success = false, Error = "Unable to logout. Please try again" });
            }
        }

        [HttpPost]
        public JsonResult GetStatus([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Username,
                    Password = model.Password,
                };

                User result = UserHandler.Get(user);

                bool online = !string.IsNullOrEmpty(result.StationID);

                if (result != null)
                {
                    return Json(new { Success = true, Payload = online, ready = result.IsReady  });
                }
                else
                {
                    return Json(new { Success = false, Error = "Unable to logout. Please try again" });
                }
            }
            else
            {
                return Json(new { Success = false, Error = "Unable to logout. Please try again" });
            }
        }

        [HttpPost]
        public JsonResult ToggleStatus([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Username,
                    Password = model.Password,
                };

                User result = UserHandler.Get(user);

                result.IsReady = !result.IsReady;

                UserHandler.Update(result);

                if (result != null)
                {
                    return Json(new { Success = true, Payload = result.IsReady });
                }
                else
                {
                    return Json(new { Success = false, Error = "Unable to logout. Please try again" });
                }
            }
            else
            {
                return Json(new { Success = false, Error = "Unable to logout. Please try again" });
            }
        }
    }
}
