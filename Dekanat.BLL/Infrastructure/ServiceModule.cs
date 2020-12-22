using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Dekanat.DAL.Interfaces.Repositories;
using Dekanat.DAL.Repositories;
using Dekanat.DAL.Context;
using Dekanat.DAL.Interfaces;

namespace Dekanat.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitRep>().To<UnitRep>();
            Bind<IStudentRep>().To<StudentRep>();
            Bind<IDormitoryRep>().To<DormitoryRep>();
            Bind<IGroupRep>().To<GroupRep>();
            Bind<IDekanatContext>().To<DekanatContext>();
        }
    }
}
