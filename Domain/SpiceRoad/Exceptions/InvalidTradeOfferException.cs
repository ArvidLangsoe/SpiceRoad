using System;
using System.Diagnostics;

namespace Domain.SpiceRoad.Exceptions
{
    public class InvalidTradeOfferException :Exception
    {
        public InvalidTradeOfferException(Guid cardId, int cardIndex, int? resourceCount):base($"Trade failed for card: {cardId}, number of resources {resourceCount??0} has to match card position {cardIndex}")
        {

        }
    }
}