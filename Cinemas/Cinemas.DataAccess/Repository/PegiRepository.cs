using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository
{
    public class PegiRepository : Repository<Pegi>, IPegiRepository
    {
        private AppDbContext _db;
        public PegiRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Pegi obj)
        {
            _db.Pegis.Update(obj);
        }
    }
}
