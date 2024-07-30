using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Repository;
using ApiClienteUsuarioCompleta.Repository.Interface;
using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ApiClienteUsuarioCompleta.Service.Interface;

namespace ApiClienteUsuarioCompleta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var clientes = await _service.GetUsuarios();
            return Ok(clientes);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _service.GetUsuarioById(id);
            if (usuario == null) return NotFound("Usuario não encontrado");
            return Ok(usuario);
        }

        [HttpGet("/nome{nome}")]

        public async Task<IActionResult> GetUsuarioByName(string nome)
        {
            var usuarios = await _service.GetUsuarioByName(nome);
            if (usuarios == null) return NotFound("Usuário não encontrado");
            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioAtualizarDto usuario)
        {
            var usuarioBanco = await _service.PutUsuario(id, usuario);
            if (usuarioBanco == null) return BadRequest("Erro ao atualizar usuario");
            return Ok(usuarioBanco);
        }

        // POST: api/Usuarios
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuarioAdicionarDto usuario)
        {
            if (usuario == null) return BadRequest("Dados inválidos");
            var usuarioRetorno = await _service.PostUsuario(usuario);
            return Ok(usuarioRetorno);
        }

        // DELETE: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _service.DeleteUsuario(id);
            if (usuario == null) return NotFound("Usuario não encontrado");
            return NoContent();
        }
    }
}
