using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.infrastructure.data.repository;

namespace ups.micros.chat.signalr.api.Controllers
{
    [Route("api/signalr")]
    [ApiController]
    public class SignalrController : ControllerBase
    {
        private readonly ISignalrService _signalrService;
        private readonly IHubContext<SignalrRepository> _hubConnection;

        public SignalrController(ISignalrService signalrService, IHubContext<SignalrRepository> hubConnection)
        {
            _signalrService = signalrService;
            _hubConnection = hubConnection;
        }

        [HttpGet]
        [Route("enviar-mensaje/{idGroup}")]
        public async Task<IActionResult> ValidarMensaje([FromHeader][Required] string message, string idGroup)
        {
            //await _hubConnection.Clients.Group(idGroup).SendAsync("MessageUsuario", message);
            await _hubConnection.Clients.All.SendAsync("MessageUsuario", message);

            return Ok();
        }

        [HttpPost]
        [Route("agregar-grupo")]
        public async Task<IActionResult> ValidarMensaje([FromBody][Required] string idGroup)
        {

            await _signalrService.CreateGroupChatHub(idGroup);

            return Ok();
        }
    }
}
