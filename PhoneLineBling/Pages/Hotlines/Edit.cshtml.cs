using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneLineBling.Data;
using PhoneLineBling.Models;

namespace PhoneLineBling.Pages.Hotlines
{
    public class EditModel : PageModel
    {
        private readonly PhoneLineBling.Data.HotlineContext _context;

        public EditModel(PhoneLineBling.Data.HotlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customers.FindAsync(id);

            if (await TryUpdateModelAsync<Customer>(
                customerToUpdate,
                "customer",
                c => c.FirstName, c => c.LastName, c => c.PhoneNumber, c => c.EmailAddress, c => c.SexualOrientation, c => c.MembershipPlan))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
