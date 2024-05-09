using GradeUp.Entities;

namespace GradeUp.Repository.Implementation
{
    public class ChatRepository : IChatRepository
    {
        private GradeUpContext context;

        public ChatRepository()
        {
            context = new GradeUpContext();

        }

        public Chat getChatById(long id)
        {
            return context.Chat.FirstOrDefault(c => c.id == id);
        }


        public List<Chat> getChatByUserId1(long id_user1)
        {
            return context.Chat.Where(c => c.id_user1 == id_user1).ToList<Chat>(); 
        }

        public List<Chat> getChatByUserId2(long id_user2)
        {
            return context.Chat.Where(c => c.id_user2 == id_user2).ToList<Chat>();
        }



    }
}
