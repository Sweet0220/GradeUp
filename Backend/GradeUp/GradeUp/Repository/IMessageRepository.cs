using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IMessageRepository
    {
        Message getMessageById(long id);
        List<Message> getMessageByChatId(long id_chat);
        void addMessage(Message message);
        void updateMessage(Message message);
        void deleteMessageById(long id);
        void deleteMessageByChatId(long id_chat);
    }
}
