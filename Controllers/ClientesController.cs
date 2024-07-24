using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Model;
using ApiClienteUsuarioCompleta.Repository.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using AutoMapper;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using Microsoft.AspNetCore.Authorization;

namespace ApiClienteUsuarioCompleta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repository.GetClientesAsync();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _repository.GetClienteByIdAsync(id);

            var clienteRetorno = _mapper.Map<ClienteDetailsDto>(cliente);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(clienteRetorno);
        }

        // PUT: api/Clientes/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(Guid id, ClienteAtualizarDto cliente)
        {
            var clienteBanco = await _repository.GetClienteByIdAsync(id);
            var clienteAtualizar = _mapper.Map(cliente, clienteBanco);
            _repository.Update(clienteAtualizar);
            return await _repository.SaveChangesAsync()
                ? Ok(cliente)
                : BadRequest("Erro ao editar cliente");
        }

        //POST: api/Clientes
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteAdicionarDto cliente)
        {
            if (cliente == null) return BadRequest("Dados inválidos!");

            var clienteAdicionar = _mapper.Map<Cliente>(cliente);

            _repository.Add(clienteAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok(cliente)
                : BadRequest("Erro ao adicionar cliente");
        }

        // DELETE: api/Clientes/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var cliente = await _repository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _repository.Delete(cliente);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("usuario/{UsuarioId}")]
        public async Task<IActionResult> GetClienteUsuario(int UsuarioId)
        {
            var clientes = await _repository.GetClienteUsuarioAsync(UsuarioId);

            if (clientes == null || !clientes.Any())
            {
                return NotFound("Esse usuário não possui clientes");
            }
            var clientesDto = _mapper.Map<List<ClienteUsuarioDto>>(clientes);

            return Ok(clientesDto);
        }


    }
}
