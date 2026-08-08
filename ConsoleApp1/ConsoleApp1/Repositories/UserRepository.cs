using ConsoleApp1.Models;

namespace ConsoleApp1.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();
    private static int _nextId = 1;
    private static readonly object Lock = new();

    public User GetByUsername(string username)
    {
        return Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public User GetByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public bool UsernameExists(string username)
    {
        return GetByUsername(username) != null;
    }

    public bool EmailExists(string email)
    {
        return GetByEmail(email) != null;
    }

    public void Add(User user)
    {
        lock (Lock)
        {
            user.Id = _nextId++;
            Users.Add(user);
        }
    }
}
