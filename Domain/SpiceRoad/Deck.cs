using Domain.SpiceRoad.Cards;
using Domain.SpiceRoad.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Domain.SpiceRoad
{
    public class Deck<T> where T : Card
    {
        private static Random random = new Random();
        protected List<T> _cards;

        public Deck(){
            _cards = new List<T>();
        }

        public void AddCard(T card) {
            _cards.Add(card);
        }

        public void AddCards(ICollection<T> cards) {
            _cards.AddRange(cards);
        }

        public T Draw() {
            if (_cards.Count == 0) {
                throw new NoCardsToDrawException();
            }
            int index = random.Next(0, _cards.Count);

            var card = _cards[index];
            _cards.RemoveAt(index);

            return card; 
        }

        public IList<T> DrawAll() {
            var allCards = _cards;
            _cards = new List<T>();
            return allCards;
        }
    }
}
