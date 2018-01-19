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

            var categories = new Category[]
            {
                new Category{CategoryID=1, Title="Look back at it"},
                new Category{CategoryID=2, Title="Melons"},
                new Category{CategoryID=3, Title="Game of thrones"},
                new Category{CategoryID=4, Title="Far East"},
                new Category{CategoryID=5, Title="Role Play"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var fetishes = new Fetish[]
            {
                new Fetish{CustomerID=1, CategoryID=4, Rank=Rank.A},
                new Fetish{CustomerID=1, CategoryID=3, Rank=Rank.B},
                new Fetish{CustomerID=2, CategoryID=3, Rank=Rank.A},
                new Fetish{CustomerID=3, CategoryID=1, Rank=Rank.A},
                new Fetish{CustomerID=4, CategoryID=1, Rank=Rank.F},
                new Fetish{CustomerID=5, CategoryID=1, Rank=Rank.A},
                new Fetish{CustomerID=5, CategoryID=5, Rank=Rank.B},
                new Fetish{CustomerID=7, CategoryID=1, Rank=Rank.A},
                new Fetish{CustomerID=7, CategoryID=2, Rank=Rank.F},
            };
            foreach (Fetish f in fetishes)
            {
                context.Fetishes.Add(f);
            }
            context.SaveChanges();
        }
    }
}
