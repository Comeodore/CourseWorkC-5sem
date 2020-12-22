using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces.Repositories;
using Dekanat.DAL.Interfaces;

namespace Dekanat.DAL.Repositories
{
    public class UnitRep : IUnitRep
    {
        public UnitRep(IDormitoryRep dormitoryRepository, IGroupRep groupRepository, IStudentRep studentRepository)
        {
            this.dormitoryRepository = dormitoryRepository;
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }

        public IDormitoryRep dormitoryRepository { get; set ; }
        public IGroupRep groupRepository { get; set; }
        public IStudentRep studentRepository { get; set; }
    }
}
