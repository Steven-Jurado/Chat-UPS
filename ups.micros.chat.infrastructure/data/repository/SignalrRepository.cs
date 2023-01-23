using Microsoft.AspNetCore.SignalR;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.domain.entities.mensaje;
using ups.micros.chat.infrastructure.data.context;

namespace ups.micros.chat.infrastructure.data.repository
{
    public class SignalrRepository : Hub, ISignalrRepository
    {

        private readonly Context _context;

        public SignalrRepository(Context context)
        {
            _context = context;
        }

        public async Task SendMessage(string message, string idGroup)
        {
            try
            {
                await Clients.Group(idGroup).SendAsync("MessageUsuario", message);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task SendMessageSqlServer(string message)
        {
            try
            {
                _context.Mensajes.Add(new Mensaje()
                {
                    FechaCreacion = DateTime.UtcNow.AddHours(-5),
                    ContenidoMensaje = message
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task CreateGroupChat(string idGroup)
        {
            try
            {

                await Groups.AddToGroupAsync(Context.ConnectionId, idGroup);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
