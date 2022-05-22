using Cinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Categoria>
    {
        void Update(Categoria obj);

    }
}
