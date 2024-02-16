namespace Logicea.Cards.Data.Models
{
    internal class SearchModel
    {
        public string Filter { get; set; } = default!;

        public string Value { get; set; } = default!;
        public int Page { get; set; }

        public int Size { get; set; } = 10;
    }
}
