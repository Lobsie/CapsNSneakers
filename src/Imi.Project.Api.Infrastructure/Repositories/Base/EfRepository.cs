using Imi.Project.Api.Core.Entities.Base;
using Imi.Project.Api.Core.Interfaces.Repositories.Base;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories.Base
{
    public abstract class EfRepository<TEntity, TFilter> : IRepository<TEntity, TFilter> where TEntity : EntityBase where TFilter : PagingFilter
    {
        protected readonly ApplicationDbContext _dbContext;

        public EfRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<TEntity> GetAllAsync()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<PagedList<TEntity>> GetPagedAsync(TFilter filter)
        {
            var source = await GetAllAsync().ToListAsync();

            return await Task.Run(() => PagedList<TEntity>.ToPagedList(source, filter.PageNumber, filter.PageSize));
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
                throw new NullReferenceException(nameof(TEntity));

            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            DbSet<TEntity> DbSet = _dbContext.Set<TEntity>();
        }
    }
}