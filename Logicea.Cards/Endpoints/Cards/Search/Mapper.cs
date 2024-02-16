using FastEndpoints;
using Logicea.Cards.Data.Entities;

namespace Cards.Search
{
    internal sealed class Mapper : Mapper<Request, Response, Card>
    {
        public override Response FromEntity(Card e)
        {
            return new Response
            {
                Color = e.Color,
                Description = e.Description,
                Name = e.Name,
                Status = e.Status,
            };
        }
    }
}