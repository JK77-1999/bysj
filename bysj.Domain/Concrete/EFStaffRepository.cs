using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bysj.Domain.Abstract;

namespace bysj.Domain.Concrete
{
    public class EFStaffRepository:IStaffsRepository
    {
        private BYSJEntities db = new BYSJEntities();

        public IEnumerable<Staff> Staffs
        {
            get { return db.Staff; }
        }

        public Staff FindById(int id)
        {
            return db.Staff.Find(id);
        }
    }
}
