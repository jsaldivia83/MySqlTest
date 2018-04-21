using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlTest.Data;

namespace MySqlTest.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MySqlTest.Data.PetContext _context;

        public DeleteModel(MySqlTest.Data.PetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.SingleOrDefaultAsync(m => m.Id == id);

            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FindAsync(id);

            if (Dog != null)
            {
                _context.Dog.Remove(Dog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
