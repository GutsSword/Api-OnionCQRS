﻿using Hepsi.Api.Domain.Common;

namespace Hepsi.Api.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T: class, IEntityBase, new()
    {
        Task AddAsync(T entity ) ;
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task HardDeleleteAsync(T entity);
    }
}
