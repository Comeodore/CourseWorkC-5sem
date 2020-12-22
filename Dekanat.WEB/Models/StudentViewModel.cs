using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dekanat.WEB.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Rating { get; set; }
        public string GroupName { get; set; }
        
       
         public int? DormitoryNumber { get; set; }
        
        [Ignore]
        public SelectList Dorms { get; set; }
        [Ignore]
        public SelectList Grps { get; set; }
    }
}