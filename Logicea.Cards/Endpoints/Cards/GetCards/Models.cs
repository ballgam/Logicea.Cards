using FastEndpoints;
using Logicea.Cards.Data.Models;

namespace Cards.GetCards
{
    internal sealed class Request
    {

        [FromClaim]
        public string UserID { get; set; } = default!;
    }


    internal sealed class Response : CardModel
    {

    }
}
