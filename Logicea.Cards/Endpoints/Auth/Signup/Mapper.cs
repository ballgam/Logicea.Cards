using FastEndpoints;
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;
using System.Globalization;

namespace Auth.Signup
{
    internal sealed class Mapper : Mapper<Request, Response, User>
    {
        static readonly CultureInfo _culture = new("en-US");

        public override User ToEntity(Request r)
        {
            var user = new User
            {
                Email = r.Email.ToLower(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.Password),
                DateCreated = DateOnly.FromDateTime(DateTime.UtcNow),
            };

            user.Role = (Role)Enum.Parse(typeof(Role), r.Role);

            return user;
        }
    }
}