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
   public class DormitoryRep : IDormitoryRep
    {
        IDekanatContext context { get; set; }
        public DormitoryRep(IDekanatContext dekContext)
        {
            context = dekContext;

        }
        public List<Dormitory> GetAllDormitories()
        {
           
            return this.context.Dormitories.ToList();
        }

        public Dormitory GetDormitoryById(int DormId)
        {
            return this.context.Dormitories.ToList().Find(x => x.Id == DormId);

        }
        public List<Dormitory> SearchByNumber(int num)
        {
            List<Dormitory> dorms = new List<Dormitory>();
            var models = context.Dormitories.ToList();

            foreach (var model in models)
            {

                if (model.Number == num)
                {
                    dorms.Add(model);
                }
            }
            return dorms;
        }

        public void UpdateDormitory(Dormitory newDorm)
        {
            var oldDorm = GetDormitoryById(newDorm.Id);
            if (oldDorm == null)
            {
                return;
            }
            this.context.Dormitories.Remove(oldDorm);
            this.context.SaveChanges();
            newDorm.Number = oldDorm.Number;
            this.context.Dormitories.Add(newDorm);
            this.context.SaveChanges();
        }
    }
}
