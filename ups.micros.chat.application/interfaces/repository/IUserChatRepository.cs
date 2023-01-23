using System.Collections.Generic;
using System.Threading.Tasks;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.interfaces.repository
{
    public interface IUserChatRepository
    {
        Task<List<UsuarioChat>> GetUserChatOfClient();
    }
}
