using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bysj.Domain.Abstract;

namespace bysj.Domain.Concrete
{
    public class EFMachineRepository:IMachinesRepository
    {
        private BYSJEntities db = new BYSJEntities();

        public IEnumerable<Machine> Machines
        {
            get { return db.Machine; }
        }

        public Machine FindById(int id)
        {
            return db.Machine.Find(id);
        }

        public IQueryable<Admin> Admins        {            get { return db.Admin; }        }
    }
}
