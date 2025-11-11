using System;

namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Represents an application user with null-guarded strings.
    /// </summary>
    public sealed class User
    {
        public string UserId { get; }
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName1 { get; }
        public string LastName2 { get; }
        public string NationalId { get; }
        public string Email { get; }
        public string Phone { get; }
        public string ExactAddress { get; }
        public string Province { get; }
        public string Canton { get; }
        public string District { get; }
        public string MarketId { get; }

        /// <summary>
        /// Builds a user. Defaults to empty strings and "MKT-000" when null.
        /// </summary>
        public User(
            string userId,
            string username,
            string password,
            string firstName,
            string lastName1,
            string lastName2,
            string nationalId,
            string email,
            string phone,
            string exactAddress,
            string province,
            string canton,
            string district,
            string marketId)
        {
            userId ??= string.Empty;
            username ??= string.Empty;
            password ??= string.Empty;
            firstName ??= string.Empty;
            lastName1 ??= string.Empty;
            lastName2 ??= string.Empty;
            nationalId ??= string.Empty;
            email ??= string.Empty;
            phone ??= string.Empty;
            exactAddress ??= string.Empty;
            province ??= string.Empty;
            canton ??= string.Empty;
            district ??= string.Empty;
            marketId ??= "MKT-000";

            UserId = userId;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName1 = lastName1;
            LastName2 = lastName2;
            NationalId = nationalId;
            Email = email;
            Phone = phone;
            ExactAddress = exactAddress;
            Province = province;
            Canton = canton;
            District = district;
            MarketId = marketId;
        }
    }
}
