using System.Collections.Generic;
using System.Threading.Tasks;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.interfaces.service
{
    public interface IUserChatService
    {
        Task<List<UsuarioChat>> GetUserChatOfClient();
    }
}
