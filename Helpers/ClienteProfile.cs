using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using ApiClienteUsuarioCompleta.Model.Entities;
using AutoMapper;

namespace ApiClienteUsuarioCompleta.Helpers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDetailsDto>();
            CreateMap<ClienteAdicionarDto, Cliente>();
            CreateMap<ClienteAtualizarDto, Cliente>();
            CreateMap<Cliente, ClienteUsuarioDto>();
        }
    }
}
