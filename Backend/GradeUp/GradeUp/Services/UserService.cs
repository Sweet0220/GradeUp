using GradeUp.Entities;
using GradeUp.Repository;
using GradeUp.Repository.Implementation;

namespace GradeUp.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService() 
        {
            userRepository = new UserRepository();
        }
        public Users getByEmail(string email)
        {
            return userRepository.getUserByEmail(email);
        }
        public Users getById(long id)
        {
            return userRepository.getUserById(id);
        }
        public Users getByUsername(string username) 
        {
            return userRepository.getUserByUsername(username);
        }
        public void deleteById(long id)
        { 
            userRepository.deleteUserById(id);
        }

    }
}
