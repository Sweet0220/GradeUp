using GradeUp.Entities;
using System.Linq;

namespace GradeUp.Repository.Implementation
{
    public class MessageRepository : IMessageRepository
    {
        private GradeUpContext context;

        public MessageRepository()
        {
            context = new GradeUpContext();

        }

        public Message getMessageById(long id)
        {
            return context.Message.FirstOrDefault(m => m.id == id);
        }


        public List<Message> getMessageByChatId(long id_chat)
        {
            return context.Message.Where(m => m.id_chat == id_chat).ToList<Message>();
        }
    }
}
