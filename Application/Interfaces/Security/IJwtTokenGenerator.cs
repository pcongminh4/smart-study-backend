public interface IJwtTokenGenerator
{
    string GenenatorAccessToken(long userId, string userName);
}