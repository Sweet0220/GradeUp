using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IMessageRepository
    {
        Message getMessageById(long id);
        List<Message> getMessageByChatId(long id_chat);
    }
}
