using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Services.Contracts;

namespace Cards.Get
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        private readonly ICardService _cardService;

        public Endpoint(ICardService cardService)
        {
            _cardService = cardService;
        }

        public override void Configure()
        {
            Get("/cards/{CardID}");
            Claims(Claim.UserID);
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var card = await _cardService.GetCard(r.CardID);


            if (card is null)
                await SendNotFoundAsync();
            else
                await SendAsync(Map.FromEntity(card));
        }
    }
}