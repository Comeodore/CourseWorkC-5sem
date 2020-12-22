using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.BLL.DTO;

namespace Dekanat.BLL.Interfaces
{
    public interface IDormitoryService
    {
        List<DormitoryDTO> GetAllDormitories();
        List<DormitoryDTO> SearchByName(int num);
        DormitoryDTO GetDormitoryById(int DormId);
        void UpdateDormitory(DormitoryDTO newDorm);
    }
}
