using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Repository.Interface;
using ApiClienteUsuarioCompleta.Service.Interface;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using NuGet.Protocol.Core.Types;

namespace ApiClienteUsuarioCompleta.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDetailsDto> GetClienteById(Guid id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            var clienteRetorno = _mapper.Map<ClienteDetailsDto>(cliente);
            return clienteRetorno;
        }

        public async Task<IEnumerable<ClienteDto>> GetClientes()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return clientes;
        }

        public async Task<IEnumerable<ClienteUsuarioDto>> GetClienteUsuario(int UsuarioId)
        {
            var clientes = await _clienteRepository.GetClienteUsuarioAsync(UsuarioId);

            if (clientes == null || !clientes.Any())
            {
                return null;
            }
            var clientesDto = _mapper.Map<List<ClienteUsuarioDto>>(clientes);

            return (clientesDto);
        }

        public async Task <ClienteAtualizarDto> PutCliente(Guid id, ClienteAtualizarDto cliente)
        {
            var clienteBanco = await _clienteRepository.GetClienteByIdAsync(id);
            if (clienteBanco == null) return null;
            var clienteAtualizar = _mapper.Map(cliente, clienteBanco);
            _clienteRepository.Update(clienteAtualizar);

            return await _clienteRepository.SaveChangesAsync()
                ? cliente
                : null;
        }

        public async Task<ClienteAdicionarDto> PostCliente(ClienteAdicionarDto cliente)
        {
            if (cliente == null) return null;
            var clienteAdicionar = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Add(clienteAdicionar);
            return await _clienteRepository.SaveChangesAsync()?
                cliente:
                null;
        }

        public async Task<Cliente> DeleteCliente(Guid id)
        {
            var clienteBanco = await _clienteRepository.GetClienteByIdAsync(id);
            if (clienteBanco == null) return null;
            _clienteRepository.Delete(clienteBanco);
            await _clienteRepository.SaveChangesAsync();
            return clienteBanco;
        }
    }
}
