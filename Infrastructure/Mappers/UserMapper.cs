using Domain.Entities;
using Infrastructure.Entities;

namespace Infrastructure.Mappers;

public static class UserMapper
{
    public static Domain.Entities.User ToDomain(this Infrastructure.Entities.User u)
    {
        return new Domain.Entities.User(
            u.Id,
            u.UserName,
            u.HashedPassword,
            u.FullName ?? string.Empty,
            u.AvatarUrl ?? string.Empty,
            u.Point ?? 0,
            u.Role ?? "user",
            u.CreateAt ?? DateTime.UtcNow,
            u.LastLogin
        );
    }

    public static Infrastructure.Entities.User ToEf(this Domain.Entities.User u)
    {
        return new Infrastructure.Entities.User
        {
            Id = u.Id,
            UserName = u.UserName,
            HashedPassword = u.HashedPassword,
            FullName = u.FullName,
            AvatarUrl = u.AvatarUrl,
            Point = u.Point,
            Role = u.Role,
            CreateAt = u.CreatedAt,
            LastLogin = u.LastLogin
        };
    }
}
