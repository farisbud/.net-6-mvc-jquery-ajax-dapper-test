using Pusdafi_Dev.Models;

namespace Pusdafi_Dev.Interface
{
    public interface LoginIntf
    {
        Task<User> AuthenticateUserAsync (string mail);
        Task<User> AuthenticatePassAsync(string pass);
    }
}
