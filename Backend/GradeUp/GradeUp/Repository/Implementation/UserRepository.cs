using GradeUp.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradeUp.Repository.Implementation;


namespace GradeUp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private GradeUpContext _context;
        public UserRepository() 
        {
            _context = new GradeUpContext();
        }

        public Users getUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email == email);
        }

        public Users getUserById(long id)
        {
            return _context.Users.FirstOrDefault(u => u.id == id);
        }

        public Users getUserByUsername(string username) 
        {
            return _context.Users.FirstOrDefault(u => u.username == username);
        }

        public void deleteUserById(long id)
        {
            try
            {
                Users userToDelete = _context.Users.FirstOrDefault(u => u.id == id);
                if (userToDelete != null)
                {
                    _context.Database.ExecuteSqlRaw($"DELETE FROM Teaching WHERE id_user = {id}");
                    _context.Database.ExecuteSqlRaw($"DELETE FROM Review WHERE id_user = {id}");
                    _context.Database.ExecuteSqlRaw($"DELETE FROM Request WHERE id_user1 = {id} OR id_user2 = {id}");
                   
                    
                    var chatIdToDelete = _context.Chat.Where(c => c.id_user1 == userToDelete.id || c.id_user2 == userToDelete.id).Select(c => c.id).ToList();
                    foreach (var chatId in chatIdToDelete)
                        _context.Database.ExecuteSqlRaw($"DELETE FROM Message WHERE id_chat = {chatId}");

                    _context.Database.ExecuteSqlRaw($"DELETE FROM Chat WHERE id_user1 = {id} OR id_user2 = {id}");

                    _context.Users.Remove(userToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("User not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }

        public void addUser(Users user)
        {
            try
            {
                if (user != null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Invalid user informations.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the entity changes.", ex);
            }
        }


        public void updateUser(Users user)
        {
            try
            {
                Users userToUpdate = _context.Users.FirstOrDefault(userToUpdate => userToUpdate.id == user.id);
                if (userToUpdate != null)
                {
                    //_context.Users.Update(userToUpdate);
                    userToUpdate.username = user.username;
                    userToUpdate.email = user.email;
                    userToUpdate.password = user.password;
                    userToUpdate.name = user.name;
                    userToUpdate.sex = user.sex;
                    userToUpdate.role = user.role;

                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("User information was not updated.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes in database.", ex);
            }
        }

    }
}
