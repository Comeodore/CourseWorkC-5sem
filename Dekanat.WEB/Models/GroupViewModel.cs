using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dekanat.WEB.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount_of_students { get; set; }
        public int Course { get; set; }
        public string Faculty { get; set; }

        public List<StudentViewModel> Students { get; set; }


    }
}