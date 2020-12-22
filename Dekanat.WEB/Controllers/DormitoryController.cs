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
    public class DormitoryController : Controller
    {
     
        IDormitoryService dormitoryService;

        public DormitoryController(IDormitoryService dormitoryService)
        {
            this.dormitoryService = dormitoryService;

        }

        // GET: Dormitory
        public ActionResult Index()
        {
            List<DormitoryDTO> dormDtos = dormitoryService.GetAllDormitories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DormitoryDTO,DormitoryViewModel>()).CreateMapper();
            var dorms = mapper.Map<List<DormitoryDTO>, List<DormitoryViewModel>>(dormDtos);
            return View(dorms);
        }

        
        
        // GET: Dormitory/Edit/5
        public ActionResult Edit(int id)
        {
            DormitoryDTO newgr = dormitoryService.GetDormitoryById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DormitoryDTO, DormitoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            DormitoryViewModel newgr2 = mapper.Map<DormitoryDTO, DormitoryViewModel>(newgr);

            if (newgr == null)
            {
                return HttpNotFound();
            }

            ViewBag.num = newgr.Number;
            return View(newgr2);
        }

        // POST: Dormitory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount_of_students,Amount_of_rooms")] DormitoryViewModel dormitoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<DormitoryViewModel, DormitoryDTO>();
                });
                IMapper mapper = config.CreateMapper();

                DormitoryDTO newgr2 = mapper.Map<DormitoryViewModel, DormitoryDTO>(dormitoryViewModel);
               

                dormitoryService.UpdateDormitory(newgr2);
                return RedirectToAction("Index");
            }
            return View(dormitoryViewModel);
        }

        

       
    }
}
