using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneLineBling.Models
{
    public enum Rank
    {
        A, B, C, D, F
    }
    public class Fetish
    {
        public int FetishID { get; set; }
        public int CategoryID { get; set; }
        public int CustomerID { get; set; }
        public Rank? Rank { get; set; }

        public Category Category { get; set; }
        public Customer Customer { get; set; }
    }
}
