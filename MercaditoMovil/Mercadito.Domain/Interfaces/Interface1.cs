using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// User repository contract independent from storage.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Returns user by username or null.
        /// </summary>
        User? GetByUsername(string username);

        /// <summary>
        /// Persists user. Returns false and sets error on failure.
        /// </summary>
        bool Add(User user, out string error);
    }
}
