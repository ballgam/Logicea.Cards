using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;

namespace Logicea.Cards.Services.Contracts
{
    internal interface ICardService
    {
        string CreateOrUpdateCard(Task<Card> entity);
        Task<bool> DeleteCard(string cardID, string userID);
        Task<Card> GetCard(string cardID);
        Task<IEnumerable<Card>> GetCardsByUser(string userID);
        Task<IEnumerable<Card>> SearchCards(string userID, SearchModel seachModel);
    }
}
