using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dekanat.WEB.Models
{
    public class DormitoryViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Amount_of_students { get; set; }
        public int Amount_of_rooms { get; set; }

        public List<StudentViewModel> Students { get; set; }

    }
}