using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artiekel>().HasData(new Artiekel
            {
                Id = 1,
                Naam ="plan1",
                Potmaat = 4,
                Planthoogte = 3,
                Kleur = "Rood",
                Productgroep = "Tulpen"
            });
        }
        public DbSet<Artiekel> Artiekel { get; set; }
        
    }
