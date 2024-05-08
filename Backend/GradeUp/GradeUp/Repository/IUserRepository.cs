using GradeUp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Repository
{
    public interface IUserRepository
    {
        Users getUserByEmail(string email);
        Users getUserById(long id);
        Users getUserByUsername(string username);
        void deleteUserById(long id);
        void addUser(Users user);
        void updateUser(Users user);
    }
}
