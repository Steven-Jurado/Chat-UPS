using System.Threading.Tasks;

namespace ups.micros.chat.application.interfaces.service
{
    public interface ISignalrService
    {
        Task SendMessageHub(string message, string idGroup);
        Task CreateGroupChatHub(string message);
    }
}
