using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;
using AutoMapper;

namespace ApiClienteUsuarioCompleta.Helpers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDetailsDto>();
            CreateMap<UsuarioAdicionarDto, Usuario>();
            CreateMap<UsuarioAtualizarDto, Usuario>();
        }
    }
}
