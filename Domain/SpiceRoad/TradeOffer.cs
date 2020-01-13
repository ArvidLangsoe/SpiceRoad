using System;
using System.Collections.Generic;
using System.Text;
using Domain.SpiceRoad.Resources;

namespace Domain.SpiceRoad
{
    public class TradeOffer
    {
        public List<Resource> Resources { get; set; }

        public TradeOffer(params Resource[] resources)
        {
            Resources = new List<Resource>();
            Resources.AddRange(resources);
        }
    }
}
