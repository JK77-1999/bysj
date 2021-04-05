using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bysj.Domain.Concrete;

namespace bysj.Domain.Abstract
{
    public interface IMachinesRepository
    {
        IEnumerable<Machine> Machines { get; }
        IQueryable<Admin> Admins { get; }
        Machine FindById(int id);
    }
}
