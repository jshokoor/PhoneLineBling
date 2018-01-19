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
    public class DetailsModel : PageModel
    {
        private readonly PhoneLineBling.Data.HotlineContext _context;

        public DetailsModel(PhoneLineBling.Data.HotlineContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.SingleOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
