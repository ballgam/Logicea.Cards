using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Services.Contracts;

namespace Cards.Create
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
            Post("/cards/save");
            Claims(Claim.UserID);
            AccessControl(
                keyName: "User_Create_Own_Card",
                behavior: Apply.ToThisEndpoint,
                groupNames: "UserCards");

            Summary(s =>
            {
                s.Summary = "Endpoint for creating a new card";
                s.ExampleRequest = new Request
                {
                    Color = "#AABBCC",
                    Description = "A testing card",
                    Name = "Testing Card",
                    Status = Logicea.Cards.Data.Entities.CardStatus.ToDo
                };
            });
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var entity = Map.ToEntity(r);

            Response.CardID = await _cardService.CreateOrUpdateCard(entity);

            if (Response.CardID is null)
                ThrowError("Unable to save the card!");

            await SendAsync(Response);
        }
    }
}