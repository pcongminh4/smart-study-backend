using Domain.Entities;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly SmartStudyDbContext _context;
    public UserRepository(SmartStudyDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ExistsByUserName(string userName)
    {
        return await _context.Users.AnyAsync(u => u.UserName == userName);
    }

    public async Task<Domain.Entities.User?> GetUserByUserNameAsync(string userName)
    {

        var ef = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);
        return ef?.ToDomain();
    }

    public async Task<Domain.Entities.User?> GetUserByUserIdAsync(long id)
    {

        var ef = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return ef?.ToDomain();
    }

    public async Task AddAsync(Domain.Entities.User user)
    {
        var efUser = user.ToEf();
        _context.Users.Add(efUser);
        await _context.SaveChangesAsync();
    }
}