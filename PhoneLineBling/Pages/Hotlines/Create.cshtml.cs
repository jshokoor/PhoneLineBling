using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneLineBling.Data;
using PhoneLineBling.Models;

namespace PhoneLineBling.Pages.Hotlines
{
    public class CreateModel : PageModel
    {
        private readonly PhoneLineBling.Data.HotlineContext _context;

        public CreateModel(PhoneLineBling.Data.HotlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCustomer = new Customer();

            if (await TryUpdateModelAsync<Customer>(
                emptyCustomer,
                "customer",     //Prefix for form value.
                s => s.FirstName, s => s.LastName, s => s.PhoneNumber, s => s.EmailAddress, s => s.SexualOrientation, s => s.MembershipPlan))
            {
                _context.Customers.Add(emptyCustomer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}