using Microsoft.Extensions.Options;
using SimpleApp.Interfaces;
using SimpleApp.Options;


namespace SimpleApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthServiceOptions options;
        public AuthService(IOptions<AuthServiceOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;
        }

        // This is really poor authentication. In real app the password should be stored in db. 
        // IdentityServer could be used to provide good authentication.
        public bool IsAdmin(string password)
        {
            return password == options.AdminPassword;
        }
    }
}
