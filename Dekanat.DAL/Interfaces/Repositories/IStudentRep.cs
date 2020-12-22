using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.DAL.Entities;


namespace Dekanat.DAL.Interfaces.Repositories
{
    public interface IStudentRep
    {
        List<Student> GetAllStudents();
        void AddStudent (Student model);
        Student GetStudentById(int StudId);
        void UpdateStudent(Student newStud);
        void DeleteStudent(int studId);
    }
}
