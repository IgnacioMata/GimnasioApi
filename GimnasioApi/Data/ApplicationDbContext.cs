using Microsoft.EntityFrameworkCore;
using GimnasioApi.Models;

namespace GimnasioApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Socio> Socios { get; set; }
    }
}
