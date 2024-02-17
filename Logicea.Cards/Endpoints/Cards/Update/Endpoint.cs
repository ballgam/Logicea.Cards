using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Services.Contracts;

namespace Cards.Update
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
            Put("/cards/update");
            Claims(Claim.UserID);
            AccessControl(
                keyName: "User_Update_Own_Card",
                behavior: Apply.ToThisEndpoint,
                groupNames: "UserCards");
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = Map.ToEntity(r);

            Response.CardID =await _cardService.CreateOrUpdateCard(entity);

            if (Response.CardID is null)
                ThrowError("Unable to save the card!");

            await SendAsync(Response);
        }
    }
}