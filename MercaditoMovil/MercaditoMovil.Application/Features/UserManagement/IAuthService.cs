using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Features.UserManagement
{
    /// <summary>
    /// Authentication and registration use cases.
    /// </summary>
    public interface IAuthService
    {
        bool Login(string username, string password, out string message);
        bool Register(User user, out string message);
    }
}
