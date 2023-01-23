using System.Threading.Tasks;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.interfaces.repository
{
    public interface IAccountRepositoy
    {
        Task<bool> AuthenticationAsync(Usuario usuario);
        Task<Usuario> GetUser(Usuario usuario);
    }
}
