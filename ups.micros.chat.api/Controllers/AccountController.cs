using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Metodo De Autenticacion
        /// </summary>
        /// <param name="userName" example="Steven"></param>
        /// <param name="password" example="1234"></param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpPost]
        [Route("autenticacion")]
        public async Task<IActionResult> Autentication([FromHeader][Required] string userName, [FromHeader][Required] string password)
        {
            Usuario usuario = new()
            {
                NombreUsuario = userName,
                Clave = password
            };

            return await _accountService.AuthenticationAsync(usuario) ? Ok("Autenticacion Correctamente") : NotFound("Registro No Encontrado");
        }
    }
}
