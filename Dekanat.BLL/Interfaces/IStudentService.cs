using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dekanat.BLL.DTO;

namespace Dekanat.BLL.Interfaces
{
    public interface IStudentService
    {
        List<StudentDTO> GetAllStudents();
        void AddStudent(StudentDTO model);
        StudentDTO GetStudentById(int StudId);
        void UpdateStudent(StudentDTO newStud);
        void DeleteStudent(int studId);
    }
}
