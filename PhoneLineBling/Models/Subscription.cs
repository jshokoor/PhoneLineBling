using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneLineBling.Models
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubscriptionID { get; set; }
        public string Title { get; set; }
        public int Followers { get; set; }

        public ICollection<Fetish> Fetishes { get; set; }
    }
}
