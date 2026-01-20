using Domain.Entities;

public interface IUserRepository
{
    Task<bool> ExistsByUserName(string userName);
    Task AddAsync(User user);
    Task<User?> GetUserByUserIdAsync(long id);
    Task<User?> GetUserByUserNameAsync(string userName);
}