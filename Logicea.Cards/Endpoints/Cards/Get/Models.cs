using Logicea.Cards.Data.Models;

namespace Cards.Get
{
    internal sealed class Request
    {
        public string CardID { get; internal set; } = default!;
    }


    internal sealed class Response : CardModel
    {

    }
}
