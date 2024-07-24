using ApiClienteUsuarioCompleta.Model.Dtos;
using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Repository.Interface
{
    public interface IUsuarioRepository : IBaseRepository
    {
        Task<IEnumerable<UsuarioDto>> GetUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<UsuarioDto>> GetUsuarioByNameAsync(string name);
    }
}
