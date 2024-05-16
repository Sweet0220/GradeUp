using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;
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

        public void addMessage(Message message) 
        {
            try
            {
                if(message != null)
                {
                    context.Message.Add(message);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid message data.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving changes.", ex);
            }
        }

        public void updateMessage(Message message)
        {
            try
            {
                Message messageToUpdate = context.Message.FirstOrDefault(messageToUpdate => messageToUpdate.id == message.id);
                if (messageToUpdate != null)
                {
                    /*
                        public string text { get; set; }
                        public long id_chat { get; set; }
                        public long id_user { get; set; }
                        public string hour { get; set; }
                        public DateTime send_date { get; set; }
                    */
                    messageToUpdate.text = message.text;
                    messageToUpdate.id_chat = message.id_chat;
                    messageToUpdate.id_user = message.id_user;
                    messageToUpdate.hour = message.hour;
                    messageToUpdate.send_date = message.send_date;
                    context.SaveChanges(true);
                
                }
                else
                {
                    throw new ArgumentException("Message data not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

        public void deleteMessageById(long id) 
        {
            try
            {
                Message messageToDelete = context.Message.FirstOrDefault(m => m.id == id);
                if(messageToDelete != null)
                {
                    context.Message.Remove(messageToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Message not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }

        public void deleteMessageByChatId(long id_chat)
        {
            try
            {
                Message messageToDelete = context.Message.FirstOrDefault(m => m.id_chat == id_chat);
                
                if (messageToDelete != null)
                {
                    context.Message.Remove(messageToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Message in chat not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while saving changes in database.", ex);
            }
        }
    }
  
}
