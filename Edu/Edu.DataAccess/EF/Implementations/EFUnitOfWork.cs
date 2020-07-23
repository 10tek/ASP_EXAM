using Edu.DataAccess.Interfaces;
using Edu.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DataAccess.EF.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IRepository<Application> ApplicationRepository { get; set; }

        public EFUnitOfWork(DataContext context, IRepository<Application> applicationRepository)
        {
            _context = context;
            ApplicationRepository = applicationRepository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }
}
