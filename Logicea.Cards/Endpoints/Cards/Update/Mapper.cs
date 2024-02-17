using FastEndpoints;
using Logicea.Cards.Data.Entities;

namespace Cards.Update
{
    internal sealed class Mapper : Mapper<Request, Response, Card>
    {
        public override Card ToEntity(Request r)
        {
            return new Card
            {
                Name = r.Name,
                Description = r.Description,
                Color = r.Color,
                Status = r.Status,
            };
        }
    }
}