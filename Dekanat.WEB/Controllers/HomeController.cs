using AutoMapper;
using Dekanat.BLL.DTO;
using Dekanat.BLL.Interfaces;
using Dekanat.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dekanat.WEB.Controllers
{
    public class HomeController : Controller
    {
        IStudentService studentService;
        IGroupService groupService;
        IDormitoryService dormitoryService;

        public HomeController(IStudentService studentService, IGroupService groupService, IDormitoryService dormitoryService)
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.dormitoryService = dormitoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DormitoryNumberSearch(int num)
        {
            List<DormitoryDTO> dormDtos = dormitoryService.SearchByName(num);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DormitoryDTO, DormitoryViewModel>()).CreateMapper();
            var newdorms = mapper.Map<List<DormitoryDTO>, List<DormitoryViewModel>>(dormDtos);

            if (newdorms == null)
            {
                return HttpNotFound();
            }
            return View(newdorms);
        }
    }
}