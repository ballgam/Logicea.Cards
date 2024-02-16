using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Services.Contracts;

namespace Cards.GetCards
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
            Get("/cards/getall");
            Claims(Claim.UserID);
            AccessControl(
                keyName: "User_Get_Own_Cards",
                behavior: Apply.ToThisEndpoint,
                groupNames: "UserCards");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            IEnumerable<Card> cards = await _cardService.GetCardsByUser(r.UserID);

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