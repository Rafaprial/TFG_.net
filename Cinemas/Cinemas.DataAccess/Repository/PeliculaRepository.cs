using Cinemas.DataAccess.Repository.IRepository;
using Cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository
{
    public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    {
        private AppDbContext _db;
        public PeliculaRepository (AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Pelicula obj)
        {
            var objFromDb = _db.Peliculas.FirstOrDefault(u=>u.Id == obj.Id);
            if(objFromDb == null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Duration = obj.Duration;
                objFromDb.Director = obj.Director;
                objFromDb.ReleaseDate = obj.ReleaseDate;
                objFromDb.Price = obj.Price;
                objFromDb.CategoriaId = obj.CategoriaId;
                objFromDb.PegiId = obj.PegiId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }


    }
}
