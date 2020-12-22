using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekanat.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount_of_students { get; set; }
        public int Course { get; set; }
        public string Faculty { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
