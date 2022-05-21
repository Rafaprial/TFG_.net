using Cinemas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinemas.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
       public DbSet<Categoria> Categorias { get; set; }
    }
}
