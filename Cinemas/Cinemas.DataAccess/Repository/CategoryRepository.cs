using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository
{
    public class CategoryRepository : Repository<Categoria>, ICategoryRepository
    {
        private AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Categoria obj)
        {
            _db.Categorias.Update(obj);
        }
    }
}
