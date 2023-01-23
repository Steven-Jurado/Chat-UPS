using System.Threading.Tasks;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.application.interfaces.service;

namespace ups.micros.chat.application.services
{
    public class SignalrService : ISignalrService
    {

        private readonly ISignalrRepository _signalrRepository;

        public SignalrService(ISignalrRepository signalrRepository)
        {
            _signalrRepository = signalrRepository;
        }

        public async Task CreateGroupChatHub(string idGroup)
        {
            await _signalrRepository.CreateGroupChat(idGroup);
        }

        public async Task SendMessageHub(string message, string idGroup)
        {
            await _signalrRepository.SendMessage(message, idGroup);
        }
    }
}
