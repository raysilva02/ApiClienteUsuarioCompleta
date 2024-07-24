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

namespace ApiClienteUsuarioCompleta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var clientes = await _repository.GetUsuariosAsync();
            return Ok(clientes);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _repository.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }

            var usuarioRetorno = _mapper.Map<UsuarioDetailsDto>(usuario);

            return Ok(usuarioRetorno);
        }

        [HttpGet("/nome{nome}")]

        public async Task<IActionResult> GetUsuarioByName(string nome)
        {
            var usuarios = await _repository.GetUsuarioByNameAsync(nome);
            if (usuarios == null) return NotFound("Usuário não encontrado");

            var usuariosRetorno = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Ok(usuariosRetorno);
        }

        // PUT: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioAtualizarDto usuario)
        {
            var usuarioBanco = await _repository.GetUsuarioByIdAsync(id);
            var usuarioAtualizar = _mapper.Map(usuario, usuarioBanco);
            _repository.Update(usuarioAtualizar);
            return await _repository.SaveChangesAsync()
                ? Ok(usuario)
                : BadRequest("Erro ao editar usuario");
        }

        // POST: api/Usuarios
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuarioAdicionarDto usuario)
        {
            if (usuario == null) return BadRequest("Dados inválidos");

            var usuarioAdicionar = _mapper.Map<Usuario>(usuario);

            _repository.Add(usuarioAdicionar);

            return await _repository.SaveChangesAsync()
               ? Ok(usuario)
               : BadRequest("Erro ao adicionar usuario");
        }

        // DELETE: api/Usuarios/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _repository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _repository.Delete(usuario);
            return await _repository.SaveChangesAsync()
               ? NoContent()
               : BadRequest("Erro ao excluir usuario");
        }
    }
}
