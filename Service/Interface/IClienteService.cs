using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Service.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetClientes();
        Task<ClienteDetailsDto> GetClienteById(Guid id);
        Task<IEnumerable<ClienteUsuarioDto>> GetClienteUsuario(int UsuarioId);
        Task<ClienteAtualizarDto> PutCliente(Guid id, ClienteAtualizarDto cliente);
        Task<ClienteAdicionarDto> PostCliente(ClienteAdicionarDto cliente);
        Task<Cliente> DeleteCliente(Guid id);
    }
}
