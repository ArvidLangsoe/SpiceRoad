using Domain.SpiceRoad.Cards.PlayableCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SpiceRoad.Players
{
    public class Player
    {
        private GameBoard Game { get; }
        public Hand Hand {get;}
        public Deck<PlayableCard> Discarded { get; set; }

        public Player(GameBoard game)
        {
            Game = game;
            Hand = new Hand(); 
        }

        public void Rest() {
            var discardedCards = Discarded.DrawAll();
            Hand.AddCards(discardedCards);
        }

        public void BuyCard(Guid cardId, TradeOffer tradeOffer=null) {
            Game.TradeCardWithPlayer(this, cardId, offer: tradeOffer);
        }

        

    }
}
