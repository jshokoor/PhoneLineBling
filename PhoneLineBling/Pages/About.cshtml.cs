using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneLineBling.Data;
using PhoneLineBling.Models.HotlineViewModels;
using Microsoft.EntityFrameworkCore;

namespace PhoneLineBling.Pages
{
    public class AboutModel : PageModel
    {
        private readonly HotlineContext _context;

        public AboutModel(HotlineContext context)
        {
            _context = context;
        }

        public IList<MembershipPlanGroup> Customer { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<MembershipPlanGroup> data =
                from customer in _context.Customers
                group customer by customer.MembershipPlan into planGroup
                select new MembershipPlanGroup()
                {
                    MembershipPlan = planGroup.Key,
                    CustomerCount = planGroup.Count()
                };

            Customer = await data.AsNoTracking().ToListAsync();
        }
    }
}
