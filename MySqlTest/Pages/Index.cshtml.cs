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
    public class IndexModel : PageModel
    {
        private readonly MySqlTest.Data.PetContext _context;

        public IndexModel(MySqlTest.Data.PetContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }

        public async Task OnGetAsync()
        {
            Dog = await _context.Dog.ToListAsync();
        }
    }
}
