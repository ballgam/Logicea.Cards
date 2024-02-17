using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;

namespace Logicea.Cards.Services.Contracts
{
    public interface ICardService
    {
        Task<int?> CreateOrUpdateCard(Card entity);
        Task DeleteCard(int cardID, int userID);
        Task<Card?> GetCard(int cardID);
        Task<IEnumerable<Card>> GetCardsByUser(int userID);
        Task<IEnumerable<Card>> SearchCards(int userID, SearchModel searchModel);
    }
}
