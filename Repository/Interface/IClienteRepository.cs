using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Repository.Interface
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(Guid id);
        Task<IEnumerable<ClienteUsuarioDto>> GetClienteUsuarioAsync(int UsuarioId);
    }
}
