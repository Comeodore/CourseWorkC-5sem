using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dekanat.WEB.Models;
using Dekanat.BLL.Interfaces;
using Dekanat.BLL.DTO;
using AutoMapper;

namespace Dekanat.WEB.Controllers
{
    public class StudentController : Controller
    {
        IStudentService studentService;
        IGroupService groupService;
        IDormitoryService dormitoryService;
       

        public StudentController(IStudentService studentService, IGroupService groupService, IDormitoryService dormitoryService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.dormitoryService = dormitoryService;
        }



        // GET: Student
        public ActionResult Index()
        {
            List<StudentDTO> stDtos = studentService.GetAllStudents();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            var grps = mapper.Map<List<StudentDTO>, List<StudentViewModel>>(stDtos);
            return View(grps);
        }

        
        // GET: Student/Create
        public ActionResult Create()
        {
            StudentViewModel model = new StudentViewModel();
            //var groups = groupService.GetAllGroups();
            //ViewBag.GroupId = new SelectList(groups, "Id", "Name");
            var groups = groupService.GetAllGroups() ;
            model.Grps = new SelectList(groups, "Name", "Name", 1);
            var dor = dormitoryService.GetAllDormitories() ;
            model.Dorms = new SelectList(dor, "Number", "Number", 1) ;
            

            // var dormitories = dormitoryService.GetAllDormitories();
            //ViewBag.DormitoryId = new SelectList(dormitories, "Id", "Name");
            return View(model);
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Rating,GroupName,DormitoryNumber")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StudentViewModel,StudentDTO>();
                });
                IMapper mapper = config.CreateMapper();

                StudentDTO newgr = mapper.Map<StudentViewModel, StudentDTO>(studentViewModel);

                studentService.AddStudent(newgr);

                return RedirectToAction("Index");

            }

                //ViewBag.DormitoryId = new SelectList(dormitoryService.GetAllDormitories(), "Id", "Id", studentViewModel.DormitoryId);
                //ViewBag.GroupId = new SelectList(groupService.GetAllGroups(), "Id", "Name", studentViewModel.GroupId);
                return View(studentViewModel);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDTO newgr = studentService.GetStudentById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, StudentViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            StudentViewModel newgr2 = mapper.Map<StudentDTO, StudentViewModel>(newgr);

            if (newgr == null)
            {
                return HttpNotFound();
            }

            var groups = groupService.GetAllGroups();
            newgr2.Grps = new SelectList(groups, "Name", "Name", 1);
            var dor = dormitoryService.GetAllDormitories();
            newgr2.Dorms = new SelectList(dor, "Number", "Number", 1);
            return View(newgr2);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Rating,GroupName,DormitoryNumber")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<StudentViewModel, StudentDTO>();
                });
                IMapper mapper = config.CreateMapper();

                StudentDTO newgr2 = mapper.Map<StudentViewModel, StudentDTO>(studentViewModel);


                studentService.UpdateStudent(newgr2);
                return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentDTO newgr = studentService.GetStudentById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, StudentViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            StudentViewModel newgr2 = mapper.Map<StudentDTO, StudentViewModel>(newgr);

            if (newgr == null)
            {
                return HttpNotFound();
            }
            return View(newgr2);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

       
    }
}
