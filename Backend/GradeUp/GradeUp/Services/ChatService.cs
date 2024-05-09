using GradeUp.Entities;
using GradeUp.Repository.Implementation;
using GradeUp.Repository;

namespace GradeUp.Services
{
    public class ChatService
    {
        private readonly IChatRepository chatRepository;

        public ChatService()
        {
            chatRepository = new ChatRepository();
        }

        public Chat getChatById(long id)
        {
            return chatRepository.getChatById(id);
        }

        public List<Chat> getChatByUserId1(long id_user1)
        {
            return chatRepository.getChatByUserId1(id_user1);
        }

        public List<Chat> getChatByUserId2(long id_user2)
        {
            return chatRepository.getChatByUserId1(id_user2);
        }
    }
}
