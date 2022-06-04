using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
