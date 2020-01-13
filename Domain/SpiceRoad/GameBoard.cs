using Domain.SpiceRoad.Cards;
using Domain.SpiceRoad.Cards.PlayableCards;
using Domain.SpiceRoad.Exceptions;
using Domain.SpiceRoad.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.SpiceRoad
{
    public class GameBoard
    {
        private readonly IList<Trade> availableTrades;
        private static readonly int Num_Trade_Cards = 6;

        private readonly Deck<PlayableCard> tradeableCards;
        public IEnumerable<Trade> AvailableTrades => availableTrades.AsEnumerable();

        public GameBoard(ICollection<PlayableCard> cardsInGame) {
            tradeableCards = new Deck<PlayableCard>();
            tradeableCards.AddCards(cardsInGame);

            availableTrades = new List<Trade>();
            FillTradeSelection();
        }

        public void TradeCardWithPlayer(Player player, Guid cardId) {
            var trade = availableTrades.FirstOrDefault(x => x.Card.Id == cardId);

            if (trade == null) {
                throw new NoEntityFoundWithIdException<Card>(cardId);
            }

            availableTrades.Remove(trade);
            player.Hand.AddCard(trade.Card);
            FillTradeSelection();
        }

        private void FillTradeSelection() {
            try
            {
                while (availableTrades.Count < Num_Trade_Cards)
                {
                    availableTrades.Add(new Trade(tradeableCards.Draw()));
                }
            }
            catch (NoCardsToDrawException)
            {
                //Expected when deck is empty.
            }
        }

        
    }
}
