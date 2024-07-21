using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthServerContext _context;

        public UnitOfWork(AuthServerContext appDbContext)
        {
            _context = appDbContext;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
