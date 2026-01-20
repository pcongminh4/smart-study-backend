using Domain.Entities;

public class RegisterUserUseCase
{
    public readonly IUserRepository _userRepository;
    public readonly IPasswordHasher _passwordHasher;
    public RegisterUserUseCase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }  
    public async Task execute(RegisterRequest request)
    {
        if (await _userRepository.ExistsByUserName(request.UserName))
            throw new Exception("Username already exists");
        var hashedPassword = _passwordHasher.Hash(request.Password);
        var user = new User(request.UserName, hashedPassword);
        await _userRepository.AddAsync(user);
    }
}