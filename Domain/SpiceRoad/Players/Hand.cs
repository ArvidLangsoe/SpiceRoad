using Domain.SpiceRoad.Cards;
using Domain.SpiceRoad.Cards.PlayableCards;
using Domain.SpiceRoad.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.SpiceRoad.Players
{
    public class Hand : Deck<PlayableCard>
    {
        public IEnumerable<PlayableCard> Cards { get { return _cards.AsEnumerable(); } }

        public PlayableCard RemoveCard(Guid cardId) {
            var removedCard = _cards.FirstOrDefault(x => x.Id == cardId);

            if (removedCard == null) {
                throw new NoEntityFoundWithIdException<Card>(cardId);
            }
            _cards.Remove(removedCard);
            return removedCard;
        }

    }
}
