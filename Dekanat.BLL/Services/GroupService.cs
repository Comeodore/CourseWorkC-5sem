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
    public class GroupService : IGroupService
    {
        IUnitRep unitRep;

        public GroupService(IUnitRep unitRep)
        {
            this.unitRep = unitRep;
        }

        public void AddGroup(GroupDTO model)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
            });
            IMapper mapper = config.CreateMapper();

            Group newGroup = mapper.Map<GroupDTO, Group>(model);
            this.unitRep.groupRepository.AddGroup(newGroup);

        }

        public void DeleteGroup(int groupId)
        {
            var students = unitRep.studentRepository.GetAllStudents();

            var group =unitRep.groupRepository.GetGroupById(groupId);
            foreach (Student st in students)
            {
                if (st.GroupName == group.Name )
                {
                    this.unitRep.studentRepository.DeleteStudent(st.Id);
                    //st.GroupName = "-";
                }
            }
            this.unitRep.groupRepository.DeleteGroup(groupId);

        }

        public List<GroupDTO> GetAllGroups()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Group>, List<GroupDTO>>(unitRep.groupRepository.GetAllGroups());

        }

        public GroupDTO GetGroupById(int GroupId)
        {
            Group group = unitRep.groupRepository.GetGroupById(GroupId);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
            });
            IMapper mapper = config.CreateMapper();

            GroupDTO newgroup = mapper.Map<Group, GroupDTO>(group);
            return newgroup;
        }

        public void UpdateGroup(GroupDTO newGroup)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
            });
            IMapper mapper = config.CreateMapper();

            Group newgroup2 = mapper.Map<GroupDTO, Group>(newGroup);


            this.unitRep.groupRepository.UpdateGroup(newgroup2);

        }
    }
}
