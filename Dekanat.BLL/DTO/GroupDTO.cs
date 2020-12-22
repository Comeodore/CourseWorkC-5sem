using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekanat.BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount_of_students { get; set; }
        public int Course { get; set; }
        public string Faculty { get; set; }
    }
}
