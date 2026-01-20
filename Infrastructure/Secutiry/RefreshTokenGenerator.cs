using Application.Auth.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly SmartStudyDbContext _context;
    public RefreshTokenGenerator(SmartStudyDbContext context)
    {
        _context = context;
    } 
    public async Task<RefreshTokenModel?> GetValidAsync(string token)
    {
        var ef = await _context.RefreshTokens.FirstOrDefaultAsync(
            x => x.Token == token && x.RevokedAt == null && x.ExpiresAt > DateTime.UtcNow 
        );
        return ef?.ToModel();
    }

    public async Task RevokeAsync(long tokenId)
    {
        var ef = await _context.RefreshTokens.FindAsync(tokenId);
        if (ef == null) return;

        ef.RevokedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync(RefreshTokenModel model)
    {
        _context.RefreshTokens.Add(model.ToEf());
        await _context.SaveChangesAsync();
    }
}