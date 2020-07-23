using Edu.DataAccess.Interfaces;
using Edu.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DataAccess.EF.Implementations
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly DataContext _context;

        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }

        public ValueTask<EntityEntry<Application>> CreateAsync(Application entity)
        {
            var createdPost = _context.Applications.AddAsync(entity);
            return createdPost;
        }

        public bool Edit(Application entity)
        {
            try
            {
                _context.Applications.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(Guid id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }

        public Task<Application> GetAsync(Guid id)
        {
            return _context.Applications.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            _context.Applications.Remove(_context.Applications.Find(id));
        }
    }
}
