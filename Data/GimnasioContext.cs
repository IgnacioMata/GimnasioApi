using GimnasioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GimnasioApi.Data
{
    public class GimnasioContext : DbContext
    {
        public GimnasioContext(DbContextOptions<GimnasioContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
