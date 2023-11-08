using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clase7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class VideoGameContext : IdentityDbContext
    {
        public VideoGameContext (DbContextOptions<VideoGameContext> options)
            : base(options)
        {
        }

        public DbSet<clase7.Models.Game> Game { get; set; } = default!;

        public DbSet<clase7.Models.GameConsole> GameConsole { get; set; } = default!;
        public DbSet<clase7.Models.Person> Person { get; set; } = default!;
        public DbSet<clase7.Models.Movement> Movement { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.Consoles)
                .WithMany(e => e.Games)
                .UsingEntity("VideoGameConsoles");

            base.OnModelCreating(modelBuilder);
        }
}
