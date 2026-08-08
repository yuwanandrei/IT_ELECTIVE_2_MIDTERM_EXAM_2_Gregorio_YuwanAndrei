using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories;

public interface IUserRepository
{
    User GetByUsername(string username);
    User GetByEmail(string email);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    void Add(User user);
}
