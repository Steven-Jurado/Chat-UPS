using System.Threading.Tasks;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.interfaces.service
{
    public interface IAccountService
    {
        Task<bool> AuthenticationAsync(Usuario usuario);
        Task<bool> AuthenticationClientAsync(Usuario usuario);
    }
}
