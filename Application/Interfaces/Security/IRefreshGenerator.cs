using Application.Auth.Models;

public interface IRefreshTokenGenerator
{
    Task SaveAsync(RefreshTokenModel token);
    Task<RefreshTokenModel?> GetValidAsync(string token);
    Task RevokeAsync(long tokenId);
}