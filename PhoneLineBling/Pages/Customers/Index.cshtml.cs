using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneLineBling.Models;

namespace PhoneLineBling.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly PhoneLineBling.Models.CustomerContext _context;

        public IndexModel(PhoneLineBling.Models.CustomerContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }
        public SelectList SexualOrientations;
        public string CustomerSexualOrientation { get; set; }

        public async Task OnGetAsync(string customerSexualOrientation, string searchString)
        {
            // Use LINQ tp get list of sexual orientations.
            IQueryable<string> sexualOrientationQuery = from m in _context.Customer
                                                        orderby m.SexualOrientation
                                                        select m.SexualOrientation;

            var customers = from m in _context.Customer
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.FirstName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(customerSexualOrientation))
            {
                customers = customers.Where(x => x.SexualOrientation == customerSexualOrientation);
            }

            SexualOrientations = new SelectList(await sexualOrientationQuery.Distinct().ToListAsync());
            Customer = await customers.ToListAsync();
        }
    }
}
