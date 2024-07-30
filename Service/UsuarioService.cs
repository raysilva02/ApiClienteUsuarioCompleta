using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Repository.Interface;
using ApiClienteUsuarioCompleta.Service.Interface;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using NuGet.Protocol.Core.Types;

namespace ApiClienteUsuarioCompleta.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioDetailsDto> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;
            var usuarioRetorno = _mapper.Map<UsuarioDetailsDto>(usuario);
            return usuarioRetorno;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarioByName(string name)
        {
            var usuarios = await _usuarioRepository.GetUsuarioByNameAsync(name);
            if (usuarios == null) return null;
            var usuariosRetorno = _mapper.Map<List<UsuarioDto>>(usuarios);
            return usuariosRetorno;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarios()
        {
            var clientes = await _usuarioRepository.GetUsuariosAsync();
            return clientes;
        }

        public async Task<UsuarioAdicionarDto> PostUsuario(UsuarioAdicionarDto usuario)
        {
            if (usuario == null) return null;
            var usuarioAdicionar = _mapper.Map<Usuario>(usuario);
            _usuarioRepository.Add(usuarioAdicionar);
            await _usuarioRepository.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioAtualizarDto> PutUsuario(int id, UsuarioAtualizarDto usuario)
        {
            var usuarioBanco = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuarioBanco == null) return null;
            var usuarioAtualizar = _mapper.Map(usuario, usuarioBanco);
            _usuarioRepository.Update(usuarioAtualizar);
            return await _usuarioRepository.SaveChangesAsync() ?
                usuario :
                null;
        }
        public async Task<Usuario> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null) return null;
            _usuarioRepository.Delete(usuario);
            await _usuarioRepository.SaveChangesAsync();
            return usuario;
        }
    }
}
