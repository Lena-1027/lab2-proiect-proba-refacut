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

namespace lab2_proiect_proba_refacut.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext _context;

        public IndexModel (lab2_proiect_proba_refacut.Data.lab2_proiect_proba_refacutContext context)
        {
            _context = context;
        }

        public IList <Book>? Book { get;set; } = default!;

        public BookData BookD { get; set; }
        public int BookID { get; set; }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, string? sortOrder, string? searchString)
        {
            BookD = new BookData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? " title_desc " : "";
            AuthorSort = sortOrder == "author" ? "author_desc" : "author";

            CurrentFilter = searchString;

            BookD.Books = await _context.Book
                        .Include(b => b.Publisher)
                        .AsNoTracking()
                        .OrderBy(b => b.Title)
                        .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Author.Contains ( searchString )|| s.Title.Contains(searchString));
            }
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
               .Where(i => i.ID == id.Value).Single();

            }
            switch (sortOrder)
            {
                case " title_desc ":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                   s.Title);
                    break;
                case " author_desc ":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                   s.Author);
                    break;
                case "author":
                    BookD.Books = BookD.Books.OrderBy(s => s.Author);
                    break;
                default:
                    BookD.Books = BookD.Books.OrderBy(s => s.Title
                   );
                    break;
            }
        }
    }
}








