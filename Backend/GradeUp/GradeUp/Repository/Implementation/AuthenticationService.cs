using GradeUp.Entities;
using GradeUp.Models;
using System.Runtime.Serialization.Json;

namespace GradeUp.Repository.Implementation
{
    public class AuthenticationService
    {
        private readonly IUserRepository userRepository;
        public AuthenticationService()
        {
            userRepository = new UserRepository();
        }

        public Users getUserByMailPassword(AuthenticationEntity request)
        {
            Users user = userRepository.getUserByEmail(request.email);
  
            if (user == null)
            {
                throw new Exception("The credentials you had entered were incorrect. Please try again.");
            }

            if (user.password == request.password)
                return user;
            else
                throw new Exception("The credentials you had entered were incorrect. Please try again.");

        }
    }
}
