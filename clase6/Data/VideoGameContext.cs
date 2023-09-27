using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clase5.Models;

namespace clase5.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext (DbContextOptions<VideoGameContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; } = default!;
        public DbSet<GameConsole> Console { get; set; } = default!;
    }
}
