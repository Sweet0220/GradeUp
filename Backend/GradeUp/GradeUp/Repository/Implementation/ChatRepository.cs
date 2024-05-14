using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;

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

        public void updateChat(Chat chat)
        {
            try
            {
                Chat chatToUpdate = context.Chat.FirstOrDefault(chatToUpdate => chatToUpdate.id == chat.id);
                if (chatToUpdate != null)
                {
                    /*
                        public long id_user1 { get; set; }
                        public long id_user2 { get; set; }
                    */
                    chatToUpdate.id_user1 = chat.id_user1;
                    chatToUpdate.id_user2 = chat.id_user2;
                    context.SaveChanges(true);

                }
                else
                {
                    throw new ArgumentException("Chat data not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

        public void removeChat(long id)
        {
            try
            {
                Chat chatToDelete = context.Chat.FirstOrDefault(c => c.id == id);
                if (chatToDelete != null)
                {
                    context.Chat.Remove(chatToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Chat not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

        public void deleteChatByUserId(long id_user)
        {
            try
            {
                Chat chatToDelete1 = context.Chat.FirstOrDefault(c => c.id_user1 == id_user);
                Chat chatToDelete2 = context.Chat.FirstOrDefault(c => c.id_user1 == id_user);

                if (chatToDelete1 != null)
                {
                    context.Database.ExecuteSqlRaw($"DELETE FROM Message WHERE id_user = {id_user}");
                    context.Chat.Remove(chatToDelete1);
                    context.SaveChanges();
                }
                else
                {
                    if (chatToDelete2 != null)
                    {
                        context.Chat.Remove(chatToDelete2);
                        context.SaveChanges();
                    }
                    throw new ArgumentException("Chat not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }
    }



}
}
