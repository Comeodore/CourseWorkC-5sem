using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekanat.DAL.Interfaces.Repositories
{
    public interface IUnitRep
    {
        IDormitoryRep dormitoryRepository { get; set; }
        IGroupRep groupRepository { get; set; }
        IStudentRep studentRepository { get; set; }
    }
}
