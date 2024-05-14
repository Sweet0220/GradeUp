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

        public void addMessage(Message message) 
        {
            messageRepository.addMessage(message);
        }

        public void updateMessage(Message message)
        {
            messageRepository.updateMessage(message);
        }

        public void removeMessage(long id)
        {
            messageRepository.deleteMessageById(id);
        }

        public void deleteMessageByChatId(long id_chat) 
        {
            messageRepository.deleteMessageByChatId(id_chat);
        }
    }
}
