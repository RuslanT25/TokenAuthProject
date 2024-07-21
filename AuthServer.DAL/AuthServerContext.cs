using AuthServer.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}
