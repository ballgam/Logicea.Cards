using FastEndpoints;
using Logicea.Cards.Auth;
using Logicea.Cards.Services.Contracts;

namespace Cards.Delete
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        private readonly ICardService _cardService;

        public Endpoint(ICardService cardService)
        {
            _cardService = cardService;
        }

        public override void Configure()
        {
            Delete("/cards/delete/{CardID}");
            Claims(Claim.UserID);
            AccessControl(
                keyName: "User_Delete_Own_Card",
                behavior: Apply.ToThisEndpoint,
                groupNames: "UserCards");

            Summary(s =>
            {
                s.Summary = "Endpoint for deleting a card";
            });
        }


        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await _cardService.DeleteCard(r.CardID, r.UserID);

            Response.Message = "Card Deleted Successfully";
        }
    }
}