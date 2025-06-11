namespace WebApplication1.Security
{
    public class AuthenticationResponse
    {
        public string Name { get ; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
