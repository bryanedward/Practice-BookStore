using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class DbContextDatabase : DbContext
    {
        //configuracion para la conexion con el modelo de la clase y la base de datos
        public DbContextDatabase(DbContextOptions<DbContextDatabase> options) : base(options)
        {
        }

        public DbSet<Books> Bookses { get; set; }
    }
}