using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlTest.Data;

namespace MySqlTest.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MySqlTest.Data.PetContext _context;

        public CreateModel(MySqlTest.Data.PetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dog.Add(Dog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}