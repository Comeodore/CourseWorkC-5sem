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
    public class GroupController : Controller
    {
      
        IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        // GET: Group
        public ActionResult Index()
        {
            List<GroupDTO> groupDtos = groupService.GetAllGroups();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupViewModel>()).CreateMapper();
            var grps = mapper.Map<List<GroupDTO>, List<GroupViewModel>>(groupDtos);
            return View(grps);
        }

       

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Amount_of_students,Course,Faculty")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupViewModel, GroupDTO>();
            });
            IMapper mapper = config.CreateMapper();

            GroupDTO newgr = mapper.Map<GroupViewModel, GroupDTO>(groupViewModel);

            groupService.AddGroup(newgr);

            return RedirectToAction("Index");
        }

            return View(groupViewModel);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int id)
        {
            GroupDTO newgr = groupService.GetGroupById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, GroupViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            GroupViewModel newgr2 = mapper.Map<GroupDTO, GroupViewModel>(newgr);

            if (newgr == null)
            {
                return HttpNotFound();
            }
            return View(newgr2);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Amount_of_students,Course,Faculty")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<GroupViewModel, GroupDTO>();
                });
                IMapper mapper = config.CreateMapper();

                GroupDTO newgr2 = mapper.Map<GroupViewModel, GroupDTO>(groupViewModel);

                groupService.UpdateGroup(newgr2);
                return RedirectToAction("Index");
            }
            return View(groupViewModel);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            

            GroupDTO  newgr = groupService.GetGroupById(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, GroupViewModel>();
            });
            IMapper mapper = config.CreateMapper();

            GroupViewModel newgr2 = mapper.Map<GroupDTO, GroupViewModel>(newgr);

            if (newgr == null)
            {
                return HttpNotFound();
            }
            return View(newgr2);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            
            groupService.DeleteGroup(id);
            return RedirectToAction("Index");
        }
       
    }
}
