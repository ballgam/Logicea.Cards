using FastEndpoints;
using Logicea.Cards.Data.Models;

namespace Cards.Search
{
    internal sealed class Request : SearchModel
    {

        [FromClaim]
        public int UserID { get; set; } = default!;

    }


    internal sealed class Response : CardModel
    {

    }
}
