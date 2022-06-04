using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;
using TrainingScheduler.ViewModels;

namespace TrainingScheduler.Controllers
{
    public class UserController : Controller
    {
        public JsonResult Index()
        {
            List<User> users = UserHandler.GetAll();

            users.ForEach(u =>
            {
                UserRole userRole = UserRoleHandler.GetByUserID(u.UserID);
                u.Role = RoleHandler.Get(userRole.RoleID).Name;
            });

            return Json(new { Success = true, Payload = users });
        }
        
        public JsonResult Get(int id)
        {
            User user = UserHandler.GetByID(id);

            UserRole userRole = UserRoleHandler.GetByUserID(user.UserID);
            Role role = RoleHandler.Get(userRole.RoleID);
            user.Role = role.Name;
            user.RoleID = role.RoleID;

            return Json(new { Success = true, Payload = user });
        }

        [HttpPost]
        public JsonResult Save([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Locale = model.Locale
                };

                if (model.UserID > 0)
                {
                    user.UserID = model.UserID;

                    UserHandler.Update(user);
                }
                else
                {
                    UserHandler.Add(user);

                    UserRole userRole = new UserRole()
                    {
                        RoleID = model.RoleID,
                        UserID = user.UserID
                    };

                    UserRoleHandler.Add(userRole);
                }

                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        public JsonResult Delete(int id)
        {
            UserHandler.Delete(id);
            return Json(new { Success = true });
        }
    }
}
