using ApiClienteUsuarioCompleta.Model.Dtos;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Repository.Interface
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(Guid id);
    }
}
