using GradeUp.Entities;
using GradeUp.Repository.Implementation;
using GradeUp.Repository;

namespace GradeUp.Services
{
    public class MessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
        }

        public Message getMessageById(long id)
        {
            return messageRepository.getMessageById(id);
        }

        public List<Message> getMessageByChatId(long id_chat)
        {
            return messageRepository.getMessageByChatId(id_chat);
        }
    }
}
