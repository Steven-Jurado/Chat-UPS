using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.domain.entities.usuario;
using ups.micros.chat.infrastructure.data.context;

namespace ups.micros.chat.infrastructure.data.repository
{
    public class UserChatRepository : IUserChatRepository
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserChatRepository(IHttpContextAccessor contextAccessor, Context context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<List<UsuarioChat>> GetUserChatOfClient()
        {
            try
            {
                var response = _contextAccessor.HttpContext.Session.GetInt32("IdUsuario");

                List<UsuarioChat> listUserChat = await _context.UsuarioChat.Where(x => x.IdUsuario == response).Select(x => new UsuarioChat
                {
                    IdUsuarioChat = x.IdUsuarioChat,
                    IdentificadorGrupo = x.IdentificadorGrupo,
                    Nombre = x.Nombre
                }).ToListAsync();


                return listUserChat;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
