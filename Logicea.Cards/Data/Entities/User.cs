
using Microsoft.Extensions.Hosting;

namespace Logicea.Cards.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = default!;
        public string PasswordHash { get; internal set; } = default!;
        public DateOnly DateCreated { get; internal set; }
        public Role Role { get; set; }

        public virtual List<Card> Cards { get; set; }
    }


    public enum Role
    {
        Member,
        Admin
    }
}
