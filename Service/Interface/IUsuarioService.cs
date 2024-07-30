using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Service.Interface
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetUsuarios();
        Task<UsuarioDetailsDto> GetUsuarioById(int id);
        Task<IEnumerable<UsuarioDto>> GetUsuarioByName(string name);
        Task<UsuarioAdicionarDto> PostUsuario(UsuarioAdicionarDto usuario);
        Task<UsuarioAtualizarDto> PutUsuario(int id, UsuarioAtualizarDto usuario);
        Task<Usuario> DeleteUsuario(int id);
    }
}
