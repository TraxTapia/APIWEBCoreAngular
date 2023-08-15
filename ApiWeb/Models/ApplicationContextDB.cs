using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Models
{
    public class ApplicationContextDB : DbContext
    {
        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options ):base(options)
        {

        }
        public virtual DbSet<Comentario> Comentarios { get; set; }
    }
}
