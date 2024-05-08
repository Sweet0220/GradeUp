using GradeUp.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
