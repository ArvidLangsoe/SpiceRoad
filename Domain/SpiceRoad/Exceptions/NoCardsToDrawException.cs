using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SpiceRoad.Exceptions
{
    public class NoCardsToDrawException :Exception
    {

        public NoCardsToDrawException() : base($"There are no cards to draw.") { 
        }
    }
}
