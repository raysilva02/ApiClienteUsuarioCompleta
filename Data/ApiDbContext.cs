using ApiClienteUsuarioCompleta.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiClienteUsuarioCompleta.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base (options)
        {
                
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
