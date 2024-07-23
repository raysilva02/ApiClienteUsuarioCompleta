using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
namespace ApiClienteUsuarioCompleta.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly ApiDbContext _context;

        public ClienteRepository(ApiDbContext context) : base (context)
        {
            _context = context;
        }
        public async Task<Cliente> GetClienteByIdAsync(Guid id)
        {
            var cliente = await _context.Clientes.FromSqlInterpolated($"SELECT * FROM Clientes WHERE Id = {id}").FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            var clientes = await _context.Clientes.FromSqlRaw("SELECT * FROM Clientes").ToListAsync();
            var clientesDto = clientes.Select(c => new ClienteDto
            {
                Nome = c.Nome,
                TipoCliente = c.TipoCliente,
                Ativo = c.Ativo
            }).ToList();
            return clientesDto;
        }
    }
}
