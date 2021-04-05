using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bysj.Domain.Concrete;
using System.ComponentModel.DataAnnotations;

namespace bysj.WebUI.Models
{
    public class StaffViewModel
    {
        public Staff Staff { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string Newpwd { get; set; }
        public string ReturnUrl { get; set; }
    }
}