using GradeUp.Entities;
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
                    throw new ArgumentException("user not found");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("an error while saving", ex);
            }
        }
    }
}
