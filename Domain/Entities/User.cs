namespace Domain.Entities;

public class User
{
    public long Id { get; private set;}
    public string UserName { get; private set; }
    public string HashedPassword { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string AvatarUrl { get; private set; } = string.Empty;
    public int Point { get; private set; } = 0;
    public string Role { get; private set; } = "user";
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastLogin { get; private set; }

    public User(long id, string userName, string hashedPassword,
            string fullName, string avatarUrl,
            int point, string role,
            DateTime createdAt, DateTime? lastLogin)
    {
        Id = id;
        UserName = userName;
        HashedPassword = hashedPassword;
        FullName = fullName;
        AvatarUrl = avatarUrl;
        Point = point;
        Role = role;
        CreatedAt = createdAt;
        LastLogin = lastLogin;
    }

    public User(string userName, string hashedPassword,
                string? fullName = null, string? avatarUrl = null)
    {
        UserName = userName;
        HashedPassword = hashedPassword;
        FullName = fullName ?? string.Empty;
        AvatarUrl = avatarUrl ?? string.Empty;
        CreatedAt = DateTime.UtcNow;
    }


    // public void AddPoint(int value)
    // {
    //     if (value <= 0)
    //         throw new DomainException("Point must be greater than 0");

    //     Point += value;
    // }

    // public void UpdateLastLogin()
    // {
    //     LastLogin = DateTime.UtcNow;
    // }
}
