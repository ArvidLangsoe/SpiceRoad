using Domain.SpiceRoad;
using Domain.SpiceRoad.Cards;
using Domain.SpiceRoad.Cards.PlayableCards;
using Domain.SpiceRoad.Exceptions;
using Domain.SpiceRoad.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DomainTest.SpiceRoad
{
    public class PlayerTest
    {
        [Fact]
        public void Given_Board_With_Cards_When_Player_Buys_First_Card_Then_Card_Is_Transferred() {
            var testCards = StubCard.GenerateCards(10);
            var board = new GameBoard(testCards);
            var player = new Player(board);

            var boughtCardId = board.AvailableTrades.ElementAt(0).Card.Id;
            player.BuyCard(boughtCardId);

            Assert.Contains(boughtCardId, player.Hand.Cards.Select(x => x.Id));
            Assert.DoesNotContain(boughtCardId, board.AvailableTrades.Select(x => x.Card.Id));
        }

        [Fact]
        public void Given_Board_With_Insufficient_Cards_When_Player_Buys_Card_Then_Fewer_Available_Cards()
        {
            var generatedCards = 6;
            var expectedCardCount = generatedCards - 1;
            var testCards = StubCard.GenerateCards(generatedCards);
            var board = new GameBoard(testCards);
            var player = new Player(board);

            var boughtCardId = board.AvailableTrades.ElementAt(0).Card.Id;
            player.BuyCard(boughtCardId);


            Assert.Equal(expectedCardCount, board.AvailableTrades.Count());
        }

        [Fact]
        public void When_Player_Buys_Card_With_Wrong_Id_Then_NoEntityFoundException()
        {
            var generatedCards = 6;
            var testCards = StubCard.GenerateCards(generatedCards);
            var board = new GameBoard(testCards);
            var player = new Player(board);

            var boughtCardId = Guid.NewGuid();
            Assert.Throws<NoEntityFoundWithIdException<Card>>(() => player.BuyCard(boughtCardId));
        }

    }

    internal class StubCard : PlayableCard {
        private StubCard()
        {
            Id = Guid.NewGuid();
        }

        public static List<PlayableCard> GenerateCards(int numCards) { 
            var list = new List<PlayableCard>();
            for (var i = 0; i < numCards; i++)
                list.Add(new StubCard());
            return list;
            
        }
    }
}
