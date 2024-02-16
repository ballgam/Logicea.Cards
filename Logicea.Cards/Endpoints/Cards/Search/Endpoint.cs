using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;
using Logicea.Cards.Services.Contracts;

namespace Cards.Search
{
    internal sealed class Endpoint : Endpoint<Request, IEnumerable<Response>, Mapper>
    {
        private readonly ICardService _cardService;

        public Endpoint(ICardService cardService)
        {
            _cardService = cardService;
        }

        public override void Configure()
        {
            Get("/cards/search?filter={Filter}&value={Value}&page={Page}&size={Size}");
            Claims(Claim.UserID);
            AccessControl(
                keyName: "User_Search_Own_Cards",
                behavior: Apply.ToThisEndpoint,
                groupNames: "UserCards");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var seachModel = new SearchModel
            {
                Filter = r.Filter,
                Page = r.Page,
                Size = r.Size,
                Value = r.Value
            };

            IEnumerable<Card> cards = await _cardService.SearchCards(r.UserID, seachModel);

            if (cards is null || !cards.Any())
                await SendNotFoundAsync();
            else
            {
                var responses = cards.Select(card => Map.FromEntity(card));

                await SendAsync(responses, cancellation: c);
            }
        }
    }
}