using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly LoginUserUseCase _loginUserUseCase;


    public AuthController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _loginUserUseCase = loginUserUseCase;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<string>>> Register(RegisterRequest request)
    {
        await _registerUserUseCase.execute(request);
        return ApiResponse<string>.Ok("Register successful");
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Login(LoginRequest request)
    {
        var result = await _loginUserUseCase.LoginAsync(request);
        return ApiResponse<LoginResponse>.Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> Refresh(RefreshTokenRequest request)
    {
        var result = await _loginUserUseCase.RefreshAsync(request.RefreshToken);
        return ApiResponse<LoginResponse>.Ok(result);
    }
}
