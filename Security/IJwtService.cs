using WebApplication1.Class;

namespace WebApplication1.Security
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwt(TB_USER user);

    }
}
