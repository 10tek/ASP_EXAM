using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        ValueTask<EntityEntry<T>> CreateAsync(T entity);
        bool Edit(T entity);
        void Remove(Guid id);
        
        bool Exist(Guid id);
    }
}
