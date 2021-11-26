namespace AuthenticationWithJWT
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password); 
    }
}
