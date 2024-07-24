using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Model.Entities;
using System.Globalization;

namespace ApiClienteUsuarioCompleta.Service.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(LoginDto loginDto);
    }
}
