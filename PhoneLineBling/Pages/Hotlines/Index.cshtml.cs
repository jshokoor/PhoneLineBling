using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneLineBling.Data;
using PhoneLineBling.Models;

namespace PhoneLineBling.Pages.Hotlines
{
    public class IndexModel : PageModel
    {
        private readonly PhoneLineBling.Data.HotlineContext _context;

        public IndexModel(PhoneLineBling.Data.HotlineContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> Customer { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            EmailSort = sortOrder == "Email" ? "email_desc" : "Email";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Customer> customerIQ = from c in _context.Customers
                                              select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customerIQ = customerIQ.Where(c => c.LastName.Contains(searchString)
                                        || c.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customerIQ = customerIQ.OrderByDescending(c => c.FirstName);
                    break;
                case "Email":
                    customerIQ = customerIQ.OrderBy(c => c.EmailAddress);
                    break;
                case "email_desc":
                    customerIQ = customerIQ.OrderByDescending(c => c.EmailAddress);
                    break;
                default:
                    customerIQ = customerIQ.OrderBy(c => c.FirstName);
                    break;
            }

            int pageSize = 3;
            Customer = await PaginatedList<Customer>.CreateAsync(
                customerIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
