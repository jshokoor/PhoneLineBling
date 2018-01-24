using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneLineBling.Models.HotlineViewModels
{
    public class SubscriptionGroup
    {
        public Fetish Fetish { get; set; }

        public int CustomerCount { get; set; }
    }
}
