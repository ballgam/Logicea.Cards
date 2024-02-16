using FastEndpoints;
using Logicea.Cards.Data.Entities;

namespace Cards.Create
{
    internal sealed class Mapper : Mapper<Request, Response, Card>
    {
        public override async Task<Card> ToEntityAsync(Request r, CancellationToken ct = default)
        {
            return await Task.FromResult(new Card
            {
                Name = r.Name,
                Description = r.Description,
                Color = r.Color,
                Status = r.Status,
            });
        }
    }
}