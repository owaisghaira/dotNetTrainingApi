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
    public class GroupController : Controller
    {
        public JsonResult Index()
        {
            List<Group> Groups = GroupHandler.GetAll();

            return Json(new { Success = true, Payload = Groups });
        }

        public JsonResult Get(int id)
        {
            Group group = GroupHandler.GetByID(id);

            GroupViewModel model = new GroupViewModel()
            {
                GroupID = group.GroupID,
                Name = group.Name,
                Users = UserGroupHandler.GetGroupUsers(group.GroupID)
            };

            return Json(new { Success = true, Payload = model });
        }

        [HttpPost]
        public JsonResult Save([FromBody] GroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                Group group = new Group()
                {
                    Name = model.Name
                };

                if (model.GroupID > 0)
                {
                    group.GroupID = model.GroupID;

                    GroupHandler.Update(group);

                    UserGroupHandler.DeleteGroup(group.GroupID);
                }
                else
                {
                    GroupHandler.Add(group);
                }

                if (model.Users.Count > 0)
                {
                    model.Users.ForEach(u =>
                    {
                        UserGroup userGroup = new UserGroup()
                        {
                            GroupID = group.GroupID,
                            UserID = u
                        };

                        UserGroupHandler.Add(userGroup);
                    });
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
            GroupHandler.Delete(id);
            return Json(new { Success = true });
        }
    }
}
