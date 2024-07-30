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
using ApiClienteUsuarioCompleta.Service.Interface;

namespace ApiClienteUsuarioCompleta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _service.GetClientes();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var clienteRetorno = await _service.GetClienteById(id);

            if (clienteRetorno == null)
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
            var clienteAtualizar = await _service.PutCliente(id, cliente);
            if (clienteAtualizar == null) return BadRequest("Erro ao atualizar cliente");
            return Ok(cliente);
        }

        //POST: api/Clientes
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteAdicionarDto cliente)
        {
            if (cliente == null) return BadRequest("Erro ao adicionar cliente");
            var clienteRetorno = await _service.PostCliente(cliente);
            return Ok(clienteRetorno);
        }

        // DELETE: api/Clientes/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var cliente = await _service.DeleteCliente(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return NoContent();
        }

        [HttpGet("usuario/{UsuarioId}")]
        public async Task<IActionResult> GetClienteUsuario(int UsuarioId)
        {
            var clientes = await _service.GetClienteUsuario(UsuarioId);
            if (clientes == null) return NotFound("Esse usuário não possui clientes");
            return Ok(clientes);
        }

    }
}
