using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab2_proiect_proba_refacut.Data;
using lab2_proiect_proba_refacut.Models;


namespace lab2_proiect_proba_refacut.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext _context;

        public CreateModel(lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher{ get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
