using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekanat.BLL.DTO
{
   public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Rating { get; set; }
        public string GroupName { get; set; }
        
        public int? DormitoryNumber { get; set; }
    }
}
