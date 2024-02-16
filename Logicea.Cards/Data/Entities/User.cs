namespace Logicea.Cards.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Store hashed passwords only
        public Role Role { get; set; }
    }
}
