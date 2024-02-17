using Logicea.Cards.Data;
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;
using Logicea.Cards.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Logicea.Cards.Services
{
    public class CardService : ICardService
    {
        private readonly LogiceaDbContext _dbContext;

        public CardService(LogiceaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> CreateOrUpdateCard(Card entity)
        {
            int? cardId = default!;
            if (entity != null)
            {
                _dbContext.Cards.Add(entity);
                await _dbContext.SaveChangesAsync();

                cardId = entity.CardId;
            }

            return cardId;
        }

        public async Task DeleteCard(int cardID, int userID)
        {
            var item = await _dbContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardID && c.User!.UserId == userID);
            if (item != null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Card?> GetCard(int cardID)
        {
            var item = await _dbContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardID);
            return item;
        }

        public async Task<IEnumerable<Card>> GetCardsByUser(int userID)
        {
            var items = await _dbContext.Cards.Where(c => c.User.UserId == userID).Select(c => c).ToListAsync();
            return items;
        }

        public async Task<IEnumerable<Card>> SearchCards(int userID, SearchModel searchModel)
        {
            var queryable = _dbContext.Cards.Where(c => c.User.UserId == userID);

            queryable = searchModel.Filter.Trim().ToLower() switch
            {
                "color" => queryable.Where(c => c.Color == searchModel.Value),
                "status" => queryable.Where(c => c.Status == (CardStatus)Enum.Parse(typeof(CardStatus), searchModel.Value)),
                _ => queryable.Where(c => c.Name == searchModel.Value),
            };

            var items = await queryable.Select(c => c).ToListAsync();
            return items;
        }
    }
}
