using bysj.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bysj.WebUI.Models
{
    public class MachinesListViewModel
    {
        public IEnumerable<Machine> Machines { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public int AreaId { get; set; }

    }
}