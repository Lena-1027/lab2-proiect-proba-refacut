using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab2_proiect_proba_refacut.Models;

namespace lab2_proiect_proba_refacut.Data
{
    public class lab2_proiect_proba_refacutContext : DbContext
    {
        public lab2_proiect_proba_refacutContext (DbContextOptions<lab2_proiect_proba_refacutContext> options)
            : base(options)
        {
        }

        public DbSet<lab2_proiect_proba_refacut.Models.Book> Book { get; set; } = default!;
        public DbSet<lab2_proiect_proba_refacut.Models.Publisher> Publisher { get; set; } = default!;
    }
}
