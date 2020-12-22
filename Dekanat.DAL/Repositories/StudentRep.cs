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
    public class StudentRep : IStudentRep

    {
        public StudentRep(IDekanatContext context)
        {
           this.context = context;
            //this.context.Students.Add(new Student { Name = "Alexandra", Rating = 90, GroupName = "IS-72", DormitoryNumber = 20 });

            // context.SaveChanges();
        }

        IDekanatContext context { get; set; }
        public void AddStudent(Student model)
        {
            this.context.Students.Add(model);
            this.context.SaveChanges();
        }

        public void DeleteStudent(int studId)
        {
            var model = GetStudentById(studId);

            if (model == null)
            {
                return;
            }

            this.context.Students.Remove(model);
            this.context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return this.context.Students.ToList();

        }

        public Student GetStudentById(int StudId)
        {
            return this.context.Students.ToList().Find(x => x.Id == StudId);

        }

        public List<Student> SearchByGroup(string nam)
        {
            List<Student> stds = new List<Student>();
            var models = context.Students.ToList();

            foreach (var model in models)
            {

                if (model.GroupName.ToLower().Contains(nam))
                {
                    stds.Add(model);

                }
            }
            return stds;
        }

        public List<Student> SearchByName(string nam)
        {
            List<Student> students = new List<Student>();
            var models = context.Students.ToList();

            foreach (var model in models)
            {

                if (model.Name.ToLower().Contains(nam))
                {
                    students.Add(model);

                }
            }
            return students;
        }

        public void UpdateStudent(Student newStud)
        {
            var oldStud = GetStudentById(newStud.Id);

            if (oldStud == null)
            {
                return;
            }

            
            this.context.Students.Remove(oldStud);
            this.context.SaveChanges();
            this.context.Students.Add(newStud);
            this.context.SaveChanges();
        }
    }
}
