using ClassificaApi.Model;
using ClassificaApi.Repositories;
using ClassificaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassificaApi.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepostitory _usuariosRepostitory;
        public UsuariosController(IUsuariosRepostitory usuariosRepostitory)
        {
            _usuariosRepostitory = usuariosRepostitory;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _usuariosRepostitory.Get();
        }

        [HttpGet]
        [Route("Get_Usuarios")]
        public async Task<ActionResult<dynamic>> GetUsuarios([FromBody] Usuarios model)
        {
            var usuario = await _usuariosRepostitory.Get(model.Id, model.Senha);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha invalidos" });
            }
            var token = TokenService.GenerateToken(usuario);
            return (usuario, token);
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> Post([FromBody] Usuarios usuarios)
        {
            var novoUsuario = await _usuariosRepostitory.Create(usuarios);

            return CreatedAtAction(nameof(GetUsuarios), new { id = novoUsuario.Id }, novoUsuario);
        }

    }
}
