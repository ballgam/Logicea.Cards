using System.Reflection.Metadata;

namespace Logicea.Cards.Data.Entities
{
    public class Card
    {
        public int CardId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Color { get; set; } = default!;
        public CardStatus Status { get; set; } = CardStatus.ToDo;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
    }

    public enum CardStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
