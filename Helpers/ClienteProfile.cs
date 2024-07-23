using ApiClienteUsuarioCompleta.Model.Dtos;
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
        }
    }
}
