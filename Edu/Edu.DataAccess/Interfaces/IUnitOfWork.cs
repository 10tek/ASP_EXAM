using Edu.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Application> ApplicationRepository { get; set; }

        Task Save();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
