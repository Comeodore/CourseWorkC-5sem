using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Dekanat.BLL.Services;
using Dekanat.BLL.Interfaces;


namespace Dekanat.WEB.Util
{
    public class DekanatModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentService>().To<StudentService>();
            Bind<IDormitoryService>().To<DormitoryService>();
            Bind<IGroupService>().To<GroupService>(); 
        }
    }
}