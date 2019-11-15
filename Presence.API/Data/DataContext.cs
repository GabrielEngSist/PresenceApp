using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presence.API.Domain;

namespace Presence.API.Data
{

    public class DataContext : IdentityDbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Presenca> Presencas { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
