using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneLineBling.Models
{
    public class Fetish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FetishID { get; set; }
        public string Title { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
