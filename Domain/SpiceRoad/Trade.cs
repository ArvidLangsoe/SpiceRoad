using Domain.SpiceRoad.Cards.PlayableCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SpiceRoad
{
    public class Trade
    {
        public PlayableCard Card { get; set; }

        public Trade(PlayableCard card) {
            Card = card;
        }
    }
}
