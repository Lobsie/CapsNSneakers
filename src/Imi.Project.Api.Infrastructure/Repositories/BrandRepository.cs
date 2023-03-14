using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Paging;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class BrandRepository : EfRepository<Brand, PagingFilter>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Brand> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Brands
                .Include(x => x.Caps)
                .SingleOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}