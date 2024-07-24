using ApiClienteUsuarioCompleta.Model.Dtos.Usuario;
using ApiClienteUsuarioCompleta.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApiClienteUsuarioCompleta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarUsuario([FromBody] LoginDto loginDto)
        {
            var token = await _tokenService.GenerateToken(loginDto);
            if (token == null) return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
