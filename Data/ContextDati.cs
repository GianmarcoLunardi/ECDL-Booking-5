using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Models
{
    public class ContextDati : DbContext
    {
        public ContextDati(DbContextOptions<ContextDati> options)
: base(options) { }

        public DbSet<SessionType> SessionTypes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Place> Places { get; set; }

    }
}

