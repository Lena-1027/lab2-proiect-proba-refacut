using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab2_proiect_proba_refacut.Data;
using lab2_proiect_proba_refacut.Models;
using lab2_proiect_proba_refacut.Models.VIEWmodels;

namespace lab2_proiect_proba_refacut.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext _context;

        public IndexModel (lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers= await _context.Publisher
           .Include(i => i.Books)
           .OrderBy(i => i.PublisherName)
           .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;

            }
        }
    }
}
