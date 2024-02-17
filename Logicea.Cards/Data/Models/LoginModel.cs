namespace Logicea.Cards.Data.Models
{
    public class LoginModel
    {
        public int UserID { get; set; }
        public string Email { get; set; } = default!;
        public string PasswordHash { get; internal set; } = default!;
    }
}
