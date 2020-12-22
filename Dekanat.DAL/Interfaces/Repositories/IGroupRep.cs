using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;

namespace Dekanat.DAL.Interfaces.Repositories
{
    public interface IGroupRep
    {
        IEnumerable<Group> GetAllGroups();
        void AddGroup(Group model);
        Group GetGroupById(int GroupId);
        void UpdateGroup(Group newGroup);
        void DeleteGroup(int groupId);
    }
}
