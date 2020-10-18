using HackTheU_Escrow_Feature.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTheU_Escrow_Feature.Data
{
    public class EscrowDbContext : IdentityDbContext<User>
    {
        public EscrowDbContext(DbContextOptions<EscrowDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.ProjectCreations)
                .WithOne(p => p.Creator);

            base.OnModelCreating(builder);
        }
    }
}
