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
using ApiClienteUsuarioCompleta.Model.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using AutoMapper;
using ApiClienteUsuarioCompleta.Model.Entities;

namespace ApiClienteUsuarioCompleta.Controllers
{
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
            return Ok(cliente);
        }

        // PUT: api/Clientes/5
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
    }
}
