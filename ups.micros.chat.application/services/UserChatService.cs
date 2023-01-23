using System.Collections.Generic;
using System.Threading.Tasks;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.services
{
    public class UserChatService : IUserChatService
    {
        private readonly IUserChatRepository _userChatRepository;

        public UserChatService(IUserChatRepository userChatRepository)
        {
            _userChatRepository = userChatRepository;
        }

        public async Task<List<UsuarioChat>> GetUserChatOfClient()
        {
            return await _userChatRepository.GetUserChatOfClient();
        }
    }
}
