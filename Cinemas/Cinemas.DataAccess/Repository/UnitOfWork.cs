using Cinemas.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Pegi = new PegiRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IPegiRepository Pegi { get; private set; }

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
