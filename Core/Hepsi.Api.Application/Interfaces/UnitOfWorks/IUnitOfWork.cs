using Hepsi.Api.Application.Interfaces.Repositories;
using Hepsi.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsi.Api.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteReporsitory<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
