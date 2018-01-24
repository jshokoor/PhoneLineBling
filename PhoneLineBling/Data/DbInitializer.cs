using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneLineBling.Models;

namespace PhoneLineBling.Data
{
    public class DbInitializer
    {
        public static void Initialize(HotlineContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return; // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer{FirstName="Jonny",LastName="Blaze",PhoneNumber="1231231234",EmailAddress="jblaze@yahoo.com",MembershipPlan="Baller"},
                new Customer{FirstName="Ed",LastName="Boxer",PhoneNumber="1231231234",EmailAddress="eboxer@yahoo.com",MembershipPlan="Baller"},
                new Customer{FirstName="Jay",LastName="Black",PhoneNumber="1231231234",EmailAddress="jblack@yahoo.com",MembershipPlan="Baller"},
                new Customer{FirstName="Heaven",LastName="Ass",PhoneNumber="1231231234",EmailAddress="hass@yahoo.com",MembershipPlan="Baller"},
                new Customer{FirstName="Haley",LastName="Angel",PhoneNumber="1231231234",EmailAddress="hangel@yahoo.com",MembershipPlan="Premium"},
                new Customer{FirstName="Tamor",LastName="Jock",PhoneNumber="1231231234",EmailAddress="tjock@yahoo.com",MembershipPlan="Premium"},
                new Customer{FirstName="Grace",LastName="Porn",PhoneNumber="1231231234",EmailAddress="gporn@yahoo.com",MembershipPlan="Premium"}
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var fetishes = new Fetish[]
            {
                new Fetish{FetishID=1, Title="Look back at it"},
                new Fetish{FetishID=2, Title="Melons"},
                new Fetish{FetishID=3, Title="Game of thrones"},
                new Fetish{FetishID=4, Title="Far East"},
                new Fetish{FetishID=5, Title="Role Play"}
            };
            foreach (Fetish c in fetishes)
            {
                context.Fetishes.Add(c);
            }
            context.SaveChanges();

            var subscriptions = new Subscription[]
            {
                new Subscription{CustomerID=1, SubscriptionID=4, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=1, SubscriptionID=3, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=2, SubscriptionID=3, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=3, SubscriptionID=1, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=4, SubscriptionID=1, Rank=Rank.NotMyThing},
                new Subscription{CustomerID=5, SubscriptionID=1, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=5, SubscriptionID=5, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=7, SubscriptionID=1, Rank=Rank.MeSoHorny},
                new Subscription{CustomerID=7, SubscriptionID=2, Rank=Rank.NotMyThing}
            };
            foreach (Subscription f in subscriptions)
            {
                context.Subscriptions.Add(f);
            }
            context.SaveChanges();
        }
    }
}
