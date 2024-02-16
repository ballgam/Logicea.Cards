using Logicea.Cards.Data.Entities;

namespace Logicea.Cards.Data.Models
{
    public class CardModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Color { get; set; } = default!;
        public CardStatus Status { get; set; } = CardStatus.ToDo;
    }
}
