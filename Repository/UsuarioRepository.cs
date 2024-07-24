using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Model.Dtos.Cliente;
using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;
using ApiClienteUsuarioCompleta.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiClienteUsuarioCompleta.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly ApiDbContext _context;

        public UsuarioRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FromSqlInterpolated($"SELECT * FROM Usuarios WHERE Id = {id}").FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarioByNameAsync(string name)
        {
            var usuarios = await _context.Usuarios.FromSqlInterpolated($"SELECT * FROM Usuarios WHERE Nome = {name}").ToListAsync();
            var usuariosDto = usuarios.Select(u => new UsuarioDto
            {
                Nome = u.Nome, 
                Email = u.Email,
            }).ToList();
            return usuariosDto;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.FromSqlRaw("SELECT * FROM Usuarios").ToListAsync();
            var usuariosDto = usuarios.Select(u => new UsuarioDto
            {
                Nome = u.Nome,
                Email = u.Email,
            }).ToList();
            return usuariosDto;
        }
    }
}
