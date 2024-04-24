using GradeUp.Entities;

namespace GradeUp.Repository
{
    public interface IUserRepository
    {
        Users getUserByEmail(string email);
        Users getUserById(long id);
        Users getUserByUsername(string username);
        void deleteUserById(long id);
    }
}
