using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;

namespace Dekanat.DAL.Interfaces.Repositories
{
    public interface IDormitoryRep
    {
        List<Dormitory> GetAllDormitories();
        List<Dormitory> SearchByNumber(int num);
        Dormitory GetDormitoryById(int DormId);
        void UpdateDormitory(Dormitory newDorm);
    }
}
