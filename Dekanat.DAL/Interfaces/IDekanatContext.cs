using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;

namespace Dekanat.DAL.Interfaces
{
    public interface IDekanatContext
    {
        DbSet<Dormitory> Dormitories { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Student> Students { get; set; }
        void SaveChanges();
    }
}
