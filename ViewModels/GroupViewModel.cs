using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class GroupViewModel
    {
        public string Name { get; set; }
        public List<int> Users { get; set; }
        public int GroupID { get; set; }
    }

}
