using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneLineBling.Models
{
    public enum Rank
    {
        MeSoHorny, KeepGoing, NotMyThing
    }

    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int FetishID { get; set; }
        public int CustomerID { get; set; }
        public Rank? Rank { get; set; }
        
        public Fetish Fetish { get; set; }
        public Customer Customer { get; set; }

    }
}
