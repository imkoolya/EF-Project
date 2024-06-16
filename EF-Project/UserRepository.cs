using Microsoft.EntityFrameworkCore;

public class UserRepository
{
    private AppContext context;

    public UserRepository()
    {
        context = new AppContext();
    }

    public User GetUserById(int userId)
    {
        return context.Users.FirstOrDefault(u => u.Id == userId);
    }

    public IQueryable<User> GetAllUsers()
    {
        return context.Users;
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }

    public void UpdateUserName(int userId, string newName)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            user.Name = newName;
            context.SaveChanges();
        }
    }
}