using Application.Auth.Models;

public class LoginUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserUseCase(
        IUserRepository userRepository, 
        IJwtTokenGenerator jwtTokenGenerator, 
        IRefreshTokenGenerator refreshTokenGenerator,
        IPasswordHasher passwordHasher
    )
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _refreshTokenGenerator = refreshTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
        Console.WriteLine(user?.Id);
        if (user == null || !_passwordHasher.Verify(request.Password, user.HashedPassword))
            throw new UnauthorizedAccessException("Invalid credential");

        var accessToken = _jwtTokenGenerator.GenenatorAccessToken(user.Id, user.UserName);
        Console.WriteLine(accessToken);
        var refreshToken = new RefreshTokenModel
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            ExpiredAt = DateTime.UtcNow.AddDays(7)
        };

        await _refreshTokenGenerator.SaveAsync(refreshToken);

        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    public async Task<LoginResponse> RefreshAsync(string refreshToken)
    {
        var validToken = await _refreshTokenGenerator.GetValidAsync(refreshToken);
        if (validToken == null)
            throw new UnauthorizedAccessException("Invalid refresh token");

        var user = await _userRepository.GetUserByUserIdAsync(validToken.UserId);
        if (user == null)
            throw new UnauthorizedAccessException("User not found");

        await _refreshTokenGenerator.RevokeAsync(validToken.Id);

        var newRefreshToken = new RefreshTokenModel
        {
            UserId = validToken.UserId,
            Token = Guid.NewGuid().ToString(),
            CreatedAt=  DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddDays(7),
        };

        await _refreshTokenGenerator.SaveAsync(newRefreshToken);
        
        var accessToken = _jwtTokenGenerator.GenenatorAccessToken(user.Id, user.UserName);
        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token
        };
    }

    public async Task LogoutAsync(long refreshTokenId)
    {
        await _refreshTokenGenerator.RevokeAsync(refreshTokenId);
    }
}