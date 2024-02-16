using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;
using Logicea.Cards.Services.Contracts;

namespace Logicea.Cards.Services
{
    public class CardService : ICardService
    {
        public string CreateOrUpdateCard(Task<Card> entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCard(string cardID, string userID)
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetCard(string cardID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetCardsByUser(string userID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Card>> ICardService.SearchCards(string userID, SearchModel seachModel)
        {
            throw new NotImplementedException();
        }
    }
}
