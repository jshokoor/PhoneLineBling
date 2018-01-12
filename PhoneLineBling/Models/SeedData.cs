using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneLineBling.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerContext>>()))
            {
                // Look for any customers.
                if (context.Customer.Any())
                {
                    return; // DB has been seeded
                }

                context.Customer.AddRange(
                    new Customer
                    {
                        FirstName = "Jonny",
                        LastName = "Blaze",
                        PhoneNumber = "6192462877",
                        EmailAddress = "jblaze@yahoo.com",
                        SexualOrientation = "straight",
                        MembershipPlan = "Baller"
                    },

                    new Customer
                    {
                        FirstName = "Ed",
                        LastName = "Boxer",
                        PhoneNumber = "1231231234",
                        EmailAddress = "edboxer@yahoo.com",
                        SexualOrientation = "gay",
                        MembershipPlan = "Premium"
                    },

                    new Customer
                    {
                        FirstName = "Jay",
                        LastName = "Black",
                        PhoneNumber = "1231231234",
                        EmailAddress = "jayblack@yahoo.com",
                        SexualOrientation = "gay",
                        MembershipPlan = "Premium"
                    },

                    new Customer
                    {
                        FirstName = "Heaven",
                        LastName = "Ass",
                        PhoneNumber = "1231231234",
                        EmailAddress = "heavenass@yahoo.com",
                        SexualOrientation = "straight",
                        MembershipPlan = "Premium"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
