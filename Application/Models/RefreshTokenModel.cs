namespace Application.Auth.Models;

public class RefreshTokenModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Token { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public DateTime? RevokedAt { get; set; }
}
