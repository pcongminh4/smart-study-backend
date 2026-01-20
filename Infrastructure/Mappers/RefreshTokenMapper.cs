using Application.Auth.Models;
using Infrastructure.Entities;

public static class RefreshTokenMapper
{
    public static RefreshTokenModel ToModel(this RefreshToken ef)
    {
        return new RefreshTokenModel
        {
            Id = ef.Id,
            UserId = ef.UserId,
            Token = ef.Token,
            CreatedAt = ef.CreatedAt,
            ExpiredAt = ef.ExpiresAt,
            RevokedAt = ef.RevokedAt,
        };
    }

    public static RefreshToken ToEf(this RefreshTokenModel model)
    {
        return new RefreshToken
        {
            Id = model.Id,
            UserId = model.UserId,
            Token = model.Token,
            ExpiresAt = model.ExpiredAt,
            RevokedAt = model.RevokedAt,
        };
    }
}
