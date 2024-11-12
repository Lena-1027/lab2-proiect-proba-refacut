using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2_proiect_proba_refacut.Data;
using lab2_proiect_proba_refacut.Models;

namespace lab2_proiect_proba_refacut.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext _context;

        public DetailsModel(lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(i =>i.Publisher)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
