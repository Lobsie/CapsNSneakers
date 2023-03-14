using Imi.Project.Api.Core.Entities.Base;
using Imi.Project.Api.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity, TFilter> where TEntity : EntityBase where TFilter : PagingFilter
    {
        Task<TEntity> GetByIdAsync(Guid id);

        IQueryable<TEntity> GetAllAsync();

        Task<IEnumerable<TEntity>> ListAllAsync();

        Task<PagedList<TEntity>> GetPagedAsync(TFilter filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);
    }
}