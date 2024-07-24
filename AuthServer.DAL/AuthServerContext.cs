using AuthServer.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL
{
    public class AuthServerContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AuthServerContext(DbContextOptions<AuthServerContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRefreshToken>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.RefreshToken).IsRequired().HasMaxLength(200);
            });
        }
    }
}
