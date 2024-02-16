using FastEndpoints;
using Logicea.Cards.Data.Models;

namespace Cards.Search
{
    internal sealed class Request : SearchModel
    {

        [FromClaim]
        public string UserID { get; set; } = default!;

    }


    internal sealed class Response : CardModel
    {

    }
}
