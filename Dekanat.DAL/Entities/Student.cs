using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekanat.DAL.Entities
{
    public class Student
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        
        public decimal Rating { get; set; }

        public string GroupName { get; set; }

        public virtual Group Group { get; set; }

        public int? DormitoryNumber { get; set; }

        public virtual Dormitory Dormitory { get; set; }

    }
}
