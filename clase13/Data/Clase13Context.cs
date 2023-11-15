using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using clase13.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace clase13.Data
{
    public class Clase13Context : IdentityDbContext
    {
        public Clase13Context (DbContextOptions<Clase13Context> options)
            : base(options)
        {
        }

        public DbSet<clase13.Models.Client> Client { get; set; } = default!;
    }
}
