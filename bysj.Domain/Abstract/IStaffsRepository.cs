using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bysj.Domain.Concrete;

namespace bysj.Domain.Abstract
{
    public interface IStaffsRepository
    {
        IEnumerable<Staff> Staffs { get; }
        Staff FindById(int id);
    }
}
