using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dekanat.BLL.DTO;
using Dekanat.BLL.Interfaces;
using Dekanat.DAL.Entities;
using Dekanat.DAL.Interfaces.Repositories;


namespace Dekanat.BLL.Services
{
    public class StudentService : IStudentService
    {
        IUnitRep unitRep;

        public StudentService(IUnitRep unitRep)
        {
            this.unitRep = unitRep;
        }

        public void AddStudent(StudentDTO model)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, Student>();
            });
            IMapper mapper = config.CreateMapper();

            Student newstud = mapper.Map<StudentDTO, Student>(model);
            this.unitRep.studentRepository.AddStudent(newstud);

        }

        public void DeleteStudent(int studId)
        {
            this.unitRep.studentRepository.DeleteStudent(studId);

        }

        public List<StudentDTO> GetAllStudents()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student,StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(unitRep.studentRepository.GetAllStudents());


        }

        public StudentDTO GetStudentById(int StudId)
        {


            Student STUD = unitRep.studentRepository.GetStudentById(StudId);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            IMapper mapper = config.CreateMapper();

            StudentDTO newstud2 = mapper.Map<Student, StudentDTO>(STUD);
            return newstud2;

        }

        public void UpdateStudent(StudentDTO newStud)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, Student>();
            });
            IMapper mapper = config.CreateMapper();

            Student newstud2 = mapper.Map<StudentDTO, Student>(newStud);

            this.unitRep.studentRepository.UpdateStudent(newstud2);
        }
    }
}
