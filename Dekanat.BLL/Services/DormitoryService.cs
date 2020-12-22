using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dekanat.BLL.DTO;
using Dekanat.BLL.Interfaces;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces;
using Dekanat.DAL.Interfaces.Repositories;

namespace Dekanat.BLL.Services
{
    public class DormitoryService : IDormitoryService
    {
        IUnitRep unitRep;

        public DormitoryService(IUnitRep unitRep)
        {
            this.unitRep = unitRep;
        }

        public List<DormitoryDTO> GetAllDormitories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dormitory, DormitoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dormitory>, List<DormitoryDTO>>(unitRep.dormitoryRepository.GetAllDormitories());

        }

        public DormitoryDTO GetDormitoryById(int DormId)
        {
            Dormitory dormitory = unitRep.dormitoryRepository.GetDormitoryById(DormId);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Dormitory, DormitoryDTO>();
            });
            IMapper mapper = config.CreateMapper();

            DormitoryDTO newdorm = mapper.Map<Dormitory, DormitoryDTO>(dormitory);
            return newdorm;
        }

        public void UpdateDormitory(DormitoryDTO newDorm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DormitoryDTO, Dormitory>();
            });
            IMapper mapper = config.CreateMapper();

            Dormitory newdorm2 = mapper.Map<DormitoryDTO, Dormitory>(newDorm);

            
            this.unitRep.dormitoryRepository.UpdateDormitory(newdorm2);

        }
        public List<DormitoryDTO> SearchByName(int num)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Dormitory, DormitoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Dormitory>, List<DormitoryDTO>>(unitRep.dormitoryRepository.SearchByNumber(num));

        }
    }
}
