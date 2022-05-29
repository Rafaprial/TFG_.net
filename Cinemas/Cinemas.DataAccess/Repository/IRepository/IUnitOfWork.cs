using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IPegiRepository Pegi { get; }
        IPeliculaRepository Pelicula { get; }
        void Save();
    }
}
