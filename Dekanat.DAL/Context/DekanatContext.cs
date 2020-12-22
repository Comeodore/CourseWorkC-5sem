using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces;

namespace Dekanat.DAL.Context
{
     public class DekanatContext : DbContext, IDekanatContext
    {
        public DekanatContext() : base("Connection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DekanatContext>());
        }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

      
        void IDekanatContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
