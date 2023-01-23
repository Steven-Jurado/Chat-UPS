using System.Threading.Tasks;

namespace ups.micros.chat.application.interfaces.repository
{
    public interface ISignalrRepository
    {
        Task SendMessageSqlServer(string message);
        Task SendMessage(string message, string idGroup);
        Task CreateGroupChat(string message);
    }
}
